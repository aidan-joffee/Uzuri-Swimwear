<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="OrderMod.aspx.cs" Inherits="Uzuri_Swimwear.Forms.OrderMod" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .home-content {
            text-align: center;
            margin-left: 2.5%;
            margin-right: 2.5%;
        }

        .body-flexbox {
            flex-wrap: wrap;
            overflow: visible;
            justify-content: space-around;
        }

        .right-Image {
            float: right;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
        <div class="container">
            <div class="right-Image">
                <div class="col-3">
                    <asp:Image runat="server" ImageUrl="\Images\BustWaistHip.png" Width="300%" Height="300%" alt="Responsive image"></asp:Image>
                </div>
            </div>
            <div class="col-9">
                <div class="home-content">
                    <div class="body-flexbox">
                        <br />
                        <div class="row">
                            <h4>Orders
                            </h4>
                        </div>
                        <asp:GridView ItemType="Uzuri_Swimwear.Model.GetOrderProducts_Result" HeaderStyle-BackColor="#CAA557" ID="productGridView" class="container" CssClass="table table-responsive table-hover" runat="server" AutoGenerateColumns="false">

                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Image
                                            runat="server"
                                            ImageUrl='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("IMAGE_DATA"))%>'
                                            class="img-thumbnail"></asp:Image>
                                    </ItemTemplate>
                                </asp:TemplateField>



                                <asp:TemplateField HeaderText="Item">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%#Eval("PRODUCT_ID")%>' ID="productID" />
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:DynamicField DataField="NAME" HeaderText="Name" />

                                <asp:TemplateField HeaderText="Price">
                                    <ItemTemplate>
                                        <p class="card-text">R<%#Eval("PRICE")%></p>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Bust line (Cm)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="bustLine" CssClass="form-control form-control-lg" runat="server" CausesValidation="true"></asp:TextBox>
                                        <asp:RegularExpressionValidator ValidationExpression="^-?[0-9]\d*(\.\d+)?$" runat="server" ControlToValidate="bustLine" ErrorMessage="Please enter positive numeric values only"></asp:RegularExpressionValidator>
                                        <br />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="bustLine" ErrorMessage="Please enter your sizing details"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Waist Line (Cm)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="waistLine" class="form-control form-control-lg" runat="server" CausesValidation="true"></asp:TextBox>
                                        <asp:RegularExpressionValidator ValidationExpression="^-?[0-9]\d*(\.\d+)?$" runat="server" ControlToValidate="waistLine" ErrorMessage="Please enter positive numeric values only"></asp:RegularExpressionValidator>
                                        <br />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="waistLine" ErrorMessage="Please enter your sizing details"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Hip Line (Cm)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="hipLine" class="form-control form-control-lg" runat="server" CausesValidation="true"></asp:TextBox>
                                        <asp:RegularExpressionValidator ValidationExpression="^-?[0-9]\d*(\.\d+)?$" runat="server" ControlToValidate="hipLine" ErrorMessage="Please enter positive numeric values only"></asp:RegularExpressionValidator>
                                        <br />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="hipLine" ErrorMessage="Please enter your sizing details"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>


                            </Columns>
                        </asp:GridView>

                        <h4>Custom Requests
                        </h4>
                        <asp:GridView ItemType="Uzuri_Swimwear.Model.GetOrderRequests_Result" HeaderStyle-BackColor="#CAA557" ID="requestGridView" class="container" CssClass="table table-responsive table-hover" runat="server" AutoGenerateColumns="false">

                            <Columns>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <img src='<%#GetImage(Container.DataItem)%>' class="img-thumbnail" id="imageCustReq" sortexpression="ImageReq">
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Item">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%#Eval("CUST_REQ_ID")%>' ID="custReqID" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:DynamicField DataField="DESCRIPTION" HeaderText="Description" />

                                <asp:TemplateField HeaderText="Price">
                                    <ItemTemplate>
                                        <p class="card-text">R<%#Eval("PRICE")%></p>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Bust line (Cm)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="bustLine" class="form-control form-control-lg" runat="server" CausesValidation="true"></asp:TextBox>
                                        <asp:RegularExpressionValidator ValidationExpression="^-?[0-9]\d*(\.\d+)?$" runat="server" ControlToValidate="bustLine" ErrorMessage="Please enter positive numeric values only"></asp:RegularExpressionValidator>
                                        <br />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="waistLine" ErrorMessage="Please enter your sizing details"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Waist Line (Cm)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="waistLine" class="form-control form-control-lg" runat="server" CausesValidation="true"></asp:TextBox>
                                        <asp:RegularExpressionValidator ValidationExpression="^-?[0-9]\d*(\.\d+)?$" runat="server" ControlToValidate="waistLine" ErrorMessage="Please enter positive numeric values only"></asp:RegularExpressionValidator>
                                        <br />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="waistLine" ErrorMessage="Please enter your sizing details"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Hip Line (Cm)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="hipLine" class="form-control form-control-lg" runat="server" CausesValidation="true"></asp:TextBox>
                                        <asp:RegularExpressionValidator ValidationExpression="^-?[0-9]\d*(\.\d+)?$" runat="server" ControlToValidate="hipLine" ErrorMessage="Please enter positive numeric values only"></asp:RegularExpressionValidator>
                                        <br />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="hipLine" ErrorMessage="Please enter your sizing details"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                        <div class="row">
                            <div class="home-content">
                                <asp:Button ID="placeOrder" runat="server" class="btn btn-outline-secondary" Text="Place Order" Width="20%" OnClick="placeOrder_Click" />
                                <br />
                                <asp:Button ID="checkOut" runat="server" class="btn btn-outline-primary" Text="Checkout" Width="20%" OnClick="checkOut_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
