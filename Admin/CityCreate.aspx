<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="CityCreate.aspx.cs" Inherits="Admin_Citt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="Server">

    <!-- start page title -->
    <div class="row">
        <div class="col-12">
            <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                <h4 class="mb-sm-0">City</h4>
            </div>
        </div>
    </div>
    <div class="custom-validation" enctype="multipart/form-data" method="post" novalidate="novalidate">
        <!-- end page title -->
        <div class="card mt-4">

            <div class="card-header">
                <div class="d-flex justify-content-between align-content-center">
                    <h4>City Form</h4>
                    <a href="CityManage.aspx" class="btn btn-primary">Back</a>
                </div>
            </div>
            <%-- Card-Header --%>
            <div class="card-body">
                <div class="mb-3">
                </div>
                <div class="row">
                    <div class="col-sm-8 col-12">
                        <div class="mb-3">
                            <label for="Country">Coutry</label>
                            <asp:DropDownList ID="CountryFormDropCountry" OnSelectedIndexChanged="CountryFormDropCountry_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="reqCountry" runat="server"
                                ControlToValidate="CountryFormDropCountry"
                                InitialValue=""
                                ErrorMessage="Please select a country"
                                ForeColor="Red" Display="Dynamic" />
                        </div>
                    </div>

                </div>
                <div class="mb-3">
                    <label for="State">State</label>
                    <asp:DropDownList ID="CountryFormDropState" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="reqState" runat="server"
                        ControlToValidate="CountryFormDropState"
                        InitialValue=""
                        ErrorMessage="Please select a State"
                        ForeColor="Red" Display="Dynamic" />
                </div>

                <div class="mb-3">

                    <label for="txtCity">City</label>
                    <asp:TextBox ID="txtCity" CssClass="form-control" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="reqCity" runat="server"
                                ControlToValidate="txtCity"
                                ErrorMessage="Please enter Value"
                                ForeColor="Red" Display="Dynamic" />
                </div>

                <div class="card-footer text-center">

                    <asp:Button ID="btnCitySave" runat="server" Text="SAVE" CssClass="btn btn-primary waves-effect waves-light me-1" OnClick="btnCitySave_Click" />

                </div>
            </div>
            <%-- Card-body--%>
        </div>
        <%-- Card - END  --%>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" runat="Server">
</asp:Content>

