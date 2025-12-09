<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="CategoryCreate.aspx.cs" Inherits="Admin_CategoryCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="Server">

    <div class="container-fluid">

        <!-- start page title -->
        <div class="row">
            <div class="col-12">
                <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                    <h4 class="mb-sm-0">Category</h4>
                </div>
            </div>
        </div>

        <div class="custom-validation" enctype="multipart/form-data" method="post" novalidate="novalidate">
            <!-- end page title -->
            <div class="card mt-4">

                <div class="card-header">
                    <div class="d-flex justify-content-between align-content-center">
                        <h4>Category Form</h4>
                        <a href="CategoryManage.aspx" class="btn btn-primary">Back</a>
                    </div>
                </div>
                <%-- Card-Header --%>
                <div class="card-body">

                    <!-- Category Name -->
                    <div class="mb-3">
                        <label for="txtCategory">Category</label>
                        <asp:TextBox ID="txtCategory" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqCategoryName" runat="server"
                            ControlToValidate="txtCategory" ErrorMessage="Please enter category name"
                            ForeColor="Red" Display="Dynamic" />
                    </div>

                    <!-- Icon Upload -->
                    <div class="row">
                        <div class="col-sm-8 col-12">
                            <div class="mb-3">
                                <label for="txtIcon">Icon</label>
                                <asp:FileUpload ID="CategoryFileUpload" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="reqfile" runat="server" ErrorMessage="Please select image" ForeColor="Red" Display="Dynamic" ControlToValidate="CategoryFileUpload"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <div class="col-sm-4 col-12">
                            <div class="mb-3">
                                <asp:Image ID="CategoryImg" runat="server" Width="100px" Height="100px" CssClass="img-thumbnail" />
                            </div>
                        </div>
                    </div>

                    <!-- Status Dropdown -->
                    <div class="mb-3">
                        <label for="txtCateStatus">Status</label>
                        <asp:DropDownList ID="DropCateStatus" runat="server" CssClass="form-control">
                            <asp:ListItem Text="--Select Status--" Value="" />
                            <asp:ListItem>Active</asp:ListItem>
                            <asp:ListItem>Deactive</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqStatus" runat="server"
                            ControlToValidate="DropCateStatus" InitialValue=""
                            ErrorMessage="Please select status" ForeColor="Red" Display="Dynamic" />
                    </div>

                </div>

                <%-- Card-body--%>

                <div class="card-footer text-center">
                    <asp:Panel ID="Panel1" runat="server">
                        <asp:Button ID="btnCateSave" runat="server" Text="SAVE" CssClass="btn btn-primary waves-effect waves-light me-1" OnClick="btnCateSave_Click" />
                    </asp:Panel>
                </div>
            </div>
            <%-- Card - END  --%>
        </div>

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" runat="Server">
</asp:Content>

