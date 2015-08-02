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

using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace Bitmap_Converter
{
    static class GénérateurDeListes
    {
        private static SortedList<int, string> listeFichiers;
        
        /// <summary>
        /// Retourne la liste des fichiers contenus dans
        /// le répertoire courant en fonction des paramètres.
        /// </summary>
        /// <returns></returns>
        public static SortedList<int, string> GénérerListe()
        {
            listeFichiers = new SortedList<int, string>();
            ListerDossier(Properties.Settings.Default.FolderPath);
            return listeFichiers;
        }

        /// <summary>
        /// Créer la liste des fichiers dans un dossier 
        /// en fonction des paramètres.
        /// 
        /// Fonction récursive si l'option est activée.
        /// </summary>
        /// <param name="chemin"></param>
        private static void ListerDossier(string chemin)
        {
            DirectoryInfo répertoire = new DirectoryInfo(chemin);
            FileInfo[] fichiers = null;

            // Penser à tester la longeur de l'extention à l'aide de :
            // if(Path.GetExtension(fileName).ToString().Length ==3) 

            if (Properties.Settings.Default.SourceType == Format.Bmp.ToString())
                fichiers = répertoire.GetFiles("*.bmp");
            else if (Properties.Settings.Default.SourceType == Format.Gif.ToString())
                fichiers = répertoire.GetFiles("*.gif");
            else if (Properties.Settings.Default.SourceType == Format.Jpeg.ToString())
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
            else if (Properties.Settings.Default.SourceType == Format.Png.ToString())
                fichiers = répertoire.GetFiles("*.png");
            else if (Properties.Settings.Default.SourceType == Format.Tiff.ToString())
                fichiers = répertoire.GetFiles("*.tif");
            else if (Properties.Settings.Default.SourceType == Format.Wmf.ToString())
                fichiers = répertoire.GetFiles("*.wmf");

            for (int i = 0; i < fichiers.Length; i++)
            {
                listeFichiers.Add(listeFichiers.Count, fichiers[i].FullName);
            }

            if (Properties.Settings.Default.RecursiveListing == true)
            {
                DirectoryInfo[] sousRépertoires = répertoire.GetDirectories();

                foreach (DirectoryInfo sousRépertoireCourant in sousRépertoires)
                {
                    ListerDossier(sousRépertoireCourant.FullName);
                }
            }
        }
	}
}
