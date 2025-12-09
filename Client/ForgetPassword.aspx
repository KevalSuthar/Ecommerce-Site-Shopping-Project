<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterClient.master" AutoEventWireup="true" CodeFile="ForgetPassword.aspx.cs" Inherits="Client_ForgetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" Runat="Server">
      
    <%--<div class="container d-flex justify-content-center align-items-center min-vh-100">
        <div class="col-md-6 col-lg-5" style="margin-top: 5%;">
            <div class="card shadow-lg rounded-4 p-4">
                <div class="card-body">
                    <h2 class="text-center mb-4">Forget Password</h2>

                    <!-- Email -->
                    <div class="mb-3">
                        <asp:Label ID="lblEmail" runat="server" Text="Email Address" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email" />
                    </div>

                    <!-- Mobile -->
                    <div class="mb-3">
                        <asp:Label ID="lblMobile" runat="server" Text="Mobile Number" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Enter Mobile Number" MaxLength="10" />
                    </div>

                    <!-- Submit Button -->
                    <div class="d-grid mb-3">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary"/>
                    </div>

                    <!-- Go back to Login -->
                    <div class="text-center">
                        <a href="LoginPage.aspx" class="text-decoration-none small text-primary">Back to Login</a>
                    </div>

                </div>
            </div>
        </div>
    </div>--%>

    <div class="rts-register-area rts-section-gap bg_light-1"  style="margin-top: 12%; margin-bottom: 4%;">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-lg-6 col-md-8">
                <div class="registration-wrapper-1 shadow-lg p-4 rounded bg-white">
                  
                    <!-- Title -->
                    <h3 class="title text-center mb-4">Forgot Password</h3>

                    <!-- Form -->
                    <div class="registration-form">
                        <!-- Email -->
                        <div class="input-wrapper mb-3">
                            <label for="TxtEmail">Email <span class="text-danger">*</span></label>
                            <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control" placeholder="Enter your email"></asp:TextBox>
                        </div>

                        <!-- New Password -->
                        <div class="input-wrapper mb-3">
                            <label for="TxtPassword">New Password <span class="text-danger">*</span></label>
                            <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter new password"></asp:TextBox>
                        </div>

                        <!-- Confirm Password -->
                        <div class="input-wrapper mb-4">
                            <label for="TxtConfirmPassword">Confirm Password <span class="text-danger">*</span></label>
                            <asp:TextBox ID="TxtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Re-enter new password"></asp:TextBox>
                        </div>

                        <!-- Submit Button -->
                        <div class="text-center">
                            <asp:Button ID="btnResetPassword" runat="server" Text="Reset Password" CssClass="btn btn-primary px-4 py-2" OnClick="btnResetPassword_Click" />
                        </div>

                        <!-- Optional social & login -->
                        <div class="another-way-to-registration text-center mt-4">
                            <div class="registradion-top-text mb-2">
                                <span>Or Register With</span>
                            </div>
                            <p class="mt-3">Already Have Account? <a href="LoginPage.aspx">Login</a></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" Runat="Server">
</asp:Content>

