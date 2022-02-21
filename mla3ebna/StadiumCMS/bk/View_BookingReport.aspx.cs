using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class View_MembersReport : System.Web.UI.Page
{
    int i;
    string str;
    string[] arr;
    public string StrPrintbtn;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            CMSCurrentUser.CheckLoggedIn();

            fillGovernorate();

            fillArea();

            fillSchool();

            fillStadium();

            fillTimeSlot();


            lnkDelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete?')";

            fillData();

            //StrPrintbtn = " <a class='btn btn-round  btn-outline-danger btnBig' href='javascript:void(0);'   onclick='openWinPrint()'><i class='fa fa-print'></i><span></span></a>";
        }
    }

    private void fillGovernorate()
    {
        string cmd;
        DataTable dt;
        cmd = "select GovernorateID,GovernorateName + ' - ' + GovernorateNameEn AS GovernorateName from [MYA_Maleabna_Governorate] where Status='" + true + "' order by Sort asc ";
        dt = dbFunctions.GetData(cmd);
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

        DDLArea.Items.Clear();
        DDLSchool.Items.Clear();
        DDLStadium.Items.Clear();
    }

    protected void DDLGovernorate_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        fillArea();
        fillData();
    }
    

    private void fillArea()
    {
        DDLSchool.Items.Clear();
        DDLStadium.Items.Clear();

        string cmd;
        DataTable dt;

        if (DDLGovernorate.SelectedValue != "0" && DDLGovernorate.SelectedValue != "")
            cmd = "select AreaID,AreaName + ' - ' + ISNULL(AreaNameEn,'') AS AreaName from [MYA_Maleabna_Area] where Status='" + true + "' and GovernorateID=" + DDLGovernorate.SelectedValue + "  order by AreaName asc ";
        else
            cmd = "select AreaID,AreaName + ' - ' + ISNULL(AreaNameEn,'') AS AreaName from [MYA_Maleabna_Area] where Status='" + true + "' order by AreaName asc ";
        dt = dbFunctions.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLArea.DataSource = dt;
            DDLArea.DataTextField = "AreaName";
            DDLArea.DataValueField = "AreaID";
            DDLArea.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLArea.Items.Add(it_bo);
        }
        else
        {
            DDLArea.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLArea.Items.Add(it_bo);
        }
    }



    private void fillSchool()
    {
        DDLStadium.Items.Clear();

        string cmd;
        DataTable dt;
        if (!string.IsNullOrEmpty(DDLArea.SelectedValue) && !DDLArea.SelectedValue.Equals("0"))
            cmd = "select SchoolID,SchoolName + ' - ' + ISNULL(SchoolNameEn,'') AS SchoolName from [MYA_Maleabna_School] where Status='" + true + "' and AreaID=" + DDLArea.SelectedValue + "  order by SchoolName asc ";
        else
            cmd = "select SchoolID,SchoolName + ' - ' + ISNULL(SchoolNameEn,'') AS SchoolName from [MYA_Maleabna_School] where Status='" + true + "' order by SchoolName asc ";
        dt = dbFunctions.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLSchool.DataSource = dt;
            DDLSchool.DataTextField = "SchoolName";
            DDLSchool.DataValueField = "SchoolID";
            DDLSchool.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLSchool.Items.Add(it_bo);
        }
        else
        {
            DDLSchool.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLSchool.Items.Add(it_bo);
        }
    }

    private void fillStadium()
    {
       

        string cmd;
        DataTable dt;

        if (DDLSchool.SelectedValue.Trim() != "0" && DDLSchool.SelectedValue != "")
            cmd = "select StadiumID,StadiumName + ' - ' + StadiumNameEn AS StadiumName from [MYA_Maleabna_Stadium]  where Status='" + true + "' and SchoolID=" + DDLSchool.SelectedValue + " order by StadiumName asc ";
        else
            cmd = "select StadiumID,StadiumName + ' - ' + StadiumNameEn AS StadiumName from [MYA_Maleabna_Stadium]  where Status='" + true + "' order by StadiumName asc ";

        dt = dbFunctions.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLStadium.DataSource = dt;
            DDLStadium.DataTextField = "StadiumName";
            DDLStadium.DataValueField = "StadiumID";

            //DDLStadium.SelectedValue = null;
            DDLStadium.DataBind();

            ListItem it_bo = new ListItem();

            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;


            DDLStadium.Items.Add(it_bo);            
        }
        else
        {

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLStadium.Items.Add(it_bo);

            

        }
    }

    private void fillTimeSlot()
    {
        string cmd;
        DataTable dt;

        // cmd = "select max(TimeSlotDetID) as TimeSlotDetID,TimeSlot from [MYA_Maleabna_TimeSlot_Det] where TimeSlotMasterID in ( select [TimeSlotMasterID] from [MYA_Maleabna_TimeSlot_Master] where (('" + FromDate + "'between DateFrm and DateTo) and('" + ToDate + "' between DateFrm and DateTo)) and Type in ('Custom','Special')) group by timeslot";

        cmd = "select max(TimeSlotDetID) as TimeSlotDetID,TimeSlot from [MYA_Maleabna_TimeSlot_Det] where TimeSlotMasterID in ( select [TimeSlotMasterID] from [MYA_Maleabna_TimeSlot_Master] where Type ='Default') group by timeslot";


        dt = dbFunctions.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            DDLTimeSlot.DataSource = dt;
            DDLTimeSlot.DataTextField = "TimeSlot";
            DDLTimeSlot.DataValueField = "TimeSlotDetID";
            DDLTimeSlot.DataBind();


            ListItem it_bo = new ListItem();

            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;


            DDLTimeSlot.Items.Add(it_bo); 

        }
        else
        {

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLTimeSlot.Items.Add(it_bo);

        }
    }

    private void fillData()
    {

        DataTable dt;
        dt = LoadData();

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

        if (DDLGovernorate.SelectedValue != "0" && DDLGovernorate.SelectedValue != "")
            str = str + ",GovernorateID=" + DDLGovernorate.SelectedValue + " ";

        if (DDLArea.SelectedValue != "0" && DDLArea.SelectedValue != "")
            str = str + ",AreaID=" + DDLArea.SelectedValue + " ";


        if (DDLSchool.SelectedValue != "0" && DDLSchool.SelectedValue != "")
            str = str + ",SchoolID=" + DDLSchool.SelectedValue + " ";


        if (DDLStadium.SelectedValue != "0" && DDLStadium.SelectedValue != "")
            str = str + ",StadiumID=" + DDLStadium.SelectedValue + " ";

        if (DDLTimeSlot.SelectedValue != "0")
            str = str + ",BookingTime ='" + DDLTimeSlot.SelectedItem.Text.Trim() + "' ";

        if (DDLOther.SelectedValue != "0")
        {
            if (DDLOther.SelectedValue == "1")
                str = str + ",CivilID ='" + TxtOther.Text.Trim() + "' ";
            else if (DDLOther.SelectedValue == "2")
                str = str + ",Phone ='" + TxtOther.Text.Trim() + "' ";
            else if (DDLOther.SelectedValue == "3")
                str = str + ",Email ='" + TxtOther.Text.Trim() + "' ";
        }

        
        if (!string.IsNullOrEmpty(TxtFromDate.Text))
        {
            if (String.IsNullOrEmpty(TxtToDate.Text))
                TxtToDate.Text = TxtFromDate.Text;

            str = str + ",( cast(BookingDate As date) between '" + TxtFromDate.Text + "' and '" + TxtToDate.Text + "')" + " ";

        }
        

        str = str + ",BookingStatus='1'";

        arr = str.Split(',');



        if (str != "")
        {
            str = " where ";
        }

        for (var i = 0; i < arr.Length; i++)
        {
            if (i > 1)
            {
                str = str + " and ";
            }
            str = str + (arr[i]);

        }

        if (DDLday.SelectedValue != "0")
        {
            if (str != "")
                str = str + " and DATENAME(WEEKDAY, BookingDate) = '" + DDLday.SelectedItem.Text.Trim()+"'";
            else
                str = "where DATENAME(WEEKDAY, BookingDate) ='" + DDLday.SelectedItem.Text.Trim()+"'";
        }


        cmd = "select * from [V_BookingReport]" + str + " order by BookingID desc";

        dt = dbFunctions.GetData(cmd);

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
        Response.Redirect("View_BookingReport.aspx");
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
    protected void DDLArea_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        fillSchool();
        fillData();
    }
    protected void DDLSchool_SelectedIndexChanged(object sender, EventArgs e)
    {       
       
        fillStadium();
        fillData();
    }
    protected void DDLStadium_SelectedIndexChanged(object sender, EventArgs e)
    {        
        fillData();
    }
    protected void DDLStadiumCourt_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillData();
    }
    protected void TxtFromDate_TextChanged(object sender, EventArgs e)
    {
        fillData();
    }
    protected void TxtToDate_TextChanged(object sender, EventArgs e)
    {
        fillData();
    }
    protected void DDLTimeSlot_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillData();
    }
    protected void DDLOther_SelectedIndexChanged(object sender, EventArgs e)
    {
        LblOther.Text = "";
        TxtOther.Text = "";

        if (DDLOther.SelectedValue != "0")
        {
            DivOther.Visible = true;

            if (DDLOther.SelectedValue == "1")
                LblOther.Text = "CivilID";
            else if (DDLOther.SelectedValue == "2")
                LblOther.Text = "Phone";
            else if (DDLOther.SelectedValue == "3")
                LblOther.Text = "Email";
        }
        else
            DivOther.Visible = false;
    }
    protected void TxtOther_TextChanged(object sender, EventArgs e)
    {
        fillData();
    }


    private void RemoveReOrderColumns(DataTable dt)
    {
        dt.Columns.Remove("GovernorateID");

        dt.Columns.Remove("AreaID");

        dt.Columns.Remove("SchoolID");

        dt.Columns.Remove("StadiumID");
        dt.Columns.Remove("BookingID");

        dt.Columns.Remove("UserID");
        dt.Columns.Remove("BookingStatus");

    }
    
    protected void btnExport_Click(object sender, EventArgs e)
    {

        DataTable dt = new DataTable();
        dt = LoadData();
        RemoveReOrderColumns(dt);
        DataGrid dg = new DataGrid();
        dg.DataSource = dt;
        dg.DataBind();


        string hex = "#E2EDF2";
        Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
        dg.AlternatingItemStyle.BackColor = _color;

        string sFileName = "Malaebna-BookingReport-" + System.DateTime.Now.Date + ".xls";
        sFileName = sFileName.Replace("/", "");

       
        foreach (DataGridItem dataGridItem in dg.Items)
        {
           // dataGridItem.Cells[4].Attributes.Add("class", "text");
            dataGridItem.Cells[4].Attributes.Add("style", "mso-number-format");
          
            //dataGridItem.Cells[2].Attributes.Add("style", "font-family: 'Neo Sans Arabic';");
        }


        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment; filename=" + sFileName);


        Response.ContentEncoding = System.Text.Encoding.Unicode;  // this two lines are used to show arabic text as a proper text
        Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());


        Response.ContentType = "application/vnd.ms-excel";
        EnableViewState = false;

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


    protected void DDLday_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillData();
    }
   


  
}