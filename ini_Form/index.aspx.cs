using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web.Script.Services;
using System.Text;
using System.Web.Services;
using System.Security.Cryptography;

public partial class ini_Form_index : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection();
    General gm = new General();

    static string search = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        search_results.Visible = false;

        if (!IsPostBack)
        {


            //healthBindRepeater();
            //artBindRepeater();
            //eduBindRepeater();
            //neighBindRepeater();
            //sciBindRepeater();
            //smiesBindRepeater();
            //infoBindRepeater();

        }


    }
    public void SQLConnection()
    {
        cnn.ConnectionString = gm.ConnectionString2();
        cnn.Open();
    }

    private DataTable loadValue(string value)
    {
        DataTable dt = new DataTable();
        SQLConnection();
        string type = value;
        string str = "InitiativeCatagoryLoad";
        SqlCommand com = new SqlCommand(str, cnn);
        com.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adp = new SqlDataAdapter(com);
        com.Parameters.AddWithValue("@action", SqlDbType.NVarChar).Value = type;
        adp.Fill(dt);
        return dt;
    }


    private void healthBindRepeater()
    {
        DataTable dt = loadValue("الصحة و الرىاضة");

        if (dt.Columns.Count > 0)
        {


        }
        dt.Clear();
        cnn.Close();
    }

    private void eduBindRepeater()
    {
        DataTable dt = loadValue("التعليم  و البحوث");
        if (dt.Columns.Count > 0)
        {


        }
        dt.Clear();
        cnn.Close();
    }

    private void artBindRepeater()
    {
        DataTable dt = loadValue("الثقافة و الفنون");
        if (dt.Columns.Count > 0)
        {


        }
        dt.Clear();
        cnn.Close();
    }

    private void infoBindRepeater()
    {
        DataTable dt = loadValue("الاعلام والحملات التوعوية");
        if (dt.Columns.Count > 0)
        {

        }
        dt.Clear();
        cnn.Close();
    }

    private void neighBindRepeater()
    {
        DataTable dt = loadValue("التخطيط العمرانى و تنمية المدن");
        if (dt.Columns.Count > 0)
        {
        }
        dt.Clear();
        cnn.Close();
    }

    private void sciBindRepeater()
    {

        DataTable dt = loadValue("العلوم و التكنلوجيا");
        if (dt.Columns.Count > 0)
        {

        }
        dt.Clear();
        cnn.Close();

    }

    private void smiesBindRepeater()
    {
        DataTable dt = loadValue("المشاريع والصغيرة وريادة الأ عمال");
        if (dt.Columns.Count > 0)
        {

        }
        dt.Clear();
        cnn.Close();

    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        lblError.Visible = false;
        if (Session["userid"] != null)
        {

            if (!s.Text.Equals(""))
            {
                var isValidNumber = Regex.IsMatch(s.Text, @"^\d+$");
                if (isValidNumber)
                {
                    SQLConnection();
                    string user_id = userid();
                    string str = "InitiativeCatagoryLoad";
                    SqlCommand comand = new SqlCommand(str, cnn);
                    comand.CommandType = CommandType.StoredProcedure;
                    comand.Parameters.AddWithValue("@bid", SqlDbType.NVarChar).Value = Server.HtmlEncode(s.Text);
                    comand.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = user_id;
                    comand.Parameters.AddWithValue("@action", "status");

                    comand.ExecuteNonQuery();

                    SqlDataAdapter da = new SqlDataAdapter(comand);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DataTableReader dtr = dt.CreateDataReader();
                    if (dtr.HasRows)
                    {
                        while (dtr.Read())
                        {

                            lblsearch.Text = "حالتك:" + dtr["Status"].ToString();
                            lblsearch.Attributes.Add("Style", "Color:Green");

                        }
                    }
                    else
                    {
                        lblsearch.Text = "لا يوجد سجلات ";
                        lblsearch.Attributes.Add("Style", "Color:Red");
                    }
                    search_results.Visible = true;
                    cnn.Close();
                }

                else
                {
                    search_results.Visible = false;
                    lblError.Text = "يرجى إدخال أرقام";
                    lblError.Visible = true;

                }
            }
            else
            {
                lblError.Text = "مطلوب هذه الخانة";
                lblError.Visible = true;


            }
        }
        else
        {

            lblsearch.Text = "يرجى تسجيل الدخول اولا";
            lblsearch.Attributes.Add("Style", "Color:Red");
            search_results.Visible = true;

        }
    }
    public string userid()
    {
        general_fn gfn = new general_fn();
        string strUserid = Session["userid"].ToString();
        strUserid = gfn.SessionDecrypt(strUserid, SHA512.Create().ToString());
        strUserid = strUserid.Substring(strUserid.IndexOf("&") + 1);
        return strUserid;
    }
    protected void btRegister_Click(object sender, EventArgs e)
    {
        //if (Session["userid"] == null)
        //{
        //    Session["moy_initiative"] = "moy_ini";
        //    var url = String.Format("../User/Login.aspx", false);
        //    Response.Redirect(url, false);
        //}
        //else
        //{
        Session["page"] = "ini_page";
        var url = String.Format("InitiativeTerms.aspx", false);
        Response.Redirect(url, false);

        //}

    }
    protected void lnkedit_Click(object sender, EventArgs e)
    {
        if (Session["userid"] == null)
        {
            Session["page"] = "iniProfile";
            var url = String.Format("../User/Login.aspx", false);
            Response.Redirect(url, false);
        }
        else
        {

            var url = String.Format("Initiative_UserProfile.aspx", false);
            Response.Redirect(url, false);

        }
    }
}

