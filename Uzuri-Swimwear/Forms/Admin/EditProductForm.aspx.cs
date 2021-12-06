using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.Entity.Core.Objects;
using Uzuri_Swimwear.Model;
using System.Web.UI.WebControls;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

/*
 * Author: Aidan Joffee
 */

namespace Uzuri_Swimwear.Forms
{    
    public partial class EditProductForm : System.Web.UI.Page
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
        /// Method to set and get the productID from the view state
        /// </summary>
        public int productID
        {
            get
            {
                //gets the productID from the viewstate
                int returnValue = 0;
                //checks if its null then gets it
                if (ViewState["productID"] != null)
                    Int32.TryParse(ViewState["productID"].ToString(), out returnValue);
                return returnValue;
            }
            set
            {
                ViewState["productID"] = value;
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to databind the imagegridview
        /// </summary>
        private void BindImageGridView()
        {
            ImageGridView.DataSource = GetProductImages(this.productID);
            ProdIDLbl.Text = String.Format("Selected Product ID: {0}", this.productID); //displaying
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
            try
            {
                UzuriSwimwearDBEntities dBEntities = new UzuriSwimwearDBEntities();
                var query = dBEntities.GetAllProductsDetails();
                return query;
            }
            catch(Exception e)
            {
                Response.Write(e.Message);
                return null;
            }
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
            using (var dbContext = new UzuriSwimwearDBEntities())
            {
                ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                dbContext.EditProduct(User.Identity.GetUserId(), name, desc, id, forSale, category, responseMessage);
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
                this.productID = Convert.ToInt32(e.CommandArgument);
                BindImageGridView();
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
        /// Method to add a product to the database
        /// </summary>
        protected void AddProductImage()
        {
            try
            {
                using (var dbContext = new UzuriSwimwearDBEntities())
                {
                    byte[] image = AddProdImage.FileBytes;
                    string imageName = AddProdImage.FileName;
                    ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                    dbContext.AddProductImage(User.Identity.GetUserId(), productID, image, imageName, false, responseMessage);                   
                    Response.Write(Convert.ToString(responseMessage.Value));
                }
            }
            catch(Exception e)
            {
                Response.Write("Method Exception: "+ e.InnerException.Message);
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to execute the edit, delete, cancel commands on the imagegridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImageGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //deleting
            if (e.CommandName.Equals("DeleteImage"))
            {
                int imageID = Convert.ToInt32(e.CommandArgument);
                this.DeleteImage(imageID);
                BindImageGridView(); //resetting gridview
            }
            if (e.CommandName.Equals("SetPrimary"))
            {
                int imageID = Convert.ToInt32(e.CommandArgument);
                this.SetPrimaryImage(imageID);
                BindImageGridView(); //resetting gridview
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to delete a product image
        /// </summary>
        protected void DeleteImage(int imageID)
        {
            try
            {
                //TODO get user role
                using (var dbContext = new UzuriSwimwearDBEntities())
                {
                    ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                    dbContext.DeleteProductImage(User.Identity.GetUserId(), imageID, responseMessage);
                    EditImageErrorLbl.Text = Convert.ToString(responseMessage.Value);
                }
            }
            catch (Exception e)
            {
                Response.Write("Method Exception: " + e.InnerException.Message);
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to delete a product image
        /// </summary>
        protected void SetPrimaryImage(int imageID)
        {
            try
            {
                using (var dbContext = new UzuriSwimwearDBEntities())
                {
                    ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                    if (this.productID != 0)
                    {
                        dbContext.SetProductPrimaryImage(User.Identity.GetUserId(), this.productID, imageID, responseMessage);
                        EditImageErrorLbl.Text = Convert.ToString(responseMessage.Value);
                    }
                    else
                    {
                        Response.Write("ID null");
                    }
                }
            }
            catch (Exception e)
            {
                Response.Write("Method Exception: " + e.InnerException.Message);
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

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// method to check 
        /// </summary>
        /// <returns></returns>
        protected bool UploadFileCheck()
        {
            bool isValid = false;
            switch (Path.GetExtension(AddProdImage.FileName.ToLower()))
            {
                case ".jpg":
                case ".png":
                case ".jpeg":
                case ".gif":
                case ".JPEG":
                case ".PNG":
                    isValid = true;
                    break;
                default:
                    isValid = false;
                    break;
            }
            return isValid;
        }

        
        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Button click to upload the image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UploadImageBtn_Click(object sender, EventArgs e)
        {
            //if file has valid extension
            if (UploadFileCheck())
            {
                try
                {
                    if(this.productID != 0)
                    {
                        AddProductImage();
                        BindImageGridView();
                    }
                    else
                    {
                        AddImageErrorLbl.Text = "No Product selected";
                    }
                }
                catch(Exception error)
                {
                    Response.Write(error.Message);
                }
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to validate the size of the product image
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void ProdImageSizeValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int mbs = 1024;
            int maxSize = 2;
            int size = AddProdImage.PostedFile.ContentLength;
            if (size < (mbs * maxSize))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        //--
    }
}
//---------------------------------------------end of page---------------------------------------------------