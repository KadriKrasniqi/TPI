using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4Images1Mot
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Après avoir choisi le thème
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChoixTheme(object sender, EventArgs e)
        {
            //Appel de la fonction pour créer l'interface de jeu
            CreateGame();
            
            
        }

        /// <summary>
        /// Lorsque l'utilisateur veut ajouter un nouveau mot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_new_Click(object sender, EventArgs e)
        {
            FormNew formNewWord = new FormNew();
            formNewWord.Show();
        }


        /// <summary>
        /// Créer l'interface pour le jeu
        /// </summary>
        private void CreateGame()
        {
            //Interface graphique
            pnl_ChoixTheme.Visible = false;
            this.Size = new Size(500, 600);
            //this.BackColor = Color.Blue;

            Panel pnl_jeu = new Panel();
            pnl_jeu.Size = new Size(456, 530);
            pnl_jeu.Location = new Point(12, 12);
            //pnl_jeu.BackColor = Color.DarkBlue;
            this.Controls.Add(pnl_jeu);

            PictureBox pb_ima1 = new PictureBox();
            pb_ima1.Size = new Size(210, 210);
            pb_ima1.ImageLocation = ".\\images\\info.jpg";
            pb_ima1.SizeMode = PictureBoxSizeMode.CenterImage;
            pb_ima1.Location = new Point(12, 12);
            pb_ima1.BackColor = Color.White;
            pnl_jeu.Controls.Add(pb_ima1);

            PictureBox pb_ima2 = new PictureBox();
            pb_ima2.Size = new Size(210, 210);
            pb_ima2.ImageLocation = ".\\images\\bd.jpg";
            pb_ima2.SizeMode = PictureBoxSizeMode.CenterImage;
            pb_ima2.Location = new Point(235, 12);
            pb_ima2.BackColor = Color.White;
            pnl_jeu.Controls.Add(pb_ima2);

            PictureBox pb_ima3 = new PictureBox();
            pb_ima3.Size = new Size(210, 210);
            pb_ima3.ImageLocation = ".\\images\\sport.png";
            pb_ima3.SizeMode = PictureBoxSizeMode.CenterImage;
            pb_ima3.Location = new Point(12, 235);
            pb_ima3.BackColor = Color.White;
            pnl_jeu.Controls.Add(pb_ima3);

            PictureBox pb_ima4 = new PictureBox();
            pb_ima4.Size = new Size(210, 210);
            pb_ima4.ImageLocation = ".\\images\\csharp.png";
            pb_ima4.SizeMode = PictureBoxSizeMode.CenterImage;
            pb_ima4.Location = new Point(235, 235);
            pb_ima4.BackColor = Color.White;
            pnl_jeu.Controls.Add(pb_ima4);

            RichTextBox rtb_MotAleatoire = new RichTextBox();
            rtb_MotAleatoire.BorderStyle = BorderStyle.None;
            rtb_MotAleatoire.Size = new Size(210, 50);
            rtb_MotAleatoire.SelectionFont = new Font("TimesNewRoman", 22, FontStyle.Bold);
            rtb_MotAleatoire.SelectionAlignment = HorizontalAlignment.Center;
            rtb_MotAleatoire.Location = new Point(12, 460);
            pnl_jeu.Controls.Add(rtb_MotAleatoire);

            TextBox tb_reponse = new TextBox();
            tb_reponse.Size = new Size(100, 50);
            tb_reponse.Location = new Point(235, 460);
            pnl_jeu.Controls.Add(tb_reponse);
        }

    }
}
