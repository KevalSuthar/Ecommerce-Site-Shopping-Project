<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterClient.master" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="Client_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="Server">

    <div class="container d-flex justify-content-center align-items-center min-vh-100">
        <div class="col-md-6 col-lg-5" style="margin-top: 5%;">
            <div class="card shadow-lg rounded-4 p-4">
                <div class="card-body">
                    <h2 class="text-center mb-4">Login</h2>
                    <div class="mb-3">
                        <asp:Label ID="lblEmail" runat="server" CssClass="form-label" AssociatedControlID="txtLoginemail">Email Address</asp:Label>
                        <asp:TextBox ID="txtLoginemail" runat="server" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqEmail" runat="server"
                            ControlToValidate="txtLoginemail"
                            ErrorMessage="Email is required"
                            ForeColor="Red"
                            Display="Dynamic" />
                    </div>

                    <div class="mb-3">
                        <asp:Label ID="lblPassword" runat="server" CssClass="form-label" AssociatedControlID="txtloginpassword">Password</asp:Label>
                        <asp:TextBox ID="txtloginpassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqPassword" runat="server"
                            ControlToValidate="txtloginpassword"
                            ErrorMessage="Password is required"
                            ForeColor="Red"
                            Display="Dynamic" />
                    </div>


                    <div class="d-flex justify-content-between align-items-center mb-3">
                        <a href="ForgetPassword.aspx" class="text-decoration-none small text-primary">Forget Password</a>

                    </div>

                    <div class="d-grid mb-3">
                        <%--<button type="submit" class="btn btn-primary">Login</button>--%>
                        <asp:Button ID="login" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="login_Click" />
                    </div>

                    <!-- New Registration Link -->
                    <div class="text-center">
                        <span class="small">Don't have an account?</span>
                        <a href="Registartion.aspx" class="text-decoration-none small text-primary">Register here</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" runat="Server">
</asp:Content>

