<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="Orderlist.aspx.cs" Inherits="Admin_Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="Server">
    <!-- start page title -->
    <div class="row">
        <div class="col-12">
            <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                <h4 class="mb-sm-0">Order Form</h4>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-header">
                    <div class="d-flex justify-content-between align-content-center">
                        <h4>Order Form</h4>
                        <%--  <a href="CityCreate.aspx" class="btn btn-primary"><i class="fa fa-plus"></i>Add</a>--%>
                    </div>
                </div>

                <div class="card-body table-responsive">
                    <asp:GridView ID="AdminOrderPageGridView" runat="server" CssClass="table table-hover" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="Id">
                                <ItemTemplate>
                                    <%#Eval("OrderId") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="UserId">
                                <ItemTemplate>
                                    <%#Eval("UserId") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BillNo">
                                <ItemTemplate>
                                    <%#Eval("BillNo") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product Name">
                                <ItemTemplate>
                                    <%#Eval("Name") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product Price">
                                <ItemTemplate>
                                    <%#Eval("Price") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product Qty">
                                <ItemTemplate>
                                    <%#Eval("Quantity") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Amount">
                                <ItemTemplate>
                                    <%#Eval("Total") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Enter Date">
                                <ItemTemplate>
                                    <%#Eval("EntryDate") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                   <%--  <a href='Invoice.aspx?OrderId=<%# Eval("ProductId") %>' class="btn btn-info">
                                        <i class="fa fa-eye"></i>View
                                    </a>--%>
                                    <button type="button" onclick='btnprint (<%#Eval("OrderId") %>)' class="btn btn-sm btn-primary  d-inline-flex align-items-center btn me-2 mb-2 me-sm-3" id="Btnprint"><i class="fa fa-eye"></i></button>
                                           
                                   
                                   
                       
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" runat="Server">
   <script>
       function btnprint(id) {
           myWindow = window.open('personalbill.aspx?OrderId=' + id, ' PrintOrder ', 'Width=1000, height=1000 ');
       }
        </script>
</asp:Content>

