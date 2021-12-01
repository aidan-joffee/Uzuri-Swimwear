using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uzuri_Swimwear.Model;

/*
 * Author: Aidan Joffee
 */


namespace Uzuri_Swimwear.Forms
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    //show logout form if logged in
                    LoginInputForm.Visible = false;
                    LogoutForm.Visible = true;
                }
                else
                {
                    //show login form if not
                    LoginInputForm.Visible = true;
                    LogoutForm.Visible = false;
                }
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to sign the user in
        /// </summary>
        protected async void SignInUser()
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
                var user = await manager.FindByNameAsync(Email.Text);
                if(user != null)
                {
                    if (!user.EmailConfirmed)
                    {
                        FailureText.Text = "Invalid login attempt. You need to confirm your email.";
                        ErrorMessage.Visible = true;
                        ResendConfirm.Visible = true;
                    }
                    else
                    {
                        var result = await signinManager.PasswordSignInAsync(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: true);
                        switch (result)
                        {
                            case SignInStatus.Success:
                                Response.Redirect("/Forms/HomeForm.aspx");
                                break;
                            case SignInStatus.LockedOut:
                                //TODO create these pages redirect to lockout
                                Response.Redirect("/Forms/LockedForm.aspx");
                                break;
                            case SignInStatus.RequiresVerification:
                                //TODO create these pages to require verification if necessary?
                                break;
                            case SignInStatus.Failure:
                            default:
                                FailureText.Text = "Invalid login attempt";
                                ErrorMessage.Visible = true;
                                break;
                        }
                    }
                }
                else
                {
                    FailureText.Text = "Invalid login attempt";
                    ErrorMessage.Visible = true;
                }
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to sign the user out
        /// </summary>
        protected void SignOutUser()
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("/Forms/Account/LoginForm.aspx");
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to resend the confirmation email
        /// </summary>
        private async void ResendEmailConfirm()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = await manager.FindByNameAsync(Email.Text);
            if (user != null)
            {
                if (!user.EmailConfirmed)
                {
                    string code = await manager.GenerateEmailConfirmationTokenAsync(user.Id);
                    string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                    await manager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                    FailureText.Text = "Confirmation email sent. Please view the email and confirm your account.";
                    ErrorMessage.Visible = true;
                    ResendConfirm.Visible = false;
                }
            }
        }

        //------------------------------------------------------------------------------------------------
        //button clicks
        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            SignOutUser();           
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {       
            SignInUser();
        }

        protected void ToRegisterFormBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Forms/Account/RegisterForm.aspx");
        }

        protected void SendEmailConfirmationToken(object sender, EventArgs e)
        {
            ResendEmailConfirm();
        }        
    }
}