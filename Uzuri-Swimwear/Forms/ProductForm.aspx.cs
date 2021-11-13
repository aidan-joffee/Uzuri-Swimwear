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

        public IQueryable<PRODUCT> GetProducts()
        {
            UzuriSwimwearDBEntities dBEntities = new UzuriSwimwearDBEntities();
            var query = dBEntities.PRODUCTs;
            return query;
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