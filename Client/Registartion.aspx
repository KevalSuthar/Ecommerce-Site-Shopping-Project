<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterClient.master" AutoEventWireup="true" CodeFile="Registartion.aspx.cs" Inherits="Client_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="Server">

    <div class="container d-flex justify-content-center align-items-center min-vh-100">
        <div class="col-md-6 col-lg-5" style="margin-top: 15%">
            <div class="card shadow-lg rounded-4 p-4">
                <div class="card-body">
                    <h2 class="text-center mb-4">Register</h2>

                    <%-- UserType --%>
                    <div class="mb-3">
                        <%--<label for="username" class="form-label">Username</label>--%>
                        <%--<input type="text" class="form-control" id="username" placeholder="Enter username" required>--%>
                        <asp:Label ID="usertype" runat="server" Text="Label" CssClass="form-label">UserType</asp:Label>
                        <asp:TextBox ID="txtuserttype" runat="server" CssClass="form-control" placeholder="Enter UserType"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqtype" runat="server"
                            ControlToValidate="txtuserttype"
                            ErrorMessage="usertype is required"
                            ForeColor="Red"
                            Display="Dynamic" />
                    </div>

                    <%-- name --%>
                    <div class="mb-3">
                        <%--<label for="username" class="form-label">Username</label>--%>
                        <%--<input type="text" class="form-control" id="username" placeholder="Enter username" required>--%>
                        <asp:Label ID="name" runat="server" Text="Label" CssClass="form-label">Username</asp:Label>
                        <asp:TextBox ID="txtname" runat="server" CssClass="form-control" placeholder="Enter username"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="repusername" runat="server"
                            ControlToValidate="txtname"
                            ErrorMessage="username is required"
                            ForeColor="Red"
                            Display="Dynamic" />
                    </div>

                    <%-- Email --%>
                    <div class="mb-3">
                        <%--<label for="email" class="form-label">Email Address</label>--%>
                        <%--<input type="text" class="form-control" id="email" placeholder="Enter email" required>--%>
                        <asp:Label ID="email" runat="server" Text="Label" CssClass="form-label">Email Address</asp:Label>
                        <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqemail" runat="server"
                            ControlToValidate="txtemail"
                            ErrorMessage="email is required"
                            ForeColor="Red"
                            Display="Dynamic" />
                    </div>

                    <%-- Password --%>
                    <div class="mb-3">
                        <%--<label for="password" class="form-label">Password</label>--%>
                        <%--<input type="text" class="form-control" id="password" placeholder="Enter password" required>--%>
                        <asp:Label ID="password" runat="server" Text="Label" CssClass="form-label"> Password</asp:Label>
                        <asp:TextBox ID="txtpassword" runat="server" CssClass="form-control" placeholder="Enter password" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqpass" runat="server"
                            ControlToValidate="txtpassword"
                            ErrorMessage="password is required"
                            ForeColor="Red"
                            Display="Dynamic" />
                    </div>

                    <%-- Conformpass --%>
                    <div class="mb-3">
                        <%--<label for="confirmPassword" class="form-label">Confirm Password</label>--%>
                        <%--<input type="text" class="form-control" id="confirmPassword" placeholder="Confirm password" required>--%>
                        <asp:Label ID="confirmpassword" runat="server" Text="Label" CssClass="form-label"> Confirm Password</asp:Label>
                        <asp:TextBox ID="txtconformpass" runat="server" CssClass="form-control" placeholder="Confirm password" ></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtpassword" ControlToValidate="txtconformpass" ErrorMessage="Password is not matched" ForeColor="Red"></asp:CompareValidator>
                    </div>

                    <%-- Phone num --%>
                    <div class="mb-3">
                        <%--  <label for="phone" class="form-label">Phone Number</label>
                            <input type="text" class="form-control" id="phone" placeholder="Enter phone number" required>--%>
                        <asp:Label ID="phone" runat="server" Text="Label" CssClass="form-label">Phone Number</asp:Label>
                        <asp:TextBox ID="txtphone" runat="server" CssClass="form-control" placeholder="Enter Phone Number" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqphone" runat="server"
                            ControlToValidate="txtphone"
                            ErrorMessage="phone is required"
                            ForeColor="Red"
                            Display="Dynamic" />
                    </div>

                    <%-- Gender --%>
                    <div class="mb-3">
                        <%--<label for="gender" class="form-label">Gender</label>--%>
                        <asp:Label ID="gender" runat="server" Text="Label" CssClass="form-label" > Gender</asp:Label>
                        <asp:DropDownList ID="dropgender" runat="server" CssClass="form-control" >
                            <asp:ListItem Text="Select gender" Value=""></asp:ListItem>
                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                            <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                        </asp:DropDownList>
                        
                        <asp:RequiredFieldValidator ID="reqgender" runat="server"
                            ControlToValidate="dropgender"
                            InitialValue=""
                            ErrorMessage="Please select a gender"
                            ForeColor="Red" Display="Dynamic" />
                    </div>

                    <%-- Country --%>
                    <div class="mb-3">
                        <%--<label for="email" class="form-label">Email Address</label>--%>
                        <%--<input type="text" class="form-control" id="email" placeholder="Enter email" required>--%>
                        <%--<asp:TextBox ID="txtcountry" runat="server" CssClass="form-control" placeholder="Enter Country" required="required"></asp:TextBox>--%>
                        <asp:Label ID="country" runat="server" Text="Label" CssClass="form-label">Country Name</asp:Label>
                        <asp:DropDownList ID="DropCountry" runat="server" OnSelectedIndexChanged="DropCountry_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" placeholder="Enter Country"  />
                   
                           <asp:RequiredFieldValidator ID="reqcountry" runat="server"
                            ControlToValidate="DropCountry"
                            InitialValue=""
                            ErrorMessage="Please select a Country"
                            ForeColor="Red" Display="Dynamic" />
                         </div>

                    <%-- State --%>
                    <div class="mb-3">
                        <%--<label for="email" class="form-label">Email Address</label>--%>
                        <%--<input type="text" class="form-control" id="email" placeholder="Enter email" required>--%>
                        <%--<asp:TextBox ID="txtstate" runat="server" CssClass="form-control" placeholder="Enter State" required="required"></asp:TextBox>--%>
                        <asp:Label ID="state" runat="server" Text="Label" CssClass="form-label">State Name</asp:Label>
                        <asp:DropDownList ID="DropState" runat="server" OnSelectedIndexChanged="DropState_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" placeholder="Enter State"  />
                          <asp:RequiredFieldValidator ID="reqstate" runat="server"
                            ControlToValidate="DropState"
                            InitialValue=""
                            ErrorMessage="Please select a State"
                            ForeColor="Red" Display="Dynamic" />
                    </div>

                    <%-- City --%>
                    <div class="mb-3">
                        <%--<label for="email" class="form-label">Email Address</label>--%>
                        <%--<input type="text" class="form-control" id="email" placeholder="Enter email" required>--%>
                        <%--<asp:TextBox ID="txtcity" runat="server" CssClass="form-control" placeholder="Enter City" required="required"></asp:TextBox>--%>
                        <asp:Label ID="city" runat="server" Text="Label" CssClass="form-label">City Name</asp:Label>
                        <asp:DropDownList ID="DropCity" runat="server" CssClass="form-control" placeholder="Enter City"  />
                         <asp:RequiredFieldValidator ID="reqcity" runat="server"
                            ControlToValidate="DropCity"
                            InitialValue=""
                            ErrorMessage="Please select a City"
                            ForeColor="Red" Display="Dynamic" />
                    </div>

                    <%-- Verified --%>
                    <div class="mb-3">
                        <%--<label for="email" class="form-label">Email Address</label>--%>
                        <%--<input type="text" class="form-control" id="email" placeholder="Enter email" required>--%>
                        <%--<asp:Label ID="verified" runat="server" Text="Label" CssClass="form-label">Verified</asp:Label>--%>
                        <%--<asp:TextBox ID="txtverified" runat="server" CssClass="form-control" placeholder="Enter Verified" required="required"></asp:TextBox>--%>
                    </div>


                    <%-- Status --%>
                    <div class="mb-3">
                        <%--<label for="gender" class="form-label">Gender</label>--%>
                        <asp:Label ID="status" runat="server" Text="Label" CssClass="form-label"> Status</asp:Label>
                        <asp:DropDownList ID="dropStatus" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Select Status" Value=""></asp:ListItem>
                            <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                            <asp:ListItem Text="Deactive" Value="Deactive"></asp:ListItem>

                        </asp:DropDownList>
                         <asp:RequiredFieldValidator ID="reqstatus" runat="server"
                            ControlToValidate="dropStatus"
                            InitialValue=""
                            ErrorMessage="Please select a status"
                            ForeColor="Red" Display="Dynamic" />
                    </div>

                    <%-- btnsubmit --%>
                    <div class="d-grid">
                        <%--<button type="submit" class="btn btn-primary">Register</button>--%>
                        <asp:Button ID="btnsubmit" CssClass="btn btn-primary" runat="server" Text="Register" OnClick="btnsubmit_Click" />
                    </div>

                    <%-- OTP --%>
                    <div class="mb-3">
                        <%--<label for="email" class="form-label">Email Address</label>--%>
                        <%--<input type="text" class="form-control" id="email" placeholder="Enter email" required>--%>
                        <%--<asp:Label ID="otp" runat="server" Text="Label" CssClass="form-label">OTP</asp:Label>--%>
                        <%--<asp:TextBox ID="txtOtp" runat="server" CssClass="form-control" placeholder="Enter OTP" required="required"></asp:TextBox>--%>
                        <asp:Label ID="LblOTP" runat="server"></asp:Label>
                    </div>

                    <%-- loginpage --%>
                    <div class="text-center mt-3">
                        <small>Already have an account? <a href="LoginPage.aspx" class="text-primary text-decoration-none">Login</a></small>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" runat="Server">
</asp:Content>

