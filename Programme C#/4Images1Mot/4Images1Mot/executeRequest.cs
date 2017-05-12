using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Images1Mot
{
    public abstract class executeRequest
    {
        private SqlConnection er_connection;

        protected executeRequest(SqlConnection connection)
        {
            er_connection = connection;
        }

        protected SqlDataReader ExecuteReader(string query)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = er_connection;

            er_connection.Open();

            var reader = cmd.ExecuteReader();

            // 

            er_connection.Close();

            return reader;
        }


    }
}
