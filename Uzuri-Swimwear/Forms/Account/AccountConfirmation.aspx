<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="AccountConfirmation.aspx.cs" Inherits="Uzuri_Swimwear.Forms.Account.AccountConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successPanel" ViewStateMode="Disabled" Visible="true">
            <p>
                Thank you for confirming your with us account. Click <a style="text-decoration:none" href="LoginForm.aspx">here</a> to login             
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="errorPanel" ViewStateMode="Disabled" Visible="false">
            <p class="text-danger">
                An error has occurred.
            </p>
        </asp:PlaceHolder>
    </div>
</asp:Content>
