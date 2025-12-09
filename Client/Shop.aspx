<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterClient.master" AutoEventWireup="true" CodeFile="Shop.aspx.cs" Inherits="Client_Shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="Server">

    <style>
        .txt1 {
            width: 100px;
            padding: 6px 10px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 4px;
            text-align: center;
            background-color: #f9f9f9;
            outline: none;
            transition: border 0.2s ease-in-out, background-color 0.2s ease-in-out;
        }

            .txt1:focus {
                border-color: #007bff;
                background-color: #fff;
            }
    </style>


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
        <h1 class="text-center text-white display-6">Shop</h1>
        <ol class="breadcrumb justify-content-center mb-0">
            <li class="breadcrumb-item"><a href="index.aspx">Home</a></li>
            <li class="breadcrumb-item"><a href="#">Pages</a></li>
            <li class="breadcrumb-item active text-white">Shop</li>
        </ol>
    </div>
    <!-- Single Page Header End -->


    <!-- Fruits Shop Start-->
    <div class="container-fluid fruite py-5">
        <div class="container py-5">
            <h1 class="mb-4">Furniture Shop</h1>
            <div class="row g-4">
                <div class="col-lg-12">
                    <div class="row g-4 mb-5">
                        <div class="col-xl-3">
                          <%--  <div class="input-group w-100 mx-auto d-flex">
                                <input type="search" class="form-control p-3" placeholder="keywords" aria-describedby="search-icon-1">
                                <span id="search-icon-1" class="input-group-text p-3"><i class="fa fa-search"></i></span>
                            </div>--%>
                        </div>
                        <div class="col-6"></div>
                        <div class="col-xl-3">
                            <div class="d-flex justify-content-between align-content-center">
                                <h1>Fliter</h1>
                                <asp:DropDownList runat="server" ID="dropFillter" AutoPostBack="true" OnSelectedIndexChanged="dropFillter_SelectedIndexChanged">
                                    <asp:ListItem Text="Select Filter" Value="0" />
                                    <asp:ListItem Text="A-Z" Value="1" />
                                    <asp:ListItem Text="Z-A" Value="2" />
                                    <asp:ListItem Text="Low to High" Value="3" />
                                    <asp:ListItem Text="High to Low" Value="4" />
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="row g-4">
                        <div class="col-lg-3">
                            <div class="row g-4">
                                <div class="col-lg-12">
                                    <div class="mb-3" id="SubCategory" runat="server" visible="false">
                                        <h4>SubCategories</h4>
                                        <asp:Repeater ID="rptSubCategory" runat="server">
                                            <ItemTemplate>
                                                <li class="mb-2" style="list-style: none">
                                                    <div class="d-flex justify-content-between fruite-name">
                                                        <a href='Shop.aspx?CategoryId=<%# Eval("CategoryId") %>&SubCategoryId=<%# Eval("SubCategoryId") %>' class="text-decoration-none">
                                                            <i class="fas fa-apple-alt me-2"></i><%# Eval("SubCategory") %>
                                                        </a>
                                                    </div>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="mb-3" id="ThirdCategory" runat="server" visible="false">
                                        <h4>ThirdCategories</h4>
                                        <asp:Repeater ID="rptThirdCategory" runat="server">
                                            <ItemTemplate>
                                                <li class="mb-2" style="list-style: none">
                                                    <div class="d-flex justify-content-between fruite-name">
                                                        <a href='Shop.aspx?CategoryId=<%# Eval("CategoryId") %>&SubCategoryId=<%# Eval("SubCategoryId") %>&ThirdCategoryId=<%# Eval("ThirdCategoryId") %>' class="text-decoration-none">
                                                            <i class="fas fa-apple-alt me-2"></i><%# Eval("ThirdCategory") %>
                                                        </a>
                                                    </div>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </div>
                                </div>
                                <div class="col-lg-12">


                                    <!-- Price Range Slider -->
                                    <div class="mb-3">
                                        <h5 class="mb-2">Price Range</h5>

                                        <!-- Show Min-Max Labels -->
                                        <div class="d-flex justify-content-between mb-2">
                                            <%--    <span>Min: ₹<span id="min-price">0</span></span>
                                            <span>Max: ₹<span id="max-price">100000</span></span>--%>
                                            <asp:TextBox ID="minprice" CssClass="txt1" runat="server">₹</asp:TextBox>
                                            <asp:TextBox ID="maxprice" CssClass="txt1" runat="server">₹</asp:TextBox>
                                        </div>


                                        <div id="slider"></div>

                                        <input type="hidden" id="hdnMin" name="min-price" />
                                        <input type="hidden" id="hdnMax" name="max-price" />

                                        <asp:LinkButton ID="btnFilterPrice" runat="server" CssClass="btn btn-primary mt-3" OnClick="btnFilterPrice_Click">Apply Filter</asp:LinkButton>

                                    </div>

                                </div>
                            </div>
                        </div>

                        <div class="col-lg-9">
                            <div class="row g-4 justify-content-center">


                                <%-- Category Query String --%>

                                <asp:Repeater ID="rptProduct" runat="server">
                                    <ItemTemplate>
                                        <div class="col-md-6 col-lg-6 col-xl-4 mb-4">
                                            <div class="rounded position-relative fruite-item border shadow-sm d-flex flex-column h-100">

                                                <!-- Image Block -->
                                                <div class="fruite-img d-flex justify-content-center align-items-center" style="height: 200px; background-color: #f8f9fa;">
                                                    <asp:Image ID="ProductImage" runat="server"
                                                        class="img-fluid"
                                                        ImageUrl='<%#Eval("Icon")%>'
                                                        Style="max-height: 100%; max-width: 100%; object-fit: contain;" />
                                                </div>

                                                <!-- Product Info Block -->
                                                <div class="p-4 border-top rounded-bottom d-flex flex-column justify-content-between flex-grow-1">

                                                    <!-- Title and Brand -->
                                                    <div>
                                                        <h5 class="fw-semibold mb-2 text-truncate"><%#Eval("Name")%></h5>
                                                        <p class="mb-2 text-muted">Brand: <%#Eval("Brand")%></p>
                                                    </div>

                                                    <!-- Price and Add to Cart -->
                                                    <div class="d-flex justify-content-between align-items-center mt-3">
                                                        <p class="text-dark fs-5 fw-bold mb-0">₹ <%#Eval("Price")%></p>
                                                        <a href="ShopDetail.aspx?ProductId=<%# Eval("ProductId") %>" class="btn border border-secondary rounded-pill px-3 text-primary">
                                                            <i class="fa fa-shopping-bag me-2 text-primary"></i>Add to cart
                                                        </a>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>

                                    </ItemTemplate>
                                </asp:Repeater>

                             

                                <div class="col-12">
                                    <div class="pagination d-flex justify-content-center mt-5">
                                        <a href="#" class="rounded">«</a>
                                        <a href="#" class="active rounded">1</a>
                                        <a href="#" class="rounded">2</a>
                                        <a href="#" class="rounded">3</a>
                                        <a href="#" class="rounded">4</a>
                                        <a href="#" class="rounded">5</a>
                                        <a href="#" class="rounded">6</a>
                                        <a href="#" class="rounded">»</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Fruits Shop End-->



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" runat="Server">

    <script>

        $(function () {
            var min = typeof dbMin !== 'undefined' ? dbMin : 0;
            var max = typeof dbMax !== 'undefined' ? dbMax : 100000;

            $("#slider").slider({
                range: true,
                min: min,
                max: max,
                values: [min, max],
                slide: function (event, ui) {
                    $("#hdnMin").val(ui.values[0]);
                    $("#hdnMax").val(ui.values[1]);
                    $("#minprice").text(ui.values[0]);
                    $("#maxprice").text(ui.values[1]);
                }
            });

            // Set default labels and hidden fields
            $("#hdnMin").val(min);
            $("#hdnMax").val(max);
            $("#minprice").text(min);
            $("#maxprice").text(max);
        });


    </script>
</asp:Content>

