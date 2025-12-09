<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductPhoto.aspx.cs" Inherits="Admin_ProductPhoto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>Product Photo Add</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport">
    <meta content="" name="keywords">
    <meta content="" name="description">

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
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0">Product Photos Form</h4>
                    </div>
                </div>
            </div>
            <!-- end page title -->

            <div class="card">
                <div class="card-header">
                    <div class="d-flex justify-content-between align-content-center">
                        <h4>Product Specifications Options Form</h4>
                    </div>
                </div>

                <%-- Card Body --%>
                <div class="card-body">

                    <%-- TextBox Photo --%>
                    <div class="mb-3">

                        <label for="txtProductPhoto">PhotoAltText</label>
                        <asp:TextBox ID="txtSpecification" CssClass="form-control" runat="server" PlaceHolder="No Value"></asp:TextBox>
                    </div>

                    <%--  File Upload --%>
                    <div class="row">
                        <div class="col-sm-8 col-12">
                            <div class="mb-3">
                                <label for="PhotoUpload">PhotoUpload</label>
                                <asp:FileUpload ID="ProductPhotoFileUpload" runat="server" CssClass="form-control" />
                            </div>
                        </div>

                        <div class="col-sm-4 col-12">
                            <div class="mb-3">
                                <asp:Image ID="ProductPhoto" runat="server" Width="100px" Height="100px" class="img-thumbnail" />
                            </div>
                        </div>
                    </div>

                    <%-- DropDown  --%>
                    <div class="mb-3">
                        <label for="txtstatus">Status</label>
                        <asp:DropDownList ID="DropProdPhotoStatus" runat="server" CssClass="form-control">
                            <asp:ListItem>Active</asp:ListItem>
                            <asp:ListItem>Deactive</asp:ListItem>
                        </asp:DropDownList>
                    </div>


                </div>
        <div class="card-footer text-center">
            <asp:Button ID="btnProdPhotoSave" runat="server" Text="SAVE" CssClass="btn btn-primary waves-effect waves-light me-1" OnClick="btnProdPhotoSave_Click" />


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
    </form>
</body>
</html>
