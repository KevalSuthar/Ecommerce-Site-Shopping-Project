using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;
public partial class Admin_ReportMonths : System.Web.UI.Page
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
    void FillReportMonthsGridview()
    {
        mycon();

        cmd = new SqlCommand("SELECT O.*, U.Name FROM OrderTbl O INNER JOIN UserTbl U ON O.UserId = U.UserId WHERE CONVERT(varchar(7), O.EntryDate, 120) = @EntryDate", con);
        cmd.Parameters.AddWithValue("@EntryDate", TxtReportMonths.Text);
        da = new SqlDataAdapter(cmd);   
        ds = new DataSet();
        da.Fill(ds);
        ReportMonthsGridView.DataSource = ds;
        ReportMonthsGridView.DataBind();
        con.Close();
        cmd.Dispose();
        con.Dispose();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
      
            string currentMonth = DateTime.Now.ToString("yyyy-MM");
            TxtReportMonths.Text = currentMonth;

            FillReportMonthsGridview();
        }
    }
    protected void BtnReportMonths_Click(object sender, EventArgs e)
    {
        FillReportMonthsGridview();
    }
}