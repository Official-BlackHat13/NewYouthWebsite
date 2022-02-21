using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ResetPassword : System.Web.UI.Page
{
    MGeneral clsGeneral = new MGeneral();
    string GstrDbKey = "MalebnaDB";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //Session["unique"] = Server.HtmlEncode(Request.QueryString["uid"]);
            FillUserName(Server.HtmlEncode(Request.QueryString["uid"]).ToString());
        }
    }

    protected void FillUserName(string uid)
    {
        DataTable dt = Get_User_Details(uid);

        DataColumnCollection columns = dt.Columns;
        if (columns.Contains("message"))
        {

        }
        else
        {
            txtUserName.Text = dt.Rows[0]["UserName"].ToString();
        }
    }

    public DataTable  Get_User_Details(string ls_euid)
    {

        DataTable dt = new DataTable();
        DataSet DS = new DataSet();       
      
        int li_userid;
        try
        {
            //li_userid = getUserid(ls_euid);
            DS = clsGeneral.GetDS("select UserName from MYA_Maleabna_Members where useruid='" + ls_euid + "'", GstrDbKey, "Table", true);

            if (DS.Tables[0].Rows.Count == 0)
                dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
            else
            {
                dt = DS.Tables[0];
            }
            
        }
        catch (Exception ex)
        {
            dt = clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0);
        }
        finally
        {

        }

        return dt;
    }
    protected void lnkSubmit_Click(object sender, EventArgs e)
    {
        Page.Validate("reset");
        if (Page.IsValid)
        {
            DataTable dt =  Update_New_Pwd(Server.HtmlEncode(Request.QueryString["uid"]).ToString(), txtPwd.Text.Trim());

            divmodalmsg.InnerHtml = dt.Rows[0]["message"].ToString();
            divmodalmsg.Visible = true;

            if (dt.Rows[0]["Error"].ToString().Trim() == "Sucess")
                Response.Redirect("Login.aspx", false);


            //$('#divmodalmsg').html(data[0].message);
            //              $('#divmodalmsg').show();
            //              $("#divmodalspin").hide();
            //              if (data[0].Error == 'Sucess') {
            //                  setTimeout(function () { window.location = "Login/''"}, 1000);                              
            //              }
        }
    }

    public DataTable Update_New_Pwd(string ls_euid, string password)
    {

        DataTable dt = new DataTable();
        DataSet DS = new DataSet();
        
        DataInsertReturn dtr = new DataInsertReturn();
        string ls_civilid = "";
        string ls_usertype = "";
        try
        {
            if (clsGeneral.GetQueryValue("select count(*) from MYA_Maleabna_Members where useruid='" + ls_euid + "'", GstrDbKey).Equals("0"))
            {
                dt = clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("Something went wrong. Unable to continue..."), 0);
                return dt;
            }
            ls_usertype = clsGeneral.GetQueryValue("select usertype from MYA_Maleabna_Members where  useruid='" + ls_euid + "'", GstrDbKey);

            ls_civilid = clsGeneral.GetQueryValue("select civilid from MYA_Maleabna_Members where  useruid='" + ls_euid + "'", GstrDbKey);

            string ePass = clsGeneral.ComputeHash(Server.HtmlEncode(password.Trim()), Server.HtmlEncode(ls_civilid), "SHA512", null);

            if (ls_usertype == "New")
            {
                dtr = clsGeneral.ExecuteNonQueryReturn("update MYA_Maleabna_Members set pwd='" + ePass + "' where useruid='" + ls_euid + "'", GstrDbKey);
                dtr = clsGeneral.ExecuteNonQueryReturn("update moyakwt_YouthMain.dbo.User_Basic_Info set pwd='" + ePass + "' where useruid='" + ls_euid + "'", GstrDbKey);
                dt = clsGeneral.msgResponse("", "Sucess", clsGeneral.GetSucTag("لقد تم تغيير كلمة المرور بنجاح ."), 0);
            }
            else if (ls_usertype == "Old")
            {
                dtr = clsGeneral.ExecuteNonQueryReturn("update MYA_Maleabna_Members set usertype='New',smsstatus=1,emailstatus=1,smscount=0, pwd='" + ePass + "' where useruid='" + ls_euid + "'", GstrDbKey);
                dtr = clsGeneral.ExecuteNonQueryReturn("update moyakwt_YouthMain.dbo.User_Basic_Info set pwd='" + ePass + "' where useruid='" + ls_euid + "'", GstrDbKey);
                dt = clsGeneral.msgResponse("", "Sucess", clsGeneral.GetSucTag("لقد تم تفعيل حسابك بنجاح ."), 0);
            }
            
        }
        catch (Exception ex)
        {
           dt = clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0);
        }
        finally
        {

        }
        return dt;

    }
}