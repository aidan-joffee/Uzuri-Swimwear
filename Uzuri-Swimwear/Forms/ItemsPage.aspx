﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="ItemsPage.aspx.cs" Inherits="Uzuri_Swimwear.Forms.ItemsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/MasterPageStyle.css" rel="stylesheet" />
    
    <%-- ListView layout --%>
     <div class="content-itempage">
         <asp:ListView runat="server">
             
             <LayoutTemplate>
                 <asp:PlaceHolder runat="server">
                     <div class="content-carousel">
            <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">
                <div class="carousel-indicators">
                    <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-label="Slide 1"></button>
                    <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
                    <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
                </div>

                 <div class="carousel-inner">
                   
                </div>
                <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Next</span>
                </button>
                 </asp:PlaceHolder>
                 
             </LayoutTemplate>
             <%-- Item template --%>
             <ItemTemplate>
                 <div class="carousel-item active">
                        <img src=".." class="d-block w-100" alt="..."/>
                    </div>
             </ItemTemplate>
              
         </asp:ListView>
       
                
            </div>
        
        <div></div>
        <div>button</div>
    </div>
</asp:Content>