using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uzuri_Swimwear.Model;

namespace Uzuri_Swimwear.Forms.Account
{
    public partial class ResetPassword : Page
    {
        protected string StatusMessage
        {
            get;
            private set;
        }


        protected async void ResetPass()
        {
            string code = IdentityHelper.GetCodeFromRequest(Request);
            if (code != null)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

                var user = await manager.FindByNameAsync(emailBox.Text);
                if (user == null)
                {
                ErrorMessage.Text = "No user found";
                    return;
                }
                var result = manager.ResetPassword(user.Id, code, passBox.Text);
                if (result.Succeeded)
                {
                    Response.Redirect("/Forms/Account/ResetConfirmation.aspx");
                    return;
                }
                ErrorMessage.Text = result.Errors.FirstOrDefault();
                return;
            }
            ErrorMessage.Text = "An error has occurred";
        }

        protected void ResetPassBtn_Click(object sender, EventArgs e)
        {
            ResetPass();
        }
    }
}