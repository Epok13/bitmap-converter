/*
 * Copyright © 2005 ; 2011 ; 2015 Clément Foucher
 *
 * Distributed under the GNU GPL v2. For full terms see the file LICENSE.txt.
 *
 *
 * This file is part of Bitmap Converter.
 *
 * Bitmap Converter is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, version 2 of the License.
 *
 * Bitmap Converter is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with Bitmap Converter. If not, see <http://www.gnu.org/licenses/>.
 */

using System.Windows.Forms;
using System.Threading;
using System.Collections;

namespace Bitmap_Converter
{
    public delegate void DémarrerConversionEventHandler(ArrayList listeDesObjetsSelectionnés);
    public delegate void InterrompreConversionEventHandler();

    /// <summary>
    /// Le moteur centralise les échanges entre les diférents threads.
    /// Il AGIT sur les threads, et recoit de EVENEMENTS de leur part.
    /// </summary>
    public sealed class Moteur
    {
        private Thread threadConversion;
        private FenêtrePrincipale fenêtre;
        private Convertisseur convertisseur;
        private Erreurs erreurs;

        /// <summary>
        /// Initialisation du moteur : on
        /// ouvre la fenêtre d'options puis
        /// on lance la fenêtre principale.
        /// 
        /// Comme c'est le moteur qui gère la boucle d'application,
        /// on peut se permettre de faire Exit() si nécessaire.
        /// </summary>
        public Moteur()
        {
            FenêtreOptions f = new FenêtreOptions(true);

            DialogResult d = f.ShowDialog();

            f.Dispose();

            if (d == DialogResult.OK)
            {
                this.erreurs = new Erreurs();

                this.fenêtre = new FenêtrePrincipale(this.erreurs);

                // Abonnement aux évènements fournis par l'IU
                this.fenêtre.DémarrerConversion    += Convertir;
                this.fenêtre.InterrompreConversion += Interrompre;
                
                Application.Run(this.fenêtre);
            }
            else
                Application.Exit();
        }

        /// <summary>
        /// L'utilisateur à lancé le processus de conversion
        /// </summary>
        /// <param name="listeDesObjetsSelectionnés"></param>
        private void Convertir(ArrayList listeDesObjetsSelectionnés)
        {
            erreurs.Reset();
            convertisseur = new Convertisseur(this.erreurs, listeDesObjetsSelectionnés);

            // Abonnement aux évènements fournis par le thread de conversion
            convertisseur.DémarrageProcessus += this.DémarrageProcessus;
            convertisseur.ProcessusTerminé += this.ProcessusTerminé;

            this.threadConversion = new Thread(new ThreadStart(convertisseur.Convertir));
            this.threadConversion.Start();
        }

        /// <summary>
        /// Interruption de la conversion par l'utilisateur
        /// </summary>
        private void Interrompre()
        {
            this.convertisseur.Interrompre();
        }

        private delegate void InvoquerLesEspritsDeLaFenêtrePrincipale();
        private delegate void InvoquerLesEspritsAvecValeur(int i);

        private void DémarrageProcessus()
        {
            convertisseur.DémarrageProcessus -= this.DémarrageProcessus;

            convertisseur.DémarrageConversion += this.PassageEnModeConversion;

            // Evènement déclenché par un thread différent: invoquer
            this.fenêtre.Invoke(new InvoquerLesEspritsDeLaFenêtrePrincipale(this.fenêtre.ProcessusDémarré));
        }

        private void PassageEnModeConversion(int nombre)
        {
            convertisseur.DémarrageConversion -= this.PassageEnModeConversion;

            convertisseur.FichierConverti += this.AvancerBarreDeProgression;
            if (Properties.Settings.Default.DeleteSources == true)
                convertisseur.DémarrageSuppression += this.PassageEnModeSuppression;

            // Evènement déclenché par un thread différent: invoquer
            this.fenêtre.Invoke(new InvoquerLesEspritsAvecValeur(this.fenêtre.PasserEnModeConversion), new object[] { nombre });
        }

        private void PassageEnModeSuppression(int nombre)
        {
            convertisseur.DémarrageSuppression -= this.PassageEnModeSuppression;
            convertisseur.FichierConverti -= this.AvancerBarreDeProgression;

            convertisseur.FichierSupprimé += this.AvancerBarreDeProgression;

            // Evènement déclenché par un thread différent: invoquer
            this.fenêtre.Invoke(new InvoquerLesEspritsAvecValeur(this.fenêtre.PasserEnModeSuppression), new object[] { nombre });
        }

        private void ProcessusTerminé()
        {
            // Evènement déclenché par un thread différent: invoquer
            this.fenêtre.Invoke(new InvoquerLesEspritsDeLaFenêtrePrincipale(this.fenêtre.ProcessusTerminé));

            threadConversion = null;
            convertisseur    = null;
        }

        private void AvancerBarreDeProgression()
        {
            // Evènement déclenché par un thread différent: invoquer
            this.fenêtre.Invoke(new InvoquerLesEspritsDeLaFenêtrePrincipale(this.fenêtre.AvancerDUnCran));
        }

    }
}
