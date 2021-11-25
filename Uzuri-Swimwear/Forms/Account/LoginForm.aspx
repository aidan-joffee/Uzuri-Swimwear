<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="Uzuri_Swimwear.Forms.LoginForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/LoginFormStyle.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- NOT MY CSS OR STYLING gotten from https://mdbootstrap.com/docs/standard/extended/login/ -->
    <section class="h-100 gradient-form" style="background-color: #eee;">
        <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-xl-10">
                    <div class="card rounded-3 text-black">
                        <div class="row g-0">
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
                                        <p>Please login to your account</p>

                                        <div class="form-outline mb-4">
                                            <asp:TextBox runat="server" ID="Email" type="Email" class="form-control" placeholder="Email" />                                        
                                        </div>

                                        <div class="form-outline mb-4">                
                                            <asp:TextBox runat="server" ID="Password" type="Password" class="form-control" placeholder="Password" />                                     
                                        </div>

                                        <div class="form-outline mb-4">
                                            <asp:CheckBox runat="server" ID="RememberMe" Text="Remember me?" />
                                        </div>

                                        <div class="text-center pt-1 mb-5 pb-1">
                                            <asp:Button runat="server" Text="Log In" ID="LoginBtn" OnClick="LoginBtn_Click" class="btn btn-primary btn-block fa-lg gradient-custom-2 mb-3" />
                                            <br />
                                            <a class="text-muted" style="text-decoration: none" href="#!">Forgot password?</a>
                                        </div>

                                         <div class="form-outline mb-4">
                                            <asp:PlaceHolder ID="ErrorMessage" runat="server" Visible="false">
                                                <asp:Label ID="FailureText" runat="server" ForeColor="red"></asp:Label>
                                            </asp:PlaceHolder>
                                        </div>

                                        <div class="d-flex align-items-center justify-content-center pb-4">
                                            <p class="mb-0 me-2">Don't have an account?</p>
                                            <asp:Button class="btn btn-outline-danger" text="Create New" ID="ToRegisterFormBtn" runat="server" OnClick="ToRegisterFormBtn_Click"/>
                                        </div>

                                       

                                    </asp:PlaceHolder>

                                </div>
                            </div>
                            <div class="col-lg-6 d-flex align-items-center gradient-custom-2">
                                <div class="text-white px-3 py-4 p-md-5 mx-md-4">
                                    <h4 class="mb-4">Login</h4>
                                    <p class="small mb-0">Login or Register if you do not have an account with us.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
