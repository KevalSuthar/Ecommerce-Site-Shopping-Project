using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Client_Invoice : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;

    void MyCon()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["EcommerceDataBaseConnectionString1"].ToString());
        con.Open();
    }

    //void fillcart()
    //{
    //    if (Session["user"] != null)
    //    {
    //        //string userid = Session["user"].ToString();


    //        MyCon();
    //        cmd = new SqlCommand("SELECT odt.*, pst.Icon, pst.Name, pst.Price, (pst.Price * odt.Quantity) as Total FROM OrderDetailTbl AS odt INNER JOIN ProducatTbl AS pst ON odt.ProductId = pst.ProductId ", con);

    //        //cmd.Parameters.AddWithValue("@uid", userid);
    //        da = new SqlDataAdapter(cmd);
    //        ds = new DataSet();
    //        da.Fill(ds);
    //        rptProductDetails.DataSource = ds;
    //        rptProductDetails.DataBind();

    //        // Pricing Calculation
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            int subTotal = 0;
    //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //            {
    //                subTotal += Convert.ToInt32(ds.Tables[0].Rows[i]["Total"]);
    //            }

    //            int shippingCharge = 0;
    //            if (subTotal >= 500)
    //            {
    //                shippingCharge = (subTotal * 10) / 100;
    //            }

    //            int grandTotal = subTotal + shippingCharge;

    //            lblSubTotal.Text = subTotal.ToString();
    //            lblShipping.Text = shippingCharge.ToString();
    //            lblGrandTotal.Text = grandTotal.ToString();
    //        }

    //        con.Close();
    //    }
    //}
    //void LoadAddressList()
    //{
    //    MyCon();

    //    if (Session["user"] != null)
    //    {
    //        string UserId = Session["user"].ToString();

    //        string OrderId = Request.QueryString["OrderId"].ToString();

    //        cmd = new SqlCommand("Select ot.*,spt.Address,spt.Name,spt.Mobile,spt.Pincode from OrderTbl as ot inner join ShippingTbl as spt on ot.ShippingId = spt.ShippingId Where  spt.UserId=@userid and ot.OrderId = @OrderId ", con);
    //        cmd.Parameters.AddWithValue("@userid", UserId);
    //        cmd.Parameters.AddWithValue("@OrderId", OrderId);

    //        da = new SqlDataAdapter(cmd);
    //        ds = new DataSet();
    //        da.Fill(ds);

    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            lblBillNo.Text = ds.Tables[0].Rows[0]["BillNo"].ToString();
    //            lblentrydate.Text = ds.Tables[0].Rows[0]["EntryDate"].ToString();
    //            lblpayment.Text = ds.Tables[0].Rows[0]["PaymentType"].ToString();
    //            lblName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
    //            lblMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
    //            lblAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
    //            lblPincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();

    //        }

    //        con.Close();
    //    }
    //}
    void fillcart()
    {
        if (Request.QueryString["BillNo"] != null)
        {
            string billNo = Request.QueryString["BillNo"].ToString();

            MyCon();
            cmd = new SqlCommand(@"
            SELECT odt.*, pst.Icon, pst.Name, pst.Price, (pst.Price * odt.Quantity) as Total 
            FROM OrderDetailTbl AS odt 
            INNER JOIN ProducatTbl AS pst ON odt.ProductId = pst.ProductId 
            INNER JOIN OrderTbl AS ot ON odt.OrderId = ot.OrderId
            WHERE ot.BillNo = @bill", con);

            cmd.Parameters.AddWithValue("@bill", billNo);
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
 

    void LoadAddressList()
    {
        if (Request.QueryString["BillNo"] != null && Session["user"] != null)
        {
            string billNo = Request.QueryString["BillNo"].ToString();
            string userId = Session["user"].ToString();

            MyCon();
            cmd = new SqlCommand(@"
            SELECT ot.*, spt.Address, spt.Name, spt.Mobile, spt.Pincode 
            FROM OrderTbl ot 
            INNER JOIN ShippingTbl spt ON ot.ShippingId = spt.ShippingId 
            WHERE ot.BillNo = @bill AND ot.UserId = @userid", con);

            cmd.Parameters.AddWithValue("@bill", billNo);
            cmd.Parameters.AddWithValue("@userid", userId);

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblBillNo.Text = ds.Tables[0].Rows[0]["BillNo"].ToString();
                lblentrydate.Text = ds.Tables[0].Rows[0]["EntryDate"].ToString();
                lblpayment.Text = ds.Tables[0].Rows[0]["PaymentType"].ToString();
                lblName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                lblMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                lblAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                lblPincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
            }

            con.Close();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillcart();
            LoadAddressList();
        }
    }
}