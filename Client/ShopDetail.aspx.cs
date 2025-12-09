using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
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

    void CategoryFill()
    {
        MyCon();
        cmd = new SqlCommand("SELECT * FROM CategoryTbl", con);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        rptCategory.DataSource = ds;
        rptCategory.DataBind();
        con.Close();
    }
    void ShowProdt()
    {
        if (Request.QueryString["ProductId"] != null)
        {
            string id = Request.QueryString["ProductId"].ToString();
            MyCon();
            cmd = new SqlCommand("SELECT * FROM ProducatTbl Where ProductId=@pid", con);
            cmd.Parameters.AddWithValue("@pid", id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                MainImage.ImageUrl = ds.Tables[0].Rows[0]["Icon"].ToString();
                titlename.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                prodprice.Text = ds.Tables[0].Rows[0]["Price"].ToString();
                prodtDescripition.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                

            }
            con.Close();
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CategoryFill();
            ShowProdt();
        }
    }
    protected void btnPlus_Click(object sender, EventArgs e)
    {
        int qty = int.Parse(CartTxtQty.Text);
        qty++;
        CartTxtQty.Text = qty.ToString();
    }

    protected void btnMinus_Click(object sender, EventArgs e)
    {
        int qty = int.Parse(CartTxtQty.Text);
        if (qty > 1)
        {
            qty--;
            CartTxtQty.Text = qty.ToString();
        }
    }

    protected void BtnAddToCard_Click(object sender, EventArgs e)
    {
        MyCon();
        cmd = new SqlCommand("Select * from CartTbl Where ProductId= @ProdId", con);
        cmd.Parameters.AddWithValue("@ProdId", Request.QueryString["ProductId"].ToString());
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (Request.QueryString["ProductId"] != null)
            {
                MyCon();
                int ProductIdQuery = Convert.ToInt32(Request.QueryString["ProductId"].ToString());
                cmd = new SqlCommand("Update CartTbl set Qty = @QTY Where ProductId = @ProdId", con);
                cmd.Parameters.AddWithValue("@ProdId", ProductIdQuery);
                cmd.Parameters.AddWithValue("@Qty", CartTxtQty.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Cart.aspx");
                Response.Write("<script>alert(' Alredy Enter.')</script>");
            }
        }

        else
        {
            if (Request.Cookies["UniqId"] == null)
            {
                string UniId = System.DateTime.Now.ToString("yyyyMMddssff");
                HttpCookie cookie = new HttpCookie("UniqId", UniId);
                Response.Cookies.Add(cookie);
            }

            if (Session["user"] != null)
            {
                string unicid = Request.Cookies["UniqId"].Value;
                string userid = Session["user"].ToString();
                string prid = Request.QueryString["ProductId"].ToString();

                MyCon();
                cmd = new SqlCommand("INSERT INTO CartTbl (UniqId, UserId, ProductId, Qty, EntryDate) VALUES (@UniId, @UserId, @PdtId, @Qty, @EDate)", con);
                cmd.Parameters.AddWithValue("@UniId", unicid);
                cmd.Parameters.AddWithValue("@UserId", userid);
                cmd.Parameters.AddWithValue("@PdtId", prid);
                cmd.Parameters.AddWithValue("@Qty", CartTxtQty.Text);
                cmd.Parameters.AddWithValue("@EDate", System.DateTime.Now);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Product added to cart successfully.')</script>");

                Response.Redirect("Cart.aspx");
            }
            else
            {

                Response.Redirect("LoginPage.aspx?Page=CartPage");
            }

        }
    }
}