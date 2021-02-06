using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using CarProject.Models;


namespace CarProject.DataAccess
{
    public class SearchDB
    {
        public static List<Search> ReadSaleByBrandIdModelId(int brandId , int modelId)
        {
            List<Search> result = new List<Search>();
            using (SqlConnection con = new SqlConnection(Utility.cn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = String.Format("select brand.name as BrandName  , model.name as ModelName, username , dateOfAd , price from sale join brand  on Sale.brandId = brand.id join model on Sale.modelId = model.id join users on Sale.userId = users.id where  brand.id ={0} and model.id={1} ", brandId , modelId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var jiviv = new Search();
                    jiviv.Price = (float)Convert.ToDouble(reader["price"]);
                    jiviv.BrandName = reader["BrandName"].ToString();
                    jiviv.ModelName = reader["ModelName"].ToString();
                    jiviv.UserName = reader["username"].ToString();
                    jiviv.DateOfAd = (DateTime)reader["dateOfAd"];
                    result.Add(jiviv);
                }
                reader.Close();
            }
            return result;
        }

    }
}