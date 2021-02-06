using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarProject.Models;

namespace CarProject.Presentation
{
    public partial class SaleWebPage : System.Web.UI.Page
    {
        public void FillDropDownBrand()
        {
            Brand brand = new Brand();
            var lstBrand = brand.ReadBrand();
            drpBrand.DataSource = lstBrand;
            drpBrand.DataTextField = "Name";
            drpBrand.DataValueField = "Id";
            drpBrand.DataBind();

            drpBrand.Items.Insert(0, new ListItem("--Select--", "0"));
            drpBrand.SelectedIndex = 0;
            drpBrand.SelectedValue = 0.ToString();
        }
        private void FillDropDownModel(int brandId)
        {
            Model model = new Model();
            var lstModel = model.ReadModelByBrandId(brandId);
            drpModel.DataSource = lstModel;
            drpModel.DataTextField = "Name";
            drpModel.DataValueField = "Id";
            drpModel.DataBind();
        }

        private void FillGridView_SaleByUserId(int userId)
        {
            Sale sale = new Sale();
            grdSaleUserInfo.DataSource  = sale.ReadSaleByUserId(userId);
            grdSaleUserInfo.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!Page.IsPostBack)
            {

                if (Application["userId"] != null)
                {
                    //to display userId but it is better to read userName
                    lblUserId.Text = Application["userId"].ToString();
                    FillDropDownBrand();
                    FillGridView_SaleByUserId(Convert.ToInt32(Application["userId"]));
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                Sale sale = new Sale()
                {
                    brandId = Convert.ToInt32(drpBrand.SelectedValue),
                    modelId = Convert.ToInt32(drpModel.SelectedValue),
                    userId = Convert.ToInt32(Application["userId"]),
                    date = DateTime.Now,
                    Price = (float)Convert.ToDouble(txtPrice.Text)
                };
                if (sale.AddSale(sale))
                {
                    StatusLbl.Text = "Done";
                }
                else
                {
                    StatusLbl.Text = "try later,Call with admin";
                }
            }
            
        }

        protected void drpBrand_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //Very important set properties  Autopostback to true for drpBrand  in properties, otherwise it is not trigger
            int brandId = Convert.ToInt32(drpBrand.SelectedValue);
            FillDropDownModel(brandId);

        }
    }
}