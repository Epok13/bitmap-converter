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

using System;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

namespace Bitmap_Converter
{
    /// <summary>
    /// Moteur centralise les échanges entre les diférents threads.
    /// </summary>
    public sealed class Moteur
    {
        private Paramètres paramètres;
        private FenêtrePrincipale fenêtre;
        private Thread threadConversion;
        private Erreurs erreurs;

        /// <summary>
        /// Crée un objet moteur initialisé aux
        /// paramètres par défaut.
        /// </summary>
        public Moteur()
        {
            Initialiser();
        }

        /// <summary>
        /// Initialisation du moteur : on
        /// ouvre la fenêtre d'options puis
        /// on lance la fenêtre principale.
        /// </summary>
        private void Initialiser()
        {
            FenêtreOptions f = new FenêtreOptions();

            DialogResult d = f.ShowDialog();

            if (d == DialogResult.OK)
            {
                paramètres = f.Paramètres;
                erreurs = new Erreurs();
                f.Dispose();

                fenêtre = new FenêtrePrincipale(this);

                Application.Run(fenêtre);
            }

            else Application.Exit();
        }

        /// <summary>
        /// L'utilisateur à lancé le processus de conversion
        /// </summary>
        /// <param name="listeDesObjetsSelectionnés"></param>
        public void Convertir(ListBox.SelectedObjectCollection listeDesObjetsSelectionnés)
        {
            fenêtre.Bloquer();
            // Gérer les accès du thread
            Convertisseur conv = new Convertisseur(this, ToListe(listeDesObjetsSelectionnés));
            threadConversion = new Thread(new ThreadStart(conv.Convertir));
            threadConversion.Start();
        }

        /// <summary>
        /// Conversion vers format de liste ArrayList
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        private ArrayList ToListe(ListBox.SelectedObjectCollection listeIn)
        {
            ArrayList listeOut = new ArrayList();
            foreach (string s in listeIn)
            {
                listeOut.Add(s);
            }
            return listeOut;
        }

        /// <summary>
        /// Afficher la fenêtre des erreurs.
        /// </summary>
        public void AfficherLesErreurs()
        {
            if (erreurs.erreur)
                (new FenêtreErreurs(erreurs)).ShowDialog();
            else MessageBox.Show("Pas d'erreurs lors de la conversion.", "Résultat de la conversion");
        }

        /// <summary>
        /// Interruption de la conversion par l'utilisateur
        /// </summary>
        public void InterrompreConversion()
        {
            // NE doit pas interrompre le thread n'importe quand
            threadConversion.Interrupt();
        }

        /// <summary>
        /// Afficher la fenêtre de modification des options
        /// </summary>
        public void ModifierOptions()
        {
            FenêtreOptions f = new FenêtreOptions(paramètres);

            DialogResult d = f.ShowDialog();

            if (d == DialogResult.OK)
            {
                paramètres = f.Paramètres;
                f.Dispose();
                fenêtre.Actualiser(new object(), new EventArgs());
            }
        }

        // Pour que les autres objets aient un accès direct entre eux
        public Paramètres Paramètres
        {
            get
            {
                return paramètres;
            }
        }
        public FenêtrePrincipale Fenêtre
        {
            get
            {
                return fenêtre;
            } 
        }
        public Erreurs Erreurs
        {
            get
            {
                return erreurs;
            }
        }
    }
}
