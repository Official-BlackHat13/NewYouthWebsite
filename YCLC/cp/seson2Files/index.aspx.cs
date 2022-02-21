using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Net;

public partial class youth_NEW_ADMIN_index : System.Web.UI.Page
{
    protected SqlCommand cmd;
    protected SqlConnection con, cnn;
   
    General gm = new General();  
    protected void Page_Load(object sender, EventArgs e)
    {


    }
    public void SQLConnection()
    {
        con = new SqlConnection();
        con.ConnectionString = gm.myConnectionString();
        con.Open();
      
    }
    private string Encrypt(string clearText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }
    protected void btlogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (!txtusername.Text.Equals("") & (!txtpassword.Text.Equals("")))
            {

                // conn.Open();
                SQLConnection();
                string pwd = string.Empty;
                string mobile = string.Empty;
                string col1Value = string.Empty;
                string id = string.Empty;
                string mya_usertype = string.Empty;
                SqlCommand cmd1 = new SqlCommand();
                string sql1 = string.Empty;
                DateTime date1 = DateTime.Now; // Or whatever
                string time = date1.ToString("yyyyMMddHHmmss");
                Session["sessionid"] = time;

                cmd1 = new SqlCommand("empYCLLogin", con);
                cmd1.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = txtusername.Text;
                cmd1.Parameters.AddWithValue("@pwd", SqlDbType.NVarChar).Value = txtpassword.Text;               
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable ds = new DataTable();
                da.Fill(ds);
                if (ds.Rows.Count > 0)
                {
                    col1Value = ds.Rows[0]["FullName"].ToString().Trim();
                    mobile = ds.Rows[0]["Mobile"].ToString();
                    pwd = ds.Rows[0]["pwd"].ToString();
                    id = ds.Rows[0]["id"].ToString();
                    Session["userid_Adminid"] = id;
                    Session["name"] = col1Value;
                    Session.Add("EmployeeDatatable", ds);  //Carries details to Employeeportal
                    Response.Redirect("YCLC_ViewUsers.aspx", false);
                  
                }
               
                else
                {
                    error.Text = "Incorrect Username or Password";
                    error.Visible = true;
                    int count = 0;
                    if (Session["incorrect"] != null)
                    {
                        count = Convert.ToInt32(Session["incorrect"]);
                        Session["incorrect"] = count + 1;
                    }
                    else
                    {
                        count = count + 1;
                        Session["incorrect"] = count;
                    }

                    if (count > 2)
                    {
                        error.Text = "You've Entered Wrong login info 3 times, Please reset your details via clicking the Forgot Password? !";
                        error.Visible = true;
                        txtusername.Enabled = false;
                        txtpassword.Enabled = false;
                        btlogin.Enabled = false;
                    }
                }

            }
            else
            {
                error.Text = "Enter Username and Password !";
                error.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);

        }
        finally
        {
            // con.Close();
        }
    }
    protected void lbforgot_Click(object sender, EventArgs e)
    {
        pnlLogin.Visible = false;
        Pnl_Password.Visible = true;
    }
    protected void bt_Click(object sender, EventArgs e)
    {
        if (txtEmail.Text.Trim() != "")
        {

            SQLConnection();
            string email = txtEmail.Text;
            string col1Value = string.Empty;
           
            SqlCommand cmd1 = new SqlCommand("employee_Actions", con);
            cmd1.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = txtEmail.Text;
            cmd1.Parameters.AddWithValue("@Action", "Email");
            cmd1.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader1 = cmd1.ExecuteReader();
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    col1Value = reader1["pwd"].ToString();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Email ID is not Found.Please contact to Administrator');</script>", false);
            }


            MailMessage message1 = new MailMessage();
            message1.From = new MailAddress("web@youth.gov.kw", "Forgot Password MYA");
            message1.To.Add(new MailAddress(email));
            message1.Subject = "no-replay";           
            message1.Body = "Your Current Password is" + " " + col1Value;
            message1.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("web@youth.gov.kw", "Top@A147258");
            client.Port = 587; // You can use Port 25 if 587 is blocked (mine is!)
            client.Host = "smtp.office365.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            try
            {
                client.Send(message1);
                //lblText.Text = "Message Sent Succesfully";
                pnlLogin.Visible = true;
                Pnl_Password.Visible = false;
                txtEmail.Text = "";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Password is send in your E-mail id Please check');</script>", false);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        else
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Please enter E-mail id');</script>", false);
    }
    protected void lloginpnl_Click(object sender, EventArgs e)
    {
        pnlLogin.Visible = true;
        Pnl_Password.Visible = false;
    }

   

}