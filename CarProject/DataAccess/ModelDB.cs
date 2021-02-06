using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CarProject.Models;

namespace CarProject.DataAccess
{
    public static class ModelDB
    {
        //Add
        public static bool AddModel(Model model)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Utility.cn))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = string.Format("INSERT INTO Model(name,brandId) VALUES('{0}' ,{1})", model.Name ,model.BrandId);
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
        public static bool UpdateModel(Model model)
        {
            using (SqlConnection con = new SqlConnection(Utility.cn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = string.Format("UPDATE Model SET name='{0}', brandId= {1} WHERE Id={1}", model.Name,model.BrandId, model.Id);
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
        //ListOfModel
        public static List<Model> ReadModel()
        {
            List<Model> result = new List<Model>();
            using (SqlConnection con = new SqlConnection(Utility.cn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Model";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Model model = new Model()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        BrandId = Convert.ToInt32(reader["BrandId"]),
                    };
                    result.Add(model);
                    
                }
                reader.Close();
            }
            return result;
        }
        public static Model FindModel(int id)
        {
            Model model = new Model();
            using (SqlConnection con = new SqlConnection(Utility.cn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from model where Id=" + id;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    model.Id = Convert.ToInt32(reader["id"]);
                    model.Name = reader["Name"].ToString();
                    model.BrandId = Convert.ToInt32(reader["id"]);

                }
                reader.Close();
            }
            return model;
        }
        // Delete
        public static bool DeleteModel(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Utility.cn))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "DELETE FROM model WHERE Id = " + id;
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
        public static List<Model> ReadModelByBrandId(int brandId)
        {
            List<Model> result = new List<Model>();
            using (SqlConnection con = new SqlConnection(Utility.cn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Model where brandId=" + brandId;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Model model = new Model()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        BrandId = Convert.ToInt32(reader["BrandId"]),
                    };
                    result.Add(model);

                }
                reader.Close();
            }
            return result;
        }

    }
}