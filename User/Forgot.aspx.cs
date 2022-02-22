using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
public partial class User_Forgot : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Clicked(object sender, EventArgs e)
    {

        string uniqueCode = string.Empty;
        if (!txtEmail.Text.Equals(""))
        {
            try
            {
                string type = "UserInfo";
                string value = string.Empty;
                General gm = new General();
                SqlConnection cnn = new SqlConnection();
                cnn.ConnectionString = gm.ConnectionString();
                cnn.Open();
                //assigning a  this value with unique id .
                value = "22";
                SqlCommand comand = new SqlCommand("forgotPasswordCheck", cnn);
                comand.CommandType = CommandType.StoredProcedure;
                comand.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtEmail.Text.Replace("'", ""));
                comand.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = type;


                comand.Connection = cnn;

                comand.ExecuteNonQuery();

                cnn.Close();
                SqlDataAdapter sda = new SqlDataAdapter(comand);

                DataTable result = new DataTable();
                sda.Fill(result);
                if (result.Rows.Count > 0)
                {
                    if (string.Equals(txtEmail.Text.Trim(), result.Rows[0]["email"].ToString().Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        string email = result.Rows[0]["email"].ToString().Trim();
                        string id = result.Rows[0]["id"].ToString().Trim();
                        uniqueCode = Convert.ToString(System.Guid.NewGuid());

                        try
                        {

                            SqlCommand cmd = new SqlCommand("tempInsert", cnn);

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@userid", SqlDbType.Int).Value = id;
                            cmd.Parameters.AddWithValue("@uniqueid", SqlDbType.NVarChar).Value = value + uniqueCode;
                            cmd.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = Server.HtmlEncode(email);
                            cmd.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = type;
                            cmd.Parameters.AddWithValue("@action", SqlDbType.NVarChar).Value = "insert";
                            cmd.Connection = cnn;
                            cnn.Open();
                            cmd.ExecuteNonQuery();
                            cnn.Close();
                            emailFunction(value + uniqueCode, txtEmail.Text.Replace("'", ""));
                        }

                        catch (Exception ex)
                        {
                            Response.Write(ex.Message);

                        }

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('This is not a valid email ');</script>", false);
                }

            }
            catch (IndexOutOfRangeException ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Incorrect UserName');</script>", false);

            }


        }


    }
    private void emailFunction(string unicode, string email)
    {
        general_fn gfn = new general_fn();

        int i = gfn.AgencyEmail(email, unicode, "user");
        if (i == 0)
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Password is send in your E-mail id Please check');window.location.href = '../index_AR.aspx'", true);
        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please try Later');window.location.href = '../index_AR.aspx'", true);
    }


    protected void txtCivil_TextChanged(object sender, EventArgs e)
    {


        lblCivil.Visible = false;


        string civil_id = Server.HtmlEncode(txtCivil.Text);
        bool num_result = IsDigitsOnly(civil_id);
        if ((num_result == true) && (civil_id.Length == 12))
        {

            string civil = txtCivil.Text.ToString();


            int c1 = int.Parse(civil.Substring(0, 1));
            int c2 = int.Parse(civil.Substring(1, 1));
            int c3 = int.Parse(civil.Substring(2, 1));
            int c4 = int.Parse(civil.Substring(3, 1));
            int c5 = int.Parse(civil.Substring(4, 1));
            int c6 = int.Parse(civil.Substring(5, 1));
            int c7 = int.Parse(civil.Substring(6, 1));
            int c8 = int.Parse(civil.Substring(7, 1));
            int c9 = int.Parse(civil.Substring(8, 1));
            int c10 = int.Parse(civil.Substring(9, 1));
            int c11 = int.Parse(civil.Substring(10, 1));
            int c12 = int.Parse(civil.Substring(11, 1));

            int vresult = ((c1 * 2) + (c2) + (c3 * 6) + (c4 * 3) + (c5 * 7) + (c6 * 9) + (c7 * 10) + (c8 * 5) + (c9 * 8) + (c10 * 4) + (c11 * 2));
            double vresult1 = (vresult / 11);
            double tvresult1 = Math.Floor(vresult1);
            double tvresult2 = (tvresult1 * 11);
            double totvresult = (vresult - tvresult2);
            double alltotvresult = (11 - totvresult);
            if (alltotvresult == c12)
            {
                txtCivil.Text = civil;
                lblCivil.Visible = false;

            }
            else
            {
                txtCivil.Text = "";
                lblCivil.Visible = true;
            }



        }
        else
        {

            RegularExpressionValidator1.Validate();

        }

    }
    bool IsDigitsOnly(string str)
    {
        foreach (char c in str)
        {
            if (c < '0' || c > '9')
                return false;
        }

        return true;
    }


    protected void BtClick_Click(object sender, EventArgs e)
    {
        lblGmail.Text = "";
        lblGmail.Visible = true;
        if ((!txtCivil.Text.Equals("")))
        {
            General gm = new General();
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = gm.ConnectionString();

            cnn.Open();
            string EncID = string.Empty; ;
            SqlCommand comand = new SqlCommand("spCheckCivilID", cnn);
            comand.CommandType = CommandType.StoredProcedure;
            comand.Parameters.AddWithValue("@civil", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtCivil.Text.Replace("'", ""));
            comand.Connection = cnn;
            comand.ExecuteNonQuery();
            cnn.Close();
            SqlDataAdapter sda = new SqlDataAdapter(comand);
            DataTable result = new DataTable();
            sda.Fill(result);
            string FinaText = string.Empty;
            if (result.Rows.Count > 0)
            {

                if (result.Rows[0]["civil"].ToString().Trim().Equals(txtCivil.Text))
                {

                    string data = result.Rows[0]["email"].ToString().Trim();
                    string[] List = data.Split(new Char[] { '@' });
                    char[] charArr = List[0].ToCharArray();

                    FinaText = charArr[0].ToString() + charArr[1].ToString();
                    string test = string.Empty;
                    for (int i = 0; i < charArr.Length - 2; i++)
                    {

                        test = test + "*";
                    }


                    lblGmail.Text = data;    //FinaText + test + "@" + List[1];
                    lblGmail.Visible = true;
                }

            }
            else
            {
                lblGmail.Text = "الرقم المدني غير موجود في النظام";
                lblGmail.Visible = true;
            }
        }
    }
    protected void lblEmail_Click(object sender, EventArgs e)
    {
        pnlReset.Visible = true;
        pnlLogin.Visible = false;
    }
    protected void lnkPassword_Click(object sender, EventArgs e)
    {
        pnlReset.Visible = false;
        pnlLogin.Visible = true;
    }
}