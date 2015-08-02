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
    public delegate void DémarrageProcessusEventHandler();

    public delegate void DémarrageConversionEventHandler(int nombre);
    public delegate void FichierConvertiEventHandler();
    public delegate void ConversionTerminéeEventHandler();

    public delegate void DémarrageSuppressionEventHandler(int nombre);
    public delegate void FichierSuppriméEventHandler();
    public delegate void SuppressionTerminéeEventHandler();

    public delegate void ProcessusTerminéEventHandler();
    
    sealed class Convertisseur
    {
        public event DémarrageProcessusEventHandler   DémarrageProcessus;
        public event DémarrageConversionEventHandler  DémarrageConversion;
        public event FichierConvertiEventHandler      FichierConverti;
        public event ConversionTerminéeEventHandler   ConversionTerminée;
        public event DémarrageSuppressionEventHandler DémarrageSuppression;
        public event FichierSuppriméEventHandler      FichierSupprimé;
        public event SuppressionTerminéeEventHandler  SuppressionTerminée;
        public event ProcessusTerminéEventHandler     ProcessusTerminé;

        private Erreurs erreurs;

        private ArrayList
            listeDesObjetsATraiter,
            listeErronés,
            listeNonSupprimés;

        private bool continuer;

        public Convertisseur(Erreurs erreurs, ArrayList liste)
        {
            this.listeDesObjetsATraiter = liste;
            this.erreurs = erreurs;

            this.listeErronés = new ArrayList();
            this.listeNonSupprimés = new ArrayList();
            this.continuer = true;
        }

        /// <summary>
        /// Convertir les fichiers selon les paramètres.
        /// Il s'agit de la boucle principale du thread.
        /// </summary>
        public void Convertir()
        {
            // Event
            if (DémarrageProcessus != null)
                DémarrageProcessus();

            // Event
            if (DémarrageConversion != null)
                DémarrageConversion(this.listeDesObjetsATraiter.Count);

            foreach (string s in this.listeDesObjetsATraiter)
            {
                if (continuer == true)
                {
                    try
                    {
                        string nom = "";

                        Bitmap image = new Bitmap(s);

                        if (Properties.Settings.Default.TargetType == Format.Bmp.ToString())
                        {
                            nom = s.Replace(Path.GetExtension(s), ".bmp");
                            if (!File.Exists(nom))
                                image.Save(nom, System.Drawing.Imaging.ImageFormat.Bmp);
                            else
                                this.listeErronés.Add(s);
                        }
                        else if (Properties.Settings.Default.TargetType == Format.Gif.ToString())
                        {
                            nom = s.Replace(Path.GetExtension(s), ".gif");
                            if (!File.Exists(nom))
                                image.Save(nom, System.Drawing.Imaging.ImageFormat.Gif);
                            else
                                this.listeErronés.Add(s);
                        }
                        else if (Properties.Settings.Default.TargetType == Format.Jpeg.ToString())
                        {
                            nom = s.Replace(Path.GetExtension(s), ".jpg");
                            if (!File.Exists(nom))
                                image.Save(nom, System.Drawing.Imaging.ImageFormat.Jpeg);
                            else
                                this.listeErronés.Add(s);
                        }
                        else if (Properties.Settings.Default.TargetType == Format.Png.ToString())
                        {
                            nom = s.Replace(Path.GetExtension(s), ".png");
                            if (!File.Exists(nom))
                                image.Save(nom, System.Drawing.Imaging.ImageFormat.Png);
                            else
                                this.listeErronés.Add(s);
                        }
                        else if (Properties.Settings.Default.TargetType == Format.Tiff.ToString())
                        {
                            nom = s.Replace(Path.GetExtension(s), ".tif");
                            if (!File.Exists(nom))
                                image.Save(nom, System.Drawing.Imaging.ImageFormat.Tiff);
                            else
                                this.listeErronés.Add(s);
                        }
                        else if (Properties.Settings.Default.TargetType == Format.Wmf.ToString())
                        {
                            nom = s.Replace(Path.GetExtension(s), ".wmf");
                            if (!File.Exists(nom))
                                image.Save(nom, System.Drawing.Imaging.ImageFormat.Wmf);
                            else
                                this.listeErronés.Add(s);
                        }
                        else // Si propritété mal initialisée
                            this.listeErronés.Add(s);

                        image.Dispose();
                    }
                    catch
                    {
                        this.listeErronés.Add(s);
                    }

                    // Event
                    if (FichierConverti != null)
                        FichierConverti();
                }
                else
                    break;
            }

            this.erreurs.erronés = this.listeErronés;

            // Event
            if (ConversionTerminée != null)
                ConversionTerminée();

            if ((Properties.Settings.Default.DeleteSources == true) &&  (continuer == true))
            {
                // Event
                if (DémarrageSuppression != null)
                    DémarrageSuppression(this.listeDesObjetsATraiter.Count - this.listeErronés.Count);

                foreach (string s in this.listeDesObjetsATraiter)
                {
                    if (continuer == true)
                    {
                        try
                        {
                            if (!this.listeErronés.Contains(s))
                                File.Delete(s);
                        }
                        catch
                        {
                            this.listeNonSupprimés.Add(s);
                        }

                        // Event
                        if (FichierSupprimé != null)
                            FichierSupprimé();
                    }
                    else
                        break;
                }

                this.erreurs.nonSupprimés = this.listeNonSupprimés;

                // Event
                if (SuppressionTerminée != null)
                    SuppressionTerminée();
            }

            if ((this.listeErronés.Count != 0) || (this.listeNonSupprimés.Count != 0))
                this.erreurs.erreur = true;
            else
                this.erreurs.erreur = false;

            // Event
            if (ProcessusTerminé != null)
                ProcessusTerminé();
        }

        /// <summary>
        /// Interrompt le processus proprement
        /// </summary>
        public void Interrompre()
        {
            this.continuer = false;
        }

    }
}
