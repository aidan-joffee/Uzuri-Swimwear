using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uzuri_Swimwear.Model;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Core.Objects;

namespace Uzuri_Swimwear.Forms
{
    public partial class CustRequestForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataSourcesView();

            }
        }

        protected void ImageUploadCountValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //makes sure atleast 1 image is selected
            if ((AddProdImage.PostedFiles.Count > 1)
                || (AddProdImage.PostedFiles.Count < 1))
            {
                args.IsValid = false;
            }
            else
            {
                //checks extension of each product to ensure its an image
                foreach (var file in AddProdImage.PostedFiles)
                {
                    String fName = file.FileName;
                    String fExt = Path.GetExtension(fName);
                    if (fExt == ".jpg" || fExt == ".png" || fExt == ".gif" || fExt == ".bmp")
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }
            }
        }
        /// <summary>
        /// Method to add a custom request with data in the form using the procedure 'CreateCustomRequest'
        /// </summary>
        protected void AddCustRequest()
        {
            String DescriptionTemp = Description.Text;
            String ColourTemp = Colour.Text;
            String PatternTemp = Pattern.Text;
            String id = User.Identity.GetUserId();


            //null checks
            if (!DescriptionTemp.Equals("") ||
                !ColourTemp.Equals("") ||
                !PatternTemp.Equals(""))
            {
                try
                {
                    using (var dbContext = new UzuriSwimwearDBEntities())
                    {
                        ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));

                        var file = AddProdImage.PostedFile;
                        byte[] bytes = null;
                        if (AddProdImage.HasFile)
                        {
                            bytes = GetImageAsBytes(file.InputStream);
                        }

                        String fName = file.FileName;
                        var query = dbContext.CreateCustomRequest(id, DescriptionTemp, ColourTemp, PatternTemp, bytes, fName, responseMessage);
                        BindDataSourcesView();

                    }


                }
                catch (Exception e)
                {
                    Response.Write(e.InnerException.Message);
                }
            }

        }

        /// <summary>
        /// Method to convert image selected to bytes
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private byte[] GetImageAsBytes(Stream file)
        {
            //reading file
            BinaryReader reader = new BinaryReader(file);
            var bytes = reader.ReadBytes((int)file.Length);
            return bytes;
        }

        protected void AddRequestButton_Click(object sender, EventArgs e)
        {
            AddCustRequest();
        }

        protected IEnumerable<GetUserCustomRequests_Result> GetRequests(string id)
        {
            ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
            var dbContext = new UzuriSwimwearDBEntities();
            var query = dbContext.GetUserCustomRequests(id, responseMessage);
            //Response.Write(responseMessage);
            return query;
        }

        /// <summary>
        /// Databind the grid to the results of GetRequests(User.Identity.GetUserId()
        /// </summary>
        protected void BindDataSourcesView()
        {

            listViewCartCustRequest.DataSource = GetRequests(User.Identity.GetUserId());
            listViewCartCustRequest.DataBind();
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

        /// <summary>
        /// Runs either the AddItemToCart to procedure or DeleteCustRequest
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void listViewCartCustRequest_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ToCart")
            {
                int RowId = Convert.ToInt32(e.CommandArgument);

                using (var context = new UzuriSwimwearDBEntities())
                {

                    ObjectParameter responseMessage = new ObjectParameter("responseMessage", typeof(string));
                    context.AddItemToCart(User.Identity.GetUserId(), RowId, false, responseMessage);
                }

            }
            if (e.CommandName == "Remove")
            {
                int RowId = Convert.ToInt32(e.CommandArgument);

                using (var context = new UzuriSwimwearDBEntities())
                {
                    context.DeleteCustRequest(RowId);
                    BindDataSourcesView();
                }

            }
        }
    }
}