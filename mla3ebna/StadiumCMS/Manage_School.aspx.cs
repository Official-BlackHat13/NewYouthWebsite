using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StadiumCMS_Manage_School : System.Web.UI.Page
{
    int i;
    string str;
    string[] arr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            CMSCurrentUser.CheckLoggedIn();
            fillGovernorate();
            fillArea();
           // lnkDelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete?')";
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
    private void fillGovernorate()
    {
        string cmd;
        DataTable dt;
       // cmd = "select GovernorateID,GovernorateName + ' - ' + GovernorateNameEn AS GovernorateName from [MYA_Maleabna_Governorate] where Status='" + true + "' order by Sort asc ";
       // dt = dbFunctions.GetData(cmd);
        dt = dbFunctions.GetData("exec SP_GetAdminStadiumsDetails @type='gov',@userid=" + Session["MaleabnaCMSUserID"]);

        if (dt.Rows.Count != 0)
        {
            DDLGovernorate.DataSource = dt;
            DDLGovernorate.DataTextField = "GovernorateName";
            DDLGovernorate.DataValueField = "GovernorateID";
            DDLGovernorate.DataBind();

            if (dt.Rows.Count > 1)
            {
                DDLGovernorate.Enabled = true;

                ListItem it_bo = new ListItem();
                it_bo.Text = "<--أختار-->";
                it_bo.Value = "0";
                it_bo.Selected = true;
                DDLGovernorate.Items.Add(it_bo);
            }
            else
            {
                DDLGovernorate.Enabled = false;
            }

           
        }
        else
        {
            DDLGovernorate.Items.Clear();
            DDLGovernorate.Enabled = true;

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLGovernorate.Items.Add(it_bo);
        }
    }
    protected void DDLGovernorate_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["MaleabnaCMSUserID"] == null)
            Response.Redirect("login.aspx", false);
        else
        {
            fillArea();
        }
    }
    private void fillArea()
    {
        string cmd;
        DataTable dt;
       // cmd = "select AreaID,AreaName + ' - ' + ISNULL(AreaNameEn,'') AS AreaName from [MYA_Maleabna_Area] where Status='" + true + "' and GovernorateID=" + DDLGovernorate.SelectedValue + "  order by AreaName asc ";
        //dt = dbFunctions.GetData(cmd);
        dt = dbFunctions.GetData("exec SP_GetAdminStadiumsDetails @type='area',@govid='"+(DDLGovernorate.SelectedValue=="0"?"":DDLGovernorate.SelectedValue)+"',@userid=" + Session["MaleabnaCMSUserID"]);
        if (dt.Rows.Count != 0)
        {
            DDLArea.DataSource = dt;
            DDLArea.DataTextField = "AreaName";
            DDLArea.DataValueField = "AreaID";
            DDLArea.DataBind();

            if (dt.Rows.Count > 1)
            {
                DDLArea.Enabled = true;

                ListItem it_bo = new ListItem();
                it_bo.Text = "<--أختار-->";
                it_bo.Value = "0";
                it_bo.Selected = true;
                DDLArea.Items.Add(it_bo);
            }
            else
            {
                DDLArea.Enabled = false;
            }
        }
        else
        {
            DDLArea.Items.Clear();
            DDLArea.Enabled = true;

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLArea.Items.Add(it_bo);
        }
    }
    private void fillData()
    {
        string cmd;
        DataTable dt;


        str = "";

        //if (TxtName.Text != "")
        //{
        //    str = str + ",Name like N'%" + TxtName.Text + "%' ";
        //}
     

        //if (DDLGovernorate.SelectedValue != "0")
        //    str = str + ",GovernorateID=" + DDLGovernorate.SelectedValue + " ";

        //if (DDLArea.SelectedValue != "0")
        //    str = str + ",AreaID=" + DDLArea.SelectedValue + " ";



        //// str = str + ",Submitted = '" + true + "' ";

        //arr = str.Split(',');

        //if (str != "")
        //{
        //    str = " where ";
        //}
        //for (var i = 0; i < arr.Length; i++)
        //{
        //    if (i > 1)
        //    {
        //        str = str + " and ";
        //    }
        //    str = str + (arr[i]);

        //}



        //cmd = "select * from [MYA_Maleabna_School]" + str + " order by SchoolID desc";

        //dt = dbFunctions.GetData(cmd);

        if (TxtName.Text != "")
        {
            str = str + ",@name='" + TxtName.Text + "' ";
        }

        if (DDLGovernorate.SelectedValue != "0")
            str = str + ",@govid=" + DDLGovernorate.SelectedValue + " ";

        if (DDLArea.SelectedValue != "0")
            str = str + ",@areaid=" + DDLArea.SelectedValue + " ";

        str = str.Trim(new char[] { ',' });

        str = (str == ""?str:(str+","));


        dt = dbFunctions.GetData("exec SP_GetAdminData " + str + "@type='school',@userid=" + Session["MaleabnaCMSUserID"]);
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
                cmd = "delete from [MYA_Maleabna_School] where [SchoolID] = " + ((Label)GVData.Rows[i].Cells[0].FindControl("labItemID")).Text;
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
        Response.Redirect("Manage_School.aspx");
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
        int i = 0;
        int ItemId;
        string ItemName;
        bool isSelected;
        foreach (GridViewRow row in GVData.Rows)
        {
            ItemId = Convert.ToInt32(((Label)GVData.Rows[i].Cells[0].FindControl("labItemID")).Text);
            ItemName = GVData.Rows[i].Cells[2].Text;
            isSelected = ((CheckBox)GVData.Rows[i].Cells[0].FindControl("ch_Status")).Checked;//row.FindControl("ch_Status") as CheckBox.Checked;

            cmd = "update [MYA_Maleabna_School] set [Status]='" + isSelected + "' where SchoolID=" + ItemId;
            dbFunctions.ExecuteQuery(cmd);
           CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, "School", "Update Status", DateTime.Now, "" + ItemId + "", "" + ItemName + "", "");
           i++;
        }
        
        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'School Updated Successfully', 'success');", true);
       
        fillData();
    }
}