 using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Uzuri_Swimwear.Forms
{
    public partial class CustomOrder : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ATSLIAM\SQLEXPRESS;Initial Catalog=UzuriSwimwearDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OrderButton_Click(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            String RequestCategory = "3";
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.CUSTOMER_REQUEST(DESCRIPTION, COLOUR, PATTERN, CATEGORY_ID) VALUES('" + DescriptionTextbox.Text + "','" + ColourTextbox.Text + "','" + PatternTextbox.Text + "','" + RequestCategory + "')");
          
            
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            }
            
    }
}