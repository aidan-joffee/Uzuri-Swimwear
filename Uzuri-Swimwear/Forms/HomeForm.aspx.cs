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


        // Query to show all products for home page
        public IEnumerable<GetProductsForSale_Result> GetProducts()
        {
            UzuriSwimwearDBEntities dBEntities = new UzuriSwimwearDBEntities();
            ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
            var query = dBEntities.GetProductsForSale(responseMessage);

            return query;


        }

        //public IEnumerable<GetProductsForSale_Result> GetSearchProducts() //Query to show all products for home page
        //{
        //    UzuriSwimwearDBEntities dBEntities = new UzuriSwimwearDBEntities();
        //    ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
        //    var query = from n in NAME select GetAllProductsDetails;

        //    return query;


        //}


    }
}