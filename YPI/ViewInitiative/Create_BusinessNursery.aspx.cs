using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

public partial class ViewInitiative_Create_BusinessNursery : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            ViewInitiativeAppCurrentUser.CheckLoggedIn();

          

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                //labtitle.Text = "Modify App Users";
                labtitle1.Text = "تعديل ";

                fillData();
            }
            else
            {
                img_pic.Visible = false;
                // labtitle.Text = "Create App Users ";
                labtitle1.Text = "إضافة ";
            }
        }
    }
    private void fillData()
    {
        DataTable dt = new DataTable();


        dt = dbFunctions_YPI.GetData("select * from [MYA_PI_BusinessNursery] where id=" + Request.QueryString["id"]);
        //Try


        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["Name"]))      // Here you can also check for DBNull or Empty string
                TxtName.Text = dt.Rows[0]["Name"].ToString();



            if (!DBNull.Value.Equals(dt.Rows[0]["NameAr"]))
                TxtNameAr.Text = dt.Rows[0]["NameAr"].ToString();



            if (!DBNull.Value.Equals(dt.Rows[0]["Profile"]))
                TxtDescriptionEn.Text = dt.Rows[0]["Profile"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["ProfileAr"]))
                TxtDescriptionAr.Text = dt.Rows[0]["ProfileAr"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["Email"]))
                TxtEmail.Text = dt.Rows[0]["Email"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["ContactNumber"]))
                TxtMobile.Text = dt.Rows[0]["ContactNumber"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["Website"]))
                TxtMobile.Text = dt.Rows[0]["Website"].ToString();

            if (!DBNull.Value.Equals(dt.Rows[0]["Logo"]))
            {
                img_pic.Visible = true;
                img_pic.Src = "../YPIFiles/BusinessNursery/" + dt.Rows[0]["Logo"].ToString();
                labPhotoFile.Text = dt.Rows[0]["Logo"].ToString();
            }
            else
            { img_pic.Visible = false; }


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
            Response.Redirect("Manage_BusinessNursery.aspx");
        else
            Response.Redirect("Create_BusinessNursery.aspx");
    }

    public void lnkAdd_Click(object sender, EventArgs e)
    {
        string cmd;
        DataTable dt = new DataTable();

        string file;
        string ext;



        if (lnkAdd.Text != "<i class='os-icon os-icon-ui-49'></i>&nbsp;Modify")
        {
            file = uFile1.PostedFile.FileName;

            if (file != "")
            {
                file = Path.GetFileName(file);
                ext = Path.GetExtension(file);
                file = TxtName.Text + "_" + DateTime.Now.Day + DateTime.Now.Hour + "_" + DateTime.Now.Minute + DateTime.Now.Second + ext;
                uFile1.PostedFile.SaveAs(Server.MapPath("../YPIFiles/BusinessNursery/") + file);
            }


            SqlConnection sqlConnection = new SqlConnection(dbFunctions_YPI.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "insert into MYA_PI_BusinessNursery(Name,ContactNumber,Email,NameAr,Profile,ProfileAr,Website,Logo) values(@Name,@ContactNumber,@Email,@NameAr,@Profile,@ProfileAr,@Website,@Logo)";

            sqlCommand.Parameters.AddWithValue("@Name", TxtName.Text);

            sqlCommand.Parameters.AddWithValue("@ContactNumber", TxtMobile.Text);

            sqlCommand.Parameters.AddWithValue("@Email", TxtEmail.Text);

            sqlCommand.Parameters.AddWithValue("@NameAr", TxtNameAr.Text);

            sqlCommand.Parameters.AddWithValue("@Profile", TxtDescriptionEn.Text);

            sqlCommand.Parameters.AddWithValue("@ProfileAr", TxtDescriptionAr.Text);

            sqlCommand.Parameters.AddWithValue("@Website", TxtWebsite.Text);

            sqlCommand.Parameters.AddWithValue("@Logo", file);



            //cmd = "insert into [MYA_PI_AppUsers] ([Name],[Username],[Password],[Mobile],[Email],[UserType],[Settings],[Initiative],[RewiewApprove],[Report]) values(N'" + globalFunctions.checkText(TxtName.Text) + "',N'" + globalFunctions.checkText(TxtUserName.Text) + "',N'" + globalFunctions.checkText(TxtPassword.Text) + "',N'" + globalFunctions.checkText(TxtMobile.Text) + "','" + globalFunctions.checkText(TxtEmail.Text) + "','" + globalFunctions.checkText(DDLUserType.SelectedValue) + "','" + StrSettings + "','" + StrInitiative + "','" + StrRewiewApprove + "','" + StrReport + "')";

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();


                string StrNewID;

                StrNewID = "";


                cmd = " select top 1 id as NewID from [MYA_PI_BusinessNursery] order by id desc";
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

                ViewInitiativeAppUserActivityLog.CreateUserActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "BusinessNursery", "Add", DateTime.Now, "" + StrNewID + "", "" + TxtName.Text + "", "");
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Business Nursery Infomation Has Been Created Successfully');", true);

                TxtName.Text = "";
                TxtNameAr.Text = "";
                TxtDescriptionEn.Text = "";
                TxtDescriptionAr.Text = "";
                TxtMobile.Text = "";
                TxtEmail.Text = "";
                TxtWebsite.Text = "";
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', '" + ex.Message + "', 'error');", true);
            }
        }
        else
        {

            file = uFile1.PostedFile.FileName;

            if (file != "")
            {
                file = Path.GetFileName(file);
                ext = Path.GetExtension(file);
                file = TxtName.Text + "_" + DateTime.Now.Day + DateTime.Now.Hour + "_" + DateTime.Now.Minute + DateTime.Now.Second + ext;
                uFile1.PostedFile.SaveAs(Server.MapPath("../YPIFiles/BusinessNursery/") + file);
            }
            else
            {
                file = labPhotoFile.Text;
            }




            SqlConnection sqlConnection = new SqlConnection(dbFunctions_YPI.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = sqlConnection;


            sqlCommand.CommandText = "update MYA_PI_BusinessNursery set Name=@Name,ContactNumber=@ContactNumber,Email=@Email,NameAr=@NameAr,Profile=@Profile,ProfileAr=@ProfileAr,Website=@Website,Logo=@Logo where id=@id";


            sqlCommand.Parameters.AddWithValue("@Name", TxtName.Text);

            sqlCommand.Parameters.AddWithValue("@ContactNumber", TxtMobile.Text);

            sqlCommand.Parameters.AddWithValue("@Email", TxtEmail.Text);

            sqlCommand.Parameters.AddWithValue("@NameAr", TxtNameAr.Text);

            sqlCommand.Parameters.AddWithValue("@Profile", TxtDescriptionEn.Text);

            sqlCommand.Parameters.AddWithValue("@ProfileAr", TxtDescriptionAr.Text);

            sqlCommand.Parameters.AddWithValue("@Website", TxtWebsite.Text);

            sqlCommand.Parameters.AddWithValue("@Logo", file);
           

            sqlCommand.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());



            try
            {


                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                ViewInitiativeAppUserActivityLog.CreateUserActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "BusinessNursery", "Modify", DateTime.Now, "" + Request.QueryString["id"] + "", "" + TxtName.Text + "", "");

                fillData();
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Business Nursery Infomation Has Been Modified Successfully');", true);
            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(ex.Message);", true);
            }
        }
    }
}