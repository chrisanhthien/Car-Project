using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CarProject.Models;

namespace CarProject.DataAccess
{
    public class SaleDB
    {
        //Add
        public static bool AddSale(Sale sale)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Utility.cn))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = string.Format("INSERT INTO sale(brandId,modelId,userId,price,dateOfAd) VALUES({0},{1},{2},{3},'{4}')",sale.brandId,sale.modelId,sale.userId,sale.Price,sale.date);
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
        public static List<Search> ReadSaleByUserId(int userId)
        {
            List<Search> result = new List<Search>();
            using (SqlConnection con = new SqlConnection(Utility.cn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = String.Format("select brand.name as BrandName  , model.name as ModelName, username , dateOfAd , price from sale join brand  on Sale.brandId = brand.id join model on Sale.modelId = model.id join users on Sale.userId = users.id where userId={0} ", userId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var jiviv = new Search();
                    jiviv.Price = (float)Convert.ToDouble(reader["price"]);
                    jiviv.BrandName = reader["BrandName"].ToString();
                    jiviv.ModelName = reader["ModelName"].ToString();
                    jiviv.UserName = reader["username"].ToString();
                    jiviv.DateOfAd = (DateTime) reader["dateOfAd"];
                    result.Add(jiviv);
                }
                reader.Close();
            }
            return result;
        }
    }
}