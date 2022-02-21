using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewInitiative_ViewInitiativeMasterPage : System.Web.UI.MasterPage
{
    public string strMenu, strMobileMenu;
    protected void Page_Load(object sender, EventArgs e)
    {

        ViewInitiativeAppCurrentUser.CheckLoggedIn();


        
       // lblMessage.Text = Session["MYAPIVIAppName"].ToString();
        lblMobileMessage.Text = Session["MYAPIVIAppName"].ToString();
        lblTopMessage.Text = "Welcome " + Session["MYAPIVIAppName"].ToString();

        labUserFullNameLeft.Text = Session["MYAPIVIAppName"].ToString();
        labUserInstitutionLeft.Text = GetInstitutionName(Session["MYAPIVIAppInstitution"].ToString());

        labUserFullNameLeftPopup.Text = Session["MYAPIVIAppName"].ToString();
        labUserInstitutionLeftPopup.Text = GetInstitutionName(Session["MYAPIVIAppInstitution"].ToString());

        fillMobileMenu();

        fillMenu();

    }

    public string GetInstitutionName(string s)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";

        cmd = "select * from [MYA_PI_Institutions]  where id=" + s + " order by id desc";
        dt = dbFunctions_YPI.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["NameAR"]))
            {
                strresult = dt.Rows[0]["NameAR"].ToString();
            }

        }


        return strresult;
    }

    private void fillMobileMenu()
    {
        strMobileMenu = strMobileMenu + "<li class=''><a href='Default.aspx'><div class='icon-w'><div class='fa fa-home'></div></div><span>الرئيسية</span></a></li>";

        if (Session["MYAPIVIAppUsers"].ToString() == "True")
        {
            strMobileMenu = strMobileMenu + "<li class='has-sub-menu'> <a href='Manage_AppUsers'><div class='icon-w'><div class='os-icon os-icon-user-male-circle2'></div></div>";
            strMobileMenu = strMobileMenu + " <span>فريق العمل</span></a>";
            strMobileMenu = strMobileMenu + " <ul class='sub-menu'>";

            strMobileMenu = strMobileMenu + " <li><a href='Create_AppUsers.aspx'>إضافة</a></li>";
            strMobileMenu = strMobileMenu + " <li><a href='Manage_AppUsers.aspx'>تعديل</a></li>";
        }

        strMobileMenu = strMobileMenu + " </ul>";
        strMobileMenu = strMobileMenu + " </li>";

        if (Session["MYAPIVIAppBusinessNursery"].ToString() == "True")
        {
            strMobileMenu = strMobileMenu + "<li class=''><a href='Manage_BusinessNursery.aspx'><div class='icon-w'><div class='fa fa-building'></div></div><span>حاضنة الأعمال</span></a></li>";
        }

        if (Session["MYAPIVIAppSettings"].ToString() == "True")
        {

        }

        if (Session["MYAPIVIAppInitiative"].ToString() == "True")
        {
            strMobileMenu = strMobileMenu + "<li class=''><a href='Search_Initiative.aspx'><div class='icon-w'><div class='fa fa-th-list'></div></div><span>المبادر المحترف</span></a></li>";
        }


    }

    private void fillMenu()
    {
        if (Request.Url.ToString().IndexOf("Default.aspx") != -1 | Request.Url.ToString().IndexOf("default.aspx") != -1)
        {
            strMenu = strMenu + " <li class='selected'><a href='Default.aspx'><div class='icon-w'><div class='fa fa-home'></div> </div><span>الرئيسية</span></a> </li>";
        }
        else
        {
            strMenu = strMenu + " <li class=''><a href='Default.aspx'><div class='icon-w'><div class='fa fa-home'></div> </div><span>الرئيسية</span></a> </li>";
        }



        if (Session["MYAPIVIAppUsers"].ToString() == "True")
        {
            strMenu = strMenu + "<li class='sub-header'> <span>فريق العمل</span></li>";

            if (Request.Url.ToString().IndexOf("Create_AppUsers.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_AppUsers.aspx") != -1)
            {
                strMenu = strMenu + "<li class='has-sub-menu'><a href='#'><div class='icon-w'> <div class='os-icon os-icon-user-male-circle2'></div></div><span>فريق العمل</span></a>";

                strMenu = strMenu + "  <div class='sub-menu-w'><div class='sub-menu-header'>فريق العمل</div> <div class='sub-menu-icon'><div class='os-icon os-icon-user-male-circle2'></div> </div>";
                strMenu = strMenu + "<div class='sub-menu-i'>";

                strMenu = strMenu + "<ul class='sub-menu'>";

                strMenu = strMenu + " <li><a href='Create_AppUsers.aspx'>إضافة</a></li>";
                strMenu = strMenu + " <li><a href='Manage_AppUsers.aspx'>تعديل</a></li>";

                strMenu = strMenu + "</ul>";

                strMenu = strMenu + "</div>";
                strMenu = strMenu + "</div>";

                strMenu = strMenu + " </li>";
            }
            else
            {
                strMenu = strMenu + "<li class='has-sub-menu'><a href='#'><div class='icon-w'> <div class='os-icon os-icon-user-male-circle2'></div></div><span>فريق العمل</span></a>";

                strMenu = strMenu + "  <div class='sub-menu-w'><div class='sub-menu-header'>فريق العمل</div> <div class='sub-menu-icon'><div class='os-icon os-icon-user-male-circle2'></div> </div>";
                strMenu = strMenu + "<div class='sub-menu-i'>";

                strMenu = strMenu + "<ul class='sub-menu'>";

                strMenu = strMenu + " <li><a href='Create_AppUsers.aspx'>إضافة</a></li>";
                strMenu = strMenu + " <li><a href='Manage_AppUsers.aspx'>تعديل</a></li>";

                strMenu = strMenu + "</ul>";

                strMenu = strMenu + "</div>";
                strMenu = strMenu + "</div>";

                strMenu = strMenu + " </li>";

                //  strMenu = strMenu + "<li class=''><a href='Add_Mod_Settings.aspx'><div class='icon-w'><i class='fa fa-cog' aria-hidden='true'></i></div> <span>Settings </span></a></li>";
            }
        }

        if (Session["MYAPIVIAppBusinessNursery"].ToString() == "True")
        {
            strMenu = strMenu + "<li class='sub-header'> <span>حاضنة الأعمال</span></li>";

            if (Request.Url.ToString().IndexOf("Create_BusinessNursery.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_BusinessNursery.aspx") != -1)
            {
                strMenu = strMenu + "<li class='has-sub-menu'><a href='#'><div class='icon-w'> <div class='fa fa-building'></div></div><span>حاضنة الأعمال</span></a>";

                strMenu = strMenu + "  <div class='sub-menu-w'><div class='sub-menu-header'>حاضنة الأعمال</div> <div class='sub-menu-icon'><div class='os-icon os-icon-user-male-circle2'></div> </div>";
                strMenu = strMenu + "<div class='sub-menu-i'>";

                strMenu = strMenu + "<ul class='sub-menu'>";

                strMenu = strMenu + " <li><a href='Create_BusinessNursery.aspx'>إضافة</a></li>";
                strMenu = strMenu + " <li><a href='Manage_BusinessNursery.aspx'>تعديل</a></li>";

                strMenu = strMenu + "</ul>";

                strMenu = strMenu + "</div>";
                strMenu = strMenu + "</div>";

                strMenu = strMenu + " </li>";
            }
            else
            {
                strMenu = strMenu + "<li class='has-sub-menu'><a href='#'><div class='icon-w'> <div class='fa fa-building'></div></div><span>حاضنة الأعمال</span></a>";

                strMenu = strMenu + "  <div class='sub-menu-w'><div class='sub-menu-header'>حاضنة الأعمال</div> <div class='sub-menu-icon'><div class='os-icon os-icon-user-male-circle2'></div> </div>";
                strMenu = strMenu + "<div class='sub-menu-i'>";

                strMenu = strMenu + "<ul class='sub-menu'>";

                strMenu = strMenu + " <li><a href='Create_BusinessNursery.aspx'>إضافة</a></li>";
                strMenu = strMenu + " <li><a href='Manage_BusinessNursery.aspx'>تعديل</a></li>";

                strMenu = strMenu + "</ul>";

                strMenu = strMenu + "</div>";
                strMenu = strMenu + "</div>";

                strMenu = strMenu + " </li>";

                //  strMenu = strMenu + "<li class=''><a href='Add_Mod_Settings.aspx'><div class='icon-w'><i class='fa fa-cog' aria-hidden='true'></i></div> <span>Settings </span></a></li>";
            }
        }


        if (Session["MYAPIVIAppSettings"].ToString() == "True")
        {
            strMenu = strMenu + "<li class='sub-header'> <span>الاعدادات</span></li>";

            if (Request.Url.ToString().IndexOf("Manage_Type.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_Category.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_EducationQualification.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_Status.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_Stage.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_IntroductionText.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_SuspendedActivities.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_TermsConditionsText.aspx") != -1)
            {
                strMenu = strMenu + "<li class='sub-header'> <span>الاعدادات</span></li>";

                strMenu = strMenu + "<li class='has-sub-menu'><a href='#'><div class='icon-w'> <div class='fa fa-cog'></div></div><span>الاعدادات</span></a>";

                strMenu = strMenu + "  <div class='sub-menu-w'><div class='sub-menu-header'>الاعدادات</div> <div class='sub-menu-icon'><div class='os-icon os-icon-user-male-circle2'></div> </div>";
                strMenu = strMenu + "<div class='sub-menu-i'>";

                strMenu = strMenu + "<ul class='sub-menu'>";


                strMenu = strMenu + " <li><a href='Manage_Type.aspx'>مقدم الطلب</a></li>";
                strMenu = strMenu + " <li><a href='Manage_Category.aspx'>المجال</a></li>";
                strMenu = strMenu + " <li><a href='Manage_EducationQualification.aspx'>المؤهل الدراسي</a></li>";
                strMenu = strMenu + " <li><a href='Manage_Status.aspx'>الحالة</a></li>";
                strMenu = strMenu + " <li><a href='Manage_Stage.aspx'>Stage</a></li>";
                strMenu = strMenu + "</ul>";

                strMenu = strMenu + "<ul class='sub-menu'>";
                strMenu = strMenu + " <li><a href='Manage_UserGroup.aspx'>User Group</a></li>";
                strMenu = strMenu + " <li><a href='Manage_UserGroupPermission.aspx'>User Group Permission</a></li>";
                strMenu = strMenu + " <li><a href='Manage_IntroductionText.aspx'>Introduction Text</a></li>";
                strMenu = strMenu + " <li><a href='Manage_SuspendedActivities.aspx'>الأنشطة الموقوفة</a></li>";
                strMenu = strMenu + " <li><a href='Manage_TermsConditionsText.aspx'>الشروط و الاحكام</a></li>";

                strMenu = strMenu + "</ul>";


                strMenu = strMenu + "</div>";
                strMenu = strMenu + "</div>";

                strMenu = strMenu + " </li>";
            }
            else
            {
                strMenu = strMenu + "<li class='has-sub-menu'><a href='#'><div class='icon-w'> <div class='fa fa-cog'></div></div><span>الاعدادات</span></a>";

                strMenu = strMenu + "  <div class='sub-menu-w'><div class='sub-menu-header'>الاعدادات</div> <div class='sub-menu-icon'><div class='fa fa-cog'></div> </div>";
                strMenu = strMenu + "<div class='sub-menu-i'>";

                strMenu = strMenu + "<ul class='sub-menu'>";
                
                strMenu = strMenu + " <li><a href='Manage_Type.aspx'>مقدم الطلب</a></li>";
                strMenu = strMenu + " <li><a href='Manage_Category.aspx'>المجال</a></li>";
                strMenu = strMenu + " <li><a href='Manage_EducationQualification.aspx'>المؤهل الدراسي</a></li>";
                strMenu = strMenu + " <li><a href='Manage_Status.aspx'>الحالة</a></li>";
                strMenu = strMenu + " <li><a href='Manage_Stage.aspx'>Stage</a></li>";
                strMenu = strMenu + "</ul>";

                strMenu = strMenu + "<ul class='sub-menu'>";

                strMenu = strMenu + " <li><a href='Manage_UserGroup.aspx'>User Group</a></li>";
                strMenu = strMenu + " <li><a href='Manage_UserGroupPermission.aspx'>User Group Permission</a></li>";
                strMenu = strMenu + " <li><a href='Manage_IntroductionText.aspx'>Introduction Text</a></li>";
                strMenu = strMenu + " <li><a href='Manage_SuspendedActivities.aspx'>الأنشطة الموقوفة</a></li>";
                strMenu = strMenu + " <li><a href='Manage_TermsConditionsText.aspx'>الشروط و الاحكام</a></li>";
                strMenu = strMenu + "</ul>";

                strMenu = strMenu + "</div>";
                strMenu = strMenu + "</div>";

                strMenu = strMenu + " </li>";


            }
        }

        //if (Session["MYAPIVIAppSettings"].ToString() == "True")
        //{
        //    strMenu = strMenu + "<li class='sub-header'> <span>الاعدادات</span></li>";

        //    if (Request.Url.ToString().IndexOf("Create_AppUsers.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_AppUsers.aspx") != -1)
        //    {
        //        strMenu = strMenu + "<li class='has-sub-menu'><a href='#'><div class='icon-w'> <div class='os-icon os-icon-user-male-circle2'></div></div><span>فريق العمل</span></a>";

        //        strMenu = strMenu + "  <div class='sub-menu-w'><div class='sub-menu-header'>فريق العمل</div> <div class='sub-menu-icon'><div class='os-icon os-icon-user-male-circle2'></div> </div>";
        //        strMenu = strMenu + "<div class='sub-menu-i'>";

        //        strMenu = strMenu + "<ul class='sub-menu'>";

        //        strMenu = strMenu + " <li><a href='Create_AppUsers.aspx'>إضافة</a></li>";
        //        strMenu = strMenu + " <li><a href='Manage_AppUsers.aspx'>تعديل</a></li>";

        //        strMenu = strMenu + "</ul>";

        //        strMenu = strMenu + "</div>";
        //        strMenu = strMenu + "</div>";

        //        strMenu = strMenu + " </li>";
        //    }
        //    else
        //    {
        //        strMenu = strMenu + "<li class='has-sub-menu'><a href='#'><div class='icon-w'> <div class='os-icon os-icon-user-male-circle2'></div></div><span>فريق العمل</span></a>";

        //        strMenu = strMenu + "  <div class='sub-menu-w'><div class='sub-menu-header'>فريق العمل</div> <div class='sub-menu-icon'><div class='os-icon os-icon-user-male-circle2'></div> </div>";
        //        strMenu = strMenu + "<div class='sub-menu-i'>";

        //        strMenu = strMenu + "<ul class='sub-menu'>";

        //        strMenu = strMenu + " <li><a href='Create_AppUsers.aspx'>إضافة</a></li>";
        //        strMenu = strMenu + " <li><a href='Manage_AppUsers.aspx'>تعديل</a></li>";

        //        strMenu = strMenu + "</ul>";

        //        strMenu = strMenu + "</div>";
        //        strMenu = strMenu + "</div>";

        //        strMenu = strMenu + " </li>";

        //        //  strMenu = strMenu + "<li class=''><a href='Add_Mod_Settings.aspx'><div class='icon-w'><i class='fa fa-cog' aria-hidden='true'></i></div> <span>Settings </span></a></li>";
        //    }


        //    if (Request.Url.ToString().IndexOf("Manage_Category.aspx") != -1)
        //    {
        //        strMenu = strMenu + " <li class='selected'><a href='Manage_Category.aspx'><div class='icon-w'><div class='fa fa-filter'></div> </div><span> الفئة</span></a> </li>";
        //    }
        //    else
        //    {
        //        strMenu = strMenu + " <li class=''><a href='Manage_Category.aspx'><div class='icon-w'><div class='fa fa-filter'></div> </div><span> الفئة </span></a> </li>";
        //    }

        //    if (Request.Url.ToString().IndexOf("Manage_Status.aspx") != -1)
        //    {
        //        strMenu = strMenu + " <li class='selected'><a href='Manage_Status.aspx'><div class='icon-w'><div class='fa fa-filter'></div> </div><span>الحالة</span></a> </li>";
        //    }
        //    else
        //    {
        //        strMenu = strMenu + " <li class=''><a href='Manage_Status.aspx'><div class='icon-w'><div class='fa fa-filter'></div> </div><span>الحالة</span></a> </li>";
        //    }

        //    if (Request.Url.ToString().IndexOf("Manage_Institutions.aspx") != -1)
        //    {
        //        strMenu = strMenu + " <li class='selected'><a href='Manage_Institutions.aspx'><div class='icon-w'><div class='fa fa-filter'></div> </div><span>Institutions</span></a> </li>";
        //    }
        //    else
        //    {
        //        strMenu = strMenu + " <li class=''><a href='Manage_Institutions.aspx'><div class='icon-w'><div class='fa fa-filter'></div> </div><span>Institutions</span></a> </li>";
        //    }

        //    if (Request.Url.ToString().IndexOf("Manage_Stage.aspx") != -1)
        //    {
        //        strMenu = strMenu + " <li class='selected'><a href='Manage_Stage.aspx'><div class='icon-w'><div class='fa fa-filter'></div> </div><span>Stage</span></a> </li>";
        //    }
        //    else
        //    {
        //        strMenu = strMenu + " <li class=''><a href='Manage_Stage.aspx'><div class='icon-w'><div class='fa fa-filter'></div> </div><span>Stage</span></a> </li>";
        //    }
        //}


        if (Session["MYAPIVIAppInitiative"].ToString() == "True")
        {

            strMenu = strMenu + "<li class='sub-header'> <span>المبادر المحترف</span></li>";

            if (Request.Url.ToString().IndexOf("Search_Initiative.aspx") != -1)
            {
                strMenu = strMenu + " <li class='selected'><a href='Search_Initiative.aspx'><div class='icon-w'><div class='fa fa-th-list'></div> </div><span>بحث المبادر المحترف</span></a> </li>";
            }
            else
            {
                strMenu = strMenu + " <li class=''><a href='Search_Initiative.aspx'><div class='icon-w'><div class='fa fa-list-ul'></div> </div><span>بحث المبادر المحترف</span></a> </li>";
            }

            strMenu = strMenu + "<li class='sub-header'> <span>Export Excel</span></li>";

            if (Request.Url.ToString().IndexOf("ExportToExcel.aspx") != -1)
            {
                strMenu = strMenu + " <li class='selected'><a href='ExportToExcel.aspx'><div class='icon-w'><div class='fa fa-th-list'></div> </div><span>Export Excel</span></a> </li>";
            }
            else
            {
                strMenu = strMenu + " <li class=''><a href='ExportToExcel.aspx'><div class='icon-w'><div class='fa fa-list-ul'></div> </div><span>Export Excel</span></a> </li>";
            }

        }

    }
}
