using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using CryptSharp;
using System.Net.Mail;

namespace MYA_Maleabna_WebService
{
    /// <summary>
    /// Summary description for Test
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MYAM : System.Web.Services.WebService
    {

        string GstrDbKey = "MalebnaDB";
        General clsGeneral = new General();
        public MYAM()
        {

            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }




        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_Load_Banner()
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {

                DS = clsGeneral.GetDS("select Title, BannerImage as BannerImage from MYA_Maleabna_Banner where Status=1 order by sort", GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
                else
                    dt = DS.Tables[0];
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_MYA_Maleabna_Area(string ls_passvalue, string ld_data)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {
                string str_date = "";
                if (ld_data != "")
                {
                    DateTime temp = DateTime.ParseExact(ld_data, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    str_date = temp.ToString("yyyy-MM-dd");
                }

                DS = clsGeneral.GetDS("exec SP_Get_MYA_Maleabna_Area '" + ls_passvalue + "','" + str_date + "'", GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
                else
                    dt = DS.Tables[0];
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }

        //postData += "&success_url=" + Uri.EscapeDataString("https://www.youth.gov.kw/Malebna/Sucess"); // url where you want to redirect user after successful of payment

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void PaymentIntegrationTest(string ls_euid)
        {
            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string ls_bookuid = "";
            double ld_amt = 0;
            int li_userid = 0;
            try
            {
                li_userid = getUserid(ls_euid);
                ls_bookuid = clsGeneral.GetQueryValue("select top 1 BookingIDUniq from MYA_Maleabna_Booking where userid= " + li_userid + "order by BookingID desc", GstrDbKey);
                ld_amt = double.Parse(clsGeneral.GetQueryValue("select top 1 rate from MYA_Maleabna_Booking where userid= " + li_userid + "order by BookingID desc", GstrDbKey));

                if (!ls_bookuid.Equals(""))
                {
                    String CurrentTimestamp = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds.ToString();
                    String order_id = CurrentTimestamp.Replace(".", string.Empty);

                    var request = (HttpWebRequest)WebRequest.Create("https://api.upayments.com/test-payment");

                    var postData = "merchant_id=" + Uri.EscapeDataString("1201");
                    postData += "&username=" + Uri.EscapeDataString("test");
                    postData += "&password=" + Uri.EscapeDataString("test");
                    postData += "&api_key=" + Uri.EscapeDataString("jtest123");
                    postData += "&order_id=" + Uri.EscapeDataString(ls_bookuid);
                    postData += "&total_price=" + Uri.EscapeDataString(ld_amt.ToString());
                    postData += "&success_url=" + Uri.EscapeDataString("https://mubaratna.com/Sucess"); // url where you want to redirect user after successful of payment
                    postData += "&error_url=" + Uri.EscapeDataString("https://mubaratna.com/Fail"); // url where you want to redirect user after failed payment
                    postData += "&notifyURL=" + Uri.EscapeDataString("https://mubaratna.com/notifyURL.html"); // url we are sending response to this webhook once payment done by payment gateway so you don't need to wait for response 
                    var data = System.Text.Encoding.ASCII.GetBytes(postData);

                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = data.Length;

                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }

                    var response = (HttpWebResponse)request.GetResponse();

                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    //JObject jObject = JObject.Parse(responseString); // converting response in JSON

                    // here you have to check for error or not

                    //string paymentURL = jObject["paymentURL"].ToString();
                    //Console.WriteLine((responseString)); // it is payment URL.
                    //Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));

                    ///Context.Response.Redirect(responseString);
                    Context.Response.Write(responseString);
                }
                else
                {
                    Context.Response.Write("Invalid BookingId");
                }

                //Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", responseString, 0))));

            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void PaymentIntegration(string ls_euid)
        {
            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string ls_bookuid = "";
            double ld_amt = 0;
            int li_userid = 0;
            try
            {
                li_userid = getUserid(ls_euid);
                ls_bookuid = clsGeneral.GetQueryValue("select top 1 BookingIDUniq from MYA_Maleabna_Booking where userid= " + li_userid + "order by BookingID desc", GstrDbKey);
                ld_amt = double.Parse(clsGeneral.GetQueryValue("select top 1 rate from MYA_Maleabna_Booking where userid= " + li_userid + "order by BookingID desc", GstrDbKey));

                if (!ls_bookuid.Equals(""))
                {
                    String CurrentTimestamp = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds.ToString();
                    String order_id = CurrentTimestamp.Replace(".", string.Empty);

                    var request = (HttpWebRequest)WebRequest.Create("https://api.upayments.com/payment-request");
                    string cryptedPassword = Crypter.Blowfish.Crypt("cj5BljENoC2gukbhYna9Y9TnjvJT5Ugu8cm6U0N4");

                    var postData = "merchant_id=" + Uri.EscapeDataString("4448");
                    postData += "&username=" + Uri.EscapeDataString("maha_4448");
                    postData += "&password=" + Uri.EscapeDataString("q#7wd!bhJ9qFxbR4");
                    postData += "&api_key=" + Uri.EscapeDataString(cryptedPassword);
                    postData += "&order_id=" + Uri.EscapeDataString(ls_bookuid);
                    postData += "&total_price=" + Uri.EscapeDataString(ld_amt.ToString());
                    postData += "&success_url=" + Uri.EscapeDataString("https://mubaratna.com/Sucess"); // url where you want to redirect user after successful of payment
                    postData += "&error_url=" + Uri.EscapeDataString("https://mubaratna.com/Fail"); // url where you want to redirect user after failed payment
                    postData += "&notifyURL=" + Uri.EscapeDataString("https://mubaratna.com/notifyURL.html"); // url we are sending response to this webhook once payment done by payment gateway so you don't need to wait for response 
                    var data = System.Text.Encoding.ASCII.GetBytes(postData);

                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = data.Length;

                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }

                    var response = (HttpWebResponse)request.GetResponse();

                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();


                    Context.Response.Write(responseString);
                }
                else
                {
                    Context.Response.Write("Invalid BookingId");
                }
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }
        }


        //[WebMethod(EnableSession = true)]
        //[ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        //public void Get_MYA_Maleabna_School()
        //{

        //    DataTable dt = new DataTable();
        //    DataSet DS = new DataSet();
        //    JavaScriptSerializer js = new JavaScriptSerializer();

        //    try
        //    {
        //        DS = clsGeneral.GetDS("exec SP_Get_MYA_Maleabna_School", GstrDbKey, "Table", true);

        //        if (DS.Tables[0].Rows.Count == 0)
        //            dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
        //        else
        //            dt = DS.Tables[0];
        //        Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
        //    }
        //    catch (Exception ex)
        //    {
        //        Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
        //    }
        //    finally
        //    {

        //    }

        //}


        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_MYA_Maleabna_Stadium(string ls_passvalue, string ld_data)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {
                string str_date = "";
                if (ld_data != "")
                {
                    DateTime temp = DateTime.ParseExact(ld_data, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    str_date = temp.ToString("yyyy-MM-dd");
                }

                DS = clsGeneral.GetDS("exec SP_Get_MYA_Maleabna_Stadium '" + ls_passvalue + "','" + str_date + "'", GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
                else
                    dt = DS.Tables[0];
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }


        public void sms(string ph, string aaNme)
        {
            string mobile = ph;

            int i = mobile.Length;
            if (!mobile.Equals("") && mobile.Length == 8)
            {
                string senderusername = "Youthkuwait";
                string senderpassword = "you.1234";
                string sender_id = "57";
                mobile = "965" + mobile;

                string message = "رمزك لمرة واحدة فقط هو " + aaNme;
                string sURL;


                StreamReader objReader;

                sURL = "https://kuwait.uigtc.com/capi/sms/send_sms?api_key=194.DC5E858062D052AC61C74CC176E91CC6BFD2B055CBF471&sender_id=" + sender_id + "&send_type=1&sms_content=" + message + "&numbers=" + mobile + "&unique=1";
                WebRequest wrGETURL;
                wrGETURL = WebRequest.Create(sURL);
                try
                {
                    Stream objStream;
                    objStream = wrGETURL.GetResponse().GetResponseStream();
                    objReader = new StreamReader(objStream);
                    objReader.Close();

                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }



        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void LoadPageContent(string ls_type)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();
            DataInsertReturn dtr = new DataInsertReturn();

            try
            {
                if (ls_type.Equals("About"))
                {
                    DS = clsGeneral.GetDS("select PageContent from MYA_Maleabna_PageContent where pid=1", GstrDbKey, "Table", true);
                }
                else if (ls_type.Equals("Policy"))
                {
                    DS = clsGeneral.GetDS("select PageContent from MYA_Maleabna_PageContent where pid=2", GstrDbKey, "Table", true);
                }
                else if (ls_type.Equals("Reservation"))
                {
                    DS = clsGeneral.GetDS("select PageContent from MYA_Maleabna_PageContent where pid=3", GstrDbKey, "Table", true);
                }
                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
                else
                {
                    dt = DS.Tables[0];
                }

                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void fn_CheckWholeSiteBlock(string ld_data)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();
            DataInsertReturn dtr = new DataInsertReturn();

            try
            {
                string str_date = "";
                if (ld_data != "")
                {
                    DateTime temp = DateTime.ParseExact(ld_data, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    str_date = temp.ToString("yyyy-MM-dd");
                }

                DS = clsGeneral.GetDS("select  DisplayMsg,convert(varchar,DateFrm, 106) as  DateFrm,  convert(varchar,DateTo, 106) as DateTo,'False' as Error from MYA_Maleabna_TimeSlot_Block where BlockBy='WholeSite' and '" + str_date + "' between DateFrm and DateTo and status=1", GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
                else
                {
                    dt = DS.Tables[0];
                }

                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void fn_LoadPopularStadium()
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();
            DataInsertReturn dtr = new DataInsertReturn();

            try
            {

                DS = clsGeneral.GetDS("select top 6 a.StadiumID,b.StadiumName,case when b.StadiumMainImage is null then 'images/qadsiya-stadium.jpg' else b.StadiumMainImage end as StadiumMainImage from MYA_Maleabna_Booking a join MYA_Maleabna_Stadium b on a.StadiumID=b.StadiumID order by bookingid desc", GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
                else
                {
                    dt = DS.Tables[0];
                }

                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_User_Profile(string ls_euid)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();
            DataInsertReturn dtr = new DataInsertReturn();
            int li_userid = 0;
            try
            {
                li_userid = getUserid(ls_euid);
                DS = clsGeneral.GetDS("select * from MYA_Maleabna_Members where userid=" + li_userid, GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
                else
                {
                    dt = DS.Tables[0];
                }


                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }

        private int getUserid(string ls_eid)
        {
            int li_userid;
            li_userid = int.Parse(clsGeneral.GetQueryValue("select userid from MYA_Maleabna_Members where UserUID='" + ls_eid + "' and status=1", GstrDbKey));
            return li_userid;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_User_Details(string ls_euid)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();
            DataInsertReturn dtr = new DataInsertReturn();
            int li_userid;
            try
            {
                //li_userid = getUserid(ls_euid);
                DS = clsGeneral.GetDS("select UserName from MYA_Maleabna_Members where useruid='" + ls_euid + "'", GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
                else
                {
                    dt = DS.Tables[0];
                }


                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_User_MyReservation(string ls_euid, string type)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();
            int li_userid = 0;
            try
            {
                li_userid = getUserid(ls_euid);
                DS = clsGeneral.GetDS("exec dbo.SP_Get_MyReservation " + li_userid + ",'" + type + "'", GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
                else
                {
                    dt = DS.Tables[0];
                }


                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_VerifyInfo(string email, string otp)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();
            DataInsertReturn dtr = new DataInsertReturn();

            try
            {
                DS = clsGeneral.GetDS("select * from MYA_Maleabna_Members where email='" + email + "' and otp='" + otp + "'", GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
                else
                {
                    dtr = clsGeneral.ExecuteNonQueryReturn("update MYA_Maleabna_Members set smsstatus=1,emailStatus=1 where email='" + email + "'", GstrDbKey);
                    dt = clsGeneral.msgResponse("", "True", "Verified", 0);
                }


                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Update_New_Pwd(string ls_euid, string password)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();
            DataInsertReturn dtr = new DataInsertReturn();
            string ls_civilid = "";
            string ls_usertype = "";
            try
            {
                if (clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Members where useruid='" + ls_euid + "'", GstrDbKey).Equals("0"))
                {
                    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("Something went wrong. Unable to continue..."), 0))));
                    return;
                }
                ls_usertype = clsGeneral.GetQueryValue("select usertype from MYA_Maleabna_Members where  useruid='" + ls_euid + "'", GstrDbKey);

                ls_civilid = clsGeneral.GetQueryValue("select civilid from MYA_Maleabna_Members where  useruid='" + ls_euid + "'", GstrDbKey);

                string ePass = clsGeneral.ComputeHash(Server.HtmlEncode(password.Trim()), Server.HtmlEncode(ls_civilid), "SHA512", null);

                if (ls_usertype == "New")
                {
                    dtr = clsGeneral.ExecuteNonQueryReturn("update MYA_Maleabna_Members set pwd='" + ePass + "' where useruid='" + ls_euid + "'", GstrDbKey);
                    dtr = clsGeneral.ExecuteNonQueryReturn("update moyakwt_YouthMain.dbo.User_Basic_Info set pwd='" + ePass + "' where useruid='" + ls_euid + "'", GstrDbKey);
                    dt = clsGeneral.msgResponse("", "Sucess", clsGeneral.GetSucTag("لقد تم تغيير كلمة المرور بنجاح ."), 0);
                }
                else if (ls_usertype == "Old")
                {
                    dtr = clsGeneral.ExecuteNonQueryReturn("update MYA_Maleabna_Members set usertype='New',smsstatus=1,emailstatus=1,smscount=0, pwd='" + ePass + "' where useruid='" + ls_euid + "'", GstrDbKey);
                    dtr = clsGeneral.ExecuteNonQueryReturn("update moyakwt_YouthMain.dbo.User_Basic_Info set pwd='" + ePass + "' where useruid='" + ls_euid + "'", GstrDbKey);
                    dt = clsGeneral.msgResponse("", "Sucess", clsGeneral.GetSucTag("لقد تم تفعيل حسابك بنجاح ."), 0);
                }
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void fn_ChangePwd(string ls_euid, string oldpassword, string newpassword)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();
            DataInsertReturn dtr = new DataInsertReturn();
            string ls_civilid = "";
            string ls_Epwd = "";
            int li_userid = 0;
            try
            {
                li_userid = getUserid(ls_euid);
                if (clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Members where userid='" + li_userid + "'", GstrDbKey).Equals("0"))
                {
                    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("Something went wrong. Unable to continue..."), 0))));
                    return;
                }


                ls_civilid = clsGeneral.GetQueryValue("select civilid from MYA_Maleabna_Members where  userid='" + li_userid + "'", GstrDbKey);
                ls_Epwd = clsGeneral.GetQueryValue("select pwd from MYA_Maleabna_Members where  userid='" + li_userid + "'", GstrDbKey);
                bool flag = clsGeneral.VerifyHash(oldpassword.Trim(), ls_civilid, "SHA512", ls_Epwd);
                if (flag == true)
                {
                    string ePass = clsGeneral.ComputeHash(Server.HtmlEncode(newpassword.Trim()), Server.HtmlEncode(ls_civilid), "SHA512", null);

                    dtr = clsGeneral.ExecuteNonQueryReturn("update MYA_Maleabna_Members set pwd='" + ePass + "' where userid='" + li_userid + "'", GstrDbKey);
                    dt = clsGeneral.msgResponse("", "True", "Password Changed", 0);

                    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
                }
                else
                {
                    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("كلمة المرور القديمة غير صحيحة ."), 0))));
                    return;
                }

            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }


        //public string SNLDate(object vExpr, bool AllowNull = true)
        //{
        //    try
        //    {
        //        if (IsDBNull(vExpr))
        //        {
        //            if (AllowNull == true)
        //                return null;
        //            else
        //                SNLDate = String.Format((DateTime)DateTime.Now, "MM/dd/yyyy");
        //        }
        //        else
        //            // If IsDate(Trim(vExpr)) Then
        //            if (Strings.Format(vExpr, "dd/MM/yyyy") == "01/01/1900" | Strings.Format(vExpr, "dd/MM/yyyy") == "01/01/0001" | vExpr == null | System.Convert.ToString(vExpr) == "" | System.Convert.ToString(vExpr) == "  /  /")
        //            {
        //                if (AllowNull == true)
        //                    SNLDate = null;
        //                else
        //                    SNLDate = Strings.Format((DateTime)DateTime.Now, "MM/dd/yyyy");
        //            }
        //            else
        //                SNLDate = Strings.Format((DateTime)vExpr, "MM/dd/yyyy");
        //    }
        //    catch (Exception ex)
        //    {
        //        SNLDate = null;
        //    }
        //}




        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public void Registration(string ls_name, string ls_fullname, string ls_civil, string ls_email, string ls_phone, int ls_govID, string ls_pwd, string ls_gender)
        {

            DataTable dt = new DataTable();
            DataInsertReturn dtr = new DataInsertReturn();
            JavaScriptSerializer js = new JavaScriptSerializer();
            fnReturnCivilId dtrCivil = new fnReturnCivilId();

            try
            {
                dtrCivil = clsGeneral.CheckCivilId(ls_civil);

                if (!clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Members where username='" + ls_name + "'", GstrDbKey).Equals("0"))
                {
                    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("اسم المستخدم مسجل معنا سابقا "), 0))));
                    return;
                }
                if (!clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Members where civilid='" + ls_civil + "'", GstrDbKey).Equals("0"))
                {
                    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("البطاقة المدنية مسجلة معنا سابقا."), 0))));
                    return;
                }

                if (dtrCivil.ValidCivil == false)
                {
                    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("الرقم المدني غير صالح "), 0))));
                    return;
                }
                if (!clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Members where email='" + ls_email + "'", GstrDbKey).Equals("0"))
                {
                    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("البريد الالكتروني مسجل معنا سابقا "), 0))));
                    return;
                }
                if (!clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Members where phone='" + ls_phone + "'", GstrDbKey).Equals("0"))
                {
                    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("رقم الموبايل مسجل معنا سابقا "), 0))));
                    return;
                }


