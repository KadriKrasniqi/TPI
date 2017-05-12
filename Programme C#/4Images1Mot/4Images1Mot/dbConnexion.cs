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
        public mot db_mot;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str_connection"></param>
        //public dbConnexion(string str_connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=4images1mot;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        public dbConnexion(string str_connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=4images1mot;Connect Timeout=30;ApplicationIntent=ReadWrite")
        {
            dc_connection = new SqlConnection(str_connection);

            db_mot = new mot(dc_connection);

        }
        public void Dispose()
        {
            dc_connection.Close();
        }

        public SqlDataReader getmot()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * from t_mot";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = dc_connection;

            dc_connection.Open();

           var reader = cmd.ExecuteReader();
            
           while (reader.Read())
           {
                Console.WriteLine("Orders for " + reader.GetString(1));

                Console.WriteLine(String.Format("{0}, {1}",
            reader["idmot"], reader["motMot"]));
           }

            return reader;
        }
        /*
        public void executeRequest(string str_SqlCommand)
        {


            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=4images1mot;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = str_SqlCommand;
            //cmd.CommandText = "SELECT * FROM [NewDatabase].[dbo].[Clients]";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.
            while (reader.Read())
            {
                Console.WriteLine("Orders for " + reader.GetString(1));

                Console.WriteLine(String.Format("{0}, {1}",
            reader["idMot"], reader["motMot"]));

            }

            // Make sure to always close readers and connections.  
            reader.Close();
            sqlConnection1.Close();
        }*/
    }
}
