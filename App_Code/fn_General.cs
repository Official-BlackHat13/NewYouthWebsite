using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
/// <summary>
/// Summary description for fn_General
/// </summary>
public class fn_General
{
	public fn_General()
	{
		//
		// TODO: Add constructor logic here
		//
	}

   public string AddExcelStyling()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<html xmlns:o='urn:schemas-microsoft-com:office:office'\n" +

    "xmlns:x='urn:schemas-microsoft-com:office:excel'\n" +

    "xmlns='http://www.w3.org/TR/REC-html40'>\n" +

    "<head>\n");
        sb.Append("<!--[if gte mso 9]><xml>\n");

        sb.Append("<x:ExcelWorkbook>\n");

        sb.Append("<x:ExcelWorksheets>\n");

        sb.Append("<x:ExcelWorksheet>\n");

        sb.Append("<x:Name>ADASA</x:Name>\n");

        sb.Append("<x:WorksheetOptions>\n");

        sb.Append("<x:DisplayRightToLeft/>\n");

        sb.Append("<x:DoNotDisplayGridlines/>\n");
        sb.Append("</x:WorksheetOptions>\n");

        sb.Append("</x:ExcelWorksheet>\n");

        sb.Append("</x:ExcelWorksheets>\n");

        sb.Append("</x:ExcelWorkbook>\n");

        sb.Append("</xml><![endif]-->\n");

        sb.Append("</head>\n");

        sb.Append("<body>\n");

        return sb.ToString();

    }
public Boolean CheckApplied(string userId,string Table)
    {
General gm = new General();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = gm.ConnectionString();
        con.Open();
        string id = userId;
        string query = "SP_checkExistance";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.CommandType = CommandType.StoredProcedure;
        DataTable dt = new DataTable();
        cmd.Parameters.AddWithValue("@uid", SqlDbType.NVarChar).Value = userId;
        cmd.Parameters.AddWithValue("@table", SqlDbType.NVarChar).Value = Table;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.ExecuteNonQuery();
        da.Fill(dt);
        con.Close();
        int result = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
        if (result.Equals(0))
        {
            return true;
        }
        return false;


    }
public DataTable GetDataTableYPI(string SQLstring)
    {
        General gm = new General();


        using (SqlConnection cnn = new SqlConnection())
        {
            cnn.ConnectionString = gm.ConnectionStringMYAPI();
            cnn.Open();

            var SDA = new SqlDataAdapter(SQLstring, cnn);
            DataTable dt = new DataTable();

            SDA.Fill(dt);
            SDA.Dispose();
            return dt;

        }
    }
    public int ExecuteDataYPI(string SQLstring)
    {
        int R = 0;
        General gm = new General();


        using (SqlConnection cnn = new SqlConnection())
        {
            cnn.ConnectionString = gm.ConnectionStringMYAPI();
            SqlCommand cmd = new SqlCommand(SQLstring, cnn);

            cnn.Open();
            R = cmd.ExecuteNonQuery();
            cnn.Close();


        }

        return R;
    }

    public int GeneralAdminEmail(string emailid, string unique, string DisplayName, string file, string partucularEmail)
    {
        String email = emailid;


        string[] arr = email.Split(',');           

      

        int i = 0;
        if (!email.Equals(""))
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("web@youth.gov.kw", DisplayName);
               message.CC.Add(new MailAddress("web@youth.gov.kw"));
            if (arr.Length > 1)
            {
                foreach (string mail in arr)
                {
                    message.To.Add(new MailAddress(mail));
                }
            }
            else
            {
                message.To.Add(new MailAddress(email));
            }

           
            message.Subject = "no-reply";
            if (!string.IsNullOrEmpty(partucularEmail))
            {
                message.CC.Add(new MailAddress(partucularEmail));
            }
           
            message.Body = AdminEmailBodyGeneral(unique);
            if (!string.IsNullOrEmpty(file))
            {
                message.Attachments.Add(new Attachment(file));
            }

            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("web@youth.gov.kw", "Top@A147258");
            client.Port = 587;
            client.Host = "smtp.office365.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            try
            {
                client.Send(message);
                i = 0; //sucess
            }
            catch (Exception ex)
            {
                i = 1;
            }
        }
        return i;
    }
 public DataSet GetDSAdmin(string SQLstring)
     {

         General gm = new General();


         using (SqlConnection cnn = new SqlConnection())
         {
             cnn.ConnectionString = gm.myConnectionString();
             cnn.Open();

             var SDA = new SqlDataAdapter(SQLstring, cnn);
             DataSet DS = new DataSet();

             SDA.Fill(DS);
             SDA.Dispose();
             return DS;

         }
     }
    public string AdminEmailBodyGeneral(string unique)
    {
        string body = string.Empty;
        string text = "";

        text = unique;


        using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/emailGeneral.html")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{work}", text);
        return body;
    }

  public DataTable GetDataTable(string SQLstring)
    {
        General gm = new General();


        using (SqlConnection cnn = new SqlConnection())
        {
            cnn.ConnectionString = gm.ConnectionString();
            cnn.Open();

            var SDA = new SqlDataAdapter(SQLstring, cnn);
            DataTable dt = new DataTable();

            SDA.Fill(dt);
            SDA.Dispose();
            return dt;

        }
    }
