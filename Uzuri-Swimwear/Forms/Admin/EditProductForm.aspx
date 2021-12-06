<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="EditProductForm.aspx.cs" Inherits="Uzuri_Swimwear.Forms.EditProductForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="background-color:white">
        <!--HEADING -->
        <div id="addProduct" class="rounded">
            <div class="row align-items-center">

                <h4>Product List</h4>
                <p class="text-muted">
                    Use this page to view your products. If you would like to add a new product you can
                        do so using the <a href="AddProductForm.aspx" class="text-decoration-none">Add Products</a> page.
                </p>

            </div>
            <hr />

            <!--PRODUCT TABLE -->
            <div class="row">
                <div class="rounded-2">
                    <asp:GridView ID="ProductGridView" runat="server"
                        CssClass="table table-responsive table-hover"
                        HeaderStyle-BackColor="#CAA557"
                        ItemType="Uzuri_Swimwear.Model.GetAllProductsDetails_Result"
                        AutoGenerateColumns="false"
                        GridLines="None"
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
                                    <br />
                                    <asp:RequiredFieldValidator runat="server"
                                        ControlToValidate="ProdNameBox"
                                        ErrorMessage="A product name must be entered."
                                        Display="Dynamic"
                                        ForeColor="Red">
                                    </asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <%#Eval("DESCRIPTION")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="ProdDescBox" Text='<%#Eval("DESCRIPTION")%>'>
                                    </asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator runat="server"
                                        ControlToValidate="ProdDescBox"
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

                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" CommandName="EditRow" class="btn btn-outline-dark" CausesValidation="false">
                                    <i class="bi bi-pen"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton runat="server" CommandArgument='<%#Eval("PRODUCT_ID")%>' CommandName="UpdateRow" class="btn btn-outline-dark">
                                    <i class="bi bi-check-circle"></i>
                                    </asp:LinkButton>
                                    <asp:LinkButton runat="server" CommandName="CancelRow" class="btn btn-outline-dark" CausesValidation="false">
                                    <i class="bi bi-x-circle"></i>
                                    </asp:LinkButton>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Images">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" class="btn btn-outline-dark" CommandArgument='<%#Eval("PRODUCT_ID")%>' CommandName="SelectRow" CausesValidation="false">
                                    <i class="bi bi-images"></i>
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
                </div>
            </div>

            <!--Image TABLE -->
            <div class="row">
                <h4>Product Images</h4>
            </div>

            <asp:Label runat="server" Text="No Product Selected" CssClass="text-primary" ID="ProdIDLbl" />

            <div class="row">
                <div class="col-md-6">
                    <h5>Image List</h5>
                    <asp:Label runat="server" Text="" ID="EditImageErrorLbl" />
                    <asp:GridView
                        runat="server"
                        ID="ImageGridView"
                        GridLines="None"
                        ItemType="Uzuri_Swimwear.Model.GetProductImages_Result"
                        AutoGenerateColumns="false"
                        CssClass="table-sm table-responsive table-hover"
                        OnRowCommand="ImageGridView_RowCommand"
                        HeaderStyle-BackColor="#CAA557">
                        <Columns>
                            <asp:BoundField DataField="IMAGE_ID" HeaderText="ID" ReadOnly="true" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Image
                                        runat="server"
                                        ImageUrl='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("IMAGE_DATA")) %>'
                                        class="img-responsive img-rounded"
                                        Style="max-height: 150px; max-width: 150px;"></asp:Image>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Primary">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ImagePrimary" runat="server" Enabled="false" Checked='<%#Eval("IMAGE_PRIMARY")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" CommandArgument='<%#Eval("IMAGE_ID") %>' CommandName="DeleteImage" CssClass="btn btn-outline-dark" CausesValidation="false">
                                    <i class="bi bi-x-circle"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Set-Primary">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" CommandArgument='<%#Eval("IMAGE_ID") %>' CommandName="SetPrimary" CssClass="btn btn-outline-dark" CausesValidation="false">
                                    <i class="bi bi-image"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <p class="text-muted">
                                No images found or product not selected. Use the image icon from the product list above
                            to view a product's images.
                            </p>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>

                <div class="col-md-6">
                    <h5>Add an Image</h5>
                    <p class="text-muted">Use the upload below to add an image to a selected product. </p>
                    <asp:FileUpload runat="server" ID="AddProdImage" />
                    <br />
                    <asp:RegularExpressionValidator
                        runat="server"
                        ControlToValidate="AddProdImage"
                        ValidationExpression="(.*png$)|(.*jpg$)|(.*jpeg$)|(.*JPG$)|(.*JPEG$)|(.*gif$)|(.*PNG$)"
                        ErrorMessage="Can only accept image files."
                        ForeColor="red">
                    </asp:RegularExpressionValidator>
                    <br />
                    <asp:Button runat="server" ID="UploadImageBtn" CssClass="btn btn-outline-dark" Text="Upload Image" OnClick="UploadImageBtn_Click" />
                    <asp:Label ID="AddImageErrorLbl" runat="server" ForeColor="red"></asp:Label>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
