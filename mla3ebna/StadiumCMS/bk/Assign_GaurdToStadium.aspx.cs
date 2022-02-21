using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StadiumCMS_Assign_GaurdToStadium : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["StadiumID"]))
            {
                fillGaurdNames();
                fillGaurdData();
            }

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {

                // labtitle1.Text = "تعديل ";

                fillGaurdDataToEdit();
            }
            
        }
    }

    protected void fillGaurdData()
    {
        string cmd = null;
        DataTable dt = default(DataTable);
        cmd = "select * from MYA_Maleabna_Stadium_Guard join MYA_Maleabna_Guard on MYA_Maleabna_Guard.GuardID = MYA_Maleabna_Stadium_Guard.GuardID and MYA_Maleabna_Stadium_Guard.StadiumID =" + Request.QueryString["StadiumID"];
        dt = dbFunctions.GetData(cmd);
       
            dg.DataSource = dt;
            dg.DataBind();

            //setConfirm();
            //If dt.Rows.Count < 5 Then
            //    dg.PagerStyle.Visible = False
            //End If


            if (dt.Rows.Count > 0)
            {
                btnAdd.Enabled = false;               
            }
            else
                btnAdd.Enabled = true;

        lblCount.Text = dt.Rows.Count + " record(s)";


    }


    protected void fillGaurdDataToEdit()
    {
        fillGaurdNames();
        DataTable dt = new DataTable();


        dt = dbFunctions.GetData("select id,GuardID from MYA_Maleabna_Stadium_Guard where Status='1' and  id=" + Request.QueryString["id"]);
        //Try


        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["GuardID"]))      // Here you can also check for DBNull or Empty string
            {
                string GuardID = dt.Rows[0]["GuardID"].ToString().Trim();

                DDLGaurdName.ClearSelection();
                DDLGaurdName.Items.FindByValue(GuardID).Selected = true;
            }

           
            btnAdd.Text = "Modify";
        }
        else
        {
            btnAdd.Text = "Add";
        }
    }

    protected void fillGaurdNames()
    {
        DDLGaurdName.Items.Clear();
        string cmd = null;
        DataTable dt = default(DataTable);
        cmd = "select GuardID,GuardName from MYA_Maleabna_Guard  order by GuardID asc ";
        dt = dbFunctions.GetData(cmd);

        if (dt.Rows.Count > 0)
        {
            DDLGaurdName.DataSource = dt;
            DDLGaurdName.DataValueField = "GuardID";
            DDLGaurdName.DataTextField = "GuardName";
            DDLGaurdName.DataBind();


            ListItem it_bo = new ListItem();

            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;


            DDLGaurdName.Items.Add(it_bo);
           
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Validate("MainValidate");
        if (Page.IsValid)
        {
            if (btnAdd.Text != "Modify")
            {
                SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = "insert into MYA_Maleabna_Stadium_Guard(StadiumID,GuardID) values(@StadiumID,@GuardID)";

                sqlCommand.Parameters.AddWithValue("@StadiumID", Request.QueryString["StadiumID"]);

                sqlCommand.Parameters.AddWithValue("@GuardID", DDLGaurdName.SelectedValue.Trim());

                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Guard Has Been Assigned Successfully');", true);

                    DDLGaurdName.SelectedValue = "0";

                   
                    fillGaurdData();
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(ex.Message);", true);
                }
            }
            else
            {
                SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = "update MYA_Maleabna_Stadium_Guard set GuardID=@GuardID where id=@id";


                sqlCommand.Parameters.AddWithValue("@GuardID", DDLGaurdName.SelectedValue.Trim());

                sqlCommand.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                

                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();

                    DDLGaurdName.SelectedValue = "0";
                    
                    fillGaurdData();
                    btnAdd.Text = "Add";

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Guard for the Stadium Has Been Modified Successfully');", true);
                }
                catch (Exception ex)
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(ex.Message);", true);
                }
            }
        }
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


    protected void img_del_Click(object sender, ImageClickEventArgs e)
    {
        string cmd;
        int i;
        for (i = 0; i <= dg.Items.Count - 1; i++)
        {
            if (((CheckBox)dg.Items[i].Cells[0].FindControl("cb")).Checked == true)
            {
                cmd = "delete from [MYA_Maleabna_Stadium_Guard] where [id] = " + dg.Items[i].Cells[1].Text;
                dbFunctions.ExecuteQuery(cmd);
                // CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.CMSUserID, CMSCurrentUser.CMSName, "Blog", "Delete", DateTime.Now, "" + dg.Items[i].Cells[1].Text + "", "" + dg.Items[i].Cells[2].Text + "", "");
            }
        }

        fillGaurdNames();
        fillGaurdData();
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

            sqlCommand.CommandText = "update [MYA_Maleabna_Stadium_Guard] set sort=@sort where id=@id";

            sqlCommand.Parameters.AddWithValue("@sort", ((TextBox)dg.Items[i].Cells[4].FindControl("txtsort")).Text);

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
        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', 'Guard Sort Has Been Updated Successfully', 'success');", true);

        fillGaurdNames();
        fillGaurdData();
    }
}