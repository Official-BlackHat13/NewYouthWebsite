using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Evaluator_Add_UserInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {


            EvalCurrentUser.CheckLoggedIn();



            FillGovernorate();
            fillArea();
            fillStadium();


            if (!string.IsNullOrEmpty(Request.QueryString["UserID"]))
            {
                DivStatus.Visible = true;
                LoadData();
                labtitle1.Text = "Modify ";
                lnkAdd.Text = "<i class='os-icon os-icon-ui-49'></i>&nbsp;Modify";

            }
            else
            {
                DivStatus.Visible = false;
                labtitle1.Text = "Create ";
                lnkAdd.Text = "<i class='os-icon os-icon-ui-22'></i>&nbsp;Add";
            }
           
        }
    }


    private void LoadData()
    {
        SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;

        sqlCommand.CommandText = "SP_MYA_Maleabna_Evaluate_UsersStatus";

        sqlCommand.CommandType = CommandType.StoredProcedure;

        sqlCommand.Parameters.AddWithValue("@flag", "S");
        sqlCommand.Parameters.AddWithValue("@UserID", Request.QueryString["UserID"]);

        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        DataTable dt = new DataTable();

        try
        {
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            adapter.Fill(dt);

        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
        }
        finally
        {
            sqlConnection.Close();
        }

        if (dt.Rows.Count > 0)
        {
            TextUserName.Text = dt.Rows[0]["UserName"].ToString();
            Textpwd.Text = dt.Rows[0]["Password"].ToString();
            TextName.Text = dt.Rows[0]["Name"].ToString();
            TextCivilID.Text = dt.Rows[0]["CivilID"].ToString();
            TextPhone.Text = dt.Rows[0]["Mobile"].ToString();
            TextEmail.Text = dt.Rows[0]["Email"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["GovernorateID"]))
            {
                DDLGovernorate.ClearSelection();
                DDLGovernorate.Items.FindByValue(dt.Rows[0]["GovernorateID"].ToString()).Selected = true;
                DDLGovernorate_SelectedIndexChanged(null, null);
            }

            if (!DBNull.Value.Equals(dt.Rows[0]["AreaID"]))
            {
                DDLArea.ClearSelection();
                DDLArea.Items.FindByValue(dt.Rows[0]["AreaID"].ToString()).Selected = true;
                DDLArea_SelectedIndexChanged(null, null);
            }

            if (!DBNull.Value.Equals(dt.Rows[0]["StadiumID"]))
            {
                string[] st =dt.Rows[0]["StadiumID"].ToString().Split(new char[]{','});

                foreach (string stitem in st)
                {
                    if (!string.IsNullOrEmpty(stitem))
                    {
                        foreach (ListItem chk in chkStadium.Items)
                        {
                            if (stitem == chk.Value)
                                chk.Selected = true;
                        }
                    }
                }

               
            }

            if (!DBNull.Value.Equals(dt.Rows[0]["UserType"]))
            {
                DDLUserType.Items.FindByText(dt.Rows[0]["UserType"].ToString()).Selected = true;
            }

            if (!DBNull.Value.Equals(dt.Rows[0]["Status"]))
            {
                chkstatus.Checked = bool.Parse(dt.Rows[0]["Status"].ToString());
            }
         
        }
    }


    private void FillGovernorate()
    {
       
        string cmd;
        DataTable dt;
        cmd = "select GovernorateID,GovernorateName + ' - ' + GovernorateNameEn AS GovernorateName from [MYA_Maleabna_Governorate] where Status='" + true + "' order by Sort asc ";
        dt = dbFunctions.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLGovernorate.DataSource = dt;
            DDLGovernorate.DataTextField = "GovernorateName";
            DDLGovernorate.DataValueField = "GovernorateID";

            DDLGovernorate.SelectedValue = null;


            DDLGovernorate.DataBind();

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;

            DDLGovernorate.Items.Add(it_bo);
           
        }
        else
        {
            DDLGovernorate.Items.Clear();


            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLGovernorate.Items.Add(it_bo);

        }

        


    }

    private void fillArea()
    {
        DDLArea.Items.Clear();
        string cmd;
        DataTable dt;
       
       cmd = "select AreaID,AreaName + ' - ' + ISNULL(AreaNameEn,'') AS AreaName from [MYA_Maleabna_Area] where Status='" + true + "' and GovernorateID=" + DDLGovernorate.SelectedValue + "  order by AreaName asc ";
       

        dt = dbFunctions.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            DDLArea.DataSource = dt;
            DDLArea.DataTextField = "AreaName";
            DDLArea.DataValueField = "AreaID";

            DDLArea.SelectedValue = null;
            DDLArea.DataBind();

            ListItem it_bo = new ListItem();

            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;

            DDLArea.Items.Add(it_bo);
           
        }
        else
        {

            ListItem it_bo = new ListItem();
            it_bo.Text = "<--أختار-->";
            it_bo.Value = "0";
            it_bo.Selected = true;
            DDLArea.Items.Add(it_bo);
           

        }
       
    }

    private void fillStadium()
    {
        string cmd;
        DataTable dt;


        cmd = "select StadiumID,StadiumName + ' - ' + StadiumNameEn AS StadiumName from [MYA_Maleabna_Stadium]  where AreaID=" + DDLArea.SelectedValue + " order by StadiumName asc ";
      
        dt = dbFunctions.GetData(cmd);
        if (dt.Rows.Count != 0)
        {

            chkStadium.DataSource = dt;
            chkStadium.DataTextField = "StadiumName";
            chkStadium.DataValueField = "StadiumID";

            chkStadium.SelectedValue = null;
            chkStadium.DataBind();
           
        }
       
    }

 
    protected void DDLGovernorate_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillArea();
    }

    protected void DDLArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStadium();
    }
    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        String SuccessMessgae = "";

        Page.Validate("MainValidate");
        if (Page.IsValid)
        {

            string stadiumList = string.Empty;

            foreach (ListItem item in chkStadium.Items)
            {
                if (item.Selected)
                {
                    stadiumList = stadiumList + "," + item.Value;
                }
            }

            stadiumList = stadiumList.Trim(new char[] { ',' });

            SqlConnection sqlConnection = new SqlConnection(dbFunctions.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "SP_MYA_Maleabna_Evaluate_UsersUpdation";

            sqlCommand.CommandType = CommandType.StoredProcedure;

           
            sqlCommand.Parameters.AddWithValue("@UserName", TextUserName.Text);
            sqlCommand.Parameters.AddWithValue("@Password", Textpwd.Text);
            sqlCommand.Parameters.AddWithValue("@Name", TextName.Text);
            sqlCommand.Parameters.AddWithValue("@CivilID", TextCivilID.Text);
            sqlCommand.Parameters.AddWithValue("@Mobile", TextPhone.Text);
            sqlCommand.Parameters.AddWithValue("@Email", TextEmail.Text);
            sqlCommand.Parameters.AddWithValue("@GovernorateID", DDLGovernorate.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@AreaID", DDLArea.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@StadiumID", stadiumList);
            sqlCommand.Parameters.AddWithValue("@UserType", DDLUserType.SelectedItem.Text);

            if (lnkAdd.Text != "<i class='os-icon os-icon-ui-49'></i>&nbsp;Modify")
            {

                sqlCommand.Parameters.AddWithValue("@flag", "I");
                SuccessMessgae = "Added Successfully!!!!!";
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@flag", "U");
                sqlCommand.Parameters.AddWithValue("@Status", chkstatus.Checked);
                sqlCommand.Parameters.AddWithValue("@UserID", Request.QueryString["UserID"]);
                SuccessMessgae = "Updated Successfully!!!!!!";
            }


            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
            }

            finally
            {
                sqlConnection.Close();
            }


            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('', '" + SuccessMessgae  + "', 'success');", true);


            if (lnkAdd.Text != "<i class='os-icon os-icon-ui-49'></i>&nbsp;Modify")
            {
                TextUserName.Text = "";
                Textpwd.Text = "";
                TextName.Text = "";
                TextCivilID.Text = "";
                TextPhone.Text = "";
                TextEmail.Text = "";


                DDLGovernorate.SelectedValue = "0";
                DDLArea.SelectedValue = "0";
                DDLUserType.SelectedValue = "0";

                chkStadium.DataSource = "";
                chkStadium.DataBind();

            }
           
        }

    }
}