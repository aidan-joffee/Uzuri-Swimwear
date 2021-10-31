using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Uzuri_Swimwear.Forms
{
    public partial class UzuriSwimwear : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetActivePage();
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
    }
}
//-------------------------------------------------end of file-----------------------------------------------