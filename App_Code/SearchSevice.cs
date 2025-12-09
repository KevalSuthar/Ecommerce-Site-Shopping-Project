using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

/// <summary>
/// Summary description for SearchSevice
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class SearchSevice : System.Web.Services.WebService
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;

    void MyCon()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["EcommerceDataBaseConnectionString1"].ToString());
        con.Open();
    }
    public SearchSevice()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public string GetSearchData(string prefix)
    {
        MyCon();
        cmd = new SqlCommand("SELECT Name FROM ProducatTbl WHERE Name LIKE @prefix + '%'", con);
        cmd.Parameters.AddWithValue("@prefix", prefix);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        con.Close();     
        return JsonConvert.SerializeObject(ds.Tables[0]);
    }


}
