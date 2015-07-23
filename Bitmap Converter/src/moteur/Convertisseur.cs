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
using System.Drawing;
using System.Collections;

namespace Bitmap_Converter
{
    public sealed class Convertisseur
    {
        private Moteur moteur;

        private Paramètres paramètres;

        private ArrayList
            listeErronés,
            listeNonSupprimés,
            listeDesObjetsATraiter;

        private delegate void InvoquerLesEspritsDeLaFenêtrePrincipale();
        private delegate void InvoquerLesEspritsAvecValeur(int i);

        public Convertisseur(Moteur m, ArrayList l)
        {
            listeErronés = new ArrayList();
            listeNonSupprimés = new ArrayList();
            listeDesObjetsATraiter = l;
            moteur = m;
            paramètres = m.Paramètres;
        }

        /// <summary>
        /// Convertir les fichiers selon les paramètres.
        /// </summary>
        /// <param name="listeDesObjetsATraiter">Fichiers à convertir</param>
        public void Convertir()
        {
            foreach (string s in listeDesObjetsATraiter)
            {
                try
                {
                    string nom = "";

                    Bitmap image = new Bitmap(s);

					if (paramètres.formatDeSortie == Format.Bmp)
					{
						nom = s.Replace(Path.GetExtension(s), ".bmp");
						if (!File.Exists(nom)) image.Save(nom, System.Drawing.Imaging.ImageFormat.Bmp);
						else listeErronés.Add(s);
					}
					else if (paramètres.formatDeSortie == Format.Gif)
					{
						nom = s.Replace(Path.GetExtension(s), ".gif");
						if (!File.Exists(nom)) image.Save(nom, System.Drawing.Imaging.ImageFormat.Gif);
						else listeErronés.Add(s);
					}
					else if (paramètres.formatDeSortie == Format.Jpeg)
					{
						nom = s.Replace(Path.GetExtension(s), ".jpg");
						if (!File.Exists(nom)) image.Save(nom, System.Drawing.Imaging.ImageFormat.Jpeg);
						else listeErronés.Add(s);
					}
					else if (paramètres.formatDeSortie == Format.Png)
					{
						nom = s.Replace(Path.GetExtension(s), ".png");
						if (!File.Exists(nom)) image.Save(nom, System.Drawing.Imaging.ImageFormat.Png);
						else listeErronés.Add(s);
					}
					else if (paramètres.formatDeSortie == Format.Tiff)
					{
						nom = s.Replace(Path.GetExtension(s), ".tif");
						if (!File.Exists(nom)) image.Save(nom, System.Drawing.Imaging.ImageFormat.Tiff);
						else listeErronés.Add(s);
					}
					else if (paramètres.formatDeSortie == Format.Wmf)
					{
						nom = s.Replace(Path.GetExtension(s), ".wmf");
						if (!File.Exists(nom)) image.Save(nom, System.Drawing.Imaging.ImageFormat.Wmf);
						else listeErronés.Add(s);
					}

                    image.Dispose();
                }
                catch
                {
                    listeErronés.Add(s);
                }
                moteur.Fenêtre.Invoke(new InvoquerLesEspritsDeLaFenêtrePrincipale(moteur.Fenêtre.AvancerDUnCran));
            }

            if (paramètres.supprimerLesSources)
            {
                moteur.Fenêtre.Invoke(new InvoquerLesEspritsAvecValeur(moteur.Fenêtre.PassageEnModeSuppression), new object[] { (listeDesObjetsATraiter.Count - listeErronés.Count) });

                foreach (string s in listeDesObjetsATraiter)
                {
                    try
                    {
                        if (!listeErronés.Contains(s)) File.Delete(s);
                    }
                    catch
                    {
                        listeNonSupprimés.Add(s);
                    }
                    moteur.Fenêtre.Invoke(new InvoquerLesEspritsDeLaFenêtrePrincipale(moteur.Fenêtre.AvancerDUnCran));
                }
            }


            moteur.Erreurs.erronés = listeErronés;
            moteur.Erreurs.nonSupprimés = listeNonSupprimés;
            if ((listeErronés.Count != 0) || (listeNonSupprimés.Count != 0)) moteur.Erreurs.erreur = true;
            else moteur.Erreurs.erreur = false;

            moteur.Fenêtre.Invoke(new InvoquerLesEspritsDeLaFenêtrePrincipale(moteur.Fenêtre.ConversionTerminée));

            moteur.Fenêtre.Invoke(new InvoquerLesEspritsDeLaFenêtrePrincipale(moteur.Fenêtre.Débloquer));
        }

    }
}
