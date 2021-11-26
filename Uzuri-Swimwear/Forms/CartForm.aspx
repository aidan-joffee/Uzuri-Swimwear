<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="CartForm.aspx.cs" Inherits="Uzuri_Swimwear.Forms.CartForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="body-flexbox">

        <!-- Products Card container-->
        <!-- Add fata from db-->

        <h3>Cart Items</h3>

        <asp:Label runat="server" ID="cartTotal"></asp:Label>

        <h5>Products</h5>



        <asp:ListView ItemType="Uzuri_Swimwear.Model.GetCartProducts_Result" runat="server" ID="listViewCartProducts" OnItemCommand="listViewCartProducts_ItemCommand">

            <LayoutTemplate>
                <table>
                    <tr>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    </tr>
                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <td>

                    <div class="card text-center" style="width: 12rem;">

                        <div class="card-body">

                            <img src='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("IMAGE_DATA")) %>' class="card-img-top" style="width: 7rem; height: 8rem;">

                            <h5 class="card-title"><%#Eval("NAME")%></h5>

                            <p class="card-text">R<%#Eval("PRICE")%></p>

                            <asp:Label runat="server" ID="CartProdId"><%#Eval("CART_PROD_ID")%></asp:Label>

                            <div class="card-button-flex">
                                <div class="card-button-flex">
                                    <asp:Button ID="Button1" runat="server" Text="Remove" CommandName="Remove" CommandArgument='<%#Eval("CART_PROD_ID")%>' ></asp:Button>
                                </div>
                                
                            </div>

                        </div>
                    </div>
                </td>
            </ItemTemplate>

        </asp:ListView>

        <h5>Customer Requests</h5>

        <asp:ListView ItemType="Uzuri_Swimwear.Model.GetCartCustomerRequests_Result" runat="server" ID="listViewCartCustRequest">

            <LayoutTemplate>
                <table>
                    <tr>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    </tr>
                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <td>

                    <div class="card text-center" style="width: 12rem">

                        <div class="card-body">

                            <img src='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("IMAGE_DATA")) %>' class="card-img-top" style="width: 7rem; height: 8rem;">

                            <h5 class="card-title"><%#Eval("DESCRIPTION")%></h5>

                            <p class="card-text">R<%#Eval("PRICE")%></p>

                            <div class="card-button-flex">
                                <button type="button" class="btn btn-danger">Remove</button>
                            </div>

                        </div>
                    </div>
                </td>
            </ItemTemplate>

        </asp:ListView>

    </div>

</asp:Content>
