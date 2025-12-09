using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;

public partial class Admin_ProductPhoto : System.Web.UI.Page
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
            if (Request.QueryString["EditSpe"] != null)
            {
                string id = Request.QueryString["EditSpe"].ToString();
                mycon();
                cmd = new SqlCommand("Select * from ProductPhotoTbl Where ProductPhotoId=@ppid", con);
                cmd.Parameters.AddWithValue("@ppid", id);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtSpecification.Text = ds.Tables[0].Rows[0]["ProductAltText"].ToString();
                    ProductPhoto.ImageUrl = ds.Tables[0].Rows[0]["Photo"].ToString();
                    DropProdPhotoStatus.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();


                }
                con.Close();
                con.Dispose();
                da.Dispose();
                ds.Dispose();
                cmd.Dispose();
            }     
        }
    }
    protected void btnProdPhotoSave_Click(object sender, EventArgs e)
    {
        string ProdctPhotoimg = "";
        mycon();
        cmd = new SqlCommand("select * from  ProductPhotoTbl where ProductAltText=@ProAltText", con);
        cmd.Parameters.AddWithValue("@ProAltText", txtSpecification.Text);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('This ProductPhoto All Ready Exit')</script>");
        }
        else
        {
            //Update Code
            if (Request.QueryString["EditSpe"] != null)
            {
                string id = Request.QueryString["EditSpe"].ToString();
                cmd = new SqlCommand("Update ProductPhotoTbl Set ProductId=@proid,ProductAltText=@proalttext,Photo=@photo,Status=@status,EntryDate=@date WHERE ProductPhotoId = @ppid", con);
                cmd.Parameters.AddWithValue("@proid", Request.QueryString["ProductId"].ToString());
                cmd.Parameters.AddWithValue("@proalttext", txtSpecification.Text);
                if (ProductPhotoFileUpload.HasFile)
                {
                    ProductPhotoFileUpload.SaveAs(Server.MapPath("~/Admin/img/" + ProductPhotoFileUpload.FileName));
                    ProdctPhotoimg = "~/Admin/img/" + ProductPhotoFileUpload.FileName;
                }
                else
                {
                    ProdctPhotoimg = ProductPhoto.ImageUrl;
                }
                cmd.Parameters.AddWithValue("@photo", ProdctPhotoimg);
                cmd.Parameters.AddWithValue("@status", DropProdPhotoStatus.Text);
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@ppid", id);
                cmd.ExecuteNonQuery();

                Response.Write("<script>alert('Successfully Product Photo Add. ')</script>");
            }
            //Insert code 
            else
            {
                cmd = new SqlCommand("Insert into ProductPhotoTbl Values(@proid,@proalttext,@photo,@status,@date)", con);
                cmd.Parameters.AddWithValue("@proid", Request.QueryString["ProductId"].ToString());
                cmd.Parameters.AddWithValue("@proalttext", txtSpecification.Text);
                if (ProductPhotoFileUpload.HasFile)
                {
                    ProductPhotoFileUpload.SaveAs(Server.MapPath("~/Admin/img/" + ProductPhotoFileUpload.FileName));
                    ProdctPhotoimg = "~/Admin/img/" + ProductPhotoFileUpload.FileName;
                }
                else
                {
                    ProdctPhotoimg = ProductPhoto.ImageUrl;
                }
                cmd.Parameters.AddWithValue("@photo", ProdctPhotoimg);
                cmd.Parameters.AddWithValue("@status", DropProdPhotoStatus.Text);
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                cmd.ExecuteNonQuery();

                Response.Write("<script>alert('Successfully Product Photo Add. ')</script>");
            }
        }
        con.Close();








        //if (Request.QueryString["ProductId"] != null)
        //{
        //    
        //cmd = new SqlCommand("Insert into ProductPhotoTbl Values(@proid,@proalttext,@photo,@status,@date)", con);
        //cmd.Parameters.AddWithValue("@proid", Request.QueryString["ProductId"].ToString());
        //cmd.Parameters.AddWithValue("@proalttext", txtSpecification.Text);
        //if (ProductPhotoFileUpload.HasFile)
        //{
        //    ProductPhotoFileUpload.SaveAs(Server.MapPath("~/Admin/img/" + ProductPhotoFileUpload.FileName));
        //    ProdctPhotoimg = "~/Admin/img/" + ProductPhotoFileUpload.FileName;
        //}
        //else
        //{
        //    ProdctPhotoimg = ProductPhoto.ImageUrl;
        //}
        //cmd.Parameters.AddWithValue("@photo", ProdctPhotoimg);
        //cmd.Parameters.AddWithValue("@status", DropProdPhotoStatus.Text);
        //cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
        //cmd.ExecuteNonQuery();

        //Response.Write("<script>alert('Successfully Product Photo Add. ')</script>");

        //}
    }
}