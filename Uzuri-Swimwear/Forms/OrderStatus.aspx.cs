using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uzuri_Swimwear.Model;

namespace Uzuri_Swimwear.Forms
{
    public partial class OrderStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        public IEnumerable<GetAllOrders_Result> getAllOrders(DateTime start, DateTime End)
        {
            UzuriSwimwearDBEntities dBEntities = new UzuriSwimwearDBEntities();
            var query = dBEntities.GetAllOrders(start, End);
            return query;
        }

        protected void orderStatBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = Startdatepicker.SelectedDate;
                DateTime EndDate = Startdatepicker.SelectedDate;

                Orders_GridView.DataSource = getAllOrders(startDate, EndDate);
                Orders_GridView.DataBind();
            }
            catch (Exception p)
            {
                Response.Write(p.Message);
            }

        }


    }
}