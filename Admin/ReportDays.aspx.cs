using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;

public partial class Admin_ReportDays : System.Web.UI.Page
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

    void FillReportDaysGridview()
    {
        mycon();

        cmd = new SqlCommand("SELECT O.*, U.Name FROM OrderTbl O INNER JOIN UserTbl U ON O.UserId = U.UserId WHERE CONVERT(date, O.EntryDate) = @EntryDate ", con);
        cmd.Parameters.AddWithValue("@EntryDate", TextBox1.Text);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        ReportDaysGridView.DataSource = ds;
        ReportDaysGridView.DataBind();
        con.Close();
        cmd.Dispose();
        con.Dispose();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnReportDays_Click(object sender, EventArgs e)
    {
        FillReportDaysGridview();
        //Response.Write("<script>alert('Successfully . ')</script>");
    }
}