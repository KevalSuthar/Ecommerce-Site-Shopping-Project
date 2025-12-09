<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterClient.master" AutoEventWireup="true" CodeFile="ConformOrder.aspx.cs" Inherits="Client_ConformOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <style>
        #conorder {
            background-color: #fff;
            padding: 20px;
            width: 200pc;
            margin-top: 200px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            text-align: center;
        }

            #conorder h1 {
                color: #4CAF50;
            }

            #conorder p {
                color: #555;
            }

            #conorder a {
                display: inline-block;
                margin-top: 20px;
                padding: 10px 20px;
                background-color: #4CAF50;
                color: #fff;
                text-decoration: none;
                border-radius: 5px;
            }

                #conorder a:hover {
                    background-color: #45a049;
                }

            #conorder .Round {
                width: 100px;
                border-radius: 50%;
                background-color: #4CAF50;
                height: 100px;
                margin: auto;
            }

            #conorder #Right {
                line-height: 100px;
                color: #f4f3f0;
                font-size: 40px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="Server">
    <div class="container" id="conorder">
        <div class="row g-4">
            <div class="col-lg-12">
                <div class="Round"><i class="fas fa-check" id="Right"></i></div>
                <h1>Order Placed Successfully!</h1>
                <p>
                    Thank you for your purchase. Your order Bill number is
                <asp:Label ID="lblbillnum" runat="server" Text=""></asp:Label>.
                </p>
                <input  type="button" id="btnDownloadBill" onclick="openwindow()" value="Download Bill"/>
            
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" runat="Server">
   <%-- <script>


        function openwindow() {
            var Qs = new URLSearchParams(window.location.search);
            if (Qs.has("OrderId")) {
                var b = Qs.get("OrderId");
               
                window.open('Invoice.aspx?OrderId=' + b, 'width=600,height=600,left=600,top=200');
            }
            else {
                alert("BillNo not found in URL!");
            }
        }
    </script>--%>
    <script type="text/javascript">
        function openwindow() {
        
            var billNo = document.getElementById('<%= lblbillnum.ClientID %>').innerText;

        if (billNo !== "") {
            window.open('Invoice.aspx?BillNo=' + billNo, '_blank', 'width=600,height=600,left=600,top=200');
        } else {
            alert("Bill number not found!");
        }
    }
</script>

</asp:Content>

