using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Client_ConformOrder : System.Web.UI.Page
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

    

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    if (Request.QueryString["OrderId"] != null)
        //    {
        //        string orderId = Request.QueryString["OrderId"].ToString();

        //        MyCon();
        //        cmd = new SqlCommand("SELECT BillNo FROM OrderTbl WHERE OrderId = @OrderId", con);
        //        cmd.Parameters.AddWithValue("@OrderId", orderId);
        //        da = new SqlDataAdapter(cmd);
        //        ds = new DataSet();
        //        da.Fill(ds);
        //        con.Close();

        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            string billNo = ds.Tables[0].Rows[0]["BillNo"].ToString();
        //            lblbillnum.Text = billNo;
             
        //        }
                
        //    }
        //}

        if (Request.QueryString["OrderId"] != null)
        {
            string orderId = Request.QueryString["OrderId"].ToString();

            MyCon();
            cmd = new SqlCommand("SELECT BillNo FROM OrderTbl WHERE OrderId = @OrderId", con);
            cmd.Parameters.AddWithValue("@OrderId", orderId);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                string billNo = ds.Tables[0].Rows[0]["BillNo"].ToString();
                lblbillnum.Text = billNo; 
            }
        }

    }

  
}
