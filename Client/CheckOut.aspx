<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterClient.master" AutoEventWireup="true" CodeFile="CheckOut.aspx.cs" Inherits="Client_CheckOut" %>

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

    <!-- Checkout Page Start -->
    <div class="container-fluid py-5">
        <div class="container py-5">
            <h1 class="mb-4">Billing details</h1>
            <form action="#">
                <div class="container-fluid py-5">
                    <div class="container py-5">

                        <div class="row">
                            <!-- LEFT SIDE: Registration Form -->
                            <div class="col-md-12 col-lg-6">

                                <asp:Panel ID="PanelRegisterForm" runat="server">
                                    <div class="row">
                                        <div class="col-md-6 mb-3">
                                            <label class="form-label">Full Name</label>
                                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="reqname" runat="server"
                                                ControlToValidate="txtName"
                                                ErrorMessage="name is required"
                                                ForeColor="Red"
                                                Display="Dynamic" />
                                        </div>
                                        <div class="col-md-6 mb-3">
                                            <label class="form-label">Mobile</label>
                                            <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="reqmobile" runat="server"
                                                ControlToValidate="txtMobile"
                                                ErrorMessage="Mobile is required"
                                                ForeColor="Red"
                                                Display="Dynamic" />
                                        </div>
                                    </div>

                                    <div class="mb-3">
                                        <label class="form-label">Alternate Mobile</label>
                                        <asp:TextBox ID="txtAltMobile" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqaltmobile" runat="server"
                                            ControlToValidate="txtAltMobile"
                                            ErrorMessage="AltMobile is required"
                                            ForeColor="Red"
                                            Display="Dynamic" />
                                    </div>

                                    <div class="mb-3">
                                        <label class="form-label">Address</label>
                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="House No, Street Name"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqaddress" runat="server"
                                            ControlToValidate="txtAddress"
                                            ErrorMessage="Address is required"
                                            ForeColor="Red"
                                            Display="Dynamic" />
                                    </div>

                                    <div class="mb-3">
                                        <label class="form-label">Locality</label>
                                        <asp:TextBox ID="txtLocality" runat="server" CssClass="form-control" placeholder="Area/Colony"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqlocality" runat="server"
                                            ControlToValidate="txtLocality"
                                            ErrorMessage="Locality is required"
                                            ForeColor="Red"
                                            Display="Dynamic" />
                                    </div>

                                    <div class="row">
                                        <div class="col-md-4 mb-3">
                                            <label class="form-label">Country</label>
                                            <asp:DropDownList ID="DropCountry" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropCountry_SelectedIndexChanged"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="reqcountry" runat="server"
                                                ControlToValidate="DropCountry"
                                                InitialValue=""
                                                ErrorMessage="Please select a Country"
                                                ForeColor="Red" Display="Dynamic" />
                                        </div>
                                        <div class="col-md-4 mb-3">
                                            <label class="form-label">State</label>
                                            <asp:DropDownList ID="DropState" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropState_SelectedIndexChanged"></asp:DropDownList>
                                         <asp:RequiredFieldValidator ID="reqstate" runat="server"
                                                ControlToValidate="DropState"
                                                InitialValue=""
                                                ErrorMessage="Please select a State"
                                                ForeColor="Red" Display="Dynamic" />
                                        </div>
                                        <div class="col-md-4 mb-3">
                                            <label class="form-label">City</label>
                                            <asp:DropDownList ID="DropCity" runat="server" CssClass="form-control"></asp:DropDownList>
                                              <asp:RequiredFieldValidator ID="reqcity" runat="server"
                                                ControlToValidate="DropCity"
                                                InitialValue=""
                                                ErrorMessage="Please select a City"
                                                ForeColor="Red" Display="Dynamic" />
                                        </div>
                                    </div>

                                    <div class="mb-3">
                                        <label class="form-label">Pincode</label>
                                        <asp:TextBox ID="txtPincode" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqpin" runat="server"
                                            ControlToValidate="txtPincode"
                                            ErrorMessage="Pincode is required"
                                            ForeColor="Red"
                                            Display="Dynamic" />
                                    </div>

                                    <div class="mb-3">
                                        <label class="form-label">Address Type</label>
                                        <asp:DropDownList ID="DropAddressType" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Select Type" Value="" />
                                            <asp:ListItem Text="Home" Value="Home" />
                                            <asp:ListItem Text="Work" Value="Work" />
                                        </asp:DropDownList>
                                          <asp:RequiredFieldValidator ID="reqaddtype" runat="server"
                                                ControlToValidate="DropAddressType"
                                                InitialValue=""
                                                ErrorMessage="Please select a AddressType"
                                                ForeColor="Red" Display="Dynamic" />
                                    </div>

                                    <div class="mb-3">
                                        <label class="form-label">Status</label>
                                        <asp:DropDownList ID="DropStatus" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Select Type" Value="" />
                                            <asp:ListItem Text="Active" Value="Active" />
                                            <asp:ListItem Text="DeActive" Value="DeActive" />

                                        </asp:DropDownList>
                                          <asp:RequiredFieldValidator ID="reqstatus" runat="server"
                                                ControlToValidate="DropStatus"
                                                InitialValue=""
                                                ErrorMessage="Please select a Status"
                                                ForeColor="Red" Display="Dynamic" />
                                    </div>

                                    <asp:Button ID="btnSaveShipping" runat="server" CssClass="btn btn-success w-100 mt-3" Text="Save Shipping Info" OnClick="btnSaveShipping_Click" />
                                </asp:Panel>
                                <div class="col-md-12 col-lg-6">

                                    <%-- CheckOutPanelList Start --%>
                                    <asp:Panel ID="PanelAddressList" runat="server">
                                        <asp:Button ID="btnAddNewAddress" runat="server" CssClass="btn btn-primary mb-3" OnClick="btnAddNewAddress_Click" Text="Add New Address" Visible="false" />
                                        <asp:Repeater ID="CheckoutRepeaterListAddress" runat="server" OnItemCommand="CheckoutRepeaterListAddress_ItemCommand">
                                            <ItemTemplate>
                                                <div class="rts-cart-list-area mt-3">



                                                    <div class="single-cart-area-list head">
                                                        <h4>Address</h4>
                                                    </div>

                                                    <div class="single-cart-area-list main item-parent AddressData border rounded bg-white p-3 shadow-sm">
                                                        <div class="AddressList">

                                                            <!-- Name -->
                                                            <h5 class="fw-bold mb-2">
                                                                <i class="bi bi-person-fill text-primary me-2"></i>
                                                                <asp:Label ID="CheckOutLabelStateName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                                            </h5>

                                                            <!-- Mobile Number -->
                                                            <p class="mb-1">
                                                                <i class="bi bi-telephone-fill text-success me-2"></i>
                                                                <asp:Label ID="CheckOutLabelMobile" runat="server" Text='<%#Eval("Mobile") %>'></asp:Label>
                                                            </p>

                                                            <!-- Locality -->
                                                            <p class="mb-1">
                                                                <i class="bi bi-signpost-2-fill text-info me-2"></i>
                                                                <asp:Label ID="CheckOutLabelLocality" runat="server" Text='<%#Eval("Locality") %>'></asp:Label>
                                                            </p>

                                                            <!-- City -->
                                                            <p class="mb-1">
                                                                <i class="bi bi-geo-alt-fill text-danger me-2"></i>
                                                                <asp:Label ID="CheckOutLabelCityName" runat="server" Text='<%#Eval("CityName") %>'></asp:Label>
                                                            </p>

                                                            <!-- Address -->
                                                            <p class="mb-1">
                                                                <i class="bi bi-house-fill text-secondary me-2"></i>
                                                                <asp:Label ID="CheckOutLabelAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                                            </p>

                                                            <!-- Pincode -->
                                                            <p>
                                                                <i class="bi bi-mailbox text-warning me-2"></i>
                                                                <asp:Label ID="CheckOutLabelPincode" runat="server" Text='<%#Eval("Pincode") %>'></asp:Label>
                                                            </p>
                                                        </div>

                                                        <!-- Place Order Button -->
                                                        <div class="AddressBtn mt-3">
                                                            <asp:LinkButton ID="CkeckoutBtnOrderPage"
                                                                CssClass="btn btn-outline-primary px-4 py-2"
                                                                CommandName="PlaceOrderPage"
                                                                CommandArgument='<%#Eval("ShippingId") %>' runat="server">Place Order</asp:LinkButton>

                                                            <asp:LinkButton ID="btnUpdate"
                                                                CssClass="btn btn-outline-primary px-4 py-2"
                                                                CommandName="UpdatePage"
                                                                CommandArgument='<%#Eval("ShippingId") %>' runat="server">Update</asp:LinkButton>

                                                            <asp:LinkButton ID="btnDelete" runat="server"
                                                                CssClass="btn btn-outline-danger px-4 py-2 mt-3"
                                                                CommandName="DeletePage"
                                                                CommandArgument='<%#Eval("ShippingId") %>'
                                                                OnClientClick="return confirm('Are you sure you want to delete this address?');">
                                                            Delete
                                                            </asp:LinkButton>
                                                        </div>



                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </asp:Panel>

                                    <%-- CheckOutPanelList End --%>
                                </div>
                            </div>

                            <!-- RIGHT SIDE: Product Details + Price Summary -->
                            <div class="col-md-12 col-lg-6">
                                <h4 class="mb-3">Your Products</h4>
                                <asp:Panel ID="PanelCart" runat="server">
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
                                                <asp:Repeater ID="rptchk" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <asp:Image ID="CartImage" runat="server" CssClass="img-fluid rounded" ImageUrl='<%# Eval("Icon") %>' Style="width: 50px; height: 50px;" />
                                                            </td>
                                                            <td><%# Eval("Name") %></td>
                                                            <td>₹ <%# Eval("Price") %></td>
                                                            <td><%# Eval("Qty") %></td>
                                                            <td>₹ <%# Eval("Total") %></td>
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
                                </asp:Panel>
                            </div>
                        </div>

                    </div>
                </div>
            </form>
        </div>
    </div>
    <!-- Checkout Page End -->


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" runat="Server">
</asp:Content>

