using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;
using Uzuri_Swimwear.Model;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;

namespace Uzuri_Swimwear.Forms
{
    public partial class ItemsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack) // loads content for home page by showing products
            {
                string id = Request.QueryString["id"];
                this.prodID = Convert.ToInt32(id);
                GetSingleProduct();

            }

        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Stores the orderID in the viewstate for selecting orders
        /// </summary>
        public int prodID
        {
            get
            {
                //gets the productID from the viewstate
                int returnValue = 0;
                //checks if its null then gets it
                if (ViewState["prodID"] != null)
                    Int32.TryParse(ViewState["prodID"].ToString(), out returnValue);
                return returnValue;
            }
            set
            {
                ViewState["prodID"] = value;
            }
        }

        private void GetSingleProduct()
        {
            using (var dbContext = new UzuriSwimwearDBEntities())
            {
                ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                var product = dbContext.GetSingleProduct(this.prodID, responseMessage);
                List<GetSingleProduct_Result> list = product.ToList();
                //loop through each image

                string name = list[0].NAME;
                ProductName.InnerText = name;
                string description = list[0].DESCRIPTION;
                ProductDescription.InnerText = description;

                Image[] images = { Image0, Image1, Image2 };

                for (int i = 0; i < list.Count; i++)
                {
                    byte[] image = list[i].IMAGE_DATA;
                    string imageUrl = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String((byte[])image));
                    images[i].ImageUrl = imageUrl;
                }

            }
        }

        protected void AddItemToCart()
        {
            try
            {
                using(var dbContext = new UzuriSwimwearDBEntities())
                {
                    ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                    dbContext.AddItemToCart(User.Identity.GetUserId(),this.prodID, true, responseMessage);
                    Response.Write(responseMessage.Value.ToString());
                }
            }
            catch(Exception e)
            {
                Response.Write(e.Message);
            }
        }

        /// <summary>
        /// AddToCart on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddToCartBtn_Click(object sender, EventArgs e)
        {
            AddItemToCart();
        }
    }
}