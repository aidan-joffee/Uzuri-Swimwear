using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uzuri_Swimwear.Model;
using System.Data.Entity.Core.Objects;

/*
 * Author: Aidan Joffee
 */


namespace Uzuri_Swimwear.Forms
{
    public partial class ProfileForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    GetUserInfo();
                }
            }         
        }

        /// <summary>
        /// Method to retrieve the users edittable profile data from the database
        /// </summary>
        protected void GetUserInfo()
        {
            var userInfo = GetProfileInfo();
            if (userInfo != null)
            {
                foreach (GetUserProfileInfo_Result user in userInfo)
                {
                    firstName.Text = user.FirstName;
                    lastName.Text = user.LastName;
                    phoneNum.Text = user.PhoneNumber;
                    suburb.Text = user.SUBURB;
                    Street.Text = user.STREET_NAME;
                    city.Text = user.CITY;
                    postalCode.Text = user.POSTAL_CODE;
                    //provinceSelection.SelectedValue = user.PROVINCE;
                }
            }
        }

        protected IEnumerable<GetUserProfileInfo_Result> GetProfileInfo()
        {
            try
            {
                UzuriSwimwearDBEntities dbContext = new UzuriSwimwearDBEntities();
                var query = dbContext.GetUserProfileInfo(User.Identity.GetUserId());
                return query;
            }
            catch(Exception e)
            {
                Response.Write(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Onclick to enable editting of personal information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EditPersonalInfoBtn_Click(object sender, EventArgs e)
        {
            firstName.ReadOnly = false;
            lastName.ReadOnly = false;
            phoneNum.ReadOnly = false;

            //disabling address so only one can be eddited at a time
            suburb.ReadOnly = true;
            Street.ReadOnly = true;
            city.ReadOnly = true;
            postalCode.Enabled = true;

            //hiding or showing buttons
            EditPersonalInfoBtn.Visible = false;
            CancelEditPersonalBtn.Visible = true;
            SubmitPersonalInfoBtn.Visible = true;
            EditAddressInfoBtn.Visible = true;
            CancelEditAddressBtn.Visible = false;
            SubmitAddressInfoBtn.Visible = false;
        }

        /// <summary>
        /// Onclick to enable editting of address information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EditAddressInfoBtn_Click(object sender, EventArgs e)
        {
            phoneNum.ReadOnly = false;
            suburb.ReadOnly = false;
            Street.ReadOnly = false;
            city.ReadOnly = false;
            postalCode.ReadOnly = false;

            //disabling personal info
            firstName.ReadOnly = true;
            lastName.ReadOnly = true;
            phoneNum.ReadOnly = true;

            //hiding or showing buttons
            EditAddressInfoBtn.Visible = false;
            CancelEditAddressBtn.Visible = true;
            SubmitAddressInfoBtn.Visible = true;
            EditPersonalInfoBtn.Visible = true;
            CancelEditPersonalBtn.Visible = false;
            SubmitPersonalInfoBtn.Visible = false;
        }

        /// <summary>
        /// Method to cancel editting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CancelEdit_Click(object sender, EventArgs e)
        {
            phoneNum.ReadOnly= true;
            suburb.ReadOnly = true;
            Street.ReadOnly = true;
            city.ReadOnly = true;
            postalCode.ReadOnly = true;
            firstName.ReadOnly = true;
            lastName.ReadOnly = true;
            //retreive user info again
            GetUserInfo();

            //hiding buttons
            EditAddressInfoBtn.Visible = true;
            EditPersonalInfoBtn.Visible = true;
            CancelEditAddressBtn.Visible = false;
            SubmitAddressInfoBtn.Visible = false;
            CancelEditPersonalBtn.Visible = false;
            SubmitPersonalInfoBtn.Visible = false;
        }

        /// <summary>
        /// Method to update personal info in the database
        /// </summary>
        protected void UpdatePersonalInfo()
        {
            try
            {
                using (var dbContext = new UzuriSwimwearDBEntities())
                {
                    string fName = firstName.Text;
                    string lName = lastName.Text;
                    string phone = phoneNum.Text;
                    ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                    dbContext.UpdateUserInfo(User.Identity.GetUserId(), fName, lName, phone, responseMessage);
                    
                }
            }
            catch(Exception e)
            {
                Response.Write(e.Message);
            }
        }

        /// <summary>
        /// Method to update address info in the database
        /// </summary>
        protected void UpdateAddressInfo()
        {
            try
            {
                using (var dbContext = new UzuriSwimwearDBEntities())
                {
                    string prov = provinceSelection.SelectedValue;
                    string sub = suburb.Text;
                    string strt = Street.Text;
                    string cty = city.Text;
                    string pCode = postalCode.Text;
                    ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                    dbContext.UpdateUserAddressInfo(User.Identity.GetUserId(), prov, sub, strt, cty, pCode, responseMessage);
                    Response.Write(responseMessage.Value.ToString());
                }
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
            }
        }

        protected void SubmitAddressInfoBtn_Click(object sender, EventArgs e)
        {
            UpdateAddressInfo();
        }

        protected void SubmitPersonalInfoBtn_Click(object sender, EventArgs e)
        {
            UpdatePersonalInfo();
        }
    }
}