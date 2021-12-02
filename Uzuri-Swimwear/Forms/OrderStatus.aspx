<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="OrderStatus.aspx.cs" Inherits="Uzuri_Swimwear.Forms.OrderStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        

                    <asp:Calendar
                        ID="Startdatepicker"
                        runat="server">
                    </asp:Calendar>
                    
       
                    <asp:Calendar
                        ID="Enddatepicker"
                        runat="server">
                    </asp:Calendar>
         
         <asp:Button ID="orderStatBtn" runat="server" class="btn btn-outline-primary" Text="Select Dates" OnClick="orderStatBtn_Click" />

    <asp:GridView ItemType="Uzuri_Swimwear.Model.GetAllOrders_Result" HeaderStyle-BackColor="#CAA557" ID="Orders_GridView" class="container" CssClass="table table-responsive table-hover" runat="server" AutoGenerateColumns="true">

       

    </asp:GridView>
    
        </div>
</asp:Content>


<%-- <Columns>

            <asp:TemplateField HeaderText="orderID">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%#Eval("ORDER_ID")%>' ID="orderID" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <%#Eval("STATUS") %>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>--%>