                string ls_otp = clsGeneral.GenerateOTP();

                Object obj;
                string ls_body;
                string ls_encrpwd;


                string ePass = clsGeneral.ComputeHash(Server.HtmlEncode(ls_pwd.Trim()), Server.HtmlEncode(ls_civil), "SHA512", null);

                String ls_dob = clsGeneral.DobFromCivil2(ls_civil);

                dtr = clsGeneral.ExecuteNonQueryReturn("EXEC SP_Register N'" + ls_name + "',N'" + ls_fullname + "',N'" + ls_civil + "','" + ls_email + "',N'" + ls_phone + "','" + ls_govID + "',N'" + ePass + "','" + ls_otp + "',N'" + ls_gender + "','" + ls_dob + "'", GstrDbKey);
                if (dtr.DataInsert == true)
                {
                    sms(ls_phone, ls_otp);
                    ls_body = PopulateBodyRegister(ls_name, ls_otp);
                    dtr = SendEmail(ls_email, ls_body, "مرحبا بك في مباراتنا .");
                    if (dtr.DataInsert == true)
                    {
                        Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Sucess", dtr.ErrorMsg.Trim(), 0))));
                    }
                    else
                    {
                        Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Fail", dtr.ErrorMsg.Trim(), 0))));
                    }
                }
                else
                {
                    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Fail", dtr.ErrorMsg.Trim(), 0))));
                }
                //if (DS.Tables[0].Rows.Count == 0)
                //    dt = msgResponse("", "True", "NO ITEMS FOUND", 0);
                //else
                //    dt = DS.Tables[0];
                //Context.Response.Write(js.Serialize(GetJSon(dt)));

            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_ProfileUpdateInfo(String ls_euid)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {

                DS = clsGeneral.GetDS("select GovernateID,AreaId,rtrim(gender) as gender,RefCivilId1,RefCivilId2,RefCivilId3,RefCivilId4,RefCivilId5 from MYA_Maleabna_Members where useruid= '" + ls_euid + "'", GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
                else
                    dt = DS.Tables[0];
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_CheckProfileInfo(String ls_euid)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();
            int li_userid;
            try
            {
                li_userid = getUserid(ls_euid);


                DS = clsGeneral.GetDS("exec SP_CheckProfileUpdate " + li_userid, GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
                else
                    dt = DS.Tables[0];
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public void Remove_Civil(int as_slno,  string ls_euid)
        {

            DataTable dt = new DataTable();
            DataInsertReturn dtr = new DataInsertReturn();
            JavaScriptSerializer js = new JavaScriptSerializer();
            fnReturnCivilId dtrCivil = new fnReturnCivilId();
            int li_userid;
            try
            {
                li_userid = getUserid(ls_euid);

                if (as_slno == 2)
                {
                    dtr = clsGeneral.ExecuteNonQueryReturn("update MYA_Maleabna_Members set RefCivilId2='' where userid=" + li_userid, GstrDbKey);
                }
                else if (as_slno == 3)
                {
                    dtr = clsGeneral.ExecuteNonQueryReturn("update MYA_Maleabna_Members set RefCivilId3='' where userid=" + li_userid, GstrDbKey);
                }
                else if (as_slno == 4)
                {
                    dtr = clsGeneral.ExecuteNonQueryReturn("update MYA_Maleabna_Members set RefCivilId4='' where userid=" + li_userid, GstrDbKey);
                }
                else if (as_slno == 5)
                {
                    dtr = clsGeneral.ExecuteNonQueryReturn("update MYA_Maleabna_Members set RefCivilId5='' where userid=" + li_userid, GstrDbKey);
                }
                if (dtr.DataInsert == true)
                {
                    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Sucess", dtr.ErrorMsg.Trim(), 0))));                 
                }
                else
                {
                    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Fail", dtr.ErrorMsg.Trim(), 0))));
                }
            
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public void UpdateProfile(int ls_govID, int ls_areaID, string ls_gender, string ls_civil1, string ls_civil2, string ls_civil3, string ls_civil4, string ls_civil5, string ls_euid)
        {

            DataTable dt = new DataTable();
            DataInsertReturn dtr = new DataInsertReturn();
            JavaScriptSerializer js = new JavaScriptSerializer();
            fnReturnCivilId dtrCivil = new fnReturnCivilId();
            int li_userid;
            try
            {
                li_userid = getUserid(ls_euid);

                if (!ls_civil1.Equals(""))
                {
                    dtrCivil = clsGeneral.CheckCivilId(ls_civil1);
                    if (dtrCivil.ValidCivil == false)
                    {
                        Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("الرقم المدني غير صالح "), 1))));
                        return;
                    }
                }

                if (!ls_civil2.Equals(""))
                {
                    dtrCivil = clsGeneral.CheckCivilId(ls_civil2);
                    if (dtrCivil.ValidCivil == false)
                    {
                        Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("الرقم المدني غير صالح "), 2))));
                        return;
                    }
                }

