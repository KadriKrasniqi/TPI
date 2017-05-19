using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace _4Images1Mot
{
    class dbConnexion : IDisposable 
    {
        //INITIALISATION VARIABLES
        private SqlConnection dc_connection;
        

        //public dbConnexion(string str_connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=4images1mot;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        public dbConnexion(string str_connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=4images1mot;Connect Timeout=30;ApplicationIntent=ReadWrite")
        {
            dc_connection = new SqlConnection(str_connection);
            

        }

        public void Dispose()
        {
            dc_connection.Close();
        }
        
        /// <summary>
        /// Recuperer l'id du thème choisi
        /// </summary>
        /// <param name="str_theme">nom du thème</param>
        /// <returns>id du thème</returns>
        public string getTheme(string str_theme)
        {
            //Requête SQL
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT idTheme FROM t_theme WHERE theTheme = @theme";
            cmd.Parameters.Add("@theme", str_theme);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = dc_connection;

            //Ouverture de la connexion
            dc_connection.Open();

            var reader = cmd.ExecuteReader();

            string str_idtheme = "";
            
            while (reader.Read())
            {
                str_idtheme = Convert.ToString(reader.GetValue(0));
            }
            dc_connection.Close();
            return str_idtheme;
        }

        /// <summary>
        /// Récuperer les mots du thème choisi
        /// </summary>
        /// <param name="str_idtheme">id du thème</param>
        /// <returns>liste d'objet contenant les mots</returns>
        public List<getMotTheme> getMotOfTheme(string str_idtheme)
        {
            //Requête SQL
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT t_mot.idMot, motMot FROM t_mot, t_appartenir Where t_appartenir.idMot = t_mot.idMot AND t_appartenir.idTheme = @str_idtheme";
            cmd.Parameters.Add("@str_idtheme", str_idtheme);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = dc_connection;

            //Ouverture de la connexion
            dc_connection.Open();

            var reader = cmd.ExecuteReader();
            
            List<getMotTheme> lst_getMotTheme = new List<getMotTheme>();
            
            while (reader.Read())
            {
                lst_getMotTheme.Add(new getMotTheme()
                {
                    idmot = reader.GetInt32(0),
                    mot = reader.GetString(1)

                });
            }
            dc_connection.Close();

            return lst_getMotTheme;
        }

        /// <summary>
        /// Récuperer les images du mot en cours
        /// </summary>
        /// <param name="str_idMot">mot en cours</param>
        /// <returns>liste d'objet contenant les liens des images</returns>
        public List<getImageMot> getImageOfMot(string str_idMot)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT t_image.idImage, imaLien FROM t_image, t_decrire WHERE t_decrire.idImage = t_image.idImage AND t_decrire.idMot = @idmot";
            cmd.Parameters.Add("@idmot", str_idMot);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = dc_connection;

            dc_connection.Open();

            var reader = cmd.ExecuteReader();

            List<getImageMot> lst_image = new List<getImageMot>();


            while (reader.Read())
            {
                lst_image.Add(new getImageMot()
                {
                    idImage = reader.GetInt32(0),
                    lienImage = reader.GetString(1)
                });                
            }
            dc_connection.Close();

            return lst_image;
        }

        /// <summary>
        /// Insérer le nouveau mot
        /// Récuperer son id
        /// </summary>
        /// <param name="mot">mot en cours</param>
        /// <returns>id du mot</returns>
        public string insertMot(string mot, string idTheme)
        {
            //Requête insertion du mot
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO t_mot(motMot) VALUES (@mot)";
            cmd.Parameters.Add("@mot", mot);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = dc_connection;

            //Requête pour récuperer l'id du mot
            SqlCommand cmdReturn = new SqlCommand();
            cmdReturn.CommandText = "SELECT idMot FROM t_mot WHERE motMot = @mot";
            cmdReturn.Parameters.Add("@mot", mot);
            cmdReturn.CommandType = CommandType.Text;
            cmdReturn.Connection = dc_connection;


            //Ouverture de la connexion
            dc_connection.Open();

            //insérer le mot
            cmd.ExecuteNonQuery();

            //Récuperer l'id
            var reader = cmdReturn.ExecuteReader();
            string idMot = "";

            while (reader.Read())
            {
                idMot = Convert.ToString(reader.GetValue(0));
            }

            //Fermer la connexion
            dc_connection.Close();

            //Requête pour lier le lien avec le thème
            SqlCommand cmdLien = new SqlCommand();
            cmdLien.CommandText = "INSERT INTO t_appartenir (t_appartenir.idMot, t_appartenir.idTheme) VALUES (@idMot, @idTheme)";
            cmdLien.Parameters.Add("@idMot", idMot);
            cmdLien.Parameters.Add("@idTheme", idTheme);
            cmdLien.CommandType = CommandType.Text;
            cmdLien.Connection = dc_connection;

            dc_connection.Open();

            //Insérer le lien
            cmdLien.ExecuteNonQuery();

            dc_connection.Close();

            //retourner l'id du mot
            return idMot; 
        }

        /// <summary>
        /// Insérer une image avec le lien du mot
        /// </summary>
        /// <param name="image">Lien de l'image</param>
        /// <param name="idMot">Id du mot</param>
        public void insertImage(string image, string idMot)
        {
            //Insérer l'image
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO t_image (imaLien) VALUES (@lienimage)";
            cmd.Parameters.Add("@lienimage", image);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = dc_connection;

            //Récuperer l'id de l'image
            SqlCommand cmdReturn = new SqlCommand();
            cmdReturn.CommandText = "SELECT idImage FROM t_image WHERE imalien = @lienimage";
            cmdReturn.Parameters.Add("@lienimage", image);
            cmdReturn.CommandType = CommandType.Text;
            cmdReturn.Connection = dc_connection;
                        
            dc_connection.Open();

            //Insértion de l'image
            cmd.ExecuteNonQuery();

            //Récuperation de l'id
            var reader = cmdReturn.ExecuteReader();
            string idImage = "";

            while (reader.Read())
            {
                idImage = Convert.ToString(reader.GetValue(0));
            }
            
            dc_connection.Close();

            //Insértion du lien entre l'image et le mot
            SqlCommand cmdLien = new SqlCommand();
            cmdLien.CommandText = "INSERT INTO t_decrire VALUES (@idImage, @idMot)";
            cmdLien.Parameters.Add("@idImage", idImage);
            cmdLien.Parameters.Add("@idMot", idMot);
            cmdLien.CommandType = CommandType.Text;
            cmdLien.Connection = dc_connection;

            dc_connection.Open();

            cmdLien.ExecuteNonQuery();

            dc_connection.Close();            

        }
    }
}
