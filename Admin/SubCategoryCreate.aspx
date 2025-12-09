<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="SubCategoryCreate.aspx.cs" Inherits="Admin_SubCategoryCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="Server">
    <div class="container-fluid">



        <!-- start page title -->
        <div class="row">
            <div class="col-12">
                <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                    <h4 class="mb-sm-0">Sub Category Form</h4>
                </div>
            </div>
        </div>
        <div class="custom-validation" enctype="multipart/form-data" method="post">
            <!-- end page title -->

            <div class="card mt-4">
                <div class="card-header">
                    <div class="d-flex justify-content-between align-content-center">
                        <h4>SubCategory Form</h4>
                        <a href="SubCategoryManage.aspx" class="btn btn-primary">Back</a>
                    </div>
                </div>

                <div class="card-body">

                    <!-- Category Dropdown -->
                    <div class="mb-3">
                        <label for="txtCategory">Category</label>
                        <asp:DropDownList ID="SubCateFormDropCategory" runat="server" CssClass="form-control">
                            <asp:ListItem Text="--Select Category--" Value="" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqCategory" runat="server"
                            ControlToValidate="SubCateFormDropCategory" InitialValue=""
                            ErrorMessage="Please select category" ForeColor="Red" Display="Dynamic" />
                    </div>

                    <!-- SubCategory Text -->
                    <div class="mb-3">
                        <label for="txtSubCategory">SubCategory</label>
                        <asp:TextBox ID="txtSubCategory" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqSubCategory" runat="server"
                            ControlToValidate="txtSubCategory" ErrorMessage="Please enter subcategory name"
                            ForeColor="Red" Display="Dynamic" />
                    </div>

                    <!-- Icon Upload -->
                    <div class="row">
                        <div class="col-sm-8 col-12">
                            <div class="mb-3">
                                <label for="txtIcon">Icon</label>
                                <asp:FileUpload ID="SubCategoryFileUpload" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="reqfile" runat="server" ErrorMessage="Please select image" ForeColor="Red" Display="Dynamic" ControlToValidate="SubCategoryFileUpload"></asp:RequiredFieldValidator>
                            
                            </div>
                        </div>
                        <div class="col-sm-4 col-12">
                            <div class="mb-3">
                                <asp:Image ID="SubCateImg" runat="server" Width="100px" Height="100px" CssClass="img-thumbnail" />
                            </div>
                        </div>
                    </div>

                    <!-- Status Dropdown -->
                    <div class="mb-3">
                        <label for="txtStatus">Status</label>
                        <asp:DropDownList ID="SubDropDownStatus" runat="server" CssClass="form-control">
                            <asp:ListItem Text="--Select Status--" Value="" />
                            <asp:ListItem>Active</asp:ListItem>
                            <asp:ListItem>Deactive</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqStatus" runat="server"
                            ControlToValidate="SubDropDownStatus" InitialValue=""
                            ErrorMessage="Please select status" ForeColor="Red" Display="Dynamic" />
                    </div>
                </div>

                <div class="card-footer text-center">
                    <asp:Button ID="btnSubCateSave" runat="server" Text="SAVE"
                        CssClass="btn btn-primary waves-effect waves-light me-1"
                        OnClick="btnSubCateSave_Click" />
                </div>
            </div>

        </div>


    </div>
    <!-- container-fluid -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" runat="Server">
</asp:Content>

