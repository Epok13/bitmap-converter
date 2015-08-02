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

// Initial header:

/************************************/
/*      Programmé par : Epok__      */
/*        Date : 22/07/2005         */
/*          Heure : 17:13           */
/*                                  */
/* Edité le 22/07/2015 par hasard ! */
/* Bon anniversaire Bitmap Converter*/
/*                                  */
/*          Version : 1.2           */
/************************************/
/*  Classe permettant de convertir	*/
/* des séries d'images d'un format	*/
/*		   bitmap à un autre		*/
/************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bitmap_Converter
{

    public partial class FenêtrePrincipale : Form
    {
        private Erreurs erreurs;

        public event DémarrerConversionEventHandler    DémarrerConversion;
        public event InterrompreConversionEventHandler InterrompreConversion;

        public FenêtrePrincipale(Erreurs erreurs)
        {
            this.erreurs = erreurs;

            InitializeComponent();

            barreDeProgression.Minimum = 0;
            barreDeProgression.Step = 1;

            ActualiserListe();
        }

        // Public

        public void ProcessusDémarré()
        {
            liste.Enabled = false;
            sélectionnerTout.Enabled = false;
            actualiser.Enabled = false;
            convertir.Enabled = false;
            barreDeMenus.Enabled = false;

            interrompre.Visible = true;
        }

        public void PasserEnModeConversion(int nombre)
        {
            texteDEtat.Text = "Conversion en cours...";

            barreDeProgression.Value = 0;
            barreDeProgression.Maximum = nombre;            
        }

        public void PasserEnModeSuppression(int nombreObjetsASupprimer)
        {
            texteDEtat.Text = "Suppression des fichiers sources en cours...";

            barreDeProgression.Value = 0;
            barreDeProgression.Maximum = nombreObjetsASupprimer;
        }

        public void ProcessusTerminé()
        {
            texteDEtat.Text = "Conversion Terminée";

            liste.Enabled = true;
            sélectionnerTout.Enabled = true;
            actualiser.Enabled = true;
            convertir.Enabled = true;
            barreDeMenus.Enabled = true;

            interrompre.Visible = false;

            AfficherLesErreurs();
        }

        public void AvancerDUnCran()
        {
            barreDeProgression.PerformStep();
        }


        // Privé

        private void ActualiserListe()
        {
            texteDEtat.Text = "En attente pour la conversion...";
            barreDeProgression.Value = 0;

            liste.Items.Clear();
            SortedList<int, string> nouvelleListe = GénérateurDeListes.GénérerListe();
            foreach (string s in nouvelleListe.Values)
            {
                liste.Items.Add(s);
            }
        }

        private void AfficherLesErreurs()
        {
            if (this.erreurs.erreur)
                (new FenêtreErreurs(this.erreurs)).ShowDialog();
            else
                MessageBox.Show("Pas d'erreurs lors de la conversion.", "Résultat de la conversion");
        }

        private void UserRequest_SélectionnerTout(object sender, EventArgs e)
        {
            for (int i = 0; i < liste.Items.Count; i++)
            {
                liste.SetSelected(i, true);
            }
        }

        private void UserRequest_DésélectionnerTout(object sender, EventArgs e)
        {
            for (int i = 0; i < liste.Items.Count; i++)
            {
                liste.SetSelected(i, false);
            }
        }

        private void UserRequest_AfficherAProposDe(object sender, EventArgs e)
        {
            (new APropos()).ShowDialog();
        }

        private void UserRequest_OuvrirOptions(object sender, EventArgs e)
        {
            FenêtreOptions f = new FenêtreOptions();

            DialogResult d = f.ShowDialog();

            if (d == DialogResult.OK)
            {
                f.Dispose();
                ActualiserListe();
            }
        }

        private void UserRequest_AfficherErreurs(object sender, EventArgs e)
        {
            AfficherLesErreurs();
        }

        private void UserRequest_Interrompre(object sender, EventArgs e)
        {
            InterrompreConversion();
        }

        private void UserRequest_Convertir(object sender, EventArgs e)
        {
            ArrayList listeConv = new ArrayList();

            foreach (string s in liste.SelectedItems)
            {
                listeConv.Add(s);
            }

            DémarrerConversion(listeConv);

        }

        private void UserRequest_Actualiser(object sender, EventArgs e)
        {
            ActualiserListe();
        }
    }
}
