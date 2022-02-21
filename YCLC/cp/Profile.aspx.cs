using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Data;
using System.IO;


public partial class YCA_Admin_Profile : System.Web.UI.Page
{
    protected SqlCommand cmd;
    protected SqlConnection con, cnn;

    General gm = new General();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid_Yclid"] == null)
        {
            Response.Redirect("Index.aspx");
        }

        success.Visible = false;

        if (!IsPostBack)
        {
            String user = Session["userid_Yclid"].ToString();

            SQLConnection();


            String mysql1 = "select * from  tbl_Yclc_Login WHERE id=@user";

            SqlCommand cmd = new SqlCommand(mysql1, con);
            cmd.Parameters.AddWithValue("@user", SqlDbType.Int).Value = user;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            DataTableReader dtr = dt.CreateDataReader();
            if (dtr.HasRows)
            {
                while (dtr.Read())
                {

                    txtname.Text = dtr["Name"].ToString();
                    txtmob.Text = dtr["Phone"].ToString();
                    txtemail.Text = dtr["Email"].ToString();
                    Session["id"] = dtr["id"].ToString();
                 

                   
                }
            }

        }
        success.Visible = false;

    }
    public void SQLConnection()
    {
        con = new SqlConnection();
        con.ConnectionString = gm.ConnectionString();
        con.Open();

    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        pnlProfile.Visible = true;
        pnlResetPassword.Visible = false;
        txtname.Enabled = true;
        txtmob.Enabled = true;
        txtname.Focus();
        btUpdate.Visible = true;
       

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {


        pnlProfile.Visible = false;
        pnlResetPassword.Visible = true;
    

    }
    protected void btUpdate_Click(object sender, EventArgs e)
    {
        try
        {

            string id = Session["userid_Yclid"].ToString();

            SQLConnection();

            string passwrd = txtPassword.Text;

            SqlCommand cmd = new SqlCommand("UPDATE tbl_Yclc_Login set Name=@FullName, Phone =@Mobile, Email = @Email WHERE id=@id", con);

            cmd.Parameters.AddWithValue("@fullname", SqlDbType.NVarChar).Value = txtname.Text;
            cmd.Parameters.AddWithValue("@Mobile", SqlDbType.Float).Value = txtmob.Text;
            cmd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = txtemail.Text;  
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            //string tsk = txtname.Text;
            con.Close();
            Session["userid_Yclid"] = id;
            success.Visible = true;
        }

        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void btReset_Click(object sender, EventArgs e)
    {
        try
        {

            string id = Session["userid_Yclid"].ToString();

            SQLConnection();

            string passwrd = txtPassword.Text;

            SqlCommand cmd = new SqlCommand("UPDATE tbl_Yclc_Login set  password=@pwd WHERE id=@id", con);

            cmd.Parameters.AddWithValue("@pwd", SqlDbType.NVarChar).Value = txtPassword.Text;
          
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            //string tsk = txtname.Text;
            con.Close();
            Session.Abandon();
            Response.Redirect("Index.aspx");
        }

        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}
