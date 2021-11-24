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

        }

        public void CreateUser()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = Context.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            var user = new ApplicationUser() { UserName = EmailBox.Text, Email = EmailBox.Text, FirstName = txtFirstName.Text, LastName = txtLastName.Text };

            try
            {
                IdentityResult result = manager.Create(user, Password.Text);

                if (result.Succeeded)
                {
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
                    StatusMessage.Text = string.Format("User {0} was created successfully!", user.UserName);
                }
                else
                {
                    StatusMessage.Text = result.Errors.FirstOrDefault();
                }
            }
            catch (Exception E)
            {
                StatusMessage.Text = E.InnerException.Message;
            }
        }
    }
}