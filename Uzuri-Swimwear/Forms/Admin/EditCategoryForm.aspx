<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="EditCategoryForm.aspx.cs" Inherits="Uzuri_Swimwear.Forms.Admin.EditCategoryForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <h4>Edit Categories</h4>
            <p class="text-muted">Use this page to add and edit categories</p>
        </div>
        <div class="row">
            <div class="col-6 col-sm-6">
                <asp:GridView
                    runat="server"
                    CssClass="table table-responsive table-hover"
                    HeaderStyle-BackColor="#CAA557"
                    ItemType="Uzuri_Swimwear.Model.GetAllCategories_Result"
                    ID="CategoryGridView"
                    AutoGenerateColumns="False"
                    GridLines="None"
                    AllowPaging="true"
                    PageSize="10"
                    OnPageIndexChanging="CategoryGridView_PageIndexChanging"
                    OnRowCommand="CategoryGridView_RowCommand"
                    DataKeyNames="CATEGORY_ID">
                    <Columns>
                        <asp:DynamicField DataField="CATEGORY_ID" HeaderText="ID" ReadOnly="true" />
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%#Eval("NAME")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="CatNameBox" Text='<%#Eval("NAME")%>'>
                                </asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator runat="server"
                                    ControlToValidate="CatNameBox"
                                    ErrorMessage="A category name must be entered."
                                    Display="Dynamic"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Price">
                            <ItemTemplate>
                                R<%#Eval("PRICE")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="CatPriceBox" Text='<%#Eval("PRICE")%>'>
                                </asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator runat="server"
                                    ControlToValidate="CatPriceBox"
                                    ErrorMessage="A category price must be entered."
                                    Display="Dynamic"
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator
                                    ValidationExpression="^\d{1,3}(\,\d{2})?$"
                                    runat="server"
                                    ControlToValidate="CatPriceBox"
                                    ErrorMessage="Must be a currency in the correct format"
                                    ForeColor="red">
                                </asp:RegularExpressionValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" CommandName="EditRow" class="btn btn-outline-dark" CausesValidation="false">
                                    <i class="bi bi-pen"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton runat="server" CommandArgument='<%#Eval("CATEGORY_ID")%>' CommandName="UpdateRow" class="btn btn-outline-dark">
                                    <i class="bi bi-check-circle"></i>
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" CommandName="CancelRow" class="btn btn-outline-dark" CausesValidation="false">
                                    <i class="bi bi-x-circle"></i>
                                </asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" CommandArgument='<%#Eval("CATEGORY_ID") %>' 
                                    CommandName="DeleteRow" 
                                    CssClass="btn btn-outline-dark" 
                                    CausesValidation="false"
                                    OnClientClick="return DeleteConfirmation();">
                                    <i class="bi bi-x-circle"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>


                    </Columns>
                    <EmptyDataTemplate>
                        <p class="text-muted">
                            No products are current stored. Use the Add Products page to create a new product.
                        </p>
                    </EmptyDataTemplate>
                </asp:GridView>

                <script type="text/javascript" language="javascript">
                    function DeleteConfirmation() {
                        if (confirm("Are you sure you want to delete this category?") == true)
                            return true;
                        else
                            return false;
                    }
                </script>

            </div>
            <div class="col-6 col-sm-6">
                <div class="card">
                    <div class="card-header">
                        <h6>Create a category</h6>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <label>Name:</label>
                            <br />
                            <asp:TextBox runat="server" CssClass="form-control" ID="CategoryName"></asp:TextBox>
                        </div>
                        <div class="row">
                            <label>Price:</label>
                            <br />
                            <asp:TextBox CssClass="form-control" runat="server" ID="CategoryPrice"></asp:TextBox>
                            <asp:RegularExpressionValidator
                                ValidationExpression="^\d{1,3}(\,\d{2})?$"
                                runat="server"
                                ControlToValidate="CategoryPrice"
                                ErrorMessage="Must be a currency in the correct format"
                                ForeColor="red">
                            </asp:RegularExpressionValidator>
                        </div>
                        <div class="row">
                            <asp:Button runat="server" ID="AddCategoryBtn" Text="Create" CssClass="btn btn-outline-dark" OnClick="AddCategoryBtn_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
