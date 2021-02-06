using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarProject.DataAccess;
namespace CarProject.Models
{
    public class Search
    {
        public string BrandName  { get; set; }
        public string ModelName  { get; set; }
        public string UserName  { get; set; }
        public float Price { get; set; }
        public DateTime DateOfAd { get; set; }

        public List<Search> ReadSaleByBrandIdModelId(int brandId , int modelId)
        {
            return SearchDB.ReadSaleByBrandIdModelId(brandId, modelId);
        }
    }
}