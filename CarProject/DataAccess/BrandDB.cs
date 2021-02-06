using CarProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CarProject.DataAccess
{
    public static class BrandDB
    {
        //Add
        public static bool AddBrand(string name)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Utility.cn))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = String.Format("INSERT INTO Brand(name) VALUES('{0}')", name);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Update
        public static bool UpdateBrand(Brand brand)
        {
            using (SqlConnection con = new SqlConnection(Utility.cn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = String.Format("UPDATE Brand SET name='{0}' WHERE Id={1}", brand.Name, brand.Id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        //Delete
        public static bool DeleteBrand(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Utility.cn))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "DELETE FROM Brand WHERE Id = " + id;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        //ListOfBrand
        public static List<Brand> ReadBrand()
        {
            List<Brand> result = new List<Brand>();
            using (SqlConnection con = new SqlConnection(Utility.cn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Brand";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Brand brand = new Brand()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                    };
                    result.Add(brand);
                    //Brand brand = new Brand();
                    //brand.Id = Convert.ToInt32(reader["Id"]);
                    //brand.Name = reader["brand"].ToString();
                    //result.Add(brand);
                }
                reader.Close();
            }
            return result;
        }
        //find 
        public static Brand FindBrand(int id)
        {
            Brand brand = new Brand();
            using (SqlConnection con = new SqlConnection(Utility.cn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from brand where Id=" + id;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    brand.Id = Convert.ToInt32(reader["id"]);
                    brand.Name = reader["Name"].ToString();
                 }
                reader.Close();
            }
            return brand;
        }

    }
}