using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Images1Mot
{
    public class mot : executeRequest
    {
        public mot(SqlConnection connection) : base(connection)
        {
        }

        public void getMot()
        {
            var mot_reader = ExecuteReader("SELECT * FROM t_mot");

            while (mot_reader.Read())
            {
                Console.WriteLine("Orders for " + mot_reader.GetString(1));

                Console.WriteLine(String.Format("{0}, {1}",
            mot_reader["idmot"], mot_reader["mot"]));

            }
        }
    }
}
