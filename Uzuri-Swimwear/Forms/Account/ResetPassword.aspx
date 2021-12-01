<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Uzuri_Swimwear.Forms.Account.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>


        <div class="row">
            <h4>Reset Password</h4>
        </div>
        <div class="row">
            <p class="text-muted">Enter your email, as well as your new password.</p>
            <div class="col-6 col-sm">
                <h6>Email</h6>
                <asp:TextBox runat="server" TextMode="Email" ID="emailBox" Placeholder="Enter your email.." CssClass="form-control-sm"></asp:TextBox>
                <asp:RequiredFieldValidator
                    runat="server"
                    ControlToValidate="emailBox"
                    ErrorMessage="Required"
                    ForeColor="red"></asp:RequiredFieldValidator>
                <h6>Password</h6>
                <asp:TextBox runat="server" TextMode="Password" ID="passBox" Placeholder="Password" CssClass="form-control-sm"></asp:TextBox>
                <asp:RequiredFieldValidator
                    runat="server"
                    ControlToValidate="passBox"
                    ErrorMessage="Required"
                    ForeColor="red"></asp:RequiredFieldValidator>
                <h6>Confirm Password</h6>
                <asp:TextBox runat="server" TextMode="Password" ID="confirmPassBox" Placeholder="Confirm Password" CssClass="form-control-sm"></asp:TextBox>
                <asp:CompareValidator
                    runat="server"
                    ControlToValidate="confirmPassBox"
                    ControlToCompare="passBox"
                    ErrorMessage="Passwords must match"
                    ForeColor="red">
                </asp:CompareValidator>
                <br />
                <asp:RequiredFieldValidator
                    runat="server"
                    ControlToValidate="confirmPassBox"
                    ErrorMessage="Required"
                    ForeColor="red"></asp:RequiredFieldValidator>
                <br />
                <asp:Button runat="server" ID="ResetPassBtn" Text="Reset Password" OnClick="ResetPassBtn_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
