using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class CURD
    {
        public static int InsertUser(string name, string phone ,out string Error)
        {
            int res = 0;
            Error = null;
            string connString = "Host=localhost;Username=postgres;Password=aA1aA1aA1;Database=postgres";
            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string coma = "insert into storage.provider(name,phone,date) values(:NAME,:PHONE)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(coma,conn))
                {
                    cmd.Parameters.AddWithValue("NAME", name);
                    cmd.Parameters.AddWithValue("PHONE", Convert.ToInt32(phone));
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
        public static int UpdateUser(string name, string phone, out string Error,int id)
        {
            int res = 0;
            Error = null;
            string connString = "Host=localhost;Username=postgres;Password=aA1aA1aA1;Database=postgres";
            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string coma = "update storage.provider set name=:NAME,phone=:PHONE where id=:ID";
                using (NpgsqlCommand cmd = new NpgsqlCommand(coma, conn))
                {
                    cmd.Parameters.AddWithValue(":NAME", name);
                    cmd.Parameters.AddWithValue(":PHONE", Convert.ToInt32(phone));
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