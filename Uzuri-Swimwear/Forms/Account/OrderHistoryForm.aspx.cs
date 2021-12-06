using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Uzuri_Swimwear.Model;
using System.Web.UI.WebControls;
using System.Data.Entity.Core.Objects;

namespace Uzuri_Swimwear.Forms.Account
{
    public partial class OrderHistoryForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    BindOrderHistoryGridView();
                }
            }                    
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Binding the order history gridview
        /// </summary>
        protected void BindOrderHistoryGridView()
        {
            OrderHistoryGridView.DataSource = GetOrderHistory();
            OrderHistoryGridView.DataBind();
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to retreive the order history from the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GetUserOrderHistory_Result> GetOrderHistory()
        {
            try
            {
                UzuriSwimwearDBEntities dBEntities = new UzuriSwimwearDBEntities();
                ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                var query = dBEntities.GetUserOrderHistory(User.Identity.GetUserId(), responseMessage);
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
        protected void OrderHistoryGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            OrderHistoryGridView.PageIndex = e.NewPageIndex;
            BindOrderHistoryGridView();
        }
    }
}