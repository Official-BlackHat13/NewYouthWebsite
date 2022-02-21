using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
public partial class MYA2_aceStatistics : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection();
    General gm = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid_Adminid"] == null)
        {
            Response.Redirect("Index.aspx");
        }
        else
        {
           // sqlace.ConnectionString = gm.ConnectionString();

            SqlCommand selectcommand = new SqlCommand("yclcStatistics");
            selectcommand.CommandType = CommandType.StoredProcedure;
            selectcommand.Connection = cnn;
            cnn.ConnectionString = gm.ConnectionString();
            cnn.Open();                  
            selectcommand.ExecuteNonQuery();
            SqlDataAdapter selAdp = new SqlDataAdapter(selectcommand);
            DataTable dt = new DataTable();
            selAdp.Fill(dt);
            grdAce.DataSource = dt;
            grdAce.DataBind();
            int total = dt.AsEnumerable().Sum(row => row.Field<int>("val"));
            
            grdAce.FooterRow.Cells[0].Text = "Total Application :";
            grdAce.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
            grdAce.FooterRow.Cells[0].CssClass = "footerStyle";
            grdAce.FooterRow.Cells[1].CssClass = "footerStyle"; 
            grdAce.FooterRow.Cells[1].Text = total.ToString();
            cnn.Close();
        }
    }
    protected void btprint_Click(object sender, EventArgs e)
    {
        Response.Redirect("printStat.aspx");
    }
    protected void grdAce_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if (e.CommandName == "catview")
        {

            string cat = e.CommandArgument.ToString();           
            Session["cat"] = cat;           
            Response.Redirect("printCat.aspx", false);
        }
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
      
            Response.Redirect("YCLC_ViewUsers.aspx", false);
      
    }
}