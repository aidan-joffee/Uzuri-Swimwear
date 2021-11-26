using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uzuri_Swimwear.Model;
using System.Data.Entity.Core.Objects;

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
        protected IEnumerable<GetCartProducts_Result> GetCartProducts(int id)
        {
            var dbContext = new UzuriSwimwearDBEntities();
            var query = dbContext.GetCartProducts(id);
            return query;
        }
        protected IEnumerable<GetCartCustomerRequests_Result> GetCartRequests(int id)
        {
            var dbContext = new UzuriSwimwearDBEntities();
            var query = dbContext.GetCartCustomerRequests(id);
            return query;
        }


        protected void BindDataSourcesView()
        {
            listViewCartProducts.DataSource = GetCartProducts(1);
            listViewCartProducts.DataBind();
            listViewCartCustRequest.DataSource = GetCartRequests(1);
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
                var query = context.GetSumOfCart(1, sumTotal);
                string tempSum = sumTotal.Value.ToString();
                cartTotal.Text = "Your Cart Total R"+tempSum;

            }
        }

        //protected void GetProdId(object sender, ListViewCommandEventArgs e)
        //{
        //    ListViewDataItem lvd = (ListViewDataItem)((Control)e.CommandSource).NamingContainer;

        //    //Same two lines for each value
        //    Label ID = lvd.FindControl("CartProdId") as Label;
        //    string id = ID.ToString();
        //    Response.Write(id);
        //}

        /*
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            //cast the sender back to a button
            Button btn = sender as Button;

            //get the current item from the listview namingcontainer
            ListViewItem item = btn.NamingContainer as ListViewItem;

            //use findcontrol to locate the label in that item
            Label lbl = item.FindControl("CartProdId") as Label;

            //show result in label outside listview
            Response.Write(lbl.Text);
        }
        */
        protected void listViewCartProducts_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if(e.CommandName == "Remove")
            {
                int RowId = Convert.ToInt32(e.CommandArgument);
                
                using (var context = new UzuriSwimwearDBEntities())
                {

                    context.DeleteCartProduct(RowId);
                    BindDataSourcesView();

                }

            }
        }
    }
    }//end of form
