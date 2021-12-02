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
                int prodId = Convert.ToInt32(id);
                GetSingleProduct(prodId);

            }

        }

        public IEnumerable<GetSingleProduct_Result> GetCartItems()
        {
            string id = Request.QueryString["id"];
            UzuriSwimwearDBEntities dBEntities = new UzuriSwimwearDBEntities();
            ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
            var query = dBEntities.GetSingleProduct(Convert.ToInt32(id), responseMessage);

            return query;
        }

        protected void listViewItems_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (e.CommandName == "AddToCart")
                {
                    int RowId = Convert.ToInt32(e.CommandArgument);

                    using (var context = new UzuriSwimwearDBEntities())
                    {
                        ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                        context.AddItemToCart(User.Identity.GetUserId(), RowId, true, responseMessage);
                        Response.Write(responseMessage.Value.ToString());
                    }

                }

            }
            else
            {
                Response.Write("<script>alert('Login to add item to cart')</script>");
            }

        }


        private void GetSingleProduct(int prodID)
        {
            using (var dbContext = new UzuriSwimwearDBEntities())
            {
                ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                var product = dbContext.GetSingleProduct(prodID, responseMessage);
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
    }
}