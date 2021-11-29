using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uzuri_Swimwear.Model;

namespace Uzuri_Swimwear.Forms.Admin
{
    public partial class EditCategoryForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCategoryGridView();
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Binding category grid view
        /// </summary>
        protected void BindCategoryGridView()
        {
            CategoryGridView.DataSource = GetAllCategories();
            CategoryGridView.DataBind();
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to retrieve all the categories
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GetAllCategories_Result> GetAllCategories()
        {
            try
            {
                UzuriSwimwearDBEntities dBEntities = new UzuriSwimwearDBEntities();
                var query = dBEntities.GetAllCategories();
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
        /// Gridview command for categorygridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CategoryGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                //index of the row
                int rowIndex = Convert.ToInt32(((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex);
                //select row to edit
                CategoryGridView.EditIndex = rowIndex;
                BindCategoryGridView();
            }
            else if (e.CommandName == "CancelRow")
            {
                //cancel update
                CategoryGridView.EditIndex = -1;
                BindCategoryGridView();
            }
            else if (e.CommandName == "UpdateRow")
            {
                //perform update
                int rowIndex = Convert.ToInt32(((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex);
                //updating
                int catID = Convert.ToInt32(e.CommandArgument);
                string catName = ((TextBox)CategoryGridView.Rows[rowIndex].FindControl("CatNameBox")).Text;
                decimal catPrice = Convert.ToDecimal(((TextBox)CategoryGridView.Rows[rowIndex].FindControl("CatPriceBox")).Text);
                UpdateCategory(catID, catName, catPrice);
                CategoryGridView.EditIndex = -1;
                BindCategoryGridView();
            }
            else if (e.CommandName == "DeleteRow")
            {
                //perform delete
                DeleteCategory(Convert.ToInt32(e.CommandArgument));
                BindCategoryGridView();
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// updating a category from the database
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        private void UpdateCategory(int categoryID, string name, decimal price)
        {
            try
            {
                using (var dbContext = new UzuriSwimwearDBEntities())
                {
                    ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                    dbContext.UpdateCategory(categoryID, name, price, responseMessage);
                    Response.Write(responseMessage.Value.ToString());
                }
            }
            catch (Exception E)
            {
                Response.Write(E.Message);
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// deleteing a category from the database
        /// </summary>
        /// <param name="categoryID"></param>
        private void DeleteCategory(int categoryID)
        {
            try
            {
                using (var dbContext = new UzuriSwimwearDBEntities())
                {
                    ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                    dbContext.DeleteProdCategory(categoryID, responseMessage);
                    Response.Write(responseMessage.Value.ToString());
                }
            }
            catch (Exception E)
            {
                Response.Write(E.Message);
            }
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Change the page index of the gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CategoryGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CategoryGridView.PageIndex = e.NewPageIndex;
            BindCategoryGridView();
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Button event to add a category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddCategoryBtn_Click(object sender, EventArgs e)
        {
            AddCategory();
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to add a category to the database
        /// </summary>
        protected void AddCategory()
        {
            string name = CategoryName.Text;
            decimal price = Convert.ToDecimal(CategoryPrice.Text);
            try
            {
                using (var dbContext = new UzuriSwimwearDBEntities())
                {
                    ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                    dbContext.CreateProdCategory(name, price, responseMessage);
                    Response.Write(responseMessage.Value.ToString());
                }
            }
            catch(Exception E)
            {
                Response.Write(E.InnerException.Message);
            }
        }
        //--
    }
}
//------------------------------------------------End of file------------------------------------------------