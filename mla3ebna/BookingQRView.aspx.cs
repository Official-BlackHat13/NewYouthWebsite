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

public partial class BookingQRView : System.Web.UI.Page
{
    MGeneral clsGeneral = new MGeneral();
    string GstrDbKey = "MalebnaDB";
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        DataSet DS = new DataSet();

        try
        {
            DS = clsGeneral.GetDS("EXEC SP_MYA_Maleabna_GetBookingInfo_Final " + Request.QueryString["BookingID"].ToString(), GstrDbKey, "Table", true);

            if (DS.Tables[0].Rows.Count == 0)
                dt = clsGeneral.msgResponse("", "True", "No Data Found", 0);
            else
                dt = DS.Tables[0];


            lblcName.Text = dt.Rows[0]["cName"].ToString();
            lblStadiumName.Text = dt.Rows[0]["StadiumName"].ToString();
            lbladdress.Text = dt.Rows[0]["address"].ToString();
            lblselTime.Text = dt.Rows[0]["selTime"].ToString();
            lblSelDate.Text = Convert.ToDateTime(dt.Rows[0]["SelDate"].ToString()).ToShortDateString();


        }
        catch (Exception ex)
        {
            dt = clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0);
        }
        finally
        {

        }
    }
    }