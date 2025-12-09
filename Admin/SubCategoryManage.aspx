<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="SubCategoryManage.aspx.cs" Inherits="Admin_SubCategoryManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="Server">
    =
    <div class="container-fluid">
        <!-- start page title -->
        <div class="row">
            <div class="col-12">
                <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                    <h4 class="mb-sm-0">Sub Category</h4>
                </div>
            </div>
        </div>
        <!-- end page title -->
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header">
                        <div class="d-flex justify-content-between align-content-center">
                            <h4>Sub Category</h4>
                            <a href="SubCategoryCreate.aspx" class="btn btn-primary"><i class="fa fa-plus"></i>Add</a>
                        </div>
                    </div>
                    <div class="card-body table-responsive">
                        <asp:GridView ID="SubCategoryView1" OnRowCommand="SubCategoryView1_RowCommand" CssClass="table table-hover" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Id">
                                    <ItemTemplate>
                                        <%--<%#Eval("SubCategoryId") %>--%>
                                          <%#Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CategoryName">
                                    <ItemTemplate>
                                        <%#Eval("Category") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="SubCategory">
                                    <ItemTemplate>
                                        <%#Eval("SubCategory") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                
                                <asp:TemplateField HeaderText="Icon">
                                    <ItemTemplate>
                                     
                                            <asp:Image ID="IconImg" runat="server" Height="100px" Width="100px" ImageUrl='<%# Eval("Icon") %>' />
                                       
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
                                        <a href='SubCategoryCreate.aspx?Edit=<%#Eval("SubCategoryId") %>' id="btnSubCateedit" class="btn btn-primary"><i class="fa fa-edit"></i>Edit</a>
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btndelete" OnClientClick="return confirm('Are You Sure Delete')" CommandName="del" CommandArgument='<%#Eval("SubCategoryId") %>' class="btn btn-danger"  runat="server">&nbsp;<i class="fa fa-trash"></i>Delete</asp:LinkButton>
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
    <!-- container-fluid -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" runat="Server">
</asp:Content>

