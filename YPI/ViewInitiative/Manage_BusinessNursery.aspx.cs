using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewInitiative_Manage_BusinessNursery : System.Web.UI.Page
{
    int i;
    string str;
    string[] arr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            ViewInitiativeAppCurrentUser.CheckLoggedIn();

            lnkDelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete?')";
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
            str = str + ",Name like N'%" + TxtName.Text + "%' ";
        }

        if (TxtMobile.Text != "")
        {
            str = str + ",Mobile ='" + TxtMobile.Text + "' ";
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


        cmd = "select * from [MYA_PI_BusinessNursery]" + str + " order by id desc";

        dt = dbFunctions_YPI.GetData(cmd);

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
                cmd = "delete from [MYA_PI_BusinessNursery] where [id] = " + ((Label)GVData.Rows[i].Cells[0].FindControl("labItemID")).Text;
                dbFunctions_YPI.ExecuteQuery(cmd);
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
        Response.Redirect("Manage_BusinessNursery.aspx");
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
            ItemId = Convert.ToInt32(((Label)GVData.Rows[i].Cells[0].FindControl("labItemID")).Text);
            ItemName = GVData.Rows[i].Cells[2].Text;
            isSelected = ((CheckBox)GVData.Rows[i].Cells[0].FindControl("ch_Status")).Checked;//row.FindControl("ch_Status") as CheckBox.Checked;

            cmd = "update [MYA_PI_BusinessNursery] set [Status]='" + isSelected + "' where id=" + ItemId;
            dbFunctions_YPI.ExecuteQuery(cmd);
            ViewInitiativeAppUserActivityLog.CreateUserActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "BusinessNursery", "Update Status", DateTime.Now, "" + ItemId + "", "" + ItemName + "", "");
        }
        // CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.GBSAdminUserID, CMSCurrentUser.GBSAdminName, "Vendors", "Update Status To " & isSelected & "", Now, "" & ItemId & "", "" & ItemName & "", "")

        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Patients Status Updated');", true);
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


}