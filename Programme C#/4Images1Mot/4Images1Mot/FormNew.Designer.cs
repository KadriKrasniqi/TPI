namespace _4Images1Mot
{
    partial class FormNew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Titre = new System.Windows.Forms.Label();
            this.tb_mot = new System.Windows.Forms.TextBox();
            this.cb_theme = new System.Windows.Forms.ComboBox();
            this.btn_parcourir = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lv_lienImage = new System.Windows.Forms.ListView();
            this.Répertoire = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_ajouter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Titre
            // 
            this.lbl_Titre.AutoSize = true;
            this.lbl_Titre.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Titre.Location = new System.Drawing.Point(47, 9);
            this.lbl_Titre.Name = "lbl_Titre";
            this.lbl_Titre.Size = new System.Drawing.Size(137, 23);
            this.lbl_Titre.TabIndex = 0;
            this.lbl_Titre.Text = "Ajouter un mot";
            // 
            // tb_mot
            // 
            this.tb_mot.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.tb_mot.Location = new System.Drawing.Point(51, 58);
            this.tb_mot.Name = "tb_mot";
            this.tb_mot.Size = new System.Drawing.Size(133, 20);
            this.tb_mot.TabIndex = 1;
            this.tb_mot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cb_theme
            // 
            this.cb_theme.DisplayMember = "1";
            this.cb_theme.FormattingEnabled = true;
            this.cb_theme.Items.AddRange(new object[] {
            "Informatique",
            "Culture générale",
            "Sport",
            "Jeux vidéo"});
            this.cb_theme.Location = new System.Drawing.Point(51, 97);
            this.cb_theme.Name = "cb_theme";
            this.cb_theme.Size = new System.Drawing.Size(133, 21);
            this.cb_theme.TabIndex = 2;
            // 
            // btn_parcourir
            // 
            this.btn_parcourir.Location = new System.Drawing.Point(51, 139);
            this.btn_parcourir.Name = "btn_parcourir";
            this.btn_parcourir.Size = new System.Drawing.Size(133, 23);
            this.btn_parcourir.TabIndex = 3;
            this.btn_parcourir.Text = "Charger image";
            this.btn_parcourir.UseVisualStyleBackColor = true;
            this.btn_parcourir.Click += new System.EventHandler(this.btn_parcourir_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lv_lienImage
            // 
            this.lv_lienImage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Répertoire});
            this.lv_lienImage.Location = new System.Drawing.Point(12, 168);
            this.lv_lienImage.Name = "lv_lienImage";
            this.lv_lienImage.Size = new System.Drawing.Size(211, 102);
            this.lv_lienImage.TabIndex = 4;
            this.lv_lienImage.UseCompatibleStateImageBehavior = false;
            this.lv_lienImage.View = System.Windows.Forms.View.Details;
            // 
            // Répertoire
            // 
            this.Répertoire.Text = "Répertoire";
            this.Répertoire.Width = 202;
            // 
            // btn_ajouter
            // 
            this.btn_ajouter.Location = new System.Drawing.Point(51, 292);
            this.btn_ajouter.Name = "btn_ajouter";
            this.btn_ajouter.Size = new System.Drawing.Size(133, 23);
            this.btn_ajouter.TabIndex = 5;
            this.btn_ajouter.Text = "Ajouter";
            this.btn_ajouter.UseVisualStyleBackColor = true;
            // 
            // FormNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 327);
            this.Controls.Add(this.btn_ajouter);
            this.Controls.Add(this.lv_lienImage);
            this.Controls.Add(this.btn_parcourir);
            this.Controls.Add(this.cb_theme);
            this.Controls.Add(this.tb_mot);
            this.Controls.Add(this.lbl_Titre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormNew";
            this.Text = "FormNew";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Titre;
        private System.Windows.Forms.TextBox tb_mot;
        private System.Windows.Forms.ComboBox cb_theme;
        private System.Windows.Forms.Button btn_parcourir;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListView lv_lienImage;
        private System.Windows.Forms.ColumnHeader Répertoire;
        private System.Windows.Forms.Button btn_ajouter;
    }
}