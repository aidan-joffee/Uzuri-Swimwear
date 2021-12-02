<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="OrderMod.aspx.cs" Inherits="Uzuri_Swimwear.Forms.OrderMod" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        
        <div class="row">
           <h4>
        Orders
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

                <asp:TemplateField HeaderText="Bust line">
                    <ItemTemplate>
                        <asp:TextBox ID="bustLine" class="form-control form-control-lg" runat="server" CausesValidation="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ValidationExpression="^[1-9]\d*(.\d+)?$" runat="server" ControlToValidate="bustLine" ErrorMessage="Please enter details"></asp:RegularExpressionValidator>
                        <br />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="bustLine" ErrorMessage="Please enter details"></asp:RequiredFieldValidator>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Waist Line">
                    <ItemTemplate>
                        <asp:TextBox ID="waistLine" class="form-control form-control-lg" runat="server" CausesValidation="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ValidationExpression="^[1-9]\d*(.\d+)?$" runat="server" ControlToValidate="waistLine" ErrorMessage="Please enter details"></asp:RegularExpressionValidator>
                        <br />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="waistLine" ErrorMessage="Please enter details"></asp:RequiredFieldValidator>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Hip Line">
                    <ItemTemplate>
                        <asp:TextBox ID="hipLine" class="form-control form-control-lg" runat="server" CausesValidation="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ValidationExpression="^[1-9]\d*(.\d+)?$" runat="server" ControlToValidate="hipLine" ErrorMessage="Please enter details"></asp:RegularExpressionValidator>
                        <br />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="hipLine" ErrorMessage="Please enter details"></asp:RequiredFieldValidator>
                    </ItemTemplate>
                </asp:TemplateField>


            </Columns>
        </asp:GridView>

        <h4>
            Custom Requests
        </h4>
        <asp:GridView ItemType="Uzuri_Swimwear.Model.GetOrderRequests_Result" HeaderStyle-BackColor="#CAA557" ID="requestGridView" class="container" CssClass="table table-responsive table-hover" runat="server" AutoGenerateColumns="false">

            <Columns>

                <asp:TemplateField>
                    <ItemTemplate>
                         <img src='<%#GetImage(Container.DataItem)%>'  class="img-thumbnail"  id="imageCustReq" sortexpression="ImageReq">
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

                <asp:TemplateField HeaderText="Bust line">
                    <ItemTemplate>
                        <asp:TextBox ID="bustLine" class="form-control form-control-lg" runat="server" CausesValidation="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ValidationExpression="^[1-9]\d*(.\d+)?$" runat="server" ControlToValidate="bustLine" ErrorMessage="Please enter details"></asp:RegularExpressionValidator>
                        <br />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="waistLine" ErrorMessage="Please enter details"></asp:RequiredFieldValidator>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Waist Line">
                    <ItemTemplate>
                        <asp:TextBox ID="waistLine" class="form-control form-control-lg" runat="server" CausesValidation="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ValidationExpression="^[1-9]\d*(.\d+)?$" runat="server" ControlToValidate="waistLine" ErrorMessage="Please enter details"></asp:RegularExpressionValidator>
                        <br />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="waistLine" ErrorMessage="Please enter details"></asp:RequiredFieldValidator>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Hip Line">
                    <ItemTemplate>
                        <asp:TextBox ID="hipLine" class="form-control form-control-lg" runat="server" CausesValidation="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ValidationExpression="^[1-9]\d*(.\d+)?$" runat="server" ControlToValidate="hipLine" ErrorMessage="Please enter details"></asp:RegularExpressionValidator>
                        <br />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="hipLine" ErrorMessage="Please enter details"></asp:RequiredFieldValidator>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>

        <div class="row">
            <asp:Button ID="placeOrder" runat="server" class="btn btn-outline-primary" Text="Place Order" OnClick="placeOrder_Click" />
            <asp:Button ID="checkOut"  runat="server" class="btn btn-outline-primary" Text="Checkout" OnClick="checkOut_Click" />

    </div>

</asp:Content>
