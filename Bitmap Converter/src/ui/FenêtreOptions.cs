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
using System.IO;

namespace Bitmap_Converter
{
    public partial class FenêtreOptions : Form
    {
        private Paramètres paramètres;

        /// <summary>
        /// Constructeur par défaut : appellé en début de programme,
        /// il initialise un nouvel objet Paramètres.
        /// </summary>
        public FenêtreOptions()
        {
            InitializeComponent();

            this.Text = "Entrez les paramètre de la conversion";
            annuler.Text = "Quitter";

            paramètres = new Paramètres();

            Initialiser();
        }

        /// <summary>
        /// Ce contructeur est appellé en cours de programme, afin
        /// de modifier une option.
        /// </summary>
        /// <param name="p">Les paramètres en cours.</param>
        public FenêtreOptions(Paramètres p)
        {
            InitializeComponent();

            paramètres = p;

            Initialiser();
        }

        private void Initialiser()
        {
            formatDEntree.Items.Add(Format.Bmp);
            formatDEntree.Items.Add(Format.Gif);
            formatDEntree.Items.Add(Format.Jpeg);
            formatDEntree.Items.Add(Format.Png);
            formatDEntree.Items.Add(Format.Tiff);
            formatDEntree.Items.Add(Format.Wmf);

            formatSortie.Items.Add(Format.Bmp);
            formatSortie.Items.Add(Format.Gif);
            formatSortie.Items.Add(Format.Jpeg);
            formatSortie.Items.Add(Format.Png);
            formatSortie.Items.Add(Format.Tiff);
            formatSortie.Items.Add(Format.Wmf);

            // Ne SURTOUT PAS modifier l'ordre des 2 commandes ci-dessous !
            formatSortie.SelectedItem = paramètres.formatDeSortie;
            formatDEntree.SelectedItem = paramètres.formatDEntrée;
            
            inclureSousRepertoires.Checked = paramètres.inclureLesSousRépertoires;
            supprimerSources.Checked = paramètres.supprimerLesSources;
            chemin.Text = paramètres.dossierCourant;
        } // Fin de la méthode initialiser

        private void Parcourir(object sender, EventArgs e)
        {
            FolderBrowserDialog boiteParcourir = new FolderBrowserDialog();
            boiteParcourir.SelectedPath = chemin.Text;
            boiteParcourir.Description = "Sélectionnez le dossier contenant les fichiers que vous désirez convertir :";
            DialogResult résultat = boiteParcourir.ShowDialog();
            if (résultat == DialogResult.OK)
            {
                chemin.Text = boiteParcourir.SelectedPath;
            }
            boiteParcourir.Dispose();
        } // Fin de la méthode parcourir

        private void ok_Click(object sender, EventArgs e)
        {
            // Tester la validité du dossierCourant avant d'accepter le clic sur ok
            // + tester le format (retour aux bonnes vielles méthodes ?). sinon :
            //if (formatDEntree.SelectedItem == formatSortie.SelectedItem) gnagnagna...

            if (Directory.Exists(chemin.Text)) paramètres.dossierCourant = chemin.Text;
            else
            {
                MessageBox.Show("Le chemin que vous avez entré n'est pas correct. Vérifiez que le répertoire existe.");
                return;
            }
            paramètres.formatDEntrée = (Format) formatDEntree.SelectedItem;
            paramètres.formatDeSortie = (Format) formatSortie.SelectedItem;
            paramètres.inclureLesSousRépertoires = inclureSousRepertoires.Checked;
            paramètres.supprimerLesSources = supprimerSources.Checked;
        }

        private void chemin_TextChanged(object sender, EventArgs e)
        {
            paramètres.dossierCourant = chemin.Text;
        }

        public Paramètres Paramètres
        {
            get
            {
                return paramètres;
            }
        }

        private void formatDEntree_SelectedIndexChanged(object sender, EventArgs e)
        {
            Format sortie = (Format)formatSortie.SelectedItem;
            formatSortie.Items.Clear();

            if ((Format) formatDEntree.SelectedItem != Format.Bmp) formatSortie.Items.Add(Format.Bmp);
            if ((Format)formatDEntree.SelectedItem != Format.Gif) formatSortie.Items.Add(Format.Gif);
            if ((Format)formatDEntree.SelectedItem != Format.Jpeg) formatSortie.Items.Add(Format.Jpeg);
            if ((Format)formatDEntree.SelectedItem != Format.Png) formatSortie.Items.Add(Format.Png);
            if ((Format)formatDEntree.SelectedItem != Format.Tiff) formatSortie.Items.Add(Format.Tiff);
            if ((Format)formatDEntree.SelectedItem != Format.Wmf) formatSortie.Items.Add(Format.Wmf);

            if (sortie != (Format) formatDEntree.SelectedItem) formatSortie.SelectedItem = sortie;
            else if ((Format) formatDEntree.SelectedItem != Format.Jpeg) formatSortie.SelectedItem = Format.Jpeg;
            else formatSortie.SelectedItem = Format.Bmp;
        }
    }
}