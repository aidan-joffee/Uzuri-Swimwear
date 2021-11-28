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
            int OrderID = 3;
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
            int userID = 1;
            int orderOut = 0;
            decimal Hipline = 0;
            decimal Bustline = 0;
            decimal Waistline = 0;
            using (var dbContext = new UzuriSwimwearDBEntities())
            {
                try
                {

                    ObjectParameter orderID = new ObjectParameter("orderID", typeof(string));
                    var query2 = dbContext.placeOrder(userID, orderID);

                    string response = (orderID.Value).ToString();
                    Int32.TryParse(response, out orderOut);
                }
                catch
                {

                }
             }

            int rows = orderGridView.Rows.Count;
           
            for (int i = 0; i < rows; i++)
            {

                Label box0 = (Label)orderGridView.Rows[i].Cells[0].FindControl("productID");
                int ProductID = Convert.ToInt32(box0.Text);

                TextBox box1 = (TextBox)orderGridView.Rows[i].Cells[3].FindControl("bustLine");
                Hipline = Convert.ToDecimal(box1.Text);

                TextBox box2 = (TextBox)orderGridView.Rows[i].Cells[4].FindControl("waistLine");
                Bustline = Convert.ToDecimal(box2.Text);

                TextBox box3 = (TextBox)orderGridView.Rows[i].Cells[5].FindControl("hipLine");
                Waistline = Convert.ToDecimal(box3.Text);

                Response.Write(box0);

                using (var dbContext = new UzuriSwimwearDBEntities())
                {
                    try
                    {

                        ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                        var query = dbContext.placeOrderProducts(orderOut, ProductID, Hipline, Bustline, Waistline, responseMessage);

                        Response.Write(Hipline);
                        Response.Write(responseMessage.Value);
                    }
                    catch (Exception p)
                    {
                        Response.Write(p.Message);
                    }

                }
            }
        }
    }
}