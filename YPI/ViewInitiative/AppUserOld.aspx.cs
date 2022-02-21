using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

public partial class ViewInitiative_AppUserOld : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            ViewInitiativeAppCurrentUser.CheckLoggedIn();
            fillUserGroups();
            fillInstitutions();

            fillStage(DDLInstitution.SelectedValue);

            fillBusinessNursery();

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                //labtitle.Text = "Modify App Users";
                labtitle1.Text = "تعديل ";

                fillData();
            }
            else
            {

                if (DDLInstitution.SelectedValue == "2")
                {
                    DDLBusinessNursery.Enabled = true;
                }
                else
                {
                    DDLBusinessNursery.Enabled = false;
                }


                fillCheckBoxCondition();
                // labtitle.Text = "Create App Users ";
                labtitle1.Text = "إضافة ";
            }
        }
    }

    private void fillUserGroups()
    {
        string cmd;
        DataTable dt;
        cmd = "select * from [MYA_PI_AppUsers_Groups] where Status='" + true + "' order by Sort asc ";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLUserGroups.DataSource = dt;
            DDLUserGroups.DataTextField = "NameAr";
            DDLUserGroups.DataValueField = "id";
            DDLUserGroups.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--Select-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLUserGroups.Items.Add(it_bo);
        }
        else
        {
            DDLUserGroups.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--Select-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLUserGroups.Items.Add(it_bo);
        }
    }

    private void fillInstitutions()
    {
        string cmd;
        DataTable dt;
        cmd = "select * from [MYA_PI_Institutions] where Status='" + true + "' order by Sort asc ";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLInstitution.DataSource = dt;
            DDLInstitution.DataTextField = "NameAr";
            DDLInstitution.DataValueField = "id";
            DDLInstitution.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--Select-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLInstitution.Items.Add(it_bo);
        }
        else
        {
            DDLInstitution.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--Select-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLInstitution.Items.Add(it_bo);
        }
    }

    private void fillStage(String StrInstitutionID)
    {
        string cmd;
        DataTable dt;
        cmd = "select * from [MYA_PI_Stage] where Status='" + true + "' and InstitutionID=" + StrInstitutionID + " order by sort asc ";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLStage.DataSource = dt;
            DDLStage.DataTextField = "NameAr";
            DDLStage.DataValueField = "id";
            DDLStage.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--Select-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLStage.Items.Add(it_bo);
        }
        else
        {
            DDLStage.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--Select-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLStage.Items.Add(it_bo);
        }
    }

    private void fillBusinessNursery()
    {
        string cmd;
        DataTable dt;
        cmd = "select * from [MYA_PI_BusinessNursery] where Status='" + true + "' order by nameAr asc ";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLBusinessNursery.DataSource = dt;
            DDLBusinessNursery.DataTextField = "NameAr";
            DDLBusinessNursery.DataValueField = "id";
            DDLBusinessNursery.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--Select-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLBusinessNursery.Items.Add(it_bo);
        }
        else
        {
            DDLBusinessNursery.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--Select-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLBusinessNursery.Items.Add(it_bo);
        }
    }

    private void fillData()
    {
        DataTable dt = new DataTable();


        dt = dbFunctions_YPI.GetData("select * from [MYA_PI_AppUsers] where UserID=" + Request.QueryString["id"]);
        //Try


        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["Name"]))      // Here you can also check for DBNull or Empty string
                TxtName.Text = dt.Rows[0]["Name"].ToString();



            if (!DBNull.Value.Equals(dt.Rows[0]["UserName"]))
                TxtUserName.Text = dt.Rows[0]["UserName"].ToString();



            if (!DBNull.Value.Equals(dt.Rows[0]["Password"]))
                TxtPassword.Text = dt.Rows[0]["Password"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["Email"]))
                TxtEmail.Text = dt.Rows[0]["Email"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["Mobile"]))
                TxtMobile.Text = dt.Rows[0]["Mobile"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["CivilID"]))
                TxtCivilID.Text = dt.Rows[0]["CivilID"].ToString();


            if (!DBNull.Value.Equals(dt.Rows[0]["Institution"]))
                DDLInstitution.SelectedValue = dt.Rows[0]["Institution"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["UserType"]))
                DDLUserType.SelectedValue = dt.Rows[0]["UserType"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["Institution"]))
                DDLInstitution.SelectedValue = dt.Rows[0]["Institution"].ToString();

            if (DDLInstitution.SelectedValue == "2")
            {
                DDLBusinessNursery.Enabled = true;
            }
            else
            {
                DDLBusinessNursery.Enabled = false;
            }

            fillStage(DDLInstitution.SelectedValue);
            if (!DBNull.Value.Equals(dt.Rows[0]["StageID"]))
                DDLStage.SelectedValue = dt.Rows[0]["StageID"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["BusinessNurseryID"]))
                DDLBusinessNursery.SelectedValue = dt.Rows[0]["BusinessNurseryID"].ToString();

            ////Settings
            //if (!DBNull.Value.Equals(dt.Rows[0]["Settings"]))
            //{
            //    if (dt.Rows[0]["Settings"].ToString() == "True")
            //    {
            //        CH_Settings.Checked = true;
            //    }
            //    else
            //    {
            //        CH_Settings.Checked = false;
            //    }
            //}

            //Users
            if (!DBNull.Value.Equals(dt.Rows[0]["Users"]))
            {
                if (dt.Rows[0]["Users"].ToString() == "True")
                {
                    CH_Users.Checked = true;
                }
                else
                {
                    CH_Users.Checked = false;
                }
            }

            //DropDowns
            if (!DBNull.Value.Equals(dt.Rows[0]["DropDowns"]))
            {
                if (dt.Rows[0]["DropDowns"].ToString() == "True")
                {
                    CH_DropDowns.Checked = true;
                }
                else
                {
                    CH_DropDowns.Checked = false;
                }
            }

            //BusinessNursery
            if (!DBNull.Value.Equals(dt.Rows[0]["BusinessNursery"]))
            {
                if (dt.Rows[0]["BusinessNursery"].ToString() == "True")
                {
                    CH_BusinessNursery.Checked = true;
                }
                else
                {
                    CH_BusinessNursery.Checked = false;
                }
            }

            //Initiative
            if (!DBNull.Value.Equals(dt.Rows[0]["Initiative"]))
            {
                if (dt.Rows[0]["Initiative"].ToString() == "True")
                {
                    CH_Initiative.Checked = true;
                }
                else
                {
                    CH_Initiative.Checked = false;
                }
            }


            //RewiewApprove
            if (!DBNull.Value.Equals(dt.Rows[0]["RewiewApprove"]))
            {
                if (dt.Rows[0]["RewiewApprove"].ToString() == "True")
                {
                    CH_RewiewApprove.Checked = true;
                }
                else
                {
                    CH_RewiewApprove.Checked = false;
                }
            }

            //Report
            if (!DBNull.Value.Equals(dt.Rows[0]["Report"]))
            {
                if (dt.Rows[0]["Report"].ToString() == "True")
                {
                    CH_Report.Checked = true;
                }
                else
                {
                    CH_Report.Checked = false;
                }
            }


            lnkAdd.Text = "<i class='os-icon os-icon-ui-49'></i>&nbsp;Modify";
        }
        else
        {
            lnkAdd.Text = "<i class='os-icon os-icon-ui-22'></i>&nbsp;Add";
        }

    }

    public void lnkCancel_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != "")
            Response.Redirect("Manage_AppUsers.aspx");
        else
            Response.Redirect("Create_AppUsers.aspx");
    }

    public void lnkAdd_Click(object sender, EventArgs e)
    {
        string cmd;
        DataTable dt = new DataTable();

        string StrSettings, StrUsers, StrDropDowns, StrBusinessNursery, StrInitiative, StrRewiewApprove, StrReport;

        //if (CH_Settings.Checked == true)
        //    StrSettings = "1";
        //else
        //    StrSettings = "0";

        if (CH_Users.Checked == true)
            StrUsers = "1";
        else
            StrUsers = "0";

        if (CH_DropDowns.Checked == true)
            StrDropDowns = "1";
        else
            StrDropDowns = "0";

        if (CH_BusinessNursery.Checked == true)
            StrBusinessNursery = "1";
        else
            StrBusinessNursery = "0";

        if (CH_Initiative.Checked == true)
            StrInitiative = "1";
        else
            StrInitiative = "0";

        if (CH_RewiewApprove.Checked == true)
            StrRewiewApprove = "1";
        else
            StrRewiewApprove = "0";

        if (CH_Report.Checked == true)
            StrReport = "1";
        else
            StrReport = "0";



        if (lnkAdd.Text != "<i class='os-icon os-icon-ui-49'></i>&nbsp;Modify")
        {

            SqlConnection sqlConnection = new SqlConnection(dbFunctions_YPI.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "insert into MYA_PI_AppUsers(Name,Mobile,Email,CivilID,Username,Password,Institution,StageID,BusinessNurseryID,UserType,Users,DropDowns,BusinessNursery,Initiative,RewiewApprove,Report) values(@Name,@Mobile,@Email,@CivilID,@Username,@Password,@Institution,@StageID,@BusinessNurseryID,@UserType,@Users,@DropDowns,@BusinessNursery,@Initiative,@RewiewApprove,@Report)";

            sqlCommand.Parameters.AddWithValue("@Name", TxtName.Text);

            sqlCommand.Parameters.AddWithValue("@Mobile", TxtMobile.Text);

            sqlCommand.Parameters.AddWithValue("@Email", TxtEmail.Text);

            sqlCommand.Parameters.AddWithValue("@CivilID", TxtCivilID.Text);

            sqlCommand.Parameters.AddWithValue("@Username", TxtUserName.Text);

            sqlCommand.Parameters.AddWithValue("@Password", TxtPassword.Text);

            sqlCommand.Parameters.AddWithValue("@Institution", DDLInstitution.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@StageID", DDLStage.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@BusinessNurseryID", DDLBusinessNursery.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@UserType", DDLUserType.SelectedValue);

            // sqlCommand.Parameters.AddWithValue("@Settings", StrSettings);

            sqlCommand.Parameters.AddWithValue("@Users", StrUsers);

            sqlCommand.Parameters.AddWithValue("@DropDowns", StrDropDowns);

            sqlCommand.Parameters.AddWithValue("@BusinessNursery", StrBusinessNursery);

            sqlCommand.Parameters.AddWithValue("@Initiative", StrInitiative);

            sqlCommand.Parameters.AddWithValue("@RewiewApprove", StrRewiewApprove);

            sqlCommand.Parameters.AddWithValue("@Report", StrReport);



            //cmd = "insert into [MYA_PI_AppUsers] ([Name],[Username],[Password],[Mobile],[Email],[UserType],[Settings],[Initiative],[RewiewApprove],[Report]) values(N'" + globalFunctions.checkText(TxtName.Text) + "',N'" + globalFunctions.checkText(TxtUserName.Text) + "',N'" + globalFunctions.checkText(TxtPassword.Text) + "',N'" + globalFunctions.checkText(TxtMobile.Text) + "','" + globalFunctions.checkText(TxtEmail.Text) + "','" + globalFunctions.checkText(DDLUserType.SelectedValue) + "','" + StrSettings + "','" + StrInitiative + "','" + StrRewiewApprove + "','" + StrReport + "')";

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();


                string StrNewID;

                StrNewID = "";


                cmd = " select top 1 UserID as NewID from [MYA_PI_AppUsers] order by UserID desc";
                try
                {
                    dt = dbFunctions_YPI.GetData(cmd);
                    if (dt.Rows.Count != 0)
                        StrNewID = dt.Rows[0]["NewID"].ToString();
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(ex.Message);", true);
                }

                ViewInitiativeAppUserActivityLog.CreateUserActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "AppUsers", "Add", DateTime.Now, "" + StrNewID + "", "" + TxtName.Text + "", "");
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('App User Infomation Has Been Created Successfully');", true);

                TxtName.Text = "";
                TxtUserName.Text = "";
                TxtPassword.Text = "";
                TxtMobile.Text = "";
                TxtEmail.Text = "";
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
            }
        }
        else
        {
            SqlConnection sqlConnection = new SqlConnection(dbFunctions_YPI.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = sqlConnection;


            sqlCommand.CommandText = "update MYA_PI_AppUsers set Name=@Name,Mobile=@Mobile,Email=@Email,CivilID=@CivilID,Username=@Username,Password=@Password,UserType=@UserType,Institution=@Institution,StageID=@StageID,BusinessNurseryID=@BusinessNurseryID,Users=@Users,DropDowns=@DropDowns,BusinessNursery=@BusinessNursery,Initiative=@Initiative,RewiewApprove=@RewiewApprove,Report=@Report where UserID=@UserID";


            sqlCommand.Parameters.AddWithValue("@Name", TxtName.Text);

            sqlCommand.Parameters.AddWithValue("@Mobile", TxtMobile.Text);

            sqlCommand.Parameters.AddWithValue("@Email", TxtEmail.Text);

            sqlCommand.Parameters.AddWithValue("@CivilID", TxtCivilID.Text);

            sqlCommand.Parameters.AddWithValue("@Username", TxtUserName.Text);

            sqlCommand.Parameters.AddWithValue("@Password", TxtPassword.Text);

            sqlCommand.Parameters.AddWithValue("@UserType", DDLUserType.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@Institution", DDLInstitution.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@StageID", DDLStage.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@BusinessNurseryID", DDLBusinessNursery.SelectedValue);

            //sqlCommand.Parameters.AddWithValue("@Settings", StrSettings);

            sqlCommand.Parameters.AddWithValue("@Users", StrUsers);

            sqlCommand.Parameters.AddWithValue("@DropDowns", StrDropDowns);

            sqlCommand.Parameters.AddWithValue("@BusinessNursery", StrBusinessNursery);

            sqlCommand.Parameters.AddWithValue("@Initiative", StrInitiative);

            sqlCommand.Parameters.AddWithValue("@RewiewApprove", StrRewiewApprove);

            sqlCommand.Parameters.AddWithValue("@Report", StrReport);

            sqlCommand.Parameters.AddWithValue("@UserID", Request.QueryString["id"].ToString());



            try
            {


                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                ViewInitiativeAppUserActivityLog.CreateUserActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "AppUsers", "Modify", DateTime.Now, "" + Request.QueryString["id"] + "", "" + TxtName.Text + "", "");


                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('App User Infomation Has Been Modified Successfully');", true);
            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(ex.Message);", true);
            }
        }
    }

    protected void DDLInstitution_SelectedIndexChanged(object sender, EventArgs e)
    {

        fillStage(DDLInstitution.SelectedValue);

        if (DDLInstitution.SelectedValue == "2")
        {
            DDLBusinessNursery.Enabled = true;
        }
        else
        {
            DDLBusinessNursery.Enabled = false;
        }

        if (DDLInstitution.SelectedValue == "1")
        {
            DDLUserType.Enabled = true;
            DDLUserType.SelectedValue = "1";
            fillCheckBoxCondition();


        }
        else
        {


            DDLUserType.Enabled = false;
            DDLUserType.SelectedValue = "2";
            CH_Initiative.Checked = false;
            CH_BusinessNursery.Checked = false;
            CH_Users.Checked = false;

            CH_Users.Enabled = false;
            CH_DropDowns.Checked = false;
            CH_DropDowns.Enabled = false;
            CH_Initiative.Enabled = false;
            CH_BusinessNursery.Enabled = false;
        }

        fillCheckBoxCondition();
    }

    private void fillCheckBoxCondition()
    {

        if (DDLUserType.SelectedValue == "1")
        {
            CH_Initiative.Checked = true;
            CH_Initiative.Enabled = false;

            CH_BusinessNursery.Checked = true;
            CH_BusinessNursery.Enabled = false;

            CH_Users.Checked = true;
            CH_Users.Enabled = false;

            CH_DropDowns.Checked = true;
            CH_DropDowns.Enabled = false;


            CH_Report.Checked = true;
            CH_Report.Enabled = false;


            CH_RewiewApprove.Checked = true;
            CH_RewiewApprove.Enabled = false;
        }
        else
        {
            CH_Initiative.Checked = true;
            CH_Initiative.Enabled = true;

            CH_BusinessNursery.Checked = false;
            CH_BusinessNursery.Enabled = true;

            CH_Users.Checked = false;
            CH_Users.Enabled = true;

            CH_DropDowns.Checked = false;
            CH_DropDowns.Enabled = true;


            CH_Report.Checked = true;
            CH_Report.Enabled = true;


            CH_RewiewApprove.Checked = false;
            CH_RewiewApprove.Enabled = true;
        }
    }

    protected void DDLUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillCheckBoxCondition();
    }
}