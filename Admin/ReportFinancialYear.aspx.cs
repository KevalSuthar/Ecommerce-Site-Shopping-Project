using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;
public partial class Admin_ReportFinancialYear : System.Web.UI.Page
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
    void FillDropdownFinancialYear()
    {
        Int32 Year = System.DateTime.Now.Year;
        Int32 Month = System.DateTime.Now.Month;

        int CurentYear = Month > 3 ? Year +1 : Year;
        int NeaxtYear = Month > 3 ? Year : Year - 1;

        int startYear = 0;
        int privYear = 0;

        if (CurentYear > NeaxtYear)
        {
            startYear = NeaxtYear + 1;
            privYear = CurentYear + 1;
        }
        else
        {
            startYear = NeaxtYear - 1;
            privYear = CurentYear - 1;
        }
        for (int i = 2020; i <= System.DateTime.Now.Year; i++)
        {
            startYear = startYear - 1;
            privYear = privYear - 1;    

            DropdownReportFinancialYear.Items.Add(startYear.ToString() + "-" + (privYear).ToString());
        }
    }

    void FillReportFInancilYearGrideView()
    {
        string[] year = DropdownReportFinancialYear.Text.Split('-');

        mycon();
        cmd = new SqlCommand("SELECT O.*, U.Name FROM OrderTbl O INNER JOIN UserTbl U ON O.UserId = U.UserId WHERE CAST(O.EntryDate AS date) BETWEEN CAST(@startdate AS date) AND CAST(@enddate AS date)", con);
        cmd.Parameters.AddWithValue("@startdate", year[0] + "-04-01");
        cmd.Parameters.AddWithValue("@enddate", year[1] + "-03-31");
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        ReportYearsGridView.DataSource = ds;
        ReportYearsGridView.DataBind();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDropdownFinancialYear();
            FillReportFInancilYearGrideView();
        }
    }
    protected void BtnReportYear_Click(object sender, EventArgs e)
    {
        FillReportFInancilYearGrideView();

    }
}