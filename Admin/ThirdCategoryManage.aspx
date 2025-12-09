<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="ThirdCategoryManage.aspx.cs" Inherits="Admin_ThirdCategoryManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="Server">
    <div class="container-fluid">



        <!-- start page title -->
        <div class="row">
            <div class="col-12">
                <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                    <h4 class="mb-sm-0">Third Category</h4>
                </div>
            </div>
        </div>
        <!-- end page title -->


        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header">
                        <div class="d-flex justify-content-between align-content-center">
                            <h4>Third Category</h4>
                            <a href="ThirdCategoryCreate.aspx" class="btn btn-primary"><i class="fa fa-plus"></i>Add</a>
                        </div>
                    </div>
                    <div class="card-body table-responsive">
                        <asp:GridView ID="ThirdCateView1" OnRowCommand="ThirdCateView1_RowCommand" CssClass="table table-hover" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Id">
                                    <ItemTemplate>
                                        <%--<%#Eval("ThirdCategoryId") %>--%>
                                        <%#Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="CategoryName">
                                    <ItemTemplate>
                                        <%#Eval("Category") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="SubCategoryName">
                                    <ItemTemplate>
                                        <%#Eval("SubCategory") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ThirdCategory">
                                    <ItemTemplate>
                                        <%#Eval("ThirdCategory") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Icon">
                                    <ItemTemplate>

                                        <a href='<%# Eval("Icon") %>'>
                                            <asp:Image ID="IconImg" runat="server" Height="100px" Width="100px" ImageUrl='<%# Eval("Icon") %>' />
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <%#Eval("Status") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <%#Eval("EntryDate") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <a href='ThirdCategoryCreate.aspx?Edit=<%#Eval("ThirdCategoryId") %>' id="btnThirdCateedit" class="btn btn-primary"><i class="fa fa-edit"></i>Edit</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnThirdCatedelete" OnClientClick="return confirm('Are You Sure Delete')" CommandName="del" CommandArgument='<%#Eval("ThirdCategoryId") %>' class="btn btn-danger" runat="server">&nbsp;<i class="fa fa-trash"></i>Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>
                    </div>
                </div>
            </div>
            <!-- end col -->
        </div>
        <!-- end row -->

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" runat="Server">
</asp:Content>

