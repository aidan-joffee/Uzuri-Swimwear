using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uzuri_Swimwear.Model;

namespace Uzuri_Swimwear.Forms
{
    public partial class OrderConfirmation : System.Web.UI.Page
    {
        private PayGate payGate = new PayGate();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StorePurchaseInfo();
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to retrieve and store the purchase information from the request
        /// </summary>
        protected void StorePurchaseInfo()
        {

            string response = Request.Params.ToString(); //getting the parametres 
            Dictionary<string, string> results = payGate.toDictionary(response); //turn into dictionary
            //TODO get order ID
            try
            {
                int paymentStatus = Convert.ToInt32(results["TRANSACTION_STATUS"]);
                if (paymentStatus == 1)
                {
                    SuccessMessage.Visible = true;
                }
                else
                {
                    ErrorMessage.Visible = true;
                }
                //getting the reference ID, aka order ID
                int orderID = payGate.GetOrder(results["PAY_REQUEST_ID"]);
                QueryTransactionInfo(results, orderID);
            }
            catch
            {
                ErrorMessage.Visible = true;
            }

        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// method to query paygate API and get mroe information back
        /// </summary>
        /// <param name="results"></param>
        /// <param name="orderID"></param>
        protected async void QueryTransactionInfo(Dictionary<string, string> response, int orderID)
        {
            HttpClient client = new HttpClient();
            Dictionary<string, string> request = new Dictionary<string, string>();

            request.Add("PAYGATE_ID", payGate.PayGateID);
            request.Add("PAY_REQUEST_ID", response["PAY_REQUEST_ID"]);
            request.Add("REFERENCE", orderID.ToString());
            request.Add("CHECKSUM", payGate.GetMd5Hash(request, payGate.PayGateKey));

            string requestString = payGate.ToUrlEncodedString(request);

            StringContent content = new StringContent(requestString, Encoding.UTF8, "application/x-www-form-urlencoded");

            //API call, 
            HttpResponseMessage res = await client.PostAsync(payGate.UrlQuery, content);
            res.EnsureSuccessStatusCode();

            string _responseContent = await res.Content.ReadAsStringAsync();

            Dictionary<string, string> results = payGate.toDictionary(_responseContent);
            if (!results.Keys.Contains("ERROR"))
            {
                payGate.UpdateTransaction(results, results["PAY_REQUEST_ID"]);
            }
            else
            {
                //display the error
                SuccessMessage.Visible = false;
                ErrorMessage.Visible = true;
                ErrorMsgLbl.Text = results["ERROR"];
            }
        }
        //--
    }
}