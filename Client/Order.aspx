<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterClient.master" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Client_Order" %>

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
        <h1 class="text-center text-white display-6">Checkout</h1>
        <ol class="breadcrumb justify-content-center mb-0">
            <li class="breadcrumb-item"><a href="#">Home</a></li>
            <li class="breadcrumb-item"><a href="#">Pages</a></li>
            <li class="breadcrumb-item active text-white">Checkout</li>
        </ol>
    </div>
    <!-- Single Page Header End -->


    <div class="container-fluid py-5">
        <div class="container py-5">
            <form action="#">
                <div class="container-fluid py-5">
                    <div class="container py-5">
                        <div class="row">
                            <!-- LEFT SIDE: Registration Form -->
                            <div class="col-md-12 col-lg-6">
                                <div class="col-md-12 col-lg-6">

                                    <%-- CheckOutPanelList Start --%>

                                    <div class="order-address-box p-3 shadow bg-white mb-4">
                                        <h4>Shipping Address</h4>
                                        <p>
                                            <strong>Name:</strong>
                                            <asp:Label ID="lblName" runat="server" />
                                        </p>
                                        <p>
                                            <strong>Mobile:</strong>
                                            <asp:Label ID="lblMobile" runat="server" />
                                        </p>
                                        <p>
                                            <strong>Address:</strong>
                                            <asp:Label ID="lblAddress" runat="server" />
                                        </p>
                                        <p>
                                            <strong>Locality:</strong>
                                            <asp:Label ID="lblLocality" runat="server" />
                                        </p>
                                        <p>
                                            <strong>Country:</strong>
                                            <asp:Label ID="lblCountry" runat="server" />
                                        </p>
                                        <p>
                                            <strong>State:</strong>
                                            <asp:Label ID="lblState" runat="server" />
                                        </p>
                                        <p>
                                            <strong>City:</strong>
                                            <asp:Label ID="lblCity" runat="server" />
                                        </p>
                                        <p>
                                            <strong>Pincode:</strong>
                                            <asp:Label ID="lblPincode" runat="server" />
                                        </p>
                                    </div>
                                    <%-- CheckOutPanelList End --%>
                                </div>
                            </div>
                            <!-- RIGHT SIDE: Product Details + Price Summary -->
                            <div class="col-md-12 col-lg-6">
                                <h4 class="mb-3">Your Products</h4>
                                <div class="table-responsive">
                                    <table class="table">
                                        <thead class="table-light">
                                            <tr>
                                                <th>Image</th>
                                                <th>Name</th>
                                                <th>Price</th>
                                                <th>Qty</th>
                                                <th>Total</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="OrderRepeater" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:Image ID="OrderPageProductImage" runat="server" CssClass="img-fluid rounded" ImageUrl='<%# Eval("Icon") %>' Style="width: 50px; height: 50px;" />
                                                        </td>
                                                        <td><%# Eval("Name") %></td>
                                                        <td>₹<asp:Label ID="OrderPageLabelPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="OrderPageLabelQuantity" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                                                        </td>
                                                        <td>₹<asp:Label ID="OrderPageLabelTotal" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </div>

                                <div class="pricing-details bg-light p-4 rounded">
                                    <h5>Price Summary</h5>
                                    <div class="d-flex justify-content-between">
                                        <span>Subtotal:</span>
                                        <asp:Label ID="lblSubTotal" runat="server" Text="0" CssClass="fw-bold"></asp:Label>
                                    </div>
                                    <div class="d-flex justify-content-between">
                                        <span>Shipping:</span>
                                        <asp:Label ID="lblShipping" runat="server" Text="0" CssClass="fw-bold"></asp:Label>
                                    </div>
                                    <hr />
                                    <div class="d-flex justify-content-between">
                                        <strong>Total:</strong>
                                        <asp:Label ID="lblGrandTotal" runat="server" Text="0" CssClass="fw-bold text-success"></asp:Label>
                                    </div>
                                </div>

                                <div class="payment-method bg-white p-4 rounded mt-4 shadow border">
                                    <h5 class="text-dark fw-bold mb-4">
                                        <i class="fas fa-wallet me-2 text-primary"></i>Select Payment Method
                                    </h5>

                                    <div class="row g-3">
                                        <!-- Cash on Delivery Card -->
                                        <div class="col-md-6">
                                            <label class="card p-3 border border-2 border-secondary-subtle shadow-sm rounded-3 h-100 payment-card" style="cursor: pointer;">
                                                <div class="d-flex align-items-center">
                                                    <asp:RadioButton ID="rdoCOD" runat="server" GroupName="Payment" CssClass="form-check-input me-3" />
                                                    <img src="https://cdn-icons-png.flaticon.com/512/2942/2942506.png" width="40" height="40" class="me-3" />
                                                    <div>
                                                        <h6 class="mb-0 fw-semibold">Cash on Delivery</h6>
                                                        <small class="text-muted">Pay when you receive the item</small>
                                                    </div>
                                                </div>
                                            </label>
                                        </div>

                                        <!-- Online Payment Card -->
                                        <div class="col-md-6">
                                            <label class="card p-3 border border-2 border-secondary-subtle shadow-sm rounded-3 h-100 payment-card" style="cursor: pointer;">
                                                <div class="d-flex align-items-center">
                                                    <asp:RadioButton ID="rdoOnline" runat="server" GroupName="Payment" CssClass="form-check-input me-3" />
                                                    <img src="https://cdn-icons-png.flaticon.com/512/196/196565.png" width="40" height="40" class="me-3" />
                                                    <div>
                                                        <h6 class="mb-0 fw-semibold">Online Payment</h6>
                                                        <small class="text-muted">Pay via UPI / Card / NetBanking</small>
                                                    </div>
                                                </div>
                                            </label>
                                        </div>
                                        <%--  <asp:Label ID="lblMessage" runat="server" />--%>
                                    </div>

                                    <!-- Proceed Button -->
                                    <div class="text-end mt-4">

                                        <asp:Button ID="OrderPaymentPageBtn" runat="server" Text="Proceed to Payment" CssClass="btn btn-primary px-4 py-2" OnClick="OrderPaymentPageBtn_Click" />

                                        <asp:Label ID="OrderPageLabelOrderId" runat="server" Text="Label"></asp:Label>
                                     
                                    </div>
                                </div>



                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" runat="Server">
    
</asp:Content>

