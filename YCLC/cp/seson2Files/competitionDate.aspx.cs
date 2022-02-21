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
using System.IO;
using System.Reflection;


public partial class YCLC_cp_competitionDate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        General gm = new General();
        general_fn gfn = new general_fn();
        string startdate = string.Empty;
        string enddate = string.Empty;

        if (!string.IsNullOrEmpty(datepicker1.Text))
        {
            startdate = datepicker1.Text.Substring(6, 4) + "/" + datepicker1.Text.Substring(0, 2) + "/" + datepicker1.Text.Substring(3, 2);
        }
        if (!string.IsNullOrEmpty(datepicker2.Text))
        {
            enddate = datepicker2.Text.Substring(6, 4) + "/" + datepicker2.Text.Substring(0, 2) + "/" + datepicker2.Text.Substring(3, 2);
        }

        SqlConnection con = new SqlConnection();

        con.ConnectionString = gm.ConnectionString();
        con.Open();
        SqlCommand listcommand = new SqlCommand("CompetitionEmailList", con);

        listcommand.CommandType = CommandType.StoredProcedure;
        listcommand.Parameters.AddWithValue("@startdate", SqlDbType.Date).Value = startdate;
        listcommand.Parameters.AddWithValue("@enddate", SqlDbType.Date).Value = (enddate == "" ? startdate : enddate);

        listcommand.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(listcommand);
        sda.Fill(dt);
        con.Close();
        ExportToExcel(dt);
        int i = gfn.GeneralYCLCListTEmail(hdfile.Value);
        if (i == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "AlertBox", "alert('Sent list to the mail');", true);

        }
    }

    public void ExportToExcel(DataTable dt)
    {

        DateTime date = DateTime.Now;
        string filename = date.ToString("yyyyMMddHHmmssffff");

        emailgrid.DataSource = dt;
        emailgrid.DataBind();


        string hex = "#E2EDF2";
        Color _color = System.Drawing.ColorTranslator.FromHtml(hex);


        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);

        string hexHeader = "#65b7d1";
        Color _colorHeader = System.Drawing.ColorTranslator.FromHtml(hexHeader);
        emailgrid.HeaderStyle.Font.Bold = true;     // SET EXCEL HEADERS AS BOLD.
        emailgrid.HeaderStyle.BackColor = _colorHeader;
        emailgrid.RenderControl(htw);
        // Write the rendered content to a file.
        string renderedGridView = sw.ToString();
        System.IO.File.WriteAllText(@"C:\\inetpub\\wwwroot\\YouthMinistry\\YCLC\\cp\\Excel\\" + filename + ".xls", renderedGridView, Encoding.GetEncoding("UTF-8"));
        hdfile.Value = @"C:\\inetpub\\wwwroot\\YouthMinistry\\YCLC\\cp\\Excel\\" + filename + ".xls";

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }





}