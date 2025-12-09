using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;

public partial class Admin_ThirdCategoryManage : System.Web.UI.Page
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
        cmd = new SqlCommand("Select tt.*,st.SubCategory,ct.Category From ThirdCategoryTbl as tt inner join	SubCategoryTbl as st on tt.SubCategoryId=st.SubCategoryId inner join CategoryTbl as ct on tt.CategoryId=ct.CategoryId", con);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        ThirdCateView1.DataSource = ds;
        ThirdCateView1.DataBind();
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
    protected void ThirdCateView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            string Id = e.CommandArgument.ToString();
            mycon();
            cmd = new SqlCommand("delete  ThirdCategoryTbl where ThirdCategoryId = @ThirdCateId", con);
            cmd.Parameters.AddWithValue("@ThirdCateId", Id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            fillcat();
            con.Close();
        }
    }
}