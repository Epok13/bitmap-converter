namespace Bitmap_Converter
{
    partial class FenêtrePrincipale
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
            this.sélectionnerTout = new System.Windows.Forms.Button();
            this.convertir = new System.Windows.Forms.Button();
            this.actualiser = new System.Windows.Forms.Button();
            this.liste = new System.Windows.Forms.ListBox();
            this.barreDeProgression = new System.Windows.Forms.ProgressBar();
            this.barreDeMenus = new System.Windows.Forms.MenuStrip();
            this.menuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuActions = new System.Windows.Forms.ToolStripMenuItem();
            this.itemActualiser = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSélectionner = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDéselectionner = new System.Windows.Forms.ToolStripMenuItem();
            this.itemConvertir = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAfficherLesErreurs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAide = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAPropos = new System.Windows.Forms.ToolStripMenuItem();
            this.barreDEtat = new System.Windows.Forms.StatusStrip();
            this.texteDEtat = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.interrompre = new System.Windows.Forms.Button();
            this.barreDeMenus.SuspendLayout();
            this.barreDEtat.SuspendLayout();
            this.SuspendLayout();
            // 
            // sélectionnerTout
            // 
            this.sélectionnerTout.Location = new System.Drawing.Point(12, 581);
            this.sélectionnerTout.Name = "sélectionnerTout";
            this.sélectionnerTout.Size = new System.Drawing.Size(150, 20);
            this.sélectionnerTout.TabIndex = 0;
            this.sélectionnerTout.Text = "Sélectionner tout";
            this.sélectionnerTout.UseVisualStyleBackColor = true;
            this.sélectionnerTout.Click += new System.EventHandler(this.SélectionnerTout);
            // 
            // convertir
            // 
            this.convertir.Location = new System.Drawing.Point(438, 581);
            this.convertir.Name = "convertir";
            this.convertir.Size = new System.Drawing.Size(150, 20);
            this.convertir.TabIndex = 2;
            this.convertir.Text = "Convertir la sélection";
            this.convertir.UseVisualStyleBackColor = true;
            this.convertir.Click += new System.EventHandler(this.Convertir);
            // 
            // actualiser
            // 
            this.actualiser.Location = new System.Drawing.Point(225, 581);
            this.actualiser.Name = "actualiser";
            this.actualiser.Size = new System.Drawing.Size(150, 20);
            this.actualiser.TabIndex = 3;
            this.actualiser.Text = "Actualiser la liste";
            this.actualiser.UseVisualStyleBackColor = true;
            this.actualiser.Click += new System.EventHandler(this.Actualiser);
            // 
            // liste
            // 
            this.liste.FormattingEnabled = true;
            this.liste.Location = new System.Drawing.Point(12, 67);
            this.liste.Name = "liste";
            this.liste.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.liste.Size = new System.Drawing.Size(576, 498);
            this.liste.TabIndex = 7;
            // 
            // barreDeProgression
            // 
            this.barreDeProgression.Location = new System.Drawing.Point(12, 622);
            this.barreDeProgression.Name = "barreDeProgression";
            this.barreDeProgression.Size = new System.Drawing.Size(576, 30);
            this.barreDeProgression.TabIndex = 8;
            // 
            // barreDeMenus
            // 
            this.barreDeMenus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOptions,
            this.menuActions,
            this.menuAide});
            this.barreDeMenus.Location = new System.Drawing.Point(0, 0);
            this.barreDeMenus.Name = "barreDeMenus";
            this.barreDeMenus.Size = new System.Drawing.Size(600, 24);
            this.barreDeMenus.TabIndex = 10;
            this.barreDeMenus.Text = "barreDeMenus";
            // 
            // menuOptions
            // 
            this.menuOptions.Name = "menuOptions";
            this.menuOptions.Size = new System.Drawing.Size(56, 20);
            this.menuOptions.Text = "&Options";
            this.menuOptions.Click += new System.EventHandler(this.OuvrirOptions);
            // 
            // menuActions
            // 
            this.menuActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemActualiser,
            this.itemSélectionner,
            this.itemDéselectionner,
            this.itemConvertir,
            this.itemAfficherLesErreurs});
            this.menuActions.Name = "menuActions";
            this.menuActions.Size = new System.Drawing.Size(54, 20);
            this.menuActions.Text = "&Actions";
            // 
            // itemActualiser
            // 
            this.itemActualiser.Name = "itemActualiser";
            this.itemActualiser.Size = new System.Drawing.Size(382, 22);
            this.itemActualiser.Text = "Actualiser la liste";
            this.itemActualiser.Click += new System.EventHandler(this.Actualiser);
            // 
            // itemSélectionner
            // 
            this.itemSélectionner.Name = "itemSélectionner";
            this.itemSélectionner.Size = new System.Drawing.Size(382, 22);
            this.itemSélectionner.Text = "Sélectionner tous les élements";
            this.itemSélectionner.Click += new System.EventHandler(this.SélectionnerTout);
            // 
            // itemDéselectionner
            // 
            this.itemDéselectionner.Name = "itemDéselectionner";
            this.itemDéselectionner.Size = new System.Drawing.Size(382, 22);
            this.itemDéselectionner.Text = "Déselectionner tous les éléments";
            this.itemDéselectionner.Click += new System.EventHandler(this.DésélectionnerTout);
            // 
            // itemConvertir
            // 
            this.itemConvertir.Name = "itemConvertir";
            this.itemConvertir.Size = new System.Drawing.Size(382, 22);
            this.itemConvertir.Text = "Démarrer la conversion";
            this.itemConvertir.Click += new System.EventHandler(this.Convertir);
            // 
            // itemAfficherLesErreurs
            // 
            this.itemAfficherLesErreurs.Name = "itemAfficherLesErreurs";
            this.itemAfficherLesErreurs.Size = new System.Drawing.Size(382, 22);
            this.itemAfficherLesErreurs.Text = "Afficher les erreurs rencontrées lors de la dernière conversion";
            this.itemAfficherLesErreurs.Click += new System.EventHandler(this.AfficherLesErreurs);
            // 
            // menuAide
            // 
            this.menuAide.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemAPropos});
            this.menuAide.Name = "menuAide";
            this.menuAide.Size = new System.Drawing.Size(24, 20);
            this.menuAide.Text = "&?";
            // 
            // itemAPropos
            // 
            this.itemAPropos.Name = "itemAPropos";
            this.itemAPropos.Size = new System.Drawing.Size(155, 22);
            this.itemAPropos.Text = "A propos de...";
            this.itemAPropos.Click += new System.EventHandler(this.AProposDe);
            // 
            // barreDEtat
            // 
            this.barreDEtat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.texteDEtat});
            this.barreDEtat.Location = new System.Drawing.Point(0, 665);
            this.barreDEtat.Name = "barreDEtat";
            this.barreDEtat.Size = new System.Drawing.Size(600, 22);
            this.barreDEtat.TabIndex = 11;
            this.barreDEtat.Text = "statusStrip1";
            // 
            // texteDEtat
            // 
            this.texteDEtat.Name = "texteDEtat";
            this.texteDEtat.Size = new System.Drawing.Size(161, 17);
            this.texteDEtat.Text = "En attente pour la conversion...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 26);
            this.label1.TabIndex = 12;
            this.label1.Text = "Voici la liste des fichiers présents dans le dossier que vous avez sélectionné.\r\n" +
                "Sélectionnez ceux que vous désirez convertir, puis cliquez sur \"Convertir\".";
            // 
            // interrompre
            // 
            this.interrompre.Location = new System.Drawing.Point(225, 333);
            this.interrompre.Name = "interrompre";
            this.interrompre.Size = new System.Drawing.Size(150, 20);
            this.interrompre.TabIndex = 13;
            this.interrompre.Text = "Interrompre la conversion";
            this.interrompre.UseVisualStyleBackColor = true;
            this.interrompre.Visible = false;
            this.interrompre.Click += new System.EventHandler(this.Interrompre);
            // 
            // FenêtrePrincipale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 687);
            this.Controls.Add(this.interrompre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.barreDEtat);
            this.Controls.Add(this.barreDeProgression);
            this.Controls.Add(this.liste);
            this.Controls.Add(this.actualiser);
            this.Controls.Add(this.convertir);
            this.Controls.Add(this.sélectionnerTout);
            this.Controls.Add(this.barreDeMenus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.barreDeMenus;
            this.MaximizeBox = false;
            this.Name = "FenêtrePrincipale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bitmap Converter";
            this.barreDeMenus.ResumeLayout(false);
            this.barreDeMenus.PerformLayout();
            this.barreDEtat.ResumeLayout(false);
            this.barreDEtat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sélectionnerTout;
        private System.Windows.Forms.Button convertir;
        private System.Windows.Forms.Button actualiser;
        private System.Windows.Forms.ListBox liste;
        private System.Windows.Forms.ProgressBar barreDeProgression;
        private System.Windows.Forms.MenuStrip barreDeMenus;
        private System.Windows.Forms.ToolStripMenuItem menuOptions;
        private System.Windows.Forms.ToolStripMenuItem menuActions;
        private System.Windows.Forms.ToolStripMenuItem menuAide;
        private System.Windows.Forms.ToolStripMenuItem itemActualiser;
        private System.Windows.Forms.ToolStripMenuItem itemSélectionner;
        private System.Windows.Forms.ToolStripMenuItem itemDéselectionner;
        private System.Windows.Forms.ToolStripMenuItem itemConvertir;
        private System.Windows.Forms.ToolStripMenuItem itemAfficherLesErreurs;
        private System.Windows.Forms.ToolStripMenuItem itemAPropos;
        private System.Windows.Forms.StatusStrip barreDEtat;
        private System.Windows.Forms.ToolStripStatusLabel texteDEtat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button interrompre;
    }
}
