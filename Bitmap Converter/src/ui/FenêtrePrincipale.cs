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
using System.Windows.Forms;

namespace Bitmap_Converter
{
    public partial class FenêtrePrincipale : Form
    {
        private Moteur moteur;

        public FenêtrePrincipale(Moteur m)
        {
            moteur = m;

            InitializeComponent();

            Actualiser(new object(), new EventArgs());
        }

        public void AvancerDUnCran()
        {
            barreDeProgression.PerformStep();
        }

        public void PassageEnModeSuppression(int nombreObjetsASupprimer)
        {
            texteDEtat.Text = "Suppression des fichiers sources en cours...";
            barreDeProgression.Value = 0;
            barreDeProgression.Maximum = nombreObjetsASupprimer;
        }

        public void ConversionTerminée()
        {
            texteDEtat.Text = "Conversion Terminée";

            moteur.AfficherLesErreurs();
        }

        public void Actualiser(object sender, EventArgs e)
        {
            texteDEtat.Text = "En attente pour la conversion...";
            liste.Items.Clear();
            barreDeProgression.Value = 0;
            OperationsSurLaListe o = new OperationsSurLaListe(moteur.Paramètres);
            ListBox.ObjectCollection nouvelleListe = o.GetListe();
            foreach (object s in nouvelleListe)
            {
                liste.Items.Add(s);
            }
        }

        public void Bloquer()
        {
            liste.Enabled = false;
            sélectionnerTout.Enabled = false;
            actualiser.Enabled = false;
            convertir.Enabled = false;
            barreDeMenus.Enabled = false;

            interrompre.Visible = true;
        }

        public void Débloquer()
        {
            liste.Enabled = true;
            sélectionnerTout.Enabled = true;
            actualiser.Enabled = true;
            convertir.Enabled = true;
            barreDeMenus.Enabled = true;

            interrompre.Visible = false;
        }

        private void SélectionnerTout(object sender, EventArgs e)
        {
            for (int i = 0; i < liste.Items.Count; i++)
            {
                liste.SetSelected(i, true);
            }
        }

        private void DésélectionnerTout(object sender, EventArgs e)
        {
            for (int i = 0; i < liste.Items.Count; i++)
            {
                liste.SetSelected(i, false);
            }
        }

        private void Convertir(object sender, EventArgs e)
        {
            barreDeProgression.Minimum = 0;
            barreDeProgression.Maximum = liste.SelectedItems.Count;
            barreDeProgression.Value = 0;
            barreDeProgression.Step = 1;
            texteDEtat.Text = "Conversion en cours...";

            moteur.Convertir(liste.SelectedItems);

        }

        private void AProposDe(object sender, EventArgs e)
        {
            (new APropos()).ShowDialog();
        }

        private void OuvrirOptions(object sender, EventArgs e)
        {
            moteur.ModifierOptions();
        }

        private void AfficherLesErreurs(object sender, EventArgs e)
        {
            moteur.AfficherLesErreurs();
        }

        private void Interrompre(object sender, EventArgs e)
        {
            moteur.InterrompreConversion();
        }
    }
}
