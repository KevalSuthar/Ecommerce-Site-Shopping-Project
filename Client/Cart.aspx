<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterClient.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Client_Cart" %>

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
        <h1 class="text-center text-white display-6">Cart</h1>
        <ol class="breadcrumb justify-content-center mb-0">
            <li class="breadcrumb-item"><a href="#">Home</a></li>
            <li class="breadcrumb-item"><a href="#">Pages</a></li>
            <li class="breadcrumb-item active text-white">Cart</li>
        </ol>
    </div>
    <!-- Single Page Header End -->

    <!-- Cart Page Start -->
    <div class="container-fluid py-5">
        <div class="container py-5">
            <div class="table-responsive">
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">Products</th>
                            <th scope="col">Name</th>
                            <th scope="col">Price</th>
                            <th scope="col">Quantity</th>
                            <th scope="col">Total</th>
                            <th scope="col">Check</th>
                            <th scope="col">Delete</th>
                            <th scope="col">Update</th>

                        </tr>
                    </thead>
                    <tbody>

                        <%-- DataFill --%>

                        <asp:Repeater ID="rptcart" OnItemCommand="rptcart_ItemCommand" runat="server">
                            <ItemTemplate>

                                <tr>
                                    <%-- Image --%>
                                    <th scope="row">
                                        <div class="d-flex align-items-center" style="width: 140px; height: 140px; overflow: hidden;">
                                            <asp:Image ID="CartImage" runat="server"
                                                CssClass="img-fluid rounded"
                                                ImageUrl='<%# Eval("Icon") %>'
                                                Style="width: 100%; height: 100%; object-fit: contain;" />
                                        </div>
                                    </th>

                                    <%-- Name --%>
                                    <td>
                                        <p class="mb-0 mt-4"><%#Eval("Name")%></p>
                                    </td>

                                    <%-- Price --%>
                                    <td>
                                        <p class="mb-0 mt-4">₹ <%#Eval("Price")%></p>
                                    </td>

                                    <%-- PLUS-MINUS --%>
                                    <td>
                                        <div class="input-group quantity mb-5" style="width: 100px; margin-top: 20px;">
                                            <div class="d-flex align-items-center gap-2" style="width: fit-content;">
                                                <!-- Minus Button -->
                                                <%--      <asp:Button ID="btnMinus" runat="server"
                                                    CssClass="btn btn-sm rounded-circle bg-light border d-flex align-items-center justify-content-center"
                                                    Style="width: 32px; height: 32px; padding: 0;"
                                                    Text="-" ToolTip="Decrease" />--%>

                                                <!-- Quantity TextBox -->
                                                <asp:TextBox ID="CartTxtQty" runat="server"
                                                    CssClass="form-control text-center border"
                                                    Style="width: 50px; height: 32px; padding: 0;"
                                                    Text='<%# Eval("Qty") %>'></asp:TextBox>

                                                <!-- Plus Button -->
                                                <%--   <asp:Button ID="btnPlus" runat="server"
                                                    CssClass="btn btn-sm rounded-circle bg-light border d-flex align-items-center justify-content-center"
                                                    Style="width: 32px; height: 32px; padding: 0;"
                                                    Text="+" ToolTip="Increase" />--%>
                                            </div>
                                        </div>
                                    </td>

                                    <%-- Total --%>
                                    <td>
                                        <p class="mb-0 mt-4">₹<%#Eval("Total") %></p>
                                    </td>
                                    <%-- Check --%>
                                    <td>
                                        <p class="mb-0 mt-4">
                                            <asp:CheckBox ID="chkproduct" runat="server" />
                                            <asp:HiddenField ID="Hiddenchk" runat="server" Value='<%#Eval("CartId") %>' />
                                        </p>
                                    </td>

                                    <%-- Cancel Order --%>
                                    <td>
                                        <asp:LinkButton ID="btndelete"
                                            CssClass="btn btn-md rounded-circle bg-light border mt-4"
                                            CommandName="Del"
                                            CommandArgument='<%# Eval("CartId") %>' runat="server">
                                            <i class="fa fa-times text-danger"></i>
                                        </asp:LinkButton>
                                    </td>

                                    <%-- Update --%>
                                    <td>
                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="CartProductUpdate" CommandArgument='<%#Eval("ProductId") %>' CssClass="btn border border-secondary rounded-pill px-4 py-2 mt-3 text-primary" />
                                    </td>
                                </tr>

                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>


            <%-- Calculator --%>
            <div class="row g-4 justify-content-end">
                <div class="col-8">

                
                    <asp:Button  CssClass="btn btn-danger" ID="Button1" OnClick="Button1_Click" runat="server" Text="Delete Product" />
                


                </div>

                <div class="col-sm-8 col-md-7 col-lg-6 col-xl-4">
                    <div class="bg-light rounded">
                        <div class="p-4">
                            <h1 class="display-6 mb-4">Cart<span class="fw-normal">Total</span></h1>
                            <%--Sub Total--%>
                            <div class="d-flex justify-content-between mb-4">
                                <h5 class="mb-0 me-4">Subtotal:</h5>
                                <p class="price">$<asp:Label ID="CartlblTotal" runat="server" Text="0"></asp:Label></p>
                            </div>

                            <%-- Shipping Charge --%>
                            <div class="d-flex justify-content-between">
                                <h5 class="mb-0 me-4">Shipping Charge</h5>
                                <p class="ShippingCharge">$<asp:Label ID="CartlblShippingCharge" runat="server" Text="0"></asp:Label></p>

                            </div>
                        </div>

                        <%-- Total --%>
                        <div class="py-4 mb-4 border-top border-bottom d-flex justify-content-between">
                            <h5 class="mb-0 ps-4 me-4">Total</h5>
                            <p class="price">$<asp:Label ID="CartlblSubTotal" runat="server" Text="0"></asp:Label></p>

                        </div>


                        <%-- BTN check out --%>
                        <%--<button class="btn border-secondary rounded-pill px-4 py-3 text-primary text-uppercase mb-4 ms-4" type="button">Proceed Checkout</button>--%>
                        <asp:LinkButton ID="CartBtnCheckOut" runat="server" CssClass="btn border-secondary rounded-pill px-4 py-3 text-primary text-uppercase mb-4 ms-4" OnClick="CartBtnCheckOut_Click">Proceed To Checkout</asp:LinkButton>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <!-- Cart Page End -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" runat="Server">
</asp:Content>

