<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="ProductForm.aspx.cs" Inherits="Uzuri_Swimwear.Forms.ProductForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <!--HEADING -->
        <div id="addProduct" class="container">
            <div class="row align-items-center">
                <div class="col">
                    <h4>Product List</h4>
                </div>
                <div class="col">
                    <div class="form-outline">
                        <input type="search" id="form1" class="form-control" />
                    </div>
                    <button type="button" class="btn btn-primary">
                        Search
                    </button>
                </div>
            </div>

            <!--PRODUCT TABLE -->
            <div class="row align-items-start">
                <asp:GridView ID="ProductGridView" runat="server" 
                    CssClass="table table-striped table-hover"
                    ItemType="Uzuri_Swimwear.PRODUCT"
                    AutoGenerateColumns ="false"
                    SelectMethod="GetProducts">
                    <Columns>
                        <asp:DynamicField Datafield="PRODUCT_ID"/>
                        <asp:DynamicField Datafield="NAME"/>
                        <asp:DynamicField Datafield="DESCRIPTION"/>
                        <asp:DynamicField Datafield="FOR_SALE"/>
                        <asp:DynamicField Datafield="CATEGORY_ID"/>
                        <%--<asp:DynamicField DataField ="PRODUCT_ID"/>
                        <asp:DynamicField DataField ="NAME"/>
                        <asp:DynamicField DataField ="PRICE"/>
                        <asp:DynamicField DataField ="CATEGORY"/>
                        <asp:DynamicField DataField ="FOR_SALE"/>--%>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
