using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;

public partial class Admin_SubCategoryManage : System.Web.UI.Page
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
        cmd = new SqlCommand("Select st.* , ct.Category  From SubCategoryTbl as st inner join CategoryTbl as ct on st.CategoryId=ct.CategoryId", con);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        SubCategoryView1.DataSource = ds;
        SubCategoryView1.DataBind();
        con.Close();
        con.Dispose();
        da.Dispose();
        ds.Dispose();
        cmd.Dispose();
    }
    protected void Page_Load(object sender, EventArgs e)
    {


        fillcat();
    }
    protected void SubCategoryView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            string Id = e.CommandArgument.ToString();

            mycon();
            cmd = new SqlCommand("delete  SubCategoryTbl where SubCategoryId = @SubCateId", con);
            cmd.Parameters.AddWithValue("@SubCateId", Id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            fillcat();
            con.Close();
        }
    }
}