using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StadiumCMS_View_Members : System.Web.UI.Page
{
    int i;
    string str;
    string[] arr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            CMSCurrentUser.CheckLoggedIn();

            fillGovernorate();

            fillArea(DDLGovernorate.SelectedValue);

           
            lnkDelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete?')";

           fillData();
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

            if (dt.Rows.Count == 1)
            {
                DDLGovernorate.Enabled = false;
            }
            else
            {
                DDLGovernorate.Enabled = true;

                ListItem it_bo = new ListItem();
                it_bo.Text = "<--أختار-->";
                it_bo.Value = "0";
               // it_bo.Selected = true;
                DDLGovernorate.Items.Add(it_bo);
            }
        }
        else
        {
            DDLGovernorate.Items.Clear();
            DDLGovernorate.Enabled = true;

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
        dt = dbFunctions.GetData("exec SP_GetAdminStadiumsDetails @type='area',@userid=" + Session["MaleabnaCMSUserID"]);
        //dt = dbFunctions.GetData(cmd);
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

    
    
    //private void fillArea()
    //{
    //    string cmd;
    //    DataTable dt;
    //    cmd = "select AreaID,AreaName + ' - ' + AreaNameEn AS AreaName from [MYA_Area] where Status='" + true + "' order by AreaName asc ";
    //    dt = dbFunctions.GetData(cmd);
    //    if (dt.Rows.Count != 0)
    //    {
    //        DDLArea.DataSource = dt;
    //        DDLArea.DataTextField = "AreaName";
    //        DDLArea.DataValueField = "AreaID";
    //        DDLArea.DataBind();

    //        ListItem it_bo = new ListItem();
    //        it_bo.Text = "<--أختار-->";
    //        it_bo.Value = "0";
    //        it_bo.Selected = true;
    //        DDLArea.Items.Add(it_bo);
    //    }
    //    else
    //    {
    //        DDLArea.Items.Clear();


    //        ListItem it_bo = new ListItem();
    //        it_bo.Text = "<--أختار-->";
    //        it_bo.Value = "0";
    //        it_bo.Selected = true;
    //        DDLArea.Items.Add(it_bo);
    //    }
    //}


    private DataTable LoadData()
    {
        string cmd;
        DataTable dt;


        str = "";

        if (TxtName.Text != "")
        {
           // str = str + ",Name like N'%" + TxtName.Text + "%' ";
            str = str + ",@name='" + TxtName.Text + "'";
        }

        if (TxtMobile.Text != "")
        {
            str = str + ",@mobile ='" + TxtMobile.Text + "' ";
        }

        if (DDLGovernorate.SelectedValue != "0")
            str = str + ",@GovID=" + DDLGovernorate.SelectedValue + " ";

        //if (DDLArea.SelectedValue != "0")
        //    str = str + ",AreaID=" + DDLArea.SelectedValue + " ";


        str = str + ",@status= " + DDLMemberStatus.SelectedValue;

        str = str + ",@uid=" + Session["MaleabnaCMSUserID"];

        str = str.Trim(new char[] { ','});


        //cmd = "select * from [V_Members]" + str + " order by UserID desc";

        //dt = dbFunctions.GetData(cmd);
        dt = dbFunctions.GetData("exec SP_GetMembers " + str);

        return dt;
    }

    private void fillData( )
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
        Response.Redirect("View_Members.aspx");
    }

    public void lnkSerach_Click(object sender, EventArgs e)
    {
        GVData.PageIndex = 0;
        fillData();
    }

    public void Status_selected(object sender, EventArgs e)
    {
        string cmd;
        

        int ItemId;
        string ItemName;
        bool isSelected;
        string emailText;

        CheckBox chk = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chk.Parent.Parent;
        int i = row.DataItemIndex;
        ItemId = Convert.ToInt32(((Label)GVData.Rows[i].Cells[0].FindControl("labItemID")).Text);
        ItemName = GVData.Rows[i].Cells[2].Text;
        string Uemail = GVData.Rows[i].Cells[5].Text;


        isSelected = ((CheckBox)GVData.Rows[i].Cells[0].FindControl("ch_Status")).Checked;

        cmd = "update [MYA_Maleabna_Members] set [Status]='" + isSelected + "' where UserID=" + ItemId;


        if (isSelected)
            emailText = "Your Email is Active now, You can Book Stadiums.";
        else
            emailText = "Your Email is Blocked, You can not Book Stadiums.";

        if (email(Uemail, emailText))
        {
            dbFunctions.ExecuteQuery(cmd);
            CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, "School", "Update Status", DateTime.Now, "" + ItemId + "", "" + ItemName + "", "");

            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Member Deails are Updated Successfully', 'success');", true);
        
        }


        
       
        //foreach (GridViewRow row in GVData.Rows)
        //{
        //    int i = row.DataItemIndex;
        //    ItemId = Convert.ToInt32(((Label)GVData.Rows[i].Cells[0].FindControl("labItemID")).Text);
        //    ItemName = GVData.Rows[i].Cells[2].Text;
        //    isSelected = ((CheckBox)GVData.Rows[i].Cells[0].FindControl("ch_Status")).Checked;//row.FindControl("ch_Status") as CheckBox.Checked;

        //    cmd = "update [MYA_Maleabna_Members] set [Status]='" + isSelected + "' where UserID=" + ItemId;
        //    dbFunctions.ExecuteQuery(cmd);
        //    CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, "School", "Update Status", DateTime.Now, "" + ItemId + "", "" + ItemName + "", "");
        //}

       // ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Member Updated Successfully', 'success');", true);

        fillData();
    }

    protected void DDLStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.Parent.Parent;
            int i = row.DataItemIndex;
            int ItemId = Convert.ToInt32(((Label)GVData.Rows[i].Cells[0].FindControl("labItemID")).Text);
            string UserEmail = GVData.Rows[i].Cells[5].Text;


            if (ddl.SelectedValue != "*")
            {
                UpdateMemberStatus(ItemId, int.Parse(ddl.SelectedValue), UserEmail);               
            }
        }
       
        fillData();
    }

    protected void UpdateMemberStatus(int ItemId, int status, string Uemail)
    {
        string cmd;
        string emailText = "";

        if (status == 2)
        {
            cmd = "Delete [MYA_Maleabna_Members] where UserID=" + ItemId;
            emailText = "Your Email is Deleted From the Mubaratna Users, You can not Book Stadiums.";
        }
        else
        {
            cmd = "update [MYA_Maleabna_Members] set [Status]='" + status + "' where UserID=" + ItemId;

            if(status == 1)
                emailText = "Your Email is Active now, You can Book Stadiums.";
            else if(status == 0)
                emailText = "Your Email is Blocked, You can not Book Stadiums.";
        }
       
        if (email(Uemail, emailText))
        {
            dbFunctions.ExecuteQuery(cmd);
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Member Deails are Updated Successfully', 'success');", true);
        }
        
    }


    private bool email(string email,string text)
    {      

       
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
            string memstatus = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Status")); //Status value from table


            DropDownList ddl = (DropDownList)(e.Row.FindControl("DDLStatus"));
           

            if (memstatus == "False")
            {
                ddl.SelectedValue = "0";
                ddl.BackColor = System.Drawing.Color.FromArgb(255, 182, 193);
                ddl.ForeColor = System.Drawing.Color.Black;
            }
            else if (memstatus == "True")
            {
                ddl.SelectedValue = "1";
                ddl.BackColor = System.Drawing.Color.FromArgb(185, 254, 185);
                ddl.ForeColor = System.Drawing.Color.Black;
            }

            else
            {
                ddl.SelectedValue = "*";
                //ddl.BackColor = System.Drawing.Color.FromArgb(185, 254, 185);
                ddl.ForeColor = System.Drawing.Color.Blue;
            }
        }
    }

    protected void TxtName_TextChanged(object sender, EventArgs e)
    {
        GVData.PageIndex = 0;
        fillData();
    }
    

    protected void lnkExcel_Click(object sender, EventArgs e)
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

        string sFileName = "Malaebna-MemberList-" + System.DateTime.Now.Date + ".xls";
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


    private void RemoveReOrderColumns(DataTable dt)
    {
        dt.Columns.Remove("Status");

        dt.Columns.Remove("PWD");

        dt.Columns.Remove("CreatedAt");

        dt.Columns.Remove("smsStatus");
        dt.Columns.Remove("EmailStatus");

        dt.Columns.Remove("WalletAmount");

        dt.Columns.Remove("OTP");

        dt.Columns.Remove("smscount");
        dt.Columns.Remove("UserID");

        dt.Columns.Remove("UserType");
        //dt.Columns.Remove("OTP");

        //dt.Columns.Remove("OTP");

        //dt.Columns.Remove("OTP");


    }

}