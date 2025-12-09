<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="BrandCreate.aspx.cs" Inherits="Admin_BrandCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="Server">
    <div class="container-fluid">
        <!-- start page title -->
        <div class="row">
            <div class="col-12">
                <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                    <h4 class="mb-sm-0">Brand Form</h4>

                </div>
            </div>
        </div>

        <div class="custom-validation" enctype="multipart/form-data" method="post">
            <!-- end page title -->
            <div class="card">
                <div class="card-header">
                    <div class="d-flex justify-content-between align-content-center">
                        <h4>Brand Form</h4>
                        <a href="BrandManage.aspx" class="btn btn-primary">Back</a>
                    </div>
                </div>

                <div class="card-body">

                    <!-- Brand Name -->
                    <div class="mb-3">
                        <label for="txtBrand">Brand</label>
                        <asp:TextBox ID="txtBrand" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqBrand" runat="server"
                            ControlToValidate="txtBrand" ErrorMessage="Please enter brand name"
                            ForeColor="Red" Display="Dynamic" />
                    </div>

                    <!-- File Upload -->
                    <div class="row">
                        <div class="col-sm-8 col-12">
                            <div class="mb-3">
                                <label for="txtIcon">Icon</label>
                                <asp:FileUpload ID="BrandFileUpload" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="reqfile" runat="server" ErrorMessage="Please select image" ForeColor="Red" Display="Dynamic" ControlToValidate="BrandFileUpload"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <div class="col-sm-4 col-12">
                            <div class="mb-3">
                                <asp:Image ID="BrandImg" runat="server" Width="100px" Height="100px" CssClass="img-thumbnail" />
                            </div>
                        </div>
                    </div>

                    <!-- Status -->
                    <div class="mb-3">
                        <label for="txtCateStatus">Status</label>
                        <asp:DropDownList ID="DropBrandStatus" runat="server" CssClass="form-control">
                            <asp:ListItem Text="--Select Status--" Value="" />
                            <asp:ListItem>Active</asp:ListItem>
                            <asp:ListItem>Deactive</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqStatus" runat="server"
                            ControlToValidate="DropBrandStatus" InitialValue=""
                            ErrorMessage="Please select status" ForeColor="Red" Display="Dynamic" />
                    </div>

                </div>

                <div class="card-footer text-center">
                    <asp:Button ID="btnBrandSave" runat="server" Text="SAVE" CssClass="btn btn-primary waves-effect waves-light me-1" OnClick="btnBrandSave_Click" />
                </div>
            </div>

        </div>

    </div>
    <!-- container-fluid -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" runat="Server">
</asp:Content>

