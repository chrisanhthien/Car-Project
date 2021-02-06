using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarProject.DataAccess;

namespace CarProject.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int brandId { get; set; }
        public DateTime date { get; set; }
        public int modelId { get; set; }
        public int userId { get; set; }
        public float Price { get; set; }

        public bool AddSale(Sale sale)
        {
            return SaleDB.AddSale(sale);
        }
       public List<Search> ReadSaleByUserId(int userId)
        {
            return SaleDB.ReadSaleByUserId(userId);
        }

    }
}