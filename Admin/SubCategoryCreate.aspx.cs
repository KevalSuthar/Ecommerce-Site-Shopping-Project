using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;

public partial class Admin_SubCategoryCreate : System.Web.UI.Page
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
    void Categoryfill()
    {
        mycon();
        cmd = new SqlCommand("Select * From CategoryTbl", con);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        SubCateFormDropCategory.DataSource = ds;
        SubCateFormDropCategory.DataTextField = "Category";
        SubCateFormDropCategory.DataValueField = "CategoryId";
        SubCateFormDropCategory.DataBind();
        SubCateFormDropCategory.Items.Insert(0, "-------Select category-------");
        SubCateFormDropCategory.Items[0].Value = "";
        con.Close();
    }


    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            Categoryfill();

            if (Request.QueryString["Edit"] != null)
            {

                string id = Request.QueryString["Edit"].ToString();
                mycon();
                cmd = new SqlCommand("Select * from SubCategoryTbl Where SubCategoryId=@SubCatid", con);
                cmd.Parameters.AddWithValue("@SubCatid", id);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    SubCateFormDropCategory.Text = ds.Tables[0].Rows[0]["CategoryId"].ToString();
                    txtSubCategory.Text = ds.Tables[0].Rows[0]["SubCategory"].ToString();
                    SubCateImg.ImageUrl = ds.Tables[0].Rows[0]["Icon"].ToString();
                    SubDropDownStatus.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();

                }
                con.Close();
                con.Dispose();
                da.Dispose();
                ds.Dispose();
                cmd.Dispose();
            }
        }
    }
    protected void btnSubCateSave_Click(object sender, EventArgs e)
    {
        string SubCategoryImg = "";
        mycon();
        cmd = new SqlCommand("select * from  SubCategoryTbl where SubCategory=@subcate", con);
        cmd.Parameters.AddWithValue("@subcate", txtSubCategory.Text);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('This SubCategory All Ready Exit')</script>");
        }
        else
        {
            //Update Code
            if (Request.QueryString["Edit"] != null)
            {
                string id = Request.QueryString["Edit"].ToString();
                cmd = new SqlCommand("UPDATE SubCategoryTbl SET CategoryId = @Catid, SubCategory = @SubCat , Icon = @ico, Status = @Sta, EntryDate = @date WHERE SubCategoryId = @SubCatId", con);
                cmd.Parameters.AddWithValue("@Catid", SubCateFormDropCategory.Text);
                cmd.Parameters.AddWithValue("@SubCat", txtSubCategory.Text);
                if (SubCategoryFileUpload.HasFile)
                {
                    SubCategoryFileUpload.SaveAs(Server.MapPath("~/Admin/img/" + SubCategoryFileUpload.FileName));
                    SubCategoryImg = "~/Admin/img/" + SubCategoryFileUpload.FileName;
                }
                else
                {
                    SubCategoryImg = SubCateImg.ImageUrl;
                }
                cmd.Parameters.AddWithValue("@ico", SubCategoryImg);
                cmd.Parameters.AddWithValue("@Sta", SubDropDownStatus.Text);
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@SubCatId", id);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('SubCategory updated successfully.')</script>");
            }
            else
            {
                cmd = new SqlCommand("Insert into SubCategoryTbl Values(@categoryId,@subcategory,@icon,@status,@date)", con);
                cmd.Parameters.AddWithValue("@categoryId", SubCateFormDropCategory.Text);
                cmd.Parameters.AddWithValue("@subcategory", txtSubCategory.Text);
                if (SubCategoryFileUpload.HasFile)
                {
                    SubCategoryFileUpload.SaveAs(Server.MapPath("~/Admin/img/" + SubCategoryFileUpload.FileName));
                    SubCategoryImg = "~/Admin/img/" + SubCategoryFileUpload.FileName;
                }
                else
                {
                    SubCategoryImg = SubCateImg.ImageUrl;
                }
                cmd.Parameters.AddWithValue("@icon", SubCategoryImg);
                cmd.Parameters.AddWithValue("@Status", SubDropDownStatus.Text);
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Successfully SubCategory Add. ')</script>");
                SubCateFormDropCategory.SelectedIndex = -1;
                txtSubCategory.Text = "";
                SubCategoryImg = "";
                SubDropDownStatus.Text = "";
            }
        }
            con.Close();
        
    }

}