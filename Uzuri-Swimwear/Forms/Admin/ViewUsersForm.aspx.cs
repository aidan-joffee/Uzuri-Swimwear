using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uzuri_Swimwear.Model;

namespace Uzuri_Swimwear.Forms.Admin
{
    public partial class ViewUsersForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(User.Identity.IsAuthenticated)
                {
                    BindUsersGridView();
                }
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Binding the order history gridview
        /// </summary>
        protected void BindUsersGridView()
        {
            UsersGridView.DataSource = GetUserInformation();
            UsersGridView.DataBind();
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to retreive the order history from the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GetAllGeneralUsers_Result> GetUserInformation()
        {
            try
            {
                UzuriSwimwearDBEntities dBEntities = new UzuriSwimwearDBEntities();
                ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                var query = dBEntities.GetAllGeneralUsers(User.Identity.GetUserId(), responseMessage);
                return query;
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to change the index of the page for the gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UsersGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            UsersGridView.PageIndex = e.NewPageIndex;
            BindUsersGridView();
        }
    }
}