<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="ProfileForm.aspx.cs" Inherits="Uzuri_Swimwear.Forms.ProfileForm" %>

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
                            <asp:TextBox runat="server" class="form-control" ID="firstName" placeholder="Enter first name" ReadOnly="true" />
                            <asp:RequiredFieldValidator runat="server" 
                                ControlToValidate="firstName" 
                                ErrorMessage="First name is required." 
                                ForeColor="red"
                                ValidationGroup="PersonalDetailValidation"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                        <div class="form-group">
                            <label for="website">Last Name</label>
                            <asp:TextBox runat="server" class="form-control" ID="lastName" placeholder="Enter last name" ReadOnly="true" />
                            <asp:RequiredFieldValidator runat="server" 
                                ControlToValidate="lastName" 
                                ErrorMessage="Last name is required." 
                                ForeColor="red"
                                ValidationGroup="PersonalDetailValidation"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                        <div class="form-group">
                            <label for="phoneNum">Phone</label>
                            <p class="text-muted">eg: 123 456 7890</p>
                            <asp:TextBox runat="server" class="form-control" ID="phoneNum" placeholder="Enter phone number" ReadOnly="true" TextMode="Phone"/>                                    
                            <asp:RequiredFieldValidator runat="server" 
                                ControlToValidate="phoneNum" 
                                ErrorMessage="Phone number name is required." 
                                ForeColor="red"
                                ValidationGroup="PersonalDetailValidation"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row gutters">
                        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                            <div class="text-right">
                                <asp:LinkButton runat="server" ID="EditPersonalInfoBtn" class="btn btn-outline-dark" OnClick="EditPersonalInfoBtn_Click" Visible="true" ValidationGroup="PersonalDetailValidation" CausesValidation="false">
                                    <i class="bi bi-pen"></i>
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" ID="SubmitPersonalInfoBtn" class="btn btn-outline-dark" OnClick="SubmitPersonalInfoBtn_Click" ValidationGroup="PersonalDetailValidation" Visible="false">
                                    <i class="bi bi-check-circle"></i>
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" ID="CancelEditPersonalBtn" class="btn btn-outline-dark" OnClick="CancelEdit_Click" ValidationGroup="PersonalDetailValidation" Visible="false" CausesValidation="false">
                                    <i class="bi bi-x-circle"></i>
                                </asp:LinkButton>
                            </div>
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
                                <asp:TextBox runat="server" class="form-control" ID="Street" placeholder="Enter Street" ReadOnly="true"/>
                                <asp:RequiredFieldValidator 
                                    runat="server" 
                                    ControlToValidate="Street" 
                                    ErrorMessage="Street name and number is required." 
                                    ForeColor="red"
                                    ValidationGroup="AddressDetailValidation"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                            <div class="form-group">
                                <label for="city">City</label>
                                <asp:TextBox runat="server" class="form-control" ID="city" placeholder="Enter City" ReadOnly="true" />
                                <asp:RequiredFieldValidator 
                                    runat="server" 
                                    ControlToValidate="city" 
                                    ErrorMessage="City is required." 
                                    ForeColor="red"
                                    ValidationGroup="AddressDetailValidation"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                            <div class="form-group">
                                <label for="suburb">Suburb</label>
                                <asp:TextBox runat="server" class="form-control" ID="suburb" placeholder="Enter Suburb" ReadOnly="true" />
                                <asp:RequiredFieldValidator 
                                    runat="server" 
                                    ControlToValidate="suburb" 
                                    ErrorMessage="Street name and number is required." 
                                    ForeColor="red"
                                    ValidationGroup="AddressDetailValidation"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                            <div class="form-group">
                                <label for="suburb">Postal Code</label>
                                <asp:TextBox Required="true" TextMode="Number" MaxLength="4" MinLength="4" runat="server" class="form-control" ID="postalCode" placeholder="Enter postal code" ReadOnly="true" />
                                <asp:RegularExpressionValidator
                                    runat="server"
                                    ControlToValidate="postalCode"
                                    ValidationExpression="^[0-9]{4}$"
                                    ErrorMessage="Postal code must be a number"
                                    ForeColor="red"
                                    ValidationGroup="AddressDetailValidation"></asp:RegularExpressionValidator>
                            </div>
                        </div>

                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                            <div class="form-group">
                                <label for="provinceSelection">Province</label>
                                <asp:DropDownList runat="server" ID="provinceSelection" Enabled="false">
                                    <asp:ListItem>Western Cape</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row gutters">
                        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                            <div class="text-right">
                                <asp:LinkButton runat="server" ID="EditAddressInfoBtn" class="btn btn-outline-dark" OnClick="EditAddressInfoBtn_Click" Visible="true" ValidationGroup="AddressDetailValidation" CausesValidation="false">
                                    <i class="bi bi-pen"></i>
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" ID="SubmitAddressInfoBtn" class="btn btn-outline-dark" OnClick="SubmitAddressInfoBtn_Click" Visible="false" ValidationGroup="AddressDetailValidation" CausesValidation="false">
                                    <i class="bi bi-check-circle"></i>
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" ID="CancelEditAddressBtn" class="btn btn-outline-dark" OnClick="CancelEdit_Click" Visible="false" ValidationGroup="AddressDetailValidation" CausesValidation="false">
                                    <i class="bi bi-x-circle"></i>
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
