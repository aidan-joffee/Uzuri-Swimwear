<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="HomeForm.aspx.cs" Inherits="Uzuri_Swimwear.Forms.HomeForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Label runat="server" ID="UserIDLbl"></asp:Label>
    </div>

    <hr />
    <!--HOME CONTENT-->
    <!--Summary
        Author: Matthew Tyler Augustine -->
    <!-- Container for product on Home-->
    <div class="body-flexbox">
        <!-- Add data from db onto home page-->
        <asp:ListView ItemType="Uzuri_Swimwear.Model.GetProductsForSale_Result" runat="server" ID="listViewHome" OnItemCommand="listViewHome_ItemCommand">
            <ItemTemplate>
              <div class="home-content">
                   <div class="card">
                    <img src='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("IMAGE_DATA")) %>' alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><%#Eval("NAME")%></h5>
                        <p class="card-text"><%#Eval("DESCRIPTION")%></p>
                        <div class="card-button-flex">

                             <asp:Button runat="server" CssClass="btn btn-success" CommandArgument='<%#Eval("PRODUCT_ID")%>' CommandName="AddToCart" Text="Add to Cart"/>
                            <asp:Button runat="server" CssClass="btn btn-primary" CommandArgument='<%#Eval("PRODUCT_ID")%>' CommandName="RedirectItemsPage" Text="View Item"/>

                        </div>
                    </div>
                </div>
                  </div>

               

            </ItemTemplate>

        </asp:ListView>

    </div>
</asp:Content>
