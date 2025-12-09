<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="SpecificationsCreate.aspx.cs" Inherits="Admin_SpecificationsCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="Server">
    <div class="container-fluid">



        <!-- start page title -->
        <div class="row">
            <div class="col-12">
                <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                    <h4 class="mb-sm-0">Specifications Form</h4>
                </div>
            </div>
        </div>

        <div class="custom-validation" enctype="multipart/form-data" method="post">
            <!-- end page title -->
            <div class="card mt-4">
                <div class="card-header">
                    <div class="d-flex justify-content-between align-content-center">
                        <h4>Specifications Form</h4>
                        <a href="SpecificationsManage.aspx" class="btn btn-primary">Back</a>
                    </div>
                </div>
                <%--card-header end--%>
                <<div class="card-body">

                    <!-- Specification Name -->
                    <div class="mb-3">
                        <label for="txtSpecification">Specification Name</label>
                        <asp:TextBox ID="txtSpecification" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqSpecification" runat="server"
                            ControlToValidate="txtSpecification"
                            ErrorMessage="Please enter Specification Name"
                            ForeColor="Red" Display="Dynamic" />
                    </div>

                    <!-- Specification Type -->
                    <div class="mb-3">
                        <label for="txtSpecificationType">Specification Type</label>
                        <asp:DropDownList ID="DropSpecificationtype" runat="server" CssClass="form-control">
                            <asp:ListItem Text="--- Select SpecificationType ---" Value="" />
                            <asp:ListItem Text="Text" Value="Text" />
                            <asp:ListItem Text="Options" Value="Options" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqSpecificationType" runat="server"
                            ControlToValidate="DropSpecificationtype" InitialValue=""
                            ErrorMessage="Please select Specification Type"
                            ForeColor="Red" Display="Dynamic" />
                    </div>

                    <!-- Status -->
                    <div class="mb-3">
                        <label for="txtStatus">Status</label>
                        <asp:DropDownList ID="DropSpecificationStatus" runat="server" CssClass="form-control">
                            <asp:ListItem Text="--Select Status--" Value="" />
                            <asp:ListItem Text="Active" Value="Active" />
                            <asp:ListItem Text="Deactive" Value="Deactive" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqStatus" runat="server"
                            ControlToValidate="DropSpecificationStatus" InitialValue=""
                            ErrorMessage="Please select status"
                            ForeColor="Red" Display="Dynamic" />
                    </div>

                </div>


                <div class="card-footer text-center">
                    <asp:Button ID="btnSpecificationSave" runat="server" Text="SAVE" CssClass="btn btn-primary waves-effect waves-light me-1" OnClick="btnSpecificationSave_Click" />

                </div>
            </div>
        </div>



    </div>
    <!-- container-fluid -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" runat="Server">
</asp:Content>

