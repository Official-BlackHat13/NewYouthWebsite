using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StadiumCMS_View_SchoolDetails : System.Web.UI.Page
{
    public string StrPrintbtn, StrGalleryDiv, StrVideoDiv;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CMSCurrentUser.CheckLoggedIn();
            lnkDelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete?')";
            fillData();

            fillSchoolStadiumData();
        }
    }

    private void fillData()
    {
        DataTable dt = new DataTable();

        DataTable Userdt = new DataTable();

        dt = dbFunctions.GetData("select * from [V_School] where SchoolID=" + Request.QueryString["SchoolID"]);
        //Try


        if (dt.Rows.Count != 0)
        {
            LabSchoolID.Text = dt.Rows[0]["SchoolID"].ToString();

            LabSchoolName.Text = dt.Rows[0]["SchoolName"].ToString();

            LabGovernorate.Text = dt.Rows[0]["GovernorateName"].ToString();

            LabArea.Text = dt.Rows[0]["AreaName"].ToString();

          

            LabAddress.Text = dt.Rows[0]["Address"].ToString();

        

            LabTelephoneNo.Text = dt.Rows[0]["TelephoneNo"].ToString();

            LabContactPersonName.Text = dt.Rows[0]["ContactPersonName"].ToString();

            LabContactPersonMobile.Text = dt.Rows[0]["ContactPersonMobile"].ToString();

            LabContactPersonEmail.Text = dt.Rows[0]["ContactPersonEmail"].ToString();



            //LabStadiumNameEn.Text = dt.Rows[0]["StadiumNameEn"].ToString();

            //LabGovernorateEn.Text = dt.Rows[0]["GovernorateNameEn"].ToString();

            //LabAreaEn.Text = dt.Rows[0]["AreaNameEn"].ToString();

            //LabSchoolEn.Text = dt.Rows[0]["SchoolNameEn"].ToString();

            //LabAddressEn.Text = dt.Rows[0]["AddressEn"].ToString();

            //LabDescriptionEn.Text = dt.Rows[0]["DescriptionEn"].ToString();

            //LabNoteEn.Text = dt.Rows[0]["Note"].ToString();
        }
    }

    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Create_School.aspx?ID=" + Request.QueryString["SchoolID"] + "");
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        string cmd;
        cmd = "delete from [MYA_Maleabna_School] where [SchoolID] = " + Request.QueryString["SchoolID"];
        dbFunctions.ExecuteQuery(cmd);
        CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, "School", "Delete", DateTime.Now, "" + Request.QueryString["SchoolID"] + "", "" + LabSchoolName.Text + "", "");

    }

    private void fillSchoolStadiumData()
    {
        DataTable dt = new DataTable();

        DataTable Userdt = new DataTable();

        dt = dbFunctions.GetData("select * from [V_StadiumInfo] where SchoolID=" + Request.QueryString["SchoolID"] + " order by StadiumID desc");
        //Try


        if (dt.Rows.Count != 0)
        {
            GVStadium.DataSource = dt;
            GVStadium.DataBind();
        }
    }

    protected void GVStadium_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVStadium.PageIndex = e.NewPageIndex;
        this.fillSchoolStadiumData();
    }
}