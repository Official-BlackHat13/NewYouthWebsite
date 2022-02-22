using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class User_ResetNewPassword : System.Web.UI.Page
{
    protected SqlCommand cmd;
    protected SqlConnection con, cnn;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userid"] != null)
            {
                Response.Redirect("user_Profile.aspx");
            }
        }
    }
    protected void btnUserLogin_Clicked(object sender, EventArgs e)
    {
        try
        {
            if ((!txtEmail.Text.Equals("")) && (!txtPassowrd.Text.Equals("")))
            {
                General gm = new General();
                SqlConnection cnn = new SqlConnection();
                cnn.ConnectionString = gm.ConnectionString();

                cnn.Open();
                string EncID = string.Empty;
                SqlCommand comand = new SqlCommand("UserResetPwd", cnn);
                comand.CommandType = CommandType.StoredProcedure;
                comand.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtEmail.Text.Replace("'", ""));
                comand.Parameters.AddWithValue("@pwd", SqlDbType.NVarChar).Value = txtPassowrd.Text.Trim();
                comand.Parameters.AddWithValue("@otp", SqlDbType.NVarChar).Value = txtOTP.Text.Trim();
                comand.Parameters.Add("@res", SqlDbType.Int, 100).Direction = ParameterDirection.Output;

                comand.Connection = cnn;
                comand.ExecuteNonQuery();
                string val = comand.Parameters["@res"].Value.ToString();
                cnn.Close();
                
                int result = int.Parse(comand.Parameters["@res"].Value.ToString());

                if (result.Equals(10))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('OTP is wrong');</script>", false);
                }
                else if (result.Equals(1))
                {
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Email does not exists');</script>", false);
                }
            }           
        }
        catch (IndexOutOfRangeException ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Incorrect UserName/Password Combination');</script>", false);

        }

    }
   
}
