using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Security.Cryptography;
public partial class thankyou : System.Web.UI.Page
{
    string id = string.Empty;
    general_fn gfn = new general_fn();
    SqlConnection con = new SqlConnection();
    General gm = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["catbutton"] = "";
        if (Session["userid"] == null)
        {

            Response.Redirect("index.aspx", false);
        }
        else
        {

            if (!IsPostBack)
            {


                id = Session["userid"].ToString();
                id = gfn.SessionDecrypt(id, SHA512.Create().ToString());
                id = id.Substring(id.IndexOf("&") + 1);
                string sql = "emailGN";
                SqlCommand qry1 = new SqlCommand(sql, con);
                qry1.CommandType = CommandType.StoredProcedure;
                qry1.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                qry1.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = "User";
                con.ConnectionString = gm.ConnectionString();
                con.Open();
                string email = (string)qry1.ExecuteScalar();

                con.Close();
                if (Session["ini_YPIbid"] != null)
                {
                    //   r_id.Text = Session["ini_YPIbid"].ToString();
                    //need to add text
                    gfn.AgencyEmail(email, "101", "YPIinitiative");
                }

            }
        }
    }
    protected void btback_Click(object sender, EventArgs e)
    {
        Session["ini_bid"] = "";
        Response.Redirect("index.aspx", false);
    }
}