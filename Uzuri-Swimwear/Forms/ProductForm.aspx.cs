using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Uzuri_Swimwear.Forms
{
    public partial class ProductForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Method to populate the product details list 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GetAllProductsDetails_Result> GetProducts()
        {
            UzuriSwimwearDBEntities dBEntities = new UzuriSwimwearDBEntities();
            var query = dBEntities.GetAllProductsDetails();
            return query;
        }

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

        //public IEnumerable<GetAllProductsDetails_Result> GetProduct()
        //{
        //    //GetAllProductsDetails_Result result = new GetAllProductsDetails_Result();

        //    //using(var context = new UzuriSwimwearDBEntities())
        //    //{
        //    //    context.GetAllProductsDetails(result);
        //    //}

        //    //return result;
        //}
    }
}