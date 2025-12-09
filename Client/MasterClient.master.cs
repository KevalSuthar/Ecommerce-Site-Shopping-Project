using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Client_MasterPage : System.Web.UI.MasterPage
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

        if (Request.QueryString["Category"] != null)
        {

            string Cat = Request.QueryString["Category"].ToString();
            MyCon();
            cmd = new SqlCommand("Select * from CategoryTbl Where Category=@ct", con);
            cmd.Parameters.AddWithValue("@ct", Cat);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            rptCategory.DataSource = ds;
            rptCategory.DataBind();
            con.Close();
        }
        else
        {
            MyCon();
            cmd = new SqlCommand("Select * from CategoryTbl", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            rptCategory.DataSource = ds;
            rptCategory.DataBind();
            con.Close();
        }
        if (Session["user"] != null)
        {
            pnlUser.Visible = true;
            //pnlorder.Visible = true;
            pnlGuest.Visible = false;
            MyCon();
            cmd = new SqlCommand("Select * from UserTbl Where UserId=@uid",con);
            cmd.Parameters.AddWithValue("@uid", Session["user"].ToString());
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count>0)
            {
                lblUser.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            }
            //lblUser.Text = "Welcome, "  + Session["user"].ToString();
        }
        else
        {
            //pnlorder.Visible = false;
            pnlUser.Visible = false;
            pnlGuest.Visible = true;
        }
    }
    protected void rptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rptSCat = e.Item.FindControl("rptSubCategory") as Repeater;
        HiddenField hCatId = e.Item.FindControl("hidCatId") as HiddenField;


        MyCon();
        cmd = new SqlCommand("select * from  SubCategoryTbl where CategoryId=@ct ", con);
        cmd.Parameters.AddWithValue("@ct", hCatId.Value);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        rptSCat.DataSource = ds;
        rptSCat.DataBind();
        con.Close();
    }

    protected void rptSubCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rptSubCat = e.Item.FindControl("rptThirdCategory") as Repeater;
        HiddenField hSubCatId = e.Item.FindControl("hidSubCatId") as HiddenField;
        MyCon();
        cmd = new SqlCommand("select * from  ThirdCategoryTbl where SubCategoryId=@sct ", con);
        cmd.Parameters.AddWithValue("@sct", hSubCatId.Value);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        rptSubCat.DataSource = ds;
        rptSubCat.DataBind();
        con.Close();
    }

    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Write("<script>alert('You have been logged out successfully.'); window.location='LoginPage.aspx';</script>");

    }

   
}