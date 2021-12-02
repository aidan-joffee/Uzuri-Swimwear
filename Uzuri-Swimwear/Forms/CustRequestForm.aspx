<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeFile="CustRequestForm.aspx.cs" Inherits="Uzuri_Swimwear.Forms.CustRequestForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <h4 style="padding-top: 5px; padding-bottom: 2px;">Create a Custom Request</h4>
        </div>
        <div class="row">
            <div class="col col-sm-7">
                <div id="AddProdForm" class="card">
                    <div class="card-body">
                        <div class="mb-3">
                            <label for="Description">Description:</label>
                            <asp:TextBox runat="server"
                                ID="Description"
                                CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                ControlToValidate="Description"
                                ValidationGroup="CustRequest"
                                ErrorMessage="Enter Your Description Please."
                                runat="Server" Font-Bold="True">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="mb-3">
                            <label for="Colour">Colour:</label>
                            <asp:TextBox runat="server"
                                ID="Colour"
                                CssClass="form-control"
                                TextMode="MultiLine"
                                MaxLength="255"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                ControlToValidate="Colour"
                                ValidationGroup="CustRequest"
                                ErrorMessage="Enter Your Colour Please."
                                runat="Server" Font-Bold="True">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="mb-3">
                            <label for="Pattern">Pattern:</label>
                            <asp:TextBox runat="server"
                                ID="Pattern"
                                CssClass="form-control"
                                TextMode="MultiLine"
                                MaxLength="255"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                ControlToValidate="Pattern"
                                ValidationGroup="CustRequest"
                                ErrorMessage="Enter Your Pattern Please."
                                runat="Server" Font-Bold="True">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="mb3">
                            <label for="CategoryDropList">Your selected Image:</label>
                        </div>
                        <div class="mb3">
                            <p class="text-muted">
                                1 images can be uploaded but is not required. Only file types of .jpg, .png , .jpeg or .gif are accepted.                     
                            </p>
                            <asp:FileUpload ID="AddProdImage" runat="server" ValidationGroup="ProdImageValidation" CausesValidation="true" />
                            <br />
                            <asp:RegularExpressionValidator
                                runat="server"
                                ControlToValidate="AddProdImage"
                                ValidationExpression="(.*png$)|(.*jpg$)|(.*jpeg$)"
                                ErrorMessage="Can only accept image files."
                                ForeColor="red">
                            </asp:RegularExpressionValidator>
                            <br />
                        </div>
                        <div class="mb3">
                            <asp:Button CssClass="btn btn-outline-dark" runat="server" OnClick="AddRequestButton_Click" ID="AddRequestButton" Text="Submit" ValidationGroup="CustRequest" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <h4 style="padding-top: 5px; padding-bottom: 2px;">Your saved Custom Requests</h4>
        </div>
        <asp:ListView ItemType="Uzuri_Swimwear.Model.GetUserCustomRequests_Result" runat="server" ID="listViewCartCustRequest" OnItemCommand="listViewCartCustRequest_ItemCommand" onrowdatabound="ImageCheck">

            <LayoutTemplate>
                <table>
                    <tr>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    </tr>
                </table>
            </LayoutTemplate>

            <EmptyDataTemplate>
                <p>You have no custom requests currently</p>
            </EmptyDataTemplate>


            <ItemTemplate>
                <td>

                    <div class="card text-center" style="width: 12rem">

                        <div class="card-body">

                            <img src='<%#GetImage(Container.DataItem)%>' class="card-img-top" style="width: 7rem; height: 8rem;" id="imageCustReq" sortexpression="ImageReq">

                            <h5 class="card-title" style="padding-top: 5px;"><%#Eval("DESCRIPTION")%></h5>

                            <p class="card-text">COLOUR: <%#Eval("COlOUR")%></p>

                            <p class="card-text">PATTERN: <%#Eval("PATTERN")%></p>

                            <div class="card-button-flex">
                                <asp:Button ID="Button1" CssClass="btn btn-outline-dark" runat="server" Text="Add To Cart" CommandName="ToCart" CommandArgument='<%#Eval("CUST_REQ_ID")%>'></asp:Button>
                            </div>

                        </div>
                    </div>
                </td>
            </ItemTemplate>

        </asp:ListView>

    </div>
</asp:Content>