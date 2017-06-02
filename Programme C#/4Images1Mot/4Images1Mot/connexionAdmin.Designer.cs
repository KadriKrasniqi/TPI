namespace _4Images1Mot
{
    partial class connexionAdmin
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
            this.tb_identifiant = new System.Windows.Forms.TextBox();
            this.tb_mdp = new System.Windows.Forms.TextBox();
            this.lbl_id = new System.Windows.Forms.Label();
            this.lbl_mdp = new System.Windows.Forms.Label();
            this.btn_SeConnecter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_identifiant
            // 
            this.tb_identifiant.Location = new System.Drawing.Point(82, 12);
            this.tb_identifiant.Name = "tb_identifiant";
            this.tb_identifiant.Size = new System.Drawing.Size(100, 20);
            this.tb_identifiant.TabIndex = 0;
            // 
            // tb_mdp
            // 
            this.tb_mdp.Location = new System.Drawing.Point(82, 48);
            this.tb_mdp.Name = "tb_mdp";
            this.tb_mdp.PasswordChar = '*';
            this.tb_mdp.Size = new System.Drawing.Size(100, 20);
            this.tb_mdp.TabIndex = 1;
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Location = new System.Drawing.Point(5, 12);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(59, 13);
            this.lbl_id.TabIndex = 2;
            this.lbl_id.Text = "Identifiant :";
            // 
            // lbl_mdp
            // 
            this.lbl_mdp.AutoSize = true;
            this.lbl_mdp.Location = new System.Drawing.Point(5, 48);
            this.lbl_mdp.Name = "lbl_mdp";
            this.lbl_mdp.Size = new System.Drawing.Size(77, 13);
            this.lbl_mdp.TabIndex = 3;
            this.lbl_mdp.Text = "Mot de passe :";
            // 
            // btn_SeConnecter
            // 
            this.btn_SeConnecter.Location = new System.Drawing.Point(82, 78);
            this.btn_SeConnecter.Name = "btn_SeConnecter";
            this.btn_SeConnecter.Size = new System.Drawing.Size(100, 23);
            this.btn_SeConnecter.TabIndex = 4;
            this.btn_SeConnecter.Text = "Se connecter";
            this.btn_SeConnecter.UseVisualStyleBackColor = true;
            this.btn_SeConnecter.Click += new System.EventHandler(this.btn_SeConnecter_Click);
            // 
            // connexionAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 113);
            this.Controls.Add(this.btn_SeConnecter);
            this.Controls.Add(this.lbl_mdp);
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.tb_mdp);
            this.Controls.Add(this.tb_identifiant);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "connexionAdmin";
            this.Text = "Connexion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_identifiant;
        private System.Windows.Forms.TextBox tb_mdp;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.Label lbl_mdp;
        private System.Windows.Forms.Button btn_SeConnecter;
    }
}