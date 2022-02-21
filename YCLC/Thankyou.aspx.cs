using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class YCLC_Thankyou : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // SendEmail();

        if (!IsPostBack)
        {
            if (Session["yclC_category"] != null)
            {
                string category = Session["yclC_category"].ToString();
                //if (category == "1" || category == "2" || category == "3" || category == "5" || category == "7")
                if (category == "2" )
                {
                    DivWaiting.Visible = true;
                    DivNormal.Visible = false;
                }
                else if (category == "1" )
                {
                    DivWaiting.Visible = false;
                    DivNormal.Visible = true;
                }
                else
                    Response.Redirect("Index.html", false);
             }
            else
                Response.Redirect("Index.html", false);
        }
       
    }
    private void generateCard()
    {

       
        if (Session["yclC_userid"] != null)
        {
            SqlConnection con = new SqlConnection();
            General Obj_Gen = new General();
            con.ConnectionString = Obj_Gen.ConnectionString();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            int userID = int.Parse(Session["yclC_userid"].ToString());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "YCLCLoadValueByUser";
            cmd.Parameters.AddWithValue("@id", userID);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("e-card.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{image}", dt.Rows[0]["QRCode"].ToString());
            body = body.Replace("{name}", dt.Rows[0]["اسم المشارك"].ToString());
            body = body.Replace("{civil}", dt.Rows[0]["الرقم المدني"].ToString());
            body = body.Replace("{catagory}", dt.Rows[0]["اختر مسابقة واحدة فقط"].ToString());
            body = body.Replace("{level}", dt.Rows[0]["تم تسجيلك في المستوى"].ToString());
            StreamWriter writer = new StreamWriter("C:\\inetpub\\wwwroot\\Youth.gov.kw\\YCLC\\e-card1.html");
          //  StreamWriter writer = new StreamWriter("C:\\inetpub\\wwwroot\\youthNew\\YCLC\\e-card1.html");
            writer.Write(body);
            writer.Dispose();
        }
    
    }
    private void SendEmail()
    {
        if (Session["yclC_userid"]!=null)
        {
            SqlConnection con = new SqlConnection();
            General Obj_Gen = new General();
            con.ConnectionString = Obj_Gen.ConnectionString();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            int userID = int.Parse(Session["yclC_userid"].ToString());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "YCLCLoadValueByUser";
            cmd.Parameters.AddWithValue("@id", userID);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            string userEmail = string.Empty;
            string parentEmail = string.Empty;
           SendEmailYCLC se = new SendEmailYCLC();           
            string ts = se.GeneralYCLEmail("sijila.p@gmail.com", dt);
        }
    
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Response.Redirect("https://www.youth.gov.kw/YCL/index.aspx",false);
    }
   
    protected void btnBack_Click(object sender, EventArgs e)
    {
       
        Response.Redirect("../Index_AR.aspx",false);
    }
    protected void btPrint_Click(object sender, EventArgs e)
    {
        generateCard();
        Response.Redirect("e-card1.html", false);
    }
}