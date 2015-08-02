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

namespace Bitmap_Converter
{
    public partial class FenêtreErreurs : Form
    {
        public FenêtreErreurs(Erreurs erreurs)
        {
            InitializeComponent();

            this.erronés.Items.AddRange(erreurs.erronés.ToArray());

            if (erreurs.nonSupprimés.Count != 0)
            {
                this.nonSupprimés.Items.AddRange(erreurs.nonSupprimés.ToArray());
            }
            else
            {
                this.nonSupprimés.Visible = false;
                this.texteNonSupprimés.Visible = false;
                if (Properties.Settings.Default.DeleteSources == false)
                    this.labelNote.Visible = false;
            }

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(erronés, "Cette fenêtre contient les objets qui n'ont pu être convertis.\nCelà peut être du au fait que le fichier que vous essayez de\nconverir est endommagé, ou encore qu'il existe déjà un fichier\ndu nom que le programme tente d'attribuer au fichier converti.");
        }

        private void fermer_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}