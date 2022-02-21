using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StadiumCMS_Default : System.Web.UI.Page
{
    public string StrLatestBookingtr, StrLatestMemberstr;
    protected void Page_Load(object sender, EventArgs e)
    {
        CMSCurrentUser.CheckLoggedIn();

        FillSiteStatistics();
       FillLatestBooking();
       FillLatestMembers();



       
    }

    private void FillSiteStatistics()
    {
        string cmd;
        DataTable dt;

        dt = dbFunctions.GetData("exec SP_GetStatistics @uid=" + Session["MaleabnaCMSUserID"]);

        labTotalGovernorate.Text = dt.Rows[0]["TotalGovernorate"].ToString();


        labTotalArea.Text = dt.Rows[0]["TotalArea"].ToString();

        labTotalSchool.Text = dt.Rows[0]["TotalSchool"].ToString();

        labTotalStadium.Text = dt.Rows[0]["TotalStadium"].ToString();

        labTotalGuard.Text = dt.Rows[0]["TotalGuard"].ToString();

        labTotalMembers.Text = dt.Rows[0]["TotalMembers"].ToString();


        labTotalBooking.Text = dt.Rows[0]["TotalBooking"].ToString();


        labBookingCancel.Text = dt.Rows[0]["TotalBookingCancel"].ToString();

        dGov.Visible = Convert.ToBoolean(dt.Rows[0]["settings"].ToString());
        dArea.Visible = Convert.ToBoolean(dt.Rows[0]["settings"].ToString());
        dGaurd.Visible = Convert.ToBoolean(dt.Rows[0]["settings"].ToString());


        dStadium.Visible = Convert.ToBoolean(dt.Rows[0]["stadium"].ToString());
        dSchool.Visible = Convert.ToBoolean(dt.Rows[0]["stadium"].ToString());

        dBooking.Visible = Convert.ToBoolean(dt.Rows[0]["booking"].ToString());
        dBookingCancel.Visible = Convert.ToBoolean(dt.Rows[0]["booking"].ToString());

        dMembers.Visible = Convert.ToBoolean(dt.Rows[0]["members"].ToString());






    }

    private void FillLatestBooking()
    {
        StrLatestBookingtr = "";
        string cmd;
        DataTable dt;

    

        //cmd = "select top 8 *  from V_Booking where BookingStatus='1'  and CONVERT(char(10), BookingDate  ,126) >=CONVERT(char(10), getdate(),126)  order by BookingDate";
        //dt = dbFunctions.GetData(cmd);

        dt = dbFunctions.GetData("exec SP_GetBooking @type='default',@uid=" + Session["MaleabnaCMSUserID"]);

        if (dt.Rows.Count != 0)
        {
            int i1;
            for (i1 = 0; i1 <= dt.Rows.Count - 1; i1++)
            {
                DateTime strdate;

                StrLatestBookingtr = StrLatestBookingtr + "<tr>";

                //StrLatestBookingtr = StrLatestBookingtr + "<td><div class='user-with-avatar'><span class='d-xl-inline-block'> <a class='btn' href='View_MemberDetails.aspx?UserID=" + dt.Rows[i1]["UserID"] + "'>" + dt.Rows[i1]["UserFullName"].ToString() + "</a></span></div> </td>";
                StrLatestBookingtr = StrLatestBookingtr + "<td> <a class='btn' href='View_MemberDetails.aspx?UserID=" + dt.Rows[i1]["UserID"] + "'>" + dt.Rows[i1]["UserFullName"].ToString() + "</a> </td>";

                //"<a class='btn btn-success btn-sm' href='View_MemberDetails.aspx?UserID=" + dt.Rows[i1]["UserID"] + "'>View Profile</a>"

                strdate = DateTime.Parse(dt.Rows[i1]["BookingDate"].ToString());

                StrLatestBookingtr = StrLatestBookingtr + "<td class='text-center'>" + strdate.ToShortDateString() + " </td>";

                StrLatestBookingtr = StrLatestBookingtr + "<td class='text-center'>" + dt.Rows[i1]["BookingTime"] + "</td>";

                StrLatestBookingtr = StrLatestBookingtr + "<td class='text-center'>" + dt.Rows[i1]["StadiumName"] + "</td>";

                StrLatestBookingtr = StrLatestBookingtr + "<td class='text-center'>" + dt.Rows[i1]["CreatedAt"] + "</td>";

                StrLatestBookingtr = StrLatestBookingtr + "<td class='text -center'>" + GetBookingStatus(dt.Rows[i1]["BookingStatus"].ToString()) + "</td>";
                StrLatestBookingtr = StrLatestBookingtr + "</tr>";
            }
        }
    }
    public string GetBookingStatus(string s)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";

        if (s.ToString() == "1")
        {
            strresult = "<div class='status-pill green' data-title='Confirmed' data-toggle='tooltip' data-original-title='' title=''></div>";
        }
        else
        {
            strresult = "<div class='status-pill red' data-title='Cancelled' data-toggle='tooltip' data-original-title='' title=''></div>";
        }



        return strresult;
    }
    private void FillLatestMembers()
    {
        if (Session["MaleabnaCMSUserType"].ToString().Trim() == "1")
        {
            divLatestMembers.Visible = true;
        }
        else
        {
            divLatestMembers.Visible = false;
        }

       // Response.Write("UserType is: " + Session["MaleabnaCMSUserType"]);
        string cmd;
        DataTable dt;

        //cmd = "select top 3 *  from V_Members where Status='1' order by UserID desc";

        //dt = dbFunctions.GetData(cmd);
        dt = dbFunctions.GetData("exec SP_GetMembers @type='default',@uid=" + Session["MaleabnaCMSUserID"]);
        if (dt.Rows.Count != 0)
        {
            int i1;
            for (i1 = 0; i1 <= dt.Rows.Count - 1; i1++)
            {
                StrLatestMemberstr = StrLatestMemberstr + "<div class='profile-tile'>";
                StrLatestMemberstr = StrLatestMemberstr + "<a class='profile-tile-box' href='View_MemberDetails.aspx?UserID=" + dt.Rows[i1]["UserID"] + "'>";
                StrLatestMemberstr = StrLatestMemberstr + "<div class='pt-avatar-w'>";
                StrLatestMemberstr = StrLatestMemberstr + "<img src='Design/img/photo.jpg'>";
                StrLatestMemberstr = StrLatestMemberstr + " </div>";
                StrLatestMemberstr = StrLatestMemberstr + "<div class='pt-user-name'>";
                StrLatestMemberstr = StrLatestMemberstr + "" + dt.Rows[i1]["UserName"] + "";
                StrLatestMemberstr = StrLatestMemberstr + " </div>";
                StrLatestMemberstr = StrLatestMemberstr + "  </a>";
                StrLatestMemberstr = StrLatestMemberstr + " <div class='profile-tile-meta'>";
                StrLatestMemberstr = StrLatestMemberstr + "<ul>";
                StrLatestMemberstr = StrLatestMemberstr + "<li>" + dt.Rows[i1]["Name"] + "";
                StrLatestMemberstr = StrLatestMemberstr + "</li>";
                StrLatestMemberstr = StrLatestMemberstr + "<li>" + dt.Rows[i1]["Phone"] + "";
                StrLatestMemberstr = StrLatestMemberstr + " </li>";
                StrLatestMemberstr = StrLatestMemberstr + "<li>" + dt.Rows[i1]["CivilID"] + "";
                StrLatestMemberstr = StrLatestMemberstr + "</li>";
                StrLatestMemberstr = StrLatestMemberstr + " </ul>";
                StrLatestMemberstr = StrLatestMemberstr + "<div class='pt-btn'>";
                StrLatestMemberstr = StrLatestMemberstr + "<a class='btn btn-success btn-sm' href='View_MemberDetails.aspx?UserID=" + dt.Rows[i1]["UserID"] + "'>View Profile</a>";
                StrLatestMemberstr = StrLatestMemberstr + "</div>";
                StrLatestMemberstr = StrLatestMemberstr + "</div>";
                StrLatestMemberstr = StrLatestMemberstr + "</div>";



                //StrLatestMemberstr = StrLatestMemberstr + "<tr>";

                //StrLatestMemberstr = StrLatestMemberstr + "<td><div class='user-with-avatar'><span class='d-xl-inline-block'>" + dt.Rows[i1]["Name"].ToString() + "</span></div> </td>";

                //strdate = DateTime.Parse(dt.Rows[i1]["CreatedAt"].ToString());

                //StrLatestMemberstr = StrLatestMemberstr + "<td class='text-center'>" + dt.Rows[i1]["Phone"] + "</td>";

                //StrLatestMemberstr = StrLatestMemberstr + "<td class='text-center'>" + dt.Rows[i1]["CivilID"] + "</td>";

                //// StrLatestMemberstr = StrLatestMemberstr + "<td class='text-center'>" + dt.Rows[i1]["StadiumName"] + "</td>";

                //StrLatestMemberstr = StrLatestMemberstr + "</tr>";
            }
        }
    }

    //public string GetUserFullName(string s)
    //{
    //    string cmd, strresult;
    //    DataTable dt;

    //    strresult = "";

    //    cmd = "select * from [MYA_Maleabna_Members] where id=" + s + " order by id desc";
    //    //Response.Write(cmd);
    //    dt = dbFunctions.GetData(cmd);

    //    if (dt.Rows.Count != 0)
    //    {
    //        if (!DBNull.Value.Equals(dt.Rows[0]["Name"]))
    //        {
    //            strresult = dt.Rows[0]["Name"].ToString();
    //        }

    //    }

    //    return strresult;
    //}



    [WebMethod]
    public static List<object> GetGovernorateData()
    {
        List<object> GovernorateData = new List<object>();
        GovernorateData.Add(new object[]
        {
        "Governarate", "BookingCount","CancellationCount"
        });

        DataTable dt = new DataTable();

        string query = "select g.GovernorateID,g.GovernorateName,CountOfBooking = ("+
                       "select count(b.BookingID) from MYA_Maleabna_Booking b join MYA_Maleabna_Stadium s on b.StadiumID = s.StadiumID and s.GovernorateID = g.GovernorateID )," +
                       "CountOfBookingCancel = ("+
                       "select count(c.BookingID) from MYA_Maleabna_BookingCancel c join MYA_Maleabna_Booking b on c.BookingID = b.BookingID join MYA_Maleabna_Stadium s on b.StadiumID = s.StadiumID and s.GovernorateID = g.GovernorateID"+
                       ") from MYA_Maleabna_Governorate g";

        dt = dbFunctions.GetData(query);        

        using (dt = dbFunctions.GetData(query))
        {
            foreach (DataRow dr in dt.Rows)
            {
                GovernorateData.Add(new object[]
                        {
                        dr["GovernorateName"], dr["CountOfBooking"],dr["CountOfBookingCancel"]
                        });
            }
            
        }
        
        return GovernorateData;


    }

    [WebMethod]
    public static List<object> GetRegionData()
    {
        List<object> RegionData = new List<object>();
        RegionData.Add(new object[]
        {
        "year","BookingConfirmCount", "BookingCancelCount"
        });

        DataTable dt = new DataTable();

        string query = "select YEAR(BookingDate) as year, count(case when BookingStatus='1'  then 1 else Null end) as BookingConfirmCount, "+
                       "count(case when BookingStatus='2'  then 1 else Null end) as BookingCancelCount "+
                       "from MYA_Maleabna_Booking group by YEAR(BookingDate) order by YEAR(BookingDate) desc";


        dt = dbFunctions.GetData(query);

        using (dt = dbFunctions.GetData(query))
        {
            foreach (DataRow dr in dt.Rows)
            {
                RegionData.Add(new object[]
                        {
                        dr["year"],dr["BookingConfirmCount"], dr["BookingCancelCount"]
                        });
            }

        }

        return RegionData;


    }



    [WebMethod]
    public static List<object> GetStadiumData()
    {
        List<object> StadiumData = new List<object>();
        StadiumData.Add(new object[]
        {
        "StadiumName", "StadiumBookingCount"
        });

        DataTable dt = new DataTable();

        string query = "select top 5 b.StadiumID,count(b.StadiumID) as StadiumBookingCount,s.StadiumName from MYA_Maleabna_Booking b join MYA_Maleabna_Stadium s on b.StadiumID = s.StadiumID "+ 
                       "group by b.StadiumID,s.StadiumName order by StadiumBookingCount desc";
                       

        dt = dbFunctions.GetData(query);

        using (dt = dbFunctions.GetData(query))
        {
            foreach (DataRow dr in dt.Rows)
            {
                StadiumData.Add(new object[]
                        {
                        dr["StadiumName"], dr["StadiumBookingCount"]
                        });
            }

        }

        return StadiumData;


    }


    [WebMethod]
    public static List<object> GetMembersData()
    {
        List<object> MemberData = new List<object>();
        MemberData.Add(new object[]
        {
        "Name", "MemberCount"
        });

        DataTable dt = new DataTable();

        string query = "select top 5 b.UserID,count(b.UserID) as MemberCount,m.Name from MYA_Maleabna_Booking b join MYA_Maleabna_Members m on b.UserID  = m.UserID " +
                       "group by b.UserID,Name order by MemberCount desc ";


        dt = dbFunctions.GetData(query);

        using (dt = dbFunctions.GetData(query))
        {
            foreach (DataRow dr in dt.Rows)
            {
                MemberData.Add(new object[]
                        {
                        dr["Name"], dr["MemberCount"]
                        });
            }

        }

        return MemberData;


    }


    private void FillBookingByDate()
    {
        StrLatestBookingtr = "";
        string cmd;
        DataTable dt;

        //cmd = "select *  from V_Booking where BookingStatus='1' and BookingDate = '"+txtdate.Text +"'order by BookingID desc";
        //dt = dbFunctions.GetData(cmd);
        dt = dbFunctions.GetData("exec SP_GetBooking @type='default',@date='"+txtdate.Text+"',@uid=" + Session["MaleabnaCMSUserID"]);
        if (dt.Rows.Count != 0)
        {
            int i1;
            for (i1 = 0; i1 <= dt.Rows.Count - 1; i1++)
            {
                DateTime strdate;

                StrLatestBookingtr = StrLatestBookingtr + "<tr>";

                //StrLatestBookingtr = StrLatestBookingtr + "<td class='text-center'><div class='user-with-avatar'><span class='d-xl-inline-block'> <a class='btn' href='View_MemberDetails.aspx?UserID=" + dt.Rows[i1]["UserID"] + "'>" + dt.Rows[i1]["UserFullName"].ToString() + "</a></span></div> </td>";
                StrLatestBookingtr = StrLatestBookingtr + "<td class='text-center'> <a class='btn' href='View_MemberDetails.aspx?UserID=" + dt.Rows[i1]["UserID"] + "'>" + dt.Rows[i1]["UserFullName"].ToString() + "</a> </td>";

               
                strdate = DateTime.Parse(dt.Rows[i1]["BookingDate"].ToString());

                StrLatestBookingtr = StrLatestBookingtr + "<td class='text-center'>" + strdate.ToShortDateString() + " </td>";

                StrLatestBookingtr = StrLatestBookingtr + "<td class='text-center'>" + dt.Rows[i1]["BookingTime"] + "</td>";

                StrLatestBookingtr = StrLatestBookingtr + "<td class='text-center'>" + dt.Rows[i1]["StadiumName"] + "</td>";

                StrLatestBookingtr = StrLatestBookingtr + "<td class='text-center'>" + dt.Rows[i1]["CreatedAt"] + "</td>";

                StrLatestBookingtr = StrLatestBookingtr + "<td class='text -center'>" + GetBookingStatus(dt.Rows[i1]["BookingStatus"].ToString()) + "</td>";
                StrLatestBookingtr = StrLatestBookingtr + "</tr>";
            }
        }
    }
   
    protected void txtdate_TextChanged(object sender, EventArgs e)
    {
        if (txtdate.Text != "")
            FillBookingByDate();
        else
            FillLatestBooking();
    }
    protected void lnkprint_Click(object sender, EventArgs e)
    {
        if (txtdate.Text == "")
            Response.Redirect("Print_BookingReport.aspx", false);
        else
            Response.Redirect("Print_BookingReport.aspx?BookingDate=" + txtdate.Text, false);
    }
    protected void LinkExcel_Click(object sender, EventArgs e)
    {     
        DataTable dt;

        if (txtdate.Text != "")
            dt = dbFunctions.GetData("select UserFullName,Email,StadiumName,format(BookingDate,'dd/MM/yyyy') as BookingDate,BookingTime  from V_Booking where BookingStatus='1' and BookingDate = '"+txtdate.Text +"'order by BookingID desc");
        else
            dt = dbFunctions.GetData("select UserFullName,Email,StadiumName,format(BookingDate,'dd/MM/yyyy') as BookingDate,BookingTime  from V_Booking where BookingStatus='1' order by BookingID desc");
       
       // RemoveReOrderColumns(dt);
        DataGrid dg = new DataGrid();
        dg.DataSource = dt;
        dg.DataBind();


        string hex = "#E2EDF2";
        Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
        dg.AlternatingItemStyle.BackColor = _color;

        string sFileName = "MalebnaMembersList-" + System.DateTime.Now.Date + ".xls";
        sFileName = sFileName.Replace("/", "");

      

        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment; filename=" + sFileName);
        Response.ContentType = "application/vnd.ms-excel";
        EnableViewState = false;

        Response.ContentEncoding = System.Text.Encoding.Unicode;
        Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());  // this two lines to show arabic text proper

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

    private void RemoveReOrderColumns(DataTable dt)
    {
        dt.Columns.Remove("BookingID");
        dt.Columns.Remove("UserID");
        dt.Columns.Remove("StadiumId");
        dt.Columns.Remove("SMSStatus");
        dt.Columns.Remove("EmailStatus");
        dt.Columns.Remove("StadiumDetId");
        dt.Columns.Remove("CancelledBy");
        dt.Columns.Remove("PaymentMode");
        dt.Columns.Remove("rate");
        dt.Columns.Remove("PaymentStatus");
        dt.Columns.Remove("BookingStatus");
        dt.Columns.Remove("CreatedAt");
        dt.Columns.Remove("StadiumNameEn");   

    }
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