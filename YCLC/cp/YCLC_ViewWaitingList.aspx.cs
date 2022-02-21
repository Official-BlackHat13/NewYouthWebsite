using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Text;
using System.Web.UI.HtmlControls;
using System.IO;


public partial class YCLC_cp_YCLC_ViewWaitingList : System.Web.UI.Page
{
    General gm = new General();
    general_fn gfn = new general_fn();
    protected SqlCommand cmd;
    protected SqlConnection cnn;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid_Yclid"] == null)
        {
            Response.Redirect("Index.aspx");
        }
        if (!IsPostBack)
        {
            LoadGovernorate();

            string organizationID = Session["OrganizationID"].ToString();

            if (!organizationID.Equals("1"))
            {

                //sta.Visible = false;
               // stati.Visible = false;
                //this commemted on 14-10-2021
                // pnlOrg.Visible = true;
                DDlOrganization.Enabled = false;
                DDlOrganization.ClearSelection();
                DDlOrganization.Items.FindByValue(organizationID).Selected = true;

            }
            else
            {
              //  sta.Visible = true;
               // stati.Visible = true;
                //this commemted on 14-10-2021
                //pnlOrg.Visible = true;

            }
            DataTable dt = LoadValues("all");
            FillData(dt);

        }
    }

    private DataTable LoadValues(string type)
    {
        string level = string.Empty;
        if (!DDLlevel.SelectedValue.Equals("0") && !DDLlevel.SelectedValue.Equals("4"))
            level = DDLlevel.SelectedItem.Text;
        else
            level = null;

        //string str = "@type='" + type + "',@orgID='" + DDlOrganization.SelectedValue + "',@UserLevel='" + ((!DDLlevel.SelectedValue.Equals("0") && !DDLlevel.SelectedValue.Equals(4)) ? DDLlevel.SelectedItem.Text : null) + "'";
        //str = str + ",@Catagory='" + (!DDLCatagory.SelectedValue.Equals("0") ? DDLCatagory.SelectedValue : null) + "',@debatelang='" + (DDLlevel.SelectedValue == "4" ? DDLlevel.SelectedItem.Text : null) + "'";

        cnn = new SqlConnection();
        cnn.ConnectionString = gm.ConnectionString();
        cnn.Open();
        SqlCommand command = new SqlCommand("SP_YCLCompetition_waiting", cnn);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = type;
        command.Parameters.AddWithValue("@orgID", SqlDbType.NVarChar).Value = DDlOrganization.SelectedValue;

        //command.Parameters.AddWithValue("@UserLevel", SqlDbType.NVarChar).Value = ((!DDLlevel.SelectedValue.Equals("0") && (!DDLlevel.SelectedValue.Equals(4))) ? DDLlevel.SelectedItem.Text : null);
        command.Parameters.AddWithValue("@UserLevel", SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(level) ? DDLlevel.SelectedItem.Text : null);

        command.Parameters.AddWithValue("@Catagory", SqlDbType.Int).Value = ((!DDLCatagory.SelectedValue.Equals("0")) ? DDLCatagory.SelectedValue : null);

        command.Parameters.AddWithValue("@Governarate", SqlDbType.Int).Value = (!DDlGovernarate.SelectedValue.Equals("0") ? DDlGovernarate.SelectedValue : null);

        command.Parameters.AddWithValue("@Usergender", SqlDbType.NVarChar).Value = (!DDLGender.SelectedValue.Equals("0") ? DDLGender.SelectedValue : null);

        command.Parameters.AddWithValue("@Usercivil", SqlDbType.NVarChar).Value = (txtcivil.Text == "" ? null : txtcivil.Text);

        command.Parameters.AddWithValue("@mobile", SqlDbType.NVarChar).Value = (txtmbl.Text == "" ? null : txtmbl.Text);

        command.Parameters.AddWithValue("@Area", SqlDbType.NVarChar).Value = (!ddlArea.SelectedValue.Equals("0") ? ddlArea.SelectedValue : null);

        command.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = (txtemail.Text == "" ? null : txtemail.Text);

        command.Parameters.AddWithValue("@debatelang", SqlDbType.NVarChar).Value = (DDLlevel.SelectedValue == "4" ? DDLlevel.SelectedItem.Text : null);

        command.ExecuteNonQuery();

        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(command);
        sda.Fill(dt);
        cnn.Close();
        return dt;
    }

    private void FillData(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            competetionGrid.DataSource = dt;
            competetionGrid.DataBind();
        }
        else
        {
            competetionGrid.DataSource = null;
            competetionGrid.DataBind();
        }
    }

    protected void competetionGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            Session["yclc_wuserid"] = e.CommandArgument.ToString();
            Response.Redirect("YCLC_WaitingListUserDetails.aspx", false);
        }
        if (e.CommandName == "civil")
        {
            if (string.IsNullOrEmpty(e.CommandArgument.ToString()))
            {
                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int RowIndex = gvr.RowIndex;
                HiddenField hdnField = (HiddenField)competetionGrid.Rows[RowIndex].FindControl("hiddencivil");

                DownloadDummyFile(hdnField.Value);

            }
            else
            {
                DownloadFile(e.CommandArgument.ToString());
            }
        }
    }
    public void DownloadDummyFile(string civil)
    {
        civil = civil + DateTime.Now.ToString("yyyyMMddHHmmss");

        Response.Clear();
        Response.ContentType = @"application\octet-stream";
        System.IO.FileInfo file = new System.IO.FileInfo(@"C:/inetpub/wwwroot/Youth.gov.kw/YCLC/Civil/civil-dummy.jpg");
        Response.AddHeader("Content-Disposition", "attachment; filename=" + civil + ".jpg");
        Response.AddHeader("Content-Length", file.Length.ToString());
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(file.FullName);
        Response.End();

    }

    public void DownloadFile(string fName)
    {
        string mypath = Path.Combine("C:/inetpub/wwwroot/Youth.gov.kw/YCLC/Civil/", fName);
        FileInfo fi = new FileInfo(mypath);
        if (fi.Exists)
        {
            long sz = fi.Length;
            Response.ClearContent();
            Response.ContentType = Path.GetExtension(fName);
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName(mypath)));
            Response.AddHeader("Content-Length", sz.ToString("F0"));
            Response.TransmitFile(mypath);
            Response.End();
        }
        //civil = civil + DateTime.Now.ToString("yyyyMMddHHmmss");

        //Response.Clear();
        //Response.ContentType = @"application\octet-stream";
        //System.IO.FileInfo file = new System.IO.FileInfo(@"C:/inetpub/wwwroot/YouthMinistry/YCLC/Civil/civil-dummy.jpg");
        //Response.AddHeader("Content-Disposition", "attachment; filename=" + civil + ".jpg");
        //Response.AddHeader("Content-Length", file.Length.ToString());
        //Response.ContentType = "application/octet-stream";
        //Response.WriteFile(file.FullName);
        //Response.End();

    }
    protected void competetionGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        competetionGrid.PageIndex = e.NewPageIndex;

        //BindGridView();
        DataTable dt = LoadValues("all");
        FillData(dt);

    }
    protected void competetionGrid_DataBound(object sender, EventArgs e)
    {
        GridViewRow gvr = competetionGrid.BottomPagerRow;
        if (gvr == null)
        {
            return;
        }
        Label lb1 = (Label)gvr.Cells[0].FindControl("CurrentPage");
        lb1.Text = Convert.ToString(competetionGrid.PageIndex + 1);
        int[] page = new int[7];
        page[0] = competetionGrid.PageIndex - 2;
        page[1] = competetionGrid.PageIndex - 1;
        page[2] = competetionGrid.PageIndex;
        page[3] = competetionGrid.PageIndex + 1;
        page[4] = competetionGrid.PageIndex + 2;
        page[5] = competetionGrid.PageIndex + 3;
        page[6] = competetionGrid.PageIndex + 4;
        for (int i = 0; i < 7; i++)
        {
            if (i != 3)
            {
                if (page[i] < 1 || page[i] > competetionGrid.PageCount)
                {
                    LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("p" + Convert.ToString(i));
                    lb.Visible = false;
                }
                else
                {
                    LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("p" + Convert.ToString(i));
                    lb.Text = Convert.ToString(page[i]);
                    lb.CommandName = "PageNo";
                    lb.CommandArgument = lb.Text;
                }
            }
        }
        if (competetionGrid.PageIndex == 0)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton1");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton2");
            lb.Visible = false;

        }
        if (competetionGrid.PageIndex == competetionGrid.PageCount - 1)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton3");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton4");
            lb.Visible = false;
        }
        if (competetionGrid.PageIndex > competetionGrid.PageCount - 5)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("nmore");
            lbmore.Visible = false;
        }
        if (competetionGrid.PageIndex < 4)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("pmore");
            lbmore.Visible = false;
        }
    }

    void lb_Command(object sender, CommandEventArgs e)
    {
        competetionGrid.PageIndex = Convert.ToInt32(e.CommandArgument) - 1;
        DataTable dt = LoadValues("all");
        FillData(dt);
    }
    protected void competetionGrid_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewRow gvr = e.Row;
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("p0");
            lb.Command += new CommandEventHandler(lb_Command);
            lb = (LinkButton)gvr.Cells[0].FindControl("p1");
            lb.Command += new CommandEventHandler(lb_Command);
            lb = (LinkButton)gvr.Cells[0].FindControl("p2");
            lb.Command += new CommandEventHandler(lb_Command);
            lb = (LinkButton)gvr.Cells[0].FindControl("p4");
            lb.Command += new CommandEventHandler(lb_Command);
            lb = (LinkButton)gvr.Cells[0].FindControl("p5");
            lb.Command += new CommandEventHandler(lb_Command);
            lb = (LinkButton)gvr.Cells[0].FindControl("p6");
            lb.Command += new CommandEventHandler(lb_Command);


        }
    }
    protected void competetionGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //   string file = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "صورة البطاقة المدنية")).TrimEnd();

        // HtmlAnchor html = (HtmlAnchor)(e.Row.FindControl("acivilid"));
        //// DropDownList ddl = (DropDownList)e.Row.FindControl("myDropdown");
        // HiddenField hiddencivil = (HiddenField)(e.Row.FindControl("hiddencivil"));
        // string val = hiddencivil.Value;


        // if (!string.IsNullOrEmpty(file))
        // {
        //     html.HRef = "~/YCLC/Civil/" + file;
        // }
        // else
        // {
        //     string tempfile = hiddencivil.Value+DateTime.Now.ToString()+".jpg";
        //     FileStream fs = new FileStream(@"C:/inetpub/wwwroot/YouthMinistry/YCLC/Civil/tempfile", FileMode.CreateNew);
        //   //  fs.Seek(2048L * 1024 * 1024, SeekOrigin.Begin);
        //     fs.WriteByte(0);
        //     fs.Close();
        //     File.Copy("civil-dummy.jpg", tempfile);
        //     html.HRef = "~/YCLC/Civil/" + file;
        // }
    }



    private void LoadGovernorate()
    {
        DataSet ds = GetData("SP_YCLCompetition_waiting");
        if (ds.Tables[0].Rows.Count > 0)
        {
            DDlGovernarate.DataSource = ds.Tables[0];
            DDlGovernarate.DataTextField = "GovName";
            DDlGovernarate.DataValueField = "Id";
            DDlGovernarate.DataBind();
            DDlGovernarate.Items.Insert(0, new ListItem("--اختر--", "0"));
        }
        DataTable dt = ds.Tables[1];

        if (ds.Tables[1].Rows.Count > 0)
        {
            DDLCatagory.DataSource = ds.Tables[1];
            DDLCatagory.DataTextField = "Category";
            DDLCatagory.DataValueField = "CategoryId";
            DDLCatagory.DataBind();
            DDLCatagory.Items.Insert(0, new ListItem("--اختر--", "0"));
        }
        if (ds.Tables[2].Rows.Count > 0)
        {
            DDlOrganization.DataSource = ds.Tables[2];
            DDlOrganization.DataTextField = "OrganizationName";
            DDlOrganization.DataValueField = "ID";
            DDlOrganization.DataBind();
            DDlOrganization.Items.Insert(0, new ListItem("--اختر--", "0"));
        }
    }


    public DataSet GetData(string Command)
    {
        cnn = new SqlConnection();
        cnn.ConnectionString = gm.ConnectionString();
        cnn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cnn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = Command;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@type", "ddlload");
        cmd.Parameters.AddWithValue("@orgID", Session["OrganizationID"]);

        //cmd.Parameters.AddWithValue("@orgID", ((!DDlOrganization.SelectedValue.Equals("0") && (!string.IsNullOrEmpty(DDlOrganization.SelectedValue.ToString()))) ? DDlOrganization.SelectedValue : Session["OrganizationID"]));

        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        cnn.Close();
        return ds;

    }



    protected void lnlprint_Click(object sender, EventArgs e)
    {
        DataTable dt = LoadValues("print");
        // FillData(dt);
        RemoveReOrderColumns(dt);
        Session.Add("printDt", dt);
        Response.Redirect("ListPrintGeneral.aspx", false);
    }
    private void RemoveReOrderColumns(DataTable dt)
    {
        dt.Columns.Remove("صورة البطاقة المدنية");

        dt.Columns.Remove("id");

    }


    protected void btnExport1_Click(object sender, EventArgs e)
    {

        DataTable dt = LoadValues("print");
        //FillData(dt);
        RemoveReOrderColumns(dt);
        DataGrid dg = new DataGrid();
        dg.DataSource = dt;
        dg.DataBind();


        string hex = "#E2EDF2";
        Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
        dg.AlternatingItemStyle.BackColor = _color;

        string sFileName = "YClCompetetionUsersList-" + System.DateTime.Now.Date + ".xls";
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


    protected void DDLlevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = LoadValues("all");
        FillData(dt);
    }

    protected void txtmbl_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = LoadValues("all");
        FillData(dt);
    }
    protected void txtcivil_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = LoadValues("all");
        FillData(dt);
    }
    protected void DDLGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = LoadValues("all");
        FillData(dt);
    }
    protected void DDlGovernarate_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = LoadValues("all");
        FillData(dt);
    }
    protected void DDLCatagory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLCatagory.SelectedItem.Text.Trim() == "المناظرات الشبابية")
        {
            DDLlevel.Items.Insert(DDLlevel.Items.Count, new ListItem("English", "4"));
        }
        else
        {
            DDLlevel.Items.Remove(new ListItem("English", "4"));
        }
        DataTable dt = LoadValues("all");
        FillData(dt);
    }
    protected void txtemail_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = LoadValues("all");
        FillData(dt);
    }
    protected void btClear_Click(object sender, EventArgs e)
    {
        DDLCatagory.ClearSelection();
        DDLlevel.ClearSelection();
        DDLGender.ClearSelection();
        DDlGovernarate.ClearSelection();
        //  DDlOrganization.ClearSelection();
        ddlArea.ClearSelection();
        txtmbl.Text = "";
        txtcivil.Text = "";
        txtemail.Text = "";
        DataTable dt = LoadValues("all");
        FillData(dt);

    }
    protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = LoadValues("all");
        FillData(dt);
    }
    protected void DDlOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {

        //DataSet ds = GetData("SP_YCLCompetition_waiting");

        //if (ds.Tables[1].Rows.Count > 0)
        //{
        //    DDLCatagory.DataSource = ds.Tables[1];
        //    DDLCatagory.DataTextField = "Category";
        //    DDLCatagory.DataValueField = "CategoryId";
        //    DDLCatagory.DataBind();
        //    DDLCatagory.Items.Insert(0, new ListItem("--اختر--", "0"));
        //}

        DataTable dt = LoadValues("all");
        FillData(dt);
    }
}