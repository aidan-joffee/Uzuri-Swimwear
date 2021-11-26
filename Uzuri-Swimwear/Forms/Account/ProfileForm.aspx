<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="ProfileForm.aspx.cs" Inherits="Uzuri_Swimwear.Forms.ProfileForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/ProfileFormStyle.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="card h-100">
            <div class="card-body">
                <div class="row gutters">
                    <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                        <h6 class="mb-3 text-primary">Personal Details</h6>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                        <div class="form-group">
                            <label for="fullName">First Name</label>
                            <asp:TextBox runat="server" class="form-control" id="firstName" placeholder="Enter first name" Enabled="false"/>
                        </div>
                    </div>

                     <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                        <div class="form-group">
                            <label for="website">Last Name</label>
                            <asp:TextBox runat="server" class="form-control" id="lastName" placeholder="Enter last name" Enabled="false"/>
                        </div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                        <div class="form-group">
                            <label for="phone">Phone</label>
                            <asp:TextBox runat="server" class="form-control" id="phone" placeholder="Enter phone number" Enabled="false"/>
                        </div>
                    </div>

                    <div class="row gutters">
                        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                            <div class="text-right">
                                <asp:LinkButton runat="server" ID="EditPersonalInfoBtn" class="btn btn-outline-dark" OnClick="EditPersonalInfoBtn_Click">
                                    <i class="bi bi-pen"></i>
                                </asp:LinkButton>
                            </div>
                        </div>

                   
                    <div class="card-body">
                    </div>
                    <div class="row gutters">
                        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                            <h6 class="mb-3 text-primary">Address</h6>
                        </div>
                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                            <div class="form-group">
                                <label for="Street">Street</label>
                                <asp:TextBox runat="server" class="form-control" ID="Street" placeholder="Enter Street" />
                            </div>
                        </div>
                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                            <div class="form-group">
                                <label for="ciTy">City</label>
                                <asp:TextBox runat="server" class="form-control" ID="city" placeholder="Enter City" />
                            </div>
                        </div>
                         <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                            <div class="form-group">
                                <label for="suburb">Suburb</label>
                                <asp:TextBox runat="server" class="form-control" ID="suburb" placeholder="Enter Suburb" />
                            </div>
                        </div>

                         <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                            <div class="form-group">
                                <label for="suburb">Postal Code</label>
                                <asp:TextBox runat="server" class="form-control" ID="postalCode" placeholder="Enter postal code" />
                            </div>
                        </div>

                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                            <div class="form-group">
                                <label for="provinceSelection">Province</label>
                                <asp:DropDownList runat="server" ID="provinceSelection">
                                    <asp:ListItem>Western Cape</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                            <div class="form-group">
                                <label for="zIp">Zip Code</label>
                                <asp:TextBox runat="server" class="form-control" ID="zIp" placeholder="Zip Code" />
                            </div>
                        </div>
                    </div>
                    <div class="row gutters">
                        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                            <div class="text-right">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
