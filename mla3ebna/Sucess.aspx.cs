using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.fss.plugin;
using System.Net;
using System.IO;
using System.Net.Mail;
using QRCoder;
using System.Drawing;

public partial class Sucess : System.Web.UI.Page
{
    MGeneral clsGeneral = new MGeneral();
    string GstrDbKey = "MalebnaDB";


  
    protected void Page_Load(object sender, EventArgs e)
    {
       // GenerateQR("Youth", "278052706124", "2020-09-10 00:00:00.000", "4:00PM - 5:00PM", "مدرسة ابن رشد الابتدائية - ملعب ١", "1734");
      //  FillData();      
       
            KentData();
        
    }




    protected void KentData()
    {
       
        iPayPipe pipe = new iPayPipe();


        //String resourcePath = "c:\\resourcepath";
        //String keystorePath = "c:\\keystorePath";

        String resourcePath = Server.MapPath("~\\resourcepath").ToString();
        String keystorePath = Server.MapPath("~\\keystorePath").ToString();

        //String aliasName = "youth";
        string aliasName = "mala3ib";
        pipe.setResourcePath(resourcePath);
        pipe.setKeystorePath(keystorePath);
        pipe.setAlias(aliasName);        
        int result = pipe.parseEncryptedRequest(Request.QueryString["trandata"]);
        if (result != 0)
        {
           // Response.Write("ErrorData From pipe:  " + pipe.getError().ToString());           
           
            pipe.getError();
        }
        else
        {
            string errorText = pipe.getError_text();

            if (errorText == null)
            {                
                string getresult = pipe.getResult();
                string date = pipe.getDate();
                string refID = pipe.getRef();
                string trackID = pipe.getTrackId();
                string transactionID = pipe.getTransId();
                string amount = pipe.getAmt();
                string udf1 = pipe.getUdf1();
                string udf2 = pipe.getUdf2();
                string udf3 = pipe.getUdf3();
                string udf4 = pipe.getUdf4();
                string udf5 = pipe.getUdf5();
                string paymentID = pipe.getPaymentId();
                string orderID = "";
                string auth = pipe.getAuth();

                string code = udf5;
              //  Response.Write(code);
                   // Response.Write(getresult);
                    DataTable dt = Insert_Payment_Details(paymentID, getresult, date, transactionID, refID, trackID, auth, orderID,code);
                   
                    if (dt.Rows.Count > 0)
                    {
                        DataColumnCollection columns = dt.Columns;
                        if (columns.Contains("message"))
                        {

                        }
                        else
                        {

                            if (getresult.Trim() == "CAPTURED")
                            {
                                lblHead.Text = "عملية الدفع ناجحة ...";

                                if (!dt.Rows[0]["EmailStatus"].ToString().Trim().Equals("1"))
                                {
                                    string ImagSrc = GeBookingQR(dt.Rows[0]["BookingID"].ToString().Trim());
                                    ImgBookingQRCode.Src = ImagSrc;
                                    int i = GeneralEmail(dt, paymentID, refID, trackID, ImagSrc);
                                    EmailStatus(paymentID, refID, trackID);
                                
                                    // GenerateQR(dt.Rows[0]["cName"].ToString().Trim(), dt.Rows[0]["CivilID"].ToString(), dt.Rows[0]["selDate"].ToString(), dt.Rows[0]["selTime"].ToString(), dt.Rows[0]["StadiumName"].ToString(), dt.Rows[0]["BookingID"].ToString());
                                }
                                SpanNotSuccess.Visible = false;

                            }
                            else if (getresult.Trim() == "NOT+CAPTURED")
                            {
                                lblHead.Text = "عملية الدفع غير ناجحة ...";
                                if (!dt.Rows[0]["EmailStatus"].ToString().Trim().Equals("1"))
                                {
                                    int i = GeneralEmailFail(dt, paymentID, refID, trackID);
                                    EmailStatus(paymentID, refID, trackID);
                                }
                                SpanNotSuccess.Visible = true;
                            }

                            lblPaymentStatus.Text = getresult;
                            lblngPayId.Text = paymentID;

                            lbltrackID.Text = trackID;
                            lblrefNum.Text = refID;

                            lblPaymentDate.Text = dt.Rows[0]["PaymentDate"].ToString();
                            lblcName.Text = dt.Rows[0]["cName"].ToString();
                            lblStadiumName.Text = dt.Rows[0]["StadiumName"].ToString();
                            lbladdress.Text = dt.Rows[0]["address"].ToString();
                            lblselTime.Text = dt.Rows[0]["selTime"].ToString();
                            lblSelDate.Text = Convert.ToDateTime(dt.Rows[0]["SelDate"].ToString()).ToShortDateString();
                            lblRate.Text = dt.Rows[0]["Rate"].ToString();                            

                        }

                       

                    }
            
                
            }
            else
            {

                lblPaymentStatus.Text = pipe.getError_text();
                lblngPayId.Text = pipe.getPaymentId();


                string geterrorText = pipe.getError_text(); ;
                string payment = pipe.getPaymentId();
                string error = pipe.getError();    
              
                string trackID = pipe.getTrackId();
                string transactionID = pipe.getTransId();  // actually they have given here trackid in the documantation
                string amount = pipe.getAmt();
                string udf1 = pipe.getUdf1();
                string udf2 = pipe.getUdf2();
                string udf3 = pipe.getUdf3();
                string udf4 = pipe.getUdf4();
                string udf5 = pipe.getUdf5();
                string paymentID = pipe.getPaymentId();                
                string auth = pipe.getAuth();
            }
        }
    }


