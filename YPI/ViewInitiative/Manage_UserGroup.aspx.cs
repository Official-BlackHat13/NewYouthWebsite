using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewInitiative_Manage_UserGroup : System.Web.UI.Page
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
        str = "";
        string cmd = null;
        DataTable dt = default(DataTable);
        cmd = "select * from [MYA_PI_AppUsers_Groups]  order by [sort] asc ";
        dt = dbFunctions_YPI_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            dg.DataSource = dt;
            dg.DataBind();
            lnkDelete.Visible = true;
            dg.Visible = true;
            lnkSort.Visible = true;
        }
        else
        {
            lnkDelete.Visible = false;
            dg.Visible = false;
            lnkSort.Visible = false;
        }

        lblCount.Text = dt.Rows.Count + " record(s)";
    }
    public void cb0_change(object sender, EventArgs e)
    {
        int i = 0;
        if (((CheckBox)sender).Checked == true)
        {
            for (i = 0; i <= dg.Items.Count - 1; i++)
            {
                ((CheckBox)dg.Items[i].Cells[0].FindControl("cb")).Checked = true;
            }
        }
        else if (((CheckBox)sender).Checked == false)
        {
            for (i = 0; i <= dg.Items.Count - 1; i++)
            {
                ((CheckBox)dg.Items[i].Cells[0].FindControl("cb")).Checked = false;
            }
        }
    }
    public void Status_selected(object sender, EventArgs e)
    {
        int pId = 0;
        int i = 0;
        int j = 0;
        string sqlstr = null;
        pId = 0;
        DataGridItem dgItem = default(DataGridItem);
        int n = 0;
        CheckBox chkBox = default(CheckBox);
        CheckBox chkBox1 = default(CheckBox);
        CheckBox chkBox2 = default(CheckBox);
        for (i = 0; i <= dg.Items.Count; i++)
        {
            if (i > 0)
            {
                dgItem = dg.Items[i - 1];
                chkBox2 = (CheckBox)dgItem.FindControl("ch_Status");
                if (chkBox2.Checked == true)
                {
                    pId = Convert.ToInt32(dgItem.Cells[1].Text);
                    sqlstr = "update [MYA_PI_AppUsers_Groups] set [status]=1 where id=" + pId;
                    dbFunctions_YPI.ExecuteQuery(sqlstr);
                }
                if (chkBox2.Checked == false)
                {
                    pId = Convert.ToInt32(dgItem.Cells[1].Text);
                    sqlstr = "update [MYA_PI_AppUsers_Groups] set [status]=0 where id=" + pId;
                    dbFunctions_YPI.ExecuteQuery(sqlstr);
                }
            }
        }


        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Status Updated Successfully', 'success');", true);
        fillData();
    }



    protected void lk_del_Click(System.Object sender, System.EventArgs e)
    {
        string cmd;
        int i;
        for (i = 0; i <= dg.Items.Count - 1; i++)
        {
            if (((CheckBox)dg.Items[i].Cells[0].FindControl("cb")).Checked == true)
            {
                cmd = "delete from [MYA_PI_AppUsers_Groups] where [ID] = " + dg.Items[i].Cells[1].Text;
                dbFunctions_YPI.ExecuteQuery(cmd);
                ViewInitiativeAppUserActivityLog.CreateUserActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "UserGroups", "Delete", DateTime.Now, "" + dg.Items[i].Cells[1].Text + "", "" + dg.Items[i].Cells[2].Text + "", "");
            }
        }
        fillData();
    }

    public void dg_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
    {
        dg.CurrentPageIndex = e.NewPageIndex;
        fillData();
    }
    public void dg_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            dg.EditItemIndex = e.Item.ItemIndex;
            fillData();
        }
        else if (e.CommandName == "Update")
        {
            //string cmd;
            //cmd = "update [MYA_PI_Stage] set [Name]='" + globalFunctions.checkText(((TextBox)e.Item.Cells[2].Controls[0]).Text) + "' where id=" + e.Item.Cells[1].Text;
            SqlConnection sqlConnection = new SqlConnection(dbFunctions_YPI.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "update MYA_PI_AppUsers_Groups set NameAr=@NameAr where id=@id";

            sqlCommand.Parameters.AddWithValue("@NameAr", globalFunctions.checkText(((TextBox)e.Item.Cells[2].Controls[0]).Text));

            sqlCommand.Parameters.AddWithValue("@id", e.Item.Cells[1].Text);
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                ViewInitiativeAppUserActivityLog.CreateUserActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "UserGroups", "Edit", DateTime.Now, "" + e.Item.Cells[1].Text + "", "" + globalFunctions.checkText(((TextBox)e.Item.Cells[2].Controls[0]).Text) + "", "");
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'User Groups Infomation Has Been Updated Successfully', 'success');", true);
                dg.EditItemIndex = -1;
                fillData();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
            }
        }
        else if (e.CommandName == "Cancel")
        {
            dg.EditItemIndex = -1;
            fillData();
        }
    }

    public void lnkAdd_Click(object sender, EventArgs e)
    {
        string cmd;
        DataTable dt = new DataTable();

        if (TxtName.Text == "")
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Provide Departments To Add');", true);

        else
        {
            SqlConnection sqlConnection = new SqlConnection(dbFunctions_YPI.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "insert into MYA_PI_AppUsers_Groups(NameAr) values(@NameAr)";



            sqlCommand.Parameters.AddWithValue("@NameAr", TxtName.Text);

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                string StrNewID;

                StrNewID = "";


                cmd = " select top 1 id as NewID from [MYA_PI_AppUsers_Groups] order by id desc";
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
                ViewInitiativeAppUserActivityLog.CreateUserActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "UserGroups", "Add", DateTime.Now, "" + StrNewID + "", "" + TxtName.Text + "", "");
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'User Groups Infomation Has Been Created Successfully', 'success');", true);

                fillData();
                TxtName.Text = "";

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
            }

        }
    }

    public void lnkSort_Click(object sender, EventArgs e)
    {
        int i;
        string cmd;
        for (i = 0; i <= dg.Items.Count - 1; i++)
        {
            cmd = "update [MYA_PI_AppUsers_Groups] set [sort]=" + ((TextBox)dg.Items[i].Cells[3].FindControl("txtsort")).Text + " where [id] = " + dg.Items[i].Cells[1].Text;
            dbFunctions_YPI.ExecuteQuery(cmd);
        }
        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'User Groups Sort Has Been Updated Successfully', 'success');", true);

        fillData();
    }
    protected void DDLStage_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillData();
    }
}