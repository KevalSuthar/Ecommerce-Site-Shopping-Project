using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Client_ForgetPassword : System.Web.UI.Page
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

    protected void btnResetPassword_Click(object sender, EventArgs e)
    {
        MyCon();

        cmd = new SqlCommand("Select * From UserTbl Where Email = @Em", con);
        cmd.Parameters.AddWithValue("@Em", TxtEmail.Text);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            MyCon();
            cmd = new SqlCommand("Update UserTbl Set Password = @Pwd Where Email = @Em", con);
            cmd.Parameters.AddWithValue("@Pwd", TxtPassword.Text);
            cmd.Parameters.AddWithValue("@Em", TxtEmail.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Update Password.')</script>");
            Response.Redirect("LoginPage.aspx");
            TxtEmail.Text = "";
            TxtPassword.Text = "";
        }
        else
        {
            Response.Write("<script>alert('Wrong Email.')</script>");
        }

        cmd.ExecuteNonQuery();
        con.Close();
    }
}