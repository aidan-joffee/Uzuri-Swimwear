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
        /// Method to ensure between 1-3 images are selected
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void ImageUploadCountValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //makes sure atleast 1 image is selected and no more than 3
            if((AddProdImage.PostedFiles.Count > 3)
                ||(AddProdImage.PostedFiles.Count < 1))
            {
                args.IsValid = false;
            }
            else
            {
                //checks extension of each product to ensure its an image
                foreach(var file in AddProdImage.PostedFiles)
                {
                    String fName = file.FileName;
                    String fExt = Path.GetExtension(fName);
                    if (fExt == ".jpg" || fExt == ".png" || fExt == ".gif" || fExt == ".bmp" || fExt == ".JPG" || fExt == ".PNG" || fExt == ".jpeg")
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }
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
            //TODO fix this
            int userRole = 1;
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
                        var query = dbContext.AddProduct(userRole, prodName, prodDesc, prodCategoryID, responseMessage);
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
                    int userRole = 1;
                    foreach (var file in AddProdImage.PostedFiles)
                    {
                        //data to add
                        var bytes = GetImageAsBytes(file.InputStream);
                        String fName = file.FileName;
                        bool isPrimary = false;
                        if (count == 0) isPrimary = true; //set first image as primary

                        //adding product image
                        dbContext.AddProductImage(userRole, productID, bytes, fName, isPrimary, responseMessage);
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
        //--
    }
}
//-------------------------------------------end of file-----------------------------------------------------