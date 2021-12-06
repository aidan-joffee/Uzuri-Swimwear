using System;
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
                this.searchByAll = true; 
                this.endDate = DateTime.Now; //today
                this.endDate.AddDays(1); //add 1 day to ensure it gets everything
                BindOrderGridView();
                BindCustomerListView();
                BindOrderProductGridView();
                BindOrderRequesttGridView();
                BindTransactionGridView();
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Bool to check whether to search by statuses all or not
        /// </summary>
        public bool searchByAll
        {
            get
            {
                //gets the productID from the viewstate
                bool returnValue = true;
                //checks if its null then gets it
                if (ViewState["searchByAll"] != null)
                    Boolean.TryParse(ViewState["searchByAll"].ToString(), out returnValue);
                return returnValue;
            }
            set
            {
                ViewState["searchByAll"] = value;
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
                int? statusID = null;
                if(this.searchByAll == false)
                {
                    statusID = Convert.ToInt32(SearchStatusDropDown.SelectedValue);
                }
                var query = dbContext.GetAllOrders(statusID, this.startDate, this.endDate);
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
            OrderGridView.PageIndex = e.NewPageIndex;
            BindOrderGridView();
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Row command for order gridview to perform select, update, delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OrderGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectRow")
            {
                this.orderID = Convert.ToInt32(e.CommandArgument);
                SelectedOrderLbl.Text = String.Format("Selected Order ID: {0}",this.orderID);
                BindCustomerListView();
                BindOrderProductGridView();
                BindOrderRequesttGridView();
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
                bool paid = (((CheckBox)OrderGridView.Rows[rowIndex].FindControl("PaidCheckBox")).Checked);
                //updating
                UpdateOrder(orderID, orderStatus, paid);
                OrderGridView.EditIndex = -1;
                BindOrderGridView();
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to update the order in the database
        /// </summary>
        /// <param name="orderID"></param>
        protected void UpdateOrder(int orderID, int orderStatus, bool paid)
        {
            try
            {
                using(var dbContext = new UzuriSwimwearDBEntities())
                {
                    ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                    dbContext.UpdateOrderStatus(orderID, orderStatus, paid, User.Identity.GetUserId(), responseMessage);
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
        /// Method to retrieve the transaction details from the database
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<GetTransaction_Result> GetTransactionDetails()
        {
            try
            {
                var dbContext = new UzuriSwimwearDBEntities();
                ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                var query = dbContext.GetTransaction(this.orderID);
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
        /// Getting the customer details from the payment
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<GetCustomerDetails_Result> GetCustInfo()
        {
            try
            {
                ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                var dbContext = new UzuriSwimwearDBEntities();
                var query = dbContext.GetCustomerDetails(this.orderID, responseMessage);               
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
        /// Getting the order products from the database
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<GetPlacedOrderProducts_Result> GetOrderProdInfo()
        {
            try
            {
                ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                var dbContext = new UzuriSwimwearDBEntities();
                var query = dbContext.GetPlacedOrderProducts(this.orderID, responseMessage);
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
        /// getting the order requests from the database
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<GetPlacedOrderRequests_Result> GetOrderRequestInfo()
        {
            try
            {
                ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                var dbContext = new UzuriSwimwearDBEntities();
                var query = dbContext.GetPlacedOrderRequests(this.orderID, responseMessage);
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
        /// Method to bind the transaction grid view
        /// </summary>
        protected void BindTransactionGridView()
        {
            TransactionGridView.DataSource = GetTransactionDetails();
            TransactionGridView.DataBind();
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Bind customer list view
        /// </summary>
        public void BindCustomerListView()
        {
            CustomerListView.DataSource = GetCustInfo();
            CustomerListView.DataBind();
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Binding the order products grid view
        /// </summary>
        public void BindOrderProductGridView()
        {
            OrderProductsGridView.DataSource = GetOrderProdInfo();
            OrderProductsGridView.DataBind();
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// binding the order requests grid view
        /// </summary>
        public void BindOrderRequesttGridView()
        {
            OrderRequestsGridView.DataSource = GetOrderRequestInfo();
            OrderRequestsGridView.DataBind();
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
            this.searchByAll = SearchByAll.Checked;
            BindOrderGridView();
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to get the image for 
        /// </summary>
        /// <param name="oItem"></param>
        /// <returns></returns>
        protected string GetImage(object oItem)
        {
            // read the data from database
            var cImgSrc = DataBinder.Eval(oItem, "IMAGE_DATA") as byte[];


            // if we do not have any image, return some default.
            if (cImgSrc == null)
            {
                return "/Images/uzuri-logo.jpg";
            }
            else
            {
                // format and render back the image
                return String.Format("data:image/jpg;base64,{0}",
                        Convert.ToBase64String((byte[])cImgSrc));
            }

        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Event when the searchbyall is checked/unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SearchByAll_CheckedChanged(object sender, EventArgs e)
        {
            //show or hide dropdown to search
            if (SearchByAll.Checked)
            {
                SearchStatusDropDown.Enabled = false;
            }
            else
            {               
                SearchStatusDropDown.Enabled = true;
            }
        }
    }
}