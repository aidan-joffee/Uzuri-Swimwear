<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="ForgotPassForm.aspx.cs" Inherits="Uzuri_Swimwear.Forms.Account.ResetPassForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>
        <div class="row">
            <h4>Forgot Password?</h4>
        </div>
        <div class="row">
            <p class="text-muted">Enter your email below and follow the link provided to reset your password.</p>
            <div class="col-6 col-sm">
                <h6>Email</h6>
                <asp:TextBox TextMode="Email" runat="server" ID="emailBox" Placeholder="Enter your email.." CssClass="form-control-sm"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator
                    runat="server"
                    ControlToValidate="emailBox"
                    ErrorMessage="Email is required.">
                </asp:RequiredFieldValidator>
                <br />
                <asp:Button CssClass="btn-outline-dark" runat="server" ID="ForgotPassBtn" OnClick="ForgotPassBtn_Click" Text="Send"/>
            </div>
        </div>
    </div>
</asp:Content>
