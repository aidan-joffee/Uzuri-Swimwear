﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.Entity.Core.Objects;
using Uzuri_Swimwear.Model;
using System.Web.UI.WebControls;

namespace Uzuri_Swimwear.Forms
{
    public partial class ProductForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductGridView();
                ImageGridView.DataBind(); //to ensure emptydatatemplate appears
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to databind the imagegridview
        /// </summary>
        private void BindImageGridView(int prodID)
        {
            ImageGridView.DataSource = GetProductImages(prodID);
            ImageGridView.DataBind();
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to databind the productgridview
        /// </summary>
        private void BindProductGridView()
        {
            ProductGridView.DataSource = GetProducts();
            ProductGridView.DataBind();
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to populate the product details list 
        /// </summary>
        /// <returns>All product details</returns>
        public IEnumerable<GetAllProductsDetails_Result> GetProducts()
        {
            UzuriSwimwearDBEntities dBEntities = new UzuriSwimwearDBEntities();
            var query = dBEntities.GetAllProductsDetails();
            return query;
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to retreive the product categories to the dropdownlist
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GetProdCategories_Result> GetCategories()
        {
            try
            {
                UzuriSwimwearDBEntities dBEntities = new UzuriSwimwearDBEntities();
                var query = dBEntities.GetProdCategories();
                return query;
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to update a product
        /// </summary>
        public void UpdateProduct(int id, string name, string desc, bool forSale, int category)
        {
            //TODO impement fetching this based on login
            int userRole = 1;
            using (var dbContext = new UzuriSwimwearDBEntities())
            {
                ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                dbContext.EditProduct(userRole, name, desc, id, forSale, category, responseMessage);
                String response = Convert.ToString(responseMessage.Value);
                //TODO remove this
                Response.Write(response);
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to retrieve the images of the selected product from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected IEnumerable<GetProductImages_Result> GetProductImages(int id)
        {

            var dbContext = new UzuriSwimwearDBEntities();
            ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
            var query = dbContext.GetProductImages(id, responseMessage);
            //TODO remove test label
            Response.Write(Convert.ToString(responseMessage.Value));
            return query;
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to execute the edit, select, update, cancel commands on the productgridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ProductGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "SelectRow")
            {
                int prodID = Convert.ToInt32(e.CommandArgument);
                BindImageGridView(prodID);
            }
            else if (e.CommandName == "EditRow")
            {
                //index of the row
                int rowIndex = Convert.ToInt32(((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex);
                //select row to edit
                ProductGridView.EditIndex = rowIndex;
                BindProductGridView();
            }
            else if (e.CommandName == "CancelRow")
            {
                //cancel update
                ProductGridView.EditIndex = -1;
                BindProductGridView();
            }
            else if (e.CommandName == "UpdateRow")
            {
                //index of the row
                int rowIndex = Convert.ToInt32(((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex);
                //updating
                int productID = Convert.ToInt32(e.CommandArgument);
                string productName = ((TextBox)ProductGridView.Rows[rowIndex].FindControl("ProdNameBox")).Text;
                string productDesc = ((TextBox)ProductGridView.Rows[rowIndex].FindControl("ProdDescBox")).Text;
                bool prodForSale = ((CheckBox)ProductGridView.Rows[rowIndex].FindControl("ProdForSale")).Checked;
                int prodCategory = Convert.ToInt32(((DropDownList)ProductGridView.Rows[rowIndex].FindControl("CategoryDropList")).SelectedValue);

                //updating
                UpdateProduct(productID, productName, productDesc, prodForSale, prodCategory);
                ProductGridView.EditIndex = -1;
                BindProductGridView();
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to change the index of the page for the gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ProductGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ProductGridView.PageIndex = e.NewPageIndex;
            BindProductGridView();
        }
        //--
    }
}
//---------------------------------------------end of page---------------------------------------------------