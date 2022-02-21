using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewInitiative_Manage_UserGroupPermission : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewInitiativeAppCurrentUser.CheckLoggedIn();

            PanBN.Visible = false;
            fillUserGroups();

        

          
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
  
    private void fillData()
    {
        DataTable dt = new DataTable();


        dt = dbFunctions_YPI.GetData("select * from [MYA_PI_AppUsers_Groups_Permissions] where UserGroupID=" + DDLUserGroups.SelectedValue);


        if (dt.Rows.Count != 0)
        {

           



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

            //Settings
            if (!DBNull.Value.Equals(dt.Rows[0]["Settings"]))
            {
                if (dt.Rows[0]["Settings"].ToString() == "True")
                {
                    CH_Settings.Checked = true;
                }
                else
                {
                    CH_Settings.Checked = false;
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


            //URewiewApprove
            if (!DBNull.Value.Equals(dt.Rows[0]["URewiewApprove"]))
            {
                if (dt.Rows[0]["URewiewApprove"].ToString() == "True")
                {
                    CH_RewiewApprove.Checked = true;
                }
                else
                {
                    CH_RewiewApprove.Checked = false;
                }
            }


            //UEdit
            if (!DBNull.Value.Equals(dt.Rows[0]["UEdit"]))
            {
                if (dt.Rows[0]["UEdit"].ToString() == "True")
                {
                    CH_Edit.Checked = true;
                }
                else
                {
                    CH_Edit.Checked = false;
                }
            }


            //UPrint
            if (!DBNull.Value.Equals(dt.Rows[0]["UPrint"]))
            {
                if (dt.Rows[0]["UPrint"].ToString() == "True")
                {
                    CH_Print.Checked = true;
                }
                else
                {
                    CH_Print.Checked = false;
                }
            }

            //UDownload
            if (!DBNull.Value.Equals(dt.Rows[0]["UDownload"]))
            {
                if (dt.Rows[0]["UDownload"].ToString() == "True")
                {
                    CH_Download.Checked = true;
                }
                else
                {
                    CH_Download.Checked = false;
                }
            }


            //MYAAllStage
            if (!DBNull.Value.Equals(dt.Rows[0]["MYAAllStage"]))
            {
                if (dt.Rows[0]["MYAAllStage"].ToString() == "True")
                {
                    CH_MYAAll.Checked = true;
                }
                else
                {
                    CH_MYAAll.Checked = false;
                }
            }


            //MYAStage1
            if (!DBNull.Value.Equals(dt.Rows[0]["MYAStage1"]))
            {
                if (dt.Rows[0]["MYAStage1"].ToString() == "True")
                {
                    CH_MYAStage1.Checked = true;
                }
                else
                {
                    CH_MYAStage1.Checked = false;
                }
            }


            //MYAStage2
            if (!DBNull.Value.Equals(dt.Rows[0]["MYAStage2"]))
            {
                if (dt.Rows[0]["MYAStage2"].ToString() == "True")
                {
                    CH_MYAStage2.Checked = true;
                }
                else
                {
                    CH_MYAStage2.Checked = false;
                }
            }

            //MYAStage3
            if (!DBNull.Value.Equals(dt.Rows[0]["MYAStage3"]))
            {
                if (dt.Rows[0]["MYAStage3"].ToString() == "True")
                {
                    CH_MYAStage3.Checked = true;
                }
                else
                {
                    CH_MYAStage3.Checked = false;
                }
            }

            //MYAStage4
            if (!DBNull.Value.Equals(dt.Rows[0]["MYAStage4"]))
            {
                if (dt.Rows[0]["MYAStage4"].ToString() == "True")
                {
                    CH_MYAStage4.Checked = true;
                }
                else
                {
                    CH_MYAStage4.Checked = false;
                }
            }

            //MYAStage5
            if (!DBNull.Value.Equals(dt.Rows[0]["MYAStage5"]))
            {
                if (dt.Rows[0]["MYAStage5"].ToString() == "True")
                {
                    CH_MYAStage5.Checked = true;
                }
                else
                {
                    CH_MYAStage5.Checked = false;
                }
            }

            //MYAStage6
            if (!DBNull.Value.Equals(dt.Rows[0]["MYAStage6"]))
            {
                if (dt.Rows[0]["MYAStage6"].ToString() == "True")
                {
                    CH_MYAStage6.Checked = true;
                }
                else
                {
                    CH_MYAStage6.Checked = false;
                }
            }

            //MYAStage7
            if (!DBNull.Value.Equals(dt.Rows[0]["MYAStage7"]))
            {
                if (dt.Rows[0]["MYAStage7"].ToString() == "True")
                {
                    CH_MYAStage7.Checked = true;
                }
                else
                {
                    CH_MYAStage7.Checked = false;
                }
            }



            //BNAllStage
            if (!DBNull.Value.Equals(dt.Rows[0]["BNAllStage"]))
            {
                if (dt.Rows[0]["BNAllStage"].ToString() == "True")
                {
                    CH_BNAll.Checked = true;
                }
                else
                {
                    CH_BNAll.Checked = false;
                }
            }


            //BNStage1
            if (!DBNull.Value.Equals(dt.Rows[0]["BNStage1"]))
            {
                if (dt.Rows[0]["BNStage1"].ToString() == "True")
                {
                    CH_BNStage1.Checked = true;
                }
                else
                {
                    CH_BNStage1.Checked = false;
                }
            }

            //BNStage2
            if (!DBNull.Value.Equals(dt.Rows[0]["BNStage2"]))
            {
                if (dt.Rows[0]["BNStage2"].ToString() == "True")
                {
                    CH_BNStage2.Checked = true;
                }
                else
                {
                    CH_BNStage2.Checked = false;
                }
            }

            //BNStage3
            if (!DBNull.Value.Equals(dt.Rows[0]["BNStage3"]))
            {
                if (dt.Rows[0]["BNStage3"].ToString() == "True")
                {
                    CH_BNStage3.Checked = true;
                }
                else
                {
                    CH_BNStage3.Checked = false;
                }
            }

            //BNStage4
            if (!DBNull.Value.Equals(dt.Rows[0]["BNStage4"]))
            {
                if (dt.Rows[0]["BNStage4"].ToString() == "True")
                {
                    CH_BNStage4.Checked = true;
                }
                else
                {
                    CH_BNStage4.Checked = false;
                }
            }


            lnkAdd.Text = "<i class='os-icon os-icon-ui-49'></i>&nbsp;Modify";
        }
        else
        {
            CH_Users.Checked = false;
            CH_Settings.Checked = false;
            CH_BusinessNursery.Checked = false;
            CH_Initiative.Checked = false;
            CH_RewiewApprove.Checked = false;
            CH_Edit.Checked = false;
            CH_Print.Checked = false;
            CH_Delete.Checked = false;
            CH_Download.Checked = false;
            CH_MYAAll.Checked = false;
            CH_MYAStage1.Checked = false;
            CH_MYAStage2.Checked = false;
            CH_MYAStage4.Checked = false;
            CH_MYAStage5.Checked = false;
            CH_MYAStage6.Checked = false;
            CH_MYAStage7.Checked = false;
           
            CH_BNAll.Checked = false;
            CH_BNStage1.Checked = false;
            CH_BNStage2.Checked = false;
            CH_BNStage3.Checked = false;
            CH_BNStage4.Checked = false;
            lnkAdd.Text = "<i class='os-icon os-icon-ui-22'></i>&nbsp;Add";
        }
    }
    protected void DDLUserGroups_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillData();
    }

   
    public void lnkCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
        //if (Request.QueryString["id"] != "")
        //    Response.Redirect("Manage_AppUsers.aspx");
        //else
        //    Response.Redirect("Create_AppUsers.aspx");
    }

    public void lnkAdd_Click(object sender, EventArgs e)
    {

        string cmd;
        DataTable dt = new DataTable();

        string StrSettings, StrUsers, StrBusinessNursery, StrInitiative;



        if (CH_Users.Checked == true)
            StrUsers = "1";
        else
            StrUsers = "0";

        if (CH_Settings.Checked == true)
            StrSettings = "1";
        else
            StrSettings = "0";

        if (CH_BusinessNursery.Checked == true)
            StrBusinessNursery = "1";
        else
            StrBusinessNursery = "0";

        if (CH_Initiative.Checked == true)
            StrInitiative = "1";
        else
            StrInitiative = "0";

        string StrRewiewApprove, StrEdit, StrPrint, StrDelete, StrDownload;

        if (CH_RewiewApprove.Checked == true)
            StrRewiewApprove = "1";
        else
            StrRewiewApprove = "0";

        if (CH_Edit.Checked == true)
            StrEdit = "1";
        else
            StrEdit = "0";

        if (CH_Print.Checked == true)
            StrPrint = "1";
        else
            StrPrint = "0";

        if (CH_Delete.Checked == true)
            StrDelete = "1";
        else
            StrDelete = "0";

        if (CH_Download.Checked == true)
            StrDownload = "1";
        else
            StrDownload = "0";



        string StrMYAAllStage, StrMYAStage1, StrMYAStage2, StrMYAStage3, StrMYAStage4, StrMYAStage5, StrMYAStage6, StrMYAStage7;

        if (CH_MYAAll.Checked == true)
        { 
            StrMYAAllStage = "1";
            //StrMYAStage1 = "1";
            //StrMYAStage2 = "1";
            //StrMYAStage3= "1";
        }
        else
        { 
            StrMYAAllStage = "0";
        }

        if (CH_MYAStage1.Checked == true)
            StrMYAStage1 = "1";
        else
            StrMYAStage1 = "0";

        if (CH_MYAStage2.Checked == true)
            StrMYAStage2 = "1";
        else
            StrMYAStage2 = "0";

        if (CH_MYAStage3.Checked == true)
            StrMYAStage3 = "1";
        else
            StrMYAStage3 = "0";

        if (CH_MYAStage4.Checked == true)
            StrMYAStage4 = "1";
        else
            StrMYAStage4 = "0";

        if (CH_MYAStage5.Checked == true)
            StrMYAStage5 = "1";
        else
            StrMYAStage5 = "0";

        if (CH_MYAStage6.Checked == true)
            StrMYAStage6 = "1";
        else
            StrMYAStage6 = "0";

        if (CH_MYAStage7.Checked == true)
            StrMYAStage7 = "1";
        else
            StrMYAStage7 = "0";


        string StrBNAllStage, StrBNStage1, StrBNStage2, StrBNStage3, StrBNStage4;

        if (CH_BNAll.Checked == true)
        {
            StrBNAllStage = "1";
            //StrBNStage1 = "1";
            //StrBNStage2 = "1";
            //StrBNStage3 = "1";
            //StrBNStage4 = "1";
        }
        else
        {
            StrBNAllStage = "0";
        }

        if (CH_BNStage1.Checked == true)
            StrBNStage1 = "1";
        else
            StrBNStage1 = "0";

        if (CH_BNStage2.Checked == true)
            StrBNStage2 = "1";
        else
            StrBNStage2 = "0";

        if (CH_BNStage3.Checked == true)
            StrBNStage3 = "1";
        else
            StrBNStage3 = "0";

        if (CH_BNStage4.Checked == true)
            StrBNStage4 = "1";
        else
            StrBNStage4 = "0";


        if (lnkAdd.Text != "<i class='os-icon os-icon-ui-49'></i>&nbsp;Modify")
        {
            SqlConnection sqlConnection = new SqlConnection(dbFunctions_YPI.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "insert into MYA_PI_AppUsers_Groups_Permissions(UserGroupID,Users,Settings,BusinessNursery,Initiative,URewiewApprove,UEdit,UPrint,UDelete,UDownload,MYAAllStage,MYAStage1,MYAStage2,MYAStage3,MYAStage4,MYAStage5,MYAStage6,MYAStage7,BNAllStage,BNStage1,BNStage2,BNStage3,BNStage4) values(@UserGroupID,@Users,@Settings,@BusinessNursery,@Initiative,@URewiewApprove,@UEdit,@UPrint,@UDelete,@UDownload,@MYAAllStage,@MYAStage1,@MYAStage2,@MYAStage3,@MYAStage4,@MYAStage5,@MYAStage6,@MYAStage7,@BNAllStage,@BNStage1,@BNStage2,@BNStage3,@BNStage4)";
            //cmd = "insert into [MYA_PI_AppUsers_Groups_Permissions] (UserGroupID,Users,Settings,BusinessNursery,Initiative,URewiewApprove,UEdit,UPrint,UDelete,UDownload,MYAAllStage,MYAStage1,MYAStage2,MYAStage3,BNAllStage,BNStage1,BNStage2,BNStage3,BNStage4) values(N'" + DDLUserGroups.SelectedValue + "',N'" + StrUsers + "',N'" + StrSettings + "',N'" + StrBusinessNursery + "','" + StrInitiative + "','" + StrRewiewApprove + "','" + StrEdit + "','" + StrPrint + "','" + StrDelete+ "','" + StrDownload + "','" + StrMYAAllStage + "','" + StrMYAStage1 + "','" + StrMYAStage2 + "','" + StrMYAStage3 + "','" + StrBNAllStage + "','" + StrBNStage1 + "','" + StrBNStage2 + "','" + StrBNStage3 + "','" + StrBNStage4 + "')";
            //Response.Write(cmd);
            sqlCommand.Parameters.AddWithValue("@UserGroupID", DDLUserGroups.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@Users", StrUsers);

            sqlCommand.Parameters.AddWithValue("@Settings", StrSettings);

            sqlCommand.Parameters.AddWithValue("@BusinessNursery", StrBusinessNursery);

            sqlCommand.Parameters.AddWithValue("@Initiative", StrInitiative);



            sqlCommand.Parameters.AddWithValue("@URewiewApprove", StrRewiewApprove);

            sqlCommand.Parameters.AddWithValue("@UEdit", StrEdit);

            sqlCommand.Parameters.AddWithValue("@UPrint", StrPrint);

            sqlCommand.Parameters.AddWithValue("@UDelete", StrDelete);

            sqlCommand.Parameters.AddWithValue("@UDownload", StrDownload);



            sqlCommand.Parameters.AddWithValue("@MYAAllStage", StrMYAAllStage);

            sqlCommand.Parameters.AddWithValue("@MYAStage1", StrMYAStage1);

            sqlCommand.Parameters.AddWithValue("@MYAStage2", StrMYAStage2);

            sqlCommand.Parameters.AddWithValue("@MYAStage3", StrMYAStage3);

            sqlCommand.Parameters.AddWithValue("@MYAStage4", StrMYAStage4);

            sqlCommand.Parameters.AddWithValue("@MYAStage5", StrMYAStage5);

            sqlCommand.Parameters.AddWithValue("@MYAStage6", StrMYAStage6);

            sqlCommand.Parameters.AddWithValue("@MYAStage7", StrMYAStage7);


            sqlCommand.Parameters.AddWithValue("@BNAllStage", StrBNAllStage);

            sqlCommand.Parameters.AddWithValue("@BNStage1", StrBNStage1);

            sqlCommand.Parameters.AddWithValue("@BNStage2", StrBNStage2);

            sqlCommand.Parameters.AddWithValue("@BNStage3", StrBNStage3);

            sqlCommand.Parameters.AddWithValue("@BNStage4", StrBNStage4);





            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
         

                ViewInitiativeAppUserActivityLog.CreateUserActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "AppUsers Group Permission", "Add", DateTime.Now, "" + DDLUserGroups.SelectedValue + "", "" + DDLUserGroups.SelectedItem.Text + "", "");
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' User Group Permission Infomation Has Been Created Successfully');", true);
                fillData();

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


            sqlCommand.CommandText = "update MYA_PI_AppUsers_Groups_Permissions set Users=@Users,Settings=@Settings,BusinessNursery=@BusinessNursery,Initiative=@Initiative,URewiewApprove=@URewiewApprove,UEdit=@UEdit,UPrint=@UPrint,UDelete=@UDelete,UDownload=@UDownload,MYAAllStage=@MYAAllStage,MYAStage1=@MYAStage1,MYAStage2=@MYAStage2,MYAStage3=@MYAStage3,MYAStage4=@MYAStage4,MYAStage5=@MYAStage5,MYAStage6=@MYAStage6,MYAStage7=@MYAStage7,BNAllStage=@BNAllStage,BNStage1=@BNStage1,BNStage2=@BNStage2,BNStage3=@BNStage3,BNStage4=@BNStage4 where UserGroupID=@UserGroupID";

        

            sqlCommand.Parameters.AddWithValue("@Users", StrUsers);

            sqlCommand.Parameters.AddWithValue("@Settings", StrSettings);
      
            sqlCommand.Parameters.AddWithValue("@BusinessNursery", StrBusinessNursery);

            sqlCommand.Parameters.AddWithValue("@Initiative", StrInitiative);



            sqlCommand.Parameters.AddWithValue("@URewiewApprove", StrRewiewApprove);

            sqlCommand.Parameters.AddWithValue("@UEdit", StrEdit);

            sqlCommand.Parameters.AddWithValue("@UPrint", StrPrint);

            sqlCommand.Parameters.AddWithValue("@UDelete", StrDelete);

            sqlCommand.Parameters.AddWithValue("@UDownload", StrDownload);


            sqlCommand.Parameters.AddWithValue("@MYAAllStage", StrMYAAllStage);

            sqlCommand.Parameters.AddWithValue("@MYAStage1", StrMYAStage1);

            sqlCommand.Parameters.AddWithValue("@MYAStage2", StrMYAStage2);

            sqlCommand.Parameters.AddWithValue("@MYAStage3", StrMYAStage3);

            sqlCommand.Parameters.AddWithValue("@MYAStage4", StrMYAStage4);

            sqlCommand.Parameters.AddWithValue("@MYAStage5", StrMYAStage5);

            sqlCommand.Parameters.AddWithValue("@MYAStage6", StrMYAStage6);

            sqlCommand.Parameters.AddWithValue("@MYAStage7", StrMYAStage7);


            sqlCommand.Parameters.AddWithValue("@BNAllStage", StrBNAllStage);

            sqlCommand.Parameters.AddWithValue("@BNStage1", StrBNStage1);

            sqlCommand.Parameters.AddWithValue("@BNStage2", StrBNStage2);

            sqlCommand.Parameters.AddWithValue("@BNStage3", StrBNStage3);

            sqlCommand.Parameters.AddWithValue("@BNStage4", StrBNStage4);



            sqlCommand.Parameters.AddWithValue("@UserGroupID", DDLUserGroups.SelectedValue);


            //cmd = "update [MYA_PI_AppUsers_Groups_Permissions] set  [Users]='" + StrUsers + "',Settings='" + StrSettings + "',BusinessNursery='" + StrBusinessNursery + "',Initiative='" + StrInitiative + "',Settings='" + StrSettings + "' where UserGroupID=" + DDLUserGroups.SelectedValue + "";
                
            try
            {
               

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
               
                ViewInitiativeAppUserActivityLog.CreateUserActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "AppUsers Group Permission", "Modify", DateTime.Now, "" + DDLUserGroups.SelectedValue + "", "" +DDLUserGroups.SelectedItem.Text + "", "");

               
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('User Group Permission Infomation Has Been Modified Successfully');", true);

                fillData();
            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(ex.Message);", true);
            }
        }

    }

    public void MYAAllCheckALL(object sender, EventArgs e)
    {
        if (CH_MYAAll.Checked == true)
        {
            CH_MYAStage1.Checked = true;
            CH_MYAStage1.Enabled = false;

            CH_MYAStage2.Checked = true;
            CH_MYAStage2.Enabled = false;

            CH_MYAStage3.Checked = true;
            CH_MYAStage3.Enabled = false;

            CH_MYAStage4.Checked = true;
            CH_MYAStage4.Enabled = false;

            CH_MYAStage5.Checked = true;
            CH_MYAStage5.Enabled = false;

            CH_MYAStage6.Checked = true;
            CH_MYAStage6.Enabled = false;

            CH_MYAStage7.Checked = true;
            CH_MYAStage7.Enabled = false;
        }
        else
        {
            CH_MYAStage1.Checked = false;
            CH_MYAStage1.Enabled = true;

            CH_MYAStage2.Checked = false;
            CH_MYAStage2.Enabled = true;

            CH_MYAStage3.Checked = false;
            CH_MYAStage3.Enabled = true;

            CH_MYAStage4.Checked = false;
            CH_MYAStage4.Enabled = true;

            CH_MYAStage5.Checked = false;
            CH_MYAStage5.Enabled = true;

            CH_MYAStage6.Checked = false;
            CH_MYAStage6.Enabled = true;

            CH_MYAStage7.Checked = false;
            CH_MYAStage7.Enabled = true;
        }
    }


    public void BNAllCheckALL(object sender, EventArgs e)
    {
        if (CH_BNAll.Checked == true)
        {
            CH_BNStage1.Checked = true;
            CH_BNStage1.Enabled = false;

            CH_BNStage2.Checked = true;
            CH_BNStage2.Enabled = false;

            CH_BNStage3.Checked = true;
            CH_BNStage3.Enabled = false;

            CH_BNStage4.Checked = true;
            CH_BNStage4.Enabled = false;
        }
        else
        {
            CH_BNStage1.Checked = false;
            CH_BNStage1.Enabled = true;

            CH_BNStage2.Checked = false;
            CH_BNStage2.Enabled = true;

            CH_BNStage3.Checked = false;
            CH_BNStage3.Enabled = true;

            CH_BNStage4.Checked = false;
            CH_BNStage4.Enabled = true;
        }
    }
}