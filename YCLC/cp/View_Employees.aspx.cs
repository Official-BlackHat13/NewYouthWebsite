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

public partial class YCLC_cp_View_Employees : System.Web.UI.Page
{
    general_fn gfn = new general_fn();
    General Obj_Gen = new General();
    SqlConnection cnn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid_Yclid"] == null)
        {
            Response.Redirect("Index.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                loadOrganization();
                DataTable dt = LoadValues("all");
                FillData(dt);
            }
        }
    }

    protected void loadOrganization()
    {
        cnn = new SqlConnection();
        cnn.ConnectionString = Obj_Gen.ConnectionString();
        cnn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cnn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SP_YCLCompetition";
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@type", "ddlload");

        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        cnn.Close();
        if (ds.Tables[2].Rows.Count > 0)
        {
            DDlOrganization.DataSource = ds.Tables[2];
            DDlOrganization.DataValueField = "ID";
            DDlOrganization.DataTextField = "OrganizationName";
            DDlOrganization.DataBind();
            DDlOrganization.Items.Insert(0, new ListItem("--اختر--", "0"));
        }
    }

    protected DataTable  LoadValues(string type)
    {
        DataTable dt = new DataTable();
        cnn = new SqlConnection();
        cnn.ConnectionString = Obj_Gen.ConnectionString();
        cnn.Open();

        SqlCommand command = new SqlCommand("SP_YCLCadmin", cnn);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = type;
        command.Parameters.AddWithValue("@orgID", SqlDbType.NVarChar).Value = (!DDlOrganization.SelectedValue.Equals("0")? DDlOrganization.SelectedValue : null);
       
        command.Parameters.AddWithValue("@mobile", SqlDbType.NVarChar).Value = (txtmbl.Text == "" ? null : txtmbl.Text);

        command.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = (TextEmail.Text == "" ? null : TextEmail.Text);

        SqlDataAdapter sda = new SqlDataAdapter(command);

        try
        {
            command.ExecuteNonQuery();
            sda.Fill(dt);
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
       
        cnn.Close();



        return dt;
    }

    protected void FillData(DataTable dt)
    {
        adminGrid.DataSource = dt;
        adminGrid.DataBind();

    }    
    protected void TextEmail_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = LoadValues("all");
        FillData(dt);
    }
    protected void DDlOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = LoadValues("all");
        FillData(dt);
    }
    protected void txtmbl_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = LoadValues("all");
        FillData(dt);
    }

    protected void btClear_Click(object sender, EventArgs e)
    {
        DDlOrganization.ClearSelection();
        DDlOrganization.SelectedValue = "0";

        txtmbl.Text = "";
        TextEmail.Text = "";

        DataTable dt = LoadValues("all");
        FillData(dt);
    }


    protected void lnkExport_Click(object sender, EventArgs e)
    {
        DataTable dt = LoadValues("all");
        
       
        DataGrid dg = new DataGrid();
        dg.DataSource = dt;
        dg.DataBind();


        string hex = "#E2EDF2";
        Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
        dg.AlternatingItemStyle.BackColor = _color;

        string sFileName = "YClCompetetionAdminList-" + System.DateTime.Now.Date + ".xls";
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
    protected void lnkprint_Click(object sender, EventArgs e)
    {
        DataTable dt = LoadValues("all");
        Session["printDt"] = dt;
        Response.Redirect("ListPrintGeneral.aspx", false);

    }
    protected void adminGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            GridViewRow gvRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            //Int32 rowind = gvRow.RowIndex;

            Label lblpwd = ((Label)gvRow.FindControl("lblpwd"));

            if (lblpwd.Text == e.CommandArgument.ToString())
                lblpwd.Text = "******";
            else
                lblpwd.Text = e.CommandArgument.ToString();

        }
    }
    protected void adminGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        adminGrid.PageIndex = e.NewPageIndex;        
        DataTable dt = LoadValues("all");
        FillData(dt);
    }
    protected void adminGrid_DataBound(object sender, EventArgs e)
    {
        GridViewRow gvr = adminGrid.BottomPagerRow;
        if (gvr == null)
        {
            return;
        }
        Label lb1 = (Label)gvr.Cells[0].FindControl("CurrentPage");
        lb1.Text = Convert.ToString(adminGrid.PageIndex + 1);
        int[] page = new int[7];
        page[0] = adminGrid.PageIndex - 2;
        page[1] = adminGrid.PageIndex - 1;
        page[2] = adminGrid.PageIndex;
        page[3] = adminGrid.PageIndex + 1;
        page[4] = adminGrid.PageIndex + 2;
        page[5] = adminGrid.PageIndex + 3;
        page[6] = adminGrid.PageIndex + 4;
        for (int i = 0; i < 7; i++)
        {
            if (i != 3)
            {
                if (page[i] < 1 || page[i] > adminGrid.PageCount)
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
        if (adminGrid.PageIndex == 0)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton1");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton2");
            lb.Visible = false;

        }
        if (adminGrid.PageIndex == adminGrid.PageCount - 1)
        {
            LinkButton lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton3");
            lb.Visible = false;
            lb = (LinkButton)gvr.Cells[0].FindControl("LinkButton4");
            lb.Visible = false;
        }
        if (adminGrid.PageIndex > adminGrid.PageCount - 5)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("nmore");
            lbmore.Visible = false;
        }
        if (adminGrid.PageIndex < 4)
        {
            Label lbmore = (Label)gvr.Cells[0].FindControl("pmore");
            lbmore.Visible = false;
        }
    }
    void lb_Command(object sender, CommandEventArgs e)
    {
        adminGrid.PageIndex = Convert.ToInt32(e.CommandArgument) - 1;
        DataTable dt = LoadValues("all");
        FillData(dt);
    }



    protected void adminGrid_RowCreated(object sender, GridViewRowEventArgs e)
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
    
}