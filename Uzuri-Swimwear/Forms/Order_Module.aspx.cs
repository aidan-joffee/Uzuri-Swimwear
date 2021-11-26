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
    public partial class Order_Module : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                order_GridView();
            }

        }
        private void order_GridView()
        {
            int OrderID = 1;
            orderGridView.DataSource = GetProducts(OrderID);
            orderGridView.DataBind();
        }

        public IEnumerable<GetOrder_Result> GetProducts(int OrderID)
        {
            UzuriSwimwearDBEntities dBEntities = new UzuriSwimwearDBEntities();
            var query = dBEntities.GetOrder(OrderID);
            return query;
        }

        public void getOrders()
        {

        }

        protected void placeOrder_Click(object sender, EventArgs e)
        {
            TextBox box0 = (TextBox)orderGridView.Rows[0].Cells[0].FindControl("productID");
            int ProductID = Convert.ToInt32(2);


            TextBox box1 = (TextBox)orderGridView.Rows[0].Cells[3].FindControl("bustLine");
            decimal Hipline = Convert.ToDecimal(box1.Text);

            TextBox box2 = (TextBox)orderGridView.Rows[0].Cells[4].FindControl("waistLine");
            decimal Bustline = Convert.ToDecimal(box2.Text);

            TextBox box3 = (TextBox)orderGridView.Rows[0].Cells[5].FindControl("hipLine");
            decimal Waistline = Convert.ToDecimal(box3.Text);

            Response.Write(box0);
            int userID = 1;
            int orderOut;
            using (var dbContext = new UzuriSwimwearDBEntities())
            {
                try
                {
                    
                    ObjectParameter orderID = new ObjectParameter("orderID", typeof(string));
                    var query2 = dbContext.placeOrder(userID,orderID);

                    string response = (orderID.Value).ToString();
                    Int32.TryParse(response, out orderOut);

                    ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                    var query = dbContext.placeOrderProducts(orderOut, ProductID, Hipline, Bustline, Waistline, responseMessage);

                    Response.Write(Hipline);
                    Response.Write(responseMessage.Value);
                }
                catch(Exception p)
                {
                    Response.Write(p.Message);
                }
     
            }
        }
    }
}