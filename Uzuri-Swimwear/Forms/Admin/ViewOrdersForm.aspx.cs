﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Uzuri_Swimwear.Model;

namespace Uzuri_Swimwear.Forms.Admin
{
    public partial class ViewOrdersForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.startDate = new DateTime(2021, 11, 1);
                this.endDate = DateTime.Now; //today
                this.endDate.AddDays(1); //add 1 day to ensure it gets everything
                BindOrderGridView();
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Stores the orderID in the viewstate for selecting orders
        /// </summary>
        public int orderID
        {
            get
            {
                //gets the productID from the viewstate
                int returnValue = 0;
                //checks if its null then gets it
                if (ViewState["orderID"] != null)
                    Int32.TryParse(ViewState["orderID"].ToString(), out returnValue);
                return returnValue;
            }
            set
            {
                ViewState["orderID"] = value;
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Stores the startDate in the viewState
        /// </summary>
        public DateTime startDate
        {
            get
            {
                //gets the productID from the viewstate
                DateTime returnValue = new DateTime();
                //checks if its null then gets it
                if (ViewState["startDate"] != null)
                    DateTime.TryParse(ViewState["startDate"].ToString(), out returnValue);
                return returnValue;
            }
            set
            {
                ViewState["startDate"] = value;
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// stores the endDate in the viewstate
        /// </summary>
        public DateTime endDate
        {
            get
            {
                //gets the productID from the viewstate
                DateTime returnValue = new DateTime();
                //checks if its null then gets it
                if (ViewState["endDate"] != null)
                    DateTime.TryParse(ViewState["endDate"].ToString(), out returnValue);
                return returnValue;
            }
            set
            {
                ViewState["endDate"] = value;
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to bind the order grid view
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        protected void BindOrderGridView()
        {
            OrderGridView.DataSource = GetOrders();
            OrderGridView.DataBind();
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to retrieve all orders from the specified date range
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<GetAllOrders_Result> GetOrders()
        {
            try
            {
                var dbContext = new UzuriSwimwearDBEntities();
                var query = dbContext.GetAllOrders(this.startDate, this.endDate);
                return query;
            }
            catch(Exception e)
            {
                Response.Write(e.Message);
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Getting the order status for the dropdownlsist
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GetOrderStatus_Result> GetOrderStatus()
        {
            try
            {
                var dbContext = new UzuriSwimwearDBEntities();
                var query = dbContext.GetOrderStatus();
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
        /// Change the page index of the order grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OrderGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void OrderGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectRow")
            {
                this.orderID = Convert.ToInt32(e.CommandArgument);
                //BindImageGridView();
            }
            else if (e.CommandName == "EditRow")
            {
                //index of the row
                int rowIndex = Convert.ToInt32(((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex);
                //select row to edit
                OrderGridView.EditIndex = rowIndex;
                BindOrderGridView();
            }
            else if (e.CommandName == "CancelRow")
            {
                //cancel update
                OrderGridView.EditIndex = -1;
                BindOrderGridView();
            }
            else if (e.CommandName == "UpdateRow")
            {
                //index of the row
                int rowIndex = Convert.ToInt32(((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex);
                //updating
                int orderID = Convert.ToInt32(e.CommandArgument); 
                int orderStatus = Convert.ToInt32(((DropDownList)OrderGridView.Rows[rowIndex].FindControl("StatusDropDown")).SelectedValue);

                //updating
                UpdateOrder(orderID, orderStatus);
                OrderGridView.EditIndex = -1;
                BindOrderGridView();
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to update the order in the database
        /// </summary>
        /// <param name="orderID"></param>
        protected void UpdateOrder(int orderID, int orderStatus)
        {
            try
            {
                using(var dbContext = new UzuriSwimwearDBEntities())
                {
                    ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                    dbContext.UpdateOrderStatus(orderID, orderStatus, User.Identity.GetUserId(), responseMessage);
                    Response.Write(responseMessage.Value.ToString());
                }
            }
            catch(Exception e)
            {
                Response.Write(e.Message);
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        ///  Button click to set an end date and start date for the orders list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SearchBtn_Click(object sender, EventArgs e)
        {         
            this.startDate = Convert.ToDateTime(startDatePicker.Text);
            this.endDate = Convert.ToDateTime(endDatePicker.Text);
            BindOrderGridView();
        }
    }
}