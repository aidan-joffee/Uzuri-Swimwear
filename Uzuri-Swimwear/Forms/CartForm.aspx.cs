using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uzuri_Swimwear.Model;
using System.Data.Entity.Core.Objects;
using Microsoft.AspNet.Identity;

namespace Uzuri_Swimwear.Forms
{
    public partial class CartForm : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataSourcesView();
                GetCartTotal();          

            }

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression

        /// <summary>
        /// Method to retrieve cart products
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<GetCartProducts_Result> GetCartProducts(string id)
        {
            var dbContext = new UzuriSwimwearDBEntities();
            var query = dbContext.GetCartProducts(id);
            return query;
        }
        protected IEnumerable<GetCartCustomerRequests_Result> GetCartRequests(string id)
        {
            var dbContext = new UzuriSwimwearDBEntities();
            var query = dbContext.GetCartCustomerRequests(id);
            return query;
        }


        protected void BindDataSourcesView()
        {
            
            listViewCartProducts.DataSource = GetCartProducts(User.Identity.GetUserId());//hardcoded for now do not forget
            listViewCartProducts.DataBind();
            listViewCartCustRequest.DataSource = GetCartRequests(User.Identity.GetUserId());
            listViewCartCustRequest.DataBind();
        }

        /// <summary>
        /// Method to call function that Sums the totals of a users cart 
        /// </summary>
        protected void GetCartTotal()
        {
            using (var context = new UzuriSwimwearDBEntities())
            {

                ObjectParameter sumTotal = new ObjectParameter("SumTotal", typeof(double));
                var query = context.GetSumOfCart(User.Identity.GetUserId(), sumTotal);
                string tempSum = sumTotal.Value.ToString();
                if (tempSum != "0")
                {
                    cartTotal.Text = "Your Cart Total R" + tempSum;
                }
                else
                {
                    cartTotal.Text = ""; 
                }

            }
        }


        /// <summary>
        /// Deletes select product using function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DeleteProductFromCart(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int RowId = Convert.ToInt32(e.CommandArgument);

                using (var context = new UzuriSwimwearDBEntities())
                {

                    context.DeleteCartProduct(RowId);
                    BindDataSourcesView();
                    GetCartTotal();
                }

            }
        }

        protected void DeleteRequestFromCart(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int RowId = Convert.ToInt32(e.CommandArgument);

                using (var context = new UzuriSwimwearDBEntities())
                {

                    context.DeleteCartRequst(RowId);
                    BindDataSourcesView();
                    GetCartTotal();

                }

            }
        }

        void ImageCheck(Object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //var ImageDate = ((byte[])e.Row.DataItem).ImageReq;
                //do something 
            }


        }

        /// <summary>
        /// Gets UserId using ASP.identity function
        /// </summary>
        /// <returns></returns>
        protected string GetUserId()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var userID = User.Identity.GetUserId();
                string ID = userID;
                return ID;
            }else {
                return "";
            }                    

        }


        protected string GetImage(object oItem)
        {
            // read the data from database
            var cImgSrc = DataBinder.Eval(oItem, "IMAGE_DATA") as byte[];


            // if we do not have any image, return some default.
            if (cImgSrc == null)
            {
                return "/Images/NoImage.png";
            }
            else
            {
                // format and render back the image
                return String.Format("data:image/jpg;base64,{0}",
                        Convert.ToBase64String((byte[])cImgSrc));
            }

        }

    }
}//end of form