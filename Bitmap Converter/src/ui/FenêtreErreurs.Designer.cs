namespace Bitmap_Converter
{
    partial class FenêtreErreurs
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.texteErreurs = new System.Windows.Forms.Label();
            this.texteNonSupprimés = new System.Windows.Forms.Label();
            this.fermer = new System.Windows.Forms.Button();
            this.erronés = new System.Windows.Forms.ListBox();
            this.nonSupprimés = new System.Windows.Forms.ListBox();
            this.labelNote = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // texteErreurs
            // 
            this.texteErreurs.AutoSize = true;
            this.texteErreurs.Location = new System.Drawing.Point(12, 9);
            this.texteErreurs.Name = "texteErreurs";
            this.texteErreurs.Size = new System.Drawing.Size(236, 13);
            this.texteErreurs.TabIndex = 2;
            this.texteErreurs.Text = "Les fichiers suivants n\'ont pas pu être convertis :";
            // 
            // texteNonSupprimés
            // 
            this.texteNonSupprimés.AutoSize = true;
            this.texteNonSupprimés.Location = new System.Drawing.Point(12, 240);
            this.texteNonSupprimés.Name = "texteNonSupprimés";
            this.texteNonSupprimés.Size = new System.Drawing.Size(240, 13);
            this.texteNonSupprimés.TabIndex = 3;
            this.texteNonSupprimés.Text = "Les fichiers suivants n\'ont pas pu être supprimés :";
            // 
            // fermer
            // 
            this.fermer.Location = new System.Drawing.Point(225, 492);
            this.fermer.Name = "fermer";
            this.fermer.Size = new System.Drawing.Size(150, 20);
            this.fermer.TabIndex = 4;
            this.fermer.Text = "Fermer";
            this.fermer.UseVisualStyleBackColor = true;
            this.fermer.Click += new System.EventHandler(this.fermer_Click);
            // 
            // erronés
            // 
            this.erronés.FormattingEnabled = true;
            this.erronés.Location = new System.Drawing.Point(12, 25);
            this.erronés.Name = "erronés";
            this.erronés.Size = new System.Drawing.Size(560, 212);
            this.erronés.TabIndex = 5;
            // 
            // nonSupprimés
            // 
            this.nonSupprimés.FormattingEnabled = true;
            this.nonSupprimés.Location = new System.Drawing.Point(12, 256);
            this.nonSupprimés.Name = "nonSupprimés";
            this.nonSupprimés.Size = new System.Drawing.Size(560, 225);
            this.nonSupprimés.TabIndex = 6;
            // 
            // labelNote
            // 
            this.labelNote.AutoSize = true;
            this.labelNote.Location = new System.Drawing.Point(300, 240);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(272, 13);
            this.labelNote.TabIndex = 7;
            this.labelNote.Text = "Note : les fichiers non convertis n\'ont pas été supprimés.";
            // 
            // FenêtreErreurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 524);
            this.Controls.Add(this.labelNote);
            this.Controls.Add(this.nonSupprimés);
            this.Controls.Add(this.erronés);
            this.Controls.Add(this.fermer);
            this.Controls.Add(this.texteNonSupprimés);
            this.Controls.Add(this.texteErreurs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FenêtreErreurs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Résultat de la conversion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label texteErreurs;
        private System.Windows.Forms.Label texteNonSupprimés;
        private System.Windows.Forms.Button fermer;
        private System.Windows.Forms.ListBox erronés;
        private System.Windows.Forms.ListBox nonSupprimés;
        private System.Windows.Forms.Label labelNote;
    }
}