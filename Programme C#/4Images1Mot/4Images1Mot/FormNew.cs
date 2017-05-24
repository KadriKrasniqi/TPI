using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _4Images1Mot
{
    public partial class FormNew : Form
    {
        public FormNew()
        {
            InitializeComponent();
            //Selectionner le premier thème
            cb_theme.SelectedIndex = 0;
        }

        ///INITIALISATION DES VARIABLES
        
        //Contrôler que le mot n'est pas juste un simple caractère
        Regex rgx = new Regex(@"^.$");
        //Contrôler que le mot ne contient pas de chiffre
        Regex rgx2 = new Regex(@"[0-9]");

        int int_noImage = 0;

        /// <summary>
        /// Ajouter une nouvelle image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_parcourir_Click(object sender, EventArgs e)
        {
                //Ouverture de l'explorer windows au bon endroit
                openFileDialog1.Filter = "PNG|*.png|JPG|*.jpg;*.jpeg|BMP|*.bmp";
                openFileDialog1.Title = "Selectioner un fichier";

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                }
                if (openFileDialog1.FileName != "openFileDialog1" && openFileDialog1.FileName != "")
                {
                    //Afficher le lien dans la liste
                    lv_lienImage.Items.Add(openFileDialog1.FileName);                    
                }            
        }

        /// <summary>
        /// Lorsque l'utilisateur clique sur le bouton ajouter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ajouter_Click(object sender, EventArgs e)
        {
            //Verification du mot
            if (tb_mot.Text == "" || rgx.IsMatch(tb_mot.Text) ||rgx2.IsMatch(tb_mot.Text))
            {
                MessageBox.Show("Veuillez inserer un mot de plus de un caractère contenant uniquement des lettres.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Si le mot contient bien 4 images
                if(lv_lienImage.Items.Count == 4)
                {
                    //Initialisation de la classe dbConnexion
                    dbConnexion fn_connexion = new dbConnexion();

                    int idtheme = cb_theme.SelectedIndex + 1;

                    //Appel de la fonction pour inserer le nouveau mot
                    string idmot = fn_connexion.insertMot(tb_mot.Text, Convert.ToString(idtheme));

                    //Copier les images dans un répertoire spécifique
                    for (int i = 0; i < lv_lienImage.Items.Count; i++)
                    {
                        //Récuperer le nouveau mot
                        string str_mot = tb_mot.Text;

                        //Répertoire ou l'image sera copier
                        string str_destination = @".\images\" + str_mot + "" + int_noImage + ".png";
                        int_noImage++;

                        //Copie de l'image dans le répertoire
                        if (!File.Exists(str_destination))
                        {
                            File.Copy(Convert.ToString(lv_lienImage.Items[i].Text), str_destination);
                            fn_connexion.insertImage(str_destination, idmot);
                        }
                    }                        
                }
                else
                {
                    MessageBox.Show("Veuillez inserer 4 images.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
