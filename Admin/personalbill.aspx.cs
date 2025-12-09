using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;

public partial class Admin_personalbill : System.Web.UI.Page
{

    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    void mycon() // my connection database
    {
        con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|EcommerceDataBase.mdf;Integrated Security=True");
        con.Open();
    }
    void billdata()
    {
        mycon();
        if (Request.QueryString["OrderId"] != null)
        {
            string OrderId = Request.QueryString["OrderId"].ToString();

            cmd = new SqlCommand("Select ot.*,spt.Address,spt.Name,spt.Mobile,spt.Pincode from OrderTbl as ot inner join ShippingTbl as spt on ot.ShippingId = spt.ShippingId Where  ot.OrderId = @OrderId", con);

            cmd.Parameters.AddWithValue("@OrderId", OrderId);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblBillNo.Text = ds.Tables[0].Rows[0]["BillNo"].ToString();
                lblentrydate.Text = ds.Tables[0].Rows[0]["EntryDate"].ToString();
                lblpayment.Text = ds.Tables[0].Rows[0]["PaymentStatus"].ToString();

                lblName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                lblMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                lblAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                lblPincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
            }
        }
        con.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            billdata();
            if (Request.QueryString["OrderId"] != null)
            {
                mycon();
                cmd = new SqlCommand("SELECT odt.*, pst.Icon, pst.Name, pst.Price, (pst.Price * odt.Quantity) as Total FROM OrderDetailTbl AS odt INNER JOIN ProducatTbl AS pst ON odt.ProductId = pst.ProductId Where odt.OrderId=@oid ", con);
                cmd.Parameters.AddWithValue("@oid", Request.QueryString["OrderId"]);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                rptProductDetails.DataSource = ds;
                rptProductDetails.DataBind();

                // Pricing Calculation
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int subTotal = 0;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        subTotal += Convert.ToInt32(ds.Tables[0].Rows[i]["Total"]);
                    }

                    int shippingCharge = 0;
                    if (subTotal >= 500)
                    {
                        shippingCharge = (subTotal * 10) / 100;
                    }

                    int grandTotal = subTotal + shippingCharge;

                    lblSubTotal.Text = subTotal.ToString();
                    lblShipping.Text = shippingCharge.ToString();
                    lblGrandTotal.Text = grandTotal.ToString();
                }
                con.Close();
            }
        }

    }
}