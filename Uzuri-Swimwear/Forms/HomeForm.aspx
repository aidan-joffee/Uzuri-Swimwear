<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="HomeForm.aspx.cs" Inherits="Uzuri_Swimwear.Forms.HomeForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/css/HomeFormStyle.css" rel="stylesheet" runat="server" type="text/css" />
    <style>
        .home-content {
            width: 15%;
            margin-left: 0.5%;
            margin-right: 0.5%;
            margin-bottom: 3%;
            float: left;
            min-width: 250px;
            max-height:900px;
            
        }

        .body-flexbox {
            flex-wrap: wrap;
            overflow: visible;
            align-items: center;
            float:left;
            
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--HOME CONTENT-->
    <!--Summary
        Author: Matthew Tyler Augustine -->
    <!-- Container for product on Home-->
        <div class="body-flexbox" style="padding-left:30px; padding-top: 50px; padding-bottom:50px;">
            <!-- Add data from db onto home page-->
            <asp:ListView ItemType="Uzuri_Swimwear.Model.GetProductsForSale_Result" runat="server" ID="listViewHome" OnItemCommand="listViewHome_ItemCommand" >
                
                <ItemTemplate>
                    <div class="home-content" >
                        <div class="card">
                            <img src='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("IMAGE_DATA")) %>' alt="..." class="card-img-top" style="max-height:720px; max-width:500px;"/>
                            <div class="card-body text-center">
                                <h5 class="card-title"><%#Eval("NAME")%></h5>
                                <p class="card-text"><%#Eval("DESCRIPTION")%></p>
                                <p class="card-footer">R<%#Eval("PRICE")%></p>
                                <div class="card-button-flex">

                                    <asp:Button runat="server" CssClass="btn btn-success" CommandArgument='<%#Eval("PRODUCT_ID")%>' CommandName="AddToCart" Text="Add to Cart" />
                                    <asp:Button runat="server" CssClass="btn btn-primary" CommandArgument='<%#Eval("PRODUCT_ID")%>' CommandName="RedirectItemsPage" Text="View Item" />

                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>

            </asp:ListView>

        </div>
</asp:Content>
