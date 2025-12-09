using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;

public partial class Admin_State : System.Web.UI.Page
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
    void Countryfill()
    {
        mycon();
        cmd = new SqlCommand("Select * From CountryTbl ", con);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        CountryFormDropCountry.DataSource = ds;
        CountryFormDropCountry.DataTextField = "CountryName";
        CountryFormDropCountry.DataValueField = "CountryId";
        CountryFormDropCountry.DataBind();
        CountryFormDropCountry.Items.Insert(0, "-------Select Country-------");
        CountryFormDropCountry.Items[0].Value = "";
        con.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Countryfill();

            if (Request.QueryString["Edit"] != null)
            {

                string id = Request.QueryString["Edit"].ToString();
                mycon();
                cmd = new SqlCommand("Select * from StateTbl Where StateId = @sId", con);
                cmd.Parameters.AddWithValue("@sId", id);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    CountryFormDropCountry.SelectedValue = ds.Tables[0].Rows[0]["CountryId"].ToString();
                    txtstate.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                con.Close();
                con.Dispose();
                da.Dispose();
                ds.Dispose();
                cmd.Dispose();
            }
        }

    }
 
    protected void btnStateSave_Click(object sender, EventArgs e)
    {

        mycon();
        cmd = new SqlCommand("SELECT * FROM StateTbl WHERE Name = @nm AND CountryId = @cid", con);
        cmd.Parameters.AddWithValue("@nm", txtstate.Text);
        cmd.Parameters.AddWithValue("@cid", CountryFormDropCountry.SelectedValue);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('this state and country already exist')</script>");

        }
        else 
        {
            //Update Code 
            if (Request.QueryString["Edit"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["Edit"]);
                cmd = new SqlCommand("UPDATE StateTbl SET Name = @nm, CountryId = @cid WHERE StateId = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nm", txtstate.Text);
                cmd.Parameters.AddWithValue("@cid", CountryFormDropCountry.SelectedValue);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('State Updated Successfully')</script>");
            }
            //Insert code 
            else
            {
                cmd = new SqlCommand("INSERT INTO StateTbl (Name, CountryId) VALUES (@nm, @cid)", con);
                cmd.Parameters.AddWithValue("@nm", txtstate.Text);
                cmd.Parameters.AddWithValue("@cid", CountryFormDropCountry.SelectedValue);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('State Inserted Successfully')</script>");
                txtstate.Text = "";
                CountryFormDropCountry.SelectedValue = "";
           }
        }
         con.Close();
    }
}