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

        bool initialisé = false;

        /// <summary>
        /// Ce contructeur est appellé en cours de programme, afin
        /// de modifier une option.
        /// </summary>
        /// <param name="p">Les paramètres en cours.</param>
        public FenêtreOptions(bool initial = false)
        {
            InitializeComponent();

            if (initial == true)
            {
                // Comportement spécifique à la première overture: quitter au lieu d'annuler
                this.Text = "Entrez les paramètre de la conversion";
                this.annuler.Text = "Quitter";
            }

            Initialiser();
        }

        /// <summary>
        /// Remplis dynamiquement les listes de format et initialise les valeurs des items graphiques
        /// </summary>
        private void Initialiser()
        {
            foreach (Format format in Enum.GetValues(typeof(Format)))
            {
                this.formatDEntree.Items.Add(format);
            }

            // Ceci remplit automatiquement la liste des formats cibles
            this.formatDEntree.SelectedItem = FormatFromString(Properties.Settings.Default.SourceType);


            this.inclureSousRepertoires.Checked = Properties.Settings.Default.RecursiveListing;
            this.supprimerSources.Checked       = Properties.Settings.Default.DeleteSources;

            if (Directory.Exists(Properties.Settings.Default.FolderPath))
                this.chemin.Text = Properties.Settings.Default.FolderPath;
            else
                this.chemin.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            this.initialisé = true;

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
            if (Directory.Exists(chemin.Text))
            {
                Properties.Settings.Default.FolderPath = chemin.Text;

                Properties.Settings.Default.SourceType = ((Format)formatDEntree.SelectedItem).ToString();
                Properties.Settings.Default.TargetType = ((Format)formatSortie.SelectedItem).ToString();
                Properties.Settings.Default.RecursiveListing = inclureSousRepertoires.Checked;
                Properties.Settings.Default.DeleteSources = supprimerSources.Checked;

                Properties.Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("Le chemin que vous avez entré n'est pas correct. Vérifiez que le répertoire existe.");
            }
        }

        private void formatDEntree_SelectedIndexChanged(object sender, EventArgs e)
        {
            Format formatSortiePrecedent;
            if (this.initialisé == true)
            {
                formatSortiePrecedent = (Format)formatSortie.SelectedItem;
            }
            else
            {
                formatSortiePrecedent = FormatFromString(Properties.Settings.Default.TargetType);
            }

            formatSortie.Items.Clear();

            foreach (Format format in Enum.GetValues(typeof(Format)))
            {
                if ((Format)formatDEntree.SelectedItem != format)
                    formatSortie.Items.Add(format);
            }
            
            if (formatSortiePrecedent != (Format)formatDEntree.SelectedItem)
                formatSortie.SelectedItem = formatSortiePrecedent;
            else if ((Format)formatDEntree.SelectedItem != Format.Jpeg)
                formatSortie.SelectedItem = Format.Jpeg;
            else
                formatSortie.SelectedItem = Format.Png;
        }

        private Format FormatFromString(string formatString)
        {
            foreach (Format format in Enum.GetValues(typeof(Format)))
            {
                if (format.ToString() == formatString)
                    return format;
            }

            return Format.Bmp;
        }

    }
}