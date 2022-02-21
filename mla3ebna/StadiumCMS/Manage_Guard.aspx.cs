using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StadiumCMS_Manage_Guard : System.Web.UI.Page
{
    int i;
    string str;
    string[] arr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            CMSCurrentUser.CheckLoggedIn();
         
            //lnkDelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete?')";
            if (Session["MaleabnaCMSDeleteMenu"].ToString() == "True")
            {
                lnkDelete.Visible = true;

                lnkDelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete?')";
            }
            else
            {
                lnkDelete.Visible = false;

            }
            fillData();
        }
    }
    
    private void fillData()
    {
        string cmd;
        DataTable dt;


        str = "";

        if (TxtName.Text != "")
        {
            str = str + ",GuardName like N'%" + TxtName.Text + "%' ";
        }

        if (TxtMobile.Text != "")
        {
            str = str + ",Mobile ='" + TxtMobile.Text + "' ";
        }
        if (TxtCivilID.Text != "")
        {
            str = str + ",CivilID like '%" + TxtCivilID.Text + "%'";
        }

        // str = str + ",Submitted = '" + true + "' ";

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


        cmd = "select * from [MYA_Maleabna_Guard]" + str + " order by GuardID desc";

        dt = dbFunctions.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            GVData.DataSource = dt;
            GVData.DataBind();
            lnkDelete.Visible = false;
            GVData.Visible = true;
        }
        else
        {
            lnkDelete.Visible = false;
            GVData.Visible = false;
        }


        lblCount.Text = dt.Rows.Count + " record(s)";
    }

    public void cb0_change(object sender, EventArgs e)
    {
        int i = 0;
        if (((CheckBox)sender).Checked == true)
        {
            for (i = 0; i <= GVData.Rows.Count - 1; i++)
            {
                ((CheckBox)GVData.Rows[i].Cells[0].FindControl("cb")).Checked = true;
            }
        }
        else if (((CheckBox)sender).Checked == false)
        {
            for (i = 0; i <= GVData.Rows.Count - 1; i++)
            {
                ((CheckBox)GVData.Rows[i].Cells[0].FindControl("cb")).Checked = false;
            }
        }
    }

    private void lnkDelete_Click(object sender, EventArgs e)
    {
        string cmd;
        int i;
        for (i = 0; i <= GVData.Rows.Count - 1; i++)
        {
            if (((CheckBox)GVData.Rows[i].Cells[0].FindControl("cb")).Checked == true)
            {
                cmd = "delete from [MYA_Maleabna_Guard] where [GuardID] = " + ((Label)GVData.Rows[i].Cells[0].FindControl("labItemID")).Text;
                dbFunctions.ExecuteQuery(cmd);
            }
        }
        fillData();
    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVData.PageIndex = e.NewPageIndex;
        this.fillData();
    }

    public void lnkCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage_Guard.aspx");
    }

    public void lnkSerach_Click(object sender, EventArgs e)
    {
        GVData.PageIndex = 0;
        fillData();
    }

    public void Status_selected(object sender, EventArgs e)
    {
        string cmd;
        DataTable dt;

        int ItemId;
        string ItemName;
        bool isSelected;
        foreach (GridViewRow row in GVData.Rows)
        {
            i = row.DataItemIndex;
            ItemId = Convert.ToInt32(((Label)GVData.Rows[i].Cells[0].FindControl("labItemID")).Text);
            ItemName = GVData.Rows[i].Cells[2].Text;
            isSelected = ((CheckBox)GVData.Rows[i].Cells[0].FindControl("ch_Status")).Checked;//row.FindControl("ch_Status") as CheckBox.Checked;

            cmd = "update [MYA_Maleabna_Guard] set [Status]='" + isSelected + "' where GuardID=" + ItemId;
            dbFunctions.ExecuteQuery(cmd);
            CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, "Guard", "Update Status", DateTime.Now, "" + ItemId + "", "" + ItemName + "", "");
        }

        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Guard Updated Successfully', 'success');", true);

        fillData();
    }
}