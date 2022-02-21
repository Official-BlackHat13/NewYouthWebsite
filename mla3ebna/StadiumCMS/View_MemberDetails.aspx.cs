using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StadiumCMS_View_MemberDetails : System.Web.UI.Page
{
    public string StrPrintbtn, StrGalleryDiv, StrVideoDiv, StrBookPrintbtn;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CMSCurrentUser.CheckLoggedIn();
           // lnkDelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete?')";
            if (Session["MaleabnaCMSDeleteMenu"].ToString() == "True")
            {
                DivlnkDelete.Visible = true;
                lnkDelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete?')";
            }
            else
            {
                DivlnkDelete.Visible = false;
            }

            fillData();
            fillUserBookingData();

            StrPrintbtn = " <a class='' href='javascript:void(0);'  onclick='openWinPrint(" + Request.QueryString["UserID"] + ")'><i class='fa fa-print'></i><span>&nbsp;طباعه &nbsp;</span></a>";
            StrBookPrintbtn = " <a class='btn btn-round  btn-outline-danger btnBig' href='javascript:void(0);'  onclick='openWinBookingPrint(" + Request.QueryString["UserID"] + ")'><i class='fa fa-print'></i></a>";
        }
    }

    private void fillData()
    {
        DataTable dt = new DataTable();

        DataTable Userdt = new DataTable();

        dt = dbFunctions.GetData("select * from [V_Members] where UserID=" + Request.QueryString["UserID"]);
        //Try


        if (dt.Rows.Count != 0)
        {
            LabUserID.Text = dt.Rows[0]["UserID"].ToString();

            LabUsername.Text = dt.Rows[0]["UserName"].ToString();

            LabFullName.Text = dt.Rows[0]["Name"].ToString();

            LabCivilID.Text = dt.Rows[0]["CivilID"].ToString();

            LabEmail.Text = dt.Rows[0]["Email"].ToString();

            LabPhone.Text = dt.Rows[0]["Phone"].ToString();

            LabGovernorate.Text = dt.Rows[0]["GovernorateName"].ToString();

           

        }
    }

   
    private void fillUserBookingData()
    {
        DataTable dt = new DataTable();

        DataTable Userdt = new DataTable();

        dt = dbFunctions.GetData("select * from [V_Booking] where BookingStatus = '1' and UserID=" + Request.QueryString["UserID"] + " order by BookingDate desc");
        //Try


        if (dt.Rows.Count != 0)
        {
            GVBooking.DataSource = dt;
            GVBooking.DataBind();
        }
    }

    protected void GVBooking_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVBooking.PageIndex = e.NewPageIndex;
        this.fillUserBookingData();
    }

    public string GetBookingStatus(object objID)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";

        if (objID.ToString() == "1")
        {
            strresult = "Confirmed";
        }
        else
        {
            strresult = "Cancel";
        }



        return strresult;
    }

    public string GetPaymentStatus(object objID)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";

        if (objID.ToString() == "True")
        {
            strresult = "Paid";
        }
        else
        {
            strresult = "Not Paid";
        }



        return strresult;
    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        string cmd;
        cmd = "delete from [MYA_Maleabna_Members] where [UserID] = " + Request.QueryString["UserID"];
        dbFunctions.ExecuteQuery(cmd);
        CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, "Members", "Delete", DateTime.Now, "" + Request.QueryString["UserID"] + "", "" + LabFullName.Text + "", "");
        Response.Redirect("View_Members.aspx");
    }
    protected void lnkprint_Click(object sender, EventArgs e)
    {
        Response.Redirect("Print_MemberBookings.aspx?UserID=" + Request.QueryString["UserID"], false);
    }
   

    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        DataTable dt;
        dt = dbFunctions.GetData("select BookingDate,BookingTime,BookingStatus,PaymentStatus,StadiumName,Name,CivilID,GovernorateName,Phone,[V_Members].Email from [V_Booking] join [V_Members] on  V_Booking.UserID = V_Members.UserID where BookingStatus = '1' and [V_Members].UserID=" + Request.QueryString["UserID"] + " order by BookingDate desc");
       
        //RemoveReOrderColumns(dt);
        DataGrid dg = new DataGrid();
        dg.DataSource = dt;
        dg.DataBind();

        //GVBooking.DataSource = dt;
        //GVBooking.DataBind();


        string hex = "#E2EDF2";
        Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
        dg.AlternatingItemStyle.BackColor = _color;

        string sFileName = "MalebnaBookingList-" + System.DateTime.Now.Date + ".xls";
        sFileName = sFileName.Replace("/", "");


        //foreach (DataGridItem dataGridItem in dg.Items)
        //{
        //    dataGridItem.Cells[6].Attributes.Add("class", "text");
        //    dataGridItem.Cells[7].NumberFormat = "@";
        //    //dataGridItem.Cells[7].SetCellValue(Double.Parse(dr(col).ToString))
        //}




        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment; filename=" + sFileName);
        Response.ContentType = "application/vnd.ms-excel";
        EnableViewState = false;

        Response.ContentEncoding = System.Text.Encoding.Unicode;
        Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());  // this two lines are to show arabic text in a proper format

        System.IO.StringWriter objSW = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter objHTW = new System.Web.UI.HtmlTextWriter(objSW);

        string hexHeader = "#65b7d1";
        Color _colorHeader = System.Drawing.ColorTranslator.FromHtml(hexHeader);
        dg.HeaderStyle.Font.Bold = true;     // SET EXCEL HEADERS AS BOLD.
        dg.HeaderStyle.BackColor = _colorHeader;
        dg.RenderControl(objHTW);

        Response.Write(AddExcelStyling());
        Response.Write("<style>  .text { mso-number-format:\\@; }  TABLE {  border:dotted 1px #999;} " +
         "TD { border:dotted 1px #D5D5D5; } </style>");

        Response.Write(objSW.ToString());



        Response.End();
        dg = null;


    }

    //private void RemoveReOrderColumns(DataTable dt)
    //{
    //    dt.Columns.Remove("BookingID");
    //    dt.Columns.Remove("UserID");
    //    dt.Columns.Remove("StadiumId");
    //    dt.Columns.Remove("SMSStatus");
    //    dt.Columns.Remove("EmailStatus");
    //    dt.Columns.Remove("StadiumDetId");
    //    dt.Columns.Remove("CancelledBy");
    //    dt.Columns.Remove("PaymentMode");
    //    dt.Columns.Remove("rate");
    //    dt.Columns.Remove("UserID1");
    //    dt.Columns.Remove("Email1");
    //    //dt.Columns.Remove("");
       

    //}
    private string AddExcelStyling()
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

        sb.Append("<x:Name>Sheet Name</x:Name>\n");

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
}