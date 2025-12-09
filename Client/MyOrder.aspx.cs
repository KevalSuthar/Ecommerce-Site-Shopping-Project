using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class Client_Contact : System.Web.UI.Page
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

    void orderdata()
    {
        if (Request.QueryString["OrderId"] != null)
        {
            string OrderId = Request.QueryString["OrderId"].ToString();
            MyCon();
            cmd = new SqlCommand("select ot.*,pt.Name from OrderDetailTbl as ot inner join ProducatTbl as pt on pt.ProductId=ot.ProductId  Where OrderId=@oid", con);
            cmd.Parameters.AddWithValue("@oid", OrderId);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();
            da.Dispose();
            ds.Dispose();
            cmd.Dispose();
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    if (Session["user"] != null)
        //    {
        //        orderdata();
        //        MyCon();
        //        cmd = new SqlCommand("Select * From OrderTbl  Where UserId =@ui", con);
        //        cmd.Parameters.AddWithValue("@ui", Session["user"].ToString());
        //        da = new SqlDataAdapter(cmd);
        //        ds = new DataSet();
        //        da.Fill(ds);
        //        GridView1.DataSource = ds;
        //        GridView1.DataBind();
        //        con.Close();

        //    }
        //    else
        //    {
        //        Response.Redirect("LoginPage.aspx?Page=MyOrders");
        //    }

        //}
        if (!IsPostBack)
        {
            if (Session["user"] != null)
            {
                if (Request.QueryString["OrderId"] != null)
                {
                    
                    orderdata();
                }
                else
                {
                   
                    MyCon();
                    cmd = new SqlCommand("Select * From OrderTbl Where UserId = @ui", con);
                    cmd.Parameters.AddWithValue("@ui", Session["user"].ToString());
                    da = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    con.Close();
                }
            }
            else
            {
                Response.Redirect("LoginPage.aspx?Page=MyOrders");
            }
        }
    }   
}