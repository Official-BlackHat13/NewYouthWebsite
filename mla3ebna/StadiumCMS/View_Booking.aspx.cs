using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StadiumCMS_View_Booking : System.Web.UI.Page
{
    int i;
    string str;
    private string cDeails;

    
    string[] arr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            CMSCurrentUser.CheckLoggedIn();
           

            fillGovernorate();

            fillArea(DDLGovernorate.SelectedValue);

           // fillUser();

            fillStadium();

            lnkDelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete?')";

            fillData();
        }
    }

    private void fillUser()
    {
        string cmd;
        DataTable dt;
        cmd = "select * from [MYA_Maleabna_Members] where Status='" + true + "' order by name asc ";
        dt = dbFunctions.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDlUser.DataSource = dt;
            DDlUser.DataTextField = "Name";
            DDlUser.DataValueField = "UserID";
            DDlUser.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDlUser.Items.Add(it_bo);
        }
        else
        {
            DDlUser.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDlUser.Items.Add(it_bo);
        }
    }

    private void fillStadium()
    {
        string cmd;
        DataTable dt;
        //cmd = "select StadiumID,StadiumName + ' - ' + StadiumNameEn AS StadiumName from [MYA_Maleabna_Stadium] where Status='" + true + "' order by StadiumName asc ";
        //dt = dbFunctions.GetData(cmd);
        dt = dbFunctions.GetData("exec SP_GetAdminStadiumsDetails @type='stadium',@userid=" + Session["MaleabnaCMSUserID"]);
        if (dt.Rows.Count != 0)
        {
            DDlStadium.DataSource = dt;
            DDlStadium.DataTextField = "StadiumName";
            DDlStadium.DataValueField = "StadiumID";
            DDlStadium.DataBind();
            if (dt.Rows.Count == 1)
            {
                DDlStadium.Enabled = false;
            }
            else
            {
                DDlStadium.Enabled = true;

                ListItem it_bo = new ListItem();
                it_bo.Text = "<--أختار-->";
                it_bo.Value = "0";
                it_bo.Selected = true;
                DDlStadium.Items.Add(it_bo);
            }
        }
        else
        {
            DDlStadium.Items.Clear();
            DDlStadium.Enabled = true;

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDlStadium.Items.Add(it_bo);
        }
    }

    private void fillGovernorate()
    {
        string cmd;
        DataTable dt;
        //cmd = "select GovernorateID,GovernorateName + ' - ' + GovernorateNameEn AS GovernorateName from [MYA_Maleabna_Governorate] where Status='" + true + "' order by Sort asc ";
        //dt = dbFunctions.GetData(cmd);
        dt = dbFunctions.GetData("exec SP_GetAdminStadiumsDetails @type='gov',@userid=" + Session["MaleabnaCMSUserID"]);
        if (dt.Rows.Count != 0)
        {
            DDLGovernorate.DataSource = dt;
            DDLGovernorate.DataTextField = "GovernorateName";
            DDLGovernorate.DataValueField = "GovernorateID";
            DDLGovernorate.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLGovernorate.Items.Add(it_bo);
        }
        else
        {
            DDLGovernorate.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLGovernorate.Items.Add(it_bo);
        }
    }

    protected void DDLGovernorate_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillArea(DDLGovernorate.SelectedValue);
    }
    private void fillArea(string StrGovernorateID)
    {
        string cmd;
        DataTable dt;
        //cmd = "select AreaID,AreaName + ' - ' + ISNULL(AreaNameEn,'') AS AreaName from [MYA_Maleabna_Area] where Status='" + true + "' and GovernorateID=" + StrGovernorateID + "  order by AreaName asc ";
        //dt = dbFunctions.GetData(cmd);
       // dt = dbFunctions.GetData("exec SP_GetAdminStadiumsDetails @type='area',@userid=" + Session["MaleabnaCMSUserID"]);
        dt = dbFunctions.GetData("exec SP_GetAdminStadiumsDetails @type='area',@govid='" + (DDLGovernorate.SelectedValue == "0" ? "" : DDLGovernorate.SelectedValue) + "',@userid=" + Session["MaleabnaCMSUserID"]);
        if (dt.Rows.Count != 0)
        {
            DDLArea.DataSource = dt;
            DDLArea.DataTextField = "AreaName";
            DDLArea.DataValueField = "AreaID";
            DDLArea.DataBind();

            if (dt.Rows.Count == 1)
            {
                DDLArea.Enabled = false;
            }
            else
            {
                DDLArea.Enabled = true;
                ListItem it_bo = new ListItem();
                it_bo.Text = "<--أختار-->";
                it_bo.Value = "0";
                it_bo.Selected = true;
                DDLArea.Items.Add(it_bo);
            }
        }
        else
        {
            DDLArea.Items.Clear();

            DDLArea.Enabled = true;
            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLArea.Items.Add(it_bo);
        }
    }



    private void fillArea()
    {
        string cmd;
        DataTable dt;
        //cmd = "select AreaID,AreaName + ' - ' + AreaNameEn AS AreaName from [MYA_Area] where Status='" + true + "' order by AreaName asc ";
        //dt = dbFunctions.GetData(cmd);
        dt = dbFunctions.GetData("exec SP_GetAdminStadiumsDetails @type='area',@userid=" + Session["MaleabnaCMSUserID"]);
        if (dt.Rows.Count != 0)
        {
            DDLArea.DataSource = dt;
            DDLArea.DataTextField = "AreaName";
            DDLArea.DataValueField = "AreaID";
            DDLArea.DataBind();

            if (dt.Rows.Count == 1)
            {
                DDLArea.Enabled = false;
            }
            else
            {
                DDLArea.Enabled = true;
                ListItem it_bo = new ListItem();
                it_bo.Text = "<--أختار-->";
                it_bo.Value = "0";
                it_bo.Selected = true;
                DDLArea.Items.Add(it_bo);
            }
        }
        else
        {
            DDLArea.Items.Clear();

            DDLArea.Enabled = true;
            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLArea.Items.Add(it_bo);
        }
    }
    private void fillData()
    {
        DataTable dt = LoadData();

        if (dt.Rows.Count != 0)
        {
            GVData.DataSource = dt;
            GVData.DataBind();
            lnkDelete.Visible = false;
            GVData.Visible = true;
        }
        else
        {
            lnkDelete.Visible = false;
            GVData.Visible = false;
        }


        lblCount.Text = dt.Rows.Count + " record(s)";
        
    }


    private DataTable LoadData()
    {
        string cmd;
        DataTable dt;


        str = "";

     
        if (DDlStadium.SelectedValue != "0")
            str = str + ",@stadiumid=" + DDlStadium.SelectedValue + " ";

        if (DDLGovernorate.SelectedValue != "0")
            str = str + ",@govid='" + DDLGovernorate.SelectedValue + "'";

        if (DDLArea.SelectedValue != "0")
            str = str + ",@areaid='" + DDLArea.SelectedValue + "'";

        if (TxtFromDate.Text != "")
            str = str + ",@FrmDate='" + TxtFromDate.Text + "'";
        else if (TxtToDate.Text != "")
            str = str + ",@FrmDate='" + TxtToDate.Text + "'";

        if (TxtToDate.Text != "")
            str = str + ",@ToDate='" + TxtToDate.Text + "'";
        else if (TxtFromDate.Text != "")
            str = str + ",@ToDate='" + TxtFromDate.Text+"'";

        str = str + ",@status = " + DDLbookingStatus.SelectedValue;

        str = str + ",@uid=" + Session["MaleabnaCMSUserID"];

        str = str.Trim(new char[] { ',' });     

       


        //cmd = "select * from [V_Booking]" + str + " order by UserID desc";
        //dt = dbFunctions.GetData(cmd);

        dt = dbFunctions.GetData("exec SP_GetBooking " + str);

        return dt;
       
    }

    public void cb0_change(object sender, EventArgs e)
    {
        int i = 0;
        if (((CheckBox)sender).Checked == true)
        {
            for (i = 0; i <= GVData.Rows.Count - 1; i++)
            {
                ((CheckBox)GVData.Rows[i].Cells[0].FindControl("cb")).Checked = true;
            }
        }
        else if (((CheckBox)sender).Checked == false)
        {
            for (i = 0; i <= GVData.Rows.Count - 1; i++)
            {
                ((CheckBox)GVData.Rows[i].Cells[0].FindControl("cb")).Checked = false;
            }
        }
    }

    

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVData.PageIndex = e.NewPageIndex;
        this.fillData();
    }

    public void lnkCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("View_Booking.aspx");
    }

    public void lnkSerach_Click(object sender, EventArgs e)
    {
        GVData.PageIndex = 0;
        fillData();
    }

    public void Status_selected(object sender, EventArgs e)
    {
        string cmd;
        DataTable dt;

        int ItemId;
        string ItemName;
        bool isSelected;
        foreach (GridViewRow row in GVData.Rows)
        {
            ItemId = Convert.ToInt32(((Label)GVData.Rows[i].Cells[0].FindControl("labItemID")).Text);
            ItemName = GVData.Rows[i].Cells[2].Text;
            isSelected = ((CheckBox)GVData.Rows[i].Cells[0].FindControl("ch_Status")).Checked;//row.FindControl("ch_Status") as CheckBox.Checked;

            cmd = "update [MYA_Maleabna_Members] set [Status]='" + isSelected + "' where UserID=" + ItemId;
            dbFunctions.ExecuteQuery(cmd);
            CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, "School", "Update Status", DateTime.Now, "" + ItemId + "", "" + ItemName + "", "");
        }

        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Member Updated Successfully', 'success');", true);

        fillData();
    }
    protected void DDLCancel_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        string confirm_value = Request.Form["confirm_value"];

        if(confirm_value == "Yes")
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.Parent.Parent;
            int rowIndex = row.DataItemIndex;
            int ItemId = Convert.ToInt32(((Label)GVData.Rows[rowIndex].Cells[0].FindControl("labItemID")).Text); //Booking ID

            int Userid = Convert.ToInt32(GVData.DataKeys[rowIndex].Values[0]); //UserID


            hdmail.Value = Convert.ToString(((Label)GVData.Rows[rowIndex].Cells[0].FindControl("LabelEmail")).Text); 
            string Bdate = Convert.ToString(((Label)GVData.Rows[rowIndex].Cells[2].FindControl("LabelDate")).Text); 
            string Btime = GVData.Rows[rowIndex].Cells[4].Text;
            string Stadium = GVData.Rows[rowIndex].Cells[5].Text;

            if (ddl.SelectedValue == "2")
            {
                hdDetails.Value = CancellationDetails(Bdate, Btime, Stadium);

                hdBookingID.Value = ItemId.ToString();
                hdUserID.Value = Userid.ToString();
                
               // CancelBooking(ItemId, Userid);

                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);             

            }
            else if (ddl.SelectedValue == "3")
            {
                memberEnterToStadium(ItemId, Userid);
            }
        }

       
        fillData();

    }


    protected void memberEnterToStadium(int bookingID, int Userid)
    {
        string cmd = "update [MYA_Maleabna_Booking] set BookingStatus='3' where BookingID=" + bookingID + " and UserID=" + Userid;

        dbFunctions.ExecuteQuery(cmd);
        CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, "School", "Update Status", DateTime.Now, "" + bookingID + "", "" + Userid + "", "");
    }

    private string CancellationDetails(string BDate, string Btime, string Stadium)
    {
        string text = "";

        text = text + "Booing Date:" + BDate + " ,"; //booking Date
        text = text + "Booing Time:" + Btime + ","; ; //booking time
        text = text + "Stadium Name:" + Stadium + ","; ; //StadiumName
       


        return text;
    }

    private void CancelBooking(int BID, int UID)
    {
        string sp = "SP_AddEdit_MYA_Maleabna_BookingCancel";
        try
        {
            SqlConnection CN = new SqlConnection();
            CN = dbFunctions.GetConnection();
            SqlCommand cmd = new SqlCommand(sp, CN);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ac_Flag", "I");
            cmd.Parameters.Add("@ai_BookingCancelID", "0");
            cmd.Parameters.Add("@ai_BookingID", BID);
            cmd.Parameters.Add("@ai_UserID", UID);
            cmd.Parameters.Add("@ai_PaymentReturn", "0");
            cmd.Parameters.Add("@ai_Amount", "0");
            cmd.Parameters.Add("@ai_CancelDate", DateTime.Now);
            cmd.Parameters.Add("@ai_cancelby", Session["MaleabnaCMSUserID"].ToString());
           
            CN.Open();
            cmd.ExecuteNonQuery();
            CN.Close();

        }
        catch (Exception Ex)
        {
            Response.Write(Ex);
        }
    }


    private bool email(string email, string cancellationDetails, string CancellationTxtByAdmin)
    {
        string text = "";
        cancellationDetails = cancellationDetails.Replace(",", "<br />");

        text = text + cancellationDetails + " <br />";

        if (radioemail.SelectedValue == "1")
        {
            text = text + CancellationTxtByAdmin + " <br />";
        }
        else
            text = text + " Has been Cancelled";


        int i = CMSSendEmail.GeneralEmail(email, text);
        if (i == 0)
            return true;
        else
            return false;
    }




    protected void GVData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string bstatus = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BookingStatus")); //Status value from table


            DropDownList ddl = (DropDownList)(e.Row.FindControl("DDLCancel"));

            if (bstatus == "2")
            {
                ddl.Items.FindByValue(bstatus).Selected = true;
                ddl.BackColor = System.Drawing.Color.FromArgb(255, 182, 193);
                ddl.ForeColor = System.Drawing.Color.Black;
            }
            else if (bstatus == "1")
            {
                ddl.Items.FindByValue(bstatus).Selected = true;
                ddl.BackColor = System.Drawing.Color.FromArgb(185, 254, 185); 
                ddl.ForeColor = System.Drawing.Color.Black;
            }
            else if (bstatus == "0")
            {
                //#FF80AA
                ddl.Items.FindByValue(bstatus).Selected = true;
                ddl.BackColor = System.Drawing.Color.FromArgb(255, 128, 170);
                ddl.ForeColor = System.Drawing.Color.Black;
            }
            else if (bstatus == "3")
            {
                //#FF80AA
                ddl.Items.FindByValue(bstatus).Selected = true;
                ddl.BackColor = System.Drawing.Color.FromArgb(102, 178, 255);
                ddl.ForeColor = System.Drawing.Color.Black;
            }



        }
    }

    protected void lnkmail_Click(object sender, EventArgs e)
    {

        if (email(hdmail.Value, hdDetails.Value, txtEmailText.Text))
        {
            CancelBooking(int.Parse(hdBookingID.Value), int.Parse(hdUserID.Value));
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Booking Cancelled Successfully', 'success');", true);
        }
        else
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Booking is not Cancelled', 'error');", true);

        fillData();
        
    }
 
    protected void radioemail_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DivEmailText
        if (radioemail.SelectedValue.Equals("1"))
        {
            radioemail.Visible = true;
        }
        else
            radioemail.Visible = false;

    }
   

    protected void lnkExcel_Click(object sender, EventArgs e)
    {
        DataTable dt;
       // dt = dbFunctions.GetData("select Name,CivilID,[V_Members].Email,Phone,GovernorateName,StadiumName,format(BookingDate,'dd/MM/yyyy') as BookingDate,BookingTime from [V_Booking] join [V_Members] on  V_Booking.UserID = V_Members.UserID where BookingStatus = '1' order by BookingDate desc");
        dt = LoadData();

        RemoveReOrderColumns(dt);

        DataGrid dg = new DataGrid();
        dg.DataSource = dt;
        dg.DataBind();


        string hex = "#E2EDF2";
        Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
        dg.AlternatingItemStyle.BackColor = _color;

        string sFileName = "MalebnaBookingList-" + System.DateTime.Now.Date + ".xls";
        sFileName = sFileName.Replace("/", "");


        foreach (DataGridItem dataGridItem in dg.Items)
        {
            dataGridItem.Cells[2].Attributes.Add("class", "text");
        }




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


    private void RemoveReOrderColumns(DataTable dt)
    {
        
        dt.Columns.Remove("BookingID");

        dt.Columns.Remove("UserID");

        dt.Columns.Remove("StadiumID");

        dt.Columns.Remove("SMSStatus");
        dt.Columns.Remove("EmailStatus");

        dt.Columns.Remove("BookingStatus");

        dt.Columns.Remove("PaymentStatus");

        dt.Columns.Remove("CreatedAt");

        dt.Columns.Remove("StadiumDetId");
        dt.Columns.Remove("CancelledBy");

        dt.Columns.Remove("PaymentMode");
        dt.Columns.Remove("rate");
        dt.Columns.Remove("BookingIDUniq");

        DataTable datatable = dt;

        //dt.Columns.Remove("OTP");
        //dt.Columns[0].SetOrdinal(4);
        //dt.Columns[1].SetOrdinal(5);
        //dt.Columns[2].SetOrdinal(0);
        //dt.Columns[3].SetOrdinal(2);
        //dt.Columns[4].SetOrdinal(3);
        //dt.Columns[5].SetOrdinal(1);

    }
    protected void DDLArea_SelectedIndexChanged(object sender, EventArgs e)
    {

        DDlStadium.Items.Clear();
        string cmd;
        DataTable dt;
        //cmd = "select StadiumID,StadiumName + ' - ' + StadiumNameEn AS StadiumName from [MYA_Maleabna_Stadium] where Status='" + true + "' order by StadiumName asc ";
        //dt = dbFunctions.GetData(cmd);
       // dt = dbFunctions.GetData("exec SP_GetAdminStadiumsDetails @type='stadiumbyArea',@areaid='" + (DDLArea.SelectedValue == "0" ? "" : DDLArea.SelectedValue) + "');

        dt = dbFunctions.GetData("select StadiumID , StadiumName  from MYA_Maleabna_Stadium  where AreaID = "+DDLArea.SelectedValue);
        
        //select StadiumID , StadiumName  from MYA_Maleabna_Stadium  where AreaID = 121 and GovernorateID = 2
        
        if (dt.Rows.Count != 0)
        {
            DDlStadium.DataSource = dt;
            DDlStadium.DataTextField = "StadiumName";
            DDlStadium.DataValueField = "StadiumID";
            DDlStadium.DataBind();
            if (dt.Rows.Count == 1)
            {
                DDlStadium.Enabled = false;
            }
            else
            {
                DDlStadium.Enabled = true;

                ListItem it_bo = new ListItem();
                it_bo.Text = "<--أختار-->";
                it_bo.Value = "0";
                it_bo.Selected = true;
                DDlStadium.Items.Add(it_bo);
            }
        }
        else
        {
            DDlStadium.Items.Clear();
            DDlStadium.Enabled = true;

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDlStadium.Items.Add(it_bo);
        }
    }
}