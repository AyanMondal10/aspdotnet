using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ado_project
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            SqlConnection conn;
            SqlCommand cmd;
            int i;
            conn = new SqlConnection("Server=AYAN\\SQLEXPRESS;Database=ado;Trusted_Connection=true");
            conn.Open();
            try
            {

                cmd = new SqlCommand("insert into student values(@p1,@p2)", conn);
                cmd.Parameters.AddWithValue("@p1", 2);
                cmd.Parameters.AddWithValue("@p2", "parthib");
                i = cmd.ExecuteNonQuery();
                if (i != 0)
                    Console.WriteLine("Query executed successfully");
                else
                    Console.WriteLine("Error in query/ connection");

            }
            catch (SqlException se) { Console.WriteLine("Error Message " + se.Message); }
            finally
            {
                conn.Close();
            }
        }


       
    }
}
