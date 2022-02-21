using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewInitiative_Manage_Stage : System.Web.UI.Page
{
    int i;
    string str;
    string[] arr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            ViewInitiativeAppCurrentUser.CheckLoggedIn();
            fillInstitutions();

            lnkDelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete?')";
            fillData();
        }
    }
    protected void DDLInstitutions_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillData();
    }
    private void fillInstitutions()
    {
        string cmd;
        DataTable dt;
        cmd = "select * from [MYA_PI_Institutions] where Status='" + true + "' order by Sort asc ";
        dt = dbFunctions_YPI.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLInstitutions.DataSource = dt;
            DDLInstitutions.DataTextField = "Name";
            DDLInstitutions.DataValueField = "id";
            DDLInstitutions.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--Select-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLInstitutions.Items.Add(it_bo);
        }
        else
        {
            DDLInstitutions.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--Select-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLInstitutions.Items.Add(it_bo);
        }
    }

    private void fillData()
    {
        str = "";




        string cmd = null;
        DataTable dt = default(DataTable);
        cmd = "select * from [MYA_PI_Stage] where InstitutionID=" + DDLInstitutions.SelectedValue + " order by [sort] asc ";
        dt = dbFunctions_YPI.GetData(cmd);
        dg.DataSource = dt;
        dg.DataBind();
        //setConfirm();
        //If dt.Rows.Count < 5 Then
        //    dg.PagerStyle.Visible = False
        //End If
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
                    sqlstr = "update [MYA_PI_Stage] set [status]=1 where id=" + pId;
                    dbFunctions_YPI.ExecuteQuery(sqlstr);
                }
                if (chkBox2.Checked == false)
                {
                    pId = Convert.ToInt32(dgItem.Cells[1].Text);
                    sqlstr = "update [MYA_PI_Stage] set [status]=0 where id=" + pId;
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
                cmd = "delete from [MYA_PI_Stage] where [ID] = " + dg.Items[i].Cells[1].Text;
                dbFunctions_YPI.ExecuteQuery(cmd);
                ViewInitiativeAppUserActivityLog.CreateUserActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "Stages", "Delete", DateTime.Now, "" + dg.Items[i].Cells[1].Text + "", "" + dg.Items[i].Cells[2].Text + "", "");
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

            sqlCommand.CommandText = "update MYA_PI_Stage set NameAr=@NameAr where id=@id";

            sqlCommand.Parameters.AddWithValue("@NameAr", globalFunctions.checkText(((TextBox)e.Item.Cells[2].Controls[0]).Text));

            sqlCommand.Parameters.AddWithValue("@id", e.Item.Cells[1].Text);
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                ViewInitiativeAppUserActivityLog.CreateUserActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "Stages", "Edit", DateTime.Now, "" + e.Item.Cells[1].Text + "", "" + globalFunctions.checkText(((TextBox)e.Item.Cells[2].Controls[0]).Text) + "", "");
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Stage Infomation Has Been Updated Successfully', 'success');", true);
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

    public void lnkSort_Click(object sender, EventArgs e)
    {
        int i;
        string cmd;
        for (i = 0; i <= dg.Items.Count - 1; i++)
        {
            SqlConnection sqlConnection = new SqlConnection(dbFunctions_YPI.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "update MYA_PI_Stage set sort=@sort where id=@id";

            sqlCommand.Parameters.AddWithValue("@sort", ((TextBox)dg.Items[i].Cells[3].FindControl("txtsort")).Text);

            sqlCommand.Parameters.AddWithValue("@id", dg.Items[i].Cells[1].Text);

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
            }
            
        }
        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Stages Sort Has Been Updated Successfully', 'success');", true);
       
        fillData();
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

            sqlCommand.CommandText = "insert into MYA_PI_Stage(InstitutionID,NameAr) values(@InstitutionID,@NameAr)";

            sqlCommand.Parameters.AddWithValue("@InstitutionID", DDLInstitutions.SelectedValue);

            sqlCommand.Parameters.AddWithValue("@NameAr", TxtName.Text);

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                string StrNewID;

                StrNewID = "";


                cmd = " select top 1 id as NewID from [MYA_PI_Stage] order by id desc";
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
                ViewInitiativeAppUserActivityLog.CreateUserActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "Stage", "Add", DateTime.Now, "" + StrNewID + "", "" + TxtName.Text + "", "");
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Stage Infomation Has Been Created Successfully', 'success');", true);

                fillData();
                TxtName.Text = "";
                DDLInstitutions.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
            }

        }
    }
}