<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="ViewUsersForm.aspx.cs" Inherits="Uzuri_Swimwear.Forms.Admin.ViewUsersForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="background-color:white">
        <div class="row">
            <h6>View User Information</h6>
            <p class="text-muted">This page allows you to view all of your users' information.</p>
            <hr />
        </div>
        <div class="row">
            <asp:GridView
                runat="server"
                ID="UsersGridView"
                CssClass="table table-responsive table-hover"
                HeaderStyle-BackColor="#CAA557"
                ItemType="Uzuri_Swimwear.Model.GetAllGeneralUsers"
                AutoGenerateColumns="true"
                GridLines="None"
                AllowPaging="true"
                PageSize="10"
                OnPageIndexChanging="UsersGridView_PageIndexChanging">
            </asp:GridView>
        </div>
    </div>
</asp:Content>
