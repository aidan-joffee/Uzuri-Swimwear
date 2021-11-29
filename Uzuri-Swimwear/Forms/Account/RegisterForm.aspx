<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="RegisterForm.aspx.cs" Inherits="Uzuri_Swimwear.Forms.RegisterForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/LoginFormStyle.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- NOT MY CSS OR STYLING gotten from https://mdbootstrap.com/docs/standard/extended/login/ -->
    <div class="h-100 gradient-form" style="background-color: #eee;">
        <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-xl-10">
                    <div class="card rounded-3 text-black">
                        <div class="row g-0">

                            <div class="col-lg-6 d-flex align-items-center gradient-custom-2">
                                <div class="text-white px-3 py-4 p-md-5 mx-md-4">
                                    <h4 class="mb-4">Register</h4>
                                    <p class="small mb-0">Use this page to register a new account.</p>
                                </div>
                            </div>

                            <div class="col-lg-6">
                                <div class="card-body p-md-5 mx-md-4">

                                    <div class="text-center">
                                        <img src="/Images/uzuri-logo-transparent-small.png" style="width: 185px;" alt="logo">
                                    </div>

                                    <asp:PlaceHolder runat="server" ID="LogoutForm" Visible="false">
                                        <p>You are already logged in, logout here to sign in to a different account.</p>
                                        <asp:Button ID="LogoutBtn" runat="server" Text="Log Out" OnClick="LogoutBtn_Click" class="btn btn-primary btn-block fa-lg gradient-custom-2 mb-3" />
                                    </asp:PlaceHolder>

                                    <asp:PlaceHolder runat="server" ID="LoginInputForm" Visible="true">
                                        <p>Please register your new account</p>

                                        <div class="form-outline mb-4">
                                            <asp:TextBox runat="server" ID="Email" type="Email" class="form-control" placeholder="Email" CausesValidation="true"  />                           
                                            <asp:RequiredFieldValidator runat="server"
                                                ControlToValidate="Email"
                                                ErrorMessage="Email is required!"
                                                ForeColor="red">
                                            </asp:RequiredFieldValidator>
                                        </div>

                                        <div class="form-outline mb-4">
                                            <asp:TextBox runat="server" ID="FirstName" class="form-control" placeholder="First Name" CausesValidation="true"  />
                                            <asp:RequiredFieldValidator
                                                runat="server"
                                                ControlToValidate="FirstName"
                                                ErrorMessage="First name is required"
                                                ForeColor="red"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="form-outline mb-4">
                                            <asp:TextBox runat="server" ID="LastName" class="form-control" placeholder="Last Name" CausesValidation="true"  />
                                            <asp:RequiredFieldValidator
                                                runat="server"
                                                ControlToValidate="LastName"
                                                ErrorMessage="Last name is required"
                                                ForeColor="red"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="form-outline mb-4">
                                            <asp:TextBox runat="server" ID="Password" type="Password" class="form-control" placeholder="Password" CausesValidation="true"  />
                                            <asp:RequiredFieldValidator
                                                runat="server"
                                                ControlToValidate="Password"
                                                ErrorMessage="Password is required"
                                                ForeColor="red"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="form-outline mb-4">
                                            <asp:TextBox runat="server" ID="ConfirmPassword" type="Password" class="form-control" placeholder="Confirm Password" CausesValidation="true" Required="true"/>
                                            <asp:CompareValidator
                                            runat="server" 
                                            ErrorMessage="Passwords must match"
                                            ForeColor="red"
                                            ControlToCompare="Password"
                                            ControlToValidate="ConfirmPassword"
                                            ></asp:CompareValidator>
                                        </div>
                                        
                                        <div class="text-center pt-1 mb-5 pb-1">
                                            <asp:Button runat="server" Text="Register" ID="RegisterBtn" OnClick="RegisterBtn_Click" CausesValidation="true" class="btn btn-primary btn-block fa-lg gradient-custom-2 mb-3" />
                                            <br />
                                            <a class="text-muted" style="text-decoration: none" href="/Forms/Account/LoginForm.aspx">Return to Login</a>
                                        </div>

                                        <div class="form-outline mb-4">
                                            <asp:PlaceHolder ID="ErrorMessage" runat="server" Visible="false">
                                                <asp:Label ID="FailureText" runat="server" ForeColor="red"></asp:Label>
                                            </asp:PlaceHolder>
                                        </div>

                                    </asp:PlaceHolder>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
