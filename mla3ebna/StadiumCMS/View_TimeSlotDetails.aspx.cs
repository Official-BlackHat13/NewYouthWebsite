using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_TimeSlotDetails : System.Web.UI.Page
{
    public string StrPrintbtn, StrGalleryDiv, StrVideoDiv;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CMSCurrentUser.CheckLoggedIn();
            //fillTimeSlot();
            fillData();

            StrPrintbtn = " <a class='' href='javascript:void(0);'  onclick='openWinPrint(" + Request.QueryString["TimeSlotMasterID"] + ")'><i class='fa fa-print'></i><span>&nbsp;طباعه &nbsp;</span></a>";
        }
    }
    private void fillData()
    {
        string cmd;

        DataTable dt = new DataTable();

        DataTable Userdt = new DataTable();

        cmd = "select m.[TimeSlotMasterID],m.[GovernorateID],m.[AreaID],m.[SchoolID],m.[StadiumID],format(m.[DateFrm],'dd/MM/yyyy') as DateFrm,format(m.[DateTo],'dd/MM/yyyy') as DateTo,m.Status,m.[Type],m.[StadiumDetId],m.[CustomType]," +
            "CASE when m.GovernorateID = 0 then '0' when m.GovernorateID != 0 then (select g.GovernorateName from  MYA_Maleabna_Governorate g where m.GovernorateID = g.GovernorateID ) End as GovernorateName," +
            "CASE when m.AreaID = 0 then '0' when m.AreaID != 0 then (select a.AreaName from  MYA_Maleabna_Area a where m.AreaID = a.AreaID ) End as AreaName," +
           "CASE when m.SchoolID = 0 then '0' when m.schoolID != 0 then (select s.SchoolName from MYA_Maleabna_School s where m.SchoolID = s.SchoolID) End as SchoolName," +
           "CASE when m.StadiumID = 0 then '0' when m.StadiumID != 0 then (select st.StadiumName from MYA_Maleabna_Stadium st where m.StadiumID = st.StadiumID) End as StadiumName," +
           "CASE when m.StadiumDetId = 0 then '0' when m.StadiumDetId != 0 then (select sd.StadiumType from MYA_Maleabna_Stadium_Detail sd where m.StadiumDetId = sd.StadiumDetId) End as StadiumType " +
            "from MYA_Maleabna_TimeSlot_Master m where m.TimeSlotMasterID = " + Request.QueryString["TimeSlotMasterID"];


        //dt = dbFunctions.GetData("select [TimeSlotBlockId],format([DateFrm],'dd/MM/yyyy') as DateFrm,format([DateTo],'dd/MM/yyyy') as DateTo,[GovernorateID],[AreaID],[SchoolID],[StadiumID],[StadiumCourtId],[TimeSlotDetID],[BlockBy],CreatedBy from [MYA_Maleabna_TimeSlot_Block] where TimeSlotBlockId=" + Request.QueryString["TimeSlotBlockId"]);
        dt = dbFunctions.GetData(cmd);


        if (dt.Rows.Count != 0)
        {
            
            lbldetefrom.Text = dt.Rows[0]["DateFrm"].ToString();

            lbldateto.Text = dt.Rows[0]["DateTo"].ToString();

            lblTimeslottype.Text = dt.Rows[0]["Type"].ToString();

            if (lblTimeslottype.Text.Trim() == "Default")
                divDate.Visible = false;
            else
                divDate.Visible = true;

            if (lblTimeslottype.Text.Trim() == "Custom")
            {
                divcustom.Visible = true;
            }
            else
                divcustom.Visible = false;


                

            LabGovernorate.Text = dt.Rows[0]["GovernorateName"].ToString();

            

            LabArea.Text = dt.Rows[0]["AreaName"].ToString();

            LabSchool.Text = dt.Rows[0]["SchoolName"].ToString();

            LabStadium.Text = dt.Rows[0]["StadiumName"].ToString();

            LabCourt.Text = dt.Rows[0]["StadiumType"].ToString();

           // lblTimeSlot.Text = dt.Rows[0]["TimeSlot"].ToString();



            cmd = "select TimeSlot from MYA_Maleabna_TimeSlot_Det where TimeSlotMasterID = " + Request.QueryString["TimeSlotMasterID"];
            dt = dbFunctions.GetData(cmd);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lblTimeSlot.Text = lblTimeSlot.Text + dr["TimeSlot"].ToString() +",";
                }
            }
            lblTimeSlot.Text = lblTimeSlot.Text.Trim(new char[] { ',' });


            //string time = dt.Rows[0]["TimeSlotDetID"].ToString();
            //string[] timearray = time.Split(',');

            //if (ViewState["TimeSlotCount"].ToString() == timearray.Length.ToString())
            //{
            //    for (int j = 0; j < ChkTimeSlot.Items.Count; j++)
            //    {
            //        ChkTimeSlot.Items[j].Selected = true;
            //    }
            //}
            //else
            //{

            //    if (dt.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < timearray.Length; i++)
            //        {
            //            for (int k = 0; k < ChkTimeSlot.Items.Count; k++)
            //            {
            //                if (timearray[i] == ChkTimeSlot.Items[k].Value)
            //                    ChkTimeSlot.Items[k].Selected = true;

            //            }

            //        }
            //    }
            //}
            //ChkTimeSlot.Enabled = false;


        }
    }
}