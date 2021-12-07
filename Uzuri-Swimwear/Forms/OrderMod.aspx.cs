using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uzuri_Swimwear.Model;
using Microsoft.AspNet.Identity;

namespace Uzuri_Swimwear.Forms
{
    public partial class OrderMod : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                orderProduct_GridView();
                orderReq_GridView();
            }

        }
        protected string GetImage(object oItem)
        {
            // read the data from database
            var cImgSrc = DataBinder.Eval(oItem, "IMAGE_DATA") as byte[];


            // if we do not have any image, return some default.
            if (cImgSrc == null)
            {
                return "/Images/uzuri-logo-transparent-small.png";
            }
            else
            {
                //Response.Write(Convert.ToBase64String((byte[])cImgSrc));
                // format and render back the image
                return String.Format("data:image/jpg;base64,{0}",
                        Convert.ToBase64String((byte[])cImgSrc));
            }

        }

        private void orderProduct_GridView()
        {
            productGridView.DataSource = GetOrderProducts(User.Identity.GetUserId());
            productGridView.DataBind();
        }

        private void orderReq_GridView()
        {
            requestGridView.DataSource = GetOrderRequest(User.Identity.GetUserId());
            requestGridView.DataBind();
        }
        public IEnumerable<GetOrderProducts_Result> GetOrderProducts(string OrderID) //Getting order products from DB
        {
            UzuriSwimwearDBEntities dBEntities = new UzuriSwimwearDBEntities();
            var query = dBEntities.GetOrderProducts(OrderID);
            return query;
        }

        public IEnumerable<GetOrderRequests_Result> GetOrderRequest(string OrderID)//Getting order requests from DB
        {
            UzuriSwimwearDBEntities dBEntities = new UzuriSwimwearDBEntities();
            var query = dBEntities.GetOrderRequests(OrderID);
            return query;
        }

        protected void placeOrder_Click(object sender, EventArgs e)
        {

            int orderOut = 0; //Initiating vlaues
            decimal Hipline = 0;
            decimal Bustline = 0;
            decimal Waistline = 0;

            using (var dbContext = new UzuriSwimwearDBEntities())
            {
                try
                {

                    ObjectParameter orderID = new ObjectParameter("orderID", typeof(string));
                    var query2 = dbContext.placeOrder(User.Identity.GetUserId(), orderID); //Getting user ID

                    string response = (orderID.Value).ToString();
                    Int32.TryParse(response, out orderOut);
                }
                catch
                {

                }
            }

            int rows = productGridView.Rows.Count; //Counting Amount of rows in girdview for products 

            for (int i = 0; i < rows; i++) //looping through number of rows
            {

                Label box0 = (Label)productGridView.Rows[i].Cells[0].FindControl("productID");//finding gridview value
                int ProductID = Convert.ToInt32(box0.Text);

                TextBox box1 = (TextBox)productGridView.Rows[i].Cells[3].FindControl("bustLine");//finding gridview value
                Hipline = Convert.ToDecimal(box1.Text);

                TextBox box2 = (TextBox)productGridView.Rows[i].Cells[4].FindControl("waistLine");//finding gridview value
                Bustline = Convert.ToDecimal(box2.Text);

                TextBox box3 = (TextBox)productGridView.Rows[i].Cells[5].FindControl("hipLine");//finding gridview value
                Waistline = Convert.ToDecimal(box3.Text);


                using (var dbContext = new UzuriSwimwearDBEntities())
                {
                    try
                    {

                        ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                        var query = dbContext.placeOrderItems(orderOut, ProductID, Hipline, Bustline, Waistline, true, responseMessage);//adding values from gridview to DB 

                    }
                    catch (Exception p)
                    {
                        Response.Write(p.Message);
                    }

                }
            }


            int reqRows = requestGridView.Rows.Count; //Counting Amount of rows in girdview for requests 

            for (int r = 0; r < reqRows; r++)
            {

                Label reqbox0 = (Label)requestGridView.Rows[r].Cells[0].FindControl("custReqID");//finding gridview value
                int Cust_Req_ID = Convert.ToInt32(reqbox0.Text);

                TextBox reqbox1 = (TextBox)requestGridView.Rows[r].Cells[3].FindControl("bustLine");//finding gridview value
                Hipline = Convert.ToDecimal(reqbox1.Text);

                TextBox reqbox2 = (TextBox)requestGridView.Rows[r].Cells[4].FindControl("waistLine");//finding gridview value
                Bustline = Convert.ToDecimal(reqbox2.Text);

                TextBox reqbox3 = (TextBox)requestGridView.Rows[r].Cells[5].FindControl("hipLine");//finding gridview value
                Waistline = Convert.ToDecimal(reqbox3.Text);


                using (var dbContext = new UzuriSwimwearDBEntities())
                {
                    try
                    {

                        ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                        var query = dbContext.placeOrderItems(orderOut, Cust_Req_ID, Hipline, Bustline, Waistline, false, responseMessage);//adding values from gridview to DB 

                    }
                    catch (Exception p)
                    {
                        Response.Write(p.Message);
                    }

                }
            }

        }

        protected void checkOut_Click(object sender, EventArgs e)
        {
            using (var dbContext = new UzuriSwimwearDBEntities())
            {
                int sumTotalOut = 0;
                ObjectParameter sumTotal = new ObjectParameter("sumTotal", typeof(string));
                var query2 = dbContext.GetSumOfCart(User.Identity.GetUserId(), sumTotal);

                string response = (sumTotal.Value).ToString();
                Int32.TryParse(response, out sumTotalOut);

               Response.Write(sumTotalOut);

              Session["payment_amt"] = sumTotalOut;

        
            }
            Response.Redirect("Checkout/CheckoutStart.aspx");

        }
    }
}