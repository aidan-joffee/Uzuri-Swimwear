using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uzuri_Swimwear.Model;

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
            if (e.CommandName == "RedirectItemsPage")
            {
                int RowId = Convert.ToInt32(e.CommandArgument);

                Response.Redirect("/Forms/ItemsPage.aspx?id=" + RowId);
            }

            if (User.Identity.IsAuthenticated)
            {
                if (e.CommandName == "AddToCart")
                {
                    int RowId = Convert.ToInt32(e.CommandArgument);

                    using (var context = new UzuriSwimwearDBEntities())
                    {
                        ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                        context.AddItemToCart(User.Identity.GetUserId(), RowId, true, responseMessage);
                        confirmed.Text = responseMessage.Value.ToString();
                    }

                }
            }
            else
            {
                confirmed.Text = "You need to login to add to cart";
            }
        }

    }
}