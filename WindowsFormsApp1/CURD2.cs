using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class CURD2
    {
        public static int InsertUser(string name, string count,string price, DateTime date,int pr_id ,int typ_id,out string Error)
        {
            int res = 0;
            Error = null;
            string connString = "Host=localhost;Username=postgres;Password=aA1aA1aA1;Database=postgres";
            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string coma = "insert into storage.product(name,count,price,date,pr_id,typ_id) values(:NAME,:COUNT,:PRICE,:DATE,:PR_ID,:TYP_ID)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(coma, conn))
                {
                    cmd.Parameters.AddWithValue("NAME", name);
                    cmd.Parameters.AddWithValue("COUNT", Convert.ToInt32(count));
                    cmd.Parameters.AddWithValue("PRICE", Convert.ToDouble(price));
                    cmd.Parameters.AddWithValue("DATE", date);
                    cmd.Parameters.AddWithValue("PR_ID", pr_id);
                    cmd.Parameters.AddWithValue("TYP_ID", typ_id);
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
        public static int UpdateUser(string name, string count, string price, DateTime date,int id, int pr_id, int typ_id, out string Error)
        {
            int res = 0;
            Error = null;
            string connString = "Host=localhost;Username=postgres;Password=aA1aA1aA1;Database=postgres";
            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string coma = "update storage.product set name=:NAME,count=:COUNT,price=:PRICE,date=:DATE,pr_id=:PR_ID,typ-id=:TYP_ID where id=:ID";
                using (NpgsqlCommand cmd = new NpgsqlCommand(coma, conn))
                {
                    cmd.Parameters.AddWithValue(":NAME", name);
                    cmd.Parameters.AddWithValue(":COUNT", Convert.ToInt32(count));
                    cmd.Parameters.AddWithValue(":PRICE", Convert.ToDouble(price));
                    cmd.Parameters.AddWithValue("DATE", date);
                    cmd.Parameters.AddWithValue("PR_ID", pr_id);
                    cmd.Parameters.AddWithValue("TYP_ID", typ_id);
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