using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uzuri_Swimwear.Model;
using System.Data.Entity.Core.Objects;

namespace Uzuri_Swimwear.Forms
{
    public partial class HomeForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack) // loads content for home page by showing products
            {
                listViewHome.DataSource = GetProducts();
                listViewHome.DataBind(); // Will Bind when page is reload,,, place in method or Button
            }
        }
        public IEnumerable<GetProductsForSale_Result> GetProducts()
        {
            UzuriSwimwearDBEntities dBEntities = new UzuriSwimwearDBEntities();
            ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
            var query = dBEntities.GetProductsForSale(responseMessage);

            return query;
        }

        protected void listViewHome_ItemCommand(object sender, ListViewCommandEventArgs e)
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
    }
}