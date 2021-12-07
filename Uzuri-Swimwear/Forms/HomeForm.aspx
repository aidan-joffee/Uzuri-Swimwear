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
            max-height: 900px;
        }

        .body-flexbox {
            flex-wrap: wrap;
            overflow: visible;
            align-items: center;
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >

    <div class="row" style="display: flex; justify-content: space-around; padding-bottom:2%">
         <asp:label id="confirmed" runat="server" style="font:26px; font-weight:bold;"></asp:label>
        <!-- Add data from db onto home page-->
        <asp:ListView ItemType="Uzuri_Swimwear.Model.GetProductsForSale_Result" runat="server" ID="listViewHome" OnItemCommand="listViewHome_ItemCommand">
            <ItemTemplate>

                <div class="col-lg-3 col-md-2 col-sm-1" style=" padding:10px 10px 10px 10px">
                    
                        <div class="card">
                            <img src='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("IMAGE_DATA")) %>' alt="...">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("NAME")%></h5>
                                <p class="card-text"><%#Eval("DESCRIPTION")%></p>
                               
                                <div class="card-button-flex">

                                    <!--Using link buttons to enable icons-->
                                    <asp:LinkButton runat="server" CssClass="btn btn-success" CommandArgument='<%#Eval("PRODUCT_ID")%>' CommandName="AddToCart" Style="margin-right: 2px;" ToolTip="Add item to cart">
                                             <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-cart-plus" viewBox="0 0 16 16">
                                             <path d="M9 5.5a.5.5 0 0 0-1 0V7H6.5a.5.5 0 0 0 0 1H8v1.5a.5.5 0 0 0 1 0V8h1.5a.5.5 0 0 0 0-1H9V5.5z"/>
                                             <path d="M.5 1a.5.5 0 0 0 0 1h1.11l.401 1.607 1.498 7.985A.5.5 0 0 0 4 12h1a2 2 0 1 0 0 4 2 2 0 0 0 0-4h7a2 2 0 1 0 0 4 2 2 0 0 0 0-4h1a.5.5 0 0 0 .491-.408l1.5-8A.5.5 0 0 0 14.5 3H2.89l-.405-1.621A.5.5 0 0 0 2 1H.5zm3.915 10L3.102 4h10.796l-1.313 7h-8.17zM6 14a1 1 0 1 1-2 0 1 1 0 0 1 2 0zm7 0a1 1 0 1 1-2 0 1 1 0 0 1 2 0z"/>
                                             </svg>
                                    </asp:LinkButton>
                                    <asp:LinkButton runat="server" CssClass="btn btn-primary" CommandArgument='<%#Eval("PRODUCT_ID")%>' CommandName="RedirectItemsPage" ToolTip="View this item">
                                             <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-eye-fill" viewBox="0 0 16 16">
                                             <path d="M10.5 8a2.5 2.5 0 1 1-5 0 2.5 2.5 0 0 1 5 0z"/>
                                                <path d="M0 8s3-5.5 8-5.5S16 8 16 8s-3 5.5-8 5.5S0 8 0 8zm8 3.5a3.5 3.5 0 1 0 0-7 3.5 3.5 0 0 0 0 7z"/>
                                                </svg>
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    
                </div>

                </ItemTemplate>

        </asp:ListView>

    </div>

</asp:Content>
