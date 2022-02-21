using CryptSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.fss.plugin;

public partial class Fail : System.Web.UI.Page
{
    MGeneral clsGeneral = new MGeneral();
    string GstrDbKey = "MalebnaDB";

    protected void Page_Load(object sender, EventArgs e)
    {
       
        KentData();
    }

    protected void KentData()
    {

        iPayPipe pipe = new iPayPipe();
        //String resourcePath = "c:\\resourcepath";
        //String keystorePath = "c:\\keystorePath";

       

        string resourcePath = Server.MapPath("~\\resourcepath").ToString();
        string keystorePath = Server.MapPath("~\\keystorePath").ToString();


        //String aliasName = "youth";
        string aliasName = "mala3ib";
        pipe.setResourcePath(resourcePath);
        pipe.setKeystorePath(keystorePath);
        pipe.setAlias(aliasName);
        
        int result = pipe.parseEncryptedRequest(Request.QueryString["trandata"]);
        if (result != 0)
        {
            Response.Write("Error:  "+pipe.getError().ToString());
            string res = pipe.getError();
            pipe.getError();
        }
        else
        {
            lblPaymentStatus.Text = pipe.getResult();

            lblngPayId.Text = pipe.getPaymentId();

            if (pipe.getResult() == "CANCELED")
            {
                lblngPayHead.Text = "تم إلغاء الدفع ...";
            }
            else
            {
                lblngPayHead.Text = "عملية الدفع غير ناجحة ";
            }

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

               // DataTable dt = Insert_Payment_Details(paymentID, getresult, date, transactionID, refID, trackID, auth, orderID);
                DataTable dt = Insert_Payment_Details(paymentID, getresult, date, transactionID, refID, trackID, auth, orderID, code);
                if (dt.Rows.Count > 0)
                {
                    DataColumnCollection columns = dt.Columns;
                    if (columns.Contains("message"))
                    {

                    }
                    else
                    {

                        lbltrackID.Text = trackID;
                        lblrefNum.Text = refID;


                        lblPaymentDate.Text = dt.Rows[0]["PaymentDate"].ToString();
                        lblcName.Text = dt.Rows[0]["cName"].ToString();
                        lblStadiumName.Text = dt.Rows[0]["StadiumName"].ToString();
                        lbladdress.Text = dt.Rows[0]["address"].ToString();
                        lblselTime.Text = dt.Rows[0]["selTime"].ToString();
                        lblSelDate.Text = dt.Rows[0]["SelDate"].ToString();
                        lblRate.Text = dt.Rows[0]["Rate"].ToString();
                    }

                }
            }
            else
            {               
                string geterrorText = pipe.getError_text();
                string payment = pipe.getPaymentId();
                string error = pipe.getPaymentId();
                string trackID = pipe.getTrackId();
                string amount = pipe.getAmt();
                string transactionID = pipe.getTransId(); //request.getParameter("trackid"); // actually they have given here trackid in the documantation
                string udf1 = pipe.getUdf1();
                string udf2 = pipe.getUdf2();
                string udf3 = pipe.getUdf3();
                string udf4 = pipe.getUdf4();
                string udf5 = pipe.getUdf5();


                
            }
        }
    }


    public DataTable Insert_Payment_Details(string ls_PaymentID, string ls_Result, string ls_PostDate, string ls_TranID, string ls_Ref, string ls_TrackID, string ls_Auth, string ls_OrderID, string code)
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

            dtr = clsGeneral.ExecuteNonQueryReturn("EXEC SP_AddEdit_MYA_Maleabna_BookingPaymentDetails 'I'," + li_bookid + "," + li_userid + ",'" + ls_Result + "','" + ls_PaymentID + "','" + ls_TranID + "','" + ls_Ref + "','" + ls_PostDate + "','" + ls_Auth + "','" + ls_TrackID + "'," + ld_rate + ",'',1,'" + code + "'", GstrDbKey);
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

     
    }

   


    //public DataTable Insert_Payment_Details(string ls_PaymentID, string ls_Result, string ls_PostDate, string ls_TranID, string ls_Ref, string ls_TrackID, string ls_Auth, string ls_OrderID)
    //{
    //    DataTable dt = new DataTable();


    //    DataInsertReturn dtr = new DataInsertReturn();

    //    string ls_bookuid;
    //    double ld_rate;
    //    int li_userid = 0;
    //    DataSet DS = new DataSet();
    //    try
    //    {

    //        Object obj;
    //        //li_userid = getUserid(ls_euid);

    //        int li_bookid;
    //        li_bookid = int.Parse(clsGeneral.GetQueryValue("select BookingId from MYA_Maleabna_Booking where BookingIDUniq='" + ls_TrackID + "'", GstrDbKey));
    //        li_userid = int.Parse(clsGeneral.GetQueryValue("select UserId from MYA_Maleabna_Booking where BookingIDUniq='" + ls_TrackID + "'", GstrDbKey));
    //        ld_rate = double.Parse(clsGeneral.GetQueryValue("select rate from MYA_Maleabna_Booking where BookingIDUniq='" + ls_TrackID + "'", GstrDbKey));
    //        string str = "";


    //        dtr = clsGeneral.ExecuteNonQueryReturn("EXEC SP_AddEdit_MYA_Maleabna_BookingPaymentDetails 'I'," + li_bookid + "," + li_userid + ",'" + ls_Result + "','" + ls_PaymentID + "','" + ls_TranID + "','" + ls_Ref + "','" + ls_PostDate + "','" + ls_Auth + "','" + ls_TrackID + "'," + ld_rate + ",'',1", GstrDbKey);
    //        if (dtr.DataInsert == true)
    //        {
    //            DS = clsGeneral.GetDS("EXEC SP_MYA_Maleabna_GetBookingInfo_Final " + li_bookid, GstrDbKey, "Table", true);

    //            if (DS.Tables[0].Rows.Count == 0)
    //                dt = clsGeneral.msgResponse("", "True", "No Data Found", 0);
    //            else
    //                dt = DS.Tables[0];


    //            // Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Sucess", dtr.ErrorMsg.Trim(), 0))));
    //        }
    //        else
    //        {
    //            dt = clsGeneral.msgResponse("", "Fail", dtr.ErrorMsg.Trim(), 0);
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        dt = clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0);
    //    }
    //    finally
    //    {

    //    }
    //    return dt;


    //    //DataTable dt = new DataTable();


    //    //DataInsertReturn dtr = new DataInsertReturn();
       
    //    //string ls_bookuid;
    //    //double ld_rate;
    //    //int li_userid = 0;
    //    //DataSet DS = new DataSet();
    //    //try
    //    //{

    //    //    Object obj;
    //    //    //li_userid = getUserid(ls_euid);

    //    //    int li_bookid;
    //    //    li_bookid = int.Parse(clsGeneral.GetQueryValue("select BookingId from MYA_Maleabna_Booking where BookingIDUniq='" + ls_OrderID + "'", GstrDbKey));
    //    //    li_userid = int.Parse(clsGeneral.GetQueryValue("select UserId from MYA_Maleabna_Booking where BookingIDUniq='" + ls_OrderID + "'", GstrDbKey));
    //    //    ld_rate = double.Parse(clsGeneral.GetQueryValue("select rate from MYA_Maleabna_Booking where BookingIDUniq='" + ls_OrderID + "'", GstrDbKey));
    //    //    string str = "";
            

    //    //    dtr = clsGeneral.ExecuteNonQueryReturn("EXEC SP_AddEdit_MYA_Maleabna_BookingPaymentDetails 'I'," + li_bookid + "," + li_userid + ",'" + ls_Result + "','" + ls_PaymentID + "','" + ls_TranID + "','" + ls_Ref + "','" + ls_PostDate + "','" + ls_Auth + "','" + ls_TrackID + "'," + ld_rate + ",'',1", GstrDbKey);
    //    //    if (dtr.DataInsert == true)
    //    //    {
    //    //        DS = clsGeneral.GetDS("EXEC SP_MYA_Maleabna_GetBookingInfo_Final " + li_bookid, GstrDbKey, "Table", true);

    //    //        if (DS.Tables[0].Rows.Count == 0)
    //    //            dt = clsGeneral.msgResponse("", "True", "No Data Found", 0);
    //    //        else
    //    //            dt = DS.Tables[0];

               
    //    //        // Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "Sucess", dtr.ErrorMsg.Trim(), 0))));
    //    //    }
    //    //    else
    //    //    {
    //    //        dt = clsGeneral.msgResponse("", "Fail", dtr.ErrorMsg.Trim(), 0);
    //    //    }

    //    //}
    //    //catch (Exception ex)
    //    //{
    //    //    dt = clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0);
    //    //}
    //    //finally
    //    //{

    //    //}
    //    //return dt;


    //}

   
    

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

    protected void lnktry_Click(object sender, EventArgs e)
    {
        string userId = Session["userid"].ToString();
        PaymentIntegration(userId);
    }


    private int getUserid(string ls_eid)
    {
        int li_userid;
        li_userid = int.Parse(clsGeneral.GetQueryValue("select userid from MYA_Maleabna_Members where UserUID='" + ls_eid + "' and status=1", GstrDbKey));
        return li_userid;
    }

    public void PaymentIntegration(string ls_euid)
    {
        DataTable dt = new DataTable();
        DataSet DS = new DataSet();
       
        string ls_bookuid = "";
        // double ld_amt = 0;
        string ld_amt = "0.000";
        int li_userid = 0;
        try
        {

            li_userid = getUserid(ls_euid);

            ls_bookuid = clsGeneral.GetQueryValue("select top 1 BookingIDUniq from MYA_Maleabna_Booking where userid= " + li_userid + "order by BookingID desc", GstrDbKey);
            // ld_amt = double.Parse(clsGeneral.GetQueryValue("select top 1 cast(rate as decimal(10,3)) from MYA_Maleabna_Booking where userid= " + li_userid + "order by BookingID desc", GstrDbKey));
            ld_amt = (clsGeneral.GetQueryValue("select top 1 cast(rate as numeric(18,3)) from MYA_Maleabna_Booking where userid= " + li_userid + "order by BookingID desc", GstrDbKey));
            Response.Write(ld_amt);
        }
        catch (Exception ex)
        {
            string exec = ex.Message.ToString();
        }


        if (!ls_bookuid.Equals(""))
        {
           
            iPayPipe pipe = new iPayPipe();


            String resourcePath = Server.MapPath("~\\resourcepath").ToString();
            String keystorePath = Server.MapPath("~\\keystorePath").ToString();
            String recieptURL = "https://www.youth.gov.kw/mla3ebna/Knet-Response.aspx";
            String errorURL = "https://www.youth.gov.kw/mla3ebna/Knet-Response.aspx";



            String action = "1";
            String alias = "youth";
            String currency = "414";
            String language = "EN"; // English – “EN”, Arabic – “AR” 
            String amount = ld_amt;
            String trackid = ls_bookuid; //order_id;
            //String Udf1= “Udf1”; 
            //String Udf2= “Udf2”; 
            //String Udf3= “Udf3”; 
            //String Udf4= “Udf4”; 
            //String Udf5= “Udf5”;
            pipe.setResourcePath(resourcePath);
            pipe.setKeystorePath(keystorePath);
            pipe.setAlias(alias);
            pipe.setAction(action);
            pipe.setCurrency(currency);
            pipe.setLanguage(language);
            pipe.setResponseURL(recieptURL);
            pipe.setErrorURL(errorURL);
            pipe.setAmt(amount);
            pipe.setTrackId(trackid);
            //pipe.setUdf1(Udf1); 
            //pipe.setUdf2(Udf2);
            //pipe.setUdf3(Udf3); 
            //pipe.setUdf4(Udf4);
            //pipe.setUdf5(Udf5);
            int val = pipe.performPaymentInitializationHTTP();
            if (val == 0)
            {
                string str = pipe.getWebAddress().ToString();
                Response.Redirect(pipe.getWebAddress());
            }
            else
            {
                string str = pipe.getError().ToString();
                Response.Write(str);
                pipe.getError();
            }
        }


    }

   
}