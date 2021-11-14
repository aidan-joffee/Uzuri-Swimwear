<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="ProductForm.aspx.cs" Inherits="Uzuri_Swimwear.Forms.ProductForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <!--HEADING -->
        <div id="addProduct" class="container">
            <div class="row align-items-center">
                <div class="col">
                    <h4>Product List</h4>
                </div>
                <div class="col">
                </div>
            </div>

            <!--PRODUCT TABLE -->
            <div class="row align-items-start">
                <asp:GridView ID="ProductGridView" runat="server"
                    CssClass="table table-striped table-hover"
                    ItemType="Uzuri_Swimwear.GetAllProductsDetails_Result"
                    AutoGenerateColumns="false"
                    
                    SelectMethod="GetProducts"
                    UpdateMethod="">
                    <Columns>
                        <asp:DynamicField DataField="PRODUCT_ID" HeaderText="ID" readonly ="true"/>
                        <asp:DynamicField DataField="NAME" HeaderText="Name" />
                        <asp:DynamicField DataField="PRICE" HeaderText="Price" />
                        <asp:DynamicField DataField="FOR_SALE" HeaderText="For Sale" />
                        <asp:TemplateField HeaderText="Category ID" >
                            <ItemTemplate>
                                <%#Eval("CATEGORY") %>                                 
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList 
                                    ID="CategoryDropList"
                                    selectmethod="GetCategories"
                                    runat="server"                                    
                                    DataTextField="NAME"
                                    DataValueField="CATEGORY_ID">
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton runat="server" CommandName="Edit" class="btn btn-light">
                                    <i class="bi bi-pen"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton runat="server" Text="Update" CommandName="Update" class="btn btn-light">
                                    <i class="bi bi-check-circle"></i>
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" Text="Cancel" CommandName="Cancel" class="btn btn-light">
                                    <i class="bi bi-x-circle"></i>
                                </asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
