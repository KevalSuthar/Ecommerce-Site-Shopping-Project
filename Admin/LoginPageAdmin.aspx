<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPageAdmin.aspx.cs" Inherits="Admin_LoginPageAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin LoginPage</title>
    <!-- Favicon -->
    <link href="assets/img/favicon.ico" rel="icon">

    <!-- Google Web Fonts -->
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Heebo:wght@400;500;600;700&display=swap" rel="stylesheet">

    <!-- Icon Font Stylesheet -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.10.0/css/all.min.css" rel="stylesheet">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.4.1/font/bootstrap-icons.css" rel="stylesheet">

    <!-- Libraries Stylesheet -->
    <link href="assets/lib/owlcarousel/assets/owl.carousel.min.css" rel="stylesheet">
    <link href="assets/lib/tempusdominus/css/tempusdominus-bootstrap-4.min.css" rel="stylesheet" />

    <!-- Customized Bootstrap Stylesheet -->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet">
    <!-- Template Stylesheet -->
    <link href="assets/css/style.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">

        <div class="container d-flex justify-content-center align-items-center min-vh-100">
            <div class="col-md-6 col-lg-5 mt-5">
                <div class="card shadow-lg rounded-4 p-4">


                    <asp:Panel ID="pnlregistartionform" runat="server">
                        <div class="card-body">
                            <h2 class="text-center mb-4">Admin Register</h2>

                            <%-- Admin Name --%>
                            <div class="mb-3">
                                <asp:Label runat="server" Text="Admin Name" CssClass="form-label" />
                                <asp:TextBox ID="txtAdminName" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="reqAdminName" runat="server" ControlToValidate="txtAdminName" ErrorMessage="Name is required" ForeColor="Red" Display="Dynamic" />
                            </div>

                            <%-- Email --%>
                            <div class="mb-3">
                                <asp:Label runat="server" Text="Email" CssClass="form-label" />
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="reqEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required" ForeColor="Red" Display="Dynamic" />
                            </div>

                            <%-- Password --%>
                            <div class="mb-3">
                                <asp:Label runat="server" Text="Password" CssClass="form-label" />
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="reqPass" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required" ForeColor="Red" Display="Dynamic" />
                            </div>

                            <%-- Confirm Password --%>
                            <div class="mb-3">
                                <asp:Label runat="server" Text="Confirm Password" CssClass="form-label" />
                                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" />
                                <asp:CompareValidator ID="cmpPass" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Passwords do not match" ForeColor="Red" Display="Dynamic" />
                            </div>

                            <%-- Phone Number --%>
                            <div class="mb-3">
                                <asp:Label runat="server" Text="Phone Number" CssClass="form-label" />
                                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="reqPhone" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone number is required" ForeColor="Red" Display="Dynamic" />
                            </div>

                            <%-- Gender --%>
                            <div class="mb-3">
                                <asp:Label runat="server" Text="Gender" CssClass="form-label" />
                                <asp:DropDownList ID="dropgender" runat="server" CssClass="form-control">
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

                            <%--Country--%>
                            <div class="mb-3">
                                <asp:Label runat="server" Text="Country" CssClass="form-label" />

                                <asp:DropDownList ID="DropCountry" runat="server" OnSelectedIndexChanged="DropCountry_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" />

                                <asp:RequiredFieldValidator ID="reqcountry" runat="server"
                                    ControlToValidate="DropCountry"
                                    InitialValue=""
                                    ErrorMessage="Please select a Country"
                                    ForeColor="Red" Display="Dynamic" />
                            </div>


                            <%--State--%>
                            <div class="mb-3">
                                <asp:Label runat="server" Text="State" CssClass="form-label" />

                                <asp:DropDownList ID="DropState" runat="server" OnSelectedIndexChanged="DropState_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" />

                                <asp:RequiredFieldValidator ID="reqstate" runat="server"
                                    ControlToValidate="DropState"
                                    InitialValue=""
                                    ErrorMessage="Please select a State"
                                    ForeColor="Red" Display="Dynamic" />
                            </div>


                            <%--City--%>
                            <div class="mb-3">
                                <asp:Label runat="server" Text="City" CssClass="form-label" />

                                <asp:DropDownList ID="DropCity" runat="server" CssClass="form-control" />

                                <asp:RequiredFieldValidator ID="reqcity" runat="server"
                                    ControlToValidate="DropCity"
                                    InitialValue=""
                                    ErrorMessage="Please select a City"
                                    ForeColor="Red" Display="Dynamic" />
                            </div>

                            <%-- Verified --%>
                            <div class="mb-3">
                            </div>



                            <%-- Status --%>
                            <div class="mb-3">
                                <asp:Label runat="server" Text="Status" CssClass="form-label" />
                                <asp:DropDownList ID="dropStatus" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Select Status" Value="" />
                                    <asp:ListItem Text="Active" Value="Active" />
                                    <asp:ListItem Text="Deactive" Value="Deactive" />
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="reqStatus" runat="server" ControlToValidate="dropStatus" InitialValue="" ErrorMessage="Select status" ForeColor="Red" Display="Dynamic" />
                            </div>

                            <%-- Submit Button --%>
                            <div class="d-grid">
                                <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-primary" Text="Register Admin" OnClick="btnRegister_Click" />
                            </div>

                            <%-- OTP --%>
                            <div class="mb-3">

                                <asp:Label ID="LblOTP" runat="server"></asp:Label>
                            </div>



                            <%-- Optional login link --%>
                            <div class="text-center mt-3">
                                <small>Already an admin?
                                     <a href="LoginPageAdmin.aspx?mode=login" class="text-primary text-decoration-none">Login here</a>
                                </small>

                            </div>



                        </div>

                    </asp:Panel>


                    <asp:Panel ID="pnlotp" runat="server">
                        <div style="max-width: 400px; margin: 60px auto; padding: 40px 30px; background-color: #fff; border-radius: 10px; box-shadow: 0 0 20px rgba(0, 0, 0, 0.08); text-align: center;">
                            <h3 style="margin-bottom: 20px;">Enter 6-Digit OTP</h3>

                            <div style="display: flex; justify-content: center; gap: 10px; flex-wrap: wrap; margin-bottom: 20px;">
                                <input type="text" runat="server" class="otp-box" id="otp1" name="otp1" maxlength="1"
                                    style="width: 45px; height: 45px; font-size: 20px; text-align: center; border: 1px solid #ccc; border-radius: 5px; outline: none;"
                                    oninput="moveToNext(this, 'otp2')" onkeydown="movePrev(event, null)" />

                                <input type="text" runat="server" class="otp-box" id="otp2" name="otp2" maxlength="1"
                                    style="width: 45px; height: 45px; font-size: 20px; text-align: center; border: 1px solid #ccc; border-radius: 5px; outline: none;"
                                    oninput="moveToNext(this, 'otp3')" onkeydown="movePrev(event, 'otp1')" />

                                <input type="text" runat="server" class="otp-box" id="otp3" name="otp3" maxlength="1"
                                    style="width: 45px; height: 45px; font-size: 20px; text-align: center; border: 1px solid #ccc; border-radius: 5px; outline: none;"
                                    oninput="moveToNext(this, 'otp4')" onkeydown="movePrev(event, 'otp2')" />

                                <input type="text" runat="server" class="otp-box" id="otp4" name="otp4" maxlength="1"
                                    style="width: 45px; height: 45px; font-size: 20px; text-align: center; border: 1px solid #ccc; border-radius: 5px; outline: none;"
                                    oninput="moveToNext(this, 'otp5')" onkeydown="movePrev(event, 'otp3')" />

                                <input type="text" runat="server" class="otp-box" id="otp5" name="otp5" maxlength="1"
                                    style="width: 45px; height: 45px; font-size: 20px; text-align: center; border: 1px solid #ccc; border-radius: 5px; outline: none;"
                                    oninput="moveToNext(this, 'otp6')" onkeydown="movePrev(event, 'otp4')" />

                                <input type="text" runat="server" class="otp-box" id="otp6" name="otp6" maxlength="1"
                                    style="width: 45px; height: 45px; font-size: 20px; text-align: center; border: 1px solid #ccc; border-radius: 5px; outline: none;"
                                    oninput="moveToNext(this, null)" onkeydown="movePrev(event, 'otp5')" />
                            </div>

                            <asp:Button ID="btnVerify" runat="server" Text="Verify OTP"
                                OnClick="btnVerify_Click"
                                Style="background-color: #007bff; color: #fff; padding: 10px 25px; border: none; border-radius: 6px; cursor: pointer; font-size: 16px;" />

                        </div>

                    </asp:Panel>


                    <asp:Panel ID="pnllogin" runat="server" Visible="false">
                        <div class="card-body">
                            <h2 class="text-center mb-4">Admin Login</h2>

                            <%-- Email --%>
                            <div class="mb-3">
                                <asp:Label ID="lblEmail" runat="server" CssClass="form-label" AssociatedControlID="txtLoginEmail">Email Address</asp:Label>
                                <asp:TextBox ID="txtLoginEmail" runat="server" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="txtLoginEmail"
                                    ErrorMessage="Email is required"
                                    ForeColor="Red"
                                    Display="Dynamic" />
                            </div>

                            <%-- Password --%>
                            <div class="mb-3">
                                <asp:Label ID="lblPassword" runat="server" CssClass="form-label" AssociatedControlID="txtLoginPassword">Password</asp:Label>
                                <asp:TextBox ID="txtLoginPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqPassword" runat="server"
                                    ControlToValidate="txtLoginPassword"
                                    ErrorMessage="Password is required"
                                    ForeColor="Red"
                                    Display="Dynamic" />
                            </div>

                            <%-- Forget Password --%>
                            <div class="d-flex justify-content-between align-items-center mb-3">
                                <a href="ForgetPassword.aspx" class="text-decoration-none small text-primary">Forget Password?</a>
                            </div>

                            <%-- Login Button --%>
                            <div class="d-grid mb-3">
                                <asp:Button ID="btnAdminLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnAdminLogin_Click" />
                            </div>

                            <%-- Register Link --%>
                            <div class="text-center">
                                <span class="small">Don’t have an admin account?</span>
                                <a href="LoginPageAdmin.aspx?mode=register" class="text-decoration-none small text-primary">Register here</a>
                            </div>


                            <%-- Optional Message Label --%>
                            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>

                        </div>

                    </asp:Panel>

                </div>
            </div>
        </div>



        <!-- JavaScript Libraries -->
        <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0/dist/js/bootstrap.bundle.min.js"></script>
        <script src="assets/lib/chart/chart.min.js"></script>
        <script src="assets/lib/easing/easing.min.js"></script>
        <script src="assets/lib/waypoints/waypoints.min.js"></script>
        <script src="assets/lib/owlcarousel/owl.carousel.min.js"></script>
        <script src="assets/lib/tempusdominus/js/moment.min.js"></script>
        <script src="assets/lib/tempusdominus/js/moment-timezone.min.js"></script>
        <script src="assets/lib/tempusdominus/js/tempusdominus-bootstrap-4.min.js"></script>

        <!-- Template Javascript -->
        <script src="assets/js/main.js"></script>
        <script>
            function moveToNext(current, nextId) {
                if (current.value.length === 1 && nextId) {
                    document.getElementById(nextId).focus();
                }
            }

            function movePrev(e, prevId) {
                if (e.key === "Backspace" && !e.target.value && prevId) {
                    document.getElementById(prevId).focus();
                }
            }
        </script>

    </form>
</body>
</html>
