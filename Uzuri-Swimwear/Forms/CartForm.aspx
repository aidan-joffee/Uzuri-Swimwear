<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="CartForm.aspx.cs" Inherits="Uzuri_Swimwear.Forms.CartForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .d-table {
            display: table;
        }

        .d-table-cell {
            display: table-cell;
        }

        .w-100 {
            width: 100%;
        }

        .tar {
            text-align: right;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div >
        <div class="container" style="padding-bottom: 25px; padding-top: 1%;" >
            <div class="body-flexbox">

                <!-- Products Card container-->
                <!-- Add fata from db-->
                <div class="d-table w-100">
                    <h3 style="color:white">Your Cart Items</h3>
                    <div class="d-table-cell tar">
                        <asp:Button runat="server" ID="Button2" OnClick="CheckOutBtn_Click" Style="background-color: gold; color: black;" Text="Proceed to checkout" />
                    </div>
                </div>

                

                <asp:Label runat="server" ID="cartTotal" style="color:white"></asp:Label>

                <h5 style="color:white">Products</h5>



                <asp:ListView ItemType="Uzuri_Swimwear.Model.GetCartProducts_Result" runat="server" ID="listViewCartProducts" OnItemCommand="DeleteProductFromCart">

                    <LayoutTemplate>
                        <table>
                            <tr>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                            </tr>
                        </table>
                    </LayoutTemplate>

                    <EmptyDataTemplate>
                        <p style="color:white">You have no standard products in your cart</p>
                    </EmptyDataTemplate>

                    <ItemTemplate>
                        <td>

                            <div class="card text-center" style="width: 12rem;">

                                <div class="card-body">

                                    <img src='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("IMAGE_DATA")) %>' class="card-img-top">

                                    <h5 class="card-title"><%#Eval("NAME")%></h5>

                                    <p class="card-text">R<%#Eval("PRICE")%></p>


                                    <div class="card-button-flex">
                                        <div class="card-button-flex">
                                            <asp:Button ID="Button1" CssClass="btn btn-outline-dark" runat="server" Text="Remove" CommandName="Remove" CommandArgument='<%#Eval("CART_PROD_ID")%>'></asp:Button>
                                        </div>

                                    </div>

                                </div>
                            </div>
                        </td>
                    </ItemTemplate>

                </asp:ListView>

                <h5 style="padding-top: 10px; padding-bottom: 10px; color:white;">Customer Requests</h5>

                <asp:ListView ItemType="Uzuri_Swimwear.Model.GetCartCustomerRequests_Result" runat="server" ID="listViewCartCustRequest" OnItemCommand="DeleteRequestFromCart" onrowdatabound="ImageCheck">

                    <LayoutTemplate>
                        <table>
                            <tr>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                            </tr>
                        </table>
                    </LayoutTemplate>

                    <EmptyDataTemplate >
                        <p style="color:white">You have no custom requests in your cart</p>
                    </EmptyDataTemplate>


                    <ItemTemplate>
                        <td>

                            <div class="card text-center" style="width: 12rem">

                                <div class="card-body">

                                    <img src='<%#GetImage(Container.DataItem)%>' class="card-img-top" style="max-height: 200px; max-width: 200px;" id="imageCustReq" />

                                    <h5 class="card-title" style="padding-top: 5px;"><%#Eval("DESCRIPTION")%></h5>

                                    <p class="card-text">COLOUR: <%#Eval("COlOUR")%></p>

                                    <p class="card-text">PATTERN: <%#Eval("PATTERN")%></p>

                                    <p class="card-text">R<%#Eval("PRICE")%></p>

                                    <div class="card-button-flex">
                                        <asp:Button ID="Button1" CssClass="btn btn-outline-dark" runat="server" Text="Remove" CommandName="Remove" CommandArgument='<%#Eval("CART_REQ_ID")%>'></asp:Button>
                                    </div>

                                </div>
                            </div>
                        </td>
                    </ItemTemplate>

                </asp:ListView>




            </div>
        </div>
    </div>
</asp:Content>
