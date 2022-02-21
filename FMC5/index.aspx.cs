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

public partial class index : System.Web.UI.Page
{

    SqlConnection cnn = new SqlConnection();
    General gm = new General();

    static string search = "";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Linkfinalsubmit_Click(object sender, EventArgs e)
    {
        //if (Session["userid"] == null)
        //{
        //    Session["page"] = "FMC_Info";
        //    Response.Redirect("../user/login.aspx", false);
        //}
        //else
       // {

            Response.Redirect("Registration.aspx", false);
        //}
    }
}

