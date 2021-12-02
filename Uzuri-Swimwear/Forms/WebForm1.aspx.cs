using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Uzuri_Swimwear.Forms
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                orderProduct_GridView();
                orderReq_GridView();
            }

        }
        private void orderProduct_GridView()
        {
            int userID = 1;
            productGridView.DataSource = GetOrderProducts(userID);
            productGridView.DataBind();
        }

        private void orderReq_GridView()
        {
            int userID = 1;
            requestGridView.DataSource = GetOrderRequest(userID);
            requestGridView.DataBind();
        }
        public IEnumerable<GetOrderProducts_Result> GetOrderProducts(int OrderID)
        {
            UzuriSwimwearDBEntities dBEntities = new UzuriSwimwearDBEntities();
            var query = dBEntities.GetOrderProducts(OrderID);
            return query;
        }

        public IEnumerable<GetOrderRequests_Result> GetOrderRequest(int OrderID)
        {
            UzuriSwimwearDBEntities dBEntities = new UzuriSwimwearDBEntities();
            var query = dBEntities.GetOrderRequests(OrderID);
            return query;
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

            int rows = productGridView.Rows.Count;

            for (int i = 0; i < rows; i++)
            {

                Label box0 = (Label)productGridView.Rows[i].Cells[0].FindControl("productID");
                int ProductID = Convert.ToInt32(box0.Text);

                TextBox box1 = (TextBox)productGridView.Rows[i].Cells[3].FindControl("bustLine");
                Hipline = Convert.ToDecimal(box1.Text);

                TextBox box2 = (TextBox)productGridView.Rows[i].Cells[4].FindControl("waistLine");
                Bustline = Convert.ToDecimal(box2.Text);

                TextBox box3 = (TextBox)productGridView.Rows[i].Cells[5].FindControl("hipLine");
                Waistline = Convert.ToDecimal(box3.Text);

                Response.Write(box0);

                using (var dbContext = new UzuriSwimwearDBEntities())
                {
                    try
                    {

                        ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                        var query = dbContext.placeOrderItems(orderOut, ProductID, Hipline, Bustline, Waistline, true, responseMessage);

                        Response.Write(Hipline);
                        Response.Write(responseMessage.Value);
                    }
                    catch (Exception p)
                    {
                        Response.Write(p.Message);
                    }

                }
            }


            int reqRows = requestGridView.Rows.Count;

            for (int r = 0; r < reqRows; r++)
            {

                Label reqbox0 = (Label)requestGridView.Rows[r].Cells[0].FindControl("custReqID");
                int Cust_Req_ID = Convert.ToInt32(reqbox0.Text);

                TextBox reqbox1 = (TextBox)requestGridView.Rows[r].Cells[3].FindControl("bustLine");
                Hipline = Convert.ToDecimal(reqbox1.Text);

                TextBox reqbox2 = (TextBox)requestGridView.Rows[r].Cells[4].FindControl("waistLine");
                Bustline = Convert.ToDecimal(reqbox2.Text);

                TextBox reqbox3 = (TextBox)requestGridView.Rows[r].Cells[5].FindControl("hipLine");
                Waistline = Convert.ToDecimal(reqbox3.Text);


                using (var dbContext = new UzuriSwimwearDBEntities())
                {
                    try
                    {

                        ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                        var query = dbContext.placeOrderItems(orderOut, Cust_Req_ID, Hipline, Bustline, Waistline, false, responseMessage);

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