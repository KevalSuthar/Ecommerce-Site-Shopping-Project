using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;
public partial class Admin_DashBoard : System.Web.UI.Page
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

    void FillReportEarningToday()
    {
        DateTime today = DateTime.Today;
        mycon();
        cmd = new SqlCommand("select * from OrderTbl where  CONVERT(date,EntryDate) = @EntryDate", con);
        cmd.Parameters.AddWithValue("@EntryDate", today);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Decimal EarningToDayDate = 0;
            int RowCount = ds.Tables[0].Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                EarningToDayDate += Convert.ToDecimal(ds.Tables[0].Rows[i]["TotalAmount"].ToString());
            }

            lblTodayEarnings.Text = EarningToDayDate.ToString();
        }
        con.Close();

    }

    void FillReportOrderToday()
    {
        DateTime today = DateTime.Today;
        mycon();
        cmd = new SqlCommand("SELECT * FROM OrderTbl WHERE CONVERT(date, EntryDate) = @EntryDate", con);
        cmd.Parameters.AddWithValue("@EntryDate", today);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {
            int RowCount = ds.Tables[0].Rows.Count;
            lblTodayOrder.Text = Convert.ToString(RowCount);
        }
        con.Close();
    }

    void FillReportUser()
    {
        DateTime today = DateTime.Today;
        mycon();
        cmd = new SqlCommand("SELECT * FROM UserTbl WHERE CONVERT(date, EntryDate) = @EntryDate", con);
        cmd.Parameters.AddWithValue("@EntryDate", today);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        int userCount = ds.Tables[0].Rows.Count;
        lblTodayUser.Text = userCount.ToString();

        con.Close();
    }

    void MonthFillEarning()
    {
        string Month = DateTime.Today.ToString("yyyy-MM");
        mycon();
        cmd = new SqlCommand("SELECT * FROM OrderTbl WHERE CONVERT(varchar(7), EntryDate, 120) = @EntryDate", con);
        cmd.Parameters.AddWithValue("@EntryDate", Month);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Decimal EarningToDayDate = 0;
            int RowCount = ds.Tables[0].Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                EarningToDayDate += Convert.ToDecimal(ds.Tables[0].Rows[i]["TotalAmount"].ToString());
            }

            lblMonthEarnings.Text = EarningToDayDate.ToString();
        }
        con.Close();
    }

    void MonthFillOrder()
    {
        string month = DateTime.Today.ToString("yyyy-MM");
        mycon();
        cmd = new SqlCommand("SELECT * FROM OrderTbl WHERE CONVERT(varchar(7), EntryDate, 120) = @EntryDate", con);
        cmd.Parameters.AddWithValue("@EntryDate", month);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        int monthOrderCount = ds.Tables[0].Rows.Count;
        lblMonthOrder.Text = monthOrderCount.ToString();

        con.Close();
    }

    void MonthFillOrderUser()
    {
        string month = DateTime.Today.ToString("yyyy-MM");
        mycon();
        cmd = new SqlCommand("SELECT * FROM OrderTbl WHERE CONVERT(varchar(7), EntryDate, 120) = @EntryDate", con);
        cmd.Parameters.AddWithValue("@EntryDate", month);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        int monthOrderCount = ds.Tables[0].Rows.Count;
        lblMonthUser.Text = monthOrderCount.ToString();

        con.Close();
    }

    void YearFillEarning()
    {
        string Year = DateTime.Today.ToString("yyyy");
        mycon();
        cmd = new SqlCommand("SELECT * FROM OrderTbl WHERE YEAR(EntryDate) = YEAR(@EntryDate)", con);
        cmd.Parameters.AddWithValue("@EntryDate", Year);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Decimal EarningToDayDate = 0;
            int RowCount = ds.Tables[0].Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                EarningToDayDate += Convert.ToDecimal(ds.Tables[0].Rows[i]["TotalAmount"].ToString());
            }

            lblYearEarnings.Text = EarningToDayDate.ToString();
        }
        con.Close();
    }

    void YearFillOrder()
    {
        string TodayDate = System.DateTime.Now.ToString("yyyy");
        mycon();
        cmd = new SqlCommand("Select * from OrderTbl where year(EntryDate) = @EntryDate", con);
        cmd.Parameters.AddWithValue("@EntryDate", TodayDate);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int RowCount = ds.Tables[0].Rows.Count;
            lblYearOrder.Text = Convert.ToString(RowCount);

        }
        con.Close();

    }

    void YearFillUser()
    {
        string Year = DateTime.Today.ToString("yyyy");
        mycon();
        cmd = new SqlCommand("SELECT * FROM UserTbl WHERE year(EntryDate) = @EntryDate", con);
        cmd.Parameters.AddWithValue("@EntryDate", Year);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {
            int yearOrderCount = ds.Tables[0].Rows.Count;
            lblYearUser.Text = yearOrderCount.ToString();
        }
        con.Close();
    }


    void FinancialYearFill()
    {
        string ReportFinancialYear = "";
        Int32 Year = System.DateTime.Now.Year;
        Int32 Month = System.DateTime.Now.Month;

        int CurentYear = Month > 3 ? Year + 1 : Year;
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

        startYear = startYear - 1;
        privYear = privYear - 1;

        ReportFinancialYear = startYear.ToString() + "-" + (privYear).ToString();

        string[] year = ReportFinancialYear.Split('-');

        mycon();
        cmd = new SqlCommand("Select * from OrderTbl where CAST(EntryDate as date) BETWEEN cast(@s as date) AND cast (@e as date)", con);
        cmd.Parameters.AddWithValue("@s", year[0] + "-04-01");
        cmd.Parameters.AddWithValue("@e", year[1] + "-03-31");
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Decimal EarningToDayDate = 0;
            int RowCount = ds.Tables[0].Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                EarningToDayDate += Convert.ToDecimal(ds.Tables[0].Rows[i]["TotalAmount"].ToString());

            }
            lblFinYearEarnings.Text = Convert.ToString(EarningToDayDate);
        }
        con.Close();
    }

    void FinancialYearFillOrder()
    {

        string ReportFinancialYear = "";
        Int32 Year = System.DateTime.Now.Year;
        Int32 Month = System.DateTime.Now.Month;

        int CurentYear = Month > 3 ? Year + 1 : Year;
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


        startYear = startYear - 1;
        privYear = privYear - 1;
        ReportFinancialYear = startYear.ToString() + "-" + (privYear).ToString();

        //string TodayDate = System.DateTime.Now.ToString("yyyy");
        string[] year = ReportFinancialYear.Split('-');

        mycon();

        cmd = new SqlCommand("select * from OrderTbl where CAST(EntryDate as date) BETWEEN cast(@s as date) AND cast(@e as date)", con);
        cmd.Parameters.AddWithValue("@s", year[0] + "-04-01");
        cmd.Parameters.AddWithValue("@e", year[1] + "-03-31");
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int RowCount = ds.Tables[0].Rows.Count;
            lblFinYearOrders.Text = Convert.ToString(RowCount);
        }
        con.Close();
    }

    void FinancialYearFillUser()
    {
        string ReportFinancialYear = "";
        Int32 Year = System.DateTime.Now.Year;
        Int32 Month = System.DateTime.Now.Month;

        int CurentYear = Month > 3 ? Year + 1 : Year;
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


        startYear = startYear - 1;
        privYear = privYear - 1;

       
        ReportFinancialYear = startYear.ToString() + "-" + (privYear).ToString();

       
        string[] year = ReportFinancialYear.Split('-');

        mycon();

        cmd = new SqlCommand("select * from UserTbl where CAST(EntryDate as date) BETWEEN cast(@s as date) AND cast(@e as date)", con);
        cmd.Parameters.AddWithValue("@s", year[0] + "-04-01");
        cmd.Parameters.AddWithValue("@e", year[1] + "-03-31");
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int RowCount = ds.Tables[0].Rows.Count;
            lblFinYearUsers.Text = Convert.ToString(RowCount);
        }
        con.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillReportEarningToday();
            FillReportOrderToday();
            FillReportUser();

            MonthFillEarning();
            MonthFillOrder();
            MonthFillOrderUser();

            YearFillEarning();
            YearFillOrder();
            YearFillUser();

            FinancialYearFill();
            FinancialYearFillOrder();
            FinancialYearFillUser();
            //if (Session["login"] == null)
            //{
              
            //    Response.Redirect("AdminLogin.aspx?Page=DashBoard");
            //}
          
        }

    }
}