using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uzuri_Swimwear.Model;

namespace Uzuri_Swimwear.Forms
{
    public partial class Order_Status : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                orderStatus_GridView();

            }

        }

        private void orderStatus_GridView()
        {
            int userID = 1;
            orderStatusGridView.DataSource = GetOrderStatus(userID);
            orderStatusGridView.DataBind();
        }


        public IEnumerable<_Result> GetOrderStatus(int OrderID)
        {
            UzuriSwimwearDBEntities dBEntities = new UzuriSwimwearDBEntities();
            var query = dBEntities.GetOrderProducts(OrderID);
            return query;
        }
    }
}