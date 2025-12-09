using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;

public partial class Admin_SpecificationsCreate : System.Web.UI.Page
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
    
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            if (Request.QueryString["Edit"] != null)
            {
               
                string id = Request.QueryString["Edit"].ToString();
                mycon();
                cmd = new SqlCommand("Select * from SpecificationsTbl Where SpecificationsId = @SpeciId", con);
                cmd.Parameters.AddWithValue("@SpeciId", id);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtSpecification.Text = ds.Tables[0].Rows[0]["SpecificationName"].ToString();
                    DropSpecificationtype.SelectedValue = ds.Tables[0].Rows[0]["SpecificationType"].ToString();
                    DropSpecificationStatus.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();

                }
                con.Close();
                con.Dispose();
                da.Dispose();
                ds.Dispose();
                cmd.Dispose();
            }
        }
    }
    protected void btnSpecificationSave_Click(object sender, EventArgs e)
    {
        mycon();
        cmd = new SqlCommand("select * from  SpecificationsTbl where SpecificationName=@SpeciName", con);
        cmd.Parameters.AddWithValue("@SpeciName", txtSpecification.Text);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('This SpecificationName All Ready Exit')</script>");
        }
        else
        {
            //Update Code
            if (Request.QueryString["Edit"] != null)
            {
                string id = Request.QueryString["Edit"].ToString();
                cmd = new SqlCommand("UPDATE SpecificationsTbl SET SpecificationName = @SpecName, SpecificationType = @SpecType , Status = @Sta, EntryDate = @date WHERE SpecificationsId = @SpeciId", con);
                cmd.Parameters.AddWithValue("@SpecName", txtSpecification.Text);
                cmd.Parameters.AddWithValue("@SpecType", DropSpecificationtype.Text);
                cmd.Parameters.AddWithValue("@Sta", DropSpecificationStatus.Text);
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@SpeciId", id);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Specification Updated successfully.')</script>");
            }
            //Insert code
            else
            {
                cmd = new SqlCommand("Insert into SpecificationsTbl Values(@SpeciName,@SpeciType,@status,@date)", con);
                cmd.Parameters.AddWithValue("@SpeciName", txtSpecification.Text);
                cmd.Parameters.AddWithValue("@SpeciType", DropSpecificationtype.Text);
                cmd.Parameters.AddWithValue("@status", DropSpecificationStatus.Text);
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Successfully Specifications Add. ')</script>");
                txtSpecification.Text = "";
                DropSpecificationtype.Text = "";
                DropSpecificationStatus.Text = "";
            }
        }
        con.Close();

    }
    
}