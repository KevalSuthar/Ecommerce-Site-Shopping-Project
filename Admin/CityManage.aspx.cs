using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;
public partial class Admin_CityManage : System.Web.UI.Page
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
   
    void FillGridView()
    {
        mycon();
        cmd = new SqlCommand("select ct.*,countryT.CountryName,st.Name from CityTbl as ct inner Join  CountryTbl as countryT on ct.Countryid = countryT.CountryId inner join StateTbl as st on ct.Stateid = st.StateId", con);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        CityGrid.DataSource = ds;
        CityGrid.DataBind();
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
            
            FillGridView();
        }
    }
    protected void CityGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            string Id = e.CommandArgument.ToString();
            mycon();
            cmd = new SqlCommand("delete  CityTbl where CityId = @CId", con);
            cmd.Parameters.AddWithValue("@CId", Id);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            FillGridView();
            con.Close();
        }
    }
}