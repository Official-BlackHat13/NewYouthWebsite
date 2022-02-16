using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index_AR : System.Web.UI.Page
{
    private bool isRTL = true;
    General gm = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillData();
        }
    }


    protected void FillData()
    {
        DataSet ds = GetDS();
        if (ds.Tables.Count > 0)
        {
            DataTable dt = new DataTable();

            dt = ds.Tables[1];
            if (dt.Rows.Count > 0)
                rptActivities.DataSource = dt;
            else
                rptActivities.DataSource = "";

            rptActivities.DataBind();


        }

    }

    protected DataSet GetDS()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = gm.YPA();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SP_GetNews";
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@isRTL", isRTL);

        DataSet ds = new DataSet();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);

        con.Open();
        cmd.ExecuteNonQuery();
        sda.Fill(ds);
        con.Close();

        return ds;
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
            General gm = new General();
            SqlConnection cnn = new SqlConnection();

            string fName = txtFirstName.Text;
            string lName = txtLastName.Text;
            string Email = txtEmail.Text;
            string Message = txtMessage.Text;


            DateTime date = DateTime.Now;

            try
            {
                if (string.IsNullOrEmpty(txtEmail.Text.ToString()))
                {
                    pnlMessage.Visible = true;
                    lblMessage.Text = "Fill all the fields";                   
                    return;
                }
                if (string.IsNullOrEmpty(txtMessage.Text.ToString()))
                {
                    pnlMessage.Visible = true;
                    lblMessage.Text = "Fill all the fields";                    
                    return;
                }

                if (string.IsNullOrEmpty(txtFirstName.Text.ToString()))
                {
                    pnlMessage.Visible = true;
                    lblMessage.Text = "Fill all the fields";                    
                    return;
                }


                string text = Message;
                text = text.Replace("\n", "<br/>");
                text = text.Replace("\r", "&nbsp;&nbsp;");
                cnn.ConnectionString = gm.YPA();
                cnn.Open();
                SqlCommand cmd = new SqlCommand("contact", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fname", SqlDbType.NVarChar).Value = fName;
                cmd.Parameters.AddWithValue("@lname", SqlDbType.NVarChar).Value = lName;
                cmd.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = txtEmail.Text;
                cmd.Parameters.AddWithValue("@msg", SqlDbType.NVarChar).Value = text;
                cmd.Parameters.AddWithValue("@ip", SqlDbType.NVarChar).Value = Globals.GetIPAddress();
                cmd.Parameters.AddWithValue("@date", SqlDbType.DateTime).Value = DateTime.Now;


                var returnParameter = cmd.Parameters.Add("@res", SqlDbType.NVarChar);
                returnParameter.Direction = ParameterDirection.Output;
                returnParameter.Size = 100;

                cmd.ExecuteNonQuery();
                string message = (string)cmd.Parameters["@res"].Value.ToString().Trim();
                if (message.Equals("01"))
                {
                    pnlMessage.Visible = true;
                    lblMessage.Text = "تم ارسال هذا الاستعلام بالفعل ";
                    cnn.Close();
                }
                else
                {

                    mail();
                    pnlMessage.Visible = true;
                    lblMessage.Text = "لقد تم ارسال رسالتك بنجاح";
                    Clear();

                }




                cnn.Close();



                txtFirstName.Text = "";
                txtEmail.Text = "";
                txtLastName.Text = "";
                txtMessage.Text = "";


            }
            catch (SmtpException ex)
            {

                pnlMessage.Visible = true;
                lblMessage.Text = ex.ToString();
            }

        
    }

    public void mail()
    {
        string fName = txtFirstName.Text;
        string lName = txtLastName.Text;
        string Email = txtEmail.Text;
        string Message = txtMessage.Text;

        MailMessage msg = new MailMessage();
        msg.To.Add(new MailAddress("undersec@youth.gov.kw", "SomeOne"));
        msg.From = new MailAddress("web@youth.gov.kw", txtEmail.Text);
        msg.Subject = "Mail From Contact Page";
        string email = "<a href='mailto:" + Email + "'" + ">" + Email + "</a>";
        msg.Body = "Email Address : " + email + "<br>" + "Name : " + fName + "<br>" + "<br>" + "Message : " + "<br>" + txtMessage;
        msg.IsBodyHtml = true;
        SmtpClient client = new SmtpClient();
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("web@youth.gov.kw", "Top@A147258");
        client.Port = 587; // You can use Port 25 if 587 is blocked (mine is!)
        client.Host = "smtp.office365.com";
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.EnableSsl = true;

        try
        {
            client.Send(msg);
            //lblText.Text = "Message Sent Succesfully";
        }
        catch (Exception ex)
        {
            //  Response.Write(ex);
        }
    }

    private void Clear()
    {
        txtEmail.Text = "";
        txtMessage.Text = "";
        txtFirstName.Text = "";
        txtLastName.Text = "";
    }



}