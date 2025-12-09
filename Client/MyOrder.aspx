<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterClient.master" AutoEventWireup="true" CodeFile="MyOrder.aspx.cs" Inherits="Client_Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="Server">


    <h2 style="margin: 11% 0 0 0; text-align: center; font-weight: bold;">My Orders</h2>

    <div style="width: 95%; max-width: 1100px; margin: auto; padding: 20px; background-color: #f9f9f9; border-radius: 10px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
            CssClass="table table-bordered table-hover" Width="100%"
            HeaderStyle-BackColor="#343a40" HeaderStyle-ForeColor="White">
            <Columns>
                <asp:BoundField DataField="OrderId" HeaderText="Order ID" />
                <asp:BoundField DataField="BillNo" HeaderText="Bill No" />
                <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" />
                <asp:BoundField DataField="TotalQuantity" HeaderText="Total Qty" />
                <asp:BoundField DataField="OrderStatus" HeaderText="Order Status" />
                <asp:BoundField DataField="PaymentStatus" HeaderText="Payment Status" />
                <asp:BoundField DataField="PaymentType" HeaderText="Payment Type" />
                <asp:TemplateField HeaderText="Invoice">
                    <ItemTemplate>
                        <%--<a href='Invoice.aspx?OrderId=<%# Eval("OrderId") %>' class="btn btn-sm btn-primary">View</a>--%>
                        <a href='Invoice.aspx?BillNo=<%# Eval("BillNo") %>' class="btn btn-sm btn-primary">View</a>

                        <%--<input type="button" id="btnDownloadBill" onclick="openwindow()" value="Download Bill" />--%>
                        <%--<asp:Button ID="btnview" runat="server" Text="View" CssClass="btn btn-sm btn-primary" OnClick="" />--%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" runat="Server">
</asp:Content>

