namespace _4Images1Mot
{
    partial class FormMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.lbl_Titre = new System.Windows.Forms.Label();
            this.pnl_ChoixTheme = new System.Windows.Forms.Panel();
            this.btn_new = new System.Windows.Forms.Button();
            this.btn_jeux = new System.Windows.Forms.Button();
            this.btn_sport = new System.Windows.Forms.Button();
            this.btn_cultureG = new System.Windows.Forms.Button();
            this.btn_informatique = new System.Windows.Forms.Button();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.pnl_ChoixTheme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Titre
            // 
            this.lbl_Titre.AutoSize = true;
            this.lbl_Titre.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Titre.Location = new System.Drawing.Point(66, 18);
            this.lbl_Titre.Name = "lbl_Titre";
            this.lbl_Titre.Size = new System.Drawing.Size(181, 23);
            this.lbl_Titre.TabIndex = 0;
            this.lbl_Titre.Text = "Choisissez un thème";
            // 
            // pnl_ChoixTheme
            // 
            this.pnl_ChoixTheme.Controls.Add(this.btn_new);
            this.pnl_ChoixTheme.Controls.Add(this.btn_jeux);
            this.pnl_ChoixTheme.Controls.Add(this.lbl_Titre);
            this.pnl_ChoixTheme.Controls.Add(this.btn_sport);
            this.pnl_ChoixTheme.Controls.Add(this.btn_cultureG);
            this.pnl_ChoixTheme.Controls.Add(this.btn_informatique);
            this.pnl_ChoixTheme.Location = new System.Drawing.Point(1, 2);
            this.pnl_ChoixTheme.Name = "pnl_ChoixTheme";
            this.pnl_ChoixTheme.Size = new System.Drawing.Size(302, 310);
            this.pnl_ChoixTheme.TabIndex = 1;
            // 
            // btn_new
            // 
            this.btn_new.BackColor = System.Drawing.Color.Transparent;
            this.btn_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_new.ForeColor = System.Drawing.Color.Transparent;
            this.btn_new.Image = ((System.Drawing.Image)(resources.GetObject("btn_new.Image")));
            this.btn_new.Location = new System.Drawing.Point(0, 275);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(34, 34);
            this.btn_new.TabIndex = 4;
            this.btn_new.UseVisualStyleBackColor = false;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // btn_jeux
            // 
            this.btn_jeux.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_jeux.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_jeux.Location = new System.Drawing.Point(97, 215);
            this.btn_jeux.Name = "btn_jeux";
            this.btn_jeux.Size = new System.Drawing.Size(117, 47);
            this.btn_jeux.TabIndex = 3;
            this.btn_jeux.Text = "Jeux vidéo";
            this.btn_jeux.UseVisualStyleBackColor = true;
            this.btn_jeux.Click += new System.EventHandler(this.ChoixTheme);
            // 
            // btn_sport
            // 
            this.btn_sport.BackColor = System.Drawing.Color.White;
            this.btn_sport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_sport.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sport.Location = new System.Drawing.Point(97, 162);
            this.btn_sport.Name = "btn_sport";
            this.btn_sport.Size = new System.Drawing.Size(117, 47);
            this.btn_sport.TabIndex = 2;
            this.btn_sport.Text = "Sport";
            this.btn_sport.UseVisualStyleBackColor = false;
            this.btn_sport.Click += new System.EventHandler(this.ChoixTheme);
            // 
            // btn_cultureG
            // 
            this.btn_cultureG.BackColor = System.Drawing.Color.Silver;
            this.btn_cultureG.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_cultureG.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cultureG.Location = new System.Drawing.Point(97, 109);
            this.btn_cultureG.Name = "btn_cultureG";
            this.btn_cultureG.Size = new System.Drawing.Size(117, 47);
            this.btn_cultureG.TabIndex = 1;
            this.btn_cultureG.Text = "Culture générale";
            this.btn_cultureG.UseVisualStyleBackColor = false;
            this.btn_cultureG.Click += new System.EventHandler(this.ChoixTheme);
            // 
            // btn_informatique
            // 
            this.btn_informatique.BackColor = System.Drawing.SystemColors.Control;
            this.btn_informatique.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_informatique.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_informatique.Location = new System.Drawing.Point(97, 56);
            this.btn_informatique.Name = "btn_informatique";
            this.btn_informatique.Size = new System.Drawing.Size(117, 47);
            this.btn_informatique.TabIndex = 0;
            this.btn_informatique.Text = "Informatique";
            this.btn_informatique.UseVisualStyleBackColor = false;
            this.btn_informatique.Click += new System.EventHandler(this.ChoixTheme);
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 312);
            this.Controls.Add(this.pnl_ChoixTheme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMenu";
            this.Text = "4 images 1 mot";
            this.pnl_ChoixTheme.ResumeLayout(false);
            this.pnl_ChoixTheme.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Titre;
        private System.Windows.Forms.Panel pnl_ChoixTheme;
        private System.Windows.Forms.Button btn_informatique;
        private System.Windows.Forms.Button btn_jeux;
        private System.Windows.Forms.Button btn_sport;
        private System.Windows.Forms.Button btn_cultureG;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.Button btn_new;
    }
}

