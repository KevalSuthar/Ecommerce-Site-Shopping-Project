using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;
public partial class Admin_ReportYear : System.Web.UI.Page
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
    void FillDropdownReportYear()
    {
        mycon();
        cmd = new SqlCommand("SELECT DISTINCT YEAR(EntryDate) AS YearValue FROM OrderTbl ORDER BY YearValue DESC", con);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DropdownReportYear.Items.Insert(0, new ListItem("-- Select Year --", ""));

            string YearValue = "";
            int count = ds.Tables[0].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                YearValue = ds.Tables[0].Rows[i]["YearValue"].ToString();
                DropdownReportYear.Items.Add(YearValue);

            }
        }
    }
    void FillReportYearsGridview()
    {
        mycon();

        cmd = new SqlCommand("SELECT O.*, U.Name FROM OrderTbl O INNER JOIN UserTbl U ON O.UserId = U.UserId WHERE YEAR(O.EntryDate) = YEAR(@EntryDate)", con);
        cmd.Parameters.AddWithValue("@EntryDate", DropdownReportYear.Text);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        ReportYearsGridView.DataSource = ds;
        ReportYearsGridView.DataBind();
        con.Close();
        cmd.Dispose();
        con.Dispose();



    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDropdownReportYear(); 
            string currentYear = DateTime.Now.ToString("yyyy");     
            if (DropdownReportYear.Items.FindByValue(currentYear) != null)
            {
                DropdownReportYear.SelectedValue = currentYear;               
                FillReportYearsGridview();
            }
        }
    }
    protected void BtnReportYear_Click(object sender, EventArgs e)
    {
        FillReportYearsGridview();
    }
}