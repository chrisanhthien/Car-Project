using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CarProject.Models;

namespace CarProject.DataAccess
{
    public static class UserDB
    {
        public static int CheckUserValidity(string userName , string pass)
        {
            int id = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(Utility.cn))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = string.Format("SELECT * FROM Users WHERE Username ='{0}' AND Pass ='{1}' ",userName,pass );
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        id = Convert.ToInt32(reader["id"]);
                    }
                    reader.Close();
                }
            }
            catch (Exception)
            {
                //
            }
            return id;
        }



    }
}