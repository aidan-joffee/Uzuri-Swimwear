<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="HomeForm.aspx.cs" Inherits="Uzuri_Swimwear.Forms.HomeForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--Summary
        Author: Matthew Tyler Augustine -->


    <!-- Container for product on Home-->
    <div class="body-flexbox">

        <!-- Products Card container-->
        <!-- Add fata from db-->

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
        <!-----------Card 2------------------>

        <%--        <!----Commeneted out template for home Cards------->
        <div class="card" >
            <img src="/Images/uzuri-logo-transparent-small.png" class="card-img-top" alt="...">
                <div class="card-body">
                <h5 class="card-title">Item 2</h5>  <!-- Add fata from db-->
                <p class="card-text">Item 2 Description</p>

                    <div class="card-button-flex">
                        <a href="#" class="btn btn-success card-button">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-cart" viewBox="0 0 16 16">
  <path d="M0 1.5A.5.5 0 0 1 .5 1H2a.5.5 0 0 1 .485.379L2.89 3H14.5a.5.5 0 0 1 .491.592l-1.5 8A.5.5 0 0 1 13 12H4a.5.5 0 0 1-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 0 1-.5-.5zM3.102 4l1.313 7h8.17l1.313-7H3.102zM5 12a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm7 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm-7 1a1 1 0 1 1 0 2 1 1 0 0 1 0-2zm7 0a1 1 0 1 1 0 2 1 1 0 0 1 0-2z"/>
</svg>
                        </a>
                    </div>
                
         </div>
        </div>
        <!-----------Card 3------------------>
        <div class="card" >
            <img src="/Images/uzuri-logo-transparent-small.png" class="card-img-top" alt="...">
                <div class="card-body">
                <h5 class="card-title">Item 3</h5>  <!-- Add fata from db-->
                <p class="card-text">Item 3 Description</p>

                    <div class="card-button-flex">
                        <a href="#" class="btn btn-success card-button">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-cart" viewBox="0 0 16 16">
  <path d="M0 1.5A.5.5 0 0 1 .5 1H2a.5.5 0 0 1 .485.379L2.89 3H14.5a.5.5 0 0 1 .491.592l-1.5 8A.5.5 0 0 1 13 12H4a.5.5 0 0 1-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 0 1-.5-.5zM3.102 4l1.313 7h8.17l1.313-7H3.102zM5 12a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm7 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm-7 1a1 1 0 1 1 0 2 1 1 0 0 1 0-2zm7 0a1 1 0 1 1 0 2 1 1 0 0 1 0-2z"/>
</svg>
                        </a>
                    </div>
                
         </div>
        </div>
        <!-----------Card 4------------------>
        <div class="card" >
            <img src="/Images/uzuri-logo-transparent-small.png" class="card-img-top" alt="...">
                <div class="card-body">
                <h5 class="card-title">Item 4</h5>  <!-- Add fata from db-->
                <p class="card-text">Item 4 Description</p>

                    <div class="card-button-flex">
                        <a href="#" class="btn btn-success card-button">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-cart" viewBox="0 0 16 16">
  <path d="M0 1.5A.5.5 0 0 1 .5 1H2a.5.5 0 0 1 .485.379L2.89 3H14.5a.5.5 0 0 1 .491.592l-1.5 8A.5.5 0 0 1 13 12H4a.5.5 0 0 1-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 0 1-.5-.5zM3.102 4l1.313 7h8.17l1.313-7H3.102zM5 12a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm7 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm-7 1a1 1 0 1 1 0 2 1 1 0 0 1 0-2zm7 0a1 1 0 1 1 0 2 1 1 0 0 1 0-2z"/>
</svg>
                        </a>
                    </div>
                
         </div>
        </div>
        <!-----------Card 5------------------>
        <div class="card" >
            <img src="/Images/uzuri-logo-transparent-small.png" class="card-img-top" alt="...">
                <div class="card-body">
                <h5 class="card-title">Item 5</h5>  <!-- Add fata from db-->
                <p class="card-text">Item 5 Description</p>

                    <div class="card-button-flex">
                        <a href="#" class="btn btn-success card-button">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-cart" viewBox="0 0 16 16">
  <path d="M0 1.5A.5.5 0 0 1 .5 1H2a.5.5 0 0 1 .485.379L2.89 3H14.5a.5.5 0 0 1 .491.592l-1.5 8A.5.5 0 0 1 13 12H4a.5.5 0 0 1-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 0 1-.5-.5zM3.102 4l1.313 7h8.17l1.313-7H3.102zM5 12a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm7 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm-7 1a1 1 0 1 1 0 2 1 1 0 0 1 0-2zm7 0a1 1 0 1 1 0 2 1 1 0 0 1 0-2z"/>
</svg>
                        </a>
                    </div>
                
         </div>
        </div>
        <!-----------Card 6------------------>
        <div class="card" >
            <img src="/Images/uzuri-logo-transparent-small.png" class="card-img-top" alt="...">
                <div class="card-body">
                <h5 class="card-title">Item 6</h5>  <!-- Add fata from db-->
                <p class="card-text">Item 6 Description</p>

                    <div class="card-button-flex">
                        <a href="#" class="btn btn-success card-button">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-cart" viewBox="0 0 16 16">
  <path d="M0 1.5A.5.5 0 0 1 .5 1H2a.5.5 0 0 1 .485.379L2.89 3H14.5a.5.5 0 0 1 .491.592l-1.5 8A.5.5 0 0 1 13 12H4a.5.5 0 0 1-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 0 1-.5-.5zM3.102 4l1.313 7h8.17l1.313-7H3.102zM5 12a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm7 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm-7 1a1 1 0 1 1 0 2 1 1 0 0 1 0-2zm7 0a1 1 0 1 1 0 2 1 1 0 0 1 0-2z"/>
</svg>
                        </a>
                    </div>
                
         </div>
        </div>
        <!-----------End of Cards------------------>

        <!----Commeneted out template for home Cards------->--%>
    </div>
    <!------------>
</asp:Content>
