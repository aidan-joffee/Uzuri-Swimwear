using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uzuri_Swimwear.Model;

namespace Uzuri_Swimwear.Forms
{
    public partial class RegisterForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    //if user is already logged in, show logout form and hide register form
                    LogoutForm.Visible = true;
                    //RegisterInputForm.Visible = false;
                }
                else
                {
                    LogoutForm.Visible = false;
                    //RegisterInputForm.Visible = true;
                }
            }
        }

        /// <summary>
        /// Method to create a user
        /// </summary>
        public async void CreateUser()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = Context.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text, FirstName = FirstName.Text, LastName = LastName.Text };

            try
            {
                IdentityResult result = await manager.CreateAsync(user, Password.Text);

                if (result.Succeeded)
                {
                    //TODO remove once live
                    if (!roleManager.RoleExists("Admin"))
                    {

                        var adminUser = new ApplicationUser() { UserName = "admin@uzuri.swimwear", Email = "admin@uzuri.swimwear", FirstName = "Admin", LastName = "Uzuri" };
                        IdentityResult adminResult = manager.Create(adminUser, "NzDvPdCRvtYY3AxE");
                        if (adminResult.Succeeded)
                        {
                            var adminRole = new IdentityRole();
                            adminRole.Name = "Admin";
                            roleManager.Create(adminRole);
                            manager.AddToRole(adminUser.Id, "Admin");
                        }
                    }

                    //create role if it doesnt exist
                    if (!roleManager.RoleExists("General"))
                    {
                        var role = new IdentityRole();
                        role.Name = "General";
                        roleManager.Create(role);
                    }
                    manager.AddToRole(user.Id, "General");
                    //redirect to login form
                    Response.Redirect("/Forms/Account/LoginForm.aspx");
                }
                else
                {
                    FailureText.Text = result.Errors.FirstOrDefault();
                    ErrorMessage.Visible = true;
                }
            }
            catch (Exception E)
            {
                FailureText.Text = E.Message;
                ErrorMessage.Visible = true;
            }
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            CreateUser();
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {

        }
    }
}