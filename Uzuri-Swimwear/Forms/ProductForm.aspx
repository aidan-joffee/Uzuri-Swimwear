﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="ProductForm.aspx.cs" Inherits="Uzuri_Swimwear.Forms.ProductForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <!--HEADING -->
        <div id="addProduct" class="rounded">
            <div class="row align-items-center">
                <div class="col">
                    <h4>Product List</h4>
                </div>
                <div class="col">
                </div>
            </div>


            <!--PRODUCT TABLE -->
            <div class="row">
                <asp:GridView ID="ProductGridView" runat="server"
                    CssClass="table table-responsive table-hover"
                    HeaderStyle-BackColor="#CAA557"
                    ItemType="Uzuri_Swimwear.Model.GetAllProductsDetails_Result"
                    AutoGenerateColumns="false"
                    AllowPaging="true"
                    PageSize="10"
                    OnPageIndexChanging="ProductGridView_PageIndexChanging"
                    OnRowCommand="ProductGridView_RowCommand"
                    DataKeyNames="PRODUCT_ID">
                    <Columns>
                        <asp:DynamicField DataField="PRODUCT_ID" HeaderText="ID" ReadOnly="true" />
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%#Eval("NAME")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="ProdNameBox" Text='<%#Eval("NAME")%>'>
                                </asp:TextBox>
                                <asp:RequiredFieldValidator runat="server"
                                    ControlToValidate="ProdNameBox"
                                    ErrorMessage="A product name must be entered."
                                    Display="Dynamic"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%#Eval("DESCRIPTION")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="ProdDescBox" Text='<%#Eval("DESCRIPTION")%>'>
                                </asp:TextBox>
                                <asp:RequiredFieldValidator runat="server"
                                    ControlToValidate="ProdNameBox"
                                    ErrorMessage="A product description must be entered."
                                    ForeColor="Red"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="For Sale">
                            <ItemTemplate>
                                <asp:CheckBox ID="ProdForSale" runat="server" Enabled="false" Checked='<%#Eval("FOR_SALE")%>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="ProdForSale" runat="server" Checked='<%#Eval("FOR_SALE")%>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Category">
                            <ItemTemplate>
                                <%#Eval("CATEGORY") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList
                                    ID="CategoryDropList"
                                    SelectMethod="GetCategories"
                                    runat="server"
                                    DataTextField="NAME"
                                    DataValueField="CATEGORY_ID"
                                    SelectedValue='<%#Eval("CATEGORY_ID")%>'>
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton runat="server" CommandName="EditRow" class="btn btn-light" CausesValidation="false">
                                    <i class="bi bi-pen"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton runat="server" CommandArgument='<%#Eval("PRODUCT_ID")%>' CommandName="UpdateRow" class="btn btn-light">
                                    <i class="bi bi-check-circle"></i>
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" CommandName="CancelRow" class="btn btn-light" CausesValidation="false">
                                    <i class="bi bi-x-circle"></i>
                                </asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton runat="server" class="btn btn-light" CommandArgument='<%#Eval("PRODUCT_ID")%>' CommandName="SelectRow" CausesValidation="false">
                                    <i class="bi bi-images"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

            <!--Image TABLE -->
            <div class="row">
                <div class="row align-items-center">
                    <div class="col">
                        <h4>Product Images</h4>
                    </div>
                    <div class="col">
                    </div>
                </div>               
            </div>

            <div class="row">
                <asp:GridView
                    runat="server"
                    ID="ImageGridView"
                    >
                    <EmptyDataTemplate>
                        No images found or product not selected.
                    </EmptyDataTemplate>
                    <Columns>  
                        <asp:BoundField DataField="ImageId" HeaderText="ImageId" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
