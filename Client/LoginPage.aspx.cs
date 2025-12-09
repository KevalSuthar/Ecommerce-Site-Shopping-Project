using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Client_Default : System.Web.UI.Page
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

    }
    protected void login_Click(object sender, EventArgs e)
    {
        
        MyCon();
        cmd = new SqlCommand("Select * from UserTbl Where Email=@em and Password=@ps", con);
        cmd.Parameters.AddWithValue("@em", txtLoginemail.Text);
        cmd.Parameters.AddWithValue("@ps", txtloginpassword.Text);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["user"] = ds.Tables[0].Rows[0]["UserId"].ToString();
            Response.Write(Session["user"].ToString());
            Response.Write("<script>alert('Successfully Login,Welcome.')</script>");
            if (Request.QueryString["Page"] != null && Request.QueryString["Page"].ToString() == "CheckOut")
            {
                Response.Redirect("CheckOut.aspx");  
            }
            else
            {
                Response.Redirect("index.aspx");   
            }
        }
        else
        {
            Response.Write("<script>alert('Email Or Password Is wrong.')</script>");
        }

        con.Close();
        con.Dispose();
        da.Dispose();
        ds.Dispose();
        cmd.Dispose();
    }
}