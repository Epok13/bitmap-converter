namespace Bitmap_Converter
{
    partial class APropos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APropos));
            this.texte = new System.Windows.Forms.Label();
            this.boutonFermer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // texte
            // 
            this.texte.Location = new System.Drawing.Point(12, 9);
            this.texte.Name = "texte";
            this.texte.Size = new System.Drawing.Size(321, 223);
            this.texte.TabIndex = 0;
            this.texte.Text = resources.GetString("texte.Text");
            this.texte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // boutonFermer
            // 
            this.boutonFermer.Location = new System.Drawing.Point(83, 254);
            this.boutonFermer.Name = "boutonFermer";
            this.boutonFermer.Size = new System.Drawing.Size(175, 23);
            this.boutonFermer.TabIndex = 1;
            this.boutonFermer.Text = "Fermer";
            this.boutonFermer.UseVisualStyleBackColor = true;
            this.boutonFermer.Click += new System.EventHandler(this.boutonFermer_Click);
            // 
            // APropos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 289);
            this.Controls.Add(this.boutonFermer);
            this.Controls.Add(this.texte);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "APropos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "A propos de...";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label texte;
        private System.Windows.Forms.Button boutonFermer;
    }
}