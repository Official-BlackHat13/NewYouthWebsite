using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.IO;

public partial class SucessWallet : System.Web.UI.Page
{
    MGeneral clsGeneral = new MGeneral();
    string GstrDbKey = "MalebnaDB";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserUID"] != null)
        {
            
            DataTable dt = new DataTable();
            if (Session["WType"] == "Cancel" && Session["BookingID"]!= null)
            {
                int li_bookingid = int.Parse(Session["BookingID"].ToString());
                dt = Get_Payment_Wallet_Details(li_bookingid);

                lblngBAlWallet.Text = dt.Rows[0]["WAmt"].ToString();
                Divngcancel.Visible = true;
                Divngbook.Visible = false;
            }
            else if (Session["WType"] == "Booking")
            {
                dt = Get_Payment_Wallet_Booking_Details(Session["UserUID"].ToString());
                lblngBAlWallet.Text = dt.Rows[0]["WAmt"].ToString();
                Divngcancel.Visible = false;
                Divngbook.Visible = true;
            }

            if(dt.Rows.Count> 0 )
            {

                DataColumnCollection columns = dt.Columns;
                if (columns.Contains("message"))
                {

                }
                else
                {
                    int i = GeneralEmail(dt);
                    
                    lblcName.Text = dt.Rows[0]["cName"].ToString();
                    lblStadiumName.Text = dt.Rows[0]["StadiumName"].ToString();
                    lbladdress.Text = dt.Rows[0]["address"].ToString();
                    lblselTime.Text = dt.Rows[0]["selTime"].ToString();
                    lblSelDate.Text = dt.Rows[0]["SelDate"].ToString();
                    lblRate.Text = dt.Rows[0]["Rate"].ToString();
                    //lblcName.Text = dt.Rows[0][""].ToString();
                }
            }
        }
        else
            Response.Redirect("Login.aspx", false);
    }


    public static int GeneralEmail(DataTable dt)
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
            message1.Body = EmailBodyGeneral(dt);
            message1.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("web@youth.gov.kw", "Top@A147258");
           // client.Port = 587;
            client.Port = 25;
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

    public static string EmailBodyGeneral(DataTable dt)
    {
        string body = string.Empty;

        StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("emailSuccessWallet.html"));
        body = reader.ReadToEnd();

        body = body.Replace("{name}", dt.Rows[0]["cName"].ToString());
        body = body.Replace("{walletamt}", dt.Rows[0]["WAmt"].ToString());      
       
        body = body.Replace("{amount}", dt.Rows[0]["Rate"].ToString());
        body = body.Replace("{staname}", dt.Rows[0]["StadiumName"].ToString());
        body = body.Replace("{place}", dt.Rows[0]["address"].ToString());
        body = body.Replace("{btime}", dt.Rows[0]["selTime"].ToString());
        body = body.Replace("{bdate}", Convert.ToDateTime(dt.Rows[0]["SelDate"].ToString()).ToString("dd-MM-yyyy"));


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

    public DataTable Get_Payment_Wallet_Details(int li_bookingid)
    {

        DataTable dt = new DataTable();


        DataInsertReturn dtr = new DataInsertReturn();
       

        DataSet DS = new DataSet();
        try
        {

            DS = clsGeneral.GetDS("EXEC SP_MYA_Maleabna_GetBookingInfo_Final_Cancel " + li_bookingid, GstrDbKey, "Table", true);

            if (DS.Tables[0].Rows.Count == 0)
                dt = clsGeneral.msgResponse("", "True", "No Data Found", 0);
            else
                dt = DS.Tables[0];

           // Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));



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

    public DataTable Get_Payment_Wallet_Booking_Details(string ls_euid)
    {

        DataTable dt = new DataTable();
        
        DataSet DS = new DataSet();
        double li_bookid = 0;
        int li_userid = 0;
        try
        {
            li_userid = getUserid(ls_euid);
            li_bookid = double.Parse(clsGeneral.GetQueryValue("select top 1 BookingID from MYA_Maleabna_Booking where userid= " + li_userid + "order by BookingID desc", GstrDbKey));
            DS = clsGeneral.GetDS("EXEC SP_MYA_Maleabna_GetBookingInfo_Final_Cancel " + li_bookid, GstrDbKey, "Table", true);
            DataInsertReturn dtr_req = clsGeneral.ExecuteNonQuery(" Exec SP_AddEdit_MYA_Maleabna_Booking_status '" + li_userid + "','" + li_bookid + "'", GstrDbKey);
            //dt = clsGeneral.msgResponse("", "Fail", "Booking Blocked...", 0);
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

    private int getUserid(string ls_eid)
    {
        int li_userid;
        li_userid = int.Parse(clsGeneral.GetQueryValue("select userid from MYA_Maleabna_Members where UserUID='" + ls_eid + "' and status=1", GstrDbKey));
        return li_userid;
    }

}