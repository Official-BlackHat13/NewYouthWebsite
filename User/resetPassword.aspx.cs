using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_resetPassword : System.Web.UI.Page
{

     General gm = new General();
    SqlConnection cnn = new SqlConnection();
    static string type = "UserInfo";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Server.HtmlEncode((Request.QueryString["rid"])) != null)
            {


                DataTable result = checkValue();

                if (result.Rows.Count == 0)
                {
                    alert.Visible = true;
                    resetform.Visible = false;
                }
                cnn.Close();
                cnn.Dispose();

            }
            else
            {
                Response.Redirect("Login.aspx", true);
            }
        }
    }

    private DataTable checkValue()
    {
        string pid = Server.HtmlEncode(Request.QueryString["rid"]);


        DataTable result = new DataTable();
        if (!pid.Equals(""))
        {
            cnn.ConnectionString = gm.ConnectionString();
            cnn.Open();

            SqlCommand cmd1 = new SqlCommand("tempInsert");
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@action", SqlDbType.NVarChar).Value = "select";
            cmd1.Parameters.AddWithValue("@pid", SqlDbType.NVarChar).Value = pid;
            cmd1.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = type;

            cmd1.Connection = cnn;
            cmd1.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd1);

            sda.Fill(result);
            // cnn.Close();
            //cnn.Dispose();
        }
        return result;

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
         string pid = Server.HtmlEncode(Request.QueryString["rid"]);
        if ((!txtPassword.Text.Equals("")) && (!txtConfirmPassowrd.Text.Equals("")))
        {
            general_fn gfn = new general_fn();
            try
            {
                DataTable result = checkValue();

                if (result.Rows.Count > 0)
                {
                    string email = result.Rows[0]["email"].ToString().Trim();
                    string id = result.Rows[0]["user_id"].ToString().Trim();
                    string ePass = gfn.ComputeHash(Server.HtmlEncode(txtPassword.Text.Trim()), email, "SHA512", null);
                    cnn.Close();

                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("forgotPasswordCheck");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@password", SqlDbType.NVarChar).Value = ePass;
                    cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = Server.HtmlEncode(email);
                    cmd.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = type;
                    cmd.Parameters.AddWithValue("@action", SqlDbType.NVarChar).Value = "updatepwd";
                    cmd.Connection = cnn;
                    cmd.ExecuteNonQuery();

                    cnn.Close();



                    cnn.Open();

                    SqlCommand cmdtemp = new SqlCommand("tempInsert");
                    cmdtemp.CommandType = CommandType.StoredProcedure;
                    cmdtemp.Parameters.AddWithValue("@action", SqlDbType.NVarChar).Value = "delete";
                    cmdtemp.Parameters.AddWithValue("@pid", SqlDbType.NVarChar).Value = pid;
                    cmdtemp.Parameters.AddWithValue("@userid", SqlDbType.NVarChar).Value = id;
                    cmdtemp.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = type;

                    cmdtemp.Connection = cnn;
                    cmdtemp.ExecuteNonQuery();

                    cnn.Close();


                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Sucessfully Updated');window.location.href = 'login.aspx'", true);

                }
            }

            catch (IndexOutOfRangeException ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Incorrect Password Combination');</script>", false);

            }
            finally
            {
                cnn.Dispose();
            }
        }
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Field are Empty');</script>", false);   

    
    }
}