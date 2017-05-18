using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
        /*
        public SqlDataReader getlink(int int_idMot)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM t_decrire WHERE idmot = @idMot";
            cmd.Parameters.Add("@idMot", int_idMot);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = dc_connection;

            dc_connection.Open();

            var reader = cmd.ExecuteReader();

        }

        public SqlDataReader getImage(int int_idMot)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM t_image WHERE ";
        }
        */

    }
}
