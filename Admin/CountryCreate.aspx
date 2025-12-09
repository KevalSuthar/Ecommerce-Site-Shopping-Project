<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="CountryCreate.aspx.cs" Inherits="Admin_Country" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="Server">
    <!-- start page title -->
    <div class="row">
        <div class="col-12">
            <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                <h4 class="mb-sm-0">Counrt</h4>
            </div>
        </div>
    </div>
    <div class="custom-validation" enctype="multipart/form-data" method="post" novalidate="novalidate">
        <!-- end page title -->
        <div class="card mt-4">

            <div class="card-header">
                <div class="d-flex justify-content-between align-content-center">
                    <h4>Country Form</h4>
                    <a href="CountryManage.aspx" class="btn btn-primary">Back</a>
                </div>
            </div>
            <%-- Card-Header --%>
            <div class="card-body">

                <!-- Country Dropdown -->
                <div class="mb-3">
                    <label for="Country">Country</label>
                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                        <asp:ListItem Text="Select Country" Value="" />
                        <asp:ListItem Text="India" Value="India" />
                        <asp:ListItem Text="United States" Value="United States" />
                        <asp:ListItem Text="France" Value="France" />
                        <asp:ListItem Text="Germany" Value="Germany" />
                        <asp:ListItem Text="Japan" Value="Japan" />
                        <asp:ListItem Text="China" Value="China" />
                        <asp:ListItem Text="Brazil" Value="Brazil" />
                        <asp:ListItem Text="Russia" Value="Russia" />
                        <asp:ListItem Text="Saudi Arabia" Value="Saudi Arabia" />
                        <asp:ListItem Text="South Korea" Value="South Korea" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqCountry" runat="server"
                        ControlToValidate="ddlCountry"
                        InitialValue=""
                        ErrorMessage="Please select a country"
                        ForeColor="Red" Display="Dynamic" />
                </div>

                <!-- Country Code Dropdown -->
                <div class="row">
                    <div class="col-sm-8 col-12">
                        <div class="mb-3">
                            <label for="CountryCode">Country Code</label>
                            <asp:DropDownList ID="ddlCountryCode" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Select Code" Value="" />
                                <asp:ListItem Text="+91 (India)" Value="+91" />
                                <asp:ListItem Text="+1 (United States)" Value="+1" />
                                <asp:ListItem Text="+33 (France)" Value="+33" />
                                <asp:ListItem Text="+49 (Germany)" Value="+49" />
                                <asp:ListItem Text="+81 (Japan)" Value="+81" />
                                <asp:ListItem Text="+86 (China)" Value="+86" />
                                <asp:ListItem Text="+55 (Brazil)" Value="+55" />
                                <asp:ListItem Text="+7 (Russia)" Value="+7" />
                                <asp:ListItem Text="+966 (Saudi Arabia)" Value="+966" />
                                <asp:ListItem Text="+82 (South Korea)" Value="+82" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="reqCountryCode" runat="server"
                                ControlToValidate="ddlCountryCode"
                                InitialValue=""
                                ErrorMessage="Please select a country code"
                                ForeColor="Red" Display="Dynamic" />
                        </div>
                    </div>
                </div>

                <!-- Language Dropdown -->
                <div class="mb-3">
                    <label for="CountryLanguage">Language</label>
                    <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Select Language" Value="" />
                        <asp:ListItem Text="English" Value="English" />
                        <asp:ListItem Text="Hindi" Value="Hindi" />
                        <asp:ListItem Text="French" Value="French" />
                        <asp:ListItem Text="German" Value="German" />
                        <asp:ListItem Text="Japanese" Value="Japanese" />
                        <asp:ListItem Text="Mandarin Chinese" Value="Mandarin Chinese" />
                        <asp:ListItem Text="Portuguese" Value="Portuguese" />
                        <asp:ListItem Text="Russian" Value="Russian" />
                        <asp:ListItem Text="Arabic" Value="Arabic" />
                        <asp:ListItem Text="Korean" Value="Korean" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqLanguage" runat="server"
                        ControlToValidate="ddlLanguage"
                        InitialValue=""
                        ErrorMessage="Please select a language"
                        ForeColor="Red" Display="Dynamic" />
                </div>

                <!-- Save Button -->
                <div class="card-footer text-center">
                    <asp:Button ID="btnContrySave" runat="server" Text="SAVE"
                        CssClass="btn btn-primary waves-effect waves-light me-1"
                        OnClick="btnContrySave_Click" />
                </div>
            </div>

            <%-- Card-body--%>
        </div>
        <%-- Card - END  --%>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" runat="Server">
</asp:Content>

