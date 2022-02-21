using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

public partial class StadiumCMS_Create_TimeSlot : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            CMSCurrentUser.CheckLoggedIn();


            fillGovernorate();

            fillArea(DDLGovernorate.SelectedValue);

            fillStadium();

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                //labtitle.Text = "Modify App Users";
                labtitle1.Text = "تعديل ";

                fillData();
            }
            else
            {
                if (DDLType.SelectedValue == "1")
                {
                    TxtFromDate.Enabled = false;
                    TxtToDate.Enabled = false;
                    DDLStadium.Enabled = false;
                }
                else if (DDLType.SelectedValue == "2")
                {
                    TxtFromDate.Enabled = true;
                    TxtToDate.Enabled = true;
                    DDLStadium.Enabled = false;
                }
                else if (DDLType.SelectedValue == "3")
                {
                    TxtFromDate.Enabled = true;
                    TxtToDate.Enabled = true;
                    DDLStadium.Enabled = true;
                }
                else
                {
                    TxtFromDate.Enabled = false;
                    TxtToDate.Enabled = false;
                    DDLStadium.Enabled = false;
                }

                // labtitle.Text = "Create App Users ";
                labtitle1.Text = "إضافة ";
            }
        }
    }

    protected void DDLType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLType.SelectedValue == "1")
        {
            TxtFromDate.Enabled = false;
            TxtToDate.Enabled = false;
            DDLStadium.Enabled = false;
        }
        else if (DDLType.SelectedValue == "2")
        {
            TxtFromDate.Enabled = true;
            TxtToDate.Enabled = true;
            DDLStadium.Enabled = false;
        }
        else if (DDLType.SelectedValue == "3")
        {
            TxtFromDate.Enabled = true;
            TxtToDate.Enabled = true;
            DDLStadium.Enabled = true;
        }
        else
        {
            TxtFromDate.Enabled = false;
            TxtToDate.Enabled = false;
            DDLStadium.Enabled = false;
        }
    }

    private void fillGovernorate()
    {
        string cmd;
        DataTable dt;
        cmd = "select GovernorateID,GovernorateName + ' - ' + GovernorateNameEn AS GovernorateName from [MYA_Maleabna_Governorate] where Status='" + true + "' order by Sort asc ";
        dt = dbFunctions.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLGovernorate.DataSource = dt;
            DDLGovernorate.DataTextField = "GovernorateName";
            DDLGovernorate.DataValueField = "GovernorateID";
            DDLGovernorate.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLGovernorate.Items.Add(it_bo);
        }
        else
        {
            DDLGovernorate.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLGovernorate.Items.Add(it_bo);
        }
    }

    protected void DDLGovernorate_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillArea(DDLGovernorate.SelectedValue);
    }

    private void fillArea(string StrGovernorateID)
    {
        string cmd;
        DataTable dt;
        cmd = "select AreaID,AreaName + ' - ' + ISNULL(AreaNameEn,'') AS AreaName from [MYA_Maleabna_Area] where Status='" + true + "' and GovernorateID=" + StrGovernorateID + "  order by AreaName asc ";
        dt = dbFunctions.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLArea.DataSource = dt;
            DDLArea.DataTextField = "AreaName";
            DDLArea.DataValueField = "AreaID";
            DDLArea.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLArea.Items.Add(it_bo);
        }
        else
        {
            DDLArea.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLArea.Items.Add(it_bo);
        }
    }

    private void fillStadium()
    {
        string cmd;
        DataTable dt;
        cmd = "select StadiumID,StadiumName + ' - ' + StadiumNameEn AS StadiumName from [MYA_Maleabna_Stadium] where Status='" + true + "' order by StadiumName asc ";
        dt = dbFunctions.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLStadium.DataSource = dt;
            DDLStadium.DataTextField = "StadiumName";
            DDLStadium.DataValueField = "StadiumID";
            DDLStadium.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLStadium.Items.Add(it_bo);
        }
        else
        {
            DDLStadium.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLStadium.Items.Add(it_bo);
        }
    }

    private void fillData()
    {

    }



        protected void lnkCancel_Click(object sender, EventArgs e)
    {

    }

    protected void lnkAdd_Click(object sender, EventArgs e)
    {

    }
}