    protected void EmailStatus(string paymentID,string refID,string trackID)
    {
        //
        DataSet DS = new DataSet();
        DS = clsGeneral.GetDS("EXEC SP_BookingEmailStatusChange " + paymentID +","+refID+","+trackID, GstrDbKey, "Table", true);

    }

    protected int PaymentEnquiry(string trackid, string amount, string transId)
    {
        iPayPipe pipe = new iPayPipe();


        //String resourcePath = "c:\\resourcepath";
        //String keystorePath = "c:\\keystorePath";



        string resourcePath = Server.MapPath("~\\resourcepath").ToString();
        string keystorePath = Server.MapPath("~\\keystorePath").ToString();


        string action = "8";
        String alias = "youth";

        string currency = "414";

        pipe.setResourcePath(resourcePath);
        pipe.setKeystorePath(keystorePath);
        pipe.setAlias(alias);
        pipe.setAction(action);
        pipe.setCurrency(currency);
        pipe.setAmt(amount);
        pipe.setTransId(transId);
        pipe.setTrackId(trackid);

        int val = pipe.performTransaction();
      

        return val;


    }

    //protected void GenerateQR(string username, string civilid, string date, string time, string stname, string bookingid)
    //{
    //    string code = "Youth Public Authority" + Environment.NewLine + "Mla3bna" + Environment.NewLine + " User Name:" + username + Environment.NewLine +
    //        "CivilID:" + civilid + Environment.NewLine + "Stadium Name:" + stname + Environment.NewLine + "BookingDate" + date + Environment.NewLine + "Booking Time:"+ time;

    //    var url = string.Format("https://chart.apis.google.com/chart?cht=qr&chs={1}x{2}&chl={0}", code, 150, 150);
    //    WebResponse response = default(WebResponse);
    //    Stream remoteStream = default(Stream);
    //    StreamReader readStream = default(StreamReader);
    //    WebRequest request = WebRequest.Create(url);
    //    response = request.GetResponse();
    //    remoteStream = response.GetResponseStream();
    //    readStream = new StreamReader(remoteStream);
    //    System.Drawing.Image img = System.Drawing.Image.FromStream(remoteStream);
    //    //img.Save("C:/inetpub/wwwroot/Youth.gov.kw/YCLC/imgQR/" + bookingid + ".png");
    //  //  img.Save("C:/inetpub/wwwroot/YouthNew/mla3ebna/imgQR/" + bookingid + ".png");
    //      img.Save(Server.MapPath("imgQR/" )+ bookingid + ".png");
    //    response.Close();
    //    remoteStream.Close();
    //    readStream.Close();

    //}


    public string GeBookingQR(string StrBookingID)
    {
        string strresult;
        strresult = "";
        string StrQRName;

        // Dim qrText As String = ConfigurationManager.AppSettings("StrQRCheckUrl") & "QRRequest.aspx?LicenseNo=" + Settings.DESEncrypt(StrLicenseNo_1) & ""
        string qrText = System.Configuration.ConfigurationManager.AppSettings["QRSiteUrl"]+ "BookingQRView.aspx?BookingID=" + StrBookingID + "";
        //QRCodeGenerator qrGenerator = new QRCodeGenerator();
        //QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
        //QRCode qrCode = new QRCode(qrCodeData);
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
        //pictureBoxQRCode.BackgroundImage = qrCode.GetGraphic(20);
        Bitmap qrCodeImage = qrCode.GetGraphic(20);
        // Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, (Bitmap)Bitmap.FromFile(Server.MapPath("images/MaleabnaLogo.png")));
        StrQRName = System.Configuration.ConfigurationManager.AppSettings["QRCodeBooking"] + StrBookingID + ".png";
        qrCodeImage.Save(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["QRCodeBooking"]) + StrBookingID + ".png");
       

