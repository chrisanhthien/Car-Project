using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarProject.DataAccess;
namespace CarProject.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }

        public Model(int id, string name, int brandId)
        {
            Id = id;
            Name = name;
            BrandId = brandId;
        }

        public Model() { }
        public bool AddModel(Model model)
        {
            return ModelDB.AddModel(model);
        }
        public bool UpdateModel(Model model)
        {
            return ModelDB.UpdateModel(model);
        }
        public List<Model> ReadModel()
        {
            return ModelDB.ReadModel();
        }
        public Model FindModel(int id)
        {
            return ModelDB.FindModel(id);
        }
        public bool DeleteModel(int id)
        {
            return ModelDB.DeleteModel(id);
        }
        public List<Model> ReadModelByBrandId(int brandId)
        {
            return ModelDB.ReadModelByBrandId(brandId);
        }

    }
}