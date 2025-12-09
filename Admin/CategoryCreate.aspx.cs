using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;


public partial class Admin_CategoryCreate : System.Web.UI.Page
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
            if (Session["login"] != null)
            {
                string UserId = Session["login"].ToString();
                mycon();
                cmd = new SqlCommand("Select * From AdminRegistartionTbl where UserId = @uid", con);
                cmd.Parameters.AddWithValue("@uid", UserId);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Panel1.Visible = false;
                    
                }
                else
                {
                    Panel1.Visible = true;
                }
            
            if (Request.QueryString["Edit"] != null)
            {

                string id = Request.QueryString["Edit"].ToString();
                mycon();
                cmd = new SqlCommand("Select * from CategoryTbl Where CategoryId=@catid", con);
                cmd.Parameters.AddWithValue("@catid", id);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCategory.Text = ds.Tables[0].Rows[0]["Category"].ToString();
                    CategoryImg.ImageUrl = ds.Tables[0].Rows[0]["Icon"].ToString();
                    DropCateStatus.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();
                }

                con.Close();
                con.Dispose();
                da.Dispose();
                ds.Dispose();
                cmd.Dispose();
            }
        }
        }
    }
    protected void btnCateSave_Click(object sender, EventArgs e) //Insert Mate
    {
        string CateImg = "";
        mycon();
        cmd = new SqlCommand("select * from  CategoryTbl where Category=@cate", con);
        cmd.Parameters.AddWithValue("@cate", txtCategory.Text);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('This Category All Ready Exit')</script>");
        }
        else
        {
            //Update Code
            if (Request.QueryString["Edit"] != null)
            {
                string id = Request.QueryString["Edit"].ToString();
                cmd = new SqlCommand("UPDATE CategoryTbl SET Category = @Cat, Icon = @ico, Status = @Sta, EntryDate = @date WHERE CategoryId = @CatId", con);
                cmd.Parameters.AddWithValue("@Cat", txtCategory.Text);
                if (CategoryFileUpload.HasFile)
                {
                    CategoryFileUpload.SaveAs(Server.MapPath("~/Admin/img/" + CategoryFileUpload.FileName));
                    CateImg = "~/Admin/img/" + CategoryFileUpload.FileName;
                }
                else
                {
                    CateImg = CategoryImg.ImageUrl;
                }
                cmd.Parameters.AddWithValue("@ico", CateImg);
                cmd.Parameters.AddWithValue("@Sta", DropCateStatus.SelectedValue);
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@CatId", id);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Category updated successfully.')</script>");

            }

                //Insert Code
            else
            {

                cmd = new SqlCommand("Insert into CategoryTbl Values(@Category,@icon,@Status,@date)", con);
                cmd.Parameters.AddWithValue("@Category", txtCategory.Text);
                if (CategoryFileUpload.HasFile)
                {
                    CategoryFileUpload.SaveAs(Server.MapPath("~/Admin/img/" + CategoryFileUpload.FileName));
                    CateImg = "~/Admin/img/" + CategoryFileUpload.FileName;
                }
                else
                {
                    CateImg = CategoryImg.ImageUrl;
                }
                cmd.Parameters.AddWithValue("@icon", CateImg);
                cmd.Parameters.AddWithValue("@Status", DropCateStatus.Text);
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Successfully Category Add. ')</script>");
                txtCategory.Text = "";
                CateImg = "";
                DropCateStatus.Text = "";
            }
        }
            con.Close();

        
    }
}