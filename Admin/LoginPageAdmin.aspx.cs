using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;

public partial class Admin_LoginPageAdmin : System.Web.UI.Page
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
        mycon();
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
        mycon();
        //cmd = new SqlCommand("SELECT * FROM CityTbl WHERE CityId = @cityId", con);
        //cmd.Parameters.AddWithValue("@cityId", DropState.SelectedValue);
        cmd = new SqlCommand("SELECT * FROM CityTbl WHERE StateId = @stateId", con);
        cmd.Parameters.AddWithValue("@stateId", DropState.SelectedValue);

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

    //void InsertUser()
    //{
    //    mycon();
    //    string UserType = "SubAdmin";
    //    string verified = "verify";
    //    cmd = new SqlCommand("Insert into AdminRegistartionTbl values(@ut,@nm,@em,@ps,@mb,@gen,@ct,@state,@country,@verified,@otp,@status,@dt)", con);
    //    cmd.Parameters.AddWithValue("@ut", UserType);
    //    cmd.Parameters.AddWithValue("@nm", txtAdminName.Text);
    //    cmd.Parameters.AddWithValue("@em", txtEmail.Text);
    //    cmd.Parameters.AddWithValue("@ps", txtPassword.Text);
    //    cmd.Parameters.AddWithValue("@mb", txtPhone.Text);
    //    cmd.Parameters.AddWithValue("@gen", dropgender.SelectedValue);
    //    cmd.Parameters.AddWithValue("@ct", DropCity.SelectedValue);
    //    cmd.Parameters.AddWithValue("@state", DropState.SelectedValue);
    //    cmd.Parameters.AddWithValue("@country", DropCountry.SelectedValue);
    //    cmd.Parameters.AddWithValue("@verified", verified);
    //    cmd.Parameters.AddWithValue("@otp", Session["otp"].ToString());
    //    cmd.Parameters.AddWithValue("@status", dropStatus.SelectedValue);
    //    cmd.Parameters.AddWithValue("@dt", DateTime.Now);
    //    cmd.ExecuteNonQuery();
    //    con.Close();
    //}


    void InsertUser()
    {
        try
        {
            mycon();
            string UserType = "SubAdmin";
            string verified = "verify";
            cmd = new SqlCommand("Insert into AdminRegistartionTbl values(@ut,@nm,@em,@ps,@mb,@gen,@ct,@state,@country,@verified,@otp,@status,@dt)", con);
            cmd.Parameters.AddWithValue("@ut", UserType);
            cmd.Parameters.AddWithValue("@nm", txtAdminName.Text);
            cmd.Parameters.AddWithValue("@em", txtEmail.Text);
            cmd.Parameters.AddWithValue("@ps", txtPassword.Text);
            cmd.Parameters.AddWithValue("@mb", txtPhone.Text);
            cmd.Parameters.AddWithValue("@gen", dropgender.SelectedValue);
            cmd.Parameters.AddWithValue("@ct", DropCity.SelectedValue);
            cmd.Parameters.AddWithValue("@state", DropState.SelectedValue);
            cmd.Parameters.AddWithValue("@country", DropCountry.SelectedValue);
            cmd.Parameters.AddWithValue("@verified", verified);
            HttpCookie otpCookie = Request.Cookies["otpCookie"];
            string savedOtp = otpCookie != null ? otpCookie.Value : "";
            cmd.Parameters.AddWithValue("@otp", savedOtp);
            cmd.Parameters.AddWithValue("@status", dropStatus.SelectedValue);
            cmd.Parameters.AddWithValue("@dt", DateTime.Now);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
        }
        finally
        {
            con.Close();
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
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    Countryfill();
        //    statefill();
        //    cityfill();
        //    string mode = Request.QueryString["mode"];
        //    string otp = Request.QueryString["otp"];
        //    //if (mode == "register")
        //    //{
        //    //    pnlregistartionform.Visible = true;
        //    //    pnlotp.Visible = false;
        //    //    pnllogin.Visible = false;
        //    //}
        //    //else if (otp == "otp")
        //    //{
        //    //    pnlregistartionform.Visible = false;
        //    //    pnlotp.Visible = true;
        //    //    pnllogin.Visible = false;
        //    //}
        //    //else
        //    //{
        //    //    pnlregistartionform.Visible = false;
        //    //    pnllogin.Visible = true;
        //    //    pnlotp.Visible = false;

        //    //}



        //}
        if (!IsPostBack)
        {
            Countryfill();
            statefill();
            cityfill();

            string mode = Request.QueryString["mode"];

            if (mode == "register")
            {
                pnlregistartionform.Visible = true;
                pnlotp.Visible = false;
                pnllogin.Visible = false;
            }
            else if (mode == "otp")
            {
                pnlregistartionform.Visible = false;
                pnlotp.Visible = true;
                pnllogin.Visible = false;
            }
            else
            {
                pnlregistartionform.Visible = false;
                pnlotp.Visible = false;
                pnllogin.Visible = true;
            }
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        mycon();
        cmd = new SqlCommand("Select * from AdminRegistartionTbl Where Email=@em and Mobile=@mb", con);
        cmd.Parameters.AddWithValue("@em", txtEmail.Text);
        cmd.Parameters.AddWithValue("@mb", txtPhone.Text);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string email = ds.Tables[0].Rows[0]["Email"].ToString();
            string mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();

            if (txtEmail.Text == email && txtPhone.Text == mobile)
            {
                Response.Write("<script>alert('Email and Mobile Number already exist.')</script>");
            }
            else if (txtEmail.Text == email)
            {
                Response.Write("<script>alert('This Email is already registered.')</script>");
            }
            else if (txtPhone.Text == mobile)
            {
                Response.Write("<script>alert('This Mobile Number is already registered.')</script>");
            }
        }

        else
        {
            //string UserType = "SubAdmin";
            //string verified = "verify";
            //Random OTPNo = new Random();
            //int OTP = OTPNo.Next(1000, 9999);
            //LblOTP.Text = Convert.ToString(OTP);
            //cmd = new SqlCommand("Insert into AdminRegistartionTbl values(@ut,@nm,@em,@ps,@mb,@gen,@ct,@state,@country,@verified,@otp,@status,@dt)", con);
            //cmd.Parameters.AddWithValue("@ut", UserType);
            //cmd.Parameters.AddWithValue("@nm", txtAdminName.Text);
            //cmd.Parameters.AddWithValue("@em", txtEmail.Text);
            //cmd.Parameters.AddWithValue("@ps", txtPassword.Text);
            //cmd.Parameters.AddWithValue("@mb", txtPhone.Text);
            //cmd.Parameters.AddWithValue("@gen", dropgender.SelectedValue);
            //cmd.Parameters.AddWithValue("@ct", DropCity.SelectedValue);
            //cmd.Parameters.AddWithValue("@state", DropState.SelectedValue);
            //cmd.Parameters.AddWithValue("@country", DropCountry.SelectedValue);
            //cmd.Parameters.AddWithValue("@verified", verified);
            //cmd.Parameters.AddWithValue("@otp", LblOTP.Text);
            //cmd.Parameters.AddWithValue("@status", dropStatus.SelectedValue);
            //cmd.Parameters.AddWithValue("@dt", DateTime.Now);
            //cmd.ExecuteNonQuery();
            //con.Close();

            //Response.Write("<script>alert('Successfully Register With Us. ')</script>");
            //txtAdminName.Text = "";
            //txtEmail.Text = "";
            //txtPassword.Text = "";
            //txtPhone.Text = "";
            //dropgender.SelectedValue = "";
            //DropCity.SelectedValue = "";
            //DropState.SelectedValue = "";
            //DropCountry.SelectedValue = "";
            //dropStatus.SelectedValue = "";

            //Random OTPNo = new Random();
            //int OTP = OTPNo.Next(100000, 999999);
            //Session["otp"] = OTP.ToString();

            //string EmailTemplatePath = Server.MapPath("~/EmailTemplate/Otp.html");
            //string MessageBody = File.ReadAllText(EmailTemplatePath);

            //MessageBody = MessageBody.Replace("[User]", txtAdminName.Text);
            //MessageBody = MessageBody.Replace("[Email]", txtEmail.Text);
            //MessageBody = MessageBody.Replace("[OTP]", OTP.ToString());

            Random OTPNo = new Random();
            int OTP = OTPNo.Next(100000, 999999);
            HttpCookie otpCookie = new HttpCookie("otpCookie");
            otpCookie.Value = OTP.ToString();
            otpCookie.Expires = DateTime.Now.AddMinutes(10);
            Response.Cookies.Add(otpCookie);
            string EmailTemplatePath = Server.MapPath("~/EmailTemplate/Otp.html");
            string MessageBody = File.ReadAllText(EmailTemplatePath);

            MessageBody = MessageBody.Replace("[User]", txtAdminName.Text);
            MessageBody = MessageBody.Replace("[Email]", txtEmail.Text);
            MessageBody = MessageBody.Replace("[OTP]", OTP.ToString());

            if (EmailSend.SendMail(txtAdminName.Text, txtEmail.Text, OTP, MessageBody))
            {
                pnlregistartionform.Visible = false;
                pnlotp.Visible = true;
                pnllogin.Visible = false;
                Response.Write("<script>alert('OTP sent successfully to your email. Please verify to complete registration.');</script>");
            }
            else
            {
                Response.Write("<script>alert('Failed to send OTP. Please check your email settings.');</script>");
            }


        }
    }

    protected void btnAdminLogin_Click(object sender, EventArgs e)
    {
        mycon();
        cmd = new SqlCommand("Select * from AdminRegistartionTbl Where Email=@em and Password=@ps", con);
        cmd.Parameters.AddWithValue("@em", txtLoginEmail.Text);
        cmd.Parameters.AddWithValue("@ps", txtLoginPassword.Text);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["login"] = ds.Tables[0].Rows[0]["UserId"].ToString();
            Response.Write("<script>alert('Successfully Login, Welcome!');</script>");
            Response.Redirect("DashBoard.aspx");
        }
        else
        {
            Response.Write("<script>alert('Email Or Password Is Wrong.');</script>");
        }

        con.Close();
        con.Dispose();
        da.Dispose();
        ds.Dispose();
        cmd.Dispose();
    }

    //protected void btnVerify_Click(object sender, EventArgs e)
    //{
    //    string otp = Request.Form["otp1"] + Request.Form["otp2"] + Request.Form["otp3"] +
    //             Request.Form["otp4"] + Request.Form["otp5"] + Request.Form["otp6"];

    //    if (Session["otp"] != null && otp == Session["otp"].ToString())
    //    {
    //        InsertUser();
    //        Response.Write("<script>alert('Successfully registered with us. Please login.');</script>");
    //        Response.Redirect("LoginPageAdmin.aspx?mode=login");
    //    }

    //}
    protected void btnVerify_Click(object sender, EventArgs e)
    {
        string otp = Request.Form["otp1"] + Request.Form["otp2"] +
                     Request.Form["otp3"] + Request.Form["otp4"] +
                     Request.Form["otp5"] + Request.Form["otp6"];

        HttpCookie otpCookie = Request.Cookies["otpCookie"];

        if (otpCookie == null)
        {
            Response.Write("<script>alert('OTP expired. Please register again.');</script>");
            return;
        }

        if (otp == otpCookie.Value)
        {
            InsertUser();

            Response.Cookies["otpCookie"].Expires = DateTime.Now.AddDays(-1);

            Response.Write("<script>alert('Registration successful! Please login.');</script>");
            Response.Redirect("LoginPageAdmin.aspx?mode=login");
        }
        else
        {
            Response.Write("<script>alert('Invalid OTP. Please try again.');</script>");
        }
    }



}