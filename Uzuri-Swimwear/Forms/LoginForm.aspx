<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="Uzuri_Swimwear.Forms.LoginForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sidenav">
        <div class="col-md-6 col-sm-12">
            <div class="login-form">

                  <div class="form-group">
                     <label>Email</label>
                      <asp:TextBox runat="server" type="Email" class="form-control" placeholder="Email"/>
                  </div>
                  <div class="form-group">
                     <label>Password</label>
                     <asp:TextBox runat="server" type="Password" class="form-control" placeholder="Password"/>
                  </div>
                  <button type="submit" class="btn btn-black">Login</button>
                  <a href="RegisterForm.aspx" class="text-muted">Not registered? Click here</a>
               
            </div>
         </div>
    </div>
</asp:Content>
