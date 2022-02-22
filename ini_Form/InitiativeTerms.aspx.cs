using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data;

public partial class ini_Form_InitiativeTerms : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection();
    SqlConnection con = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["terms"] != null)
            {
                pnlTerms.Visible = true;
                if (Session["userid"] != null)
                {
                    bool val = checkApplied();
                    if (val)
                    {
                        Response.Redirect("initiativeForm.aspx", true);
                    }
                    else
                    {

                    }
                }
                else
                    Response.Redirect("../User/Login.aspx", true);



            }
            else
            {
                Session["terms"] = null;
            }

        }
    }
    protected void btnterm_Click(object sender, EventArgs e)
    {
        if (ChckTerm.Checked == true)
        {

            Session["terms"] = "Checked";
            if (Session["userid"] != null)
            {
                bool val = checkApplied();
                if (val)
                {
                    Response.Redirect("initiativeForm.aspx", true);
                }
                else
                {

                }
            }
            else
                Response.Redirect("../User/Login.aspx", true);

        }

    }
    public void SQLConnection()
    {
        General gm = new General();
        cnn.ConnectionString = gm.ConnectionString2();
        cnn.Open();
    }
    private Boolean checkApplied()
    {

        SQLConnection();
        string id = userid();
        SqlCommand com1 = new SqlCommand("checkInitiativeVersionPermission", cnn);
        com1.CommandType = CommandType.StoredProcedure;
        com1.Parameters.AddWithValue("@PID", SqlDbType.Int).Value = id;
        var returnParameter = com1.Parameters.Add("@nstatus", SqlDbType.NVarChar);
        returnParameter.Direction = ParameterDirection.Output;
        returnParameter.Size = 100;
        com1.ExecuteNonQuery();
        cnn.Close();
        if (!com1.Parameters["@nstatus"].Value.Equals(""))
        {
            string message = (string)com1.Parameters["@nstatus"].Value;

            if (message.Equals("1"))
            {
                alertApplied.Visible = true;
                pnlTerms.Visible = false;
                return false;

            }
            else
            {

                return true;

            }
        }
        return true;

    }
    private Boolean checkAge()
    {

        general_fn gfn = new general_fn();
        string id = userid();
        int age = gfn.checkAge(id.ToString());
        if (age == 1)
        {
            pnlTerms.Visible = true;
            return true;

        }
        else
        {
            alertAge.Visible = true;
            pnlTerms.Visible = false;

            return false;
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
}