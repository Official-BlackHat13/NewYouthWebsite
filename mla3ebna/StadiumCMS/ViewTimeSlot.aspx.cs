using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewTimeSlot : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            CMSCurrentUser.CheckLoggedIn();
            fillData();
        }
    }



    private void fillData()
    {

        string cmd;
        DataTable dt;



        //cmd = "select [Type],status,TimeSlotMasterID,"+
        //    "case when format(DateFrm,'dd/MM/yyyy') = '01/01/1900' then '-' when format(DateFrm,'dd/MM/yyyy') != '01/01/1900' then format(DateFrm,'dd/MM/yyyy') End as DateFrm,"+
        //    "case when format(DateTo,'dd/MM/yyyy') = '01/01/1900' then '-' when format(DateTo,'dd/MM/yyyy') != '01/01/1900' then format(DateTo,'dd/MM/yyyy') End as DateTo  FROM [MYA_Maleabna_TimeSlot_Master]";
       
       
        //dt = dbFunctions.GetData(cmd);
        dt = dbFunctions.GetData("exec SP_GetAdminData @type='timeslot',@userid=" + Session["MaleabnaCMSUserID"]);

        if (dt.Rows.Count != 0)
        {
            GVData.DataSource = dt;
            GVData.DataBind();


            //lnkDelete.Visible = false;
            GVData.Visible = true;
        }
        else
        {
            GVData.DataSource = null;
            GVData.DataBind();
            //lnkDelete.Visible = false;
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
    public void Status_selected(object sender, EventArgs e)
    {
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVData.PageIndex = e.NewPageIndex;
        this.fillData();
    }

}