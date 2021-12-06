using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uzuri_Swimwear.Model;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace Uzuri_Swimwear.Forms
{
    public partial class UzuriSwimwear : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SetActivePage();
                if(HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    personalReqLink.Visible = true;
                    orderHistoryLink.Visible = true;
                    //if logged in
                    if (HttpContext.Current.User.IsInRole("Admin"))
                    {
                        productLink.Visible = true;
                        viewUersLink.Visible = true;
                    }
                }
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to set the active page for the navigation bar
        /// Author: Aidan Joffee
        /// </summary>
        protected void SetActivePage()
        {
            String pageURL = Request.Url.Segments[Request.Url.Segments.Length - 1];
            switch (pageURL)
            {
                case "Default":
                case "HomeForm.aspx":
                    homeLink.Attributes.Add("class", "nav-link active");
                    break;
                case "ProfileForm.aspx":
                    homeLink.Attributes.Remove("active");
                    break;
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}
//-------------------------------------------------end of file-----------------------------------------------