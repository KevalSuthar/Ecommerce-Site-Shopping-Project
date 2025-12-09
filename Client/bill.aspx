<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterClient.master" AutoEventWireup="true" CodeFile="bill.aspx.cs" Inherits="Client_bill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="Server">
    <div style="max-width: 900px; margin: 15% auto; padding: 40px; background: #fff; border-radius: 12px; box-shadow: 0 0 15px rgba(0,0,0,0.1); font-family: Segoe UI,sans-serif; border: 1px solid #dee2e6; color: black;">

        <!-- Header -->
        <div style="text-align: center; margin-bottom: 20px;">

            <h2 style="color: black; margin-top: 10px; font-size: 28px;">🧾 BILL</h2>
        </div>

        <!-- Addresses -->
        <div style="display: flex; justify-content: space-between; margin-bottom: 30px;">

            <!-- From Address (Seller) -->
            <div style="width: 48%;">
                <h4 style="color: black;">From:</h4>
                <p style="margin: 0;">
                    Bill No:
                    <asp:Label ID="lblBillNo" runat="server" /><br />
                    EntryDate: 
                    <asp:Label ID="lblentrydate" runat="server" /><br />
                    Payment Due:             
                    <asp:Label ID="lblpayment" runat="server" /><br />

                </p>
            </div>

            <!-- To Address (Customer) -->
            <div style="width: 48%;">
                <h4 style="color: black;">To:</h4>
                <p style="margin: 0;">
                    Name:
            <asp:Label ID="lblName" runat="server" /><br />
                    Mobile No:
            <asp:Label ID="lblMobile" runat="server" /><br />
                    Address:
            <asp:Label ID="lblAddress" runat="server" /><br />
                    Pincode:
            <asp:Label ID="lblPincode" runat="server" />
                </p>
            </div>

        </div>


        <!-- Product Table -->
        <table style="width: 100%; border-collapse: collapse; text-align: center; margin-bottom: 20px;">
            <thead>
                <tr style="background: #f1f1f1; color: black;">
                    <th style="padding: 10px; border: 1px solid #ccc;">Product</th>
                    <th style="padding: 10px; border: 1px solid #ccc;">Unit Price</th>
                    <th style="padding: 10px; border: 1px solid #ccc;">Qty</th>
                    <th style="padding: 10px; border: 1px solid #ccc;">Amount</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptProductDetails" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="padding: 10px; border: 1px solid #ccc;"><%# Eval("Name") %></td>
                            <td style="padding: 10px; border: 1px solid #ccc;">₹<%# Eval("Price") %></td>
                            <td style="padding: 10px; border: 1px solid #ccc;"><%# Eval("Qty") %></td>
                            <td style="padding: 10px; border: 1px solid #ccc;">₹<%# Convert.ToInt32(Eval("Price")) * Convert.ToInt32(Eval("Qty")) %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

        <!-- Totals -->
        <div style="background-color: #f8f9fa; padding: 20px; border-radius: 10px; font-family: Arial, sans-serif; color: black;">
            <h5 style="font-weight: bold; font-size: 20px;">Bill Summary</h5>

            <div style="display: flex; justify-content: space-between; padding: 8px 0;">
                <span>Subtotal:</span>
                <asp:Label ID="lblSubTotal" runat="server" Text="0" Style="font-weight: bold;"></asp:Label>
            </div>

            <div style="display: flex; justify-content: space-between; padding: 8px 0;">
                <span>Shipping Charges:</span>
                <asp:Label ID="lblShipping" runat="server" Text="0" Style="font-weight: bold;"></asp:Label>
            </div>

            <hr style="border-top: 1px solid #ccc;" />

            <div style="display: flex; justify-content: space-between; padding: 12px 0;">
                <strong>Total:</strong>
                <asp:Label ID="lblGrandTotal" runat="server" Text="0" Style="font-weight: bold; color: black;"></asp:Label>
            </div>
        </div>

        <!-- Animated Buttons -->   
            <div style="text-align: center; margin-top: 40px;">
                <asp:Button ID="btnPrint" runat="server" Text="🖨️ Print Bill"
                    CssClass="btn btn-primary"
                    Style="border-radius: 30px; padding: 10px 25px; margin-right: 15px; transition: all 0.3s ease; cursor: pointer;"
                    onmouseover="this.style.background='#0b5ed7';"
                    onmouseout="this.style.background='#0d6efd';"
                    OnClientClick="return printBill();" />

                <asp:Button ID="btnDownload" runat="server" Text="⬇️ Download Bill"
                    CssClass="btn btn-success"
                    Style="border-radius: 30px; padding: 10px 25px; transition: all 0.3s ease; cursor: pointer;"
                    onmouseover="this.style.background='#157347';"
                    onmouseout="this.style.background='#198754';"
                    OnClientClick="return downloadPDF();" />
            </div>
      

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" runat="Server">
    <script>
        function printBill() {
            window.print();
            return false;
        }

        
    </script>
</asp:Content>

