using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;
public partial class Admin_ProductManage : System.Web.UI.Page
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
    void fillcat()
    {
        mycon();
        cmd = new SqlCommand("select * from ProducatTbl as pt inner join CategoryTbl as ct on pt.CategoryId = ct.CategoryId  inner join SubCategoryTbl as st on pt.SubCategoryId= st.SubCategoryId inner join ThirdCategoryTbl as tt on pt.ThirdCategoryId = tt.ThirdCategoryId inner join BrandTbl as bt on pt.BrandId =bt.BrandId", con);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        ProductGrid.DataSource = ds;
        ProductGrid.DataBind();
        con.Close();
        con.Dispose();
        da.Dispose();
        ds.Dispose();
        cmd.Dispose();
    }
 
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            fillcat();

        }
 

    }
    protected void ProductGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            string Id = e.CommandArgument.ToString();
            mycon();
            cmd = new SqlCommand("delete ProducatTbl where ProductId = @ProdId", con);
            cmd.Parameters.AddWithValue("@ProdId", Id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            fillcat();
            con.Close();
        }
    }
}