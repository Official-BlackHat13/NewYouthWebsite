using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StadiumCMS_Manage_Governorate : System.Web.UI.Page
{
    int i;
    string str;
    string[] arr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            CMSCurrentUser.CheckLoggedIn();


            lnkDelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete?')";
            fillData();
        }
    }

    private void fillData()
    {
        str = "";




        string cmd = null;
        DataTable dt = default(DataTable);
        cmd = "select * from [MYA_Maleabna_Governorate]  order by [sort] asc ";
        dt = dbFunctions.GetData(cmd);
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
                    sqlstr = "update [MYA_Maleabna_Governorate] set [status]=1 where GovernorateID=" + pId;
                    dbFunctions.ExecuteQuery(sqlstr);
                }
                if (chkBox2.Checked == false)
                {
                    pId = Convert.ToInt32(dgItem.Cells[1].Text);
                    sqlstr = "update [MYA_Maleabna_Governorate] set [status]=0 where GovernorateID=" + pId;
                    dbFunctions.ExecuteQuery(sqlstr);
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
                cmd = "delete from [MYA_Maleabna_Governorate] where [GovernorateID] = " + dg.Items[i].Cells[1].Text;
                dbFunctions.ExecuteQuery(cmd);
                CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, "Governorate", "Delete", DateTime.Now, "" + dg.Items[i].Cells[1].Text + "", "" + dg.Items[i].Cells[2].Text + "", "");
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
        
    }

    protected void dg_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        dg.EditItemIndex = e.Item.ItemIndex;
        SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

        SqlCommand sqlCommand = new SqlCommand();

        sqlCommand.Connection = sqlConnection;

        sqlCommand.CommandText = "update MYA_Maleabna_Governorate set GovernorateName=@GovernorateName,GovernorateNameEn=@GovernorateNameEn where GovernorateID=@GovernorateID";

        sqlCommand.Parameters.AddWithValue("@GovernorateName", globalFunctions.checkText(((TextBox)e.Item.Cells[2].Controls[0]).Text));

        sqlCommand.Parameters.AddWithValue("@GovernorateNameEn", globalFunctions.checkText(((TextBox)e.Item.Cells[3].Controls[0]).Text));

        sqlCommand.Parameters.AddWithValue("@GovernorateID", e.Item.Cells[1].Text);



        try
        {


            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();

            CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, "Governorate", "Edit", DateTime.Now, "" + e.Item.Cells[1].Text + "", "" + globalFunctions.checkText(((TextBox)e.Item.Cells[2].Controls[0]).Text) + "", "");

            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Governorate Infomation Has Been Updated Successfully', 'success');", true);
            dg.EditItemIndex = -1;
            fillData();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
        }
    }
    protected void dg_CancelCommand(object source, DataGridCommandEventArgs e)
    {

        dg.EditItemIndex = -1;
        fillData();

    }

    public void lnkSort_Click(object sender, EventArgs e)
    {
        int i;
        string cmd;
        for (i = 0; i <= dg.Items.Count - 1; i++)
        {
            SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "update MYA_Maleabna_Governorate set sort=@sort where id=@id";

            sqlCommand.Parameters.AddWithValue("@sort", ((TextBox)dg.Items[i].Cells[3].FindControl("txtsort")).Text);

            sqlCommand.Parameters.AddWithValue("@GovernorateID", dg.Items[i].Cells[1].Text);

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
        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Governorate Sort Has Been Updated Successfully', 'success');", true);

        fillData();
    }

    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        string cmd;
        DataTable dt = new DataTable();

        if (TxtName.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Provide GovernorateName To Add');", true);
        }
     
        else
        {
            SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "insert into MYA_Maleabna_Governorate(GovernorateName,GovernorateNameEn) values(@GovernorateName,@GovernorateNameEn)";

            sqlCommand.Parameters.AddWithValue("@GovernorateName", TxtName.Text);
            sqlCommand.Parameters.AddWithValue("@GovernorateNameEn", TxtNameEn.Text);
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                string StrNewID;

                StrNewID = "";


                cmd = " select top 1 GovernorateID as NewID from [MYA_Maleabna_Governorate] order by GovernorateID desc";
                try
                {
                    dt = dbFunctions.GetData(cmd);
                    if (dt.Rows.Count != 0)
                        StrNewID = dt.Rows[0]["NewID"].ToString();
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(ex.Message);", true);
                }
                CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, "Governorate", "Add", DateTime.Now, "" + StrNewID + "", "" + TxtName.Text + "", "");

                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Governorate Infomation Has Been Created Successfully', 'success');", true);

                fillData();
                TxtName.Text = "";
                TxtNameEn.Text = "";
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
            }

        }
    }

}