public DataTable GetDataTableAdmin(string SQLstring)
    {
        General gm = new General();


        using (SqlConnection cnn = new SqlConnection())
        {
            cnn.ConnectionString = gm.myConnectionString();
            cnn.Open();

            var SDA = new SqlDataAdapter(SQLstring, cnn);
            DataTable dt = new DataTable();

            SDA.Fill(dt);
            SDA.Dispose();
            return dt;

        }
    }

    public DataSet GetDS(string SQLstring)
    {

        General gm = new General();


        using (SqlConnection cnn = new SqlConnection())
        {
            cnn.ConnectionString = gm.ConnectionString();
            cnn.Open();

            var SDA = new SqlDataAdapter(SQLstring, cnn);
            DataSet DS = new DataSet();

            SDA.Fill(DS);
            SDA.Dispose();
            return DS;

        }
    }
  public DataSet GetAdminDS(string SQLstring)
     {

         General gm = new General();


         using (SqlConnection cnn = new SqlConnection())
         {
             cnn.ConnectionString = gm.myConnectionString();
             cnn.Open();

             var SDA = new SqlDataAdapter(SQLstring, cnn);
             DataSet DS = new DataSet();

             SDA.Fill(DS);
             SDA.Dispose();
             return DS;

         }
     }

  
 public string CivilID(string id)
    {
        string civil = id;


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
            return id;
        }
        else
        {
            return "";
        }



    }


     
    public int ExecuteData(string SQLstring)
    {
        int R = 0;
        General gm = new General();


        using (SqlConnection cnn = new SqlConnection())
        {
            cnn.ConnectionString = gm.ConnectionString();
            SqlCommand cmd = new SqlCommand(SQLstring, cnn);

             cnn.Open();
             R = cmd.ExecuteNonQuery();
            cnn.Close();       

           
        }

        return R;
    }
    public int ExecuteDataAdmin(string SQLstring)
    {
        int R = 0;
        General gm = new General();
        using (SqlConnection cnn = new SqlConnection())
        {
            cnn.ConnectionString = gm.myConnectionString();
            SqlCommand cmd = new SqlCommand(SQLstring, cnn);


            try
            {
                cnn.Open();
                R = cmd.ExecuteNonQuery();
                cnn.Close();
            }

            catch (Exception ex)
            {
                if (ex.Message.ToUpper().Contains("PRIMARY KEY") == true)
                {
                    R = 999;
                }
            }
        }

        return R;
    }

    public bool checkQueryString(string value)
    {
        int i;
        bool res = int.TryParse(value, out i);

        if (res == false)
        {
            HttpContext.Current.Response.Redirect("error.aspx",false);
            //return;
        }
        return res;
    }
    public int AdminExecuteData(string SQLstring)
    {
        int R = 0;
        General gm = new General();
        using (SqlConnection cnn = new SqlConnection())
        {
            cnn.ConnectionString =  gm.myConnectionString();
            SqlCommand cmd = new SqlCommand(SQLstring, cnn);


            try
            {
                cnn.Open();
                R = cmd.ExecuteNonQuery();
                cnn.Close();
            }

            catch (Exception ex)
            {
                if (ex.Message.ToUpper().Contains("PRIMARY KEY") == true)
                {
                    R = 999;
                }
            }
        }

        return R;
    }
}