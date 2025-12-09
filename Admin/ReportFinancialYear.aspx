<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="ReportFinancialYear.aspx.cs" Inherits="Admin_ReportFinancialYear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" Runat="Server">

    <div id="ContentPage_typeAdd" class="d-sm-flex align-items-center justify-content-between mb-4 w-50">

            <asp:DropDownList ID="DropdownReportFinancialYear" runat="server"></asp:DropDownList>


            <asp:Button ID="BtnReportYear" CssClass="btn btn-primary" OnClick="BtnReportYear_Click" runat="server" Text="Search" />

        </div>
        <div class="card shadow mb-4">
            <div class="card-header">
                <h5>Order List</h5>
            </div>
            <div class="card-body table-responsive">
                <div>
                    <asp:GridView ID="ReportYearsGridView" runat="server"
                        CssClass="table table-bordered table-striped table-hover"
                        AutoGenerateColumns="False"
                        GridLines="None"
                        HeaderStyle-CssClass="thead-dark"
                        EmptyDataText="No orders found for selected date.">

                        <Columns>
                            <asp:TemplateField HeaderText="Order ID">
                                <ItemTemplate><%# Eval("OrderId") %></ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Bill No">
                                <ItemTemplate><%# Eval("BillNo") %></ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="User ID">
                                <ItemTemplate><%# Eval("Name") %></ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Amount (₹)">
                                <ItemTemplate><%# Eval("TotalAmount") %></ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate><%# Eval("TotalQuantity") %></ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Order Status">
                                <ItemTemplate><%# Eval("OrderStatus") %></ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Payment Type">
                                <ItemTemplate><%# Eval("PaymentType") %></ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Payment Status">
                                <ItemTemplate><%# Eval("PaymentStatus") %></ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Entry Date">
                                <ItemTemplate><%# Eval("EntryDate") %></ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
            </div>
        </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" Runat="Server">
</asp:Content>

