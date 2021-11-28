<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="Order_Status.aspx.cs" Inherits="Uzuri_Swimwear.Forms.Order_Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:GridView ItemType="Uzuri_Swimwear.Model._Result" HeaderStyle-BackColor="#CAA557" ID="orderStatusGridView" class="container" CssClass="table table-responsive table-hover" runat="server" AutoGenerateColumns="false">



     </asp:GridView>

</asp:Content>
