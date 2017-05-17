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

        //INITIALISATION DES VARIABLES
        Panel pnl_jeu = new Panel();
        PictureBox pb_ima1 = new PictureBox();
        PictureBox pb_ima2 = new PictureBox();
        PictureBox pb_ima3 = new PictureBox();
        PictureBox pb_ima4 = new PictureBox();
        
        TextBox tb_reponse = new TextBox();

        int int_motSuivant = 0;

        List<getMotTheme> lst_motOfTheme = new List<getMotTheme>();

        /// <summary>
        /// Après avoir choisi le thème
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChoixTheme(object sender, EventArgs e)
        {
            //Appel de la fonction pour créer l'interface de jeu
            CreateGame();

            //Initialisation de la classe dbconnexion
            dbConnexion fm_connexion = new dbConnexion();

            //Recuperer le thème séléctionné par l'utilisateur
            string str_theme = ((Button)sender).Text;

            //Appel de la fonction getTheme pour recuperer le "ID" du thème choisi
            string idtheme = fm_connexion.getTheme(str_theme);

            //Appel de la fonction getMotOfTheme pour recuperer tous les mots du thème choisi
            lst_motOfTheme = fm_connexion.getMotOfTheme(idtheme);

            //Connaître la taille de la liste de mots
            int int_lenghtList = lst_motOfTheme.Count();
                        
            //Appel du premier mot
            showImages(Convert.ToString(lst_motOfTheme[int_motSuivant].idmot));
            
        }

        private void showImages(string mot)
        {
            //Initialisation de la classe dbconnexion
            dbConnexion si_connexion = new dbConnexion();

            //Récuperer la liste des images du mot
            List<getImageMot> lst_imageOfMot = si_connexion.getImageOfMot(Convert.ToString(mot));

            //Récuperer le lien des images
            pb_ima1.ImageLocation = lst_imageOfMot[0].lienImage;
            pb_ima2.ImageLocation = lst_imageOfMot[1].lienImage;
            pb_ima3.ImageLocation = lst_imageOfMot[2].lienImage;
            pb_ima4.ImageLocation = lst_imageOfMot[3].lienImage;

            //Passer au mot suivant
            int_motSuivant++;
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
        /// Lorsque l'utilisateur veut revenir au menu principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_quitter_Click(object sender, EventArgs e)
        {
            pnl_jeu.Visible = false;
            pnl_ChoixTheme.Visible = true;
            this.Size = new Size(320, 350);
        }

        /// <summary>
        /// Lorsque l'utilisateur souhaite verifier si il a trouvé
        /// le bon mot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_valider_Click(object sender, EventArgs e)
        {
            //Si l'utilisateur a trouvé la bonne réponse
            if(tb_reponse.Text == lst_motOfTheme[int_motSuivant -1].mot)
            {
                MessageBox.Show("MOT CORRECT");
                if((int_motSuivant) < lst_motOfTheme.Count)
                {
                    //Changer les images du jeux
                    showImages(Convert.ToString(lst_motOfTheme[int_motSuivant].idmot));
                }              
            }
        }

        /// <summary>
        /// Créer l'interface pour le jeu
        /// </summary>
        private void CreateGame()
        {
            //Interface graphique
            pnl_ChoixTheme.Visible = false;
            this.Size = new Size(500, 600);

            pnl_jeu.Visible = true;
            pnl_jeu.Size = new Size(456, 530);
            pnl_jeu.Location = new Point(12, 12);
            pnl_jeu.BackColor = Color.LightGray;
            this.Controls.Add(pnl_jeu);

            pb_ima1.Size = new Size(210, 210);
            pb_ima1.BorderStyle = BorderStyle.Fixed3D;
            //pb_ima1.ImageLocation = ".\\images\\adobe3.png";
            pb_ima1.SizeMode = PictureBoxSizeMode.CenterImage;
            pb_ima1.Location = new Point(12, 12);
            pb_ima1.BackColor = Color.White;
            pnl_jeu.Controls.Add(pb_ima1);

            pb_ima2.Size = new Size(210, 210);
            pb_ima2.BorderStyle = BorderStyle.Fixed3D;
            //pb_ima2.ImageLocation = ".\\images\\bd.jpg";
            pb_ima2.SizeMode = PictureBoxSizeMode.CenterImage;
            pb_ima2.Location = new Point(235, 12);
            pb_ima2.BackColor = Color.White;
            pnl_jeu.Controls.Add(pb_ima2);

            pb_ima3.Size = new Size(210, 210);
            pb_ima3.BorderStyle = BorderStyle.Fixed3D;
            //pb_ima3.ImageLocation = ".\\images\\sport.png";
            pb_ima3.SizeMode = PictureBoxSizeMode.CenterImage;
            pb_ima3.Location = new Point(12, 235);
            pb_ima3.BackColor = Color.White;
            pnl_jeu.Controls.Add(pb_ima3);

            pb_ima4.Size = new Size(210, 210);
            pb_ima4.BorderStyle = BorderStyle.Fixed3D;
            //pb_ima4.ImageLocation = ".\\images\\csharp.png";
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

            tb_reponse.Size = new Size(130, 50);
            tb_reponse.Text = "Reponse ?";
            tb_reponse.Location = new Point(235, 460);
            pnl_jeu.Controls.Add(tb_reponse);

            Button btn_valider = new Button();
            btn_valider.Location = new Point(370, 460);
            btn_valider.Text = "Valider";
            btn_valider.FlatStyle = FlatStyle.System;
            btn_valider.Click += new System.EventHandler(btn_valider_Click);
            pnl_jeu.Controls.Add(btn_valider);

            Button btn_quitter = new Button();
            btn_quitter.Location = new Point(370, 490);
            btn_quitter.Text = "Quitter";
            btn_quitter.FlatStyle = FlatStyle.System;
            btn_quitter.Click += new System.EventHandler(btn_quitter_Click);
            pnl_jeu.Controls.Add(btn_quitter);
        }

    }
}
