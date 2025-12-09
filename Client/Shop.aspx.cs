using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Client_Shop : System.Web.UI.Page
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

    //void BindProducts()
    //{
    //    string search = Request.QueryString["search"]; 
    //    MyCon();
    //    cmd = new SqlCommand("SELECT * FROM ProducatTbl WHERE Name LIKE @search", con);
    //    cmd.Parameters.AddWithValue("@search", "%" + search + "%");
    //    da = new SqlDataAdapter(cmd);
    //    ds = new DataSet();
    //    da.Fill(ds);
    //    rptProduct.DataSource = ds;
    //    rptProduct.DataBind();
    //    con.Close();
    //}

    void categorydata()
    {
        MyCon();
        string Cat = Request.QueryString["CategoryId"].ToString();
        cmd = new SqlCommand("SELECT pt.*, bt.Brand FROM ProducatTbl AS pt INNER JOIN BrandTbl AS bt ON bt.BrandId = pt.BrandId WHERE pt.CategoryId = @ct", con);
        cmd.Parameters.AddWithValue("@ct", Cat);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        rptProduct.DataSource = ds;
        rptProduct.DataBind();
        con.Close();
        da.Dispose();
        ds.Dispose();
        cmd.Dispose();
    }

    void subcategorydata()
    {
        MyCon();
        string SubCat = Request.QueryString["SubCategoryId"].ToString();
        cmd = new SqlCommand("SELECT pt.*, bt.Brand FROM ProducatTbl AS pt INNER JOIN BrandTbl AS bt ON bt.BrandId = pt.BrandId WHERE pt.SubCategoryId = @sct", con);
        cmd.Parameters.AddWithValue("@sct", SubCat);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        rptProduct.DataSource = ds;
        rptProduct.DataBind();
        con.Close();
        da.Dispose();
        ds.Dispose();
        cmd.Dispose();
    }
    void thirdcategorydata()
    {
        MyCon();
        string ThirdCat = Request.QueryString["ThirdCategoryId"].ToString();
        cmd = new SqlCommand("SELECT pt.*, bt.Brand FROM ProducatTbl AS pt INNER JOIN BrandTbl AS bt ON bt.BrandId = pt.BrandId WHERE pt.ThirdCategoryId = @tct", con);
        cmd.Parameters.AddWithValue("@tct", ThirdCat);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        rptProduct.DataSource = ds;
        rptProduct.DataBind();
        con.Close();
        da.Dispose();
        ds.Dispose();
        cmd.Dispose();
    }

    void BrandData()
    {
        MyCon();
        cmd = new SqlCommand("SELECT pt.*, bt.Brand FROM ProducatTbl AS pt INNER JOIN BrandTbl AS bt ON bt.BrandId = pt.BrandId", con);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        rptProduct.DataSource = ds;
        rptProduct.DataBind();
        con.Close();
        da.Dispose();
        ds.Dispose();
        cmd.Dispose();
    }
    void SubCatFill()
    {
        MyCon();
        string CatId = Request.QueryString["CategoryId"];
        cmd = new SqlCommand("SELECT * FROM SubCategoryTbl WHERE CategoryId = @cid", con);
        cmd.Parameters.AddWithValue("@cid", CatId);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        rptSubCategory.DataSource = ds;
        rptSubCategory.DataBind();
        con.Close();
    }
    void ThirdCatFill()
    {
        MyCon();
        if (Request.QueryString["SubCategoryId"] != null)
        {
            string subCatId = Request.QueryString["SubCategoryId"];
            cmd = new SqlCommand("SELECT * FROM ThirdCategoryTbl WHERE SubCategoryId = @sid", con);
            cmd.Parameters.AddWithValue("@sid", subCatId);
        }
        else if (Request.QueryString["CategoryId"] != null)
        {
            string catId = Request.QueryString["CategoryId"];
            cmd = new SqlCommand("SELECT * FROM ThirdCategoryTbl WHERE CategoryId = @cid", con);
            cmd.Parameters.AddWithValue("@cid", catId);
        }
        else
        {
            cmd = new SqlCommand("SELECT * FROM ThirdCategoryTbl", con);
        }

        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        rptThirdCategory.DataSource = ds;
        rptThirdCategory.DataBind();
        con.Close();
    }

    void filter()
    {
        MyCon();
        string query = "";
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        string filter = dropFillter.SelectedValue;

        if (Request.QueryString["ThirdCategoryId"] != null)
        {
            string id = Request.QueryString["ThirdCategoryId"].ToString();
            if (filter == "1")
                query = "SELECT pt.*, bt.Brand FROM ProducatTbl pt INNER JOIN BrandTbl bt ON bt.BrandId = pt.BrandId WHERE pt.ThirdCategoryId = @id ORDER BY pt.Name ASC";
            else if (filter == "2")
                query = "SELECT pt.*, bt.Brand FROM ProducatTbl pt INNER JOIN BrandTbl bt ON bt.BrandId = pt.BrandId WHERE pt.ThirdCategoryId = @id ORDER BY pt.Name DESC";
            else if (filter == "3")
                query = "SELECT pt.*, bt.Brand FROM ProducatTbl pt INNER JOIN BrandTbl bt ON bt.BrandId = pt.BrandId WHERE ISNUMERIC(pt.Price) = 1 AND pt.ThirdCategoryId = @id ORDER BY CAST(pt.Price AS FLOAT) ASC";
            else if (filter == "4")
                query = "SELECT pt.*, bt.Brand FROM ProducatTbl pt INNER JOIN BrandTbl bt ON bt.BrandId = pt.BrandId WHERE ISNUMERIC(pt.Price) = 1 AND pt.ThirdCategoryId = @id ORDER BY CAST(pt.Price AS FLOAT) DESC";
            else
                query = "SELECT pt.*, bt.Brand FROM ProducatTbl pt INNER JOIN BrandTbl bt ON bt.BrandId = pt.BrandId WHERE pt.ThirdCategoryId = @id";

            cmd.Parameters.AddWithValue("@id", id);
        }
        else if (Request.QueryString["SubCategoryId"] != null)
        {
            string id = Request.QueryString["SubCategoryId"].ToString();
            if (filter == "1")
                query = "SELECT pt.*, bt.Brand FROM ProducatTbl pt INNER JOIN BrandTbl bt ON bt.BrandId = pt.BrandId WHERE pt.SubCategoryId = @id ORDER BY pt.Name ASC";
            else if (filter == "2")
                query = "SELECT pt.*, bt.Brand FROM ProducatTbl pt INNER JOIN BrandTbl bt ON bt.BrandId = pt.BrandId WHERE pt.SubCategoryId = @id ORDER BY pt.Name DESC";
            else if (filter == "3")
                query = "SELECT pt.*, bt.Brand FROM ProducatTbl pt INNER JOIN BrandTbl bt ON bt.BrandId = pt.BrandId WHERE ISNUMERIC(pt.Price) = 1 AND pt.SubCategoryId = @id ORDER BY CAST(pt.Price AS FLOAT) ASC";
            else if (filter == "4")
                query = "SELECT pt.*, bt.Brand FROM ProducatTbl pt INNER JOIN BrandTbl bt ON bt.BrandId = pt.BrandId WHERE ISNUMERIC(pt.Price) = 1 AND pt.SubCategoryId = @id ORDER BY CAST(pt.Price AS FLOAT) DESC";
            else
                query = "SELECT pt.*, bt.Brand FROM ProducatTbl pt INNER JOIN BrandTbl bt ON bt.BrandId = pt.BrandId WHERE pt.SubCategoryId = @id";

            cmd.Parameters.AddWithValue("@id", id);
        }
        else if (Request.QueryString["CategoryId"] != null)
        {
            string id = Request.QueryString["CategoryId"].ToString();
            if (filter == "1")
                query = "SELECT pt.*, bt.Brand FROM ProducatTbl pt INNER JOIN BrandTbl bt ON bt.BrandId = pt.BrandId WHERE pt.CategoryId = @id ORDER BY pt.Name ASC";
            else if (filter == "2")
                query = "SELECT pt.*, bt.Brand FROM ProducatTbl pt INNER JOIN BrandTbl bt ON bt.BrandId = pt.BrandId WHERE pt.CategoryId = @id ORDER BY pt.Name DESC";
            else if (filter == "3")
                query = "SELECT pt.*, bt.Brand FROM ProducatTbl pt INNER JOIN BrandTbl bt ON bt.BrandId = pt.BrandId WHERE ISNUMERIC(pt.Price) = 1 AND pt.CategoryId = @id ORDER BY CAST(pt.Price AS FLOAT) ASC";
            else if (filter == "4")
                query = "SELECT pt.*, bt.Brand FROM ProducatTbl pt INNER JOIN BrandTbl bt ON bt.BrandId = pt.BrandId WHERE ISNUMERIC(pt.Price) = 1 AND pt.CategoryId = @id ORDER BY CAST(pt.Price AS FLOAT) DESC";
            else
                query = "SELECT pt.*, bt.Brand FROM ProducatTbl pt INNER JOIN BrandTbl bt ON bt.BrandId = pt.BrandId WHERE pt.CategoryId = @id";

            cmd.Parameters.AddWithValue("@id", id);
        }
        else
        {
            if (filter == "1")
                query = "SELECT pt.*, bt.Brand FROM ProducatTbl pt INNER JOIN BrandTbl bt ON bt.BrandId = pt.BrandId ORDER BY pt.Name ASC";
            else if (filter == "2")
                query = "SELECT pt.*, bt.Brand FROM ProducatTbl pt INNER JOIN BrandTbl bt ON bt.BrandId = pt.BrandId ORDER BY pt.Name DESC";
            else if (filter == "3")
                query = "SELECT pt.*, bt.Brand FROM ProducatTbl pt INNER JOIN BrandTbl bt ON bt.BrandId = pt.BrandId WHERE ISNUMERIC(pt.Price) = 1 ORDER BY CAST(pt.Price AS FLOAT) ASC";
            else if (filter == "4")
                query = "SELECT pt.*, bt.Brand FROM ProducatTbl pt INNER JOIN BrandTbl bt ON bt.BrandId = pt.BrandId WHERE ISNUMERIC(pt.Price) = 1 ORDER BY CAST(pt.Price AS FLOAT) DESC";
            else
                query = "SELECT pt.*, bt.Brand FROM ProducatTbl pt INNER JOIN BrandTbl bt ON bt.BrandId = pt.BrandId";
        }

        cmd.CommandText = query;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        rptProduct.DataSource = ds;
        rptProduct.DataBind();
        con.Close();
    }

    void price()
    {
        MyCon();
        cmd = new SqlCommand("SELECT (SELECT MAX(Price) FROM ProducatTbl) AS MaxPrice, (SELECT MIN(Price) FROM ProducatTbl) AS MinPrice", con);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string PriceMinValue = ds.Tables[0].Rows[0]["MinPrice"].ToString();
            string PriceMaxValue = ds.Tables[0].Rows[0]["MaxPrice"].ToString();
            minprice.Text = PriceMinValue;
            maxprice.Text = PriceMaxValue;

        }
        con.Close();
    }
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            price();
            //BindProducts();

            if (Request.QueryString["ThirdCategoryId"] != null)
            {
                thirdcategorydata();

            }
            else if (Request.QueryString["SubCategoryId"] != null)
            {
                subcategorydata();
                ThirdCategory.Visible = true;
                ThirdCatFill();
            }
            else if (Request.QueryString["CategoryId"] != null)
            {
                categorydata();
                SubCategory.Visible = true;
                SubCatFill();
                ThirdCatFill();

            }
            else
            {
                BrandData();
            }
        }

    }


    protected void dropFillter_SelectedIndexChanged(object sender, EventArgs e)
    {
        filter();
    }



    protected void btnFilterPrice_Click(object sender, EventArgs e)
    {

        MyCon();

        string PriceMinValue = minprice.Text;
        string PriceMaxValue = maxprice.Text;

        string query = "";
        cmd = new SqlCommand();
        cmd.Connection = con;

        if (Request.QueryString["ThirdCategoryId"] != null)
        {
            string thirdCatId = Request.QueryString["ThirdCategoryId"].ToString();
            query = @"SELECT pt.*, bt.Brand 
                  FROM ProducatTbl pt 
                  INNER JOIN BrandTbl bt ON bt.BrandId = pt.BrandId 
                  WHERE pt.ThirdCategoryId = @tid 
                  AND pt.Price >= @min AND pt.Price <= @max 
                  ORDER BY CAST(pt.Price AS FLOAT) ASC";
            cmd.Parameters.AddWithValue("@tid", thirdCatId);
        }

        else if (Request.QueryString["SubCategoryId"] != null)
        {
            string subCatId = Request.QueryString["SubCategoryId"].ToString();
            query = @"SELECT pt.*, bt.Brand 
                  FROM ProducatTbl pt 
                  INNER JOIN BrandTbl bt ON bt.BrandId = pt.BrandId 
                  WHERE pt.SubCategoryId = @sid 
                  AND pt.Price >= @min AND pt.Price <= @max 
                  ORDER BY CAST(pt.Price AS FLOAT) ASC";
            cmd.Parameters.AddWithValue("@sid", subCatId);
        }

        else if (Request.QueryString["CategoryId"] != null)
        {
            string catId = Request.QueryString["CategoryId"].ToString();
            query = @"SELECT pt.*, bt.Brand 
                  FROM ProducatTbl pt 
                  INNER JOIN BrandTbl bt ON bt.BrandId = pt.BrandId 
                  WHERE pt.CategoryId = @cid 
                  AND pt.Price >= @min AND pt.Price <= @max 
                  ORDER BY CAST(pt.Price AS FLOAT) ASC";
            cmd.Parameters.AddWithValue("@cid", catId);
        }
        else
        {
            
            query = @"SELECT pt.*, bt.Brand 
                  FROM ProducatTbl pt 
                  INNER JOIN BrandTbl bt ON bt.BrandId = pt.BrandId 
                  WHERE pt.Price >= @min AND pt.Price <= @max 
                  ORDER BY CAST(pt.Price AS FLOAT) ASC";
        }

 
        cmd.CommandText = query;
        cmd.Parameters.AddWithValue("@min", PriceMinValue);
        cmd.Parameters.AddWithValue("@max", PriceMaxValue);

        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);

        rptProduct.DataSource = ds;
        rptProduct.DataBind();
        con.Close();

    }
}




