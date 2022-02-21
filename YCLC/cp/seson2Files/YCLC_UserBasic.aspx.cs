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


public partial class YCLC_cp_YCLC_UserBasic : System.Web.UI.Page
{

    General gm = new General();
    general_fn gfn = new general_fn();
    protected SqlCommand cmd;
    protected SqlConnection cnn;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid_Adminid"] == null)
        {
            Response.Redirect("Index.aspx");
        }
        if (!IsPostBack)
        {           
            DataTable dt = LoadValues("all");
            FillData(dt);
        }
    }

    private DataTable LoadValues(string type)
    {
        cnn = new SqlConnection();
        cnn.ConnectionString = gm.ConnectionString();
        cnn.Open();

        SqlCommand command = new SqlCommand("SP_YCLCUser", cnn);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = type;      

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

    protected void lnlprint_Click(object sender, EventArgs e)
    {
        DataTable dt = LoadValues("all");
        // FillData(dt);
        //RemoveReOrderColumns(dt);
        Session.Add("printDt", dt);
        Response.Redirect("ListPrintGeneral.aspx", false);
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
    protected void competetionGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        competetionGrid.PageIndex = e.NewPageIndex;

        //BindGridView();
        DataTable dt = LoadValues("all");
        FillData(dt);
    }
    protected void competetionGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {

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
  

    protected void btnExport1_Click(object sender, EventArgs e)
    {

        DataTable dt = LoadValues("all");
        //FillData(dt);
        //RemoveReOrderColumns(dt);
        DataGrid dg = new DataGrid();
        dg.DataSource = dt;
        dg.DataBind();


        string hex = "#E2EDF2";
        Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
        dg.AlternatingItemStyle.BackColor = _color;

        string sFileName = "YClUsersList-" + System.DateTime.Now.Date + ".xls";
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
    
}