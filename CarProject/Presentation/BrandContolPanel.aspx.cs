using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarProject.Models;

namespace CarProject.Presentation
{
    public partial class BrandContolPanel : System.Web.UI.Page
    {
        private void FillGridView()
        {
            Brand brand = new Brand();
            GridView1.DataSource= brand.ReadBrand();
            GridView1.DataBind();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            FillGridView();

        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Brand brand = new Brand();                
                if (brand.AddBrand(txtName.Text))
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
            Brand brand = new Brand();
            brand = brand.FindBrand(id);

            if (brand.Id != 0)
            {
                txtName.Text = brand.Name.Trim();
            }
            else
            {
                StatusLbl.Text = "Not found";
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            Brand brand = new Brand();
            brand.Id = Convert.ToInt32(hiddenField1.Value);          
                brand.Name = txtName.Text.Trim();
                if (brand.UpdateBrand(brand))
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

        protected void BtbDelete_Click(object sender, EventArgs e)
        {
            Brand brand = new Brand();
            int id = Convert.ToInt32(hiddenField1.Value);
            if (brand.DeleteBrand(id))
            {
                StatusLbl.Text = "delete has done successfully";
                FillGridView();
                txtName.Text="";
                StatusLbl.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                StatusLbl.Text = "failed to delete customer ";
                StatusLbl.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}