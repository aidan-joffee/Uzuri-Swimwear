using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity.Owin;
using Uzuri_Swimwear.Model;

namespace Uzuri_Swimwear.Forms.Login
{
    public partial class RegisterForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = new ApplicationUser() { UserName = EmailBox.Text, Email = EmailBox.Text };

            try
            {
                IdentityResult result = manager.Create(user, Password.Text);

                if (result.Succeeded)
                {
                    StatusMessage.Text = string.Format("User {0} was created successfully!", user.UserName);
                }
                else
                {
                    StatusMessage.Text = result.Errors.FirstOrDefault();
                }
            }
            catch(Exception E)
            {
                StatusMessage.Text = E.InnerException.InnerException.Message;
            }
        }
    }
}