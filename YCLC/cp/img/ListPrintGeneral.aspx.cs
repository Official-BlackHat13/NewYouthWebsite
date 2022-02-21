using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net.Mail;
using System.IO;
using System.Text;
using System.Web;




public partial class MYA2_YPAindividualPrint : System.Web.UI.Page
{
    #region Declarations
    public string Heading = "";
    static string prevPage = String.Empty;
    #endregion
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.UrlReferrer != null && (Request.UrlReferrer.ToString() != HttpContext.Current.Request.Url.AbsoluteUri))
        {
            Session["prepage"] = Request.UrlReferrer.AbsoluteUri;
        }



        if (Session["userid_Adminid"] == null)
        {
            Response.Redirect("Index.aspx", false);
        }
        else
        {
            if (Session["printDt"] == null)
                Response.Redirect("YCL_View_Announcement.aspx", false);
            if (!IsPostBack)
            {
                prevPage = Request.UrlReferrer.ToString();
                if (Session["printDt"] != null)
                {
                    DataTable dt = (DataTable)Session["printDt"];
                    if(dt.Rows.Count>1)
                    {
                        Heading = "";
                        LoadAll();
                    }
                    else
                    {
                        Heading = "";
                        LoadIndividualData();
                    }
                }
            }

        }
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(prevPage);
    }
    #endregion

    #region Methods

    //void loadgrid()
    //{
    //    DataTable dt = (DataTable)Session["printDt"];
    //    if (dt.Rows.Count > 0)
    //    {
    //        foreach (DataColumn column in dt.Columns)
    //        {
    //            BoundField bf = new BoundField();
    //            bf.HeaderText = column.ColumnName.ToString();
    //            bf.DataField = column.ColumnName.ToString();
    //            grdGeneral.Columns.Add(bf);





    //        }
    //        grdGeneral.DataSource = dt;
    //        grdGeneral.DataBind();


    //        rpYPA.DataSource = dt;
    //        rpYPA.DataBind();

    //    }
    //}
    public void LoadIndividualData()
    {

        DataTable dt = (DataTable)Session["printDt"];
        StringBuilder html = new StringBuilder();
        html.Append("<h2 align='center'>" + Heading.ToString() + "</h2>");
        html.Append("<br/>");
        html.Append("<center>");
        html.Append("<table width = '680px' border = '1' cellpadding = '0' cellspacing = '0' style='direction: rtl;border-collapse: collapse;'>");
        html.Append("<tr>");
        html.Append("<td width = '0'><img  src = '../images/DMSHeader-1.jpg' width='680px' alt = '' /><br/>");
        html.Append("</td>");       
        html.Append("</tr>");
        html.Append("</table>");
        html.Append("</center>");
        html.Append("<center>");
        html.Append("<table style='direction: rtl;border-collapse: collapse;'  border = '1' width='680' cellpadding='15' cellspacing='10' class='table table - bordered nf'>");
        foreach (DataRow row in dt.Rows)
        {

            foreach (DataColumn column in dt.Columns)
            {
                html.Append("<tr>");
                html.Append("<td width='50%'>");
                html.Append(column.ColumnName);
                html.Append("</td>");
                html.Append("<td  width='50%'>");
                html.Append(row[column.ColumnName]);
                html.Append("</td>");
                html.Append("</tr>");
            }

        }
        html.Append("</table>");
        html.Append("</center>");
        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
    }
    public void LoadAll()
    {
        DataTable dt = (DataTable)Session["printDt"];
        StringBuilder html = new StringBuilder();
        html.Append("<h2 align='center'>" + Heading.ToString() + "</h2>");
        html.Append("<br/>");
        html.Append("<table style='direction: rtl;border-collapse: collapse;' border = '1'>");
        html.Append("<tr>");
        foreach (DataColumn column in dt.Columns)
        {
            html.Append("<th>");
            html.Append(column.ColumnName);
            html.Append("</th>");
        }
        html.Append("</tr>");
        foreach (DataRow row in dt.Rows)
        {
            html.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                html.Append("<td>");
                html.Append(row[column.ColumnName]);
                html.Append("</td>");
            }
            html.Append("</tr>");
        }
        html.Append("</table>");
        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

    }
    #endregion
   
}