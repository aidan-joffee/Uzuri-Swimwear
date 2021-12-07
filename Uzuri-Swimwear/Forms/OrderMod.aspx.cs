using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
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
                MakeOrder(); //create the order
                GetRequest(); //get the address
                //SendOrderEmail(); //email owner about the new order
            }
            else
            {
                responseLbl.Text = "Please ensure you have entered your address information on the profile screen, click on your name to view it";
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Send the order email to the owner that a new order has been created
        /// </summary>
        /// <returns></returns>
        public void SendOrderEmail()
        {
            MailMessage msg = new MailMessage("uzuriswimwear@gmail.com", ""); //todo put owners email
            String message = String.Format(@"A new order has been placed. Order ID: {0}", this.orderID);

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
        /// Method to get the total from the cart for paygate
        /// </summary>
        /// <returns></returns>
        public decimal GetTotal()
        {
            decimal total = 0;
            try
            {
                using (var dbContext = new UzuriSwimwearDBEntities())
                {
                    ObjectParameter sumtotal = new ObjectParameter("SumTotal", typeof(decimal));
                    dbContext.GetSumOfCart(User.Identity.GetUserId(), sumtotal);
                    total = Convert.ToDecimal(sumtotal.Value);
                    return total;
                }
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                return total;
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Innitiate paygate request, this calls payfast and returns data necessary for the transaction
        /// </summary>
        /// <returns></returns>
        protected async void GetRequest()
        {
            PayGate payGate = new PayGate();

            ///the request
            HttpClient http = new HttpClient();

            //getting total price
            decimal total = GetTotal();
            int cents = Convert.ToInt32(total * 100);
            string paymentAmount = cents.ToString(); // amount int cents e.i 50 rands is 5000 cents

            Dictionary<string, string> request = new Dictionary<string, string>();

            request.Add("PAYGATE_ID", payGate.PayGateID);
            request.Add("REFERENCE", this.orderID.ToString());
            request.Add("AMOUNT", paymentAmount);
            request.Add("CURRENCY", "ZAR"); // South Africa
            request.Add("RETURN_URL", "https://uzuriswimwear.co.za/Forms/OrderConfirmation.aspx");
            request.Add("TRANSACTION_DATE", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            request.Add("LOCALE", "en-za");
            request.Add("COUNTRY", "ZAF");
            request.Add("EMAIL", User.Identity.Name);
            request.Add("CHECKSUM", payGate.GetMd5Hash(request, payGate.PayGateKey));

            string requestString = payGate.ToUrlEncodedString(request);
            StringContent content = new StringContent(requestString, Encoding.UTF8, "application/x-www-form-urlencoded");
            HttpResponseMessage response = await http.PostAsync(payGate.UrlInitiate, content);

            //response
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            Dictionary<string, string> results = payGate.toDictionary(responseContent);

            //checkign for errors
            if (results.Keys.Contains("ERROR"))
            {
                //error occured
                responseLbl.Text = results["ERROR"];
            }
            else if (!payGate.VerifyMd5Hash(results, payGate.PayGateKey, results["CHECKSUM"]))
            {
                //MD5 validaiton error
                responseLbl.Text = "MD5 validation error";
            }
            else
            {
                //adding transaction to database
                await payGate.AddTransaction(results, total, results["PAY_REQUEST_ID"]);
                //redirecting to paypal to finalize
                RedirectToPayGate(results);
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to redirect to paygate upon successful get
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        protected void RedirectToPayGate(Dictionary<string, string> results)
        {
            PayGate payGate = new PayGate();
            Response.Clear();

            StringBuilder sb = new StringBuilder();
            //redirects to paygate with the response variables from initial call
            sb.Append("<html>");
            sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
            sb.AppendFormat("<form name='form' action='{0}' method='post'>", payGate.UrlRedirect);
            sb.AppendFormat("<input type='hidden' name='PAY_REQUEST_ID' value='{0}'>", results["PAY_REQUEST_ID"]);
            sb.AppendFormat("<input type='hidden' name='CHECKSUM' value='{0}'>", results["CHECKSUM"]);
            sb.Append("</form>");
            sb.Append("</body>");
            sb.Append("</html>");
            Response.Write(sb.ToString());
            Response.End();
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
                    var query2 = dbContext.placeOrder(User.Identity.GetUserId(), orderID); //Getting user ID

                    string response = (orderID.Value).ToString();
                    Int32.TryParse(response, out orderOut);
                    this.orderID = orderOut;
                }
                catch(Exception e)
                {
                    Response.Write(e.Message);
                }
            }

            int rows = productGridView.Rows.Count; //Counting Amount of rows in girdview for products 

            for (int i = 0; i < rows; i++)
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
    }
}
//--------------------------------------------------End OF File----------------------------------------------------