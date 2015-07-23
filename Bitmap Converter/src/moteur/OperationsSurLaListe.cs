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
using System.IO;

namespace Bitmap_Converter
{
    class OperationsSurLaListe
    {
        private Paramètres paramètres;
        private ListBox.ObjectCollection listeFichiers;  // Changer le type de stockage

        public OperationsSurLaListe(Paramètres p)
        {
            paramètres = p;
        }

        /// <summary>
        /// Retourne la liste des fichiers contenus dans
        /// le répèrtoire courant selont les paramètres.
        /// </summary>
        /// <returns></returns>
        public ListBox.ObjectCollection GetListe()
        {
            listeFichiers = (new ListBox()).Items;
            CréerListe(paramètres.dossierCourant);
            return listeFichiers;
        }

        /// <summary>
        /// Créer la liste des fichiers en fonction des paramètres.
        /// </summary>
        /// <param name="dossierCourant"></param>
        private void CréerListe(string chemin)
        {
            DirectoryInfo répertoire = new DirectoryInfo(chemin);
            FileInfo[] fichiers = null;

            // Penser à tester la longeur de l'extention à l'aide de :
            // if(Path.GetExtension(fileName).ToString().Length ==3) 

            if (paramètres.formatDEntrée == Format.Bmp) fichiers = répertoire.GetFiles("*.bmp");
            else if (paramètres.formatDEntrée == Format.Gif) fichiers = répertoire.GetFiles("*.gif");
            else if (paramètres.formatDEntrée == Format.Jpeg)
            {
                FileInfo[][] fichiersJpg = new FileInfo[3][];
                fichiersJpg[0] = répertoire.GetFiles("*.jpg");
                fichiersJpg[1] = répertoire.GetFiles("*.jpeg");
                fichiersJpg[2] = répertoire.GetFiles("*.jpe");

                fichiers = new FileInfo[fichiersJpg[0].Length + fichiersJpg[1].Length + fichiersJpg[2].Length];

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < fichiersJpg[i].Length; j++)
                    {
                        if (i == 0) fichiers[j] = fichiersJpg[i][j];
                        else if (i == 1) fichiers[j + fichiersJpg[0].Length] = fichiersJpg[i][j];
                        else fichiers[j + fichiersJpg[0].Length + fichiersJpg[1].Length] = fichiersJpg[i][j];
                    }
                }
            }
            else if (paramètres.formatDEntrée == Format.Png) fichiers = répertoire.GetFiles("*.png");
            else if (paramètres.formatDEntrée == Format.Tiff) fichiers = répertoire.GetFiles("*.tif");
            else if (paramètres.formatDEntrée == Format.Wmf) fichiers = répertoire.GetFiles("*.wmf");

            for (int i = 0; i < fichiers.Length; i++)
            {
                listeFichiers.Add(fichiers[i].FullName);
            }

            if (paramètres.inclureLesSousRépertoires == true)
            {
                DirectoryInfo[] sousRépertoires = répertoire.GetDirectories();

                foreach (DirectoryInfo sousRépertoireCourant in sousRépertoires)
                {
                    CréerListe(sousRépertoireCourant.FullName);
                }
            }
        }
	}
}
