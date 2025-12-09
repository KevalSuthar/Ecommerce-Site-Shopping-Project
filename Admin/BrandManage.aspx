<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="BrandManage.aspx.cs" Inherits="Admin_BrandManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" Runat="Server">
      <div class="container-fluid">


        <!-- start page title --> 
        <div class="row">
            <div class="col-12">
                <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                    <h4 class="mb-sm-0">Brand</h4>
                </div>
            </div>
        </div>
        <!-- end page title -->




        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header">
                        <div class="d-flex justify-content-between align-content-center">
                            <h4>Brand</h4>
                            <a href="BrandCreate.aspx" class="btn btn-primary"><i class="fa fa-plus"></i>Add</a>
                        </div>
                    </div>

                     <div class="card-body table-responsive">
                        <asp:GridView ID="BrandView1" OnRowCommand="BrandView1_RowCommand" CssClass="table table-hover" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Id">
                                    <ItemTemplate>
                                        <%-- <%#Eval("BrandId") %>--%>
                                        <%#Container.DataItemIndex + 1 %>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Brand">
                                     <ItemTemplate>
                                         <%#Eval("Brand") %>
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
                                       <a href='BrandCreate.aspx?Edit=<%#Eval("BrandId") %>' id="btnBrandedit"    class="btn btn-primary" <i class="fa fa-edit"></i>Edit</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>

                                        <asp:LinkButton ID="btnBranddelete" OnClientClick="return confirm('Are You Sure Delete')" CommandName="del" CommandArgument='<%#Eval("BrandId") %>' class="btn btn-danger"  runat="server">&nbsp;<i class="fa fa-trash"></i>Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            

                        </asp:GridView>
                </div>
            </div>
            <!-- end col -->
        </div>
        <!-- end row -->

    </div>
      </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" Runat="Server">
</asp:Content>

