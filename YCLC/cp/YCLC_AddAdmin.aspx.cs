using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class YCLC_cp_YCLC_AddAdmin : System.Web.UI.Page
{

    general_fn gfn = new general_fn();
    General gm = new General();
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid_Yclid"] == null)
        {
            Response.Redirect("Index.aspx");
        }

        else if (Session["yclc_rid"] == null)
        {
            Response.Redirect("YCLC_RegisterdAdmin.aspx", false);
        }
        else
        {
            if (!IsPostBack)
            {
                loadOrganization();

                LoadData();

                // SendEmail("gangareddy.359@gmail.com","123456");

            }
        }
    }

    protected void loadOrganization()
    {
        con = new SqlConnection();
        con.ConnectionString = gm.ConnectionString();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SP_YclcOrganization";
        cmd.Parameters.Clear();
       

        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DDlOrganization.DataSource = ds.Tables[0];
            DDlOrganization.DataValueField = "ID";
            DDlOrganization.DataTextField = "OrganizationName";
            DDlOrganization.DataBind();
            DDlOrganization.Items.Insert(0, new ListItem("--اختر--", "0"));
        }       
    }


    protected void LoadData()
    {
        con = new SqlConnection();
        con.ConnectionString = gm.ConnectionString();
        con.Open();



        SqlCommand command = new SqlCommand("SP_YCLCadmin", con);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = "rgdetails";
        command.Parameters.AddWithValue("@ID", SqlDbType.NVarChar).Value = Session["yclc_rid"].ToString();

       

        command.ExecuteNonQuery();

        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(command);
        sda.Fill(dt);
        con.Close();


        if (dt.Rows.Count > 0)
        {
            txtName.Text = dt.Rows[0]["Name"].ToString();
            txtContactNo.Text = dt.Rows[0]["Phone"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            DDlOrganization.Items.FindByValue(dt.Rows[0]["OrganizationID"].ToString()).Selected = true;
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Validate("personalInfo");
        if (Page.IsValid)
        {

            con.ConnectionString = gm.ConnectionString();

            con.Open();


            SqlCommand Command = new SqlCommand("YCLCAdminRegister", con);
            Command.CommandType = CommandType.StoredProcedure;


            Command.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = Session["yclc_rid"].ToString();
            Command.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtName.Text);
            //Command.Parameters.AddWithValue("@ename", SqlDbType.NVarChar).Value = Server.HtmlEncode(TextEngName.Text);           
            Command.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtEmail.Text);
            Command.Parameters.AddWithValue("@mobile", SqlDbType.NVarChar).Value = Server.HtmlEncode(txtContactNo.Text.Trim());
            Command.Parameters.AddWithValue("@pwd", SqlDbType.NVarChar).Value = txtPassword.Text;
            Command.Parameters.AddWithValue("@Organization", SqlDbType.NVarChar).Value = DDlOrganization.SelectedValue;

            Command.Parameters.Add("@ERROR", SqlDbType.Int).Direction = ParameterDirection.Output;

            try
            {
                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

            int result = int.Parse(Command.Parameters["@ERROR"].Value.ToString());

            if (result != 0)
            {
                SendEmail(txtEmail.Text,txtPassword.Text);

                success.Visible = true;
                alertEmail.Visible = false;
                txtName.Text = "";
                //TextEngName.Text = "";
                txtEmail.Text = "";
              
                txtContactNo.Text = "";
                DDlOrganization.SelectedValue = "0";
                
            }
            else if (result == 0)
            {
                alertEmail.Visible = true;
                success.Visible = false;
            }
        }
    }

    protected void SendEmail(string email,string pwd)
    {
        string result = string.Empty;

        result = " <a href='https://www.youth.gov.kw/YCLC/cp/index.aspx' target='_blank'> Click Here to Login </a> " + " <br />" +
              "  اسم المستخدم : " + email + " <br />" +
              " كلمة المرور:" + pwd + " <br />";

        int i = GeneralEmail(email, result);

    }

    public int GeneralEmail(string emailid, string unique)
    {
        String email = emailid;
        int i = 0;
        if (!email.Equals(""))
        {
            MailMessage message1 = new MailMessage();
            message1.From = new MailAddress("web@youth.gov.kw", "Registration Sucess");
            message1.To.Add(new MailAddress(email));
            message1.Subject = "no-reply";

           // message1.CC.Add(new MailAddress("web@youth.gov.kw"));
            message1.Body = EmailBodyGeneral(unique);
            message1.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("web@youth.gov.kw", "Top@A147258");
            client.Port = 587;
            client.Host = "smtp.office365.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            try
            {
                client.Send(message1);
                i = 0; //sucess
            }
            catch (Exception ex)
            {
                i = 1;
            }
        }
        return i;
    }

    public string EmailBodyGeneral(string unique)
    {
        string body = string.Empty;
        string text = "";

        text = "عزيزي المستخدم  " + " <br />" +
              "نتمنى أن تكونوا بصحة وعافية " + " <br />" +
              " يسعدنا انضمامكم معنا في دوري الابداع الشبابي " + " <br />" +
              " نقدم لك عزيزي المستخدم بيانات الدخول الخاصة بك حتى يمكنك من تسجيل المشاركين  " + " <br />" +
               unique;


        using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/emailGeneral.html")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{work}", text);
        return body;
    }
 
}