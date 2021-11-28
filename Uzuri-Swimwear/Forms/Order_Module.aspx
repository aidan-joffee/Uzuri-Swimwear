<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="Order_Module.aspx.cs" Inherits="Uzuri_Swimwear.Forms.Order_Module" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <head>
        <style>
            .centerTxt {
                margin: 0;
                position: absolute;
                top: 45%;
                left: 50%;
                -ms-transform: translate(-50%, -50%);
                transform: translate(-50%, -50%);
            }
        </style>
        <style>
            .centerBtn {
                margin: 0;
                position: absolute;
                top: 80%;
                left: 50%;
                -ms-transform: translate(-50%, -50%);
                transform: translate(-50%, -50%);
            }
        </style>
    </head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="centerTxt">
        <asp:GridView ItemType="Uzuri_Swimwear.Model.GetOrder_Result" ID="orderGridView" class="container" CssClass="table table-responsive table-hover" runat="server" AutoGenerateColumns="false">

            <Columns>
                <asp:TemplateField HeaderText="Item">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("PRODUCT_ID")%>' ID="productID" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:DynamicField DataField="NAME" HeaderText="Name" />

                <asp:DynamicField DataField="PRICE" HeaderText="Price" />

                <asp:TemplateField HeaderText="Bust line">
                    <ItemTemplate>
                        <asp:TextBox ID="bustLine" class="form-control form-control-lg" runat="server" CausesValidation="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ValidationExpression="^[1-9]\d*(.\d+)?$" runat="server" ControlToValidate="bustLine" ErrorMessage="Please enter details"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="hipLine" ErrorMessage="Please enter details"></asp:RequiredFieldValidator>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Waist Line">
                    <ItemTemplate>
                        <asp:TextBox ID="waistLine" class="form-control form-control-lg" runat="server" CausesValidation="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ValidationExpression="^[1-9]\d*(.\d+)?$" runat="server" ControlToValidate="waistLine" ErrorMessage="Please enter details"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="hipLine" ErrorMessage="Please enter details"></asp:RequiredFieldValidator>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Hip Line">
                    <ItemTemplate>
                        <asp:TextBox ID="hipLine" class="form-control form-control-lg" runat="server" CausesValidation="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ValidationExpression="^[1-9]\d*(.\d+)?$" runat="server" ControlToValidate="hipLine" ErrorMessage="Please enter details"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="hipLine" ErrorMessage="Please enter details"></asp:RequiredFieldValidator>
                    </ItemTemplate>
                </asp:TemplateField>


            </Columns>
        </asp:GridView>
    </div>

    <div class="centerBtn">
        <asp:Button ID="placeOrder" runat="server" class="btn btn-outline-primary" Text="Place Order" OnClick="placeOrder_Click" />
    </div>

</asp:Content>
