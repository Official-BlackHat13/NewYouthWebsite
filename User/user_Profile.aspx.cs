using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using QRCoder;
using System.Drawing;
using System.Text;
using System.Net.Mail;
using System.Security.Cryptography;
public partial class User_user_Profile : System.Web.UI.Page
{
   
    protected static string dateofbirth = string.Empty;
    protected static string imgpath = string.Empty;
    General gm = new General();
    SqlConnection cnn = new SqlConnection();
    string ID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["userid"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {

            if (!IsPostBack)
            {

                loaddata();

            }


        }
    }
    public string userid()
    {
        general_fn gfn = new general_fn();
        string strUserid = Session["userid"].ToString();
        strUserid = gfn.SessionDecrypt(strUserid, SHA512.Create().ToString());
        strUserid = strUserid.Substring(strUserid.IndexOf("&") + 1);
        return strUserid;
    }
    protected void loaddata()
    {
        cnn.ConnectionString = gm.ConnectionString();
        cnn.Open();
        ID = userid();

        SqlCommand cmd = new SqlCommand("userProfile_info", cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Id", ID);
        cmd.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = "";
        cmd.Parameters.AddWithValue("@mobile", SqlDbType.NVarChar).Value = "";
        cmd.Parameters.AddWithValue("@gender", SqlDbType.NVarChar).Value = "";
        cmd.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = "1";

        cmd.Parameters.AddWithValue("@imgQR", SqlDbType.NVarChar).Value = "";
        cmd.Parameters.Add("@existrow", SqlDbType.Int, 0, "id");
        cmd.Parameters["@existrow"].Direction = ParameterDirection.Output;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.ExecuteNonQuery();
        int exist = (int)cmd.Parameters["@existrow"].Value;
        DataSet ds = new DataSet();
        da.Fill(ds);
        cnn.Close();
        if (exist > 0)
        {

            gvloadpersenal(ds.Tables[0], exist);
        }
        cnn.Close();
    }
    protected void gvloadpersenal(DataTable dt, int exist)
    {

        DataTableReader dr = dt.CreateDataReader();
        ID = userid();


        while (dr.Read())
        {
            lblName.Text = dt.Rows[0]["Name"].ToString().Trim();
            lblCivil.Text = dt.Rows[0]["civil"].ToString().Trim();
            lblEmail.Text = dt.Rows[0]["email"].ToString().Trim();
            lblContactNo.Text = dt.Rows[0]["mobile"].ToString().Trim();
            lblGender.Text = dt.Rows[0]["gender"].ToString().Trim();
            dateofbirth = dt.Rows[0]["dob"].ToString().Trim();

            TxtName.Text = dt.Rows[0]["Name"].ToString().Trim();
            txtcivil.Text = dt.Rows[0]["civil"].ToString().Trim();
            txTEmail.Text = dt.Rows[0]["email"].ToString().Trim();

            txtmobile.Text = dt.Rows[0]["mobile"].ToString().Trim();

            ddlGender.SelectedIndex = ddlGender.Items.IndexOf(ddlGender.Items.FindByText(dt.Rows[0]["gender"].ToString()));

           

            imgpath = dt.Rows[0]["gender"].ToString().Trim();

            if (imgpath.Equals("ذكر"))
                {
                    lblImage.Src ="../Content/images/arab-male.png";

                }
                else
                {
                    lblImage.Src = "../Content/images/arab-female.png";

                }

           
          
            cnn.Close();

        }
        dr.Close();



    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {



            cnn.ConnectionString = gm.ConnectionString();
            cnn.Open();
            ID = userid();
            SqlCommand comand = new SqlCommand("userProfile_info", cnn);
            comand.CommandType = CommandType.StoredProcedure;
            comand.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = lblName.Text;
            comand.Parameters.AddWithValue("@mobile", SqlDbType.NVarChar).Value = txtmobile.Text;
            comand.Parameters.AddWithValue("@gender", SqlDbType.NVarChar).Value = ddlGender.SelectedItem.Text;
            comand.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = "2";
            comand.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;
            comand.Parameters.AddWithValue("@imgQR", SqlDbType.NVarChar).Value = "";
            var returnParameter = comand.Parameters.Add("@existrow", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.Output;
            returnParameter.Size = 100;
          
            comand.Connection = cnn;
          
            comand.ExecuteNonQuery();
            cnn.Close();

            loaddata();
        

        
         
        }

        catch (SqlException ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Exception');</script>", false);
        }

    }
    protected void btncancel_Click(object sender, EventArgs e)
    {


        Page_Load(null, null);
      
    }
}