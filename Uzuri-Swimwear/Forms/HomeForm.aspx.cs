using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Uzuri_Swimwear.Forms
{
    public partial class HomeForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var userID = User.Identity.GetUserId();
                UserIDLbl.Text = userID;
            }
        }
    }
}