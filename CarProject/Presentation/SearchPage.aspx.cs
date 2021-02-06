using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarProject.Models;

namespace CarProject.Presentation
{
    public partial class SearchPage : System.Web.UI.Page
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {     
                    FillDropDownBrand();
            }               
            
        }

        protected void drpBrand_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //Very important set properties  Autopostback to true for drpBrand  in properties, otherwise it is not trigger
            int brandId = Convert.ToInt32(drpBrand.SelectedValue);
            FillDropDownModel(brandId);

        }
        private void FillGridView_SearchResult(int brandId , int modelId )
        {
            Search se = new Search();
            grdResultSearch.DataSource = se.ReadSaleByBrandIdModelId(brandId, modelId);
               grdResultSearch.DataBind();


        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            if (drpBrand.SelectedValue.ToString() == "0")
            {
                StatusLbl.Text = "select brand";
            }
            else
            {
                StatusLbl.Text = "";
                FillGridView_SearchResult(Convert.ToInt32(drpBrand.SelectedValue), Convert.ToInt32(drpModel.SelectedValue));
            }

        }
    }
}