using CryptSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Booking : System.Web.UI.Page
{
    MGeneral clsGeneral = new MGeneral();
    string GstrDbKey = "MalebnaDB";

    protected void Page_Load(object sender, EventArgs e)
    {
        //  Session["UserUID"] = "140222";
        if (Session["UserUID"] != null)
        {
            if (!this.IsPostBack)
            {
                if (Session["stdbooking"] != null || Session["BookingID"] != null)
                {
                    FillData();
                    hiddenSession.Value = Session["WType"].ToString();
                }
                else
                {

                    Response.Redirect("index.aspx", false);
                }
            }
        }
        else
        {
            Session["page"] = "booking";
            Response.Redirect("Login.aspx", false);
        }
    }

    protected void FillData()
    {
        if (Session["UserUID"] != null)
        {
            divmodalmsg.InnerHtml = "";
            divmodalmsg.Visible = false;


            DataTable dt = new DataTable();
            if (Session["stdbooking"] != null && Session["WType"].ToString() == "Booking")
            {
                string[] arr = Session["stdbooking"].ToString().Split(new char[] { ',' });

                int staID = int.Parse(arr[0].ToString());
                string date = arr[1].ToString();
                int stdetID = int.Parse(arr[4].ToString());
                string userId = Session["UserUID"].ToString();

                string time = arr[3].ToString();

                dt = GetBookingInfo(stdetID, userId, date, time);
            }
            else if (Session["BookingID"] != null && Session["WType"].ToString() == "Cancel")
            {
                int stID = int.Parse(Session["StadiumID"].ToString());
                int bookID = int.Parse(Session["BookingID"].ToString());
                string uid = Session["UserUID"].ToString();
                dt = GetCancelInfo(stID, uid, bookID);

            }
            if (dt.Rows.Count > 0)
            {
                if (Session["UserGender"] != null)
                {
                    string gender = dt.Rows[0]["Gender"].ToString().Trim();
                    string GenderFromSession = Session["UserGender"].ToString().Trim() == "أنثى" ? "2" : "1";

                    lbl.Text = dt.Rows[0]["cName"].ToString();
                    

                    lblCName.Text = dt.Rows[0]["cName"].ToString();
                    lblStdName.Text = dt.Rows[0]["StadiumName"].ToString();
                    lblAddress.Text = dt.Rows[0]["address"].ToString();
                    lblSelTime.Text = dt.Rows[0]["selTime"].ToString();
                    lblSelDate.Text = dt.Rows[0]["SelDate"].ToString();
                    lblRate.Text = dt.Rows[0]["Rate"].ToString();
                    lblRate1.Text = dt.Rows[0]["Rate"].ToString();

                    double rate = double.Parse(dt.Rows[0]["Rate"].ToString());
                    lnkSubmit.Visible = true;


                    if (Session["WType"].ToString() == "Booking")
                    {
                        // if (gender.Equals(GenderFromSession))
                        if (gender.Equals(GenderFromSession) || string.IsNullOrEmpty(gender))
                        {
                            double walletAmount = double.Parse(dt.Rows[0]["wAmt"].ToString());

                            divpayment.Visible = true;
                            if (walletAmount < rate)
                                divWallet.Visible = false;
                            else
                                divWallet.Visible = true;

                            lblng_bread.Text = "تفاصيل الحجز";
                            lblng_modaltext.Text = "Booking Policy Text Here";
                            lblng_modalheading.Text = "سياسة الحجز";


                        }
                        else
                        {
                            lnkSubmit.Visible = false;
                            divmodalmsg.InnerHtml = "<div class='alert alert-danger'><button type='button' class='close' data-dismiss='alert'><i class='ace-icon fa fa-times'></i></button><strong>This Stadium For " + gender + " </strong>  </div>";
                            divmodalmsg.Visible = true;

                        }
                    }
                    else if (Session["WType"].ToString() == "Cancel")
                    {
                        divpayment.Visible = false;
                        lblng_bread.Text = "الحجز الملغى";
                        lblng_modaltext.Text = "Booking Cancel Policy Text Here";
                        lblng_modalheading.Text = "سياسة إلغاء الحجز";
                    }
                }
                else
                {
                    lblCName.Text = "";
                    lblStdName.Text = "";
                    lblAddress.Text = "";
                    lblSelTime.Text = "";
                    lblSelDate.Text = "";
                    lblRate.Text = "";
                    lblRate1.Text = "";
                    lnkSubmit.Visible = false;
                }
            }
            else
                Response.Redirect("index.aspx", false);
        }
        else
            Response.Redirect("index.aspx", false);


    }

    public DataTable GetCancelInfo(int stadid, string ls_euid, int bookid)
    {

        DataTable dt = new DataTable();
        DataSet DS = new DataSet();

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


        }
        catch (Exception ex)
        {
            dt = clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0);
        }
        finally
        {

        }


        return dt;
    }


    public DataTable GetBookingInfo(int stadetid, string ls_euid, string seldate, string seltime)
    {

        DataTable dt = new DataTable();
        DataSet DS = new DataSet();

        int li_userid = 0;

        li_userid = getUserid(ls_euid); //int.Parse(ls_euid); // getUserid(ls_euid);
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

    private int getUserid(string ls_eid)
    {
        int li_userid;
        li_userid = int.Parse(clsGeneral.GetQueryValue("select userid from MYA_Maleabna_Members where UserUID='" + ls_eid + "' and status=1", GstrDbKey));
        return li_userid;
    }

    
    protected void lnkSubmit_Click(object sender, EventArgs e)
    {
        if ((Session["stdbooking"] != null || Session["BookingID"] != null) && Session["UserUID"] != null && Session["WType"] != null)
        {
            divspin1.Visible = true;
            divmodalmsg.InnerHtml = "";
            divmodalmsg.Visible = false;
            DataTable dt = new DataTable();

            string[] arr; // Session["stdbooking"].ToString().Split(new char[] { ',' });
            string PaymentType = (radioKnet.Checked ? "knet" : "wallet");
            string userId = Session["UserUID"].ToString();

            if (Session["stdbooking"] != null && Session["WType"].ToString() == "Booking")
            {
                arr = Session["stdbooking"].ToString().Split(new char[] { ',' });

                int staID = int.Parse(arr[0].ToString());
                string date = arr[1].ToString();
                int stdetID = int.Parse(arr[4].ToString());
               
              //  string time = arr[2].ToString();                
                string time = arr[3].ToString();

                
                int bookiD = (Session["WType"].ToString() == "Booking" ? 0 : int.Parse(Session["BookingID"].ToString()));

                dt = InsertBookingInfo(staID, stdetID, userId, date, time, Session["WType"].ToString(), bookiD, PaymentType);

               
            }
            else if (Session["BookingID"] != null && Session["WType"].ToString() == "Cancel")
            {
                int staID = int.Parse(Session["StadiumID"].ToString());
                int bookID = int.Parse(Session["BookingID"].ToString());
                userId = Session["UserUID"].ToString();

                int bookiD = (Session["WType"].ToString() == "Booking" ? 0 : int.Parse(Session["BookingID"].ToString()));

                dt = InsertBookingInfo(staID, 0, userId, DateTime.Now.ToString(), "", Session["WType"].ToString(), bookID, "");

            }

            //int staID =  int.Parse(arr[0].ToString());
            //string date = arr[1].ToString();
            //int stdetID = int.Parse(arr[2].ToString());  
            //string userId = Session["UserUID"].ToString();
            //string time = arr[2].ToString();

           

           

            

            if (dt.Rows[0]["Error"].ToString() == "Sucess")
            {
                if (Session["WType"] == "Booking")
                {
                    if (PaymentType == "knet")
                    {
                        //PaymentIntegrationTest(userId);
                        PaymentIntegration(userId);
                    }
                    else if (PaymentType == "wallet")
                        Response.Redirect("SucessWallet.aspx", false);
                }
                else if (Session["WType"] == "Cancel")
                {
                    Response.Redirect("SucessWallet.aspx", false);
                }
            }
            else if (dt.Rows[0]["Error"].ToString() == "Fail")
            {
                divmodalmsg.InnerHtml = "<div class='alert alert-danger'><button type='button' class='close' data-dismiss='alert'><i class='ace-icon fa fa-times'></i></button><strong> " + dt.Rows[0]["message"].ToString() + " </strong>  </div>"; ;
                divmodalmsg.Visible = true;
                divspin1.Visible = false;
            }
            
        }
        else
        {
            Response.Redirect("login.aspx", false);
        }
    }


    public DataTable InsertBookingInfo(int li_stadid, int li_staddetid, string ls_euid, string ls_date, string ls_time, string ls_type, int li_bookingid, string li_paymode)
    {

        DataTable dt = new DataTable();


        DataInsertReturn dtr = new DataInsertReturn();
        DataInsertReturn dtr_req = new DataInsertReturn();
        
        string ls_bookuid;
        int li_userid = 0;
        try
        {
            Object obj;
            li_userid = getUserid(ls_euid);
           
            String ls_para = "";
            ls_para = "li_stadid: " + li_stadid + ",li_staddetid: " + li_staddetid + ",ls_euid: " + ls_euid + ",ls_date: " + ls_date + ",ls_time: " + ls_time + ",ls_type: " + ls_type + "li_bookingid: " + li_bookingid + ",li_paymode: " + li_paymode;

            dtr_req = clsGeneral.ExecuteNonQueryReturn("Insert into RequestTrace (requestTo,ErrorMsg,reqDate,userid,parameters)values('InsertBookingInfo','',getdate()," + li_userid + ",'" + ls_para + "')", GstrDbKey);

            if (ls_type == "Booking")
            {
                DateTime temp = DateTime.ParseExact(ls_date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                string str = "";
                if (ls_date != "")
                {

                    str = temp.ToString("yyyy-MM-dd");
                }

                if (!clsGeneral.GetQueryValue("select  count(*) as cnt from MYA_Maleabna_TimeSlot_Block where BlockBy='WholeSite' and '" + str + "' between DateFrm and DateTo and status=1", GstrDbKey).Equals("0"))
                {
                    dtr_req = clsGeneral.ExecuteNonQueryReturn("Insert into RequestTrace (requestTo,ErrorMsg,reqDate,userid,parameters)values('InsertBookingInfo','Booking Blocked...',getdate()," + li_userid + ",'" + ls_para + "')", GstrDbKey);
                    dt = clsGeneral.msgResponse("", "Fail", "Booking Blocked...", 0);
                    return dt;
                }




                if (!clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Booking where StadiumDetId=" + li_staddetid + " and BookingDate='" + str + "' and BookingStatus=1 and PaymentStatus=1 and bookingtime='" + ls_time + "'", GstrDbKey).Equals("0"))
                {
                    dt = clsGeneral.msgResponse("", "Fail", "لم تم حجز الفترات المختارة من قبل ", 0);
                    return dt;
                }


                if (!clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Booking where BookingDate='" + str + "' and BookingStatus=1 and PaymentStatus=1 and userid=" + li_userid, GstrDbKey).Equals("0"))
                {
                    dt = clsGeneral.msgResponse("", "Fail", "الحجز أكثر من مرة واحدة باليوم غير متاح ", 0);
                    return dt;
                }

                DateTime baseDate = temp;
                var thisWeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek);
                var thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1);



                if (clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Booking where BookingDate between '" + thisWeekStart.ToString("yyyy-MM-dd") + "' and '" + thisWeekEnd.ToString("yyyy-MM-dd") + "' and BookingStatus=1 and PaymentStatus=1 and userid=" + li_userid, GstrDbKey).Equals("2"))
                {
                    dt = clsGeneral.msgResponse("", "Fail", "الحجز أكثر من مرتين بالأسبوع غير متاح ", 0);
                    return dt;
                }


                if (li_paymode == "wallet")
                {
                    double ld_amt;
                    double ld_rate;
                    ld_amt = double.Parse(clsGeneral.GetQueryValue("select isnull(sum(amount),0) from MYA_Maleabna_MembersWallet where userid=" + li_userid, GstrDbKey));
                    ld_rate = double.Parse(clsGeneral.GetQueryValue("select rate from MYA_Maleabna_Stadium_Detail where StadiumDetId=" + li_staddetid, GstrDbKey));

                    if (ld_amt < ld_rate)
                    {
                        dt = clsGeneral.msgResponse("", "Fail", "رصيدك غير كاف ", 0);
                        return dt;
                    }
                }


                dtr = clsGeneral.ExecuteNonQueryReturn("EXEC SP_AddEdit_MYA_Maleabna_Booking 'I',0," + li_userid + "," + li_stadid + ",'" + str + "','" + ls_time + "',0,0,0,0," + li_staddetid + ",'" + li_paymode + "','WebApp'", GstrDbKey);

            }
            else if (ls_type == "Cancel")
            {
                DateTime temp = Convert.ToDateTime(ls_date);
                string ldate = temp.ToString("yyyy-MM-dd");
                dtr = clsGeneral.ExecuteNonQueryReturn("EXEC SP_AddEdit_MYA_Maleabna_BookingCancel 'I',0," + li_bookingid + "," + li_userid + ",'" + ldate + "',0,2,'User'", GstrDbKey);
                //MYA_Maleabna_BookingCancel
            }
            dt = clsGeneral.msgResponse("", "Sucess", dtr.ErrorMsg.Trim(), 0);
            return dt;
        }
        catch (Exception ex)
        {
            dt=clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0);
            return dt;
        }
        finally
        {

        }

    }



    //public void PaymentIntegrationTest(string ls_euid)
    //{
    //    DataTable dt = new DataTable();
    //    DataSet DS = new DataSet();
       
    //    string ls_bookuid = "";
    //    double ld_amt = 0;
    //    int li_userid = 0;
    //    try
    //    {
    //        li_userid = int.Parse(ls_euid);// getUserid(ls_euid);
    //        ls_bookuid = clsGeneral.GetQueryValue("select top 1 BookingIDUniq from MYA_Maleabna_Booking where userid= " + li_userid + "order by BookingID desc", GstrDbKey);
    //        ld_amt = double.Parse(clsGeneral.GetQueryValue("select top 1 rate from MYA_Maleabna_Booking where userid= " + li_userid + "order by BookingID desc", GstrDbKey));

    //        if (!ls_bookuid.Equals(""))
    //        {
    //            String CurrentTimestamp = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds.ToString();
    //            String order_id = CurrentTimestamp.Replace(".", string.Empty);

    //            var request = (HttpWebRequest)WebRequest.Create("https://api.upayments.com/test-payment");

    //            var postData = "merchant_id=" + Uri.EscapeDataString("1201");
    //            postData += "&username=" + Uri.EscapeDataString("test");
    //            postData += "&password=" + Uri.EscapeDataString("test");
    //            postData += "&api_key=" + Uri.EscapeDataString("jtest123");
    //            postData += "&order_id=" + Uri.EscapeDataString(ls_bookuid);
    //            postData += "&total_price=" + Uri.EscapeDataString(ld_amt.ToString());
    //            postData += "&success_url=" + Uri.EscapeDataString("https://mubaratna.com/Sucess"); // url where you want to redirect user after successful of payment
    //            postData += "&error_url=" + Uri.EscapeDataString("https://mubaratna.com/Fail"); // url where you want to redirect user after failed payment
    //            postData += "&notifyURL=" + Uri.EscapeDataString("https://mubaratna.com/notifyURL.html"); // url we are sending response to this webhook once payment done by payment gateway so you don't need to wait for response 
    //            var data = System.Text.Encoding.ASCII.GetBytes(postData);

    //            request.Method = "POST";
    //            request.ContentType = "application/x-www-form-urlencoded";
    //            request.ContentLength = data.Length;

    //            using (var stream = request.GetRequestStream())
    //            {
    //                stream.Write(data, 0, data.Length);
    //            }

    //            var response = (HttpWebResponse)request.GetResponse();

    //            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

    //            string[] str = responseString.Split(new char[] { ',' });
    //            string[] str1 = str[1].Split(new char[]{'"'});
    //            string url = str1[3];

    //           // Context.Response.Write(responseString);
    //            //{"status":"success","paymentURL":"https:\/\/api.upayments.com\/test\/payment?ref=vV0G3D6Obe2bc1184e-5c8c-46b4-a163-796f948ca48c1626172235155985422760ed6b4b7caf6&sess_id=8589b5630362fa69723dc81f260d88b0"}
    //           // string url = Request.QueryString["paymentURL"];

    //            Response.Redirect(url, false);
    //        }
    //        else
    //        {
    //           // Context.Response.Write("Invalid BookingId");
    //        }

    //        //Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", responseString, 0))));

    //    }
    //    catch (Exception ex)
    //    {
    //       // Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
    //    }
    //    finally
    //    {

    //    }
    //}



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
           // li_userid = int.Parse(ls_euid);// getUserid(ls_euid);


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
                postData += "&success_url=" + Uri.EscapeDataString("https://mubaratna.com/Sucess.aspx"); // url where you want to redirect user after successful of payment
                postData += "&error_url=" + Uri.EscapeDataString("http://mubaratna.com/Fail.aspx"); // url where you want to redirect user after failed payment
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

                
                string[] temp = responseString.Split(new char[]{'"'});               
                string url = temp[7];
                url = url.Replace("\\/","/");

                Response.Redirect(url, false);
            }
            else
            {
               Response.Write("Invalid BookingId");
            }
        }
        catch (Exception ex)
        {
           // Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
        }
        finally
        {

        }
    }


    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchStadium.aspx", false);
    }
}