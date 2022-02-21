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

public partial class ViewInitiative_Search_Initiative : System.Web.UI.Page
{
    int i;
    string str;
    string[] arr;
    public string  StrInstitutionID, StrBusinessNurseryID, StrUserGroupID, StrMYAAllStage, StrMYAStage1, StrMYAStage2, StrMYAStage3, StrMYAStage4, StrMYAStage5, StrMYAStage6, StrMYAStage7, StrBNAllStage, StrBNStage1, StrBNStage2, StrBNStage3, StrBNStage4;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            ViewInitiativeAppCurrentUser.CheckLoggedIn();

            StrUserGroupID = Session["MYAPIVIAppUserGroupID"].ToString();

            StrInstitutionID = Session["MYAPIVIAppInstitution"].ToString();

            StrBusinessNurseryID = Session["MYAPIVIAppBusinessNurseryID"].ToString();




            StrMYAAllStage = Session["MYAPIVIAppMYAAllStage"].ToString();

            StrMYAStage1 = Session["MYAPIVIAppMYAStage1"].ToString();

            StrMYAStage2 = Session["MYAPIVIAppMYAStage2"].ToString();

            StrMYAStage3 = Session["MYAPIVIAppMYAStage3"].ToString();

            StrMYAStage4 = Session["MYAPIVIAppMYAStage4"].ToString();

            StrMYAStage5 = Session["MYAPIVIAppMYAStage5"].ToString();

            StrMYAStage6 = Session["MYAPIVIAppMYAStage6"].ToString();

            StrMYAStage7 = Session["MYAPIVIAppMYAStage7"].ToString();


            StrBNAllStage = Session["MYAPIVIAppBNAllStage"].ToString();

            StrBNStage1 = Session["MYAPIVIAppBNStage1"].ToString();

            StrBNStage2 = Session["MYAPIVIAppBNStage2"].ToString();

            StrBNStage3 = Session["MYAPIVIAppBNStage3"].ToString();

            StrBNStage4 = Session["MYAPIVIAppBNStage4"].ToString();

            fillType();

            fillCategory();

            fillStage();

           // fillStatus();

            if (!string.IsNullOrEmpty(Request.QueryString["Status"]))
            {
                DDLStatus.SelectedValue = Request.QueryString["Status"];
            }

                lnkDelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete?')";
            fillData();
        }
    }

    private void fillType()
    {
        string cmd;
        DataTable dt;
        cmd = "select * from [MYA_PI_Type] where Status='" + true + "' order by Sort asc ";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLType.DataSource = dt;
            DDLType.DataTextField = "NameAr";
            DDLType.DataValueField = "id";
            DDLType.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLType.Items.Add(it_bo);
        }
        else
        {
            DDLType.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLType.Items.Add(it_bo);
        }
    }
    private void fillCategory()
    {
        string cmd;
        DataTable dt;
        cmd = "select * from [MYA_PI_Category] where Status='" + true + "' order by Sort asc ";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLCategory.DataSource = dt;
            DDLCategory.DataTextField = "NameAr";
            DDLCategory.DataValueField = "id";
            DDLCategory.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLCategory.Items.Add(it_bo);
        }
        else
        {
            DDLCategory.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLCategory.Items.Add(it_bo);
        }
    }
    private void fillStage()
    {
        string cmd;
        DataTable dt;
        cmd = "select * from [MYA_PI_Stage] where Status='" + true + "' order by Sort asc ";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLStage.DataSource = dt;
            DDLStage.DataTextField = "NameAr";
            DDLStage.DataValueField = "id";
            DDLStage.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLStage.Items.Add(it_bo);
        }
        else
        {
            DDLStage.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLStage.Items.Add(it_bo);
        }
    }

    private void fillStatus()
    {
        string cmd;
        DataTable dt;
        cmd = "select * from [MYA_PI_Status] where Status='" + true + "' order by Sort asc ";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLStatus.DataSource = dt;
            DDLStatus.DataTextField = "NameAr";
            DDLStatus.DataValueField = "id";
            DDLStatus.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLStatus.Items.Add(it_bo);
        }
        else
        {
            DDLStatus.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLStatus.Items.Add(it_bo);
        }
    }

    public bool chkImg(object str)
    {
        //try
        //{
        //    if (str.IndexOf(".") != -1)
        //        return true;
        //    else
        //        return false;
        //}
        //catch (Exception ex)
        //{
        //    return false;
        //}
        return true;
    }

    private DataTable FillDataTable()
    {  

        string ls_params = "@ininame='" + TxtName.Text +"',@startDate='" + TxtFromDate.Text + "',@endDate='"+TxtToDate.Text+"'";

        if (DDLCategory.SelectedValue != "0")
            ls_params = ls_params + ",@category='" + (DDLCategory.SelectedValue == "0" ? "" : DDLCategory.SelectedValue) + "'";
        if (DDLType.SelectedValue != "0")
            ls_params = ls_params + ",@type='" + (DDLType.SelectedValue == "0" ? "" : DDLType.SelectedValue) + "'";

        if (ddlSerachByMultiple.SelectedValue == "1")
            ls_params = ls_params + ",@civil='"+txtSearch.Text+"'";
        else if (ddlSerachByMultiple.SelectedValue == "2")
            ls_params = ls_params + ",@email='" + txtSearch.Text + "'";
        else if (ddlSerachByMultiple.SelectedValue == "3")
            ls_params = ls_params + ",@name='" + txtSearch.Text + "'";
        else if (ddlSerachByMultiple.SelectedValue == "4")
            ls_params = ls_params + ",@iniNumber='" + txtSearch.Text + "'";

       DataTable dt = GetData("exec ProfessionalInitiativeSearch " + ls_params);

        return dt;

    }

    public static DataTable GetData(string qry)
    {
        General gm = new General();
        SqlConnection CN = new SqlConnection();

        CN.ConnectionString = gm.ConnectionStringMYAPI();       
        SqlDataAdapter adpt = new SqlDataAdapter(qry, CN);
        DataTable dt = new DataTable();
        CN.Open();
        adpt.Fill(dt);
        CN.Close();
        return dt;

    }

    private void fillData()
    {
       
        DataTable dt = FillDataTable();

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

    public string GetPhaseDetails(object s)
    {
        string cmd, strresult, strInstitution, StrStage;
        DataTable dt;

        strresult = "";
        strInstitution = "";
        StrStage = "";

        cmd = "select * from [V_AllInitiative]  where id=" + s + " order by id desc";
        dt = dbFunctions_YPI.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["InstitutionID"]))
            {
                if (dt.Rows[0]["InstitutionID"].ToString() == "1")
                {
                    strInstitution = "<b> مكتب وزير الدولة لشئون الشباب </b>";
                }
                else if (dt.Rows[0]["InstitutionID"].ToString() == "2")
                {
                    if (!DBNull.Value.Equals(dt.Rows[0]["BusinessNurseryID"]))
                    {
                        if (dt.Rows[0]["BusinessNurseryID"].ToString() == "0")
                        {
                            strInstitution = "حاضنة الأعمال";
                        }
                        else
                        {
                            strInstitution = "حاضنة الأعمال ( " + GetBusinessNurseryText(dt.Rows[0]["BusinessNurseryID"].ToString()) + " )";
                        }
                    }
                }
                else { strInstitution = "-"; }

            }

            if (!DBNull.Value.Equals(dt.Rows[0]["Stage"]))
            {
               
                StrStage = dt.Rows[0]["Stage"].ToString() + " - " + GetStageText(dt.Rows[0]["Stage"].ToString());
               

            }
        }


        strresult = strInstitution + "<br><br>" + StrStage;



        return strresult;
    }

    public string GetBusinessNurseryText(string s)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";

        cmd = "select * from [MYA_PI_BusinessNursery] where id=" + s + " order by id desc";
        //Response.Write(cmd);
        dt = dbFunctions_YPI.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["NameAr"]))
            {
                strresult = dt.Rows[0]["NameAr"].ToString();
            }

        }

        return strresult;
    }

    public string GetStageText(string s)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";

        cmd = "select * from [MYA_PI_Stage] where id=" + s + " order by id desc";
        //Response.Write(cmd);
        dt = dbFunctions_YPI.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["NameAr"]))
            {
                strresult = dt.Rows[0]["NameAr"].ToString();
            }

        }

        return strresult;
    }

    public string GetQuotationStatus(object objID)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";

        cmd = "select * from [MYA_PI_Initiative]  where id=" + objID + " order by id desc";
        dt = dbFunctions_YPI.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["Status"]))
            {
                if (dt.Rows[0]["Status"].ToString() == "1")
                {
                    strresult = "<span class='status-pill smaller blue'></span><span class='text-info'>&nbsp;" + GetStatusName(dt.Rows[0]["Status"].ToString()) + "</span>";
                }

                if (dt.Rows[0]["Status"].ToString() == "2")
                {
                    strresult = "<span class='status-pill smaller blue'></span><span class='text-info'>&nbsp;" + GetStatusName(dt.Rows[0]["Status"].ToString()) + "</span>";
                }

                if (dt.Rows[0]["Status"].ToString() == "3")
                {
                    strresult = "<span class='status-pill smaller blue'></span><span class='text-info'>&nbsp;" + GetStatusName(dt.Rows[0]["Status"].ToString()) + "</span>";
                }

                if (dt.Rows[0]["Status"].ToString() == "4")
                {
                    strresult = "<span class='status-pill smaller blue'></span><span class='text-info'>&nbsp;" + GetStatusName(dt.Rows[0]["Status"].ToString()) + "</span>";
                }

                if (dt.Rows[0]["Status"].ToString() == "5")
                {
                    strresult = "<span class='status-pill smaller blue'></span><span class='text-info'>&nbsp;" + GetStatusName(dt.Rows[0]["Status"].ToString()) + "</span>";
                }

                if (dt.Rows[0]["Status"].ToString() == "6")
                {
                    strresult = "<span class='status-pill smaller blue'></span><span class='text-info'>&nbsp;" + GetStatusName(dt.Rows[0]["Status"].ToString()) + "</span>";
                }


                if (dt.Rows[0]["Status"].ToString() == "7")
                {
                    strresult = "<span class='status-pill smaller blue'></span><span class='text-info'>&nbsp;" + GetStatusName(dt.Rows[0]["Status"].ToString()) + "</span>";
                }

                if (dt.Rows[0]["Status"].ToString() == "8")
                {
                    strresult = "<span class='status-pill smaller green'></span><span class='text-success'>&nbsp;" + GetStatusName(dt.Rows[0]["Status"].ToString()) + "</span>";
                }

                if (dt.Rows[0]["Status"].ToString() == "9")
                {
                    strresult = "<span class='status-pill smaller red'></span><span class='text-danger'>&nbsp;" + GetStatusName(dt.Rows[0]["Status"].ToString()) + "</span>";
                }

                // strresult = dt.Rows[0]["Name"].ToString();
            }


        }


        return strresult;
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

    private void lnkDelete_Click(object sender, EventArgs e)
    {
        string cmd;
        int i;
        for (i = 0; i <= GVData.Rows.Count - 1; i++)
        {
            if (((CheckBox)GVData.Rows[i].Cells[0].FindControl("cb")).Checked == true)
            {
                cmd = "delete from [MYA_PI_Initiative] where [id] = " + ((Label)GVData.Rows[i].Cells[0].FindControl("labItemID")).Text;
                dbFunctions_YPI.ExecuteQuery(cmd);
            }
        }
        fillData();
    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVData.PageIndex = e.NewPageIndex;
        this.fillData();
    }

    public void lnkCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Search_Initiative.aspx");
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

            cmd = "update [MYA_PI_Initiative] set [Status]='" + isSelected + "' where id=" + ItemId;
            dbFunctions_YPI.ExecuteQuery(cmd);
            ViewInitiativeAppUserActivityLog.CreateUserActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "Initiative", "Update Status", DateTime.Now, "" + ItemId + "", "" + ItemName + "", "");
        }
        // CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.GBSAdminUserID, CMSCurrentUser.GBSAdminName, "Vendors", "Update Status To " & isSelected & "", Now, "" & ItemId & "", "" & ItemName & "", "")

        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Patients Status Updated');", true);
        fillData();
    }

    public string GetStatusName(string s)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";

        cmd = "select * from [MYA_PI_Status]  where id=" + s + " order by id desc";
        dt = dbFunctions_YPI.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["NameAr"]))
            {
                strresult = dt.Rows[0]["NameAr"].ToString();
            }

        }


        return strresult;
    }

    public string GetUserInfo(object objID)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";

        cmd = "select * from [User_Basic_Info]  where id=" + objID + "";

        dt = dbFunctions_YPI.GetDataMYAMain(cmd);

        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["Name"]))
            {
                strresult = dt.Rows[0]["Name"].ToString() + " " + dt.Rows[0]["Mname"].ToString() + " " + dt.Rows[0]["TName"].ToString() + " " + dt.Rows[0]["Lname"].ToString() + "<br>" + dt.Rows[0]["mobile"].ToString();
            }
        }


        return strresult;
    }

    protected void lnkExcelIncubatorSelected_Click(object sender, EventArgs e)
    {
        string cmd;
        DataTable dt;


        cmd = "select  * from V_YPIListIncubatorSelected ";

        dt = dbFunctions_YPI.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            DataGrid dg = new DataGrid();
            dg.DataSource = dt;
            dg.DataBind();

            string hex = "#E2EDF2";
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            dg.AlternatingItemStyle.BackColor = _color;

            string sFileName = "YPIListIncubatorSelected-" + System.DateTime.Now.Date + ".xls";
            sFileName = sFileName.Replace("/", "");


            foreach (DataGridItem dataGridItem in dg.Items)
            {
                dataGridItem.Cells[3].Attributes.Add("class", "text");
            }


            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=" + sFileName);
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
    }

    protected void lnkExcelAll_Click(object sender, EventArgs e)
    {
        string cmd;
        DataTable dt;


        cmd = "select  * from V_YPIListAll ";

        dt = dbFunctions_YPI.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            DataGrid dg = new DataGrid();
            dg.DataSource = dt;
            dg.DataBind();

            string hex = "#E2EDF2";
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            dg.AlternatingItemStyle.BackColor = _color;

            string sFileName = "YPIListAll-" + System.DateTime.Now.Date + ".xls";
            sFileName = sFileName.Replace("/", "");


            foreach (DataGridItem dataGridItem in dg.Items)
            {
                dataGridItem.Cells[3].Attributes.Add("class", "text");
            }


            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=" + sFileName);
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

    protected void lnkExcelFullReportByAge_Click(object sender, EventArgs e)
    {
        string cmd;
        DataTable dt;


        cmd = "select  * from V_YPI_YearWiseReport ";

        dt = dbFunctions_YPI.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            DataGrid dg = new DataGrid();
            dg.DataSource = dt;
            dg.DataBind();

            string hex = "#E2EDF2";
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            dg.AlternatingItemStyle.BackColor = _color;

            string sFileName = "YPIReport-" + System.DateTime.Now.Date + ".xls";
            sFileName = sFileName.Replace("/", "");


            foreach (DataGridItem dataGridItem in dg.Items)
            {
                dataGridItem.Cells[3].Attributes.Add("class", "text");
            }


            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=" + sFileName);
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
    }
    protected void lnkExcel_Click(object sender, EventArgs e)
    {
        string cmd;
        DataTable dt;

        str = "";

     
        //if (TxtMobile.Text != "")
        //{
        //    str = str + ",Mobile ='" + TxtMobile.Text + "' ";
        //}

        //if (TxtCivilID.Text != "")
        //{
        //    str = str + ",CivilID ='" + TxtCivilID.Text + "' ";
        //}

      

        if (DDLCategory.SelectedValue != "0")
            str = " where CategoryID=" + DDLCategory.SelectedValue + "   and   FinalStatus=1";






        cmd = "select * from V_YPIListAllByCategory " + str + "  order by id desc";

        Response.Write(str);
        Response.Write(cmd);

       dt = dbFunctions_YPI.GetData(cmd);
      
      


        if (dt.Rows.Count != 0)
        {
           // RemoveColumns(dt);

            //dt.Columns["Success"].DataType = typeof(string);
            //dt.Columns["SimilarProject"].DataType = typeof(string);

            //foreach (DataRow dr in dt.Rows)
            //{
            //    foreach (DataColumn dc in dt1.Columns)
            //    {
            //        //str1 = dr[dc].ToString();
            //        if (dr[dc].ToString() == "False")
            //        {
            //            dr[dc] = "No";
            //        }
            //        else if (dr[dc].ToString() == "True")
            //            dr[dc] = "Yes";
            //    }
            //}
 
            DataGrid dg = new DataGrid();
            dg.DataSource = dt;
            dg.DataBind();

            string hex = "#E2EDF2";
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            dg.AlternatingItemStyle.BackColor = _color;

            string sFileName = "YPIReport-" + System.DateTime.Now.Date + ".xls";
            sFileName = sFileName.Replace("/", "");

            foreach (DataGridItem dataGridItem in dg.Items)
            {
                dataGridItem.Cells[3].Attributes.Add("class", "text");
            }


            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=" + sFileName);
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
    }

    private void RemoveColumns(DataTable dt)
    {
        dt.Columns.Remove("id");
        dt.Columns.Remove("CategoryName");
        dt.Columns.Remove("TypeID");
        dt.Columns.Remove("TypeName");
        dt.Columns.Remove("UpdatedAt");
        dt.Columns.Remove("SubmitedAt");
        dt.Columns.Remove("FileAgriculture");
        dt.Columns.Remove("FileAcademicQualification");
        dt.Columns.Remove("FileCriminalAutorization");
        dt.Columns.Remove("InitiativeNo");
        dt.Columns.Remove("EducationQualificationID");
        dt.Columns.Remove("UID");
        dt.Columns.Remove("CategoryID");
        //dt.Columns.Remove("ExperienceTypeID");
        //dt.Columns.Remove("");
        //dt.Columns.Remove("");
        //dt.Columns.Remove("");
        //dt.Columns.Remove("");
    }
    protected void ddlSerachByMultiple_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtSearch.Text = "";
        if (ddlSerachByMultiple.SelectedValue == "0")
            DivSearch.Visible = false;
        else
        {
            DivSearch.Visible = true;
        }
    }
}