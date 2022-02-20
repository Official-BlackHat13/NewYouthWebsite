using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;
using System.Net;
using System.Text;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using QRCoder;
using System.Drawing;
using System.Web.Hosting;
using System.Net.Mail;
/// <summary>
/// Summary description for general_fn
/// </summary>
public class general_fn
{
    General gm = new General();
    SqlConnection cnn = new SqlConnection();
    private static readonly byte[] DOC = { 208, 207, 17, 224, 161, 177, 26, 225 };
    private static readonly byte[] GIF = { 71, 73, 70, 56 };
    private static readonly byte[] JPG = { 255, 216, 255 };
    private static readonly byte[] PDF = { 37, 80, 68, 70, 45, 49, 46 };
    private static readonly byte[] PNG = { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82 };
    private static readonly byte[] ZIP_DOCX = { 80, 75, 3, 4 };

    public general_fn()
    {
        //
        // TODO: Add constructor logic here
        //
    }
public int ReportEmail(string[] emailid, string unique)
 {
    
     String PCemail = emailid[0];
     int i = 0;
     if (!PCemail.Equals(""))
     {
         MailMessage message1 = new MailMessage();
         message1.From = new MailAddress("web@youth.gov.kw", "Monthly Report");
         message1.To.Add(new MailAddress(PCemail));
         message1.Subject = "no-reply";

         message1.CC.Add(new MailAddress("web@youth.gov.kw"));         
         message1.CC.Add(new MailAddress("m.alrubaie@youth.gov.kw"));
         message1.Body = EmailBodyReportGeneral(unique);
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
 public int DobFromCivilAge(string civil_id)
    {
        int year;
        int cnt = 0;
        string returndob = null;

        //if input is arabic numberes.
        string enddate1 = toEnglishNumber(civil_id);

        string first_digit = enddate1.Substring(0, 1);
        string sub = enddate1.Substring(1, 6);
        string year1 = sub.Substring(0, 2);
        string month = sub.Substring(2, 2);
        string date = sub.Substring(4, 2);
        int diff = 0;
        string dob = date + "/" + month + "/" + year1;



        DateTime foundDate;
        Match matchResult = Regex.Match(dob,
            "^(?<day>[0-3]?[0-9])/(?<month>[0-3]?[0-9])/(?<year>(?:[0-9]{2})?[0-9]{2})$");
        if (matchResult.Success)
        {
            year = int.Parse(matchResult.Groups["year"].Value);

            if ((first_digit == "3") || (first_digit == "2"))
            {
                if (first_digit == "3") year += 2000;
                else if (first_digit == "2") year += 1900;

                //if (year > DateTime.Now.Year) year += 2000;
                //else if (year < 100) year += 1900;
                try
                {
                    foundDate = new DateTime(year, int.Parse(matchResult.Groups["month"].Value), int.Parse(matchResult.Groups["day"].Value));
                    //int dobyear = Convert.ToInt32(year1);// Convert.ToInt32(DateTime.Parse(dob1).Year);
                    int years = Convert.ToInt32(DateTime.Now.Year);
                    diff = (years - year);
                    string dateformate = year + "/" + month + "/" + date;
                    if (diff < 1)
                    {
                        cnt = 1;

                    }
                    else
                    {
                        if ((DateTime.Parse(dateformate).Month > DateTime.Now.Month) || (DateTime.Parse(dateformate).Month == DateTime.Now.Month && DateTime.Parse(dateformate).Day > DateTime.Now.Day))

                            diff = diff - 1;

                        returndob = year + "/" + month + "/" + date;

                    }
                }
                catch (Exception ex)
                {
                    cnt = 1;

                }
            }
            else
            {
                cnt = 1;

            }
        }
        else
        {
            cnt = 1;

        }
        int a = diff;
        return a;

    }

public string EmailBodyReportGeneral(string unique)
 {
     string body = string.Empty;
     string text = "";

     text = unique;


     using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("../emailGeneral.html")))
     {
         body = reader.ReadToEnd();
     }
     body = body.Replace("{work}", text);
     return body;
 }



