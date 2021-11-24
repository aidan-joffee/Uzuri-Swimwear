<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="RegisterForm.aspx.cs" Inherits="Uzuri_Swimwear.Forms.Login.RegisterForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="LoginPage.aspx">LOGIN</a>
    <div class="container">
        <h4 style="font-size: medium">Register a new user</h4>
        <hr />
        <p>
            <asp:Literal runat="server" ID="StatusMessage" />
        </p>
        <div style="margin-bottom: 10px">
               <asp:Label runat="server" AssociatedControlID="EmailBox">Email</asp:Label>
               <div>
                  <asp:TextBox runat="server" ID="EmailBox" TextMode="Email" />        
               </div>
            </div>
        <div style="margin-bottom: 10px">
            <asp:Label runat="server" AssociatedControlID="txtFirstName">First Name</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="txtFirstName"/>
            </div>
        </div>
        <div style="margin-bottom: 10px">
            <asp:Label runat="server" AssociatedControlID="txtLastName">Last Name</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="txtLastName" />
            </div>
        </div>
        <div style="margin-bottom: 10px">
            <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
            </div>
        </div>
        <div style="margin-bottom: 10px">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
            </div>
        </div>
        <div>
            <div>
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" />
            </div>
        </div>
    </div>
</asp:Content>
