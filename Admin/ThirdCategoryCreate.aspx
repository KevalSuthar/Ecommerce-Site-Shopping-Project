<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="ThirdCategoryCreate.aspx.cs" Inherits="Admin_ThirdCategoryCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="Server">
    <div class="container-fluid">



        <!-- start page title -->
        <div class="row">
            <div class="col-12">
                <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                    <h4 class="mb-sm-0">Third Category Form</h4>
                </div>
            </div>
        </div>
        <div class="custom-validation" enctype="multipart/form-data" method="post">
            <!-- end page title -->
            <div class="card mt-4">
                <div class="card-header">
                    <div class="d-flex justify-content-between align-content-center">
                        <h4>ThirdCategory Form</h4>
                        <a href="ThirdCategoryManage.aspx" class="btn btn-primary">Back</a>
                    </div>
                </div>

                <div class="card-body">

                    <!-- Category -->
                    <div class="mb-3">
                        <label for="txtCategory">Category</label>
                        <asp:DropDownList ID="DropCategory" OnSelectedIndexChanged="DropCategory_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control">
                            <asp:ListItem Text="--Select Category--" Value="" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqDropCategory" runat="server"
                            ControlToValidate="DropCategory" InitialValue=""
                            ErrorMessage="Please select category" ForeColor="Red" Display="Dynamic" />
                    </div>

                    <!-- SubCategory -->
                    <div class="mb-3">
                        <label for="txtSubCategory">SubCategory</label>
                        <asp:DropDownList ID="DropSubCategory" runat="server" CssClass="form-control">
                            <asp:ListItem Text="--Select SubCategory--" Value="" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqDropSubCategory" runat="server"
                            ControlToValidate="DropSubCategory" InitialValue=""
                            ErrorMessage="Please select subcategory" ForeColor="Red" Display="Dynamic" />
                    </div>

                    <!-- ThirdCategory Text -->
                    <div class="mb-3">
                        <label for="txtThirdCategory">ThirdCategory</label>
                        <asp:TextBox ID="txtThirdCategory" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqThirdCategory" runat="server"
                            ControlToValidate="txtThirdCategory" ErrorMessage="Please enter third category"
                            ForeColor="Red" Display="Dynamic" />
                    </div>

                    <!-- File Upload -->
                    <div class="row">
                        <div class="col-sm-8 col-12">
                            <div class="mb-3">
                                <label for="txtIcon">Icon</label>
                                <asp:FileUpload ID="ThirdCategoryFileUpload" runat="server" CssClass="form-control" />
                              <asp:RequiredFieldValidator ID="reqfile" runat="server" ErrorMessage="Please select image" ForeColor="Red" Display="Dynamic" ControlToValidate="ThirdCategoryFileUpload"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <div class="col-sm-4 col-12">
                            <div class="mb-3">
                                <asp:Image ID="ThirdCateImg" runat="server" Width="100px" Height="100px" CssClass="img-thumbnail" />
                            </div>
                        </div>
                    </div>

                    <!-- Status -->
                    <div class="mb-3">
                        <label for="txtStatus">Status</label>
                        <asp:DropDownList ID="ThirdDropDownStatus" runat="server" CssClass="form-control">
                            <asp:ListItem Text="--Select Status--" Value="" />
                            <asp:ListItem>Active</asp:ListItem>
                            <asp:ListItem>Deactive</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqStatus" runat="server"
                            ControlToValidate="ThirdDropDownStatus" InitialValue=""
                            ErrorMessage="Please select status" ForeColor="Red" Display="Dynamic" />
                    </div>

                </div>

                <div class="card-footer text-center">
                    <asp:Button ID="btnThirdCateSave" runat="server" Text="SAVE" CssClass="btn btn-primary waves-effect waves-light me-1" OnClick="btnThirdCateSave_Click" />
                </div>
            </div>

        </div>




    </div>
    <!-- container-fluid -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" runat="Server">
</asp:Content>

