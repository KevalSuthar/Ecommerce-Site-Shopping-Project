using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;

public partial class Admin_OptionCreate : System.Web.UI.Page
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
    void specificationfill()
    {
        mycon();
        cmd = new SqlCommand("SELECT * FROM SpecificationsTbl WHERE SpecificationType = 'Options'", con);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        OptionFormDropSpeicification.DataSource = ds;
        OptionFormDropSpeicification.DataTextField = "SpecificationName";
        OptionFormDropSpeicification.DataValueField = "SpecificationsId";
        OptionFormDropSpeicification.DataBind();
        OptionFormDropSpeicification.Items.Insert(0, "-------Select Specification-------");
        OptionFormDropSpeicification.Items[0].Value = "";
        con.Close();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            specificationfill();
            if (Request.QueryString["Edit"] != null)
            {
              
                string id = Request.QueryString["Edit"].ToString();
                mycon();
                cmd = new SqlCommand("Select * from SpecificationsOptionTbl Where SpecificationsOptionId=@specoptiid", con);
                cmd.Parameters.AddWithValue("@specoptiid", id);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    OptionFormDropSpeicification.Text = ds.Tables[0].Rows[0]["SpecificationsId"].ToString();
                    txtValue.Text = ds.Tables[0].Rows[0]["Value"].ToString();
                    DropOptionStatus.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();

                }
                con.Close();
            }
        }
    }
    protected void btnOptionSave_Click(object sender, EventArgs e)
    {
        mycon();
        cmd = new SqlCommand("select * from  SpecificationsOptionTbl where Value=@value", con);
        cmd.Parameters.AddWithValue("@value", txtValue.Text);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('This SpecificationsOption Value All Ready Exit')</script>");
        }
        else
        {
            //Update Code
            if (Request.QueryString["Edit"] != null)
            {
                string id = Request.QueryString["Edit"].ToString();
                cmd = new SqlCommand("UPDATE SpecificationsOptionTbl SET SpecificationsId = @specid,Value=@val,Status = @Sta, EntryDate = @date WHERE SpecificationsOptionId = @specoptiid", con);
                cmd.Parameters.AddWithValue("@specid", OptionFormDropSpeicification.Text);
                cmd.Parameters.AddWithValue("@val", txtValue.Text);
                cmd.Parameters.AddWithValue("@Sta", DropOptionStatus.Text);
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@specoptiid", id);

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Successfully Update Option Data Add. ')</script>");
            }
            //Insert code
            else
            {
                cmd = new SqlCommand("Insert into SpecificationsOptionTbl Values(@Specificationoption,@values,@status,@date)", con);
                cmd.Parameters.AddWithValue("@Specificationoption", OptionFormDropSpeicification.Text);
                cmd.Parameters.AddWithValue("@values", txtValue.Text);
                cmd.Parameters.AddWithValue("@status", DropOptionStatus.Text);
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Successfully Option Data Add. ')</script>");
                OptionFormDropSpeicification.SelectedIndex = -1;
                txtValue.Text = "";
                DropOptionStatus.Text = "";
            }
        }
        con.Close();

    }

}