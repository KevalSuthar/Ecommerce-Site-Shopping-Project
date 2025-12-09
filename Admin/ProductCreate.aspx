<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="ProductCreate.aspx.cs" Inherits="Admin_ProductCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="Server">
    <div class="container-fluid">
        <!-- start page title -->
        <div class="row">
            <div class="col-12">
                <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                    <h4 class="mb-sm-0">Product Form</h4>
                </div>
            </div>
        </div>


        <!-- end page title -->
        <div class="card">
            <div class="card-header bg-#ebeff3">
                <div class="d-flex justify-content-between align-content-center">
                    <h4>Product Form</h4>
                    <a href="ProductManage.aspx" class="btn btn-primary">Back</a>
                </div>
            </div>
            <div class="card-body">

                <div class="mb-3">
                    <label for="txtName">Name</label>
                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqName" runat="server" ErrorMessage="Please enter product name"
                        ControlToValidate="txtName" ForeColor="Red" Display="Dynamic" />
                </div>

                <div class="mb-3">
                    <label for="txtPrice">Price</label>
                    <asp:TextBox ID="txtPrince" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqPrice" runat="server" ErrorMessage="Please enter product price"
                        ControlToValidate="txtPrince" ForeColor="Red" Display="Dynamic" />
                </div>

                <div class="mb-3">
                    <label for="txtcategory">Category</label>
                    <asp:DropDownList ID="DropCategory" OnSelectedIndexChanged="DropCategory_SelectedIndexChanged"
                        AutoPostBack="true" runat="server" CssClass="form-control">
                        <asp:ListItem Text="--Select Category--" Value="" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqCategory" runat="server" ErrorMessage="Please select a category"
                        ControlToValidate="DropCategory" InitialValue="" ForeColor="Red" Display="Dynamic" />
                </div>

                <div class="mb-3">
                    <label for="txtsubcategory">SubCategory</label>
                    <asp:DropDownList ID="DropSubCategory" OnSelectedIndexChanged="DropSubCategory_SelectedIndexChanged"
                        AutoPostBack="true" runat="server" CssClass="form-control">
                        <asp:ListItem Text="--Select Subcategory--" Value="" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqSubCategory" runat="server" ErrorMessage="Please select a subcategory"
                        ControlToValidate="DropSubCategory" InitialValue="" ForeColor="Red" Display="Dynamic" />
                </div>

                <div class="mb-3">
                    <label for="txtThirdCate">Third Category</label>
                    <asp:DropDownList ID="DropThirdCategory" runat="server" CssClass="form-control">
                        <asp:ListItem Text="--Select Third Category--" Value="" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqThirdCat" runat="server" ErrorMessage="Please select third category"
                        ControlToValidate="DropThirdCategory" InitialValue="" ForeColor="Red" Display="Dynamic" />
                </div>

                <div class="mb-3">
                    <label for="txtBrand">Brand</label>
                    <asp:DropDownList ID="DropBrand" runat="server" CssClass="form-control">
                        <asp:ListItem Text="--Select Brand--" Value="" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqBrand" runat="server" ErrorMessage="Please select a brand"
                        ControlToValidate="DropBrand" InitialValue="" ForeColor="Red" Display="Dynamic" />
                </div>

                <div class="row">
                    <div class="col-sm-8 col-12">
                        <div class="mb-3">
                            <label for="txtIcon">Icon</label>

                            <asp:FileUpload ID="ProductFileUpload" runat="server" CssClass="form-control" />
                             <asp:RequiredFieldValidator ID="reqfile" runat="server" ErrorMessage="Please select image" ForeColor="Red" Display="Dynamic" ControlToValidate="ProductFileUpload"></asp:RequiredFieldValidator>
                          
                        </div>
                    </div>
                    <div class="col-sm-4 col-12">
                        <div class="mb-3">
                            <asp:Image ID="ProdImg" runat="server" Width="100px" Height="100px" class="img-thumbnail" />
                        </div>
                    </div>
                </div>

                <div class="mb-3">
                    <label for="Description">Description</label>
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="2" Columns="20" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="reqDesc" runat="server" ErrorMessage="Please enter description"
                        ControlToValidate="txtDescription" ForeColor="Red" Display="Dynamic" />
                </div>

                <div class="mb-3">
                    <label for="txtstatus">Status</label>
                    <asp:DropDownList ID="DropProdStatus" runat="server" CssClass="form-control">
                        <asp:ListItem Text="--Select Status--" Value="" />
                        <asp:ListItem>Active</asp:ListItem>
                        <asp:ListItem>Deactive</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqStatus" runat="server" ErrorMessage="Please select status"
                        ControlToValidate="DropProdStatus" InitialValue="" ForeColor="Red" Display="Dynamic" />
                </div>

            </div>

            <div class="card-footer text-center">
                <asp:Button ID="btnProdSave" runat="server" Text="SAVE" CssClass="btn btn-primary waves-effect waves-light me-1" OnClick="btnProdSave_Click" />
            </div>
        </div>


        <%-- Specification  --%>
        <div class="card my-5">

            <%-- First Panel --%>
            <asp:Panel ID="Panel1" runat="server">
                <div class="card-header">

                    <div class="d-flex justify-content-between align-content-center">
                        <h4>Specification</h4>
                    </div>
                </div>
                <div class="card-body">
                    <p>
                        Onece You Add Product then After You Can Add Products.
                    </p>
                </div>
            </asp:Panel>
            <%-- Second Panel --%>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <div class="card-header">
                    <div class="d-flex justify-content-between align-content-center">
                        <h4>Specification</h4>
                        <button type="button" onclick="openwindow()" class="btn btn-primary waves-effect waves-light me-1">Add Specification</button>
                    </div>
                </div>
                <%-- Card Body --%>
                <div class="card-body table-responsive">
                    <asp:GridView ID="ProductSpecificationGrid" OnRowCommand="ProductSpecificationGrid_RowCommand" runat="server" CssClass="table table-hover" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="No">
                                <ItemTemplate>
                                    <%--<%#Eval("ProductSpecificationOptionId") %>--%>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ProductName">
                                <ItemTemplate>
                                    <%#Eval("ProductId") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="SpecificationOptionName">
                                <ItemTemplate>
                                    <%#Eval("SpecificationName") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="SpecificationOptionId">
                                <ItemTemplate>
                                    <%#Convert.ToInt32(Eval("SpecificationOptionId")) > 0 ?Eval("Value"):Eval("Specifications") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SpecificationName">
                                <ItemTemplate>
                                    <%#Eval("Specifications") %>
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

                                    <button type="button" onclick="editbtn('<%#Eval("ProductSpecificationOptionId") %>')" class="btn btn-primary waves-effect waves-light me-1"><i class="fa fa-edit"></i>Edit</button>

                                    <!-- <a href='SpecificationPage.aspx?Edit=<%#Eval("ProductSpecificationOptionId") %>' id="btnSubCateedit" class="btn btn-primary"><i class="fa fa-edit"></i>Edit</a> -->
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btndelete" OnClientClick="return confirm('Are You Sure Delete')" CommandName="del" CommandArgument='<%#Eval("ProductSpecificationOptionId") %>' class="btn btn-danger" runat="server">&nbsp;<i class="fa fa-trash"></i>Delete</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

            </asp:Panel>
        </div>

        <%-- Product Photo --%>
        <div class="card my-5">

            <%-- Third Panel --%>
            <asp:Panel ID="Panel3" runat="server">
                <div class="card-header">
                    <div class="d-flex justify-content-between align-content-center">
                        <h4>Products Photos</h4>
                    </div>
                </div>
                <div class="card-body">
                    <p>
                        Onece You Add Product then After You Can Add Products Photos.
                    </p>
                </div>
            </asp:Panel>
            <%-- Four Panel --%>
            <asp:Panel ID="Panel4" runat="server" Visible="false">
                <div class="card-header">
                    <div class="d-flex justify-content-between align-content-center">
                        <h4>Products Photos</h4>
                        <button type="button" onclick="openwindow1()" class="btn btn-primary waves-effect waves-light me-1">Add Photos</button>
                    </div>
                </div>
                <%-- Card Body Grid View --%>
                <div class="card-body table-responsive">
                    <asp:GridView ID="ProductPhotoView1" OnRowCommand="ProductPhotoView1_RowCommand" runat="server" CssClass="table table-hover" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="No">
                                <ItemTemplate>
                                    <%--<%#Eval("ProductPhotoId") %>--%>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ProductId">
                                <ItemTemplate>
                                    <%#Eval("ProductId")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Alternet Text">
                                <ItemTemplate>
                                    <%#Eval("ProductAltText") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Photo">
                                <ItemTemplate>
                                    <a href='<%# Eval("Photo") %>'>
                                        <asp:Image ID="PhotoImg" runat="server" Height="100px" Width="100px" ImageUrl='<%# Eval("Photo") %>' />
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
                                    <button type="button" onclick="editbtn1('<%#Eval("ProductPhotoId") %>')" class="btn btn-primary waves-effect waves-light me-1"><i class="fa fa-edit"></i>Edit</button>
                                    <%--onclick="editbtn('<%#Eval("ProductPhotoId") %>')"--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btndelete" runat="server" OnClientClick="return confirm('Are You Sure Delete')" CommandName="del" CommandArgument='<%#Eval("ProductPhotoId") %>' class="btn btn-danger">&nbsp;<i class="fa fa-trash"></i>Delete</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>
                </div>
            </asp:Panel>
        </div>

    </div>
    <!-- container-fluid -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" runat="Server">
    <script>
       
        <%--Add Specification Btn--%>
        function openwindow() {
            var Qs = new URLSearchParams(window.location.search);
            if (Qs.has("Edit")) {
                var b = Qs.get("Edit");
                window.open('SpecificationPage.aspx?ProductId=' + b, '_blank', 'Width= 600 ,Height=600,left = 600 , top = 200');

            }
        }
         <%--Add Specification Edit Button--%>
        function editbtn(id) {
            var Qs = new URLSearchParams(window.location.search);
            if (Qs.has("Edit")) {
                var b = Qs.get("Edit");
                window.open('SpecificationPage.aspx?SpecificationsId=' + b + '&EditSpe=' + id, '_blank', 'width=600,height=600,left=600,top=200');
            }
        }
         <%--Add Photo Btn--%>
        function openwindow1() {
            var Qs = new URLSearchParams(window.location.search);
            if (Qs.has("Edit")) {
                var b = Qs.get("Edit");
                window.open('ProductPhoto.aspx?ProductId=' + b, '_blank', 'Width= 600 ,Height=600,left = 600 , top = 200');

            }
        }
        <%--Add Photo Edit Button--%>
        function editbtn1(id) {
            var Qs = new URLSearchParams(window.location.search);
            if (Qs.has("Edit")) {
                var b = Qs.get("Edit");
                window.open('ProductPhoto.aspx?ProductId=' + b + '&EditSpe=' + id, '_blank', 'width=600,height=600,left=600,top=200');
            }
        }
          <%--Add Photo Edit Button--%>
        function editbtn1(id) {
            var Qs = new URLSearchParams(window.location.search);
            if (Qs.has("Edit")) {
                var b = Qs.get("Edit");
                window.open('ProductPhoto.aspx?ProductId=' + b + '&EditSpe=' + id, '_blank', 'width=600,height=600,left=600,top=200');
            }
        }
    </script>
</asp:Content>

