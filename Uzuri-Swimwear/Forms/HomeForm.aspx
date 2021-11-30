﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="HomeForm.aspx.cs" Inherits="Uzuri_Swimwear.Forms.HomeForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--Summary
        Author: Matthew Tyler Augustine -->


    <!-- Container for product on Home-->
    <div class="body-flexbox">

        <!-- Products Card container-->
        <!-- Products that user has searched for-->

        <%-- <asp:ListView ItemType="Uzuri_Swimwear.Model.GetSearchedProductsForSale_Result" runat="server" ID="listViewSearch">
            <ItemTemplate>
                <div class="card">
                    <img src="/Images/uzuri-logo-transparent-small.png" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title">Name Holder<%--<%#Eval("NAME")%>--REMOVETHISWORD%></h5>
                        
                            <p class="card-text">Item Description</p>

                            <div class="card-button-flex">
                                <a href="#" class="btn btn-success card-button">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-cart" viewBox="0 0 16 16">
                                        <path d="M0 1.5A.5.5 0 0 1 .5 1H2a.5.5 0 0 1 .485.379L2.89 3H14.5a.5.5 0 0 1 .491.592l-1.5 8A.5.5 0 0 1 13 12H4a.5.5 0 0 1-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 0 1-.5-.5zM3.102 4l1.313 7h8.17l1.313-7H3.102zM5 12a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm7 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm-7 1a1 1 0 1 1 0 2 1 1 0 0 1 0-2zm7 0a1 1 0 1 1 0 2 1 1 0 0 1 0-2z" />
                                    </svg>
                                </a>
                            </div>

                        </div>
                    </div>

            </ItemTemplate>

        </asp:ListView>--%>
        <!-- Add data from db onto home page-->

        <asp:ListView ItemType="Uzuri_Swimwear.Model.GetProductsForSale_Result" runat="server" ID="listViewHome">
            <ItemTemplate>
                <div class="card">
                    <img src="/Images/uzuri-logo-transparent-small.png" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("NAME")%></h5>
                        
                            <p class="card-text">Item Description</p>

                            <div class="card-button-flex">
                                <a href="#" class="btn btn-success card-button">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-cart" viewBox="0 0 16 16">
                                        <path d="M0 1.5A.5.5 0 0 1 .5 1H2a.5.5 0 0 1 .485.379L2.89 3H14.5a.5.5 0 0 1 .491.592l-1.5 8A.5.5 0 0 1 13 12H4a.5.5 0 0 1-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 0 1-.5-.5zM3.102 4l1.313 7h8.17l1.313-7H3.102zM5 12a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm7 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm-7 1a1 1 0 1 1 0 2 1 1 0 0 1 0-2zm7 0a1 1 0 1 1 0 2 1 1 0 0 1 0-2z" />
                                    </svg>
                                </a>
                            </div>

                        </div>
                    </div>

            </ItemTemplate>

        </asp:ListView>

    </div>
</asp:Content>
