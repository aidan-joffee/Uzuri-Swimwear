<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="AddProductForm.aspx.cs" Inherits="Uzuri_Swimwear.Forms.AddProductForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <h4>Add a Product</h4>
        </div>
        <div class="row">
            <div class="col col-sm-7">
                <div id="AddProdForm" class="card">
                    <div class="card-body">
                        <div class="mb-3">
                            <label for="ProdName">Product Name:</label>
                            <asp:TextBox runat="server"
                                ID="ProdName"
                                CssClass="form-control"
                                Required="true"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="ProdDesc">Product Description:</label>
                            <asp:TextBox runat="server"
                                ID="ProdDesc"
                                CssClass="form-control"
                                TextMode="MultiLine"
                                Required="true"
                                MaxLength="255"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="CategoryDropList">Product Category:</label>
                            <br />
                            <asp:DropDownList
                                ID="CategoryDropList"
                                SelectMethod="GetCategories"
                                runat="server"
                                DataTextField="NAME"
                                DataValueField="CATEGORY_ID">
                            </asp:DropDownList>
                        </div>
                        <div class="mb3">
                            <label for="CategoryDropList">Product Images:</label>
                        </div>
                        <div class="mb3">
                            <p class="text-muted">
                                Between 1 and 3 images can be uploaded. Only file types of .jpg, .png , .jpeg or .gif are accepted.                     
                            </p>
                            <asp:FileUpload ID="AddProdImage" runat="server" AllowMultiple="true" ValidationGroup="ProdImageValidation" CausesValidation="true" />
                            <br />
                            <asp:CustomValidator
                                ID="ImageUploadCountValidator"
                                ValidationGroup="ProdImageValidation"
                                ControlToValidate="AddProdImage"
                                OnServerValidate="ImageUploadCountValidator_ServerValidate"
                                runat="server"
                                ValidateEmptyText="True"
                                ErrorMessage="File type must be either .jpg, .png , .jpeg or .gif. Between 1-3 images can be uploaded."
                                ForeColor="red">
                            </asp:CustomValidator>
                            <br />
                        </div>
                        <div class="mb3">
                            <asp:Button CssClass="btn btn-outline-dark" runat="server" OnClick="AddProdBtn_Click" ID="AddProdBtn" Text="Submit" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col col-sm-5">
                <p class="text-muted">
                    Use this page to add a product to your site. Once the product has been added, you may view
                        or edit the product in the <a href="EditProductForm.aspx" class="text-decoration-none">Edit Products</a> page.                    
                </p>
            </div>
        </div>
    </div>
</asp:Content>
