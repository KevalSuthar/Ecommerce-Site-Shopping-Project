<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="ProductManage.aspx.cs" Inherits="Admin_ProductManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="Server">
    <div class="container-fluid">
        <!-- start page title -->
        <div class="row">
            <div class="col-12">
                <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                    <h4 class="mb-sm-0">Product</h4>
                </div>
            </div>
        </div>
        <!-- end page title -->
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header">
                        <div class="d-flex justify-content-between align-content-center">
                            <h4>Product</h4>
                           
                            <a runat="server" href="ProductCreate.aspx" class="btn btn-primary"><i class="fa fa-plus"></i>Add</a>

                        


                        </div>
                    </div>
                    <%-- Card Body --%>
                    <div class="card-body table-responsive">
                        <asp:GridView ID="ProductGrid" OnRowCommand="ProductGrid_RowCommand" CssClass="table table-hover" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Id">
                                    <ItemTemplate>
                                        <%--<%#Eval("ProductId") %>>--%>
                                        <%#Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ProdName">
                                    <ItemTemplate>
                                        <%#Eval("Name") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ProdPrice">
                                    <ItemTemplate>
                                        <%#Eval("Price") %>
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
                                <asp:TemplateField HeaderText="ThirdCategoryName">
                                    <ItemTemplate>
                                        <%#Eval("ThirdCategory") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="BrandName">
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
                                <%--  <asp:TemplateField HeaderText="Description">
                                     <ItemTemplate>
                                         <%#Eval("Description") %>>
                                     </ItemTemplate>
                                 </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <%#Eval("Status") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        
                                        <a href='ProductCreate.aspx?Edit=<%#Eval("ProductId") %>' id="btnProdedit" class="btn btn-primary"><i class="fa fa-edit"></i>Edit</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>

                                        <asp:LinkButton ID="btnProddelete" OnClientClick="return confirm('Are You Sure Delete')" CommandName="del" CommandArgument='<%#Eval("ProductId") %>' class="btn btn-danger" runat="server">&nbsp;<i class="fa fa-trash"></i>Delete</asp:LinkButton>
                                    
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

