using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Please Add This 2 Library For SQL Database
using System.Data;
using System.Data.SqlClient;

public partial class Admin_SpecificationPage : System.Web.UI.Page
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
        cmd = new SqlCommand("SELECT * FROM SpecificationsTbl", con);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        ProdDropSpecificationtype.DataSource = ds;
        ProdDropSpecificationtype.DataTextField = "SpecificationName";
        ProdDropSpecificationtype.DataValueField = "SpecificationsId";
        ProdDropSpecificationtype.DataBind();
        con.Close();

    }
    void Option()
    {
        mycon();
        cmd = new SqlCommand("Select * From SpecificationsOptionTbl where  SpecificationsId =@SpecId", con);
        cmd.Parameters.AddWithValue("@SpecId", ProdDropSpecificationtype.Text);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        DropSpeficationsOption.DataSource = ds;
        DropSpeficationsOption.DataTextField = "Value";
        DropSpeficationsOption.DataValueField = "SpecificationsOptionId";
        DropSpeficationsOption.DataBind();
        con.Close();
    }
   
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            specificationfill();
            if (Request.QueryString["EditSpe"] != null)
            {
                string id = Request.QueryString["EditSpe"].ToString();
                mycon();
                cmd = new SqlCommand("Select * from ProductSpecificationOptionTbl Where ProductSpecificationOptionId=@ProdSpecid", con);
                cmd.Parameters.AddWithValue("@ProdSpecid", id);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ProdDropSpecificationtype.SelectedValue = ds.Tables[0].Rows[0]["SpecificationsId"].ToString();
                    DropSpeficationsOption.SelectedValue = ds.Tables[0].Rows[0]["Specifications"].ToString();
                    txtSpecification.Text = ds.Tables[0].Rows[0]["Specifications"].ToString();
                    DropProdSpeciStatus.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();


                }
                con.Close();
                con.Dispose();
                da.Dispose();
                ds.Dispose();
                cmd.Dispose();
            }
        }
    }
    protected void ProdDropSpecificationtype_SelectedIndexChanged(object sender, EventArgs e)
    {

        Option();
        mycon();
        cmd = new SqlCommand("select * from SpecificationsTbl where SpecificationType='Options' and SpecificationsId=@specid", con);
        cmd.Parameters.AddWithValue("@specid", ProdDropSpecificationtype.Text);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            SpeciOption.Visible = true;
            SpeciText.Visible = false;
        }
        else
        {
            SpeciOption.Visible = false;
            SpeciText.Visible = true;
        }
        con.Close();
    }
    protected void btnProdSpecificationSave_Click(object sender, EventArgs e)
    {
        mycon();
        cmd = new SqlCommand("select * from  ProductSpecificationOptionTbl where Specifications=@Speci", con);
        cmd.Parameters.AddWithValue("@Speci", txtSpecification.Text);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('This Producat Name All Ready Exit')</script>");
        }
        else
        {
            //Update Code 
            if (Request.QueryString["EditSpe"] != null)
            {
                string id = Request.QueryString["EditSpe"].ToString();
                cmd = new SqlCommand("Update ProductSpecificationOptionTbl SET ProductId=@pid,SpecificationsId=@sid,SpecificationOptionId=@soid,Specifications=@spe,Status=@stat,EntryDate=@date WHERE ProductSpecificationOptionId = @PsOid", con);
                cmd.Parameters.AddWithValue("@pid", Request.QueryString["ProductId"].ToString());
                cmd.Parameters.AddWithValue("@sid", ProdDropSpecificationtype.Text);
                cmd.Parameters.AddWithValue("@soid", DropSpeficationsOption.Text);
                cmd.Parameters.AddWithValue("@spe", txtSpecification.Text);
                cmd.Parameters.AddWithValue("@stat", DropProdSpeciStatus.Text);
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@PsOid", id);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Successfully Specification Options  Update Add. ')</script>");
            }
            //Insert Code
            else
            {
                cmd = new SqlCommand("Insert into ProductSpecificationOptionTbl Values(@proid,@SpecType,@SpecOption,@SpecText,@Status,@Date)", con);
                cmd.Parameters.AddWithValue("@proid", Request.QueryString["ProductId"].ToString());
                cmd.Parameters.AddWithValue("@SpecType", ProdDropSpecificationtype.Text);
                cmd.Parameters.AddWithValue("@SpecOption", DropSpeficationsOption.Text);
                cmd.Parameters.AddWithValue("@SpecText", txtSpecification.Text);
                cmd.Parameters.AddWithValue("@Status", DropProdSpeciStatus.Text);
                cmd.Parameters.AddWithValue("@Date", System.DateTime.Now);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Successfully Specification Options Add. ')</script>");
            }
        }
        con.Close();       
    }
}