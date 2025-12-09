<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="StateManage.aspx.cs" Inherits="Admin_StateManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="Server">

    <!-- start page title -->
    <div class="row">
        <div class="col-12">
            <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                <h4 class="mb-sm-0">State</h4>
            </div>
        </div>
    </div>
    <!-- end page title -->
    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-header">
                    <div class="d-flex justify-content-between align-content-center">
                        <h4>State Form</h4>
                        <a href="StateCreate.aspx" class="btn btn-primary"><i class="fa fa-plus"></i>Add</a>
                    </div>
                </div>

                <div class="card-body table-responsive">
                    <asp:GridView ID="StateGrid" OnRowCommand="StateGrid_RowCommand" CssClass="table table-hover" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="Id">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Country Name">
                                <ItemTemplate>
                                    <%#Eval("CountryName") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="StateName">
                                <ItemTemplate>
                                    <%#Eval("Name") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <a href='StateCreate.aspx?Edit=<%#Eval("StateId") %>' id="btnstateedit" class="btn btn-primary"><i class="fa fa-edit"></i>Edit</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnstatedelete" OnClientClick="return confirm('Are You Sure Delete')" CommandName="del" CommandArgument='<%#Eval("StateId") %>' class="btn btn-danger" runat="server">&nbsp;<i class="fa fa-trash"></i>Delete</asp:LinkButton>
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
</asp:Content>

