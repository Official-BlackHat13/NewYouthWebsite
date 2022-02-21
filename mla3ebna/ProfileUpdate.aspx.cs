using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProfileUpdate : System.Web.UI.Page
{
    MGeneral clsGeneral = new MGeneral();
    string GstrDbKey = "MalebnaDB";

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            if (Session["UserUID"] != null)
            {
                string ls_euid = Session["UserUID"].ToString();
                Get_ProfileUpdateInfo(ls_euid);
              
            }

            else
            {
                Response.Redirect("Login.aspx");
            
            }

          //  divmodalmsg.InnerHtml = "hi";
        }
    }
    public void Get_ProfileUpdateInfo(String ls_euid)
    {

        DataTable dt = new DataTable();
        DataSet DS = new DataSet();
        string GstrDbKey = "MalebnaDB";
        General clsGeneral = new General();
        try
        {
            int userID = getUserid(ls_euid);

            DS = clsGeneral.GetDS("select GovernateID,AreaId,rtrim(gender) as gender,RefCivilId1,RefCivilId2,RefCivilId3,RefCivilId4,RefCivilId5 from MYA_Maleabna_Members where useruid= '" + userID + "'", GstrDbKey, "Table", true);

            if (DS.Tables[0].Rows.Count == 0)
                dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
            else
            {
                dt = DS.Tables[0];
                Get_MYA_Maleabna_GovernorateForReg();
              


            }
            //Context.Response.Write(js.Serialize(clsGeneral.GetJSon(dt)));
        }
        catch (Exception ex)
        {
           // Context.Response.Write(js.Serialize(clsGeneral.GetJSon(clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0))));
        }
        finally
        {

        }

    }
  
    public void Get_MYA_Maleabna_GovernorateForReg()
    {

        DataTable dt = new DataTable();
        DataSet DS = new DataSet();
        string GstrDbKey = "MalebnaDB";
        General clsGeneral = new General();
        try
        {

            DS = clsGeneral.GetDS("exec SP_Get_MYA_Maleabna_GovernorateForReg ", GstrDbKey, "Table", true);

            if (DS.Tables[0].Rows.Count == 0)
            {
                dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
            }
            else
            {
                dt = DS.Tables[0];

                ddlGov.DataSource = dt;
                ddlGov.DataTextField = "GovernorateName";
                ddlGov.DataValueField = "GovernorateID";
                ddlGov.DataBind();
                int val = int.Parse(ddlGov.SelectedValue);

                Get_MYA_Maleabna_AreaForReg(val);
            }
           
        }
        catch (Exception ex)
        {
           
        }
        finally
        {

        }

    }
    public void Get_MYA_Maleabna_AreaForReg(int li_govid)
    {

        DataTable dt = new DataTable();
        DataSet DS = new DataSet();
        string GstrDbKey = "MalebnaDB";
        General clsGeneral = new General();
        try
        {

            DS = clsGeneral.GetDS("exec SP_Get_MYA_Maleabna_AreaForReg " + li_govid, GstrDbKey, "Table", true);

            if (DS.Tables[0].Rows.Count == 0)
                dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
            else
            {
                dt = DS.Tables[0];

                ddlArea.DataSource = dt;
                ddlArea.DataTextField = "AreaName";
                ddlArea.DataValueField = "AreaID";
                ddlArea.DataBind();

            }


        }
        catch (Exception ex)
        {

        }
        finally
        {

        }

    }

    protected void ddlGov_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_MYA_Maleabna_AreaForReg(int.Parse(ddlGov.SelectedValue));
    }

    protected void ButtonClick(string type,int levl)
    {
        if (type == "Plus") {                   
                   if (levl == 1) {
                      //$scope.reg.civilID2 = "";
                      //$("#divciv2").show();
                      //$("#btnpl1").hide();

                      //$("#c2err").hide();
                      //$("#c2inv").hide();
                      //$("#c2suc").hide();
                      //$("#divmsgc2").hide();

                       txtSecondCivilID.Text = "";
                       divciv2.Visible = true;
                       lnkFirstPlus.Visible = false;
                      
                       c2err.Visible = false;
                       c2inv.Visible = false;
                       c2suc.Visible = false;
                       divmsgc2.Visible = false;

                   } else if (levl == 2) {
                      //$scope.reg.civilID3 = "";
                      //$("#divciv3").show();
                      //$("#btnpl2").hide();

                      //$("#c3err").hide();
                      //$("#c3inv").hide();
                      //$("#c3suc").hide();
                      //$("#divmsgc3").hide();
                       txtThirdCivilID.Text = "";
                       divciv3.Visible = true;
                       lnkSecondPlus.Visible = false;

                       c3err.Visible = false;
                       c3inv.Visible = false;
                       c3suc.Visible = false;
                       divmsgc3.Visible = false;


                   } else if (levl == 3) {
                      //$scope.reg.civilID4 = "";
                      //$("#divciv4").show();
                      //$("#btnpl3").hide();

                      //$("#c4err").hide();
                      //$("#c4inv").hide();
                      //$("#c4suc").hide();
                      //$("#divmsgc4").hide();

                       txtFourthCivilID.Text = "";
                       divciv4.Visible = true;
                       lnkThirdPlus.Visible = false;

                       c4err.Visible = false;
                       c4inv.Visible = false;
                       c4suc.Visible = false;
                       divmsgc4.Visible = false;


                   } else if (levl == 4) {
                      //$scope.reg.civilID5 = "";
                      //$("#divciv5").show();
                      //$("#btnpl4").hide();

                      //$("#c5err").hide();
                      //$("#c5inv").hide();
                      //$("#c5suc").hide();
                      //$("#divmsgc5").hide();

                       txtFifthCivilID.Text = "";
                       divciv5.Visible = true;
                       lnkFourthPlus.Visible = false;

                       c5err.Visible = false;
                       c5inv.Visible = false;
                       c5suc.Visible = false;
                       divmsgc5.Visible = false;
                   } 
               }
        else if (type == "Minus") {
            DataTable dt = new DataTable();  
                   if (levl == 2) {
                      //$scope.reg.civilID2 = "";
                      // scope.RemoveCivil(2);
                      //$("#divciv2").hide();
                      //$("#btnpl1").show();
                       
                       dt = Remove_Civil(levl, Session["UserUID"].ToString());
                       if (dt.Rows[0]["Error"].ToString().Trim() == "Sucess")
                       {
                           txtSecondCivilID.Text = "";
                           divciv2.Visible = false;
                           lnkFirstPlus.Visible = true;
                       }

                   } else if (levl == 3) {
                      //$scope.reg.civilID3 = "";
                      // scope.RemoveCivil(3);
                      //$("#divciv3").hide();
                      //$("#btnpl2").show();
                       dt = Remove_Civil(levl, Session["UserUID"].ToString());
                       if (dt.Rows[0]["Error"].ToString().Trim() == "Sucess")
                       {
                           txtThirdCivilID.Text = "";                           
                           divciv3.Visible = false;
                           lnkSecondPlus.Visible = true;
                       }

                   } else if (levl == 4) {
                      //$scope.reg.civilID4 = "";
                      // scope.RemoveCivil(4);
                      //$("#divciv4").hide();
                      //$("#btnpl3").show();

                       
                       dt = Remove_Civil(levl, Session["UserUID"].ToString());
                       if (dt.Rows[0]["Error"].ToString().Trim() == "Sucess")
                       {
                           txtFourthCivilID.Text = "";
                           divciv4.Visible = false;
                           lnkThirdPlus.Visible = true;
                       }
                   } else if (levl == 5) {
                      //$scope.reg.civilID5 = "";
                     //  scope.RemoveCivil(5);
                      //$("#divciv5").hide();
                      //$("#btnpl4").show();
                      
                       dt = Remove_Civil(levl, Session["UserUID"].ToString());
                       if (dt.Rows[0]["Error"].ToString().Trim() == "Sucess")
                       {
                           txtFifthCivilID.Text = "";
                           divciv5.Visible = false;
                           lnkFourthPlus.Visible = true;
                       }

                   } 
               }
    }
    protected void lnkFirstPlus_Click(object sender, EventArgs e)
    {
        ButtonClick("Plus", 1);
    }    
    protected void lnkSecondPlus_Click(object sender, EventArgs e)
    {
        ButtonClick("Plus", 2);
    }
    
    protected void lnkThirdPlus_Click(object sender, EventArgs e)
    {
        ButtonClick("Plus", 3);
    }
    protected void lnkFourthPlus_Click(object sender, EventArgs e)
    {
        ButtonClick("Plus", 4);
    }
   
    protected void lnkSecondMinus_Click(object sender, EventArgs e)
    {
        ButtonClick("Minus", 2);
    }
    protected void lnkThirdMinus_Click(object sender, EventArgs e)
    {
        ButtonClick("Minus", 3);
    }
    protected void lnkFourthMinus_Click(object sender, EventArgs e)
    {
        ButtonClick("Minus", 4);
    }
    protected void lnlFifthMinus_Click(object sender, EventArgs e)
    {
        ButtonClick("Minus", 5);
    }

    public DataTable Remove_Civil(int as_slno, string ls_euid)
    {

        DataTable dt = new DataTable();
        DataInsertReturn dtr = new DataInsertReturn();
        
      
        int li_userid;
        try
        {
            li_userid = getUserid(ls_euid);

            if (as_slno == 2)
            {
                dtr = clsGeneral.ExecuteNonQueryReturn("update MYA_Maleabna_Members set RefCivilId2='' where userid=" + li_userid, GstrDbKey);
            }
            else if (as_slno == 3)
            {
                dtr = clsGeneral.ExecuteNonQueryReturn("update MYA_Maleabna_Members set RefCivilId3='' where userid=" + li_userid, GstrDbKey);
            }
            else if (as_slno == 4)
            {
                dtr = clsGeneral.ExecuteNonQueryReturn("update MYA_Maleabna_Members set RefCivilId4='' where userid=" + li_userid, GstrDbKey);
            }
            else if (as_slno == 5)
            {
                dtr = clsGeneral.ExecuteNonQueryReturn("update MYA_Maleabna_Members set RefCivilId5='' where userid=" + li_userid, GstrDbKey);
            }
            if (dtr.DataInsert == true)
            {
               dt = clsGeneral.msgResponse("", "Sucess", dtr.ErrorMsg.Trim(), 0);
            }
            else
            {
                dt = clsGeneral.msgResponse("", "Fail", dtr.ErrorMsg.Trim(), 0);
            }

        }
        catch (Exception ex)
        {
            dt= clsGeneral.msgResponse("", "True", ex.Message.Trim(), 0);
        }
        finally
        {

        }
        return dt;
    }

    private int getUserid(string ls_eid)
    {
        int li_userid;
        li_userid = int.Parse(clsGeneral.GetQueryValue("select userid from MYA_Maleabna_Members where UserUID='" + ls_eid + "' and status=1", GstrDbKey));
        return li_userid;
    }
    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        Page.Validate("profileupdate");
        if (Page.IsValid)
        {
            divmodalspin.Visible = true;
            DataTable dt = new DataTable();
            int gov = int.Parse(ddlGov.SelectedValue.ToString());
            int area = int.Parse(ddlArea.SelectedValue.ToString());
            string gender = cmbGender.Value.ToString();
            string civil1 = txtFirstCivilID.Text.ToString();
            string civil2 = (divciv2.Visible?txtSecondCivilID.Text.ToString():string.Empty);
            string civil3 = (divciv3.Visible ? txtThirdCivilID.Text.ToString() : string.Empty);
            string civil4 = (divciv4.Visible ? txtFourthCivilID.Text.ToString() : string.Empty);
            string civil5 = (divciv5.Visible ? txtFifthCivilID.Text.ToString() : string.Empty);
            string userID = Session["UserUID"].ToString(); 
            dt =  UpdateProfile(gov,area,gender,civil1,civil2,civil3,civil4,civil5,userID);

            divmodalmsg.InnerHtml = dt.Rows[0]["message"].ToString();
            divmodalmsg.Visible = true;
            divmodalspin.Visible = false;

            if(dt.Rows[0]["message"].ToString().Trim() == "Insert Sucessfully")
            {
                CheckProfile("Update");
            }
            else if(dt.Rows[0]["Error"].ToString().Trim() == "True")
            {
                divmodalmsg.InnerHtml = dt.Rows[0]["message"].ToString();
                divmodalmsg.Visible = true;
                divmodalspin.Visible=false;
            }
            
            //$('#divmodalmsg').html(data[0].message);
            //           $('#divmodalmsg').show();
            //           $("#divmodalspin").hide();

                       //if (data[0].message === 'Insert Sucessfully') {                           
                       //    $scope.CheckProfile(ls_from);                           
                       //    //setTimeout(function () { window.location = "#Login/''"; }, 500);
                       //} else if (data[0].Error === 'True') {
                       //    $('#divmodalmsg').html(data[0].message);
                       //    $('#divmodalmsg').show();
                       //    $("#divmodalspin").hide();

                       //}
            string str = divmodalmsg.InnerHtml.ToString();
            
            
        }
    }

    protected DataTable UpdateProfile(int ls_govID, int ls_areaID, string ls_gender, string ls_civil1, string ls_civil2, string ls_civil3, string ls_civil4, string ls_civil5, string ls_euid)
    {

        DataTable dt = new DataTable();
        DataInsertReturn dtr = new DataInsertReturn();

        fnReturnCivilId dtrCivil = new fnReturnCivilId();
        int li_userid;
        try
        {
            li_userid = getUserid(ls_euid);

            if (!ls_civil1.Equals(""))
            {
                dtrCivil = clsGeneral.CheckCivilId(ls_civil1);
                if (dtrCivil.ValidCivil == false)
                {
                    dt = clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("الرقم المدني غير صالح "), 1);
                    return dt;
                }
            }

            if (!ls_civil2.Equals(""))
            {
                dtrCivil = clsGeneral.CheckCivilId(ls_civil2);
                if (dtrCivil.ValidCivil == false)
                {
                   dt = clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("الرقم المدني غير صالح "), 2);
                    return dt;
                }
            }

            if (!ls_civil3.Equals(""))
            {
                dtrCivil = clsGeneral.CheckCivilId(ls_civil3);
                if (dtrCivil.ValidCivil == false)
                {
                    dt = clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("الرقم المدني غير صالح "), 3);
                    return dt;
                }
            }


            if (!ls_civil4.Equals(""))
            {
                dtrCivil = clsGeneral.CheckCivilId(ls_civil4);
                if (dtrCivil.ValidCivil == false)
                {
                   dt = clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("الرقم المدني غير صالح "), 4);
                    return dt;
                }
            }

            if (!ls_civil5.Equals(""))
            {
                dtrCivil = clsGeneral.CheckCivilId(ls_civil5);
                if (dtrCivil.ValidCivil == false)
                {
                    dt = clsGeneral.msgResponse("", "True", clsGeneral.GetErrTag("الرقم المدني غير صالح "), 5);
                    return dt;
                }
            }





            dtr = clsGeneral.ExecuteNonQueryReturn("EXEC SP_UpdtaeProfile " + li_userid + "," + ls_govID + "," + ls_areaID + ",N'" + ls_gender + "',N'" + ls_civil1 + "',N'" + ls_civil2 + "',N'" + ls_civil3 + "',N'" + ls_civil4 + "',N'" + ls_civil5 + "'", GstrDbKey);
            if (dtr.DataInsert == true)
            {





                dt = clsGeneral.msgResponse("", "Sucess", dtr.ErrorMsg.Trim(), 0);

            }
            else
            {
                dt = clsGeneral.msgResponse("", "Fail", dtr.ErrorMsg.Trim(), 0);
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

     protected void CheckProfile(string ls_from)
     {
         DataTable dt = Get_CheckProfileInfo(Session["UserUID"].ToString());
         DataColumnCollection columns = dt.Columns;
         if (columns.Contains("message"))
         {

         }
         else
         {
             if (dt.Rows[0]["Status"].ToString() == "Approve") {
                           if (ls_from == "Update") {
                               Response.Redirect("Login.aspx",false);
                           } else if (ls_from == "Profile") {
                               divmodalmsg.InnerHtml = "'<div class='alert alert-info'><button type='button' class='close' data-dismiss='alert'><i class='ace-icon fa fa-times'></i></button><strong>Profile Updated Sucessfully.</strong> </div>')";
                               //$('#divmodalmsg').show();
                               divmodalmsg.Visible = true;
                               divmodalspin.Visible=false;
                           }
                       }
             else if (dt.Rows[0]["Status"].ToString() == "FinalCheck") {
                           divmodalmsg.InnerHtml = "'<div class='alert alert-danger'><button type='button' class='close' data-dismiss='alert'><i class='ace-icon fa fa-times'></i></button><strong>'" + dt.Rows[0]["ErrMsg"].ToString() + "'</strong> </div>')";
                           // $('#divmodalmsg').show();
                           divmodalmsg.Visible = true;
                            divmodalspin.Visible=false;
                       }
             else{
                           if (int.Parse(dt.Rows[0]["CivilDigits"].ToString()) != 12 || dt.Rows[0]["CivilValid"].ToString() == "Invalid" || dt.Rows[0]["CivilYourOwn"].ToString() == "Yes" || dt.Rows[0]["CivilValid"].ToString() == "Duplicate") {
                            
                               txtFirstCivilID.Focus();
                               c1err.Visible=true;
                               divmsgc1.InnerHtml = dt.Rows[0]["ErrMsg"].ToString();
                               divmsgc1.Visible=true;

                               c1inv.Visible=false;
                               c1suc.Visible=false;
                                //  $("#txtcivil1").focus();
                              // $('#divmsgc1').html(data[0].ErrMsg);
                              // $('#divmsgc1').show();
                           } 
                           else if (dt.Rows[0]["CivilNotFound"].ToString() == "Not Found") {
                               //$("#txtcivil1").focus();
                               //$('#c1inv').show();
                              // $('#divmsgc1').html(data[0].ErrMsg);
                              // $('#divmsgc1').show();

                                 txtFirstCivilID.Focus();
                                c1inv.Visible=true;
                                divmsgc1.InnerHtml = dt.Rows[0]["ErrMsg"].ToString();
                               divmsgc1.Visible=true;

                               c1suc.Visible=false;
                               c1err.Visible=false;
                           } 
                           else if ((dt.Rows[0]["CivilNotFound"].ToString() == "Found")) {
                               //$("#txtcivil1").focus();
                               //$('#c1suc').show();
                               txtFirstCivilID.Focus();
                               c1suc.Visible=true;

                               c1inv.Visible=false;
                               c1err.Visible=false;
                               divmsgc1.Visible=false;
                               divmsgc1.InnerHtml = "";
                           }


                           if ( int.Parse(dt.Rows[1]["CivilDigits"].ToString()) != 12 || dt.Rows[1]["CivilValid"].ToString() == "Invalid" || dt.Rows[1]["CivilYourOwn"].ToString() == "Yes" || dt.Rows[1]["CivilValid"].ToString() == "Duplicate") {
                               //$("#txtcivil2").focus();
                               //$('#c2err').show();
                               //$('#divmsgc2').html(data[1].ErrMsg);
                               //$('#divmsgc2').show();
                               txtSecondCivilID.Focus();
                               c2err.Visible=true;
                               divmsgc2.InnerHtml = dt.Rows[1]["ErrMsg"].ToString();
                               divmsgc2.Visible=true;

                               c2inv.Visible=false;  
                                c2suc.Visible=false;

                           } else if (dt.Rows[1]["CivilNotFound"].ToString() == "Not Found") {
                             //  $("#txtcivil2").focus();
                              // $('#c2inv').show();
                              // $('#divmsgc2').html(data[1].ErrMsg);
                              // $('#divmsgc2').show();


                                txtSecondCivilID.Focus();
                               c2inv.Visible=true;
                               divmsgc2.InnerHtml = dt.Rows[1]["ErrMsg"].ToString();
                               divmsgc2.Visible = true;                               

                               c2err.Visible=false;
                               c2suc.Visible=false;

                           } else if (dt.Rows[1]["CivilNotFound"].ToString() == "Found") {
                              // $("#txtcivil2").focus();
                              // $('#c2suc').show();

                               txtSecondCivilID.Focus();
                               c2suc.Visible=true;


                               c2err.Visible=false;
                                c2inv.Visible=false; 
                               divmsgc2.Visible=false;
                               divmsgc2.InnerHtml = "";
                           }


                           if ( int.Parse(dt.Rows[2]["CivilDigits"].ToString()) != 12 || dt.Rows[2]["CivilValid"].ToString() == "Invalid" || dt.Rows[2]["CivilYourOwn"].ToString() == "Yes" || dt.Rows[2]["CivilValid"].ToString() == "Duplicate") {
                               //$("#txtcivil3").focus();
                               //$('#c3err').show();
                               //$('#divmsgc3').html(data[2].ErrMsg);
                               //$('#divmsgc3').show();

                               txtThirdCivilID.Focus();
                               c3err.Visible=true;
                               divmsgc3.InnerHtml = dt.Rows[2]["ErrMsg"].ToString();
                               divmsgc3.Visible=true;

                               c3inv.Visible=false;
                               c3suc.Visible=false;

                           } else if (dt.Rows[2]["CivilNotFound"].ToString() == "Not Found") {
                               //$("#txtcivil3").focus();
                               //$('#c3inv').show();
                               //$('#divmsgc3').html(data[2].ErrMsg);
                               //$('#divmsgc3').show();

                                txtThirdCivilID.Focus();
                               c3inv.Visible=true;
                               divmsgc3.InnerHtml = dt.Rows[2]["ErrMsg"].ToString();
                               divmsgc3.Visible=true;

                               c3err.Visible=false;
                               c3suc.Visible=false;
                           } else if (dt.Rows[2]["CivilNotFound"].ToString() == "Found") {
                               //$("#txtcivil3").focus();
                               //$('#c3suc').show();
                               txtThirdCivilID.Focus();
                               c3suc.Visible=true;

                               c3inv.Visible=false;
                               divmsgc3.Visible=false;
                               c3err.Visible=false;
                               divmsgc3.InnerHtml = "";
                           }


                           if ( int.Parse(dt.Rows[3]["CivilDigits"].ToString()) != 12 || dt.Rows[3]["CivilValid"].ToString() == "Invalid" || dt.Rows[3]["CivilYourOwn"].ToString() == "Yes" || dt.Rows[3]["CivilValid"].ToString() == "Duplicate") {
                               //$("#txtcivil4").focus();
                               //$('#c4err').show();
                               //$('#divmsgc4').html(data[3].ErrMsg);
                               //$('#divmsgc4').show();

                               txtFourthCivilID.Focus();
                               c4err.Visible=true;
                               divmsgc4.InnerHtml=dt.Rows[3]["ErrMsg"].ToString();
                               divmsgc4.Visible=true;

                               c4inv.Visible=false;
                               c4suc.Visible=false;

                           } else if (dt.Rows[3]["CivilNotFound"].ToString() == "Not Found") {
                               //$("#txtcivil4").focus();
                               //$('#c4inv').show();
                               //$('#divmsgc4').html(data[3].ErrMsg);
                               //$('#divmsgc4').show();

                               txtFourthCivilID.Focus();
                               c4inv.Visible=true;
                               divmsgc4.InnerHtml=dt.Rows[3]["ErrMsg"].ToString();
                               divmsgc4.Visible=true;

                               c4err.Visible=false;
                               c4suc.Visible=false;
                           } 
                           else if (dt.Rows[3]["CivilNotFound"].ToString() == "Found") {
                               //$("#txtcivil4").focus();
                               //$('#c4suc').show();
                                txtFourthCivilID.Focus();
                               c4suc.Visible=true;

                               c4inv.Visible=false;
                               c4err.Visible=false;
                               divmsgc4.InnerHtml="";
                               divmsgc4.Visible=false;
                           }


                           if (int.Parse(dt.Rows[4]["CivilDigits"].ToString()) != 12 ||dt.Rows[4]["CivilValid"].ToString() == "Invalid" || dt.Rows[4]["CivilYourOwn"].ToString() == "Yes" ||dt.Rows[4]["CivilValid"].ToString() == "Duplicate") {
                               //$("#txtcivil5").focus();
                               //$('#c5err').show();
                               //$('#divmsgc5').html(data[4].ErrMsg);
                               //$('#divmsgc5').show();


                               txtFifthCivilID.Focus();
                               c5err.Visible=true;
                               divmsgc5.InnerHtml = dt.Rows[4]["ErrMsg"].ToString();
                               divmsgc5.Visible=true;

                               c5inv.Visible=false;
                               c5suc.Visible=false;

                           } else if (dt.Rows[4]["CivilNotFound"].ToString() == "Not Found") {
                               //$("#txtcivil5").focus();
                               //$('#c5inv').show();
                               //$('#divmsgc5').html(data[4].ErrMsg);
                               //$('#divmsgc5').show();
                               txtFifthCivilID.Focus();
                              c5inv.Visible=true;
                                divmsgc5.InnerHtml = dt.Rows[4]["ErrMsg"].ToString();
                               divmsgc5.Visible=true;

                                c5err.Visible=false;
                                c5suc.Visible=false;
                               
                           } else if (dt.Rows[4]["CivilNotFound"].ToString() == "Found") {
                               //$("#txtcivil5").focus();
                               //$('#c5suc').show();
                               txtFifthCivilID.Focus();
                               c5suc.Visible=true;

                               c5err.Visible=false;
                               c5inv.Visible=false;
                                divmsgc5.InnerHtml = "";
                               divmsgc5.Visible=false;
                           }
                       }



                       //$scope.$apply();
                       //$('#divmodalspin').hide(0)
             divmodalspin.Visible=false;

         }

     }

     public DataTable  Get_CheckProfileInfo(String ls_euid)
        {

            DataTable dt = new DataTable();
            DataSet DS = new DataSet();
            
            int li_userid;
            try
            {
                li_userid = getUserid(ls_euid);


                DS = clsGeneral.GetDS("exec SP_CheckProfileUpdate " + li_userid, GstrDbKey, "Table", true);

                if (DS.Tables[0].Rows.Count == 0)
                    dt = clsGeneral.msgResponse("", "True", "NO ITEMS FOUND", 0);
                else
                    dt = DS.Tables[0];
               
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

     protected void lnkSendmail_Click(object sender, EventArgs e)
     {
         Validate("email");
         if (Page.IsValid)
         {
             DataTable dt = fn_SendEmailProfileUpdate(Session["UserUID"].ToString(), txtfriendEmail.Text);
             string msg = dt.Rows[0]["message"].ToString();
             if (msg == "Insert Sucessfully")
             {
                 divmodalmsgmodal.InnerHtml = "<div class='alert alert-info'><button type='button' class='close' data-dismiss='alert'><i class='ace-icon fa fa-times'></i></button><strong>Email Send Sucessfully. </strong> </div>'";
                 divmodalmsgmodal.Visible = true;
             }
             else
             {
                 divmodalmsgmodal.InnerHtml = msg;
                 divmodalmsgmodal.Visible = true;
             }

             divmodalspinmodal.Attributes.Add("style", "display:none;");            
         }
     }

     public DataTable fn_SendEmailProfileUpdate(string ls_euid, String ls_sendemail)
     {
         Object obj;
         string ls_body;
         DataInsertReturn dtr = new DataInsertReturn();
         DataTable dt = new DataTable();

         int li_userid;
         string ls_username;

         li_userid = getUserid(ls_euid);
         //clsGeneral.ExecuteNonQuery("insert into MYA_Maleabna_ContactUs (Name,Email,Msg) values(N'" + ls_name + "','" + ls_email + "',N'" + ls_msg + "')", GstrDbKey);
         ls_username = clsGeneral.GetQueryValue("select name from MYA_Maleabna_Members where UserUID='" + li_userid + "'", GstrDbKey);


         ls_body = PopulateBodyProfileUpdate(ls_username, "https://mubaratna.com/Register.aspx");

         dtr = SendEmail(ls_sendemail, ls_body, "Register Mubaratna");
         if (dtr.DataInsert == true)
         {
            dt = clsGeneral.msgResponse("", "Sucess", dtr.ErrorMsg.Trim(), 0);
            return dt;
         }
         else
         {
             dt = clsGeneral.msgResponse("", "Fail", dtr.ErrorMsg.Trim(), 0);
             return dt;
         }
     }

     private string PopulateBodyProfileUpdate(string ls_username, string ls_link)
     {
         string body = string.Empty;
         StreamReader reader = new StreamReader(Server.MapPath("~/emailProfileUpdate.html"));
         body = reader.ReadToEnd();

         body = body.Replace("{User}", ls_username);
         body = body.Replace("{link}", ls_link);

         return body;
     }
     public DataInsertReturn SendEmail(string emailid, string ls_body, string ls_Subject)
     {
         string rtString;
         rtString = "";
         string email = emailid;
         DataInsertReturn dtr = new DataInsertReturn();
         dtr.DataInsert = true;
         if (!email.Equals(""))
         {
             System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
             message.From = new MailAddress("web@youth.gov.kw", "Mubaratna");
             message.To.Add(new MailAddress(email));
             message.Subject = ls_Subject;
             message.CC.Add(new MailAddress("web@youth.gov.kw"));
             message.IsBodyHtml = true;

             message.Body = ls_body;

             SmtpClient smtpClient = new SmtpClient();
             smtpClient.UseDefaultCredentials = false;

             smtpClient.Credentials = new System.Net.NetworkCredential("web@youth.gov.kw", "Top@A147258");

             smtpClient.Port = 587;
             smtpClient.Host = "smtp.office365.com";
             smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
             smtpClient.EnableSsl = true;
             try
             {
                // smtpClient.Send(message);
                 //smtpClient = null/* TODO Change to default(_) if this is not a reference type */;

                 dtr.ErrorMsg = "Insert Sucessfully";

                 return dtr;
             }

             // rtString = "Email Send Successfully."
             catch (Exception ex)
             {
                 dtr.DataInsert = false;
                 dtr.ErrorMsg = ex.Message;
                 return dtr;
             }

         }
         return dtr;
     }
   
}