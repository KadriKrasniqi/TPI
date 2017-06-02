using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace _4Images1Mot
{
    public partial class connexionAdmin : Form
    {
        public connexionAdmin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Verification des informations de connexion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SeConnecter_Click(object sender, EventArgs e)
        {
            //Hash du mot de passer insérer par l'utilisateur pour comparer avec la base de données
            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(tb_mdp.Text));
            string mdpSha1 = string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
            
            //Initialisation de la classe dbConnexion
            dbConnexion nc_dbConnexion = new dbConnexion();

            List<getCompteAdmin> lst_getCompteAdmin = new List<getCompteAdmin>();

            lst_getCompteAdmin = nc_dbConnexion.getCompteAdmin();

            //Verifier si les informations sont correctes
            if (lst_getCompteAdmin[0].conIdentifiant == tb_identifiant.Text && lst_getCompteAdmin[0].conMotDePasse == mdpSha1)
            {
                FormNew formNewWord = new FormNew();
                formNewWord.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Erreur de l'identifiant ou du mot de passe.", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
