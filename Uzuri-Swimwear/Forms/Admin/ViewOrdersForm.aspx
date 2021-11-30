﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="ViewOrdersForm.aspx.cs" Inherits="Uzuri_Swimwear.Forms.Admin.ViewOrdersForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/OrderFormStyle.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <h4>View Orders</h4>
            <p class="text-muted">Use this page to manage orders and view order details, such as delivery information and order items.</p>
        </div>

        <div class="row">
            <div class="col-12 col-sm-6">
                <div class="mb-3">
                    <p class="form-label">Start Date:</p>
                    <asp:TextBox runat="server" CssClass="form-control" TextMode="Date" ID="startDatePicker"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                        runat="server"
                        ControlToValidate="startDatePicker"
                        ErrorMessage="Start date required"
                        ForeColor="red"
                        ValidationGroup="SearchValidation"></asp:RequiredFieldValidator>
                </div>
                <div class="mb-3">
                    <p class="form-label">End Date:</p>
                    <asp:TextBox runat="server" CssClass="form-control" TextMode="Date" ID="endDatePicker"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                        runat="server"
                        ControlToValidate="endDatePicker"
                        ErrorMessage="End date required"
                        ForeColor="red"
                        ValidationGroup="SearchValidation"></asp:RequiredFieldValidator>
                </div>
                <div class="mb-3">
                    <p class="form-label">Status</p>
                    <asp:DropDownList
                        runat="server"
                        CssClass="form-select"
                        ID="SearchStatusDropDown"
                        SelectMethod="GetOrderStatus"
                        DataTextField="STATUS"
                        Enabled="false"
                        DataValueField="ORDER_STATUS_ID">
                    </asp:DropDownList>
                    <asp:CheckBox ID="SearchByAll" Checked="true" runat="server" Text="Search by all statuses" OnCheckedChanged="SearchByAll_CheckedChanged" AutoPostBack="true" />
                </div>
                <div class="mb-3">
                    <br />
                    <asp:Button runat="server" CssClass="btn btn-outline-dark" Text="Search" ID="SearchBtn" OnClick="SearchBtn_Click" ValidationGroup="SearchValidation" />
                </div>
            </div>
            <div class="col-12 col-sm-6">
                <p class="text-muted">Use this form to search for orders between a specific date range, or by status. 
                    Click on the clipboard icon on an order to view order information.
                </p>
            </div>
        </div>

        <!--Order list-->
        <div class="row">
            <h4>Order List</h4>
            <asp:GridView ID="OrderGridView" runat="server"
                CssClass="table table-responsive table-hover"
                HeaderStyle-BackColor="#CAA557"
                ItemType="Uzuri_Swimwear.Model.GetAllOrders_Result"
                AutoGenerateColumns="false"
                GridLines="None"
                AllowPaging="true"
                PageSize="10"
                OnPageIndexChanging="OrderGridView_PageIndexChanging"
                OnRowCommand="OrderGridView_RowCommand"
                DataKeyNames="ORDER_ID">
                <EmptyDataTemplate>
                    <p class="text-muted">No orders for this specific date range.</p>
                </EmptyDataTemplate>
                <Columns>
                    <asp:DynamicField DataField="ORDER_ID" HeaderText="ID" ReadOnly="true" />

                    <asp:DynamicField DataField="ACCOUNT_ID" HeaderText="Account ID" ReadOnly="true" />

                    <asp:BoundField DataField="DATE" HeaderText="Date" DataFormatString="{0:d}" ReadOnly="true" />

                    <asp:TemplateField HeaderText="STATUS">
                        <ItemTemplate>
                            <p><%#Eval("STATUS")%></p>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList
                                runat="server"
                                ID="StatusDropDown"
                                SelectMethod="GetOrderStatus"
                                DataTextField="STATUS"
                                DataValueField="ORDER_STATUS_ID"
                                SelectedValue='<%#Eval("ORDER_STATUS_ID")%>'>
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
                            <asp:LinkButton runat="server" CommandArgument='<%#Eval("ORDER_ID")%>' CommandName="UpdateRow" class="btn btn-outline-dark">
                                    <i class="bi bi-check-circle"></i>
                            </asp:LinkButton>
                            <asp:LinkButton runat="server" CommandName="CancelRow" class="btn btn-outline-dark" CausesValidation="false">
                                    <i class="bi bi-x-circle"></i>
                            </asp:LinkButton>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" class="btn btn-outline-dark" CommandArgument='<%#Eval("ORDER_ID")%>' CommandName="SelectRow" CausesValidation="false">
                                    <i class="bi bi-clipboard"></i>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>

        <!--Order Details-->
        <div class="row">
            <div class="col-12 col-sm-6">
                <asp:ListView
                    runat="server"
                    ID="DeliveryInfoListView"
                    ItemType="">
                </asp:ListView>
            </div>
            <div class="col-12 col-sm-6">

            </div>
        </div>
        <div class="row">
             <div class="col-12 col-sm-6">

            </div>
            <div class="col-12 col-sm-6">

            </div>
        </div>
    </div>

</asp:Content>
