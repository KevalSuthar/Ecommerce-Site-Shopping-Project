using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;
public partial class Admin_BrandCreate : System.Web.UI.Page
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
                cmd = new SqlCommand("Select * from BrandTbl Where BrandId=@Braid", con);
                cmd.Parameters.AddWithValue("@Braid", id);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtBrand.Text = ds.Tables[0].Rows[0]["Brand"].ToString();
                    BrandImg.ImageUrl = ds.Tables[0].Rows[0]["Icon"].ToString();
                    DropBrandStatus.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();
                }
                con.Close();
                con.Dispose();
                da.Dispose();
                ds.Dispose();
                cmd.Dispose();
            }
        }
    }
    protected void btnBrandSave_Click(object sender, EventArgs e)
    {
        string BrandImguplo = "";
        mycon();
        cmd = new SqlCommand("select * from  BrandTbl where Brand=@brand", con);
        cmd.Parameters.AddWithValue("@brand", txtBrand.Text);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('This Brand All Ready Exit')</script>");
        }
        else
        {
            //Update Code
            if (Request.QueryString["Edit"] != null)
            {
                string id = Request.QueryString["Edit"].ToString();
                cmd = new SqlCommand("UPDATE BrandTbl SET Brand = @Bra, Icon = @ico, Status = @Sta, EntryDate = @date WHERE BrandId = @BraId", con);
                cmd.Parameters.AddWithValue("@Bra", txtBrand.Text);
                if (BrandFileUpload.HasFile)
                {
                    BrandFileUpload.SaveAs(Server.MapPath("~/Admin/img/" + BrandFileUpload.FileName));
                    BrandImguplo = "~/Admin/img/" + BrandFileUpload.FileName;
                }
                else
                {
                    BrandImguplo = BrandImg.ImageUrl;
                }
                cmd.Parameters.AddWithValue("@ico", BrandImguplo);
                cmd.Parameters.AddWithValue("@Sta", DropBrandStatus.SelectedValue);
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@BraId", id);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Brand updated successfully.')</script>");

            }
            //Insert code
            else
            {
                cmd = new SqlCommand("Insert into BrandTbl Values(@Brand,@icon,@status,@date)", con);
                cmd.Parameters.AddWithValue("@Brand", txtBrand.Text);
                if (BrandFileUpload.HasFile)
                {
                    BrandFileUpload.SaveAs(Server.MapPath("~/Admin/img/" + BrandFileUpload.FileName));
                    BrandImguplo = "~/Admin/img/" + BrandFileUpload.FileName;
                }
                else
                {
                    BrandImguplo = BrandImg.ImageUrl;
                }

                cmd.Parameters.AddWithValue("@icon", BrandImguplo);
                cmd.Parameters.AddWithValue("@Status", DropBrandStatus.Text);
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Successfully BrandCategory Add. ')</script>");
                txtBrand.Text = "";
                BrandImguplo = "";
                DropBrandStatus.Text = "";
            }
        }
        con.Close();
        
    }
}