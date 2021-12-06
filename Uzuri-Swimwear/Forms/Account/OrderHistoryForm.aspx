<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="OrderHistoryForm.aspx.cs" Inherits="Uzuri_Swimwear.Forms.Account.OrderHistoryForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="background-color: white">
        <div class="row">
            <h6>Order History</h6>
            <p class="text-muted">Use this page to view and track your order history!</p>
            <hr />
        </div>
        <div class="row">
            <asp:GridView
                ID="OrderHistoryGridView"
                runat="server"
                CssClass="table table-responsive table-hover"
                HeaderStyle-BackColor="#CAA557"
                ItemType="Uzuri_Swimwear.Model.GetUserOrderHistory"
                AutoGenerateColumns="true"
                GridLines="None"
                AllowPaging="true"
                PageSize="10"
                OnPageIndexChanging="OrderHistoryGridView_PageIndexChanging">
                <EmptyDataTemplate>
                    <p class="text-muted"> You have not made any orders yet. </p>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
