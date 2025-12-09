using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;
public partial class Admin_ThirdCategoryCreate : System.Web.UI.Page
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
        DropCategory.DataSource = ds;
        DropCategory.DataTextField = "Category";
        DropCategory.DataValueField = "CategoryId";
        DropCategory.DataBind();
        DropCategory.Items.Insert(0, "-------Select category-------");
        DropCategory.Items[0].Value = "";
        con.Close();
    }
    void SubCategoryfill()
    {
        mycon();
        cmd = new SqlCommand("Select * From SubCategoryTbl where CategoryId = @CatId ", con);
        cmd.Parameters.AddWithValue("@CatId", DropCategory.Text);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        DropSubCategory.DataSource = ds;
        DropSubCategory.DataTextField = "SubCategory";
        DropSubCategory.DataValueField = "SubCategoryId";
        DropSubCategory.DataBind();
        DropSubCategory.Items.Insert(0, "-------Select SubCategory-------");
        DropSubCategory.Items[0].Value = "";
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
                cmd = new SqlCommand("Select * from ThirdCategoryTbl Where ThirdCategoryId=@ThirdCatid", con);
                cmd.Parameters.AddWithValue("@ThirdCatid", id);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DropCategory.Text = ds.Tables[0].Rows[0]["CategoryId"].ToString();
                    string SubCateId = ds.Tables[0].Rows[0]["SubCategoryId"].ToString();
                    txtThirdCategory.Text = ds.Tables[0].Rows[0]["ThirdCategory"].ToString();
                    ThirdCateImg.ImageUrl = ds.Tables[0].Rows[0]["Icon"].ToString();
                    ThirdDropDownStatus.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();

                    DropSubCategory.Text = SubCateId;
                    SubCategoryfill();

                }
                con.Close();
                con.Dispose();
                da.Dispose();
                ds.Dispose();
                cmd.Dispose();
            }
        
        }
       
    }
    protected void btnThirdCateSave_Click(object sender, EventArgs e)
    {
        string ThirdCategoryImg = "";
        mycon();
        cmd = new SqlCommand("select * from  ThirdCategoryTbl where ThirdCategory=@Thirdcate", con);
        cmd.Parameters.AddWithValue("@Thirdcate", txtThirdCategory.Text);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('This ThirdCategory All Ready Exit')</script>");
        }
        else
        {
            //Update Code
            if (Request.QueryString["Edit"] != null)
            {
                string id = Request.QueryString["Edit"].ToString();
                cmd = new SqlCommand("UPDATE ThirdCategoryTbl SET SubCategoryId = @SubCatid, CategoryId = @catid ,ThirdCategory=@Thirdcate, Icon = @ico, Status = @Sta, EntryDate = @date WHERE ThirdCategoryId = @ThirdCatId", con);
                cmd.Parameters.AddWithValue("@SubCatid", DropSubCategory.Text);
                cmd.Parameters.AddWithValue("@catid", DropCategory.Text);
                cmd.Parameters.AddWithValue("@Thirdcate", txtThirdCategory.Text);
                if (ThirdCategoryFileUpload.HasFile)
                {
                    ThirdCategoryFileUpload.SaveAs(Server.MapPath("~/Admin/img/" + ThirdCategoryFileUpload.FileName));
                    ThirdCategoryImg = "~/Admin/img/" + ThirdCategoryFileUpload.FileName;
                }
                else
                {
                    ThirdCategoryImg = ThirdCateImg.ImageUrl;
                }
                cmd.Parameters.AddWithValue("@ico", ThirdCategoryImg);
                cmd.Parameters.AddWithValue("@Sta", ThirdDropDownStatus.Text);
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@ThirdCatId", id);

                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Successfully Update ThirdCategory Add. ')</script>");

            }
            //Insert Code
            else
            {
                cmd = new SqlCommand("Insert into ThirdCategoryTbl Values(@subcategoryId,@category,@Thirdcategory,@icon,@status,@date)", con);
                cmd.Parameters.AddWithValue("@subcategoryId", DropSubCategory.Text);
                cmd.Parameters.AddWithValue("@category", DropCategory.Text);
                cmd.Parameters.AddWithValue("@Thirdcategory", txtThirdCategory.Text);
                if (ThirdCategoryFileUpload.HasFile)
                {
                    ThirdCategoryFileUpload.SaveAs(Server.MapPath("~/Admin/img/" + ThirdCategoryFileUpload.FileName));
                    ThirdCategoryImg = "~/Admin/img/" + ThirdCategoryFileUpload.FileName;
                }
                else
                {
                    ThirdCategoryImg = ThirdCateImg.ImageUrl;
                }
                cmd.Parameters.AddWithValue("@icon", ThirdCategoryImg);
                cmd.Parameters.AddWithValue("@Status", ThirdDropDownStatus.Text);
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Successfully ThirdCategory Add. ')</script>");
                DropCategory.SelectedIndex = -1;
                DropSubCategory.SelectedIndex = -1;
                txtThirdCategory.Text = "";
                ThirdCategoryImg = "";
                ThirdDropDownStatus.Text = "";
            }
        }
        con.Close();
    }
    protected void DropCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        SubCategoryfill();
    }
}