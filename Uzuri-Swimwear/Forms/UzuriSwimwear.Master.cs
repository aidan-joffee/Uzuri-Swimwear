using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uzuri_Swimwear.Model;
using Microsoft.AspNet.Identity.Owin;

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
                    //if logged in
                    registerLink.Visible = false;
                    loginLink.Visible = false;
                    SignOutBtn.Visible = true;
                }
                else
                {
                    //if not logged in
                    registerLink.Visible = true;
                    loginLink.Visible = true;
                    SignOutBtn.Visible = false;

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
                    profileLink.Attributes.Remove("active");
                    homeLink.Attributes.Add("class", "nav-link active");
                    break;
                case "ProfileForm.aspx":
                    homeLink.Attributes.Remove("active");
                    profileLink.Attributes.Add("class", "nav-link active");
                    break;
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to signout the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SignOutBtn_Click(object sender, EventArgs e)
        {
            if(HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                authenticationManager.SignOut();
                Response.Redirect("/Forms/HomeForm.aspx");
            }
        }
    }
}
//-------------------------------------------------end of file-----------------------------------------------