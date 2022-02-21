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


public partial class youthNEWADMIN_printACE : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection();
    General gm = new General();
    decimal grdTotal = 0;
    decimal grdTotal2 = 0;
    decimal grdTotal3 = 0;
    decimal grandTotal = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["userid_Adminid"] == null)
        {
            Response.Redirect("Index.aspx");
        }
        else
        {


            SqlCommand selectcommand = new SqlCommand("select CategoryId,Catgeory_name  from YCLCategory");
            selectcommand.CommandType = CommandType.Text;
            selectcommand.Connection = cnn;
            cnn.ConnectionString = gm.ConnectionString();
            cnn.Open();
            selectcommand.ExecuteNonQuery();
            cnn.Close();        
            SqlDataAdapter selAdp = new SqlDataAdapter(selectcommand);
            DataTable dt = new DataTable();
            selAdp.Fill(dt);
            grdAce.DataSource = dt;
            grdAce.DataBind();


        }
    }

    protected void btprint_Click(object sender, EventArgs e)
    {
        Response.Redirect("printStat.aspx");
    }
   
  
   
    protected void grdAce_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label lbltype = (Label)e.Row.FindControl("lblCatagoryName");

            Label lblelevel1 = (Label)e.Row.FindControl("lbllevel1");

            Label lblCount = (Label)e.Row.FindControl("lblCount");


            SqlCommand selectcommand = new SqlCommand("select sum(levelCount) as val , UserLevel  from [dbo].[yclcCatagoryView]  where CategoryId='" + lbltype.Text + "' and  userlevel=N'المبتدئ'  group by UserLevel,Catgeory_name");
            selectcommand.CommandType = CommandType.Text;
            selectcommand.Connection = cnn;
            cnn.ConnectionString = gm.ConnectionString();
            cnn.Open();
            selectcommand.ExecuteNonQuery();
            SqlDataAdapter selAdp = new SqlDataAdapter(selectcommand);
            DataTable dt = new DataTable();
            selAdp.Fill(dt);
            //lblelevel1.Text = dt.Rows[0]["val"].ToString();

            //decimal rowTotal = Convert.ToDecimal(dt.Rows[0]["val"].ToString());
            //grdTotal = grdTotal + rowTotal;
            if (dt.Rows.Count > 0)
            {
                lblelevel1.Text = dt.Rows[0]["val"].ToString();

                decimal rowTotal = Convert.ToDecimal(dt.Rows[0]["val"].ToString());
                grdTotal = grdTotal + rowTotal;

            }
            else
            { lblelevel1.Text = "0"; }
            cnn.Close();

            Label lblelevel2 = (Label)e.Row.FindControl("lbllbel2");
            SqlCommand selectcommand1 = new SqlCommand("select sum(levelCount) as val , UserLevel  from [dbo].[yclcCatagoryView]  where CategoryId='" + lbltype.Text + "' and  userlevel=N'المتقدم'  group by UserLevel,Catgeory_name");
            selectcommand1.CommandType = CommandType.Text;
            selectcommand1.Connection = cnn;
            cnn.ConnectionString = gm.ConnectionString();
            cnn.Open();
            selectcommand1.ExecuteNonQuery();
            SqlDataAdapter selAdp1 = new SqlDataAdapter(selectcommand1);
            DataTable dt1 = new DataTable();
            selAdp1.Fill(dt1);
            //lblelevel2.Text = dt1.Rows[0]["val"].ToString();

            //decimal rowTotal2 = Convert.ToDecimal(dt1.Rows[0]["val"].ToString());
            //grdTotal2 = grdTotal2 + rowTotal2;
            if (dt1.Rows.Count > 0)
            {

                lblelevel2.Text = dt1.Rows[0]["val"].ToString();

                decimal rowTotal2 = Convert.ToDecimal(dt1.Rows[0]["val"].ToString());
                grdTotal2 = grdTotal2 + rowTotal2;

            }
            else
            { lblelevel2.Text = "0"; }
            cnn.Close();



            Label lblelevel3 = (Label)e.Row.FindControl("lbllbel3");
            SqlCommand selectcommand2 = new SqlCommand("select sum(levelCount) as val , UserLevel  from [dbo].[yclcCatagoryView]  where CategoryId='" + lbltype.Text + "' and  userlevel=N'المتوسط'  group by UserLevel,Catgeory_name");
            selectcommand2.CommandType = CommandType.Text;
            selectcommand2.Connection = cnn;
            cnn.ConnectionString = gm.ConnectionString();
            cnn.Open();
            selectcommand2.ExecuteNonQuery();
            SqlDataAdapter selAdp2 = new SqlDataAdapter(selectcommand2);
            DataTable dt2 = new DataTable();
            selAdp2.Fill(dt2);

            if (dt2.Rows.Count > 0)
            {

                lblelevel3.Text = dt2.Rows[0]["val"].ToString();

            }
            else
            { lblelevel3.Text = "0"; }

            int i = int.Parse(lblelevel1.Text) + int.Parse(lblelevel2.Text) + int.Parse(lblelevel3.Text);

            lblCount.Text = i.ToString();

            decimal rowTotal3 = Convert.ToDecimal(lblelevel3.Text);
            grdTotal3 = grdTotal3 + rowTotal3;

            // lblelevel3.Text = dt2.Rows[0]["val"].ToString();
            cnn.Close();
            //int i = int.Parse(dt.Rows[0]["val"].ToString()) + int.Parse(dt1.Rows[0]["val"].ToString()) + int.Parse(dt2.Rows[0]["val"].ToString());

           // lblCount.Text = i.ToString();

           // decimal rowTotal3 = Convert.ToDecimal(dt2.Rows[0]["val"].ToString());
           // grdTotal3 = grdTotal3 + rowTotal3;
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl = (Label)e.Row.FindControl("lblTotal1");
            lbl.Text = grdTotal.ToString();

            lbl.ForeColor = System.Drawing.Color.Green;

            Label lbl1 = (Label)e.Row.FindControl("lblTotal2");
            lbl1.Text = grdTotal2.ToString();

            lbl1.ForeColor = System.Drawing.Color.Green;

            Label lbl2 = (Label)e.Row.FindControl("lblTotal3");
            lbl2.Text = grdTotal3.ToString();

            lbl2.ForeColor = System.Drawing.Color.Green;

            Label lbl3 = (Label)e.Row.FindControl("lbl");


            lbl3.ForeColor = System.Drawing.Color.Red;
            decimal GrandTot = grdTotal + grdTotal2 + grdTotal3;
            lbl3.Text = "Total :" + GrandTot.ToString();
        }

    }

    }
  
   
   

  
