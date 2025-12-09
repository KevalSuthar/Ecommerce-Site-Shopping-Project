using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Citt : System.Web.UI.Page
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
    void statefill()
    { 
        mycon();
        cmd = new SqlCommand("SELECT * FROM StateTbl WHERE CountryId = @CounId", con);
        cmd.Parameters.AddWithValue("@CounId", CountryFormDropCountry.SelectedValue);
        da = new SqlDataAdapter(cmd); 
        ds = new DataSet();
        da.Fill(ds);
        CountryFormDropState.DataSource = ds;
        CountryFormDropState.DataTextField = "Name";
        CountryFormDropState.DataValueField = "StateId"; 
        CountryFormDropState.DataBind();
        CountryFormDropState.Items.Insert(0, new ListItem("-------Select State-------", ""));
        con.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Countryfill();
            statefill();
            if (Request.QueryString["Edit"] != null)
            {
                string id = Request.QueryString["Edit"].ToString();
             
                mycon();
                cmd = new SqlCommand("Select * from CityTbl Where CityId = @cId", con);
                cmd.Parameters.AddWithValue("@cId", id);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    CountryFormDropCountry.SelectedValue = ds.Tables[0].Rows[0]["Countryid"].ToString();
                    string StateId = ds.Tables[0].Rows[0]["Stateid"].ToString();
                    //CountryFormDropState.SelectedValue = ds.Tables[0].Rows[0]["Stateid"].ToString();
                    txtCity.Text = ds.Tables[0].Rows[0]["CityName"].ToString();
                    CountryFormDropState.SelectedValue = StateId;
                    statefill();
                }
                con.Close();
                con.Dispose();
                da.Dispose();
                ds.Dispose();
                cmd.Dispose();
            }
        }
    }
    protected void btnCitySave_Click(object sender, EventArgs e)
    {
        mycon();
        cmd = new SqlCommand("select * from  CityTbl where CityName=@Cnm", con);
        cmd.Parameters.AddWithValue("@Cnm", txtCity.Text);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('This Name City All Ready Exit')</script>");
        }
        else
        {
            //Update Code
            if (Request.QueryString["Edit"] != null)
            {
                string id = Request.QueryString["Edit"].ToString();
                cmd = new SqlCommand("UPDATE CityTbl SET Countryid = @CounId, Stateid = @StaId ,CityName=@Cnm WHERE CityId = @cityid", con);
                cmd.Parameters.AddWithValue("@CounId", CountryFormDropCountry.SelectedValue);
                cmd.Parameters.AddWithValue("@StaId", CountryFormDropState.SelectedValue);
                cmd.Parameters.AddWithValue("@Cnm", txtCity.Text);     
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Successfully Update City Add. ')</script>");

            }
            //Insert Code
            else
            {
                cmd = new SqlCommand("Insert into CityTbl Values(@CounId,@StaId,@Cnm)", con);
                cmd.Parameters.AddWithValue("@CounId", CountryFormDropCountry.SelectedValue);
                cmd.Parameters.AddWithValue("@StaId", CountryFormDropState.SelectedValue);
                cmd.Parameters.AddWithValue("@Cnm", txtCity.Text);           
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Successfully City Add. ')</script>");
                CountryFormDropCountry.SelectedValue = "";
                CountryFormDropState.SelectedValue = "";
                txtCity.Text="";
            }
        }
    }
    protected void CountryFormDropCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        statefill();
    }
}