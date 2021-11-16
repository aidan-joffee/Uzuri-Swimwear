<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="AddProductForm.aspx.cs" Inherits="Uzuri_Swimwear.Forms.AddProductForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <h4>Add a Product</h4>
        </div>
        <div class="row">
            <div class="col col-sm">
                <div id="AddProdForm" class="panel panel-default">
                    <div class="mb-3">
                        <label for="ProdName">Product Name:</label>
                        <asp:TextBox runat="server" ID="ProdName" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="ProdDesc">Product Description</label>
                        <asp:TextBox runat="server"
                            ID="ProdDesc"
                            CssClass="form-control"
                            TextMode="MultiLine"
                            Required="true"
                            MaxLength="255"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button runat="server" type="submit" ID="AddProdBtn" />
                    </div>
                </div>
            </div>
            <div class="col col-sm">
                <p class="text-muted">
                    Use this page to add a product to your site. Once the product has been added, you may view
                        or edit the product in the <a href="ProductForm.aspx" class="text-decoration-none">Edit Products</a> page.                    
                </p>
            </div>
        </div>
    </div>
</asp:Content>
