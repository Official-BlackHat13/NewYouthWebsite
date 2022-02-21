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

public partial class YPI_ViewInitiative_ExportToExcel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            ViewInitiativeAppCurrentUser.CheckLoggedIn();

        }
        
    }

 

   
    protected void lnkExcelFullReportByAge_Click(object sender, EventArgs e)
    {
        DataTable dt = dbFunctions_YPI.GetData("exec GetProfessionalInitiatives @type='age'"); 

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
    protected void lnkExcelIncubatorSelected_Click(object sender, EventArgs e)
    {
        DataTable dt = dbFunctions_YPI.GetData("exec GetProfessionalInitiatives @type='incub'"); 
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
       
        DataTable dt = dbFunctions_YPI.GetData("exec GetProfessionalInitiatives @type='all'");       

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

  

    
  
    //protected void GVData_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        string strresult = "";
    //        string strInstitution = "";
    //        string StrStage = "";

    //        Label lblPhase = e.Row.FindControl("lblPhase") as Label;

    //        string InstitutionID =(DataBinder.Eval(e.Row.DataItem, "InstitutionID").ToString());
    //        string BusinessNurseryID = DataBinder.Eval(e.Row.DataItem, "BusinessNurseryID").ToString();
    //        string Stage = DataBinder.Eval(e.Row.DataItem, "Stage").ToString();
    //        string StageName = DataBinder.Eval(e.Row.DataItem, "StageName").ToString();
    //        if (InstitutionID == "1")
    //        {
    //            strInstitution = "<b> مكتب وزير الدولة لشئون الشباب </b>";
    //        }
    //        else if (InstitutionID == "2")
    //        {
    //            if (!string.IsNullOrEmpty(BusinessNurseryID))
    //            {
    //                if (BusinessNurseryID == "0")
    //                {
    //                    strInstitution = "حاضنة الأعمال";
    //                }
    //                else
    //                {
    //                    strInstitution = "حاضنة الأعمال ( " + DataBinder.Eval(e.Row.DataItem, "BusinessNurseryName").ToString() + " )";
    //                }
    //            }
    //        }
    //        else { strInstitution = "-"; }

    //        if(!string.IsNullOrEmpty(Stage))
    //            StrStage = Stage+ " - " + StageName;


    //        strresult = strInstitution + "<br><br>" + StrStage;


    //        lblPhase.Text = strresult;

    //        //int age = Convert.ToInt32(e.Row.Cells[3].Text);

    //        //if (age >= 35)
    //        //{

    //        //    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#4F81BD");

    //        //    e.Row.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");

    //        //}

    //    }
    //}
}