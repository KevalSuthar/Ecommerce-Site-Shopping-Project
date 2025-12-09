using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Client_CheckOut : System.Web.UI.Page
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

    void fillcart()
    {
        if (Session["user"] != null)
        {
            string userid = Session["user"].ToString();
            //string uniqcid = Request.Cookies["UniqId"].Value;

            MyCon();
            cmd = new SqlCommand("SELECT crt.*, pst.Icon, pst.Name, pst.Price, (pst.Price * crt.Qty) as Total FROM CartTbl AS crt INNER JOIN ProducatTbl AS pst ON crt.ProductId = pst.ProductId WHERE crt.UserId = @uid", con);
            //cmd.Parameters.AddWithValue("@uniqid", uniqcid);
            cmd.Parameters.AddWithValue("@uid", userid);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            rptchk.DataSource = ds;
            rptchk.DataBind();

            // Pricing Calculation
            if (ds.Tables[0].Rows.Count > 0)
            {
                int subTotal = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    subTotal += Convert.ToInt32(ds.Tables[0].Rows[i]["Total"]);
                }

                int shippingCharge = 0;
                if (subTotal >= 500)
                {
                    shippingCharge = (subTotal * 10) / 100;
                }

                int grandTotal = subTotal + shippingCharge;

                lblSubTotal.Text = subTotal.ToString();
                lblShipping.Text = shippingCharge.ToString();
                lblGrandTotal.Text = grandTotal.ToString();
            }

            con.Close();
        }
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
    void LoadAddressList()
    {
        if (Session["user"] != null)
        {
            string userid = Session["user"].ToString();
            MyCon();
            cmd = new SqlCommand("Select spt.*,ct.CountryName,st.Name,ctt.CityName From ShippingTbl as spt inner join CountryTbl as ct on spt.CountryId=ct.CountryId inner join StateTbl as st on spt.StateId=st.StateId inner join CityTbl  as ctt on spt.CityId = ctt.CityId Where UserId = @user", con);
            cmd.Parameters.AddWithValue("@user", userid);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                PanelRegisterForm.Visible = false;
                PanelAddressList.Visible = true;
                btnAddNewAddress.Visible = true;
                CheckoutRepeaterListAddress.DataSource = ds;
                CheckoutRepeaterListAddress.DataBind();
            }
            else
            {
                btnAddNewAddress.Visible = false;
                PanelRegisterForm.Visible = true;
                PanelAddressList.Visible = false;

            }

            con.Close();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillcart();
            LoadAddressList();
            if (PanelRegisterForm.Visible)
            {
                Countryfill();
            }
            //if (Session["user"] != null)
            //{


            //    string userid = Session["user"].ToString();
            //    Countryfill();
            //    MyCon();
            //    cmd = new SqlCommand("Select spt.*,ct.CountryName,st.Name,ctt.CityName From ShippingTbl as spt inner join CountryTbl as ct on spt.CountryId=ct.CountryId inner join StateTbl as st on spt.StateId=st.StateId inner join CityTbl  as ctt on spt.CityId = ctt.CityId Where UserId = @user", con);
            //    cmd.Parameters.AddWithValue("@user", userid);
            //    da = new SqlDataAdapter(cmd);
            //    ds = new DataSet();
            //    da.Fill(ds);
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        string uid = ds.Tables[0].Rows[0]["UserId"].ToString();
            //        txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            //        txtMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
            //        txtAltMobile.Text = ds.Tables[0].Rows[0]["AlternateMobile"].ToString();
            //        txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            //        txtLocality.Text = ds.Tables[0].Rows[0]["Locality"].ToString();
            //        txtPincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
            //        DropCountry.SelectedValue = ds.Tables[0].Rows[0]["CountryId"].ToString();
            //        DropCity.SelectedValue = ds.Tables[0].Rows[0]["CityId"].ToString();
            //        DropAddressType.SelectedValue = ds.Tables[0].Rows[0]["AddressType"].ToString();
            //        DropState.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();

            //        PanelRegisterForm.Visible = false;
            //        CheckoutRepeaterListAddress.DataSource = ds;
            //        CheckoutRepeaterListAddress.DataBind();
            //    }
            //    else
            //    {
            //        PanelRegisterForm.Visible = true;
            //    }
            //}
            //else
            //{

            //    Response.Redirect("LoginPage.aspx?Page=CheckOut");

            //}

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


    protected void btnSaveShipping_Click(object sender, EventArgs e)
    {

        if (Session["user"] != null)
        {

            //Upddate Code 
            if (Session["user"] != null)
            {
                string UserId = Session["user"].ToString();
                string id = Session["user"].ToString();
                MyCon();
                cmd = new SqlCommand("UPDATE ShippingTbl Set UserId=@UId, Name = @name,Mobile=@mb,AlternateMobile=@amb,Address=@add,Locality=@loc,Pincode=@pincode,CountryId=@countryid,StateId=@sid,CityId=@cityid,AddressType=@addresstype,Status=@status,EntryDate=@edate WHERE ShippingId = @shippingId", con);
                cmd.Parameters.AddWithValue("@UId", UserId);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@mb", txtMobile.Text);
                cmd.Parameters.AddWithValue("@amb", txtAltMobile.Text);
                cmd.Parameters.AddWithValue("@add", txtAddress.Text);
                cmd.Parameters.AddWithValue("@loc", txtLocality.Text);
                cmd.Parameters.AddWithValue("@pincode", txtPincode.Text);
                cmd.Parameters.AddWithValue("@countryid", DropCountry.SelectedValue);
                cmd.Parameters.AddWithValue("@sid", DropState.SelectedValue);
                cmd.Parameters.AddWithValue("@cityid", DropCity.SelectedValue);
                cmd.Parameters.AddWithValue("@addresstype", DropAddressType.SelectedValue);
                cmd.Parameters.AddWithValue("@status", DropState.SelectedValue);
                cmd.Parameters.AddWithValue("@edate", System.DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@shippingId", id);

                Response.Write("<script>alert('Successfully  Product Update Add. ')</script>");

                cmd.ExecuteNonQuery();
                con.Close();
            }
            //insert code 
            else
            {
                string UserId = Session["user"].ToString();
                MyCon();
                cmd = new SqlCommand("Insert Into ShippingTbl Values(@UserId,@Name,@Mobile,@AlternateMobile,@Address,@Locality,@Pincode,@CountryId,@StateId,@CityId,@AddressType,@Status,@EntryDate)", con);
                cmd.Parameters.AddWithValue("@UserId", UserId);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                cmd.Parameters.AddWithValue("@AlternateMobile", txtAltMobile.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Locality", txtLocality.Text);
                cmd.Parameters.AddWithValue("@Pincode", txtPincode.Text);
                cmd.Parameters.AddWithValue("@CountryId", DropCountry.SelectedValue);
                cmd.Parameters.AddWithValue("@StateId", DropState.SelectedValue);
                cmd.Parameters.AddWithValue("@CityId", DropCity.SelectedValue);
                cmd.Parameters.AddWithValue("@AddressType", DropAddressType.SelectedValue);
                cmd.Parameters.AddWithValue("@Status", DropState.SelectedValue);
                cmd.Parameters.AddWithValue("@EntryDate", System.DateTime.Now.ToString());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Successfully DataInsert With Us.')</script>");

            }
            LoadAddressList();
        }
        else
        {
            Response.Write("<script>alert('User not logged in');</script>");
            Response.Redirect("LoginPage.aspx");

        } 

//        if (Session["user"] != null)
//        {
//            string UserId = Session["user"].ToString();
//            MyCon();

//            if (Request.QueryString["ShippingId"] != null)
//            {
//                // Update existing address
//                string ShippingId = Request.QueryString["ShippingId"].ToString();
//                cmd = new SqlCommand(@"UPDATE ShippingTbl 
//                SET Name=@Name, Mobile=@Mobile, AlternateMobile=@AlternateMobile, Address=@Address, Locality=@Locality, 
//                    Pincode=@Pincode, CountryId=@CountryId, StateId=@StateId, CityId=@CityId, AddressType=@AddressType, 
//                    Status=@Status, EntryDate=@EntryDate 
//                WHERE ShippingId=@ShippingId", con);
//                cmd.Parameters.AddWithValue("@ShippingId", ShippingId);
//            }
//            else
//            {
//                // Insert new address
//                cmd = new SqlCommand(@"INSERT INTO ShippingTbl 
//                (UserId, Name, Mobile, AlternateMobile, Address, Locality, Pincode, CountryId, StateId, CityId, AddressType, Status, EntryDate)
//                VALUES
//                (@UserId, @Name, @Mobile, @AlternateMobile, @Address, @Locality, @Pincode, @CountryId, @StateId, @CityId, @AddressType, @Status, @EntryDate)", con);
//                cmd.Parameters.AddWithValue("@UserId", UserId);
//            }

//            // Common parameters
//            cmd.Parameters.AddWithValue("@Name", txtName.Text);
//            cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
//            cmd.Parameters.AddWithValue("@AlternateMobile", txtAltMobile.Text);
//            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
//            cmd.Parameters.AddWithValue("@Locality", txtLocality.Text);
//            cmd.Parameters.AddWithValue("@Pincode", txtPincode.Text);
//            cmd.Parameters.AddWithValue("@CountryId", DropCountry.SelectedValue);
//            cmd.Parameters.AddWithValue("@StateId", DropState.SelectedValue);
//            cmd.Parameters.AddWithValue("@CityId", DropCity.SelectedValue);
//            cmd.Parameters.AddWithValue("@AddressType", DropAddressType.SelectedValue);
//            cmd.Parameters.AddWithValue("@Status", DropStatus.SelectedValue);
//            cmd.Parameters.AddWithValue("@EntryDate",System.DateTime.Now.ToString());
//            cmd.ExecuteNonQuery();
//            con.Close();

//            Response.Write("<script>alert('Data Saved Successfully');</script>");
//            LoadAddressList();
//        }
//        else
//        {
//            Response.Redirect("LoginPage.aspx");
//        }

    }

    protected void CheckoutRepeaterListAddress_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "PlaceOrderPage")
        {
            string ShippingId = e.CommandArgument.ToString();
            Response.Redirect("Order.aspx?ShippingId=" + ShippingId);
        }
        else if (e.CommandName == "DeletePage")
        {
            string ShippingId = e.CommandArgument.ToString();

            MyCon();
            SqlCommand cmd = new SqlCommand("DELETE FROM ShippingTbl WHERE ShippingId = @ID", con);
            cmd.Parameters.AddWithValue("@ID", ShippingId);
            cmd.ExecuteNonQuery();
            con.Close();
            LoadAddressList();

        }

        else if (e.CommandName == "UpdatePage")
        {
            string ShippingId = e.CommandArgument.ToString();


            MyCon();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ShippingTbl WHERE ShippingId = @shippingId", con);
            cmd.Parameters.AddWithValue("@shippingId", ShippingId);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string uid = ds.Tables[0].Rows[0]["UserId"].ToString();
                txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                txtMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                txtAltMobile.Text = ds.Tables[0].Rows[0]["AlternateMobile"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                txtLocality.Text = ds.Tables[0].Rows[0]["Locality"].ToString();
                txtPincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                DropCountry.SelectedValue = ds.Tables[0].Rows[0]["CountryId"].ToString();
                DropCity.SelectedValue = ds.Tables[0].Rows[0]["CityId"].ToString();
                DropAddressType.SelectedValue = ds.Tables[0].Rows[0]["AddressType"].ToString();
                DropState.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();

                // 1. Fill country dropdown
                Countryfill();
                DropCountry.SelectedValue = ds.Tables[0].Rows[0]["CountryId"].ToString();

                // 2. Now fill state based on selected country
                statefill();
                DropState.SelectedValue = ds.Tables[0].Rows[0]["StateId"].ToString();

                // 3. Now fill city based on selected state
                cityfill();
                DropCity.SelectedValue = ds.Tables[0].Rows[0]["CityId"].ToString();


            }
            PanelRegisterForm.Visible = true;
            PanelAddressList.Visible = false;

        }
    }


    protected void btnAddNewAddress_Click(object sender, EventArgs e)
    {
        PanelRegisterForm.Visible = true;
        PanelAddressList.Visible = false;

        Countryfill();

        txtName.Text = "";
        txtMobile.Text = "";
        txtAltMobile.Text = "";
        txtAddress.Text = "";
        txtLocality.Text = "";
        txtPincode.Text = "";
        DropCountry.SelectedIndex = 0;
        DropState.Items.Clear();
        DropCity.Items.Clear();
        DropAddressType.SelectedIndex = 0;
        DropStatus.SelectedIndex = 0;
    }
}