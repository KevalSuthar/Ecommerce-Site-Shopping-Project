using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;
public partial class Admin_Country : System.Web.UI.Page
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Edit"] != null)
            {

                string id = Request.QueryString["Edit"].ToString();
                mycon();
                cmd = new SqlCommand("Select * from CountryTbl Where CountryId = @coId", con);
                cmd.Parameters.AddWithValue("@coId", id);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlCountry.SelectedValue = ds.Tables[0].Rows[0]["CountryName"].ToString();
                    ddlCountryCode.SelectedValue = ds.Tables[0].Rows[0]["Code"].ToString();
                    ddlLanguage.SelectedValue = ds.Tables[0].Rows[0]["Language"].ToString();

                }
                con.Close();
                con.Dispose();
                da.Dispose();
                ds.Dispose();
                cmd.Dispose();
            }
        }
    }
    protected void btnContrySave_Click(object sender, EventArgs e)
    {
        mycon();
        cmd = new SqlCommand("select * from CountryTbl  where CountryName=@cnm", con);
        cmd.Parameters.AddWithValue("@cnm", ddlCountry.SelectedValue);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('This CountryTbl All Ready Exit')</script>");
        }
        else
        {
            //Update Code
            if (Request.QueryString["Edit"] != null)
            {
                string id = Request.QueryString["Edit"].ToString();
                cmd = new SqlCommand("UPDATE CountryTbl SET CountryName = @cnm, Code = @cd , Language = @lg WHERE CountryId = @coId", con);
                cmd.Parameters.AddWithValue("@cnm", ddlCountry.SelectedValue);
                cmd.Parameters.AddWithValue("@cd", ddlCountryCode.SelectedValue);
                cmd.Parameters.AddWithValue("@lg", ddlLanguage.SelectedValue);
                cmd.Parameters.AddWithValue("@coId", id);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert(' Updated Country successfully.')</script>");
            }
            //Insert code
            else
            {
                cmd = new SqlCommand("Insert into CountryTbl Values(@cnm,@cd,@lg)", con);
                cmd.Parameters.AddWithValue("@cnm", ddlCountry.SelectedValue);
                cmd.Parameters.AddWithValue("@cd", ddlCountryCode.SelectedValue);
                cmd.Parameters.AddWithValue("@lg", ddlLanguage.SelectedValue);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Successfully Country Add. ')</script>");
                ddlCountry.SelectedValue = "";
                ddlCountryCode.SelectedValue = "";
                ddlLanguage.SelectedValue = "";
            }
        }
        con.Close();
    }
}