        strresult = StrQRName;
        return strresult;
    }

    public DataTable Insert_Payment_Details(string ls_PaymentID, string ls_Result, string ls_PostDate, string ls_TranID, string ls_Ref, string ls_TrackID, string ls_Auth, string ls_OrderID,string code)
    {

        DataTable dt = new DataTable();


        DataInsertReturn dtr = new DataInsertReturn();

        string ls_bookuid;
        double ld_rate;
        int li_userid = 0;
        DataSet DS = new DataSet();
        try
        {

            Object obj;
            //li_userid = getUserid(ls_euid);

            int li_bookid;
            li_bookid = int.Parse(clsGeneral.GetQueryValue("select BookingId from MYA_Maleabna_Booking where BookingIDUniq='" + ls_TrackID + "'", GstrDbKey));
            li_userid = int.Parse(clsGeneral.GetQueryValue("select UserId from MYA_Maleabna_Booking where BookingIDUniq='" + ls_TrackID + "'", GstrDbKey));
            ld_rate = double.Parse(clsGeneral.GetQueryValue("select rate from MYA_Maleabna_Booking where BookingIDUniq='" + ls_TrackID + "'", GstrDbKey));
            string str = "";

            dtr = clsGeneral.ExecuteNonQueryReturn("EXEC SP_AddEdit_MYA_Maleabna_BookingPaymentDetails 'I'," + li_bookid + "," + li_userid + ",'" + ls_Result + "','" + ls_PaymentID + "','" + ls_TranID + "','" + ls_Ref + "','" + ls_PostDate + "','" + ls_Auth + "','" + ls_TrackID + "'," + ld_rate + ",'',1,'"+code+"'", GstrDbKey);
           // Response.Write(dtr.DataInsert.ToString());
            if (dtr.DataInsert == true)
            {
                DS = clsGeneral.GetDS("EXEC SP_MYA_Maleabna_GetBookingInfo_Final " + li_bookid, GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "No Data Found", 0);
                else
                    dt = DS.Tables[0];

            }
            else
            {
                dt = clsGeneral.msgResponse("", "Fail", dtr.ErrorMsg.Trim(), 0);
            }

        }
        catch (Exception ex)
        {
            dt = clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0);
        }
        finally
        {

        }

        return dt;

        #region old code

        //DataTable dt = new DataTable();


        //DataInsertReturn dtr = new DataInsertReturn();
       
        //string ls_bookuid;
        //double ld_rate;
        //int li_userid = 0;
        //DataSet DS = new DataSet();
        //try
        //{

        //    Object obj;
        //    //li_userid = getUserid(ls_euid);

        //    int li_bookid;
        //    li_bookid = int.Parse(clsGeneral.GetQueryValue("select BookingId from MYA_Maleabna_Booking where BookingIDUniq='" + ls_OrderID + "'", GstrDbKey));
        //    li_userid = int.Parse(clsGeneral.GetQueryValue("select UserId from MYA_Maleabna_Booking where BookingIDUniq='" + ls_OrderID + "'", GstrDbKey));
        //    ld_rate = double.Parse(clsGeneral.GetQueryValue("select rate from MYA_Maleabna_Booking where BookingIDUniq='" + ls_OrderID + "'", GstrDbKey));
        //    string str = "";
           
        //    dtr = clsGeneral.ExecuteNonQueryReturn("EXEC SP_AddEdit_MYA_Maleabna_BookingPaymentDetails 'I'," + li_bookid + "," + li_userid + ",'" + ls_Result + "','" + ls_PaymentID + "','" + ls_TranID + "','" + ls_Ref + "','" + ls_PostDate + "','" + ls_Auth + "','" + ls_TrackID + "'," + ld_rate + ",'',1", GstrDbKey);
        //    if (dtr.DataInsert == true)
        //    {
        //        DS = clsGeneral.GetDS("EXEC SP_MYA_Maleabna_GetBookingInfo_Final " + li_bookid, GstrDbKey, "Table", true);

        //        if (DS.Tables[0].Rows.Count == 0)
        //            dt = clsGeneral.msgResponse("", "True", "No Data Found", 0);
        //        else
        //            dt = DS.Tables[0];
              
        //    }
        //    else
        //    {
        //       dt = clsGeneral.msgResponse("", "Fail", dtr.ErrorMsg.Trim(), 0);
        //    }

        //}
        //catch (Exception ex)
        //{
        //    dt = clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0);
        //}
        //finally
        //{

        //}

        //return dt;
        #endregion
    }



    public DataTable GetBookingInfo(int stadetid, string ls_euid, string seldate, string seltime)
    {

        DataTable dt = new DataTable();
        DataSet DS = new DataSet();

        int li_userid = 0;

        li_userid = int.Parse(ls_euid); // getUserid(ls_euid);
        string str = "";
        if (seldate != "")
        {
            DateTime temp = DateTime.ParseExact(seldate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            str = temp.ToString("yyyy-MM-dd");
        }

        DS = clsGeneral.GetDS("EXEC SP_MYA_Maleabna_GetBookingInfo " + stadetid + "," + li_userid + ",'" + str + "','" + seltime + "'", GstrDbKey, "Table", true);

        dt = DS.Tables[0];

        return dt;
    }


    public static int GeneralEmailFail(DataTable dt, string payid, string refid, string trackID)
    {
        String email = dt.Rows[0]["Email"].ToString();
        int i = 0;

      
        if (!email.Equals(""))
        {
            MailMessage message1 = new MailMessage();
            message1.From = new MailAddress("web@youth.gov.kw", "Mla3bna Booking");
            message1.To.Add(new MailAddress(email));
            message1.Subject = "no-reply";

            message1.CC.Add(new MailAddress("web@youth.gov.kw"));
            message1.Body = EmailBodyGeneralFial(dt, payid, refid, trackID);

         
           
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


    public static int GeneralEmail(DataTable dt, string payid, string refid, string trackID, string qr)
    {

        string qrpath = System.Configuration.ConfigurationManager.AppSettings["QRSiteUrl"] + qr;
        String email = dt.Rows[0]["Email"].ToString();
        int i = 0;
        if (!email.Equals(""))
        {
            MailMessage message1 = new MailMessage();
            message1.From = new MailAddress("web@youth.gov.kw", "Mla3bna Booking");
            message1.To.Add(new MailAddress(email));
            message1.Subject = "no-reply";

            message1.CC.Add(new MailAddress("web@youth.gov.kw"));
            message1.Body = EmailBodyGeneral(dt,payid,refid,trackID);

            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(qrpath);
            message1.Attachments.Add(attachment);


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

    public static string EmailBodyGeneral(DataTable dt, string paymentID,string refID,string trackID)
    {
        string body = string.Empty;        
       
            StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("emailKnetPayment.html"));
            body = reader.ReadToEnd();

            body = body.Replace("{name}", dt.Rows[0]["cName"].ToString());
            body = body.Replace("{paymentID}", paymentID);
            body = body.Replace("{trackID}", trackID);
            body = body.Replace("{referenceID}", refID);
            body = body.Replace("{paydate}", dt.Rows[0]["PaymentDate"].ToString());
            body = body.Replace("{amount}", dt.Rows[0]["Rate"].ToString());
            body = body.Replace("{staname}", dt.Rows[0]["StadiumName"].ToString());
            body = body.Replace("{place}", dt.Rows[0]["address"].ToString());
            body = body.Replace("{btime}", dt.Rows[0]["selTime"].ToString());
            body = body.Replace("{bdate}", Convert.ToDateTime(dt.Rows[0]["SelDate"].ToString()).ToString("dd-MM-yyyy"));

        
        return body;
    }

    public static string EmailBodyGeneralFial(DataTable dt, string paymentID, string refID, string trackID)
    {
        string body = string.Empty;
      
            StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("emailKnetNotCapture.html"));
            body = reader.ReadToEnd();

            //body = body.Replace("{name}", dt.Rows[0]["cName"].ToString());
            body = body.Replace("{paymentID}", paymentID);
            body = body.Replace("{trackID}", trackID);
            body = body.Replace("{referenceID}", refID);
            body = body.Replace("{paydate}", dt.Rows[0]["PaymentDate"].ToString());
            body = body.Replace("{amount}", dt.Rows[0]["Rate"].ToString());
      
        return body;
    }



    //protected string getSearch(string parameter)
    //{
    //    string url;
    //    var search = 0;
    //    string[] parsed;
    //    int count;
    //    int loop;
    //    string searchPhrase;
    //    url = HttpContext.Current.Request.Url.AbsoluteUri;
    //    search = url.IndexOf("?");
    //    if (search < 0)
    //    {
    //        return "";
    //    }
    //    searchPhrase = parameter;
    //    parsed = url.Substring(search + 1).Split(new char[] { '&' });
    //    count = parsed.Length;
    //    for (loop = 0; loop < count; loop++)
    //    {
    //        string[] res = parsed[loop].Split(new char[] { '=' });
    //        if (res[0] == searchPhrase)
    //            return res[1];
    //    }
    //    return "";
    //}

    //protected string getKnetSearch(string parameter)
    //{
    //    string url;
    //    var search = 0;
    //    string[] parsed;
    //    int count;
    //    int loop;
    //    string searchPhrase;
    //    url = HttpContext.Current.Request.Url.AbsoluteUri;
    //    search = url.IndexOf("?");
    //    if (search < 0)
    //    {
    //        return "";
    //    }
    //    searchPhrase = parameter;  //+ "="
    //    parsed = url.Substring(search + 1).Split(new char[] { '&' });
    //    count = parsed.Length;
    //    for (loop = 0; loop < count; loop++)
    //    {
    //        string[] res = parsed[loop].Split(new char[] { '=' });
    //        if (res[0] == searchPhrase)
    //            return res[1];

    //    }
    //    return "";
    //}



    //protected string getSearch(string parameter)
    //{
    //    string url;
    //    var search=0;
    //    string[] parsed;
    //    int count;
    //    int loop;
    //    string searchPhrase;
    //    url = HttpContext.Current.Request.Url.AbsoluteUri;
    //    search = url.IndexOf("?");
    //    if (search < 0)
    //    {
    //        return "";
    //    }
    //    searchPhrase = parameter ;  //+ "="
    //    parsed = url.Substring(search + 1).Split(new char[] { '&' });
    //    count = parsed.Length;
    //    for (loop = 0; loop < count; loop++)
    //    {
    //        string[] res = parsed[loop].Split(new char[] { '=' });
    //        if (res[0] == searchPhrase)
    //            return res[1];

    //    }
    //    return "";
    //}

    //protected void FillData()
    //{
    //    lblPaymentStatus.Text = getSearch("Result");
    //    // string ngOrdId = getSearch("OrderID");
    //    lblngPayId.Text = getSearch("PaymentID");

    //    //if (getSearch("Result") == "CANCELED") {
    //    //    scope.ngPayHead = 'تم إلغاء الدفع ...'
    //    //} else {
    //    //    scope.ngPayHead = 'عملية الدفع غير ناجحة '
    //    //}
    //    string ls_PaymentID = getSearch("PaymentID");
    //    string ls_Result = getSearch("Result");
    //    string ls_PostDate = getSearch("PostDate");
    //    string ls_TranID = getSearch("TranID");
    //    string ls_Ref = getSearch("Ref");
    //    string ls_TrackID = getSearch("TrackID");
    //    string ls_Auth = getSearch("Auth");
    //    string ls_OrderID = getSearch("OrderID");

    //    DataTable dt = Insert_Payment_Details(ls_PaymentID, ls_Result, ls_PostDate, ls_TranID, ls_Ref, ls_TrackID, ls_Auth, ls_OrderID);
    //    if (dt.Rows.Count > 0)
    //    {
    //        DataColumnCollection columns = dt.Columns;
    //        if (columns.Contains("message"))
    //        {

    //        }
    //        else
    //        {
    //            lblPaymentDate.Text = dt.Rows[0]["PaymentDate"].ToString();
    //            lblcName.Text = dt.Rows[0]["cName"].ToString();
    //            lblStadiumName.Text = dt.Rows[0]["StadiumName"].ToString();
    //            lbladdress.Text = dt.Rows[0]["address"].ToString();
    //            lblselTime.Text = dt.Rows[0]["selTime"].ToString();                
    //            lblSelDate.Text = dt.Rows[0]["SelDate"].ToString();
    //            lblRate.Text = dt.Rows[0]["Rate"].ToString();
    //        }

    //    }
    //}

    protected void btnCancel_Click(object sender, EventArgs e)
    {
       // Session.Abandon();
        Response.Redirect("index.aspx", false);
    }
}