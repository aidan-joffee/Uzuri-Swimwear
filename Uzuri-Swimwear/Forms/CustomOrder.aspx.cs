 using System;
using System.Collections.Generic;
using System.Configuration;
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
            //insert product into cart
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if(FileUpload1.HasFile)
            {
                String RequestCategory = "3";
                //saves photo into folder RequestImages for later recall
                string str = FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("/Images/RequestImages/" + str));
                string imgpath = "/Images/RequestImages/" + str.ToString();
                //command to insert data into table in database
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.CUSTOMER_REQUEST(DESCRIPTION, COLOUR, PATTERN, CATEGORY_ID)VALUES (@DESCRIPTION, @COLOUR, @PATTERN, @CATEGORY_ID)", con);
                //command to insert photo into database. ----Table column in database needs to be changed to varchar(max) from varbinary(max) 
                SqlCommand cmd2 = new SqlCommand("INSERT INTO dbo.IMAGES(iMAGE)VALUES (@IMAGE)", con);
                cmd.Parameters.AddWithValue("@DESCRIPTION", DescriptionTextbox.Text);
                cmd.Parameters.AddWithValue("@COLOUR", ColourTextbox.Text);
                cmd.Parameters.AddWithValue("@PATTERN", PatternTextbox.Text);
                cmd.Parameters.AddWithValue("@CATEGORY_ID", RequestCategory);
                cmd2.Parameters.AddWithValue("@IMAGE", imgpath);
                
                con.Open();
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                con.Close();
                Label1.Text = "Saved Successfully";
            }
            else
            {
                Label1.Text = "Error, please make sure all fields are completed";
            }

        }
            
    }
}