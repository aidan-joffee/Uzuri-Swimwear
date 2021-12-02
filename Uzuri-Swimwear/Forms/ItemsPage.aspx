<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="ItemsPage.aspx.cs" Inherits="Uzuri_Swimwear.Forms.ItemsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/css/MasterPageStyle.css" rel="stylesheet" runat="server" type="text/css" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- Carousel for Images --%>

    <div class="item-content-carousel item-content-carousel" style="margin-bottom:150px;")>
        <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
            </div>
            <div class="carousel-inner">

                <asp:ListView ItemType="Uzuri_Swimwear.Model.GetProductsForSale_Result" runat="server" ID="listViewItems"  OnItemCommand="listViewItems_ItemCommand">
                    <ItemTemplate>

                        <div class="carousel-item active ">
                            <img src='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("IMAGE_DATA")) %>' class="d-block" alt="...">
                            <div><%#Eval("NAME")%></div>
                            <div><%#Eval("DESCRIPTION")%></div>
                            <asp:Button runat="server" CommandArgument='<%#Eval("PRODUCT_ID")%>' CommandName="AddToCart" class="items-add-to-cart"/>
                        </div>

                        
                    </ItemTemplate>
                </asp:ListView>
            </div>

        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>
    <%-- Carousel for Images --%>

</asp:Content>
