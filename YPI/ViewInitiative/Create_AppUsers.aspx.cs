using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

public partial class ViewInitiative_Create_AppUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            ViewInitiativeAppCurrentUser.CheckLoggedIn();
            fillUserGroups();
            fillInstitutions();

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

                labtitle1.Text = "إضافة ";
            }
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
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLInstitution.Items.Add(it_bo);
        }
        else
        {
            DDLInstitution.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLInstitution.Items.Add(it_bo);
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
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLBusinessNursery.Items.Add(it_bo);
        }
        else
        {
            DDLBusinessNursery.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLBusinessNursery.Items.Add(it_bo);
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
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLUserGroups.Items.Add(it_bo);
        }
        else
        {
            DDLUserGroups.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLUserGroups.Items.Add(it_bo);
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

            if (DDLInstitution.SelectedValue == "2")
            {
                DDLBusinessNursery.Enabled = true;
            }
            else
            {
                DDLBusinessNursery.Enabled = false;
            }

            if (!DBNull.Value.Equals(dt.Rows[0]["BusinessNurseryID"]))
                DDLBusinessNursery.SelectedValue = dt.Rows[0]["BusinessNurseryID"].ToString();


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

      

      

        if (lnkAdd.Text != "<i class='os-icon os-icon-ui-49'></i>&nbsp;Modify")
        {

            SqlConnection sqlConnection = new SqlConnection(dbFunctions_YPI.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "insert into MYA_PI_AppUsers(Name,Mobile,Email,CivilID,Username,Password,UserGroupID,Institution,BusinessNurseryID) values(@Name,@Mobile,@Email,@CivilID,@Username,@Password,@UserGroupID,@Institution,@BusinessNurseryID)";

            sqlCommand.Parameters.AddWithValue("@Name", TxtName.Text);

            sqlCommand.Parameters.AddWithValue("@Mobile", TxtMobile.Text);

            sqlCommand.Parameters.AddWithValue("@Email", TxtEmail.Text);

            sqlCommand.Parameters.AddWithValue("@CivilID", TxtCivilID.Text);

            sqlCommand.Parameters.AddWithValue("@Username", TxtUserName.Text);

            sqlCommand.Parameters.AddWithValue("@Password", TxtPassword.Text);

            sqlCommand.Parameters.AddWithValue("@UserGroupID", DDLUserGroups.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@Institution", DDLInstitution.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@BusinessNurseryID", DDLBusinessNursery.SelectedValue);



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
                // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('App User Infomation Has Been Created Successfully');", true);
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'App User Information Has Been Created Successfully');", true);
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


            sqlCommand.CommandText = "update MYA_PI_AppUsers set Name=@Name,Mobile=@Mobile,Email=@Email,CivilID=@CivilID,Username=@Username,Password=@Password,UserGroupID=@UserGroupID,Institution=@Institution,BusinessNurseryID=@BusinessNurseryID where UserID=@UserID";


            sqlCommand.Parameters.AddWithValue("@Name", TxtName.Text);

            sqlCommand.Parameters.AddWithValue("@Mobile", TxtMobile.Text);

            sqlCommand.Parameters.AddWithValue("@Email", TxtEmail.Text);

            sqlCommand.Parameters.AddWithValue("@CivilID", TxtCivilID.Text);

            sqlCommand.Parameters.AddWithValue("@Username", TxtUserName.Text);

            sqlCommand.Parameters.AddWithValue("@Password", TxtPassword.Text);

           
            sqlCommand.Parameters.AddWithValue("@UserGroupID", DDLUserGroups.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@Institution", DDLInstitution.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@BusinessNurseryID", DDLBusinessNursery.SelectedValue);


            sqlCommand.Parameters.AddWithValue("@UserID", Request.QueryString["id"].ToString());



            try
            {
               

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                ViewInitiativeAppUserActivityLog.CreateUserActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "AppUsers", "Modify", DateTime.Now, "" + Request.QueryString["id"] + "", "" + TxtName.Text + "", "");

                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'App User Information Has Been Modified Successfully');", true);
                // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('App User Infomation Has Been Modified Successfully');", true);
            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
            }
        }
    }

    protected void DDLInstitution_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLInstitution.SelectedValue == "2")
        {
            DDLBusinessNursery.Enabled = true;
        }
        else
        {
            DDLBusinessNursery.Enabled = false;
        }
    }
}