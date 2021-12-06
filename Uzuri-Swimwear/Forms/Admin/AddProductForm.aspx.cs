using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uzuri_Swimwear.Model;

/*
 * Author: Aidan Joffee
 */

namespace Uzuri_Swimwear.Forms
{
    public partial class AddProductForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

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
        /// Method to add a product
        /// </summary>
        protected void AddProduct()
        {
            String prodName = ProdName.Text;
            String prodDesc = ProdDesc.Text;
            int prodCategoryID = Convert.ToInt32(CategoryDropList.SelectedValue);
            int prodID = 0; //get from responseMessage

            //null checks
            if (!prodName.Equals("") ||
                !prodName.Equals("") ||
                prodCategoryID != 0)
            {
                try
                {
                    using (var dbContext = new UzuriSwimwearDBEntities())
                    {
                        ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                        var query = dbContext.AddProduct(User.Identity.GetUserId(), prodName, prodDesc, prodCategoryID, responseMessage);
                        //converting response to ID if possible
                        string response = (responseMessage.Value).ToString();
                        Int32.TryParse(response, out prodID);
                    }

                    //add images if product added was added with ID
                    if (prodID != 0)
                    {
                        AddProductImage(prodID);
                    }
                }
                catch(Exception e)
                {
                    Response.Write(e.Message);
                }
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to add an image to the product
        /// </summary>
        protected void AddProductImage(int productID)
        {
            try
            {
                using (var dbContext = new UzuriSwimwearDBEntities())
                {
                    ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                    int count = 0;
                    //TODO fix this user role
                    foreach (var file in AddProdImage.PostedFiles)
                    {
                        //data to add
                        var bytes = GetImageAsBytes(file.InputStream);
                        String fName = file.FileName;
                        bool isPrimary = false;
                        if (count == 0) isPrimary = true; //set first image as primary

                        //adding product image
                        dbContext.AddProductImage(User.Identity.GetUserId(), productID, bytes, fName, isPrimary, responseMessage);
                        count++;
                    }
                }
            }
            catch(Exception e)
            {
                Response.Write(e.Message);
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to get the image as bytes
        /// </summary>
        /// <returns></returns>
        private byte[] GetImageAsBytes(Stream file)
        {
            //reading file
            BinaryReader reader = new BinaryReader(file);
            var bytes = reader.ReadBytes((int)file.Length);
            return bytes;
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Button event to add a product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddProdBtn_Click(object sender, EventArgs e)
        {
            Page.Validate();
            //checks the entries are valid first
            if(Page.IsValid)
            {
                AddProduct();
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
            if(size < (mbs * maxSize))
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
//-------------------------------------------end of file-----------------------------------------------------