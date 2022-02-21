﻿using System;
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
    decimal grdTotal4 = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["userid_Yclid"] == null)
        {
            Response.Redirect("Index.aspx");
        }
        else
        {



            // sqlace.ConnectionString = gm.ConnectionString();

            SqlCommand selectcommand = new SqlCommand("select CategoryId,Catgeory_name  from YCLCategory  order by Catgeory_name");
            selectcommand.CommandType = CommandType.Text;
            selectcommand.Connection = cnn;
            cnn.ConnectionString = gm.ConnectionString();
            cnn.Open();
            selectcommand.ExecuteNonQuery();
            cnn.Close();


            //SqlCommand selectcommand = new SqlCommand("yclcStatistics");
            //selectcommand.CommandType = CommandType.StoredProcedure;
            //selectcommand.Connection = cnn;
            //cnn.ConnectionString = gm.ConnectionString();
            //cnn.Open();                  
            //selectcommand.ExecuteNonQuery();
            SqlDataAdapter selAdp = new SqlDataAdapter(selectcommand);
            DataTable dt = new DataTable();
            selAdp.Fill(dt);
            grdAce.DataSource = dt;
            grdAce.DataBind();


        }
    }

    protected void btprint_Click(object sender, EventArgs e)
    {
        Response.Redirect("printStatLevel.aspx");
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
    protected void grdAce_DataBound(object sender, EventArgs e)
    {

    }
    protected void grdAce_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label lbltype = (Label)e.Row.FindControl("lblCatagoryName");

            Label lblelevel1 = (Label)e.Row.FindControl("lbllevel1");

            Label lblCount = (Label)e.Row.FindControl("lblCount");


            SqlCommand selectcommand = new SqlCommand("select sum(levelCount) as val , UserLevel  from [dbo].[yclcCatagoryView]  where CategoryId='" + lbltype.Text + "' and DebateLangaguge !='English'  and  userlevel=N'المبتدئ'  group by UserLevel,Catgeory_name");
            selectcommand.CommandType = CommandType.Text;
            selectcommand.Connection = cnn;
            cnn.ConnectionString = gm.ConnectionString();
            cnn.Open();
            selectcommand.ExecuteNonQuery();
            SqlDataAdapter selAdp = new SqlDataAdapter(selectcommand);
            DataTable dt = new DataTable();
            selAdp.Fill(dt);
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
            SqlCommand selectcommand1 = new SqlCommand("select sum(levelCount) as val , UserLevel  from [dbo].[yclcCatagoryView]  where CategoryId='" + lbltype.Text + "' and DebateLangaguge !='English'  and  userlevel=N'المتقدم'  group by UserLevel,Catgeory_name");
            selectcommand1.CommandType = CommandType.Text;
            selectcommand1.Connection = cnn;
            cnn.ConnectionString = gm.ConnectionString();
            cnn.Open();
            selectcommand1.ExecuteNonQuery();
            SqlDataAdapter selAdp1 = new SqlDataAdapter(selectcommand1);
            DataTable dt1 = new DataTable();
            selAdp1.Fill(dt1);
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
            SqlCommand selectcommand2 = new SqlCommand("select sum(levelCount) as val , UserLevel  from [dbo].[yclcCatagoryView]  where CategoryId='" + lbltype.Text + "'and DebateLangaguge !='English' and  userlevel=N'المتوسط'  group by UserLevel,Catgeory_name");
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

                decimal rowTotal3 = Convert.ToDecimal(lblelevel3.Text);
                grdTotal3 = grdTotal3 + rowTotal3;

            }
            else
            { lblelevel3.Text = "0"; }
            cnn.Close();



            Label lbllbelEng = (Label)e.Row.FindControl("lbllbelEng");
            SqlCommand selectcommand4 = new SqlCommand("select sum(levelCount) as val  from [dbo].[yclcCatagoryView]  where CategoryId='" + lbltype.Text + "'and DebateLangaguge ='English'  group by Catgeory_name");
            selectcommand4.CommandType = CommandType.Text;
            selectcommand4.Connection = cnn;
            cnn.ConnectionString = gm.ConnectionString();
            cnn.Open();
            selectcommand4.ExecuteNonQuery();
            SqlDataAdapter selAdp4 = new SqlDataAdapter(selectcommand4);
            DataTable dt4 = new DataTable();
            selAdp4.Fill(dt4);
            if (dt4.Rows.Count > 0)
            {

                lbllbelEng.Text = dt4.Rows[0]["val"].ToString();

                decimal rowTotal4 = Convert.ToDecimal(lbllbelEng.Text);
                grdTotal4 = grdTotal4 + rowTotal4;

            }
            else
            { lbllbelEng.Text = "0"; }
            cnn.Close();



            int i = int.Parse(lblelevel1.Text) + int.Parse(lblelevel2.Text) + int.Parse(lblelevel3.Text) + int.Parse(lbllbelEng.Text);

            lblCount.Text = i.ToString();
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

           
            Label lblTotalEng = (Label)e.Row.FindControl("lblTotalEng");
            lblTotalEng.Text = grdTotal4.ToString();
            lblTotalEng.ForeColor = System.Drawing.Color.Green;

            Label lbl3 = (Label)e.Row.FindControl("lbl");
            lbl3.ForeColor = System.Drawing.Color.Red;
            decimal GrandTot = grdTotal + grdTotal2 + grdTotal3 + grdTotal4;
            lbl3.Text = "Total :" + GrandTot.ToString();
        }

    }
}
   
   

  