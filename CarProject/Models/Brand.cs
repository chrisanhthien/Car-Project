using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarProject.DataAccess;

namespace CarProject.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool AddBrand(string name )
        {
            return BrandDB.AddBrand(name);
        }

        public bool UpdateBrand(Brand brand)
        {
            return BrandDB.UpdateBrand(brand);
        }
        public bool DeleteBrand(int id)
        {
            return BrandDB.DeleteBrand(id);
        }
        public List<Brand> ReadBrand()
        {
            return BrandDB.ReadBrand();
        }
        public Brand FindBrand(int id)
        {
            return BrandDB.FindBrand(id);
        }
    }
}