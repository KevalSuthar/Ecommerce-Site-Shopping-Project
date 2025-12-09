using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Order : System.Web.UI.Page
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
    void FillOrderGridView()
    {

        mycon();
        cmd = new SqlCommand("Select ot.*,pdt.ProductId, pdt.Name,pdt.Price,odt.Quantity,odt.Total From OrderTbl  as ot Inner Join OrderDetailTbl as odt on ot.OrderId = odt.OrderId Inner Join ProducatTbl as pdt on odt.ProductId = pdt.ProductId ", con);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        AdminOrderPageGridView.DataSource = ds;
        AdminOrderPageGridView.DataBind();
        con.Close();
        cmd.Dispose();
        con.Dispose();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillOrderGridView();

        }
    }
}