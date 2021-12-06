<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="OrderConfirmation.aspx.cs" Inherits="Uzuri_Swimwear.Forms.OrderConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:PlaceHolder runat="server" ID="ErrorMessage">
            <h3 class="text-danger">Payment Failed</h3>
            <p class="text-danger">An error occured during the payment process.</p>
            <asp:Label runat="server" ID="ErrorMsgLbl"></asp:Label>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="SuccessMessage">

        </asp:PlaceHolder>
    </div>
</asp:Content>
