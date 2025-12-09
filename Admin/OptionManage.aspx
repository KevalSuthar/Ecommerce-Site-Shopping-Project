<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="OptionManage.aspx.cs" Inherits="Admin_OptionManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="Server">
    <div class="container-fluid">

        <!-- start page title -->
        <div class="row">
            <div class="col-12">
                <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                    <h4 class="mb-sm-0">OptionForm</h4>
                </div>
            </div>
        </div>
        <!-- end page title -->
       <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header">
                        <div class="d-flex justify-content-between align-content-center">
                            <h4>OptionForm</h4>
                            <a href="OptionCreate.aspx" class="btn btn-primary"><i class="fa fa-plus"></i>Add</a>
                        </div>
                    </div>
                    <div class="card-body table-responsive">
                          <asp:GridView ID="OptionGrid" OnRowCommand="OptionGrid_RowCommand" CssClass="table table-hover" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="Id">
                                     <ItemTemplate>
                                        <%-- <%#Eval("SpecificationsOptionId") --%>
                                          <%#Container.DataItemIndex + 1 %>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SpecificationName">
                                    <ItemTemplate>
                                         <%#Eval("SpecificationName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Value">
                                     <ItemTemplate>
                                         <%#Eval("Value") %>
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
                                       <a id="btnOptionedit" class="btn btn-primary" href='OptionCreate.aspx?Edit=<%#Eval("SpecificationsOptionId") %>'<i class="fa fa-edit"></i>Edit</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                     <ItemTemplate>
                                        <asp:LinkButton ID="btnOptiondelete" OnClientClick="return confirm('Are You Sure Delete')"  CommandName="del" CommandArgument='<%#Eval("SpecificationsOptionId") %>' class="btn btn-danger"  runat="server">&nbsp;<i class="fa fa-trash"></i>Delete</asp:LinkButton>

                                    
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