                if (!ls_civil3.Equals(""))
                {
                    dtrCivil = clsGeneral.CheckCivilId(ls_civil3);
                    if (dtrCivil.ValidCivil == false)
                    {
                        Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("الرقم المدني غير صالح "), 3))));
                        return;
                    }
                }


                if (!ls_civil4.Equals(""))
                {
                    dtrCivil = clsGeneral.CheckCivilId(ls_civil4);
                    if (dtrCivil.ValidCivil == false)
                    {
                        Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("الرقم المدني غير صالح "), 4))));
                        return;
                    }
                }

                if (!ls_civil5.Equals(""))
                {
                    dtrCivil = clsGeneral.CheckCivilId(ls_civil5);
                    if (dtrCivil.ValidCivil == false)
                    {
                        Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("الرقم المدني غير صالح "), 5))));
                        return;
                    }
                }



                //if (clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Members where civilid='" + ls_civil1 + "' and userid<>" + li_userid, GstrDbKey).Equals("0"))
                //{
                //    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("This CivilID Is not Registered with US"), 1))));
                //    return;
                //}



                //string ls_otp = clsGeneral.GenerateOTP();

                //Object obj;
                //string ls_body;
                //string ls_encrpwd;


                //string ePass = clsGeneral.ComputeHash(Server.HtmlEncode(ls_pwd.Trim()), Server.HtmlEncode(ls_civil), "SHA512", null);

                //String ls_dob = clsGeneral.DobFromCivil2(ls_civil);

                dtr = clsGeneral.ExecuteNonQueryReturn("EXEC SP_UpdtaeProfile " + li_userid + "," + ls_govID + "," + ls_areaID + ",N'" + ls_gender + "',N'" + ls_civil1 + "',N'" + ls_civil2 + "',N'" + ls_civil3 + "',N'" + ls_civil4 + "',N'" + ls_civil5 + "'", GstrDbKey);
                if (dtr.DataInsert == true)
                {

                    //dtrCivil = clsGeneral.CheckCivilId(ls_civil1);

                    //if (!clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Members where civilid='" + ls_civil1 + "' and userid=" + li_userid, GstrDbKey).Equals("0"))
                    //{
                    //    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("Your Own Civil Id not Allowed"), 1))));
                    //    return;
                    //}
                    //if (dtrCivil.ValidCivil == false)
                    //{
                    //    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("الرقم المدني غير صالح "), 11))));
                    //    return;
                    //}

                    //if (clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Members where civilid='" + ls_civil1 + "'", GstrDbKey).Equals("0"))
                    //{
                    //    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("This CivilId is not found in our database. Please invite your friend to register Mubaratna."), 21))));
                    //    return;
                    //}








                    //if (!clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Members where civilid='" + ls_civil2 + "' and userid=" + li_userid, GstrDbKey).Equals("0"))
                    //{
                    //    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("Your Own Civil Id not Allowed"), 2))));
                    //    return;
                    //}


                    //if (!clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Members where civilid='" + ls_civil3 + "' and userid=" + li_userid, GstrDbKey).Equals("0"))
                    //{
                    //    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("Your Own Civil Id not Allowed"), 3))));
                    //    return;
                    //}


                    //if (!clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Members where civilid='" + ls_civil4 + "' and userid=" + li_userid, GstrDbKey).Equals("0"))
                    //{
                    //    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("Your Own Civil Id not Allowed"), 4))));
                    //    return;
                    //}


                    //if (!clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Members where civilid='" + ls_civil5 + "' and userid=" + li_userid, GstrDbKey).Equals("0"))
                    //{
                    //    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("Your Own Civil Id not Allowed"), 5))));
                    //    return;
                    //}




                    



                    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Sucess", dtr.ErrorMsg.Trim(), 0))));
                    //sms(ls_phone, ls_otp);
                    //ls_body = PopulateBodyRegister(ls_name, ls_otp);
                    //dtr = SendEmail(ls_email, ls_body, "مرحبا بك في مباراتنا .");
                    //if (dtr.DataInsert == true)
                    //{
                    //    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Sucess", dtr.ErrorMsg.Trim(), 0))));
                    //}
                    //else
                    //{
                    //    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Fail", dtr.ErrorMsg.Trim(), 0))));
                    //}
                }
                else
                {
                    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Fail", dtr.ErrorMsg.Trim(), 0))));
                }
                //if (DS.Tables[0].Rows.Count == 0)
                //    dt = msgResponse("", "True", "NO ITEMS FOUND", 0);
                //else
                //    dt = DS.Tables[0];
                //Context.Response.Write(js.Serialize(GetJSon(dt)));

            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public void fn_ReSendOTP(string ls_email)
        {
            DataTable dt = new DataTable();
            DataInsertReturn dtr = new DataInsertReturn();
            JavaScriptSerializer js = new JavaScriptSerializer();
            fnReturnCivilId dtrCivil = new fnReturnCivilId();
            Object obj;
            string ls_body;
            string ls_name;
            string ls_phone;
            int ls_smscnt;

            ls_phone = clsGeneral.GetQueryValue("select phone from MYA_Maleabna_Members where email='" + ls_email + "'", GstrDbKey);
            ls_name = clsGeneral.GetQueryValue("select name from MYA_Maleabna_Members where email='" + ls_email + "'", GstrDbKey);
            ls_smscnt = int.Parse(clsGeneral.GetQueryValue("select smscount from MYA_Maleabna_Members where email='" + ls_email + "'", GstrDbKey));

            string ls_otp = clsGeneral.GenerateOTP();
            if (ls_smscnt < 3)
            {
                sms(ls_phone, ls_otp);
                clsGeneral.ExecuteNonQuery("update MYA_Maleabna_Members set smscount=smscount+1 where  email='" + ls_email + "'", GstrDbKey);
            }

            ls_body = PopulateBodyRegister(ls_name, ls_otp);
            dtr = SendEmail(ls_email, ls_body, "مرحبا بك في مباراتنا ");
            if (dtr.DataInsert == true)
            {
                clsGeneral.ExecuteNonQuery("update MYA_Maleabna_Members set otp='" + ls_otp + "' where  email='" + ls_email + "'", GstrDbKey);
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Sucess", clsGeneral.GetSucTag("لقد تم ارسال الرمز بنجاح "), 0))));
            }
            else
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Fail", dtr.ErrorMsg.Trim(), 0))));
            }

        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public void fn_SendContact(string ls_name, string ls_email, string ls_msg)
        {
            Object obj;
            string ls_body;
            DataInsertReturn dtr = new DataInsertReturn();
            JavaScriptSerializer js = new JavaScriptSerializer();

            clsGeneral.ExecuteNonQuery("insert into MYA_Maleabna_ContactUs (Name,Email,Msg) values(N'" + ls_name + "','" + ls_email + "',N'" + ls_msg + "')", GstrDbKey);

            ls_body = PopulateBodyContactUS(ls_name, ls_email, ls_msg);
            dtr = SendEmail("web@youth.gov.kw", ls_body, "New Contact.");
            if (dtr.DataInsert == true)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Sucess", dtr.ErrorMsg.Trim(), 0))));
            }
            else
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Fail", dtr.ErrorMsg.Trim(), 0))));
            }
        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public void fn_SendEmailProfileUpdate(string ls_euid, String ls_sendemail)
        {
            Object obj;
            string ls_body;
            DataInsertReturn dtr = new DataInsertReturn();
            JavaScriptSerializer js = new JavaScriptSerializer();

            int li_userid;
            String ls_username;

            //li_userid = getUserid(ls_euid);
            //clsGeneral.ExecuteNonQuery("insert into MYA_Maleabna_ContactUs (Name,Email,Msg) values(N'" + ls_name + "','" + ls_email + "',N'" + ls_msg + "')", GstrDbKey);
            ls_username = clsGeneral.GetQueryValue("select name from MYA_Maleabna_Members where UserUID='" + ls_euid + "'", GstrDbKey);


            ls_body = PopulateBodyProfileUpdate(ls_username, "https://mubaratna.com/Register");

            dtr = SendEmail(ls_sendemail, ls_body, "Register Mubaratna");
            if (dtr.DataInsert == true)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Sucess", dtr.ErrorMsg.Trim(), 0))));
            }
            else
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Fail", dtr.ErrorMsg.Trim(), 0))));
            }
        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public void fn_Reset_Password(string ls_email)
        {

            DataTable dt = new DataTable();
            DataInsertReturn dtr = new DataInsertReturn();
            JavaScriptSerializer js = new JavaScriptSerializer();
            fnReturnCivilId dtrCivil = new fnReturnCivilId();
            string ls_body;
            string ls_username;
            string ls_euid;
            object obj;
            try
            {

                if (clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Members where email='" + ls_email + "'", GstrDbKey).Equals("0"))
                {
                    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("لم يتم العثور على بريدك الإلكتروني "), 0))));
                    return;
                }

                ls_username = clsGeneral.GetQueryValue("select name from MYA_Maleabna_Members where email='" + ls_email + "'", GstrDbKey);
                ls_euid = clsGeneral.GetQueryValue("select useruid from MYA_Maleabna_Members where email='" + ls_email + "'", GstrDbKey);

                ls_body = PopulateBodyResetPWD(ls_username, "https://mubaratna.com/ResetPassword/" + ls_euid);
                //ls_body = PopulateBodyResetPWD(ls_username, "http://localhost:94/ResetPassword/" + ls_euid);
                dtr = SendEmail(ls_email, ls_body, "Mubaratna Reset Password.");

                if (dtr.DataInsert == true)
                {
                    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Sucess", clsGeneral.GetSucTag("لقد تم ارسال رابط تغيير كلمة الرور لبريدك الإلكتروني بنجاح "), 0))));
                }
                else
                {
                    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag(dtr.ErrorMsg.Trim()), 0))));
                }

            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }


        private string PopulateBodyResetPWD(string ls_username, string ls_link)
        {
            string body = string.Empty;
            StreamReader reader = new StreamReader(Server.MapPath("~/emailForgetPWD.html"));
            body = reader.ReadToEnd();

            body = body.Replace("{User}", ls_username);
            body = body.Replace("{link}", ls_link);

            return body;
        }


        private string PopulateBodyRegister(string ls_username, string ls_otp)
        {
            string body = string.Empty;
            StreamReader reader = new StreamReader(Server.MapPath("~/emailRegister.html"));
            body = reader.ReadToEnd();

            body = body.Replace("{User}", ls_username);
            body = body.Replace("{otp}", ls_otp);

            return body;
        }

        private string PopulateBodyContactUS(string ls_name, string ls_email, string ls_msg)
        {
            string body = string.Empty;
            StreamReader reader = new StreamReader(Server.MapPath("~/emailContact.html"));
            body = reader.ReadToEnd();

            body = body.Replace("{Name}", ls_name);
            body = body.Replace("{Email}", ls_email);
            body = body.Replace("{Msg}", ls_msg);

            return body;
        }


        private string PopulateBodyProfileUpdate(string ls_username, string ls_link)
        {
            string body = string.Empty;
            StreamReader reader = new StreamReader(Server.MapPath("~/emailProfileUpdate.html"));
            body = reader.ReadToEnd();

            body = body.Replace("{User}", ls_username);
            body = body.Replace("{link}", ls_link);

            return body;
        }

        public DataInsertReturn SendEmail(string emailid, string ls_body, string ls_Subject)
        {
            string rtString;
            rtString = "";
            string email = emailid;
            DataInsertReturn dtr = new DataInsertReturn();
            dtr.DataInsert = true;
            if (!email.Equals(""))
            {
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.From = new MailAddress("web@youth.gov.kw", "Mubaratna");
                message.To.Add(new MailAddress(email));
                message.Subject = ls_Subject;
                message.CC.Add(new MailAddress("web@youth.gov.kw"));
                message.IsBodyHtml = true;

                message.Body = ls_body;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.UseDefaultCredentials = false;

                smtpClient.Credentials = new System.Net.NetworkCredential("web@youth.gov.kw", "Top@A147258");

                smtpClient.Port = 587;
                smtpClient.Host = "smtp.office365.com";
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                try
                {
                    smtpClient.Send(message);
                    //smtpClient = null/* TODO Change to default(_) if this is not a reference type */;

                    dtr.ErrorMsg = "Insert Sucessfully";

                    return dtr;
                }

                // rtString = "Email Send Successfully."
                catch (Exception ex)
                {
                    dtr.DataInsert = false;
                    dtr.ErrorMsg = ex.Message;
                    return dtr;
                }

            }
            return dtr;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_Payment_Wallet_Details(int li_bookingid)
        {

            DataTable dt = new DataTable();


            DataInsertReturn dtr = new DataInsertReturn();
            JavaScriptSerializer js = new JavaScriptSerializer();

            DataSet DS = new DataSet();
            try
            {

                DS = clsGeneral.GetDS("EXEC SP_MYA_Maleabna_GetBookingInfo_Final_Cancel " + li_bookingid, GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "No Data Found", 0);
                else
                    dt = DS.Tables[0];

                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));



            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_Payment_Wallet_Booking_Details(string ls_euid)
        {

            DataTable dt = new DataTable();


            DataInsertReturn dtr = new DataInsertReturn();
            JavaScriptSerializer js = new JavaScriptSerializer();

            DataSet DS = new DataSet();
            double li_bookid = 0;
            int li_userid = 0;
            try
            {
                li_userid = getUserid(ls_euid);
                li_bookid = double.Parse(clsGeneral.GetQueryValue("select top 1 BookingID from MYA_Maleabna_Booking where userid= " + li_userid + "order by BookingID desc", GstrDbKey));
                DS = clsGeneral.GetDS("EXEC SP_MYA_Maleabna_GetBookingInfo_Final_Cancel " + li_bookid, GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "No Data Found", 0);
                else
                    dt = DS.Tables[0];

                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));



            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Insert_Payment_Details(string ls_PaymentID, string ls_Result, string ls_PostDate, string ls_TranID, string ls_Ref, string ls_TrackID, string ls_Auth, string ls_OrderID)
        {

            DataTable dt = new DataTable();


            DataInsertReturn dtr = new DataInsertReturn();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string ls_bookuid;
            double ld_rate;
            int li_userid = 0;
            DataSet DS = new DataSet();
            try
            {

                Object obj;
                //li_userid = getUserid(ls_euid);

                int li_bookid;
                li_bookid = int.Parse(clsGeneral.GetQueryValue("select BookingId from MYA_Maleabna_Booking where BookingIDUniq='" + ls_OrderID + "'", GstrDbKey));
                li_userid = int.Parse(clsGeneral.GetQueryValue("select UserId from MYA_Maleabna_Booking where BookingIDUniq='" + ls_OrderID + "'", GstrDbKey));
                ld_rate = double.Parse(clsGeneral.GetQueryValue("select rate from MYA_Maleabna_Booking where BookingIDUniq='" + ls_OrderID + "'", GstrDbKey));
                string str = "";
                //if (ls_PostDate != "")
                //{
                //DateTime temp = DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                //str = temp.ToString("yyyy-MM-dd");
                //}

                dtr = clsGeneral.ExecuteNonQueryReturn("EXEC SP_AddEdit_MYA_Maleabna_BookingPaymentDetails 'I'," + li_bookid + "," + li_userid + ",'" + ls_Result + "','" + ls_PaymentID + "','" + ls_TranID + "','" + ls_Ref + "','" + ls_PostDate + "','" + ls_Auth + "','" + ls_TrackID + "'," + ld_rate + ",'',1", GstrDbKey);
                if (dtr.DataInsert == true)
                {
                    DS = clsGeneral.GetDS("EXEC SP_MYA_Maleabna_GetBookingInfo_Final " + li_bookid, GstrDbKey, "Table", true);

                    if (DS.Tables[0].Rows.Count == 0)
                        dt = clsGeneral.msgResponse("", "True", "No Data Found", 0);
                    else
                        dt = DS.Tables[0];

                    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
                    // Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Sucess", dtr.ErrorMsg.Trim(), 0))));
                }
                else
                {
                    Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Fail", dtr.ErrorMsg.Trim(), 0))));
                }

            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }




        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void fn_InsertRating(string ls_euid, int li_stadid, double li_rating)
        {

            DataTable dt = new DataTable();


            DataInsertReturn dtr = new DataInsertReturn();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string ls_bookuid;
            int li_userid = 0;
            try
            {
                Object obj;
                li_userid = getUserid(ls_euid);

                dtr = clsGeneral.ExecuteNonQueryReturn("EXEC SP_AddEdit_MYA_Maleabna_Rating 'I',0," + li_stadid + "," + li_userid + "," + li_rating, GstrDbKey);

                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Sucess", dtr.ErrorMsg.Trim(), 0))));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void fn_InsertFavorite(string ls_euid, int li_stadid)
        {

            DataTable dt = new DataTable();


            DataInsertReturn dtr = new DataInsertReturn();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string ls_bookuid;
            int li_userid = 0;
            try
            {
                Object obj;
                li_userid = getUserid(ls_euid);

                dtr = clsGeneral.ExecuteNonQueryReturn("EXEC SP_AddEdit_MYA_Maleabna_Favorite 'I',0," + li_stadid + "," + li_userid, GstrDbKey);

                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Sucess", dtr.ErrorMsg.Trim(), 0))));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void InsertBookingInfo(int li_stadid, int li_staddetid, string ls_euid, string ls_date, string ls_time, string ls_type, int li_bookingid, string li_paymode)
        {

            DataTable dt = new DataTable();


            DataInsertReturn dtr = new DataInsertReturn();
            DataInsertReturn dtr_req = new DataInsertReturn();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string ls_bookuid;
            int li_userid = 0;
            try
            {
                Object obj;
                li_userid = getUserid(ls_euid);
                DateTime temp = DateTime.ParseExact(ls_date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                String ls_para = "";
                ls_para = "li_stadid: " + li_stadid + ",li_staddetid: " + li_staddetid + ",ls_euid: " + ls_euid + ",ls_date: " + ls_date + ",ls_time: " + ls_time + ",ls_type: " + ls_type + "li_bookingid: " + li_bookingid + ",li_paymode: " + li_paymode;

                dtr_req = clsGeneral.ExecuteNonQueryReturn("Insert into RequestTrace (requestTo,ErrorMsg,reqDate,userid,parameters)values('InsertBookingInfo','',getdate()," + li_userid + ",'" + ls_para + "')", GstrDbKey);

                if (ls_type == "Booking")
                {
                    string str = "";
                    if (ls_date != "")
                    {

                        str = temp.ToString("yyyy-MM-dd");
                    }

                    if (!clsGeneral.GetQueryValue("select  count(*) as cnt from MYA_Maleabna_TimeSlot_Block where BlockBy='WholeSite' and '" + str + "' between DateFrm and DateTo and status=1", GstrDbKey).Equals("0"))
                    {
                        dtr_req = clsGeneral.ExecuteNonQueryReturn("Insert into RequestTrace (requestTo,ErrorMsg,reqDate,userid,parameters)values('InsertBookingInfo','Booking Blocked...',getdate()," + li_userid + ",'" + ls_para + "')", GstrDbKey);
                        Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Fail", "Booking Blocked...", 0))));
                        return;
                    }




                    if (!clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Booking where StadiumDetId=" + li_staddetid + " and BookingDate='" + str + "' and BookingStatus=1 and PaymentStatus=1 and bookingtime='" + ls_time + "'", GstrDbKey).Equals("0"))
                    {
                        Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Fail", "لم تم حجز الفترات المختارة من قبل ", 0))));
                        return;
                    }


                    if (!clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Booking where BookingDate='" + str + "' and BookingStatus=1 and PaymentStatus=1 and userid=" + li_userid, GstrDbKey).Equals("0"))
                    {
                        Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Fail", "الحجز أكثر من مرة واحدة باليوم غير متاح ", 0))));
                        return;
                    }

                    //DateTime cur_date = Convert.ToDateTime(clsGeneral.GetQueryValue("select isnull(MAX(bookingdate),getdate()) as bkdate from MYA_Maleabna_Booking where userid=" + li_userid, GstrDbKey));

                    DateTime baseDate = temp;
                    var thisWeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek);
                    var thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1);



                    if (clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Booking where BookingDate between '" + thisWeekStart.ToString("yyyy-MM-dd") + "' and '" + thisWeekEnd.ToString("yyyy-MM-dd") + "' and BookingStatus=1 and PaymentStatus=1 and userid=" + li_userid, GstrDbKey).Equals("2"))
                    {
                        Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Fail", "الحجز أكثر من مرتين بالأسبوع غير متاح ", 0))));
                        return;
                    }


                    if (li_paymode == "wallet")
                    {
                        double ld_amt;
                        double ld_rate;
                        ld_amt = double.Parse(clsGeneral.GetQueryValue("select isnull(sum(amount),0) from MYA_Maleabna_MembersWallet where userid=" + li_userid, GstrDbKey));
                        ld_rate = double.Parse(clsGeneral.GetQueryValue("select rate from MYA_Maleabna_Stadium_Detail where StadiumDetId=" + li_staddetid, GstrDbKey));

                        if (ld_amt < ld_rate)
                        {
                            Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Fail", "رصيدك غير كاف ", 0))));
                            return;
                        }
                    }


                    dtr = clsGeneral.ExecuteNonQueryReturn("EXEC SP_AddEdit_MYA_Maleabna_Booking 'I',0," + li_userid + "," + li_stadid + ",'" + str + "','" + ls_time + "',0,0,0,0," + li_staddetid + ",'" + li_paymode + "','WebApp'", GstrDbKey);

                }
                else if (ls_type == "Cancel")
                {

                    dtr = clsGeneral.ExecuteNonQueryReturn("EXEC SP_AddEdit_MYA_Maleabna_BookingCancel 'I',0," + li_bookingid + "," + li_userid + ",'',0,2,'User'", GstrDbKey);

                }
                //if (DS.Tables[0].Rows.Count == 0)
                //    dt = msgResponse("", "True", "NO ITEMS FOUND", 0);
                //else
                //    dt = DS.Tables[0];
                //Context.Response.Write(js.Serialize(GetJSon(dt)));
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Sucess", dtr.ErrorMsg.Trim(), 0))));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }





        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_MYA_Maleabna_Search(string ls_passvalue, string ls_date, string ls_time)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {
                string str = "";
                if (ls_date != "")
                {
                    DateTime temp = DateTime.ParseExact(ls_date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    str = temp.ToString("yyyy-MM-dd");
                }
                DS = clsGeneral.GetDS("exec SP_Get_MYA_Maleabna_Search '" + ls_passvalue + "','" + str + "','" + ls_time + "'", GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
                else
                    dt = DS.Tables[0];
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_MYA_Maleabna_MapData()
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {

                DS = clsGeneral.GetDS("exec SP_Get_MapData ", GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
                else
                    dt = DS.Tables[0];
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_MYA_Maleabna_Stadium_Gallery(int li_staid)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {

                DS = clsGeneral.GetDS("exec SP_Get_MYA_Maleabna_Stadium_Gallery " + li_staid, GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
                else
                    dt = DS.Tables[0];
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_MYA_Maleabna_Stadium_Videos(int li_staid)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {

                DS = clsGeneral.GetDS("exec SP_Get_MYA_Maleabna_Stadium_Videos " + li_staid, GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
                else
                    dt = DS.Tables[0];
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_StadiumDetails(int li_staid)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {
                DS = clsGeneral.GetDS(" select StadiumDetId,StadiumType from MYA_Maleabna_Stadium_Detail where StadiumID=" + li_staid, GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "Login Failed", 0);
                else
                    dt = DS.Tables[0];
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }




        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_User_Login(string username, string password)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string ls_civilid = "";
            string ls_Epwd = "";
            string ls_email = "";
            try
            {
                if (clsGeneral.GetQueryValue("select UserType from MYA_Maleabna_Members where username='" + username + "' and pwd=''", GstrDbKey).Equals("Old"))
                {
                    dt = clsGeneral.msgResponse("", "True", "Old User", 0);
                }
                else
                {

                    if (!clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Members where username='" + username + "'", GstrDbKey).Equals("0"))
                    {

                        ls_email = clsGeneral.GetQueryValue("select email from MYA_Maleabna_Members where  username='" + username + "'", GstrDbKey);
                        ls_civilid = clsGeneral.GetQueryValue("select civilid from MYA_Maleabna_Members where  username='" + username + "'", GstrDbKey);
                        ls_Epwd = clsGeneral.GetQueryValue("select pwd from MYA_Maleabna_Members where  username='" + username + "'", GstrDbKey);
                        bool flag = false;
                        flag = clsGeneral.VerifyHash(password.Trim(), ls_civilid, "SHA512", ls_Epwd);
                        if (flag == false)
                        {
                            flag = clsGeneral.VerifyHash(password.Trim(), ls_email, "SHA512", ls_Epwd);
                        }

                        if (flag == true)
                        {
                            DS = clsGeneral.GetDS("EXEC	SP_Get_User_Login '" + username + "','" + ls_Epwd + "'", GstrDbKey, "Table", true);

                            if (DS.Tables[0].Rows.Count == 0)
                                dt = clsGeneral.msgResponse("", "True", "Login Failed", 0);
                            else
                            {
                                string ls_smsstats = "";
                                string ls_profilestatus = "";
                                ls_smsstats = clsGeneral.GetQueryValue("select cast(smsstatus as char(1)) as smsstatus from MYA_Maleabna_Members where username='" + username + "'", GstrDbKey);
                                ls_profilestatus = clsGeneral.GetQueryValue("select ProfileStatus from MYA_Maleabna_Members where username='" + username + "'", GstrDbKey);
                                if (ls_smsstats.Equals("0"))
                                {
                                    dt = clsGeneral.msgResponse("", ls_email, "SMS Not Validated", 0);
                                }
                                else if (ls_profilestatus.Equals("False"))
                                {
                                    dt = clsGeneral.msgResponse("", DS.Tables[0].Rows[0]["UserUID"].ToString(), "Profile Not Updated", 0);
                                }
                                else
                                {
                                    //dt = clsGeneral.msgResponse("", "test", ls_profilestatus, 0);
                                    dt = DS.Tables[0];
                                }
                            }

                        }
                        else
                        {
                            dt = clsGeneral.msgResponse("", "True", "Login Failed", 0);
                        }
                    }
                    else
                    {
                        dt = clsGeneral.msgResponse("", "True", "Login Failed", 0);
                    }
                }

                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetBookingInfo(int stadid, string ls_euid, string seldate, string seltime)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();
            int li_userid = 0;
            try
            {
                li_userid = getUserid(ls_euid);
                string str = "";
                if (seldate != "")
                {
                    DateTime temp = DateTime.ParseExact(seldate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    str = temp.ToString("yyyy-MM-dd");
                }

                DS = clsGeneral.GetDS("EXEC SP_MYA_Maleabna_GetBookingInfo " + stadid + "," + li_userid + ",'" + str + "','" + seltime + "'", GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "No Data Found", 0);
                else
                    dt = DS.Tables[0];

                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetCancelInfo(int stadid, string ls_euid, int bookid)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();
            int li_userid = 0;
            try
            {
                //string str = "";
                //if (seldate != "")
                //{
                //    DateTime temp = DateTime.ParseExact(seldate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                //    str = temp.ToString("yyyy-MM-dd");
                //}
                li_userid = getUserid(ls_euid);
                DS = clsGeneral.GetDS("EXEC SP_MYA_Maleabna_GetCancelInfo " + li_userid + "," + bookid, GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "No Data Found", 0);
                else
                    dt = DS.Tables[0];

                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_MYA_Maleabna_Result(int ls_stadid, string ls_date)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {
                string str = "";
                if (ls_date != "")
                {
                    DateTime temp = DateTime.ParseExact(ls_date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    str = temp.ToString("yyyy-MM-dd");
                }
                DS = clsGeneral.GetDS("exec SP_MYA_Maleabna_Result " + ls_stadid + ",'" + str + "'", GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
                else
                    dt = DS.Tables[0];
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_MYA_Maleabna_Rating(int ls_stadid, string ls_euid)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();

            int li_userid = 0;
            try
            {
                if (ls_euid.Equals(""))
                {
                    li_userid = 0;
                }
                else
                {
                    li_userid = getUserid(ls_euid);
                }

                DS = clsGeneral.GetDS("exec SP_Get_MYA_Maleabna_Stadium_Rating " + ls_stadid + "," + li_userid, GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
                else
                    dt = DS.Tables[0];
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_MYA_Maleabna_TimeSlot_Search(int li_govid, int li_areaid, int li_staid, string ld_data)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {
                string str = "";
                if (ld_data != "")
                {
                    DateTime temp = DateTime.ParseExact(ld_data, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    str = temp.ToString("yyyy-MM-dd");
                }

                DS = clsGeneral.GetDS("exec SP_MYA_Maleabna_TimeSlot_Search " + li_govid + "," + li_areaid + "," + li_staid + ",'" + str + "'", GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
                else
                    dt = DS.Tables[0];

                //Context.Response.Write(js.Serialize(GetJSon(msgResponse("", "True", str, 0))));
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }





        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_MYA_Maleabna_Governorate(string ls_passvalue, string ld_data)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {
                string str_date = "";
                if (ld_data != "")
                {
                    DateTime temp = DateTime.ParseExact(ld_data, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    str_date = temp.ToString("yyyy-MM-dd");
                }

                DS = clsGeneral.GetDS("exec SP_Get_MYA_Maleabna_Governorate '" + ls_passvalue + "','" + str_date + "'", GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
                else
                    dt = DS.Tables[0];
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_MYA_Maleabna_GovernorateForReg()
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {

                DS = clsGeneral.GetDS("exec SP_Get_MYA_Maleabna_GovernorateForReg ", GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
                else
                    dt = DS.Tables[0];
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_MYA_Maleabna_AreaForReg(int li_govid)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {

                DS = clsGeneral.GetDS("exec SP_Get_MYA_Maleabna_AreaForReg " + li_govid, GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
                else
                    dt = DS.Tables[0];
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }

        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void fn_CheckWithPACI(string ls_civil)
        {
            fnReturnCivilId dtrCivil = new fnReturnCivilId();
            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            JavaScriptSerializer js = new JavaScriptSerializer();       
           
          
          //  DataInsertReturn dtr = new DataInsertReturn();

            dtrCivil = clsGeneral.CheckCivilId(ls_civil);
            //int li_userid;

            if (dtrCivil.ValidCivil == false)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("الرقم المدني غير صالح "), 0))));
                return;
            }

            try
            {

                DS = clsGeneral.GetDS("exec SP_CheckCivilWithPACI '" + ls_civil + "'", GstrDbKey, "Table", true);
                dt = DS.Tables[0];
                // Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));    
                //if (DS.Tables[0].Rows.Count == 0)
                //    dt = clsGeneral.msgResponse("", "True", "Updated", 0);
                //else
                //    dt = DS.Tables[0];
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));

            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
            }
            finally
            {

            }


        }




    }

}