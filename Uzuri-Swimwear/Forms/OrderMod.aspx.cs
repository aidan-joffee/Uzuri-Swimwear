using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uzuri_Swimwear.Model;

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

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Stores the orderID in the viewstate for selecting orders
        /// </summary>
        public int orderID
        {
            get
            {
                //gets the productID from the viewstate
                int returnValue = 0;
                //checks if its null then gets it
                if (ViewState["orderID"] != null)
                    Int32.TryParse(ViewState["orderID"].ToString(), out returnValue);
                return returnValue;
            }
            set
            {
                ViewState["orderID"] = value;
            }
        }

        public string GetImage(object oItem)
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
        public IEnumerable<GetOrderProducts_Result> GetOrderProducts(string OrderID)
        {
            UzuriSwimwearDBEntities dBEntities = new UzuriSwimwearDBEntities();
            var query = dBEntities.GetOrderProducts(OrderID);
            return query;
        }

        public IEnumerable<GetOrderRequests_Result> GetOrderRequest(string OrderID)
        {
            UzuriSwimwearDBEntities dBEntities = new UzuriSwimwearDBEntities();
            var query = dBEntities.GetOrderRequests(OrderID);
            return query;
        }

        protected void placeOrder_Click(object sender, EventArgs e)
        {
            //checks the users address is input
            if (CheckAddress())
            {
                MakeOrder();
                SendOrderEmail();
                Response.Redirect("/Forms/OrderConfirmation.aspx");
            }
            else
            {
                Response.Write("Please ensure you have entered your address information on the profile screen, click on your name to view it");
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Send the order email
        /// </summary>
        /// <returns></returns>
        public void SendOrderEmail()
        {
            MailMessage msg = new MailMessage("uzuri@uzuriswimwear.co.za", User.Identity.Name);
            String message = String.Format(@"<html>
                                <body>
                                <h4>Please use the details below to pay for your order.</h4>
                                <p>Email: email@email.com</p>
                                <p>Name: Tebogo Lime</p>
                                <p>Account Number: 000000000000</p>
                                <p>Branch Code: 00000000</p>
                                <p>Reference no: {0}</p>
                                </body>
                                </html>", this.orderID);

            msg.Subject = "UzuriSwimwear - Order Placed!";
            msg.Body = message;
            msg.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();
            if (smtpClient != null)
            {
                smtpClient.Send(msg);
            }
            else
            {
                Response.Write("An error occured, email not sent");
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to make the order
        /// </summary>
        private void MakeOrder()
        {
            int orderOut = 0;
            decimal Hipline = 0;
            decimal Bustline = 0;
            decimal Waistline = 0;

            using (var dbContext = new UzuriSwimwearDBEntities())
            {
                try
                {

                    ObjectParameter orderID = new ObjectParameter("orderID", typeof(string));
                    var query2 = dbContext.placeOrder(User.Identity.GetUserId(), orderID);

                    string response = (orderID.Value).ToString();
                    Int32.TryParse(response, out orderOut);
                    this.orderID = orderOut;
                }
                catch(Exception e)
                {
                    Response.Write(e.Message);
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


                using (var dbContext = new UzuriSwimwearDBEntities())
                {
                    try
                    {

                        ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                        var query = dbContext.placeOrderItems(orderOut, ProductID, Hipline, Bustline, Waistline, true, responseMessage);

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

                    }
                    catch (Exception p)
                    {
                        Response.Write(p.Message);
                    }

                }
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Check if the user has input their address
        /// </summary>
        protected bool CheckAddress()
        {
            try
            {
                using (var dbContext = new UzuriSwimwearDBEntities())
                {
                    ObjectParameter doesExist = new ObjectParameter("doesExist", typeof(string));
                    var isValid = dbContext.CheckUserAddress(User.Identity.GetUserId(), doesExist);
                    int test = Convert.ToInt32(doesExist.Value.ToString());
                    if (test == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                return false;
            }
        }

        protected void checkOut_Click(object sender, EventArgs e)
        {
            //using (var dbContext = new UzuriSwimwearDBEntities())
            //{
            //    int sumTotalOut = 0;
            //    ObjectParameter sumTotal = new ObjectParameter("sumTotal", typeof(string));
            //    var query2 = dbContext.GetSumOfCart(User.Identity.GetUserId(), sumTotal);

            //    string response = (sumTotal.Value).ToString();
            //    Int32.TryParse(response, out sumTotalOut);

            //    Response.Write(sumTotalOut);

            //    Session["payment_amt"] = sumTotalOut;


            //}
            //Response.Redirect("Checkout/CheckoutStart.aspx");           
        }
        //--
    }
}