using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uzuri_Swimwear.Forms.Logic;

namespace Uzuri_Swimwear.Forms.Checkout
{
    public partial class CheckoutReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NVPAPICaller payPalCaller = new NVPAPICaller();

                string retMsg = "";
                string token = "A21AAL7HTJekOSb45vaBdUOu_J-Qwflff_e53GVCO7YYCVjmEM2TIdeazgmYlv0ygn0HDWQJ3LrZh61XR5eJx9suUsvbjdemA";
                string PayerID = "";
                NVPCodec decoder = new NVPCodec();
               // token = Session["token"].ToString();

                bool ret = payPalCaller.GetCheckoutDetails(token, ref PayerID, ref decoder, ref retMsg);
                if (ret)
                {
                    Session["payerId"] = PayerID;

                    
                    DateTime OrderDate = Convert.ToDateTime(decoder["TIMESTAMP"].ToString());
                    string Username = User.Identity.Name;
                    string FirstName = decoder["FIRSTNAME"].ToString();
                    string LastName = decoder["LASTNAME"].ToString();
                    string Address = decoder["SHIPTOSTREET"].ToString();
                    string City = decoder["SHIPTOCITY"].ToString();
                    string State = decoder["SHIPTOSTATE"].ToString();
                    string PostalCode = decoder["SHIPTOZIP"].ToString();
                    string Country = decoder["SHIPTOCOUNTRYCODE"].ToString();
                    string Email = decoder["EMAIL"].ToString();
                    decimal Total = Convert.ToDecimal(decoder["AMT"].ToString());

                    // Verify total payment amount as set on CheckoutStart.aspx.
                    try
                    {
                        decimal paymentAmountOnCheckout = Convert.ToDecimal(Session["payment_amt"].ToString());
                        decimal paymentAmoutFromPayPal = Convert.ToDecimal(decoder["AMT"].ToString());
                        if (paymentAmountOnCheckout != paymentAmoutFromPayPal)
                        {
                            Response.Redirect("CheckoutError.aspx?" + "Desc=Amount%20total%20mismatch.");
                        }
                    }
                    catch (Exception)
                    {
                        Response.Redirect("CheckoutError.aspx?" + "Desc=Amount%20total%20mismatch.");
                    }

                }
                else
                {
                    Response.Redirect("CheckoutError.aspx?" + retMsg);
                }
            }
        }

        protected void CheckoutConfirm_Click(object sender, EventArgs e)
        {
            Session["userCheckoutCompleted"] = "true";
            Response.Redirect("~/Checkout/CheckoutComplete.aspx");
        }
    }
}