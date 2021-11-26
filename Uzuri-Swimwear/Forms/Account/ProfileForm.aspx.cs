using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uzuri_Swimwear.Model;

namespace Uzuri_Swimwear.Forms
{
    public partial class ProfileForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(User.Identity.IsAuthenticated)
            {
                GetUserInfo();
            }
        }

        protected void GetUserInfo()
        {
            var userInfo = GetProfileInfo();
            foreach(GetUserProfileInfo_Result user in userInfo)
            {
                firstName.Text = user.FirstName;
                lastName.Text = user.LastName;
                phone.Text = user.PhoneNumber;
                suburb.Text = user.SUBURB;
                Street.Text = user.STREET_NAME;
                city.Text = user.CITY;
                postalCode.Text = user.POSTAL_CODE;
                //provinceSelection.SelectedValue = user.PROVINCE;
            }
        }

        protected IEnumerable<GetUserProfileInfo_Result> GetProfileInfo()
        {
            UzuriSwimwearDBEntities dbContext = new UzuriSwimwearDBEntities();
            var query = dbContext.GetUserProfileInfo(User.Identity.GetUserId());
            return query;
        }

        protected void EditPersonalInfoBtn_Click(object sender, EventArgs e)
        {
            firstName.Enabled = true;
            lastName.Enabled = true;
            phone.Enabled = true;
        }
    }
}