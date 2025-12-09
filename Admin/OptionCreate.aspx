<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="OptionCreate.aspx.cs" Inherits="Admin_OptionCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="Server">
    <div class="container-fluid">

        <!-- start page title -->
        <div class="row">
            <div class="col-12">
                <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                    <h4 class="mb-sm-0">Options</h4>
                </div>
            </div>
        </div>

        <div class="custom-validation" enctype="multipart/form-data" method="post">
            <!-- end page title -->
            <div class="card">
                <div class="card-header">
                    <div class="d-flex justify-content-between align-content-center">
                        <h4>Options Form</h4>
                        <a href="OptionManage.aspx" class="btn btn-primary">Back</a>
                    </div>
                </div>

                <div class="card-body">

                    <!-- Specification Dropdown -->
                    <div class="mb-3 mt-4">
                        <label for="Speicification">Specification</label>
                        <asp:DropDownList ID="OptionFormDropSpeicification" runat="server" CssClass="form-control">
                            <asp:ListItem Text="--Select Specification--" Value="" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqSpecification" runat="server"
                            ControlToValidate="OptionFormDropSpeicification" InitialValue=""
                            ErrorMessage="Please select Specification"
                            ForeColor="Red" Display="Dynamic" />
                    </div>

                    <!-- Value TextBox -->
                    <div class="mb-3">
                        <label for="txtValue">Value</label>
                        <asp:TextBox ID="txtValue" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqValue" runat="server"
                            ControlToValidate="txtValue"
                            ErrorMessage="Please enter Value"
                            ForeColor="Red" Display="Dynamic" />
                    </div>

                    <!-- Status Dropdown -->
                    <div class="mb-3">
                        <label for="txtCateStatus">Status</label>
                        <asp:DropDownList ID="DropOptionStatus" runat="server" CssClass="form-control">
                            <asp:ListItem Text="--Select Status--" Value="" />
                            <asp:ListItem Text="Active" Value="Active" />
                            <asp:ListItem Text="Deactive" Value="Deactive" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqStatus" runat="server"
                            ControlToValidate="DropOptionStatus" InitialValue=""
                            ErrorMessage="Please select Status"
                            ForeColor="Red" Display="Dynamic" />
                    </div>

                </div>

                <div class="card-footer text-center">
                    <asp:Button ID="btnOptionSave" runat="server" Text="SAVE" CssClass="btn btn-primary waves-effect waves-light me-1" OnClick="btnOptionSave_Click" />
                </div>
            </div>

        </div>




    </div>
    <!-- container-fluid -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" runat="Server">
</asp:Content>

