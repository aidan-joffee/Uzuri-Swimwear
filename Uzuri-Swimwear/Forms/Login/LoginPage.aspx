<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Uzuri_Swimwear.Forms.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h4 style="font-size: medium">Log In</h4>
        <hr />
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="LoginForm" Visible="false">
            <div style="margin-bottom: 10px">
                <asp:Label runat="server" AssociatedControlID="Email">Email</asp:Label>
                <div>
                    <asp:TextBox runat="server" ID="Email" TextMode="Email" />
                </div>
            </div>

            <div style="margin-bottom: 10px">
                <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                <div>
                    <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                </div>
            </div>
            <div style="margin-bottom: 10px">
                <div>
                    <asp:Button runat="server" OnClick="SignIn" Text="Log in" />
                </div>
            </div>
            <div style="margin-bottom: 10px">
                <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me?" />
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="LogoutButton" Visible="false">
            <div>
                <div>
                    <asp:Button runat="server" OnClick="SignOut" Text="Log out" />
                </div>
            </div>
        </asp:PlaceHolder>
    </div>
</asp:Content>
