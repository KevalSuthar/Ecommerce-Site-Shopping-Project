using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;
public partial class Admin_ProductCreate : System.Web.UI.Page
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
        con.Close();
        DropSubCategory.Items.Insert(0, "-------Select Subcategory-------");
        DropSubCategory.Items[0].Value = "";
    }
    void ThirdCategoryfill()
    {
        mycon();
        cmd = new SqlCommand("Select * From ThirdCategoryTbl where SubCategoryId = @SubCatId ", con);
        cmd.Parameters.AddWithValue("@SubCatId", DropSubCategory.Text);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        DropThirdCategory.DataSource = ds;
        DropThirdCategory.DataTextField = "ThirdCategory";
        DropThirdCategory.DataValueField = "ThirdCategoryId";
        DropThirdCategory.DataBind();
        DropThirdCategory.Items.Insert(0, "-------Select ThirdCategory-------");
        DropThirdCategory.Items[0].Value = "";
        con.Close();
    }
    void Brandfill()
    {
        mycon();
        cmd = new SqlCommand("Select * From BrandTbl", con);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        DropBrand.DataSource = ds;
        DropBrand.DataTextField = "Brand";
        DropBrand.DataValueField = "BrandId";
        DropBrand.DataBind();
        DropBrand.Items.Insert(0, "-------Select Brand -------");
        DropBrand.Items[0].Value = "";
        con.Close();
    }
    void fillcat()
    {
        //mycon();
        //cmd = new SqlCommand("select ps.*,st.SpecificationName ,spo.Value from ProductSpecificationOptionTbl as ps inner join SpecificationsTbl as st on ps.SpecificationsId = st.SpecificationsId  left outer join SpecificationsOptionTbl as spo on ps.SpecificationOptionId=spo.SpecificationsOptionId", con);
        //da = new SqlDataAdapter(cmd);
        //ds = new DataSet();
        //da.Fill(ds);
        //ProductSpecificationGrid.DataSource = ds;
        //ProductSpecificationGrid.DataBind();
        //con.Close();
        //con.Dispose();
        //da.Dispose();
        //ds.Dispose();
        //cmd.Dispose();
        string productId = Request.QueryString["Edit"];
        if (!string.IsNullOrEmpty(productId))
        {
            mycon();
            cmd = new SqlCommand("SELECT ps.*, st.SpecificationName, spo.Value FROM ProductSpecificationOptionTbl ps INNER JOIN SpecificationsTbl st ON ps.SpecificationsId = st.SpecificationsId LEFT JOIN SpecificationsOptionTbl spo ON ps.SpecificationOptionId = spo.SpecificationsOptionId WHERE ps.ProductId = @ProductId", con);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            ProductSpecificationGrid.DataSource = ds;
            ProductSpecificationGrid.DataBind();
            con.Close();           
            con.Dispose();
            da.Dispose();
            ds.Dispose();
            cmd.Dispose();
        }
    }
    void prophotofill()
    {
        //string productId = Request.QueryString["Edit"];
        //mycon();
        //cmd = new SqlCommand("SELECT * FROM ProductPhotoTbl WHERE ProductId = @ProductId", con);
        //cmd.Parameters.AddWithValue("@ProductId", productId);
        //da = new SqlDataAdapter(cmd);
        //ds = new DataSet();
        //da.Fill(ds);
        //ProductPhotoView1.DataSource = ds;
        //ProductPhotoView1.DataBind();
        //con.Close();
        //con.Dispose();
        //da.Dispose();
        //ds.Dispose();
        //cmd.Dispose();
        string productId = Request.QueryString["Edit"];
        if (!string.IsNullOrEmpty(productId))
        {
            mycon();
            cmd = new SqlCommand("SELECT * FROM ProductPhotoTbl WHERE ProductId = @ProductId", con);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            ProductPhotoView1.DataSource = ds;
            ProductPhotoView1.DataBind();
            con.Close();

            // Clean up
            con.Dispose();
            da.Dispose();
            ds.Dispose();
            cmd.Dispose();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {



        if (!IsPostBack)
        {
            fillcat();
            prophotofill();

        }



        //add vakhte 

        if (!IsPostBack)
        {
            Categoryfill();
            Brandfill();

            if (Request.QueryString["Edit"] != null)
            {
                string id = Request.QueryString["Edit"].ToString();
                Panel1.Visible = false;
                Panel2.Visible = true;
                Panel3.Visible = false;
                Panel4.Visible = true;

                mycon();
                cmd = new SqlCommand("Select * from ProducatTbl Where ProductId=@Produid", con);
                cmd.Parameters.AddWithValue("@Produid", id);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtPrince.Text = ds.Tables[0].Rows[0]["Price"].ToString();
                    DropCategory.Text = ds.Tables[0].Rows[0]["CategoryId"].ToString();
                    string SubCateId = ds.Tables[0].Rows[0]["SubCategoryId"].ToString();
                    string ThirdCateId = ds.Tables[0].Rows[0]["ThirdCategoryId"].ToString();
                    DropBrand.Text = ds.Tables[0].Rows[0]["BrandId"].ToString();
                    ProdImg.ImageUrl = ds.Tables[0].Rows[0]["Icon"].ToString();
                    txtDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                    DropProdStatus.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();

                    DropSubCategory.Text = SubCateId;
                    SubCategoryfill();

                    DropThirdCategory.Text = ThirdCateId;
                    ThirdCategoryfill();
                }
                con.Close();
                con.Dispose();
                da.Dispose();
                ds.Dispose();
                cmd.Dispose();
            }

        }

    }
    protected void btnProdSave_Click(object sender, EventArgs e)
    {
        string ProductImg = "";
        mycon();
        cmd = new SqlCommand("select * from  ProducatTbl where Name=@name", con);
        cmd.Parameters.AddWithValue("@name", txtName.Text);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('This Producat Name All Ready Exit')</script>");
        }
        else
        {
            //Update Code
            if (Request.QueryString["Edit"] != null)
            {
                string id = Request.QueryString["Edit"].ToString();
                cmd = new SqlCommand("UPDATE ProducatTbl SET Name = @name, Price = @price ,CategoryId=@catid,SubCategoryId=@subcatid, ThirdCategoryId=@thirdcatid,BrandId=@brandid,Icon = @ico,Description=@description, Status = @Sta WHERE ProductId = @Produid", con);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@price", txtPrince.Text);
                cmd.Parameters.AddWithValue("@catid", DropCategory.Text);
                cmd.Parameters.AddWithValue("@subcatid", DropSubCategory.Text);
                cmd.Parameters.AddWithValue("@thirdcatid", DropThirdCategory.Text);
                cmd.Parameters.AddWithValue("@brandid", DropBrand.Text);
                if (ProductFileUpload.HasFile)
                {
                    ProductFileUpload.SaveAs(Server.MapPath("~/Admin/img/" + ProductFileUpload.FileName));
                    ProductImg = "~/Admin/img/" + ProductFileUpload.FileName;
                }
                else
                {
                    ProductImg = ProdImg.ImageUrl;
                }
                cmd.Parameters.AddWithValue("@ico", ProductImg);
                cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@Sta", DropProdStatus.Text);
                cmd.Parameters.AddWithValue("@Produid", id);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Successfully  Product Update Add. ')</script>");

            }
            //insertCode
            else
            {

                cmd = new SqlCommand("Insert into ProducatTbl Values(@name,@price,@cateid,@subcateid,@thirdcateid,@brandid,@icon,@description,@status)", con);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@price", txtPrince.Text);
                cmd.Parameters.AddWithValue("@cateid", DropCategory.Text);
                cmd.Parameters.AddWithValue("@subcateid", DropSubCategory.Text);
                cmd.Parameters.AddWithValue("@thirdcateid", DropThirdCategory.Text);
                cmd.Parameters.AddWithValue("@brandid", DropBrand.Text);
                if (ProductFileUpload.HasFile)
                {
                    ProductFileUpload.SaveAs(Server.MapPath("~/Admin/img/" + ProductFileUpload.FileName));
                    ProductImg = "~/Admin/img/" + ProductFileUpload.FileName;
                }
                else
                {
                    ProductImg = ProdImg.ImageUrl;
                }
                cmd.Parameters.AddWithValue("@icon", ProductImg);
                cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@status", DropProdStatus.Text);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Successfully Product Add. ')</script>");
                txtName.Text = "";
                txtPrince.Text = "";
                DropCategory.SelectedIndex = -1;
                DropSubCategory.SelectedIndex = -1;
                DropThirdCategory.SelectedIndex = -1;
                DropBrand.SelectedIndex = -1;
                ProductImg = "";
                txtDescription.Text = "";
                DropProdStatus.Text = "";

            }
        }
        con.Close();

    }
    protected void DropCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        SubCategoryfill();
    }
    protected void DropSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        ThirdCategoryfill();
    }

    //protected void btnAddSpecification_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("SpecificationPage.aspx");

    //}

    protected void ProductSpecificationGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            string Id = e.CommandArgument.ToString();
            mycon();
            cmd = new SqlCommand("delete  ProductSpecificationOptionTbl where ProductSpecificationOptionId = @PsoId", con);
            cmd.Parameters.AddWithValue("@PsoId", Id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            fillcat();

            con.Close();


        }
    }
    protected void ProductPhotoView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            string Id = e.CommandArgument.ToString();
            mycon();
            cmd = new SqlCommand("delete  ProductPhotoTbl where ProductPhotoId = @ProId", con);
            cmd.Parameters.AddWithValue("@ProId", Id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            con.Close();
            prophotofill();

        }
    }
}