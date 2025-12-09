<%@ Page Language="C#" AutoEventWireup="true" CodeFile="personalbill.aspx.cs" Inherits="Admin_personalbill" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Invoice</title>
    <style>
        body {
            font-family: 'Segoe UI', sans-serif;
            background: #f4f4f4;
            margin: 0;
            padding: 40px;
        }

        .invoice-container {
            max-width: 900px;
            margin: auto;
            background: #fff;
            padding: 40px;
            border-radius: 12px;
            box-shadow: 0 0 15px rgba(0,0,0,0.1);
            color: black;
        }

        .invoice-header {
            text-align: center;
            margin-bottom: 20px;
        }

            .invoice-header h2 {
                margin-top: 10px;
                font-size: 28px;
                color: black;
            }

        .addresses {
            display: flex;
            justify-content: space-between;
            margin-bottom: 30px;
        }

            .addresses div {
                width: 48%;
            }

        table {
            width: 100%;
            border-collapse: collapse;
            text-align: center;
            margin-bottom: 20px;
        }

        th, td {
            padding: 10px;
            border: 1px solid #ccc;
        }

        thead {
            background: #f1f1f1;
        }

        .summary {
            background-color: #f8f9fa;
            padding: 20px;
            border-radius: 10px;
            font-family: Arial, sans-serif;
            color: black;
        }

            .summary div {
                display: flex;
                justify-content: space-between;
                padding: 8px 0;
            }

        .buttons {
            text-align: center;
            margin-top: 40px;
        }

        .btn {
            border-radius: 30px;
            padding: 10px 25px;
            transition: all 0.3s ease;
            cursor: pointer;
            border: none;
            color: #fff;
            margin-right: 15px;
        }

        .btn-primary {
            background-color: #0d6efd;
        }

            .btn-primary:hover {
                background-color: #0b5ed7;
            }

        .btn-success {
            background-color: #198754;
        }

            .btn-success:hover {
                background-color: #157347;
            }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div id="invoiceContent" class="invoice-container">

            <div class="invoice-header">
                <h2>🧾 BILL</h2>
            </div>

           <%-- <div class="addresses">
                <div>
                    <h4>From:</h4>
                    <p>
                        Bill No:<%# Eval("BillNo") %>
                      <br />
                        EntryDate:<%# Eval("BillNo") %>
                    <br />
                        Payment Due:<%# Eval("PaymentStatus") %>
                      
                    </p>
                </div>
                <div>
                    <h4>To:</h4>
                    <p>
                        Name:<%# Eval("Name") %>
                      <br />
                        Mobile No:<%# Eval("Mobile") %>
                        <br />
                        Address:<%# Eval("Address") %>
                      <br />
                        Pincode:<%# Eval("Pincode") %>
                      
                    </p>
                </div>
            </div>--%>
            <div class="addresses">
                <div>
                    <h4>From:</h4>
                    <p>
                        Bill No:
                        <asp:Label ID="lblBillNo" runat="server" /><br />
                        EntryDate:
                        <asp:Label ID="lblentrydate" runat="server" /><br />
                        Payment Due:
                        <asp:Label ID="lblpayment" runat="server" /><br />
                    </p>
                </div>
                <div>
                    <h4>To:</h4>
                    <p>
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

            <table>
                <thead>
                    <tr>
                        <th>Product</th>
                        <th>Unit Price</th>
                        <th>Qty</th>
                        <th>Amount</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptProductDetails" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("Name") %></td>
                                <td>₹<%# Eval("Price") %></td>
                                <td><%# Eval("Quantity") %></td>
                                <td>₹<%# Convert.ToInt32(Eval("Price")) * Convert.ToInt32(Eval("Quantity")) %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>

            <div class="summary">
                <h5><strong>Bill Summary</strong></h5>
                <div>
                    <span>Subtotal:</span>
                    <asp:Label ID="lblSubTotal" runat="server" CssClass="fw-bold" />
                </div>
                <div>
                    <span>Shipping Charges:</span>
                    <asp:Label ID="lblShipping" runat="server" CssClass="fw-bold" />
                </div>
                <hr />
                <div>
                    <strong>Total:</strong>
                    <asp:Label ID="lblGrandTotal" runat="server" CssClass="fw-bold" />
                </div>
            </div>

            <div class="buttons">
                <asp:Button ID="btnPrint" runat="server" Text="🖨️ Print Bill"
                    CssClass="btn btn-primary"
                    OnClientClick="return printBill();" />

                <asp:Button ID="btnDownload" runat="server" Text="⬇️ Download Bill"
                    CssClass="btn btn-success"
                    OnClientClick="return downloadPDF();" />
            </div>

        </div>
    </form>
    <script>
        function printBill() {
            var printContents = document.getElementById('invoiceContent').innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;
            window.print();
            document.body.innerHTML = originalContents;
            return false;
        }

        function downloadPDF() {
            var element = document.getElementById('invoiceContent');
            var opt = {
                margin: 0.5,
                filename: 'Invoice.pdf',
                image: { type: 'jpeg', quality: 0.98 },
                html2canvas: { scale: 2 },
                jsPDF: { unit: 'in', format: 'letter', orientation: 'portrait' }
            };
            html2pdf().from(element).set(opt).save();
            return false;
        }
    </script>
</body>
</html>



