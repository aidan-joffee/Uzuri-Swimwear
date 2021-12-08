<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="OrderMod.aspx.cs" Inherits="Uzuri_Swimwear.Forms.OrderMod" %>

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

    <div class="container" style="padding-bottom: 50px">
        <div class="row">
            <div class="col-9">
                <div class="home-content">
                    <div class="body-flexbox" style="background-color: white">
                        <br />
                        <div class="row">
                            <h4>Orders
                            </h4>
                        </div>


                        <asp:Label runat="server" CssClass="text-danger" ID="responseLbl"></asp:Label>

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
                                        <asp:TextBox ID="bustLine" class="form-control form-control-lg" runat="server" CausesValidation="true"></asp:TextBox>
                                        <asp:RegularExpressionValidator ValidationExpression="^[1-9]\d*(.\d+)?$" runat="server" ControlToValidate="bustLine" ErrorMessage="Please enter positive numeric values only"></asp:RegularExpressionValidator>
                                        <br />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="bustLine" ErrorMessage="Please enter your sizing details"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Waist Line (Cm)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="waistLine" class="form-control form-control-lg" runat="server" CausesValidation="true"></asp:TextBox>
                                        <asp:RegularExpressionValidator ValidationExpression="^[1-9]\d*(.\d+)?$" runat="server" ControlToValidate="waistLine" ErrorMessage="Please enter positive numeric values only"></asp:RegularExpressionValidator>
                                        <br />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="waistLine" ErrorMessage="Please enter your sizing details"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Hip Line (Cm)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="hipLine" class="form-control form-control-lg" runat="server" CausesValidation="true"></asp:TextBox>
                                        <asp:RegularExpressionValidator ValidationExpression="^[1-9]\d*(.\d+)?$" runat="server" ControlToValidate="hipLine" ErrorMessage="Please enter positive numeric values only"></asp:RegularExpressionValidator>
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
                                        <img src='<%#GetImage(Container.DataItem)%> ' style="max-height: 200px; max-width: 200px;" />
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
                                        <asp:RegularExpressionValidator ValidationExpression="^[1-9]\d*(.\d+)?$" runat="server" ControlToValidate="bustLine" ErrorMessage="Please enter positive numeric values only"></asp:RegularExpressionValidator>
                                        <br />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="waistLine" ErrorMessage="Please enter your sizing details"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Waist Line (Cm)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="waistLine" class="form-control form-control-lg" runat="server" CausesValidation="true"></asp:TextBox>
                                        <asp:RegularExpressionValidator ValidationExpression="^[1-9]\d*(.\d+)?$" runat="server" ControlToValidate="waistLine" ErrorMessage="Please enter positive numeric values only"></asp:RegularExpressionValidator>
                                        <br />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="waistLine" ErrorMessage="Please enter your sizing details"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Hip Line (Cm)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="hipLine" class="form-control form-control-lg" runat="server" CausesValidation="true"></asp:TextBox>
                                        <asp:RegularExpressionValidator ValidationExpression="^[1-9]\d*(.\d+)?$" runat="server" ControlToValidate="hipLine" ErrorMessage="Please enter positive numeric values only"></asp:RegularExpressionValidator>
                                        <br />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="hipLine" ErrorMessage="Please enter your sizing details"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>

                       
                    </div>
                </div>
                <div class="row">
                            <asp:Button ID="placeOrder" runat="server" class="btn btn-outline-primary" Text="Place Order" OnClick="placeOrder_Click" />
                        </div>
            </div>
            <div class="col-3">
                <asp:Image runat="server" Style="padding-top: 10px;" ImageUrl="\Images\BustWaistHip.png" Width="75%" Height="75%" CssClass="img-thumbnail" alt="Responsive image"></asp:Image>
            </div>
        </div>
    </div>

</asp:Content>
