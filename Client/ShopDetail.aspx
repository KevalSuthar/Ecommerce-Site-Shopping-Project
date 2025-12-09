<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterClient.master" AutoEventWireup="true" CodeFile="ShopDetail.aspx.cs" Inherits="Client_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="Server">

    <!-- Modal Search Start -->
    <div class="modal fade" id="searchModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-fullscreen">
            <div class="modal-content rounded-0">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Search by keyword</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body d-flex align-items-center">
                    <div class="input-group w-75 mx-auto d-flex">
                        <input type="search" class="form-control p-3" placeholder="keywords" aria-describedby="search-icon-1">
                        <span id="search-icon-1" class="input-group-text p-3"><i class="fa fa-search"></i></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal Search End -->


    <!-- Single Page Header start -->
    <div class="container-fluid page-header py-5">
        <h1 class="text-center text-white display-6">Shop Detail</h1>
        <ol class="breadcrumb justify-content-center mb-0">
            <li class="breadcrumb-item"><a href="index.aspx">Home</a></li>
            <li class="breadcrumb-item"><a href="#">Pages</a></li>
            <li class="breadcrumb-item active text-white">Shop Detail</li>
        </ol>
    </div>
    <!-- Single Page Header End -->

    <!-- Single Product Start -->
    <div class="container-fluid py-5 mt-5">
        <div class="container py-5">
            <div class="row g-4 mb-5">
                <div class="col-lg-8 col-xl-9">
                    <div class="row g-4">
                        <%-- image --%>
                        <div class="col-lg-6">
                            <div class="border rounded">
                                <a href="#">
                                    <asp:Image ID="MainImage" runat="server" class="img-fluid rounded" alt="Image" />
                                    <%--   <img src="assets/img/single-item.jpg" class="img-fluid rounded" alt="Image">--%>
                                </a>
                            </div>
                        </div>
                        <%-- Title --%>
                        <div class="col-lg-6">
                            <%--<h4 class="fw-bold mb-3"></h4>--%>
                            <asp:Label ID="titlename" runat="server" Text="Label" CssClass="text-danger fs-2 fw-bold mb-3"></asp:Label>
                            <hr>
                            <%--<h5 class="fw-bold mb-3"></h5>--%>
                            <asp:Label ID="prodprice" runat="server" Text="Label" CssClass="fs-3 fw-bold mb-3">                               
                                
                            </asp:Label>
                            ₹
                            <div class="d-flex mb-4">
                                <i class="fa fa-star text-secondary"></i>
                                <i class="fa fa-star text-secondary"></i>
                                <i class="fa fa-star text-secondary"></i>
                                <i class="fa fa-star text-secondary"></i>
                                <i class="fa fa-star"></i>
                            </div>

                            <asp:Label ID="prodtDescripition" runat="server" Text="Label" CssClass="fs-6">    
                            </asp:Label>

                            <%-- PLUS -MINUS --%>

                            <%--<div class="input-group quantity mb-5" style="width: 100px;">--%>
                            <%--<div class="input-group-btn">
                                    <button class="btn btn-sm btn-minus rounded-circle bg-light border">
                                        <i class="fa fa-minus"></i>
                                    </button>
                                </div>--%>
                            <%--<asp:TextBox ID="CartTxtQty" CssClass="input" runat="server">1</asp:TextBox>--%>

                            <%--<div class="input-group-btn">
                                    <button class="btn btn-sm btn-plus rounded-circle bg-light border">
                                        <i class="fa fa-plus"></i>
                                    </button>
                                </div>--%>
                            <%--</div>--%>
                            <%--<a href="#" class="btn border border-secondary rounded-pill px-4 py-2 mb-4 text-primary"><i class="fa fa-shopping-bag me-2 text-primary"></i>Add to cart</a>--%>

                            <%-- PLUS -MINUS --%>

                            <asp:ScriptManager ID="ScriptManager1" runat="server" />

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="input-group quantity mb-5" style="width: 100px;">
                                        <div class="input-group-btn">
                                            <asp:Button ID="btnMinus" runat="server" Text="-" CssClass="btn btn-sm btn-minus rounded-circle bg-light border" OnClick="btnMinus_Click" />
                                        </div>

                                        <asp:TextBox ID="CartTxtQty" runat="server" CssClass="form-control form-control-sm text-center border-0" Text="1" />

                                        <div class="input-group-btn">
                                            <asp:Button ID="btnPlus" runat="server" Text="+" CssClass="btn btn-sm btn-plus rounded-circle bg-light border" OnClick="btnPlus_Click" />
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>


                            <!-- Add to Cart Button -->
                            <asp:Button ID="BtnAddToCard" runat="server" Text="Add to cart" CssClass="btn border border-secondary rounded-pill px-4 py-2 mb-4 text-primary" OnClick="BtnAddToCard_Click" />
                           
                            <%--<asp:LinkButton ID="BtnAddToCard" OnClick="BtnAddToCard_Click" CssClass="btn border border-secondary rounded-pill px-4 py-2 mb-4 text-primary" runat="server">Add To Cart   <i class="fa-regular fa-cart-shopping"></i></asp:LinkButton>--%>
                        </div>

                    </div>

                </div>

                <%-- Category Data --%>
                <div class="col-lg-4 col-xl-3">
                    <div class="row g-4 fruite">
                        <div class="col-lg-12">
                            <div class="input-group w-100 mx-auto d-flex mb-4">
                                <input type="search" class="form-control p-3" placeholder="keywords" aria-describedby="search-icon-1">
                                <span id="search-icon-1" class="input-group-text p-3"><i class="fa fa-search"></i></span>
                            </div>

                            <div class="mb-4">
                                <h4>Categories</h4>
                                <asp:Repeater ID="rptCategory" runat="server">
                                    <ItemTemplate>
                                        <li class="mb-2" style="list-style: none">
                                            <div class="d-flex justify-content-between fruite-name">
                                                <a href='Shop.aspx?CategoryId=<%# Eval("CategoryId") %>' class="text-decoration-none">
                                                    <i class="fas fa-apple-alt me-2"></i><%# Eval("Category") %>
                                                </a>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Single Product End -->


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" runat="Server">
</asp:Content>

