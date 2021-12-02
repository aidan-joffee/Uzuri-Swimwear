<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="ItemsPage.aspx.cs" Inherits="Uzuri_Swimwear.Forms.ItemsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/css/MasterPageStyle.css" rel="stylesheet" runat="server" type="text/css" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- Carousel for Images --%>



    <%-- Carousel Images --%>
    
    <div class="item-carousel-container">

    <div id="carouselExampleDark" class="carousel carousel-dark slide" data-bs-ride="carousel">
  <div class="carousel-indicators">
    <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
    <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="1" aria-label="Slide 2"></button>
    <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="2" aria-label="Slide 3"></button>
  </div>
  <div class="carousel-inner">
    <div class="carousel-item active" data-bs-interval="10000">
      <asp:Image ImageUrl="/Images/uzuri-logo-transparent-small.png" runat="server" id="Image0" class="d-block w-100" alt="..."/>
      <div class="carousel-caption d-none d-md-block">
      </div>
    </div>
    <div class="carousel-item" data-bs-interval="2000">
      <asp:Image ImageUrl="/Images/uzuri-logo-transparent-small.png" runat="server" id="Image1" class="d-block w-100" alt="..."/>
      <div class="carousel-caption d-none d-md-block">
      </div>
    </div>
    <div class="carousel-item">
      <asp:Image ImageUrl="/Images/uzuri-logo-transparent-small.png" runat="server" id="Image2" class="d-block w-100" alt="..."/>
      <div class="carousel-caption d-none d-md-block">
      </div>
    </div>
  </div>
  <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleDark" data-bs-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Previous</span>
  </button>
  <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleDark" data-bs-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Next</span>
  </button>
</div>
        </div>

    <div class="item-content-text">
        <div><h5 runat="server" id="ProductName">Name</h5></div>
        <div><p runat="server" id="ProductDescription">Description</p></div>
    </div>
    <%-- Carousel Images --%>


</asp:Content>