    public int GeneralYCLCEmail(string unique)
    {

        int i = 0;

        MailMessage message1 = new MailMessage();
        message1.From = new MailAddress("register-ws@sacgc.org", "Contact");
        // message1.To.Add(new MailAddress(email));
       
        message1.Subject = "no-reply";

        message1.CC.Add(new MailAddress("ae.alameeri@paaet.edu.kw"));
        message1.Body = unique;
        message1.IsBodyHtml = true;
        SmtpClient client = new SmtpClient();
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("register-ws@sacgc.org", "Wuv11540");
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

        return i;
    }
 public int YCLCompetitionOrg(string emailid, string tempID, string unique)
    {
        String email = emailid;
        int i = 0;
        if (!email.Equals(""))
        {

            MailMessage message = new MailMessage();
            message.From = new MailAddress("web@youth.gov.kw", "دوري الاإبداع الشبابي ");
            message.Bcc.Add(new MailAddress("web@youth.gov.kw"));
            message.To.Add(new MailAddress(email));

            if (!tempID.Equals(""))
            {
               // message.To.Add(new MailAddress(tempID));
            }
            string url = "https://www.youth.gov.kw/YCLC/QRenerator.aspx?rid=" + unique;
            message.Subject = "no-reply";
            message.CC.Add(new MailAddress("web@youth.gov.kw"));
            string text = "عزيزي المشترك " + "<br>" + "نتمنى أن تكونوا بصحة وعافية " + "<br>" + "يسعدنا انضمامك معنا في دوري الابداع الشبابي" + "<br>" + "لقد تم تسجيلك للمشاركة في دوري الإبداع الشبابي من طرف" + "&nbsp;&nbsp;" + tempID + "<br>" + "<br>" + "<p style='text-align: center;font-size: 16px;font-weight: 600;color: #76b7d2;'>" + "مع كل التمنيات لكم بالاستفادة واستثمار وقتكم وانتو" + "<br>" + " #قاعدين_بالبيت" + "</p>";
            message.Body = EmailBodyAgency(text);

            message.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.office365.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("web@youth.gov.kw", "Top@A147258");

            try
            {
                smtpClient.Send(message);
                smtpClient = null;
                message.Dispose();
                i = 0; //sucess
            }
            catch (Exception ex)
            {
                i = 1;
            }

        }
        return i;
    }
    public int YCLCompetition(string emailid, string tempID, string unique)
    {
        String email = emailid;
        int i = 0;
        if (!email.Equals(""))
        {

            MailMessage message = new MailMessage();
            message.From = new MailAddress("web@youth.gov.kw", "دوري الاإبداع الشبابي ");
            message.Bcc.Add(new MailAddress("web@youth.gov.kw"));          
            message.To.Add(new MailAddress(email));

            if (!tempID.Equals(""))
            {
                message.To.Add(new MailAddress(tempID));
            }
            string url = "https://www.youth.gov.kw/YCLC/QRenerator.aspx?rid=" + unique;
            message.Subject = "no-reply";
            message.CC.Add(new MailAddress("web@youth.gov.kw"));
            string text = "تم تسجيلك في مسابقات دوري الابداع الشبابي " + "<br>" + "سيتم التواصل معك في أقرب فرصه " + "<br>" +  "<br>";
            message.Body = EmailBodyAgency(text);

            message.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.office365.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("web@youth.gov.kw", "Top@A147258");

            try
            {
                smtpClient.Send(message);
                smtpClient = null;
                message.Dispose();
                i = 0; //sucess
            }
            catch (Exception ex)
            {
                i = 1;
            }

        }
        return i;
    }
    public int GeneralYCLCListTEmail(string unique)
    {

        int i = 0;
        if (!unique.Equals(""))
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("web@youth.gov.kw", "Registration Sucess");
            message.To.Add(new MailAddress("sijila.p@gmail.com"));
            message.Subject = "no-reply";
            message.CC.Add(new MailAddress("web@youth.gov.kw"));
            message.Body = "THNK YOU";// EmailBodyYPA(unique);           
            Attachment data = new Attachment(unique, System.Net.Mime.MediaTypeNames.Application.Octet);
            message.Attachments.Add(data);
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
                client = null;
                message.Dispose();
                i = 0; //sucess
            }
            catch (Exception ex)
            {
                i = 1;
            }

        }
        return i;
    }
    public string Civil_Check(string civil)
    {
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
            return civil;

        }
        else
        {
            return "";

        }

    }
    public int checkYPIAge(string id)
    {

        int count_value = 0;
        cnn.ConnectionString = gm.ConnectionString();
        cnn.Open();
        SqlCommand com = new SqlCommand("select dob from [User_Basic_Info]  WHERE [id] =@id", cnn);
        com.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
        com.ExecuteNonQuery();
        SqlDataAdapter selAdp = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        selAdp.Fill(dt);
        string DOB = dt.Rows[0]["dob"].ToString().Trim();
        if (!DOB.Equals(""))
        {
            cnn.Close();
            DateTime dateb = DateTime.Parse(DOB);

            int year = Convert.ToInt32(DateTime.Now.Year);

            int years = DateTime.Now.Year - DateTime.Parse(DOB).Year;

            int month = DateTime.Parse(DOB).Month;
            int day = DateTime.Parse(DOB).Day;

            if ((DateTime.Parse(DOB).Month > DateTime.Now.Month) || (DateTime.Parse(DOB).Month == DateTime.Now.Month && DateTime.Parse(DOB).Day > DateTime.Now.Day))
                years--;

            int diff = years;

            if (diff >= 21 && diff < 35)

                count_value = 1;
            else
                count_value = 0;



        }
        return count_value;




    }
    public int AdminYCLEmail(string emailid, string unique)
    {
        String email = emailid;
        int i = 0;
        if (!email.Equals(""))
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("register-ws@sacgc.org", "Registration Sucess");
            message.To.Add(new MailAddress(email));
            message.Subject = "no-reply";
            message.CC.Add(new MailAddress("register-ws@sacgc.org"));
            message.Body = unique;

            message.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.office365.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("register-ws@sacgc.org", "Wuv11540");


            try
            {
                smtpClient.Send(message);
                smtpClient = null;
                message.Dispose();
                i = 0; //sucess
            }
            catch (Exception ex)
            {
                i = 1;
            }
        }
        return i;
    }
    public int surveyEmail(string emailid, string content)
    {
        String email = emailid;

        int i = 0;

        if (!email.Equals(""))
        {

            MailMessage message1 = new MailMessage();
            message1.From = new MailAddress("web@youth.gov.kw", "فرصة تجميل حدائق الكويت");
            message1.Bcc.Add(new MailAddress("web@youth.gov.kw"));
            message1.CC.Add("ayadena@youth.gov.kw");
            message1.To.Add(new MailAddress(email));

            message1.Subject = "no-reply";


            message1.Body = content;

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

            message1.CC.Add(new MailAddress("web@youth.gov.kw"));
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

        text = unique + " <br />" + "شكرا جزيلا ، لقد تم تسجيل بياناتك بنجاح ، نتمنى لك التوفيق ";   
       
           
        using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("../emailGeneral.html")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{work}", text);
        return body;
    }

    public string checkAgeDiffYPA(string DOB)
    {
        string returndob = null;
        int cnt = 0;
        int diff = 0;
        if (!DOB.Equals(""))
        {

            DateTime dateb = DateTime.ParseExact(DOB, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            // DateTime dateb = DateTime.Parse(DOB);
            int year = Convert.ToInt32(DateTime.Now.Year);
            int years = DateTime.Now.Year - dateb.Year;
            int month = dateb.Month;
            int day = dateb.Day;
            returndob = dateb.Year + "/" + month + "/" + day;
            if ((dateb.Month > DateTime.Now.Month) || (dateb.Month == DateTime.Now.Month && dateb.Day > DateTime.Now.Day))
                years--;
            diff = years;
            if (diff > 18 && diff < 34)
                cnt = 0;
            else
                cnt = 1;
        }
        string a = cnt + "~" + returndob + "~" + diff;
        return a;
    }


    public int checkAge(string id)
    {

        int count_value = 0;
        cnn.ConnectionString = gm.ConnectionString();
        cnn.Open();
        SqlCommand com = new SqlCommand("select dob from [User_Basic_Info]  WHERE [id] =@id", cnn);
        com.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
        com.ExecuteNonQuery();
        SqlDataAdapter selAdp = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        selAdp.Fill(dt);
        string DOB = dt.Rows[0]["dob"].ToString().Trim();
        if (!DOB.Equals(""))
        {
            cnn.Close();
            DateTime dateb = DateTime.Parse(DOB);

            int year = Convert.ToInt32(DateTime.Now.Year);

            int years = DateTime.Now.Year - DateTime.Parse(DOB).Year;

            int month = DateTime.Parse(DOB).Month;
            int day = DateTime.Parse(DOB).Day;

            if ((DateTime.Parse(DOB).Month > DateTime.Now.Month) || (DateTime.Parse(DOB).Month == DateTime.Now.Month && DateTime.Parse(DOB).Day > DateTime.Now.Day))
                years--;

            int diff = years;

            if (diff >= 14 && diff < 35)

                count_value = 1;
            else
                count_value = 0;



        }
        return count_value;




    }

    public Boolean checkAgeDiff(string DOB)
    {
        Boolean count_value = false;

        if (!DOB.Equals(""))
        {

            cnn.Close();
            DateTime dateb = DateTime.Parse(DOB);

            int year = Convert.ToInt32(DateTime.Now.Year);

            int years = DateTime.Now.Year - DateTime.Parse(DOB).Year;

            int month = DateTime.Parse(DOB).Month;
            int day = DateTime.Parse(DOB).Day;

            if ((DateTime.Parse(DOB).Month > DateTime.Now.Month) || (DateTime.Parse(DOB).Month == DateTime.Now.Month && DateTime.Parse(DOB).Day > DateTime.Now.Day))
                years--;

            int diff = years;

            if (diff >= 14 && diff < 35)

                count_value = false;
            else
                count_value = true;



        }
        return count_value;
    }


    public string DobFromCivil(string civil_id)
    {
        int year;
        int cnt = 0;
        string returndob = null;

        //if input is arabic numberes.
        string enddate1 = toEnglishNumber(civil_id);

        string first_digit = enddate1.Substring(0, 1);
        string sub = enddate1.Substring(1, 6);
        string year1 = sub.Substring(0, 2);
        string month = sub.Substring(2, 2);
        string date = sub.Substring(4, 2);
        int diff = 0;
        string dob = date + "/" + month + "/" + year1;



        DateTime foundDate;
        Match matchResult = Regex.Match(dob,
            "^(?<day>[0-3]?[0-9])/(?<month>[0-3]?[0-9])/(?<year>(?:[0-9]{2})?[0-9]{2})$");
        if (matchResult.Success)
        {
            year = int.Parse(matchResult.Groups["year"].Value);

            if ((first_digit == "3") || (first_digit == "2"))
            {
                if (first_digit == "3") year += 2000;
                else if (first_digit == "2") year += 1900;

                //if (year > DateTime.Now.Year) year += 2000;
                //else if (year < 100) year += 1900;
                try
                {
                    foundDate = new DateTime(year, int.Parse(matchResult.Groups["month"].Value), int.Parse(matchResult.Groups["day"].Value));
                    //int dobyear = Convert.ToInt32(year1);// Convert.ToInt32(DateTime.Parse(dob1).Year);
                    int years = Convert.ToInt32(DateTime.Now.Year);
                    diff = (years - year);
                    string dateformate = year + "/" + month + "/" + date;
                    if (diff < 1)
                    {
                        cnt = 1;

                    }
                    else
                    {
                        if ((DateTime.Parse(dateformate).Month > DateTime.Now.Month) || (DateTime.Parse(dateformate).Month == DateTime.Now.Month && DateTime.Parse(dateformate).Day > DateTime.Now.Day))

                            diff = diff - 1;

                        returndob = year + "/" + month + "/" + date;

                    }
                }
                catch (Exception ex)
                {
                    cnt = 1;

                }
            }
            else
            {
                cnt = 1;

            }
        }
        else
        {
            cnt = 1;

        }
        string a = cnt + "~" + returndob + "~" + diff;
        return a;

    }
    public string RamdomNumberGenerate()
    {
        try
        {
            int time = DateTime.Now.Millisecond;

            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());

            const string Nos1 = "12345678";
            var randomNo1 = new Random();
            string NoBeg = new string(Enumerable.Repeat(Nos1, 1).Select(s => s[randomNo1.Next(s.Length)]).ToArray());

            int Split1 = Convert.ToInt16(NoBeg);
            string GuidSub1 = GuidString.Substring(Split1, 3);

            const string Nos2 = "123456789";
            var randomNo2 = new Random();
            string NoBeg2 = new string(Enumerable.Repeat(Nos2, 1).Select(s => s[randomNo2.Next(s.Length)]).ToArray());
            NoBeg2 = "1" + Convert.ToInt16(NoBeg2);
            int Split2 = Convert.ToInt16(NoBeg2);
            string GuidSub2 = GuidString.Substring(Split2, 2);

            int sec = time + DateTime.Now.Millisecond;

            int len = sec.ToString().Length;
            string sec1 = sec.ToString().Substring(1, 1);

            len = (len + 1) - 4;
            string sec2 = sec.ToString().Substring(2, 1);

            GuidString = sec1 + GuidSub2 + sec2 + GuidSub1;

            const string chars = "@$#=";
            var random = new Random();
            string charBeg = new string(Enumerable.Repeat(chars, 1).Select(s => s[random.Next(s.Length)]).ToArray());

            GuidString = charBeg + GuidString;

            return GuidString;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public string toEnglishNumber(string input)
    {
        string EnglishNumbers = "";

        for (int i = 0; i < input.Length; i++)
        {
            if (Char.IsDigit(input[i]))
            {
                EnglishNumbers += char.GetNumericValue(input, i);

            }
            else
            {
                EnglishNumbers += input[i].ToString();
            }

        }
        return EnglishNumbers;
    }

    public void QRCodeGenerate(string code)
    {
        DateTime date = DateTime.Now;
        string time = date.ToString("yyyyMMddHHmmss");
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
        imgBarCode.Height = 150;
        imgBarCode.Width = 150;

        using (Bitmap bitMap = qrCode.GetGraphic(20))
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] byteImage = ms.ToArray();
                imgBarCode.ImageUrl = "data:imgQR/png;base64," + Convert.ToBase64String(byteImage);/// ----for displaying
            }
            bitMap.Save(HostingEnvironment.MapPath("~/User/imgQR/") + @"\qr" + time + ".jpeg");
        }

    }
    public string EncryptFileName(FileUpload File, string filename)
    {
        string Oprfileextn = Path.GetExtension(File.PostedFile.FileName.ToString());
        string Oprfilepath = filename;
        SHA256 sha2562 = SHA256Managed.Create(); //utf8 here as well
        byte[] bytes2 = sha2562.ComputeHash(Encoding.UTF8.GetBytes(Oprfilepath));
        string ope_hashedBytes = Convert.ToBase64String(bytes2);
        ope_hashedBytes = ope_hashedBytes.Replace("/", "a");
        return ope_hashedBytes + Oprfileextn;
    }
    //ftpsave for file upload

    public void ftpSaveFile(FileUpload extn, string filename, string module)
    {
        String ftpurl = "ftp://50.87.248.214/upkwt/" + module + "/";
        String ftpusername = "youth_mya@q8-youth.com"; // e.g. username
        String ftppassword = "mya#@Ahelp456789"; // e.g. password
        string ftpfullpath2 = ftpurl + filename;
        FtpWebRequest ftp2 = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath2);
        ftp2.Credentials = new NetworkCredential(ftpusername, ftppassword);

        ftp2.KeepAlive = true;
        ftp2.UseBinary = true;
        ftp2.Method = WebRequestMethods.Ftp.UploadFile;
        byte[] buffer2 = new byte[extn.PostedFile.InputStream.Length];
        extn.PostedFile.InputStream.Read(buffer2, 0, buffer2.Length);
        extn.PostedFile.InputStream.Close();
        try
        {
            Stream ftpstream2 = ftp2.GetRequestStream();
            ftpstream2.Write(buffer2, 0, buffer2.Length);
            ftpstream2.Close();
        }

        catch (Exception ex)
        {


        }

    }
    private static string ErrMime = "";
    public static Boolean GetMimeType(byte[] file, string fileName, string type)
    {

        string mime = "application/octet-stream";
        if (string.IsNullOrWhiteSpace(fileName))
        {
            return false;
        }
        //Get the file extension
        string extension = Path.GetExtension(fileName) == null
                               ? string.Empty
                               : Path.GetExtension(fileName).ToUpper();

        //Get the MIME Type

        if (type == "document")
        {
            if (file.Take(8).SequenceEqual(DOC))
            {
                mime = "application/msword";
                return false;
            }

            else if (file.Take(7).SequenceEqual(PDF))
            {
                mime = "application/pdf";
                return false;
            }
            else if (file.Take(4).SequenceEqual(ZIP_DOCX))
            {
                mime = extension == ".DOCX" ? "application/vnd.openxmlformats-officedocument.wordprocessingml.document" : "application/x-zip-compressed";
                return false;
            }
            else if (file.Take(4).SequenceEqual(GIF))
            {
                ErrMime = "image/gif";
                return true;
            }
            else if (file.Take(16).SequenceEqual(PNG))
            {
                ErrMime = "image/png";
                return true;
            }
            else if (file.Take(3).SequenceEqual(JPG))
            {
                ErrMime = "image/jpeg";
                return true;
            }
        }
        else if (type == "pdf")
        {
            if (file.Take(7).SequenceEqual(PDF))
            {
                mime = "application/pdf";
                return false;
            }

        }
        else if (type == "image")
        {
            if (file.Take(4).SequenceEqual(GIF))
            {
                mime = "image/gif";
                return false;
            }
            else if (file.Take(16).SequenceEqual(PNG))
            {
                mime = "image/png";
                return false;
            }
            else if (file.Take(3).SequenceEqual(JPG))
            {
                mime = "image/jpeg";
                return false;
            }
            else if (file.Take(8).SequenceEqual(DOC))
            {
                ErrMime = "application/msword";
                return true;
            }

            else if (file.Take(7).SequenceEqual(PDF))
            {
                ErrMime = "application/pdf";
                return true;
            }
            else if (file.Take(4).SequenceEqual(ZIP_DOCX))
            {
                ErrMime = extension == ".DOCX" ? "application/vnd.openxmlformats-officedocument.wordprocessingml.document" : "application/x-zip-compressed";
                return true;
            }

        }
        else if (type == "civil")
        {
            if (file.Take(4).SequenceEqual(GIF))
            {
                mime = "image/gif";
                return false;
            }
            else if (file.Take(16).SequenceEqual(PNG))
            {
                mime = "image/png";
                return false;
            }
            else if (file.Take(3).SequenceEqual(JPG))
            {
                mime = "image/jpeg";
                return false;
            }
            else if (file.Take(7).SequenceEqual(PDF))
            {
                mime = "application/pdf";
                return false;
            }
            else if (file.Take(8).SequenceEqual(DOC))
            {
                ErrMime = "application/msword";
                return true;
            }

            else if (file.Take(4).SequenceEqual(ZIP_DOCX))
            {
                ErrMime = extension == ".DOCX" ? "application/vnd.openxmlformats-officedocument.wordprocessingml.document" : "application/x-zip-compressed";
                return true;
            }

        }
        else if (type == "video")
        {
            string result = GetMimeType(fileName);
            // if ((result=="video/mp4")||(result=="video/x-flv"))
            return false;
        }


        return true;
    }

    //return false for success = proper file format




    private static string GetMimeType(string fileName)
    {
        string mimeType = "application/unknown";
        string ext = System.IO.Path.GetExtension(fileName).ToLower();
        Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
        if (regKey != null && regKey.GetValue("Content Type") != null)
            mimeType = regKey.GetValue("Content Type").ToString();
        return mimeType;
    }


    public Boolean CheckExtension(FileUpload upd, string type)
    {

        string extn = Path.GetExtension(upd.PostedFile.FileName.ToString());
        string filetype = upd.PostedFile.ContentType.ToString();

        int fileLen;


        fileLen = upd.PostedFile.ContentLength;
        byte[] input = new byte[25];
        if (fileLen > 1)
        {
            input = new byte[fileLen - 1];
            input = upd.FileBytes;
        }

        if (type == "image")
        {
            if ((extn != ".pdf") && (extn != ".jpeg") && (extn != ".png") && (extn != ".gif") && (extn != ".JPG") && (extn != ".JPEG") && (extn != ".PNG") && (extn != ".GIF"))
            {
                fileuploadDetails(upd, "image", HttpContext.Current.Session["sessionid_upload"].ToString(), "expected extension is .pdf/.jpeg/.png/.gif/.JPG/.JPEG/.PNG/.GIF", "", "", "", false, "insert");

                return true;
            }
        }
        else if (type == "document")
        {
            if ((extn != ".doc") && (extn != ".docx") && (extn != ".pdf") && (extn != ".DOC") && (extn != ".DOCX") && (extn != ".PDF"))
            {
                fileuploadDetails(upd, "document", HttpContext.Current.Session["sessionid_upload"].ToString(), "expected extension is .doc/.docx/.pdf/.DOC/.DOCX/.PDF", "", "", "", false, "insert");
                return true;

            }
        }
        else if (type == "pdf")
        {
            if ((extn != ".pdf") && (extn != ".PDF"))
            {
                fileuploadDetails(upd, "pdf", HttpContext.Current.Session["sessionid_upload"].ToString(), "expected extension is .pdf/.PDF", "", "", "", false, "insert");
                return true;

            }
        }
        else if (type == "civil")
        {
            if ((extn != ".pdf") && (extn != ".PDF") && (extn != ".jpg") && (extn != ".jpeg") && (extn != ".png") && (extn != ".gif") && (extn != ".JPG") && (extn != ".JPEG") && (extn != ".PNG") && (extn != ".GIF"))
            {
                fileuploadDetails(upd, "civil", HttpContext.Current.Session["sessionid_upload"].ToString(), "expected extension is .pdf/.PDF/.jpg/.jpeg/.png/.gif/.JPG/.JPEG/.PNG/.GIF", "", "", "", false, "insert");

                return true;

            }
        }
        else if (type == "all")
        {
            if ((extn != ".doc") && (extn != ".docx") && (extn != ".pdf") && (extn != ".DOC") && (extn != ".DOCX") && (extn != ".PDF") && (extn != ".jpg") && (extn != ".jpeg") && (extn != ".png") && (extn != ".gif") && (extn != ".JPG") && (extn != ".JPEG") && (extn != ".PNG") && (extn != ".GIF"))
            {
                fileuploadDetails(upd, "all", HttpContext.Current.Session["sessionid_upload"].ToString(), "expected extension is .doc/.docx/.pdf/.DOC/.DOCX/.PDF/.jpg/.jpeg/.png/.gif/.JPG/.JPEG/.PNG/.GIF", "", "", "", false, "insert");
                return true;

            }
        }
        else if (type == "video")
        {

            if ((extn != ".flv") && (extn != ".mp4"))
            {
                fileuploadDetails(upd, "video", HttpContext.Current.Session["sessionid_upload"].ToString(), "expected extension is .flv/.mp4F", "", "", "", false, "insert");

                return true;

            }
        }

        Boolean val = GetMimeType(input, upd.FileName, type);
        if (val)
        {
            string error = "Expected " + type + " file but selected " + ErrMime;
            fileuploadDetails(upd, type, HttpContext.Current.Session["sessionid_upload"].ToString(), "", error, "", "", false, "insert");
            return true;
        }
        else
            return false;
    }
    public int YPAEmail(string emailid, string unique)
    {
        String email = emailid;
        int i = 0;
        if (!email.Equals(""))
        {
            MailMessage message1 = new MailMessage();
            message1.From = new MailAddress("web@ypa.gov.kw", "YPA");
            message1.To.Add(new MailAddress(email));
            message1.Subject = "no-reply";

            message1.CC.Add(new MailAddress("web@ypa.gov.kw"));
            message1.CC.Add(new MailAddress("info@ypa.gov.kw"));
            message1.CC.Add(new MailAddress("G.alajmi@ypa.gov.kw"));
            message1.CC.Add(new MailAddress("web@youth.gov.kw"));
            message1.Body = EmailBodyYPA(unique);



            message1.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("web@ypa.gov.kw", "3Kg<>b>h");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
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
    public string EmailBodyYPA(string unique)
    {
        string body = string.Empty;
        string text = "";


        text = unique;
        using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("emailYPA.html")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{work}", text);
        return body;
    }
    public void DownloadFile(string FileName, string LocalDirectory)
    {
        string ftpURL = "ftp://50.87.248.214";             //Host URL or address of the FTP server
        string UserName = "youth_mya@q8-youth.com";                 //User Name of the FTP server
        string Password = "mya#@Ahelp456789";             //Password of the FTP server
        string ftpDirectory = "upkwt/ini/";          //The directory in FTP server where the files are present

        // string[] files = FileName.Split('*');

        SHA256 sha256 = SHA256Managed.Create(); //utf8 here as well
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(FileName));
        string hashedBytes = Convert.ToBase64String(bytes);
        hashedBytes = hashedBytes.Replace("/", "a");
        try
        {
            FtpWebRequest requestFileDownload = (FtpWebRequest)WebRequest.Create(ftpURL + "/" + ftpDirectory + "/" + FileName);
            requestFileDownload.Credentials = new NetworkCredential(UserName, Password);
            requestFileDownload.Method = WebRequestMethods.Ftp.DownloadFile;
            FtpWebResponse responseFileDownload = (FtpWebResponse)requestFileDownload.GetResponse();
            Stream responseStream = responseFileDownload.GetResponseStream();

            FileStream writeStream = new FileStream(LocalDirectory + "/" + FileName, FileMode.Create);
            int Length = 2048;
            Byte[] buffer = new Byte[Length];
            int bytesRead = responseStream.Read(buffer, 0, Length);
            while (bytesRead > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = responseStream.Read(buffer, 0, Length);
            }
            responseStream.Close();
            writeStream.Close();
            requestFileDownload = null;

            System.Web.HttpResponse response1 = System.Web.HttpContext.Current.Response;
            response1.ClearContent();
            response1.Clear();
            response1.ContentType = "text/plain";
            response1.AddHeader("Content-Disposition", "attachment; filename=" + FileName);
            response1.TransmitFile(LocalDirectory + "\\" + FileName);
            response1.Flush();
            File.Delete(LocalDirectory + "\\" + FileName);

            response1.End();


        }
        catch (WebException e)
        {
            String status = ((FtpWebResponse)e.Response).StatusDescription;
        }

    }


    public int AgencyEmail(string emailid, string unique, string type)
    {
        String email = emailid;

        int i = 0;

        if (!email.Equals(""))
        {

            MailMessage message1 = new MailMessage();
            message1.From = new MailAddress("web@youth.gov.kw", "Ministry of State for Youth Affairs");

            message1.To.Add(new MailAddress(email));
            message1.CC.Add(new MailAddress("web@youth.gov.kw"));
            message1.Subject = "no-reply";

            if (!unique.Equals(""))
            {
                string url = string.Empty;
                if (type.Equals("user"))
                {
                    string p1 = string.Empty;
                    url = "https://www.youth.gov.kw/User/resetPassword.aspx?rid=" + unique;

                    p1 = "<table border='0' cellspacing='10' cellpadding='10' width='100%'>" +
      " <tr><td colspan='2'><center> <strong> </center></strong></td></tr>" +

      "<tr><td colspan='2'>  <center> <strong>" + "<a href=" + url + ">" + "<b>الرجاء الضغط على الرابط التالي لإعادة تعيين كلمة المرور الخاصة بك</b> </a>" + "</center></td></tr>" +
       " </table>";

                    message1.Body = EmailBodyAgency(p1);
                }
                else if (type.Equals("YCLuser"))
                {
                    string p1 = string.Empty;
                    url = "https://www.youth.gov.kw/YCL/resetPassword.aspx?rid=" + unique;

                    p1 = "<table border='0' cellspacing='10' cellpadding='10' width='100%'>" +
      " <tr><td colspan='2'><center> <strong> </center></strong></td></tr>" +

      "<tr><td colspan='2'>  <center> <strong>" + "<a href=" + url + ">" + "<b>الرجاء الضغط على الرابط التالي لإعادة تعيين كلمة المرور الخاصة بك</b> </a>" + "</center></td></tr>" +
       " </table>";

                    message1.Body = EmailBodyAgency(p1);
                }
                else if (type.Equals("initiative"))
                {
                    message1.CC.Add(new MailAddress("mubadarat@youth.gov.kw"));
                    message1.Body = "شكرا لكم .. تمت اضافة مبادرتك بنجاح " + " رقم التسلسل لمبادرتك هو" + " " + unique + " " + "للاستفسار عن المبادرات mubadarat@youth.gov.kw " + " :";
                }
                else if (type.Equals("ADASA"))
                {
                    string p1 = string.Empty;
                    message1.CC.Add(new MailAddress("m.alhulail@youth.gov.kw"));
                    p1 = "شكرا لكم على التسجيل في مسابقة التصوير الفوتوغرافي للمبتدأين من طلبة الثانوية العامة  " + "<br>" + " رقم الطلب" + ": " + unique + " <br>" + "في حال وجود أي استفسار" + "<br>" + "يرجى التواصل على الرقم التالي :1880003";
                    message1.Body = EmailBodyAgency(p1); ;
                }
                else if (type.Equals("ENT"))
                {
                    message1.CC.Add(new MailAddress("entrepreneurs@youth.gov.kw"));
                    string text = "<strong>" + "لقد تم التسجيل بنجاح و سيتم التواصل معكم بأقرب وقت" + "</strong>";
                    message1.Body = EmailBodyAgency(text);
                }
                else if (type.Equals("Training"))
                {
                    message1.CC.Add(new MailAddress("leaders@youth.gov.kw"));
                    string text = "شكرا لتسجيلكم في" + "(" + unique + ")" + " سيتم التواصل معكم من قبل إدارة البرنامج الوطني لإعداد وتأهيل القيادات الشابة";
                    message1.Body = EmailBodyAgency(text);
                }
                else if (type.Equals("initiativeTraining"))
                {
                    //message1.CC.Add(new MailAddress("leaders@youth.gov.kw"));
                    string text = " شكرا لتسجيلكم في نظام دعم الدورات والبرامج التدريبية والمؤتمرات سيتم التواصل معكم من قبل إدارة البرنامج الوطني لإعداد وتأهيل القيادات الشابة رقم المرجع " + "<br>" + "  رقم الطلب" + " " + unique + " ";
                    message1.Body = EmailBodyAgency(text);
                }
 		else if (type.Equals("LawEmail"))
                {
                  
                    string text = " <center> <strong>" + "لقد تم تسجيل بياناتك" + "</center> </strong>";
                    message1.Body = EmailBodyAgency(text);
                }
                else if (type.Equals("Ministry"))
                {
                    message1.CC.Add(new MailAddress("a.alansari@youth.gov.kw"));
                    string text =" <center> <strong>"+ "لقد تم تسجيل بياناتك"+ "</center> </strong>";
                    message1.Body = EmailBodyAgency(text);
                }
                else if (type.Equals("initiativeEditEmailConfirmation"))
                {
                    message1.CC.Add(new MailAddress("mubadarat@youth.gov.kw"));
                    message1.CC.Add(new MailAddress(unique));

                    string text = " تم التعديل بنجاح <br />  " + " شكرا لتعاونكم ";
                    message1.Body = EmailBodyAgency(text);
                } 
                else if (type.Equals("ace"))
                {
                    message1.Body = "شكراً لتقدمك بطلب الحصول على جائزة الكويت للتميز والإبداع الشبابي   " + "<br>" + "  رقم الطلب" + " " + unique + " " + "التواصل على البريد الإلكتروني التالي :ace@youth.gov.kw" + " :";
                }
                 else if (type.Equals("summer"))
                {
                    message1.CC.Add(new MailAddress("f.almejadi@youth.gov.kw"));
                    message1.Body = "تم استلام طلبك بنجاح" + "<br>" + "شكرا لك على التسجيل" + "  " + "رقم المرجع الخاص بك هو" + " " + unique + " ";
                }
                else if (type.Equals("YPIinitiative"))
                {
                    // message1.CC.Add(new MailAddress("webdeveloper@youth.gov.kw"));
                    string text = "شكرا لكم .. تمت اضافة   المبادر المحترفبنجاح ";
                    message1.Body = EmailBodyAgency(text);
                }
                else if (type.Equals("volounteering"))
                {

                    string text = "شكرا ، لقد تم تسجيلك بنجاح ، سوف يتم الإتصال بك لاحقا ";
                    message1.Body = EmailBodyAgency(text);
                }
                else if (type.Equals("SYC"))
                {

                    string text = "شكرا ، لقد تم تسجيلك بنجاح ، سوف يتم الإتصال بك لاحقا ";
                    message1.Body = EmailBodyAgency(text);
                }
                else if (type.Equals("FMCEmail"))
                {

                    string text = "شكرا ، لقد تم تسجيلك بنجاح ، سوف يتم الإتصال بك لاحقا ";
                    message1.Body = EmailBodyAgency(text);
                }
                else if (type.Equals("yca2020"))
                {
				   string text="";
				  
                   if(unique.Equals("0"))
                   {
                      text = "شكرا جزيلا لقد تم تسجيلك بنجاح، كما يمكنك تعديل بياناتك لاحقا" ;
                   }
                   else{
                     text = "شكرا جزيلا لقد تم التعديل بنجاح" ;}
				  
                     message1.Body = EmailBodyAgency(text);
                }
                else
                {
                    url = "https://www.youth.gov.kw/Volunteer/resetPassword.aspx?rid=" + unique;

                    message1.Body = "الرجاء الضغط على الرابط التالي لإعادة تعيين كلمة المرور الخاصة بك" + " :" + url;
                }

            }
            else
            {

                 string text = "تشكر لكم ادارة العمل التطوعي تسجيلكم في بوابة ايادينا وسيتم التواصل معكم في حين تسجيلكم في الفرص التطوعية القادمة المعلنة في البوابة" + "<br>" + "بتطوعكم ترقى الكويت";

                message1.Body = EmailBodyAgency(text); 
            }
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
                i = 0; //sucess
            }
            catch (Exception ex)
            {
                i = 1;
            }

        }
        return i;
    }
 public string EmailBodyAgency(string messagebody)
    {
        string body = string.Empty;
        string text = "";
        text = messagebody;

        using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("../emailGeneral.html")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{work}", text);
        return body;
    }
    public string ComputeHash(string plainText, string civiid, string hashAlgorithm, byte[] saltBytes)
    {
        // If salt is not specified, generate it.
        if (saltBytes == null)
        {
            // Define min and max salt sizes.
            int minSaltSize = 4;
            int maxSaltSize = 8;

            // Generate a random number for the size of the salt.
            Random random = new Random();
            int saltSize = random.Next(minSaltSize, maxSaltSize);

            // Allocate a byte array, which will hold the salt.
            saltBytes = new byte[saltSize];

            // Initialize a random number generator.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            // Fill the salt with cryptographically strong byte values.
            rng.GetNonZeroBytes(saltBytes);
        }

        // Convert plain text into a byte array.
        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText + civiid);

        // Allocate array, which will hold plain text and salt.
        byte[] plainTextWithSaltBytes =
        new byte[plainTextBytes.Length + saltBytes.Length];

        // Copy plain text bytes into resulting array.
        for (int i = 0; i < plainTextBytes.Length; i++)
            plainTextWithSaltBytes[i] = plainTextBytes[i];

        // Append salt bytes to the resulting array.
        for (int i = 0; i < saltBytes.Length; i++)
            plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];

        HashAlgorithm hash;

        // Make sure hashing algorithm name is specified.
        if (hashAlgorithm == null)
            hashAlgorithm = "";

        // Initialize appropriate hashing algorithm class.
        switch (hashAlgorithm.ToUpper())
        {

            case "SHA384":
                hash = new SHA384Managed();
                break;

            case "SHA512":
                hash = new SHA512Managed();
                break;

            default:
                hash = new MD5CryptoServiceProvider();
                break;
        }

        // Compute hash value of our plain text with appended salt.
        byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

        // Create array which will hold hash and original salt bytes.
        byte[] hashWithSaltBytes = new byte[hashBytes.Length +
        saltBytes.Length];

        // Copy hash bytes into resulting array.
        for (int i = 0; i < hashBytes.Length; i++)
            hashWithSaltBytes[i] = hashBytes[i];

        // Append salt bytes to the result.
        for (int i = 0; i < saltBytes.Length; i++)
            hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

        // Convert result into a base64-encoded string.
        string hashValue = Convert.ToBase64String(hashWithSaltBytes);

        // Return the result.
        return hashValue;
    }

    public bool VerifyHash(string plainText, string civilid, string hashAlgorithm, string hashValue)
    {

        // Convert base64-encoded hash value into a byte array.
        byte[] hashWithSaltBytes = Convert.FromBase64String(hashValue);

        // We must know size of hash (without salt).
        int hashSizeInBits, hashSizeInBytes;

        // Make sure that hashing algorithm name is specified.
        if (hashAlgorithm == null)
            hashAlgorithm = "";

        // Size of hash is based on the specified algorithm.
        switch (hashAlgorithm.ToUpper())
        {

            case "SHA384":
                hashSizeInBits = 384;
                break;

            case "SHA512":
                hashSizeInBits = 512;
                break;

            default: // Must be MD5
                hashSizeInBits = 128;
                break;
        }

        // Convert size of hash from bits to bytes.
        hashSizeInBytes = hashSizeInBits / 8;

        // Make sure that the specified hash value is long enough.
        if (hashWithSaltBytes.Length < hashSizeInBytes)
            return false;

        // Allocate array to hold original salt bytes retrieved from hash.
        byte[] saltBytes = new byte[hashWithSaltBytes.Length - hashSizeInBytes];

        // Copy salt from the end of the hash to the new array.
        for (int i = 0; i < saltBytes.Length; i++)
            saltBytes[i] = hashWithSaltBytes[hashSizeInBytes + i];

        // Compute a new hash string.
        string expectedHashString = ComputeHash(plainText, civilid, hashAlgorithm, saltBytes);

        // If the computed hash matches the specified hash,
        // the plain text value must be correct.
        return (hashValue == expectedHashString);
    }

    //session encryption

    public string EncodeSessionToBase64(string session)
    {
        try
        {
            byte[] encData_byte = new byte[session.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(session);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }
        catch (Exception ex)
        {
            throw new Exception("Error in base64Encode" + ex.Message);
        }
    }

    public string DecodeFrom64(string encodedData)
    {
        System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
        System.Text.Decoder utf8Decode = encoder.GetDecoder();
        byte[] todecode_byte = Convert.FromBase64String(encodedData);
        int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
        char[] decoded_char = new char[charCount];
        utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
        string result = new String(decoded_char);
        return result;
    }

    public string SessionDecrypt(string stringToDecrypt, string sEncryptionKey)
    {
        byte[] key = { };
        byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };
        //Private IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}

        byte[] inputByteArray = new byte[stringToDecrypt.Length];
        try
        {
            key = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(stringToDecrypt);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            Encoding encoding = Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }

    //public static string Encrypt(string stringToEncrypt,
    public string SessionEncrypt(string stringToEncrypt, string sEncryptionKey)
    {
        byte[] key = { };
        byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };
        byte[] inputByteArray; //Convert.ToByte(stringToEncrypt.Length)
        try
        {
            key = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            return Convert.ToBase64String(ms.ToArray());
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }
    public void fileuploadDetails(FileUpload upd, string type, string usersessionid, string ExtError, string MimeTypeError, string module, string BasicError, Boolean status, string action)
    {
        string extn = Path.GetExtension(upd.PostedFile.FileName.ToString());
        string filetype = upd.PostedFile.ContentType.ToString();

        int fileLen;


        fileLen = upd.PostedFile.ContentLength;
        byte[] input = new byte[25];
        if (fileLen > 1)
        {
            input = new byte[fileLen - 1];
            input = upd.FileBytes;
            input = upd.FileBytes.Take(16).ToArray();


        }
        string ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]; // get IP address
        if (!string.IsNullOrEmpty(ipAddress))
        {
            string[] ipRange = ipAddress.Split(',');
            int le = ipRange.Length - 1;
            string trueIP = ipRange[le];
        }
        else
        {
            ipAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        try
        {
            cnn.ConnectionString = gm.ConnectionString();
            cnn.Open();
            string query = "fileUploadInfo";
            SqlCommand com = new SqlCommand(query, cnn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@usersessionid", SqlDbType.NVarChar).Value = usersessionid;
            com.Parameters.AddWithValue("@filename", SqlDbType.NVarChar).Value = upd.PostedFile.FileName.ToString();
            com.Parameters.AddWithValue("@filetype", SqlDbType.NVarChar).Value = filetype;
            com.Parameters.AddWithValue("@extension", SqlDbType.NVarChar).Value = extn;
            com.Parameters.AddWithValue("@ipaddress", SqlDbType.NVarChar).Value = ipAddress;
            com.Parameters.AddWithValue("@extenssionError", SqlDbType.NVarChar).Value = ExtError;
            com.Parameters.AddWithValue("@expectedType", SqlDbType.NVarChar).Value = type;
            com.Parameters.AddWithValue("@MimeError", SqlDbType.NVarChar).Value = MimeTypeError;
            com.Parameters.AddWithValue("@date", SqlDbType.NVarChar).Value = DateTime.Now;
            com.Parameters.AddWithValue("@module", SqlDbType.NVarChar).Value = module;
            com.Parameters.AddWithValue("@basicError", SqlDbType.NVarChar).Value = BasicError;
            com.Parameters.AddWithValue("@status", SqlDbType.Bit).Value = status;
            com.Parameters.AddWithValue("@action", SqlDbType.NVarChar).Value = action;
            com.Parameters.AddWithValue("@fileinbyte", input);

            com.ExecuteNonQuery();

        }
        catch (Exception ex)
        {

        }
        cnn.Close();
    }
    public string EmailBodyReminder(string dropdown, string useremail, DateTime postdate, string id)
    {
        string body = string.Empty;

        string text = "";

        if (dropdown.Equals("استكمال مستندات"))
        {
            text = " عزيزي مقدم الطلب" + "," + "<br>" +
                "،،تحيه طيبة وبعد  " + "<br>" +
                "نشكركم على تقديم طلبكم لمكتب وزير الدولة لشئون الشباب ،بانتظار استكمال المستندات المطلوبة بموعد أقصاه 20 يوما من تاريخ اخطارك بها ." + "<br>" +

            "<span style='float: left;'>ولكم منا جزيل الشكر والتقدير</span>";
        }
        else if (dropdown.Equals("تذكير-استكمال مستندات"))
        {
            text = " عزيزي مقدم الطلب" + "," + "<br>" +
                "،، تحيه طيبة وبعد " + "<br>" +
                "نفيدكم علما باننا مازلنا بانتظار المستندات المطلوبة يرجى موافاتنا بها بصفة الاستعجال " + "<br>" +
               "<span style='float: left;'>ولكم منا جزيل الشكر والتقدير</span>";
        }
        else if (dropdown.Equals("تم استلام المستندات"))
        {
            text = " عزيزي مقدم الطلب" + "," + "<br>" +
                "،، تحيه طيبة وبعد " + "<br>" +
                "نفيدكم علما بانه تم استلام المستندات المطلوبة بنجاح، المشروع في طور الدراسة وسيتم التواصل معك في حال وجود استفسارات أخرى، والرد عليك بالسرعه الممكنة " +
                 "<span style='float: left;line-height: 4;'>ولكم منا جزيل الشكر والتقدير</span>";
        }
        else if (dropdown.Equals("تم الموافقة"))
        {
            text = " عزيزي مقدم الطلب" + "," + "<br>" +
                "،، تحيه طيبة وبعد " + "<br>" +
                " :تم عرض طلبكم على لجنة التقييم المختصة في مكتب وزير الدولة لشئون الشباب، ويسرنا إبلاغكم بأنه قد تمت الموافقة على طلبكم، لذا يرجى تزويدنا بالآتي" + "<br>" +

                "<span style='direction:rtl;float:none;margin:20px 0;line-height: 3;'>" + "1" + " صورة من البطاقة المدنية للفرد/صورة من المعلومات المدنية في حال تقديم الطلب من قبل الجهة" + "<br> </span>" +

               "<span style='direction:rtl; float:none;text-align:justify; margin:20px 0;'>" + "2 " + "صورة من الحساب البنكي  IBAN  للفرد/ ورقة" + " معتمدة من البنك في حال تقديم الطلب من قبل الجهة" + "<br></span><br> " +


                ".مع ضرورة مراجعتنا في مقر مكتب وزير الدولة لشئون الشباب- برج الحمراء - الدور الثالث عشر إدارة المبادرات والمشاريع، وذلك خلال سبعة أيام عمل من تاريخه ليتسنى لنا عمل اللازم" + "<br>" +

               "<span style='float: left;line-height: 4;'>ولكم منا جزيل الشكر والتقدير</span>";
        }
        else if (dropdown.Equals("تم الرفض"))
        {
            //show the number
            text = " عزيزي مقدم الطلب" + "," + "<br>" +
               "،، تحيه طيبة وبعد " + "<br>" +
               ".نشكركم على تقديم طلبكم لمكتب وزير الدولة لشئون الشباب ونود إبلاغكم بأنه قد تم عرض طلبكم على لجنة التقييم المختصة بمكتب وزير الدولة لشئون الشباب" + "<br>" +
               " وبناءً على ذلك نود الإعتذار عن عدم قبول طلبكم رقم " + "(" + id + ")" + "<br>" +
               "<span style='float: left;line-height: 4;'>ولكم منا جزيل الشكر والتقدير</span>";
        }
        else if (dropdown.Equals("تذكير-طلب حضور"))
        {

            text = " عزيزي مقدم الطلب" + "," + "<br>" +
                "،، تحيه طيبة وبعد " + "<br>" +
                "بناءً على سابق البريد الالكتروني بتاريخ " + postdate.Date.ToShortDateString() + " ،والذي تضمن انه قد تم عرض طلبكم على لجنة التقييم وتم الموافقة عليه، يرجى مراجعة مكتب وزير الدولة لشئون الشباب –برج الحمراء-الدور الثالث عشر إدارة المبادرات والمشاريع، خلال أسبوعين من تاريخه ليتسنى لنا عمل اللازم ،والا سيتم إلغاء الموافقة على الدعم وفق نص المادة رقم (11) من القرار الوزاري رقم (57) لسنة 2016 بشأن لائحة تنظيم دعم المشاريع والفعاليات الشبابية والمكافات والجوائز." +
                 "<br>" +
               "<span style='float: left;line-height: 4;'>ولكم منا جزيل الشكر والتقدير</span>";
        }
        else if (dropdown.Equals("الغاء- عدم حضور"))
        {

            text = " عزيزي مقدم الطلب" + "," + "<br>" +
                "،، تحيه طيبة وبعد " + "<br>" +
                "بناءً على سابق البريد الالكتروني، بتاريخ " + postdate.Date.ToShortDateString() + "," + postdate.Date.AddDays(6).ToShortDateString() + "، الذي تضمن انه قد تم عرض طلبكم على لجنة التقييم وتم الموافقة عليه.ونظرا لعدم مراجعة مكتب وزير الدولة لشئون الشباب –برج الحمراء- الدور الثالث عشر إدراة المبادرات والمشاريع،وذلك خلال المواعيد التي تم تحديدها لكم." +
                "نحيكم علما بانه قد تقرر إلغاء الدعم وذلك وفق نص المادة(11) من القرار الوزاري رقم (57) لسنة 2016 بشأ ن لائحة تنظيم دعم المشاريع والفعاليات الشبابية والمكافات والجوائز " +
                "<br>" +
               "<span style='float: left;line-height: 4;'>ولكم منا جزيل الشكر والتقدير</span>";

        }


        using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("emailOther.html")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{work}", text);

        return body;
    }
}


