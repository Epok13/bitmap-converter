namespace Bitmap_Converter
{
    partial class FenêtreOptions
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
            this.ok = new System.Windows.Forms.Button();
            this.annuler = new System.Windows.Forms.Button();
            this.parcourir = new System.Windows.Forms.Button();
            this.chemin = new System.Windows.Forms.TextBox();
            this.inclureSousRepertoires = new System.Windows.Forms.CheckBox();
            this.supprimerSources = new System.Windows.Forms.CheckBox();
            this.formatDEntree = new System.Windows.Forms.ComboBox();
            this.formatSortie = new System.Windows.Forms.ComboBox();
            this.texteFormatIn = new System.Windows.Forms.Label();
            this.texteFormatOut = new System.Windows.Forms.Label();
            this.textePath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(12, 239);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(150, 20);
            this.ok.TabIndex = 6;
            this.ok.Text = "Ok";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // annuler
            // 
            this.annuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.annuler.Location = new System.Drawing.Point(338, 239);
            this.annuler.Name = "annuler";
            this.annuler.Size = new System.Drawing.Size(150, 20);
            this.annuler.TabIndex = 7;
            this.annuler.Text = "Annuler";
            this.annuler.UseVisualStyleBackColor = true;
            // 
            // parcourir
            // 
            this.parcourir.Location = new System.Drawing.Point(338, 51);
            this.parcourir.Name = "parcourir";
            this.parcourir.Size = new System.Drawing.Size(150, 20);
            this.parcourir.TabIndex = 1;
            this.parcourir.Text = "Parcourir";
            this.parcourir.UseVisualStyleBackColor = true;
            this.parcourir.Click += new System.EventHandler(this.Parcourir);
            // 
            // dossierCourant
            // 
            this.chemin.Location = new System.Drawing.Point(12, 25);
            this.chemin.Name = "chemin";
            this.chemin.Size = new System.Drawing.Size(476, 20);
            this.chemin.TabIndex = 0;
            // 
            // inclureSousRepertoires
            // 
            this.inclureSousRepertoires.AutoSize = true;
            this.inclureSousRepertoires.Location = new System.Drawing.Point(12, 86);
            this.inclureSousRepertoires.Name = "inclureSousRepertoires";
            this.inclureSousRepertoires.Size = new System.Drawing.Size(209, 17);
            this.inclureSousRepertoires.TabIndex = 2;
            this.inclureSousRepertoires.Text = "Inclure les sous-répertoires dans la liste";
            this.inclureSousRepertoires.UseVisualStyleBackColor = true;
            // 
            // supprimerSources
            // 
            this.supprimerSources.AutoSize = true;
            this.supprimerSources.Location = new System.Drawing.Point(12, 109);
            this.supprimerSources.Name = "supprimerSources";
            this.supprimerSources.Size = new System.Drawing.Size(272, 17);
            this.supprimerSources.TabIndex = 3;
            this.supprimerSources.Text = "Supprimer le fichier source une fois l\'image convertie";
            this.supprimerSources.UseVisualStyleBackColor = true;
            // 
            // formatDEntree
            // 
            this.formatDEntree.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formatDEntree.FormattingEnabled = true;
            this.formatDEntree.Location = new System.Drawing.Point(285, 150);
            this.formatDEntree.Name = "formatDEntree";
            this.formatDEntree.Size = new System.Drawing.Size(60, 21);
            this.formatDEntree.Sorted = true;
            this.formatDEntree.TabIndex = 4;
            this.formatDEntree.SelectedIndexChanged += new System.EventHandler(this.formatDEntree_SelectedIndexChanged);
            // 
            // formatSortie
            // 
            this.formatSortie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formatSortie.FormattingEnabled = true;
            this.formatSortie.Location = new System.Drawing.Point(285, 182);
            this.formatSortie.Name = "formatSortie";
            this.formatSortie.Size = new System.Drawing.Size(60, 21);
            this.formatSortie.Sorted = true;
            this.formatSortie.TabIndex = 5;
            // 
            // texteFormatIn
            // 
            this.texteFormatIn.AutoSize = true;
            this.texteFormatIn.Location = new System.Drawing.Point(12, 153);
            this.texteFormatIn.Name = "texteFormatIn";
            this.texteFormatIn.Size = new System.Drawing.Size(242, 13);
            this.texteFormatIn.TabIndex = 8;
            this.texteFormatIn.Text = "Sélectionnez le format que vous voulez convertir :";
            // 
            // texteFormatOut
            // 
            this.texteFormatOut.AutoSize = true;
            this.texteFormatOut.Location = new System.Drawing.Point(12, 185);
            this.texteFormatOut.Name = "texteFormatOut";
            this.texteFormatOut.Size = new System.Drawing.Size(267, 13);
            this.texteFormatOut.TabIndex = 9;
            this.texteFormatOut.Text = "Sélectionnez le format dans lequel converir les images :";
            // 
            // textePath
            // 
            this.textePath.AutoSize = true;
            this.textePath.Location = new System.Drawing.Point(85, 9);
            this.textePath.Name = "textePath";
            this.textePath.Size = new System.Drawing.Size(330, 13);
            this.textePath.TabIndex = 10;
            this.textePath.Text = "Chemin du dossier dans lequel vous souhaitez convertir des images :";
            // 
            // FenêtreOptions
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.annuler;
            this.ClientSize = new System.Drawing.Size(500, 269);
            this.Controls.Add(this.textePath);
            this.Controls.Add(this.texteFormatOut);
            this.Controls.Add(this.texteFormatIn);
            this.Controls.Add(this.formatSortie);
            this.Controls.Add(this.formatDEntree);
            this.Controls.Add(this.supprimerSources);
            this.Controls.Add(this.inclureSousRepertoires);
            this.Controls.Add(this.chemin);
            this.Controls.Add(this.parcourir);
            this.Controls.Add(this.annuler);
            this.Controls.Add(this.ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FenêtreOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modifier une option";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button annuler;
        private System.Windows.Forms.Button parcourir;
        private System.Windows.Forms.TextBox chemin;
        private System.Windows.Forms.CheckBox inclureSousRepertoires;
        private System.Windows.Forms.CheckBox supprimerSources;
        private System.Windows.Forms.ComboBox formatDEntree;
        private System.Windows.Forms.ComboBox formatSortie;
        private System.Windows.Forms.Label texteFormatIn;
        private System.Windows.Forms.Label texteFormatOut;
        private System.Windows.Forms.Label textePath;
    }
}