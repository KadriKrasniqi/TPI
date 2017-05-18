using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        int int_noImage = 0;

        private void btn_parcourir_Click(object sender, EventArgs e)
        {
            //Ouverture de l'explorer windows au bon endroit
            openFileDialog1.Filter = "Cursor Files| *.png";
            openFileDialog1.Title = "Selectioner un fichier";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
            }
            if (openFileDialog1.FileName != "openFileDialog1")
            {
                //Afficher le lien dans la liste
                lv_lienImage.Items.Add(openFileDialog1.FileName);

                string str_mot = tb_mot.Text;

                //Répertoire ou l'image sera copier
                string str_destination = @".\images\"+ str_mot + "" + int_noImage + ".png";
                int_noImage++;

                //Copie de l'image dans le répertoire
                File.Copy(openFileDialog1.FileName, str_destination);
            }
        }
    }
}
