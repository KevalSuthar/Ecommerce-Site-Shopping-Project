using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class Client_Order : System.Web.UI.Page
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

    void fillcart()
    {
        if (Session["user"] != null)
        {
            string userid = Session["user"].ToString();


            MyCon();
            cmd = new SqlCommand("SELECT crt.*, pst.Icon, pst.Name, pst.Price, (pst.Price * crt.Qty) as Total FROM CartTbl AS crt INNER JOIN ProducatTbl AS pst ON crt.ProductId = pst.ProductId WHERE crt.UserId = @uid", con);

            cmd.Parameters.AddWithValue("@uid", userid);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            OrderRepeater.DataSource = ds;
            OrderRepeater.DataBind();

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
        if (Session["user"] != null)
        {
            string UserId = Session["user"].ToString();
            string shippingid = Request.QueryString["ShippingId"];
            MyCon();
            cmd = new SqlCommand("Select spt.*,ct.CountryName,st.Name,ctt.CityName From ShippingTbl as spt inner join CountryTbl as ct on spt.CountryId=ct.CountryId inner join StateTbl as st on spt.StateId=st.StateId inner join CityTbl  as ctt on spt.CityId = ctt.CityId Where ShippingId = @ShippingId And UserId=@userid", con);
            cmd.Parameters.AddWithValue("@ShippingId", shippingid);
            cmd.Parameters.AddWithValue("@userid", UserId);

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblName.Text = ds.Tables[0].Rows[0]["Name"].ToString(); ;
                lblMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                lblAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                lblLocality.Text = ds.Tables[0].Rows[0]["Locality"].ToString();
                lblCountry.Text = ds.Tables[0].Rows[0]["CountryName"].ToString();
                lblState.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                lblCity.Text = ds.Tables[0].Rows[0]["CityName"].ToString();
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

    protected void OrderPaymentPageBtn_Click(object sender, EventArgs e)
    {
        int TotalQtyNo = 0;
        for (int i = 0; i < OrderRepeater.Items.Count; i++)
        {
            Label lableQty = (Label)OrderRepeater.Items[i].FindControl("OrderPageLabelQuantity");
            int OrderPageLabelQty = Convert.ToInt32(lableQty.Text);
            TotalQtyNo = Convert.ToInt32(OrderPageLabelQty) + TotalQtyNo;
        }


        decimal Rpt = 0;
        int lblSubTotal = Convert.ToInt32(lblGrandTotal.Text);
        Rpt = Convert.ToInt32(lblSubTotal) + Rpt;

        if (Request.QueryString["ShippingId"] != null)
        {


            string BillNo = System.DateTime.Now.ToString("yyyymmddssffff");
            int ShippingId = Convert.ToInt32(Request.QueryString["ShippingId"].ToString());
            int UserId = Convert.ToInt32(Session["user"].ToString());
            string PaymentType = "";
            string PaymentStatus = "";

          
            if (rdoCOD.Checked)
            {
                PaymentType = "COD";
                PaymentStatus = "Pending";
            }
            else if (rdoOnline.Checked)
            {
                PaymentType = "Online";
                PaymentStatus = "Paid";
            }


            MyCon();
            cmd = new SqlCommand("Insert Into OrderTbl Values(@BillNo, @ShippingId, @UserId, @TotalAmount, @TotalQuantity, @Status, @OrderStatus, @PaymentStatus, @PaymentType, @EntryDate)", con);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@ShippingId", ShippingId);
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@TotalAmount", Rpt);
            cmd.Parameters.AddWithValue("@TotalQuantity", TotalQtyNo);
            cmd.Parameters.AddWithValue("@Status", "active");
            cmd.Parameters.AddWithValue("@OrderStatus", "Generate");
            cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
            cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
            cmd.Parameters.AddWithValue("@EntryDate", System.DateTime.Now);

            cmd.ExecuteNonQuery();
            con.Close();

            MyCon();
            cmd = new SqlCommand("SELECT MAX(OrderId) as MaxId FROM OrderTbl", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                string OrderId = ds.Tables[0].Rows[0]["MaxId"].ToString();

                // Cart Data
                MyCon();
                cmd = new SqlCommand("SELECT crt.*,pst.Price,(crt.Qty * pst.Price) as Total  FROM CartTbl crt LEFT JOIN ProducatTbl pst ON crt.ProductId = pst.ProductId WHERE crt.UserId = @UserId", con);
                cmd.Parameters.AddWithValue("@UserId", UserId);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        int ProdId = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductId"]);
                        string ProdPrice = ds.Tables[0].Rows[i]["Price"].ToString();
                        string ProdQty = ds.Tables[0].Rows[i]["Qty"].ToString();
                        int ptotal = Convert.ToInt32(ds.Tables[0].Rows[i]["Total"]);

                        MyCon();
                        cmd = new SqlCommand("Insert Into OrderDetailTbl Values(@OrderId, @ProductId, @Price, @Quantity, @Total, @EntryDate)", con);
                        cmd.Parameters.AddWithValue("@OrderId", OrderId);
                        cmd.Parameters.AddWithValue("@ProductId", ProdId);
                        cmd.Parameters.AddWithValue("@Price", ProdPrice);
                        cmd.Parameters.AddWithValue("@Quantity", ProdQty);
                        cmd.Parameters.AddWithValue("@Total", ptotal);
                        cmd.Parameters.AddWithValue("@EntryDate", System.DateTime.Now);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                   
                    string Uniqid = Request.Cookies["UniqId"].Value.ToString();
                    MyCon();
                    cmd = new SqlCommand("DELETE FROM CartTbl WHERE UniqId = @UniqId", con);
                    cmd.Parameters.AddWithValue("@UniqId", Uniqid);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }


                Response.Redirect("ConformOrder.aspx?OrderId=" + OrderId );
            }
            con.Close();
        }
    }
}