using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Client_Cart : System.Web.UI.Page
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
                //string uniqcid = Request.Cookies["UniqId"].Value.ToString();
                MyCon();
                cmd = new SqlCommand("SELECT crt.*, pst.Icon, pst.Name, pst.Price,(pst.Price * crt.Qty) as Total FROM CartTbl AS crt INNER JOIN ProducatTbl AS pst ON crt.ProductId = pst.ProductId WHERE  crt.UserId = @uid", con);
                //cmd.Parameters.AddWithValue("@uniqid", uniqcid);
                cmd.Parameters.AddWithValue("@uid", userid);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                rptcart.DataSource = ds;
                rptcart.DataBind();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int ptotal = 0;
                    int count = ds.Tables[0].Rows.Count;

                    for (int i = 0; i < count; i++)
                    {
                        ptotal += Convert.ToInt32(ds.Tables[0].Rows[i]["Total"].ToString());
                    }
                    CartlblTotal.Text = ptotal.ToString();

                    if (ptotal >= 500)
                    {
                        int shippingCharge = (ptotal * 10) / 100;
                        CartlblShippingCharge.Text = shippingCharge.ToString();
                        CartlblSubTotal.Text = (ptotal + shippingCharge).ToString();
                    }
                    else
                    {
                        CartlblShippingCharge.Text = "0";
                        CartlblSubTotal.Text = ptotal.ToString();
                    }

                }
                else
                {
                   
                    CartlblTotal.Text = "0";
                    CartlblShippingCharge.Text = "0";
                    CartlblSubTotal.Text = "0";
                }
                con.Close();
            }
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            fillcart();
        }
    }

    protected void rptcart_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            string id = e.CommandArgument.ToString();
            MyCon();
            cmd = new SqlCommand("DELETE FROM CartTbl WHERE CartId = @cid", con);
            cmd.Parameters.AddWithValue("@cid", id);
            cmd.ExecuteNonQuery();
            con.Close();
            fillcart();
            Response.Write("<script>alert('Product removed from cart.');</script>");

        }
        else if (e.CommandName == "CartProductUpdate")
        {
            TextBox TxtQty = e.Item.FindControl("CartTxtQty") as TextBox;
            string id = e.CommandArgument.ToString();
            MyCon();
            cmd = new SqlCommand("Update CartTbl Set Qty = @CartProdQty where ProductId=@Prodid", con);
            cmd.Parameters.AddWithValue("@CartProdQty", TxtQty.Text);
            cmd.Parameters.AddWithValue("@Prodid", id);
            cmd.ExecuteNonQuery();
            con.Close();
            fillcart();
            Response.Write("<script>alert('Update Data Qty .');</script>");

        }
    }
    protected void CartBtnCheckOut_Click(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {
            Response.Redirect("CheckOut.aspx");
        }
        else
        {
            Response.Redirect("LoginPage.aspx?CheckOutPade=Chk");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in rptcart.Items)
        {
            CheckBox ch1 = item.FindControl("chkproduct") as CheckBox;
            HiddenField hd1 = item.FindControl("Hiddenchk") as HiddenField;

            if (ch1 != null && ch1.Checked && hd1 != null)
            {
                int data = Convert.ToInt32(hd1.Value);
                MyCon();
                cmd = new SqlCommand("DELETE FROM CartTbl WHERE CartId = @cid", con);
                cmd.Parameters.AddWithValue("@cid", data);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        fillcart(); 
        Response.Write("<script>alert('Selected products deleted from cart.');</script>");

    }
}

