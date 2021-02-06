using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarProject.Models;

namespace CarProject.Presentation
{
    public partial class ModelControlPanel : System.Web.UI.Page
    {
        public void FillDropDownBrand()
        {
            Brand brand = new Brand();
            var lstBrand = brand.ReadBrand();
            drpBrand.DataSource = lstBrand;
            drpBrand.DataTextField = "Name";
            drpBrand.DataValueField = "Id";
            drpBrand.DataBind();
        }
        private void FillGridView()
        {
            Model model = new Model();
            GridView1.DataSource = model.ReadModel();
            GridView1.DataBind();

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            FillDropDownBrand();
            FillGridView();
        }

        protected void BtbDelete_Click(object sender, EventArgs e)
        {
            Model model = new Model();
            int id = Convert.ToInt32(hiddenField1.Value);
            if (model.DeleteModel(id))
            {
                StatusLbl.Text = "delete has done successfully";
                FillGridView();
                txtName.Text = "";
                StatusLbl.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                StatusLbl.Text = "failed to delete customer ";
                StatusLbl.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            Model model = new Model();
            model.Id = Convert.ToInt32(hiddenField1.Value);
            model.Name = txtName.Text.Trim();
            if (model.UpdateModel(model))
            {
                StatusLbl.Text = "Update has done successfully";
                StatusLbl.ForeColor = System.Drawing.Color.Green;
                FillGridView();
                txtName.Text = "";
            }
            else
            {
                StatusLbl.Text = "Failed ";
                StatusLbl.ForeColor = System.Drawing.Color.Red;

            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Model model = new Model();
                model.BrandId = Convert.ToInt32(drpBrand.SelectedValue);
                model.Name = txtName.Text;
                if (model.AddModel(model))
                {
                    StatusLbl.Text = "Data has saved successfully";
                    StatusLbl.ForeColor = System.Drawing.Color.Green;
                    FillGridView();
                    txtName.Text = "";
                }
                else
                {
                    StatusLbl.Text = "Data has not saved successfully";
                    StatusLbl.ForeColor = System.Drawing.Color.Red;
                }

            }
        }
        protected void View_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            hiddenField1.Value = id.ToString();
            Model model = new Model();
            model = model.FindModel(id);

            if (model.Id != 0)
            {
                txtName.Text = model.Name.Trim();
                drpBrand.SelectedItem.Value = model.BrandId.ToString(); 
            }
            else
            {
                StatusLbl.Text = "Not found";
            }
        }
    }
}