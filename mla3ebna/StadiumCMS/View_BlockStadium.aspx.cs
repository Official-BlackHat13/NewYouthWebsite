using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class View_BlockStadium : System.Web.UI.Page
{
    int i;
    string str;
    string[] arr;


    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!this.IsPostBack)
        {
            CMSCurrentUser.CheckLoggedIn();

            fillGovernorate();
            fillArea();
            fillSchool();
            fillStadium();
            fillStadiumCourt();
            fillTimeSlot();


           // lnkDelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete?')";

            fillData();
        }
    }
    private void fillGovernorate()
    {
        string cmd;
        DataTable dt;
        //cmd = "select GovernorateID,GovernorateName + ' - ' + GovernorateNameEn AS GovernorateName from [MYA_Maleabna_Governorate] where Status='" + true + "' order by Sort asc ";
        //dt = dbFunctions.GetData(cmd);

        dt = dbFunctions.GetData("exec SP_GetAdminStadiumsDetails @type='gov',@userid=" + Session["MaleabnaCMSUserID"]);
        if (dt.Rows.Count != 0)
        {
            DDLGovernorate.DataSource = dt;
            DDLGovernorate.DataTextField = "GovernorateName";
            DDLGovernorate.DataValueField = "GovernorateID";
            DDLGovernorate.DataBind();

            if (dt.Rows.Count == 1)
            {
                DDLGovernorate.Enabled = false;
            }
            else
            {
                DDLGovernorate.Enabled = true;
                ListItem it_bo = new ListItem();
                it_bo.Text = "<--أختار-->";
                it_bo.Value = "0";
                it_bo.Selected = true;
                DDLGovernorate.Items.Add(it_bo);
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
        fillArea();
    }

    private void fillArea()
    {
        string cmd;
        DataTable dt;
        //if(DDLGovernorate.SelectedValue != "0")
        //    cmd = "select AreaID,AreaName + ' - ' + ISNULL(AreaNameEn,'') AS AreaName from [MYA_Maleabna_Area] where Status='" + true + "' and GovernorateID=" + DDLGovernorate.SelectedValue + "  order by AreaName asc ";
        //else
        //    cmd = "select AreaID,AreaName + ' - ' + ISNULL(AreaNameEn,'') AS AreaName from [MYA_Maleabna_Area] where Status='" + true + "' order by AreaName asc ";
        //dt = dbFunctions.GetData(cmd);
        dt = dbFunctions.GetData("exec SP_GetAdminStadiumsDetails @type='area',@govid='" + (DDLGovernorate.SelectedValue == "0" ? "" : DDLGovernorate.SelectedValue) + "',@userid=" + Session["MaleabnaCMSUserID"]);
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
            else if (dt.Rows.Count == 1)
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

        fillSchool();
        fillStadium();
    }


    private void fillTimeSlot()
    {
        string cmd;
        DataTable dt;
        //cmd = "select TimeSlotDetID,TimeSlot  from [MYA_Maleabna_TimeSlot_Det] ";
        //dt = dbFunctions.GetData(cmd);

        dt = dbFunctions.GetData("exec SP_GetAdminStadiumsDetails @type='timeslot',@userid=" + Session["MaleabnaCMSUserID"]);
        if (dt.Rows.Count != 0)
        {
            DDLTimeSlot.DataSource = dt;
            DDLTimeSlot.DataTextField = "TimeSlot";
            DDLTimeSlot.DataValueField = "TimeSlotDetID";
            DDLTimeSlot.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLTimeSlot.Items.Add(it_bo);
        }
        else
        {
            DDLTimeSlot.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLTimeSlot.Items.Add(it_bo);
        }
    }

    private void fillData()
    {
       
        string cmd;
        DataTable dt;


        str = "";

       
       str = str + "@userid='" + Session["MaleabnaCMSUserID"].ToString()+"'";
       

        if (DDLGovernorate.SelectedValue != "0")
            str = str + ",@govid='" + DDLGovernorate.SelectedValue + "' ";

        if (DDLArea.SelectedValue != "0")
            str = str + ",@areaid='" + DDLArea.SelectedValue + "' ";


        if (DDLSchool.SelectedValue != "0")
            str = str + ",@schoolid='" + DDLSchool.SelectedValue + "' ";


        if (DDLStadium.SelectedValue != "0")
            str = str + ",@stadiumid='" + DDLStadium.SelectedValue + "' ";


        if (DDLStadiumCourt.SelectedValue != "0")
            str = str + ",@court='" + DDLStadiumCourt.SelectedValue + "' ";

        if (ddlBlockBy.SelectedValue != "0")
            str = str + ",@blockby='" + ddlBlockBy.SelectedItem.Text.Trim() + "' ";

        if (txtFromDate.Text != "")
            str = str + ",@FrmDate='" + txtFromDate.Text + "'";
        else if (txtToDate.Text != "")
            str = str + ",@FrmDate='" + txtToDate.Text + "'";

        if (txtToDate.Text != "")
            str = str + ",@ToDate='" + txtToDate.Text + "'";
        else if (txtFromDate.Text != "")
            str = str + ",@ToDate='" + txtFromDate.Text + "'";


        str = str.Trim(new char[] { ',' });  

        //if ((txtFromDate.Text != "") && (txtToDate.Text != ""))
        //    str = str + ",(( ('" + txtFromDate.Text + "' between DateFrm and dateto )or ('" + txtToDate.Text + "' between  DateFrm and dateto)) or (( DateFrm between '" + txtFromDate.Text + "' and '" + txtToDate.Text + "') or (dateto between '" + txtFromDate.Text + "' and '" + txtToDate.Text + "')))" + " ";
        //else
        //{
        //    if (txtFromDate.Text != "")
        //        str = str + ",('" + txtFromDate.Text + "' between DateFrm and dateto )" + " ";

        //    if (txtToDate.Text != "")
        //        str = str + ",('" + txtToDate.Text + "' between DateFrm and dateto )" + " ";
        //}




        // str = str + ",Submitted = '" + true + "' ";

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

        
        //cmd = "select b.TimeSlotBlockId,format(b.DateFrm,'dd/MM/yyy') as DateFrm,format(b.DateTo,'dd/MM/yyyy') as DateTo,CreatedBy,b.BlockBy,b.Status,b.BlockBy," +
        //    "CASE when b.GovernorateID = 0 then '-' when b.GovernorateID != 0 then (select g.GovernorateName from  MYA_Maleabna_Governorate g where b.GovernorateID = g.GovernorateID ) End as GovernorateName,"+
        //    "CASE when b.AreaID = 0 then '-' when b.AreaID != 0 then (select a.AreaName from  MYA_Maleabna_Area a where b.AreaID = a.AreaID ) End as AreaName," +
        //    "CASE when b.SchoolID = 0 then '-' when b.schoolID != 0 then (select s.SchoolName from MYA_Maleabna_School s where b.SchoolID = s.SchoolID) End as SchoolName," +
        //    "CASE when b.StadiumID = 0 then '-' when b.StadiumID != 0 then (select st.StadiumName from MYA_Maleabna_Stadium st where b.StadiumID = st.StadiumID) End as StadiumName," +
        //    "CASE when b.StadiumCourtId = 0 then '-' when b.StadiumCourtId != 0 then (select sd.StadiumType from MYA_Maleabna_Stadium_Detail sd where b.StadiumCourtId = sd.StadiumDetId) End as StadiumType " +
            
        //    "From MYA_Maleabna_TimeSlot_Block b "+ str + "order by b.TimeSlotBlockId desc ";

        //dt = dbFunctions.GetData(cmd);

        dt = dbFunctions.GetData("exec SP_GetBLockedStadiums "+ str);

        if (dt.Rows.Count != 0)
        {
            GVData.DataSource = dt;
            GVData.DataBind();
           

            lnkDelete.Visible = false;
            GVData.Visible = true;
        }
        else
        {
            GVData.DataSource = null;
            GVData.DataBind();
            lnkDelete.Visible = false;            
        }


        lblCount.Text = dt.Rows.Count + " record(s)";
    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        fillData();
    }
    protected void lnkClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("View_BlockStadium.aspx", false);
        //DDLGovernorate.ClearSelection();
        //DDLArea.ClearSelection();
        //DDLSchool.ClearSelection();
        //DDLStadium.ClearSelection();
        //DDLStadiumCourt.ClearSelection();
        //ddlBlockBy.ClearSelection();

        //DDLGovernorate.SelectedValue = "0";
        //DDLGovernorate_SelectedIndexChanged(null, null);

        //DDLArea.SelectedValue = "0";
        //DDLArea_SelectedIndexChanged(null, null);

        //DDLSchool.SelectedValue = "0";
        //DDLSchool_SelectedIndexChanged(null, null);

        //DDLStadium.SelectedValue = "0";
        //DDLStadium_SelectedIndexChanged(null, null);

        //DDLStadiumCourt.SelectedValue = "0";

        //ddlBlockBy.SelectedValue = "0";

        //txtFromDate.Text = "";
        //txtToDate.Text = "";
        //fillData();
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVData.PageIndex = e.NewPageIndex;
        this.fillData();
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
        CheckBox chk = (CheckBox)sender;
        GridViewRow gvr = (GridViewRow)chk.NamingContainer;
        int RowIndex = gvr.RowIndex;

       // bool val = chk.Checked; // this also will work

        bool isSelected = ((CheckBox)GVData.Rows[RowIndex].Cells[0].FindControl("ch_Status")).Checked;
        int ItemId = Convert.ToInt32(((Label)GVData.Rows[RowIndex].Cells[0].FindControl("labItemID")).Text);
        string cmd = "update [MYA_Maleabna_TimeSlot_Block] set [Status]='" + isSelected + "' where TimeSlotBlockId=" + ItemId;
        dbFunctions.ExecuteQuery(cmd);
              
       
    }

    protected void DDLArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillSchool();
    }
    private void fillSchool()
    {
        string cmd;
        DataTable dt;

        //if(DDLArea.SelectedValue != "0")
        //    cmd = "select SchoolID,SchoolName + ' - ' + SchoolNameEn AS SchoolName from [MYA_Maleabna_School] where Status='" + true + "' and AreaID=" + DDLArea.SelectedValue + "  order by SchoolName asc ";
        //else
        //    cmd = "select SchoolID,SchoolName + ' - ' + SchoolNameEn AS SchoolName from [MYA_Maleabna_School] where Status='" + true + "'  order by SchoolName asc ";

        //dt = dbFunctions.GetData(cmd);
        dt = dbFunctions.GetData("exec SP_GetAdminStadiumsDetails @type='school',@govid='" + (DDLGovernorate.SelectedValue == "0" ? "" : DDLGovernorate.SelectedValue) + "',@areaid='" + (DDLArea.SelectedValue == "0" ? "" : DDLArea.SelectedValue) + "',@userid=" + Session["MaleabnaCMSUserID"]);


        if (dt.Rows.Count != 0)
        {
            DDLSchool.DataSource = dt;
            DDLSchool.DataTextField = "SchoolName";
            DDLSchool.DataValueField = "SchoolID";
            DDLSchool.DataBind();

            if (dt.Rows.Count > 1)
            {
                DDLSchool.Enabled = true;

                ListItem it_bo = new ListItem();
                it_bo.Text = "<--أختار-->";
                it_bo.Value = "0";
                it_bo.Selected = true;
                DDLSchool.Items.Add(it_bo);
            }
            else if (dt.Rows.Count == 1)
            {
                DDLSchool.Enabled = false;
            }




        }
        else
        {
            DDLSchool.Items.Clear();
            DDLSchool.Enabled = true;

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLSchool.Items.Add(it_bo);
        }

        fillStadium();
    }

    protected void DDLSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStadium();
    }
    private void fillStadium()
    {
        DataTable dt = dbFunctions.GetData("exec SP_GetAdminStadiumsDetails @type='stadium',@govid='" + (DDLGovernorate.SelectedValue == "0" ? "" : DDLGovernorate.SelectedValue) + "',@areaid='" + (DDLArea.SelectedValue == "0" ? "" : DDLArea.SelectedValue) + "',@schoolid='" + (DDLSchool.SelectedValue == "0" ? "" : DDLSchool.SelectedValue) + "',@userid=" + Session["MaleabnaCMSUserID"]);


        if (dt.Rows.Count != 0)
        {

            DDLStadium.DataSource = dt;
            DDLStadium.DataTextField = "StadiumName";
            DDLStadium.DataValueField = "StadiumID";
            DDLStadium.DataBind();

            if (dt.Rows.Count > 1)
            {
                DDLStadium.Enabled = true;

                ListItem it_bo = new ListItem();
                it_bo.Text = "<--أختار-->";
                it_bo.Value = "0";
                it_bo.Selected = true;
                DDLStadium.Items.Add(it_bo);
            }
            else if (dt.Rows.Count == 1)
            {
                DDLStadium.Enabled = false;
            }
        }
        else
        {
            DDLStadium.Items.Clear();

            DDLStadium.Enabled = true;
            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLStadium.Items.Add(it_bo);
        }
        fillStadiumCourt();
    }
    protected void DDLStadium_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStadiumCourt();
    }
    private void fillStadiumCourt()
    {
        string cmd;
        DataTable dt;
        
        //if(DDLStadium.SelectedValue != "0")
        //    cmd = "select  distinct StadiumType,StadiumDetId from [MYA_Maleabna_Stadium_Detail] where Status='" + true + "' and StadiumID=" + DDLStadium.SelectedValue + "  order by StadiumType asc ";
        //else
        //    cmd = "select  distinct StadiumType,StadiumDetId from [MYA_Maleabna_Stadium_Detail] where Status='" + true + "' order by StadiumType asc ";

        //dt = dbFunctions.GetData(cmd);

        dt = dbFunctions.GetData("exec SP_GetAdminStadiumsDetails @type='court',@govid='" + (DDLGovernorate.SelectedValue == "0" ? "" : DDLGovernorate.SelectedValue) + "',@areaid='" + (DDLArea.SelectedValue == "0" ? "" : DDLArea.SelectedValue) + "',@schoolid='" + (DDLSchool.SelectedValue == "0" ? "" : DDLSchool.SelectedValue) + "',@stadiumID='" + (DDLStadium.SelectedValue == "0" ? "" : DDLStadium.SelectedValue) + "',@userid=" + Session["MaleabnaCMSUserID"]);

        if (dt.Rows.Count != 0)
        {
            DDLStadiumCourt.DataSource = dt;
            DDLStadiumCourt.DataTextField = "StadiumType";
            DDLStadiumCourt.DataValueField = "StadiumDetId";
            DDLStadiumCourt.DataBind();

            if (dt.Rows.Count == 1)
            {
                DDLStadiumCourt.Enabled = false;
            }
            else
            {
                DDLStadiumCourt.Enabled = true;
                ListItem it_bo = new ListItem();
                it_bo.Text = "<--أختار-->";
                it_bo.Value = "0";
                it_bo.Selected = true;
                DDLStadiumCourt.Items.Add(it_bo);
            }


        }
        else
        {
            DDLStadiumCourt.Items.Clear();

            DDLStadiumCourt.Enabled = true;
            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLStadiumCourt.Items.Add(it_bo);

        }
    }

    //private void fillBlockData(string id)
    //{
    //    divblock.Visible = false;
    //    divAdminBlock.Visible = true;

    //    string cmd;
    //    DataTable dt;


    //    str = "";



    //    if (DDLGovernorate.SelectedValue != "0")
    //        str = str + ",GovernorateID=" + DDLGovernorate.SelectedValue + " ";

    //    if (DDLArea.SelectedValue != "0")
    //        str = str + ",AreaID=" + DDLArea.SelectedValue + " ";


    //    if (DDLSchool.SelectedValue != "0")
    //        str = str + ",SchoolID=" + DDLSchool.SelectedValue + " ";


    //    if (DDLStadium.SelectedValue != "0")
    //        str = str + ",StadiumID=" + DDLStadium.SelectedValue + " ";


    //    if (DDLStadiumCourt.SelectedValue != "0")
    //        str = str + ",StadiumCourtId=" + DDLStadiumCourt.SelectedValue + " ";


    //    if ((txtFromDate.Text != "") && (txtToDate.Text != ""))
    //        str = str + "(( ('" + txtFromDate.Text + "' between DateFrm and dateto )or ('" + txtToDate.Text + "' between  DateFrm and dateto)) or (( DateFrm between '" + txtFromDate.Text + "' and '" + txtToDate.Text + "') or (dateto between '" + txtFromDate.Text + "' and '" + txtToDate.Text + "')))" + " ";
    //    else
    //    {
    //        if (txtFromDate.Text != "")
    //            str = str + "('" + txtFromDate.Text + "' between DateFrm and dateto )'" + " ";

    //        if (txtToDate.Text != "")
    //            str = str + "('" + txtToDate.Text + "' between DateFrm and dateto )'" + " ";
    //    }




    //    // str = str + ",Submitted = '" + true + "' ";

    //    arr = str.Split(',');

    //    if (str != "")
    //    {
    //        str = " where ";
    //    }



    //    for (var i = 0; i < arr.Length; i++)
    //    {
    //        if (i > 1)
    //        {
    //            str = str + " and ";
    //        }
    //        str = str + (arr[i]);

    //    }

    //    if (str != "")
    //    {
    //        str = str + "and CreatedBy=" + id;
    //    }
    //    else
    //        str = "where CreatedBy=" + id;


    //    cmd = "select * from [MYA_Maleabna_TimeSlot_Block]" + str + " order by TimeSlotBlockId desc";

    //    dt = dbFunctions.GetData(cmd);

    //    if (dt.Rows.Count != 0)
    //    {

            


    //        GridViewAdmin.DataSource = dt;
    //        GridViewAdmin.DataBind();
    //        lnkDelete.Visible = false;
    //        GridViewAdmin.Visible = true;
    //    }
    //    else
    //    {
    //        lnkDelete.Visible = false;
    //        GridViewAdmin.Visible = false;
    //    }




    //    lblCount.Text = dt.Rows.Count + " record(s)";
    //}

    //private void fillBlockData(string id,GridView gd)
    //{
    //    divblock.Visible = false;
    //    divAdminBlock.Visible = true;

    //    string cmd;
    //    DataTable dt;


    //    str = "";



    //    if (DDLGovernorate.SelectedValue != "0")
    //        str = str + ",GovernorateID=" + DDLGovernorate.SelectedValue + " ";

    //    if (DDLArea.SelectedValue != "0")
    //        str = str + ",AreaID=" + DDLArea.SelectedValue + " ";


    //    if (DDLSchool.SelectedValue != "0")
    //        str = str + ",SchoolID=" + DDLSchool.SelectedValue + " ";


    //    if (DDLStadium.SelectedValue != "0")
    //        str = str + ",StadiumID=" + DDLStadium.SelectedValue + " ";


    //    if (DDLStadiumCourt.SelectedValue != "0")
    //        str = str + ",StadiumCourtId=" + DDLStadiumCourt.SelectedValue + " ";


    //    if ((txtFromDate.Text != "") && (txtToDate.Text != ""))
    //        str = str + "(( ('" + txtFromDate.Text + "' between DateFrm and dateto )or ('" + txtToDate.Text + "' between  DateFrm and dateto)) or (( DateFrm between '" + txtFromDate.Text + "' and '" + txtToDate.Text + "') or (dateto between '" + txtFromDate.Text + "' and '" + txtToDate.Text + "')))" + " ";
    //    else
    //    {
    //        if (txtFromDate.Text != "")
    //            str = str + "('" + txtFromDate.Text + "' between DateFrm and dateto )'" + " ";

    //        if (txtToDate.Text != "")
    //            str = str + "('" + txtToDate.Text + "' between DateFrm and dateto )'" + " ";
    //    }




    //    // str = str + ",Submitted = '" + true + "' ";

    //    arr = str.Split(',');

    //    if (str != "")
    //    {
    //        str = " where ";
    //    }
        


    //    for (var i = 0; i < arr.Length; i++)
    //    {
    //        if (i > 1)
    //        {
    //            str = str + " and ";
    //        }
    //        str = str + (arr[i]);

    //    }

    //    if (str != "")
    //    {
    //        str = str + "and CreatedBy=" + id;
    //    }
    //    else
    //        str = "where CreatedBy=" + id;


    //    cmd = "select * from [MYA_Maleabna_TimeSlot_Block]" + str + " order by TimeSlotBlockId desc";

    //    dt = dbFunctions.GetData(cmd);

    //    if (dt.Rows.Count != 0)
    //    {
    //        GridViewAdmin.DataSource = dt;
    //        GridViewAdmin.DataBind();

            
    //        //HtmlAnchor an = (HtmlAnchor)gd.FindControl("anchorblockstadium");
    //        //string str = an.HRef.ToString();
    //        //for (int i = 0; i < gd.Rows.Count; i++)
    //        //{
    //        //    BoundField boundField = new BoundField();
    //        //    if (gd.Columns[i].HeaderText.ToString() == "عرض")
    //        //    {
    //        //        boundField.DataField = "Edit_BlockStadiumDetails.aspx?TimeSlotBlockId=<%#DataBinder.Eval(Container.DataItem, 'TimeSlotBlockId')%>";
    //        //        boundField.HeaderText = "Edit";
    //        //        gd.Columns.Add(boundField);

    //        //    }

    //        //}


            
    //        lnkDelete.Visible = false;
    //        GridViewAdmin.Visible = true;
    //    }
    //    else
    //    {
    //        lnkDelete.Visible = false;
    //        GridViewAdmin.Visible = false;
    //    }




    //    lblCount.Text = dt.Rows.Count + " record(s)";
    //}


    protected void lnkanchor_Click(object sender, EventArgs e)
    {
        DDLGovernorate.SelectedValue = "0";
        DDLArea.SelectedValue = "0";
        DDLSchool.SelectedValue = "0";
        DDLStadium.SelectedValue = "0";
        DDLStadiumCourt.SelectedValue = "0";
        txtFromDate.Text = "";
        txtToDate.Text = "";       
       

        fillData();

       // fillBlockData(Session["MaleabnaCMSUserID"].ToString());

       

        
    }    
    //protected void lnkall_Click(object sender, EventArgs e)
    //{
    //    DDLGovernorate.SelectedValue = "0";
    //    DDLArea.SelectedValue = "0";
    //    DDLSchool.SelectedValue = "0";
    //    DDLStadium.SelectedValue = "0";
    //    DDLStadiumCourt.SelectedValue = "0";
    //    txtFromDate.Text = "";
    //    txtToDate.Text = "";

    //    lnkanchor.Visible = true;
    //    lnkall.Visible = false;

    //    fillData();
    //}
}