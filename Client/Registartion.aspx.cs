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

    void Countryfill()
    {
        MyCon();
        cmd = new SqlCommand("Select * From CountryTbl ", con);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        DropCountry.DataSource = ds;
        DropCountry.DataTextField = "CountryName";
        DropCountry.DataValueField = "CountryId";
        DropCountry.DataBind();
        DropCountry.Items.Insert(0, "-------Select Country-------");
        DropCountry.Items[0].Value = "";
        con.Close();
    }
    void statefill()
    {
        MyCon();
        cmd = new SqlCommand("SELECT * FROM StateTbl WHERE CountryId = @CounId", con);
        cmd.Parameters.AddWithValue("@CounId", DropCountry.SelectedValue); 
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        DropState.DataSource = ds;
        DropState.DataTextField = "Name";
        DropState.DataValueField = "StateId";
        DropState.DataBind();
        DropState.Items.Insert(0, new ListItem("-------Select State-------", ""));
        con.Close();
    }

    void cityfill()
    {
        MyCon();
        cmd = new SqlCommand("SELECT * FROM CityTbl WHERE CityId = @cityId", con);
        cmd.Parameters.AddWithValue("@cityId", DropState.SelectedValue);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        DropCity.DataSource = ds;
        DropCity.DataTextField = "CityName";
        DropCity.DataValueField = "CityId";
        DropCity.DataBind();
        DropCity.Items.Insert(0, new ListItem("-------Select City-------", ""));
        con.Close();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Countryfill();
            statefill();
            cityfill();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        MyCon();
        cmd = new SqlCommand("Select * from UserTbl Where Email=@em and Mobile=@mb", con);
        cmd.Parameters.AddWithValue("@em", txtemail.Text);
        cmd.Parameters.AddWithValue("@mb", txtphone.Text);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string email = ds.Tables[0].Rows[0]["Email"].ToString();
            string mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();

            if (txtemail.Text == email && txtphone.Text == mobile)
            {
                Response.Write("<script>alert('Email and Mobile Number already exist.')</script>");
            }
            else if (txtemail.Text == email)
            {
                Response.Write("<script>alert('This Email is already registered.')</script>");
            }
            else if (txtphone.Text == mobile)
            {
                Response.Write("<script>alert('This Mobile Number is already registered.')</script>");
            }
        }

        else
        {
            string UserType = "Client";
            Random OTPNo = new Random();
            int OTP = OTPNo.Next(1000, 9999);
            LblOTP.Text = Convert.ToString(OTP);
            cmd = new SqlCommand("Insert into UserTbl values(@ut,@nm,@em,@ps,@mb,@gen,@ct,@state,@country,@verified,@otp,@status,@dt)", con);
            cmd.Parameters.AddWithValue("@ut", UserType);
            cmd.Parameters.AddWithValue("@nm", txtname.Text);
            cmd.Parameters.AddWithValue("@em", txtemail.Text);
            cmd.Parameters.AddWithValue("@ps", txtpassword.Text);
            cmd.Parameters.AddWithValue("@mb", txtphone.Text);
            cmd.Parameters.AddWithValue("@gen", dropgender.SelectedValue);
            cmd.Parameters.AddWithValue("@ct", DropCity.SelectedValue);
            cmd.Parameters.AddWithValue("@state", DropState.SelectedValue);
            cmd.Parameters.AddWithValue("@country", DropCountry.SelectedValue);
            cmd.Parameters.AddWithValue("@verified",0);
            cmd.Parameters.AddWithValue("@otp", LblOTP.Text);
            cmd.Parameters.AddWithValue("@status", dropStatus.SelectedValue);
            cmd.Parameters.AddWithValue("@dt", DateTime.Now);

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Successfully Register With Us. ')</script>");
            txtuserttype.Text="";
            txtname.Text = "";
            txtemail.Text = "";
            txtpassword.Text = "";
            txtphone.Text = "";
            dropgender.SelectedValue = "";
            DropCity.SelectedValue = "";
            DropState.SelectedValue = "";
            DropCountry.SelectedValue = "";
            //txtverified.Text = "";
            LblOTP.Text = "";
            dropStatus.SelectedValue = "";

        }
    }
    protected void DropCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        statefill();
    }
    protected void DropState_SelectedIndexChanged(object sender, EventArgs e)
    {
        cityfill();
    }
}