using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;
public partial class Admin_MasterAdmin : System.Web.UI.MasterPage
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
    //protected void Page_Load(object sender, EventArgs e)
    //{        
    //    if (Session["login"] == null)
    //    {
    //        pnlUser.Visible = false;
    //        Response.Redirect("LoginPageAdmin.aspx?mode=login");

    //    }
    //    else
    //    {
    //        pnlUser.Visible = true;

    //        mycon();
    //        cmd = new SqlCommand("Select * from AdminRegistartionTbl Where UserId=@uid", con);
    //        cmd.Parameters.AddWithValue("@uid", Session["login"].ToString());
    //        da = new SqlDataAdapter(cmd);
    //        ds = new DataSet();
    //        da.Fill(ds);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            lblUser.Text = ds.Tables[0].Rows[0]["UserType"].ToString();
    //        }

    //    }
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["login"] == null)
            {
                pnlUser.Visible = false;
                Response.Redirect("LoginPageAdmin.aspx?mode=login");
            }
            else
            {
                pnlUser.Visible = true;

                mycon();
                cmd = new SqlCommand("SELECT * FROM AdminRegistartionTbl WHERE UserId=@uid", con);
                cmd.Parameters.AddWithValue("@uid", Session["login"].ToString());
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    string name = ds.Tables[0].Rows[0]["Name"].ToString();
                    string role = ds.Tables[0].Rows[0]["UserType"].ToString();

                    lblUser.Text = String.Format("{0} ({1})", name, role);

                }

                con.Close();
                da.Dispose();
                ds.Dispose();
                cmd.Dispose();
            }
        }
    }


    // Logout button click
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();      // saari session delete
        Session.Abandon();    // session terminate
        Response.Redirect("LoginPageAdmin.aspx?mode=login");  // login page pe redirect
    }

}
