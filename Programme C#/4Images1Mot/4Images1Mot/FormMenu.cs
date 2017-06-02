using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        RichTextBox rtb_MotAleatoire = new RichTextBox();
        TextBox tb_reponse = new TextBox();

        //Points de jeu
        Label lbl_point = new Label();
        int int_point = 0;
        
        int int_motSuivant = 0;

        List<getMotTheme> lst_motOfTheme = new List<getMotTheme>();

        /// <summary>
        /// Après avoir choisi le thème
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChoixTheme(object sender, EventArgs e)
        {
            //Remettre les points à zéro
            int_point = 0;

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
            if(lst_motOfTheme.Count == 0)
            {
                MessageBox.Show("Le thème que vous avez choisi ne contient aucun mot. Veuillez-choisir un autre thème.","Aucun mot", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //Appel de la fonction pour créer l'interface de jeu
                CreateGame();

                showImages(Convert.ToString(lst_motOfTheme[int_motSuivant].idmot), lst_motOfTheme[int_motSuivant].mot);
            }
            
        }

        /// <summary>
        /// Fonction qui gère les images avec le mot en cours
        /// Partie affichage graphique
        /// </summary>
        /// <param name="mot">Mot en cours</param>
        private void showImages(string idmot, string mot)
        {
            //enlever l'ancienne réponse
            tb_reponse.Text = "Réponse ?";
            
            //Initialisation de variables pour le mélange des lettres
            Random rnd = new Random();
            char temp;
            char[] chars = mot.ToCharArray();
            int int_nbChar = chars.Length;

            //Boucle pour mélanger les lettres du mot aléatoirement
            for (int i = 0; i < int_nbChar; i++)
            {
                int j = rnd.Next(0, int_nbChar - 1);
                temp = chars[i];
                chars[i] = chars[j];
                chars[j] = temp;
            }
            //Récuperer le tableau de lettres dans une chaine de caractère
            string str_MotMelange = new string(chars);

            //Affichage des lettres mélangées dans la richTextBox
            rtb_MotAleatoire.Text = str_MotMelange;
            rtb_MotAleatoire.SelectAll();
            rtb_MotAleatoire.SelectionFont = new Font("TimesNewRoman", 20, FontStyle.Bold);
            rtb_MotAleatoire.SelectionAlignment = HorizontalAlignment.Center;

            //Initialisation de la classe dbconnexion
            dbConnexion si_connexion = new dbConnexion();

            //Récuperer la liste des images du mot
            List<getImageMot> lst_imageOfMot = si_connexion.getImageOfMot(Convert.ToString(idmot));

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
            connexionAdmin ca = new connexionAdmin();
            ca.Show();
                    
           
            

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string Hash(string input)
        {
            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }

        /// <summary>
        /// Lorsque l'utilisateur veut revenir au menu principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_quitter_Click(object sender, EventArgs e)
        {
            //Remettre les mots à 0
            int_motSuivant = 0;

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
                //Ajout des points
                int_point++;
                lbl_point.Text = "Points : " + int_point;

                //Si il reste encore des mots du thème
                if((int_motSuivant) < lst_motOfTheme.Count)
                {
                    //Changer les images du jeux
                    showImages(Convert.ToString(lst_motOfTheme[int_motSuivant].idmot), lst_motOfTheme[int_motSuivant].mot);
                }
                else
                {
                    btn_quitter_Click(sender, e);

                    MessageBox.Show("Bravo ! Vous avez trouvé tous les mots du thème. Veuillez-choisir un nouveau thème.\n\n Nombre de point(s) : "+ int_point, "Bravo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                //Enlever un point
                int_point--;
                lbl_point.Text = "Points : " + int_point;
            }
        }

        private void tb_reponse_Click(object sender, EventArgs e)
        {
            if(tb_reponse.Text == "Réponse ?")
            {
                tb_reponse.Text = "";
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
            pb_ima1.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_ima1.Location = new Point(12, 12);
            pb_ima1.BackColor = Color.White;
            pnl_jeu.Controls.Add(pb_ima1);

            pb_ima2.Size = new Size(210, 210);
            pb_ima2.BorderStyle = BorderStyle.Fixed3D;
            pb_ima2.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_ima2.Location = new Point(235, 12);
            pb_ima2.BackColor = Color.White;
            pnl_jeu.Controls.Add(pb_ima2);

            pb_ima3.Size = new Size(210, 210);
            pb_ima3.BorderStyle = BorderStyle.Fixed3D;
            pb_ima3.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_ima3.Location = new Point(12, 235);
            pb_ima3.BackColor = Color.White;
            pnl_jeu.Controls.Add(pb_ima3);

            pb_ima4.Size = new Size(210, 210);
            pb_ima4.BorderStyle = BorderStyle.Fixed3D;
            pb_ima4.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_ima4.Location = new Point(235, 235);
            pb_ima4.BackColor = Color.White;
            pnl_jeu.Controls.Add(pb_ima4);

            rtb_MotAleatoire.BorderStyle = BorderStyle.None;
            rtb_MotAleatoire.Size = new Size(210, 50);
            rtb_MotAleatoire.Location = new Point(12, 460);
            rtb_MotAleatoire.Enabled = false;
            pnl_jeu.Controls.Add(rtb_MotAleatoire);

            tb_reponse.Size = new Size(130, 50);
            tb_reponse.Text = "Réponse ?";
            tb_reponse.Location = new Point(235, 460);
            tb_reponse.Click += new System.EventHandler(tb_reponse_Click);
            pnl_jeu.Controls.Add(tb_reponse);

            lbl_point.Text = "Point(s) : " + int_point;
            lbl_point.Location = new Point(235, 490);
            pnl_jeu.Controls.Add(lbl_point);

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
