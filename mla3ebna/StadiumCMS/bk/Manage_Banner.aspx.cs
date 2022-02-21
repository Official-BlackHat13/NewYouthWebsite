using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StadiumCMS_Manage_Banner : System.Web.UI.Page
{
    int i;
    string str;
    string[] arr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            CMSCurrentUser.CheckLoggedIn();


            lnkDelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete?')";
            fillData();
        }
    }

    private void fillData()
    {
        string cmd;
        DataTable dt;


        str = "";

       

        arr = str.Split(',');

        if (str != "")
        {
            str = " where ";
        }
        for (var i = 0; i < arr.Length; i++)
        {
            if (i > 1)
            {
                str = str + " and ";
            }
            str = str + (arr[i]);

        }


        cmd = "select * from [MYA_Maleabna_Banner]" + str + " order by sort asc";

        dt = dbFunctions.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            dg.DataSource = dt;
            dg.DataBind();
            lnkDelete.Visible = true;
            dg.Visible = true;
          
        }
        else
        {
         
          
            lnkDelete.Visible = false;
            dg.Visible = false;
        }
        lblCount.Text = dt.Rows.Count + " record(s)";
    }

    private void setConfirm()
    {
        int i;
        for (i = 0; i <= dg.Items.Count - 1; i++)
            ((LinkButton)dg.Items[i].FindControl("lk_del")).Attributes["onClick"] = "return confirm('Are you sure you want to delete?')";
    }

    public void cb0_change(object sender, EventArgs e)
    {
        int i = 0;
        if (((CheckBox)sender).Checked == true)
        {
            for (i = 0; i <= dg.Items.Count - 1; i++)
            {
                ((CheckBox)dg.Items[i].Cells[0].FindControl("cb")).Checked = true;
            }
        }
        else if (((CheckBox)sender).Checked == false)
        {
            for (i = 0; i <= dg.Items.Count - 1; i++)
            {
                ((CheckBox)dg.Items[i].Cells[0].FindControl("cb")).Checked = false;
            }
        }
    }
    public void ShowStatus(object sender, EventArgs e)
    {
        int pId = 0;
        int i = 0;
        int j = 0;
        string sqlstr = null;
        pId = 0;
        DataGridItem dgItem = default(DataGridItem);
        int n = 0;
        CheckBox chkBox = default(CheckBox);
        CheckBox chkBox1 = default(CheckBox);
        CheckBox chkBox2 = default(CheckBox);
        for (i = 0; i <= dg.Items.Count; i++)
        {
            if (i > 0)
            {
                dgItem = dg.Items[i - 1];
                chkBox2 = (CheckBox)dgItem.FindControl("ch_Status");
                if (chkBox2.Checked == true)
                {
                    pId = Convert.ToInt32(dgItem.Cells[1].Text);
                    sqlstr = "update [MYA_Maleabna_Banner] set [status]=1 where BannerID=" + pId;
                    dbFunctions.ExecuteQuery(sqlstr);
                }
                if (chkBox2.Checked == false)
                {
                    pId = Convert.ToInt32(dgItem.Cells[1].Text);
                    sqlstr = "update [MYA_Maleabna_Banner] set [status]=0 where BannerID=" + pId;
                    dbFunctions.ExecuteQuery(sqlstr);
                }
            }
        }

        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Status Updated Successfully', 'success');", true);
        
       
        fillData();
    }

    

    protected void lk_del_Click(System.Object sender, System.EventArgs e)
    {
        string cmd;
        int i;
        for (i = 0; i <= dg.Items.Count - 1; i++)
        {
            if (((CheckBox)dg.Items[i].Cells[0].FindControl("cb")).Checked == true)
            {
                cmd = "delete from [MYA_Maleabna_Banner] where [BannerID] = " + dg.Items[i].Cells[1].Text;
                dbFunctions.ExecuteQuery(cmd);
                CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, "Banner", "Delete", DateTime.Now, "" + dg.Items[i].Cells[1].Text + "", "" + dg.Items[i].Cells[2].Text + "", "");
               
            }
        }
        fillData();
    }

    public Boolean chkImg(object str)
    {
        try
        {



            if (Convert.ToString(str).IndexOf(".") != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    protected void lnkSort_Click(System.Object sender, System.EventArgs e)
    {
        string cmd;
        int i;
        for (i = 0; i <= dg.Items.Count - 1; i++)
        {
            cmd = "update [MYA_Maleabna_Banner] set [Sort]='" + ((TextBox)dg.Items[i].Cells[6].FindControl("Txtsort")).Text + "' where [BannerID] = " + dg.Items[i].Cells[1].Text;
            dbFunctions.ExecuteQuery(cmd);
        }
        fillData();
        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Sort Updated Successfully', 'success');", true);
       // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Sort Updated Successfully');", true);
    }

    public void lnkCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage_Banner.aspx");
    }

    public void lnkSerach_Click(object sender, EventArgs e)
    {
        dg.CurrentPageIndex = 0;
        fillData();
       
    }
}