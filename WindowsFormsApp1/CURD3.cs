using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class CURD3
    {
        public static int InsertUser(string type, out string Error)
        {
            int res = 0;
            Error = null;
            string connString = "Host=localhost;Username=postgres;Password=aA1aA1aA1;Database=postgres";
            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string coma = "insert into storage.type(type) values(:TYPE)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(coma, conn))
                {
                    cmd.Parameters.AddWithValue(":TYPE", type);
                    try
                    {
                        res = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Error = ex.Message;
                    }
                }
            }
            return res;
        }
        public static int UpdateUser(string type, int id, out string Error)
        {
            int res = 0;
            Error = null;
            string connString = "Host=localhost;Username=postgres;Password=aA1aA1aA1;Database=postgres";
            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string coma = "update storage.provider set type=:TYPE where id=:ID";
                using (NpgsqlCommand cmd = new NpgsqlCommand(coma, conn))
                {
                    cmd.Parameters.AddWithValue(":TYPE", type);
                    cmd.Parameters.AddWithValue(":ID", id);
                    try
                    {
                        res = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Error = ex.Message;
                    }
                }
            }
            return res;
        }
        public static int DeleteUser(int id, out string Error)
        {
            int res = 0;
            Error = null;
            string connString = "Host=localhost;Username=postgres;Password=aA1aA1aA1;Database=postgres";
            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string coma = "delete from storage.provider where id=:ID";
                using (NpgsqlCommand cmd = new NpgsqlCommand(coma, conn))
                {
                    cmd.Parameters.AddWithValue(":ID", id);
                    try
                    {
                        res = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Error = ex.Message;
                    }
                }
            }
            return res;
        }
    }
}