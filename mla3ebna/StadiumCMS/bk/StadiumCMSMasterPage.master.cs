using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StadiumCMS_StadiumCMSMasterPage : System.Web.UI.MasterPage
{
    public string strMenu, strMobileMenu;
    protected void Page_Load(object sender, EventArgs e)
    {
        CMSCurrentUser.CheckLoggedIn();



        // lblMessage.Text = Session["MYAPIVIAppName"].ToString();
        lblMobileMessage.Text = Session["MaleabnaCMSName"].ToString();
        lblTopMessage.Text = "Welcome " + Session["MaleabnaCMSName"].ToString();

        labUserFullNameLeft.Text = Session["MaleabnaCMSName"].ToString();
        //labUserInstitutionLeft.Text = GetInstitutionName(Session["MYAPIVIAppInstitution"].ToString());

        labUserFullNameLeftPopup.Text = Session["MaleabnaCMSName"].ToString();
        //labUserInstitutionLeftPopup.Text = GetInstitutionName(Session["MYAPIVIAppInstitution"].ToString());

        fillMobileMenu();

        fillMenu();
    }

    private void fillMobileMenu()
    {
        strMobileMenu = strMobileMenu + "<li class=''><a href='Default.aspx'><div class='icon-w'><div class='fa fa-home'></div></div><span>الرئيسية</span></a></li>";

        if (Session["MaleabnaCMSUsersMenu"].ToString() == "True")
        {
            strMobileMenu = strMobileMenu + "<li class='has-sub-menu'> <a href='Manage_AppUsers'><div class='icon-w'><div class='os-icon os-icon-user-male-circle2'></div></div>";
            strMobileMenu = strMobileMenu + " <span>فريق العمل</span></a>";
            strMobileMenu = strMobileMenu + " <ul class='sub-menu'>";

            strMobileMenu = strMobileMenu + " <li><a href='Create_AppUsers.aspx'>إضافة</a></li>";
            strMobileMenu = strMobileMenu + " <li><a href='Manage_AppUsers.aspx'>تعديل</a></li>";
        }

        strMobileMenu = strMobileMenu + " </ul>";
        strMobileMenu = strMobileMenu + " </li>";
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

        if (Session["MaleabnaCMSUsersMenu"].ToString() == "True")
        {
            //strMenu = strMenu + "<li class='sub-header'> <span>فريق العمل</span></li>";
            if (Request.Url.ToString().IndexOf("Create_CMSUsers.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_CMSUsers.aspx") != -1)
            {
                strMenu = strMenu + " <li class='selected'><a href='Manage_CMSUsers.aspx'><div class='icon-w'><div class='os-icon os-icon-user-male-circle2'></div> </div><span>فريق العمل</span></a> </li>";
            }
            else
            {
                strMenu = strMenu + " <li class=''><a href='Manage_CMSUsers.aspx'><div class='icon-w'><div class='os-icon os-icon-user-male-circle2'></div> </div><span>فريق العمل</span></a> </li>";
            }
            //if (Request.Url.ToString().IndexOf("Create_CMSUsers.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_CMSUsers.aspx") != -1)
            //{
            //    strMenu = strMenu + "<li class='has-sub-menu'><a href='#'><div class='icon-w'> <div class='os-icon os-icon-user-male-circle2'></div></div><span>فريق العمل</span></a>";

            //    strMenu = strMenu + "  <div class='sub-menu-w'><div class='sub-menu-header'>فريق العمل</div> <div class='sub-menu-icon'><div class='os-icon os-icon-user-male-circle2'></div> </div>";
            //    strMenu = strMenu + "<div class='sub-menu-i'>";

            //    strMenu = strMenu + "<ul class='sub-menu'>";

            //    strMenu = strMenu + " <li><a href='Create_CMSUsers.aspx'>إضافة</a></li>";
            //    strMenu = strMenu + " <li><a href='Manage_CMSUsers.aspx'>تعديل</a></li>";

            //    strMenu = strMenu + "</ul>";

            //    strMenu = strMenu + "</div>";
            //    strMenu = strMenu + "</div>";

            //    strMenu = strMenu + " </li>";
            //}
            //else
            //{
            //    strMenu = strMenu + "<li class='has-sub-menu'><a href='#'><div class='icon-w'> <div class='os-icon os-icon-users'></div></div><span>فريق العمل</span></a>";

            //    strMenu = strMenu + "  <div class='sub-menu-w'><div class='sub-menu-header'>فريق العمل</div> <div class='sub-menu-icon'><div class='os-icon os-icon-users'></div> </div>";
            //    strMenu = strMenu + "<div class='sub-menu-i'>";

            //    strMenu = strMenu + "<ul class='sub-menu'>";

            //    strMenu = strMenu + " <li><a href='Create_CMSUsers.aspx'>إضافة</a></li>";
            //    strMenu = strMenu + " <li><a href='Manage_CMSUsers.aspx'>تعديل</a></li>";

            //    strMenu = strMenu + "</ul>";

            //    strMenu = strMenu + "</div>";
            //    strMenu = strMenu + "</div>";

            //    strMenu = strMenu + " </li>";

            //    //  strMenu = strMenu + "<li class=''><a href='Add_Mod_Settings.aspx'><div class='icon-w'><i class='fa fa-cog' aria-hidden='true'></i></div> <span>Settings </span></a></li>";
            //}
        }


        if (Session["MaleabnaCMSSettingsMenu"].ToString() == "True")
        {
            // strMenu = strMenu + "<li class='sub-header'> <span>الاعدادات</span></li>";

            if (Request.Url.ToString().IndexOf("Manage_Governorate.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_Area.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_School.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_Stadium.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_Guard.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_PageContent.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_SuspendedActivities.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_TermsConditionsText.aspx") != -1)
            {
               // strMenu = strMenu + "<li class='sub-header'> <span>الاعدادات</span></li>";

                strMenu = strMenu + "<li class='has-sub-menu'><a href='#'><div class='icon-w'> <div class='fa fa-cog'></div></div><span>الاعدادات</span></a>";

                strMenu = strMenu + "  <div class='sub-menu-w'><div class='sub-menu-header'>الاعدادات</div> <div class='sub-menu-icon'><div class='os-icon os-icon-user-male-circle2'></div> </div>";
                strMenu = strMenu + "<div class='sub-menu-i'>";

                strMenu = strMenu + "<ul class='sub-menu'>";


                strMenu = strMenu + " <li><a href='Manage_Governorate.aspx'>المحافظة</a></li>";
                strMenu = strMenu + " <li><a href='Manage_Area.aspx'>المنطقة</a></li>";
               // strMenu = strMenu + " <li><a href='Manage_School.aspx'>School</a></li>";
                strMenu = strMenu + " <li><a href='Manage_Guard.aspx'>Guard</a></li>";
                strMenu = strMenu + "</ul>";

                strMenu = strMenu + "<ul class='sub-menu'>";

                strMenu = strMenu + " <li><a href='ViewTimeSlot.aspx'>Time Slot</a></li>";
                //strMenu = strMenu + " <li><a href='Manage_SpecialTimeSlot.aspx'>Special Time Slot</a></li>";
                //strMenu = strMenu + " <li><a href='Manage_StadiumWiseTimeSlot.aspx'>Stadium Wise Time Slot</a></li>";

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

                strMenu = strMenu + " <li><a href='Manage_Governorate.aspx'>المحافظة</a></li>";
                strMenu = strMenu + " <li><a href='Manage_Area.aspx'>المنطقة</a></li>";
               // strMenu = strMenu + " <li><a href='Manage_School.aspx'>School</a></li>";       
                strMenu = strMenu + " <li><a href='Manage_Guard.aspx'>Guard</a></li>";
                strMenu = strMenu + "</ul>";

                strMenu = strMenu + "<ul class='sub-menu'>";

                strMenu = strMenu + " <li><a href='ViewTimeSlot.aspx'>Time Slot</a></li>";
                //strMenu = strMenu + " <li><a href='Manage_SpecialTimeSlot.aspx'>Special Time Slot</a></li>";
                //strMenu = strMenu + " <li><a href='Manage_StadiumWiseTimeSlot.aspx'>Stadium Wise Time Slot</a></li>";          
                strMenu = strMenu + "</ul>";

                strMenu = strMenu + "</div>";
                strMenu = strMenu + "</div>";

                strMenu = strMenu + " </li>";


            }
        }


        if (Session["MaleabnaCMSStadiumMenu"].ToString() == "True")
        {
            // strMenu = strMenu + "<li class='sub-header'> <span>الملعب</span></li>";

            if (Request.Url.ToString().IndexOf("Manage_School.aspx") != -1 | Request.Url.ToString().IndexOf("Create_School.aspx") != -1 |  Request.Url.ToString().IndexOf("View_SchoolDetails.aspx") != -1)
            {
                strMenu = strMenu + " <li class='selected'><a href='Manage_School.aspx'><div class='icon-w'><div class='fa fa-building-o'></div> </div><span>مدرسة</span></a> </li>";
            }
            else
            {
                strMenu = strMenu + " <li class=''><a href='Manage_School.aspx'><div class='icon-w'><div class='fa fa-building-o'></div> </div><span>مدرسة</span></a> </li>";
            }
        }

        if (Session["MaleabnaCMSStadiumMenu"].ToString() == "True")
        {
           // strMenu = strMenu + "<li class='sub-header'> <span>الملعب</span></li>";

            if (Request.Url.ToString().IndexOf("Manage_Stadium.aspx") != -1 | Request.Url.ToString().IndexOf("Create_Stadium.aspx") != -1)
            {
                strMenu = strMenu + " <li class='selected'><a href='Manage_Stadium.aspx'><div class='icon-w'><div class='fa fa-map-marker'></div> </div><span>الملعب</span></a> </li>";
            }
            else
            {
                strMenu = strMenu + " <li class=''><a href='Manage_Stadium.aspx'><div class='icon-w'><div class='fa fa-map-marker'></div> </div><span>الملعب</span></a> </li>";
            }
        }

      

        if (Session["MaleabnaCMSMembersMenu"].ToString() == "True")
        {
            //strMenu = strMenu + "<li class='sub-header'> <span>Members</span></li>";

            if (Request.Url.ToString().IndexOf("View_Members.aspx") != -1 | Request.Url.ToString().IndexOf("View_MembersDetails.aspx") != -1)
            {
                strMenu = strMenu + " <li class='selected'><a href='View_Members.aspx'><div class='icon-w'><div class='fa fa-address-card'></div> </div><span>Members</span></a> </li>";
            }
            else
            {
                strMenu = strMenu + " <li class=''><a href='View_Members.aspx'><div class='icon-w'><div class='fa fa-address-card'></div> </div><span>Members</span></a> </li>";
            }
        }

        if (Session["MaleabnaCMSBookingMenu"].ToString() == "True")
        {
            //strMenu = strMenu + "<li class='sub-header'> <span>Booking</span></li>";

            if (Request.Url.ToString().IndexOf("View_Members.aspx") != -1 | Request.Url.ToString().IndexOf("View_MembersDetails.aspx") != -1)
            {
                strMenu = strMenu + " <li class='selected'><a href='View_Booking.aspx'><div class='icon-w'><div class='fa fa-calendar'></div> </div><span>حجوز</span></a> </li>";
            }
            else
            {
                strMenu = strMenu + " <li class=''><a href='View_Booking.aspx'><div class='icon-w'><div class='fa fa-calendar '></div> </div><span>حجوز</span></a> </li>";
            }
        }

        if (Session["MaleabnaCMSReportsMenu"].ToString() == "True")
        {
            // strMenu = strMenu + "<li class='sub-header'> <span>Reports</span></li>";

            if (Request.Url.ToString().IndexOf("View_Reports.aspx") != -1 | Request.Url.ToString().IndexOf("View_Reports.aspx") != -1)
            {
                strMenu = strMenu + " <li class='selected'><a href='View_BookingReport.aspx'><div class='icon-w'><div class='os-icon os-icon-bar-chart-up'></div> </div><span>تقارير</span></a> </li>";
            }
            else
            {
                strMenu = strMenu + " <li class=''><a href='View_BookingReport.aspx'><div class='icon-w'><div class='os-icon os-icon-bar-chart-up'></div> </div><span>تقارير</span></a> </li>";
            }
        }

        if (Session["MaleabnaCMSPagesMenu"].ToString() == "True")
        {
             //strMenu = strMenu + "<li class='sub-header'> <span>Pages</span></li>";

            if (Request.Url.ToString().IndexOf("Manage_PageContent.aspx") != -1 | Request.Url.ToString().IndexOf("Manage_PageContent.aspx") != -1)
            {
                strMenu = strMenu + "<li class='has-sub-menu'><a href='#'><div class='icon-w'> <div class='os-icon os-icon-file-text'></div></div><span>Pages</span></a>";

                strMenu = strMenu + "  <div class='sub-menu-w'><div class='sub-menu-header'>Pages</div> <div class='sub-menu-icon'><div class='os-icon os-icon-file-text'></div> </div>";
                strMenu = strMenu + "<div class='sub-menu-i'>";

                strMenu = strMenu + "<ul class='sub-menu'>";
                strMenu = strMenu + " <li><a href='Add_Modify_PageContent.aspx?PID=5'>Introduction</a></li>";
                strMenu = strMenu + " <li><a href='Add_Modify_PageContent.aspx?PID=1'>عن ملعبنا</a></li>";
                strMenu = strMenu + " <li><a href='Add_Modify_PageContent.aspx?PID=2'>سياسة الخصوصية</a></li>";
                strMenu = strMenu + " <li><a href='Add_Modify_PageContent.aspx?PID=3'>سياسة الحجز</a></li>";
                strMenu = strMenu + " <li><a href='Add_Modify_PageContent.aspx?PID=4'>الإتصال بنا</a></li>";

                strMenu = strMenu + "</ul>";

                strMenu = strMenu + "</div>";
                strMenu = strMenu + "</div>";

                strMenu = strMenu + " </li>";
            }
            else
            {
                strMenu = strMenu + "<li class='has-sub-menu'><a href='#'><div class='icon-w'> <div class='os-icon os-icon-file-text'></div></div><span>Pages</span></a>";

                strMenu = strMenu + "  <div class='sub-menu-w'><div class='sub-menu-header'>Pages</div> <div class='sub-menu-icon'><div class='os-icon os-icon-file-text'></div> </div>";
                strMenu = strMenu + "<div class='sub-menu-i'>";

                strMenu = strMenu + "<ul class='sub-menu'>";
                strMenu = strMenu + " <li><a href='Add_Modify_PageContent.aspx?PID=5'>Introduction</a></li>";
                strMenu = strMenu + " <li><a href='Add_Modify_PageContent.aspx?PID=1'>عن ملعبنا</a></li>";
                strMenu = strMenu + " <li><a href='Add_Modify_PageContent.aspx?PID=2'>سياسة الخصوصية</a></li>";
                strMenu = strMenu + " <li><a href='Add_Modify_PageContent.aspx?PID=3'>سياسة الحجز</a></li>";
                strMenu = strMenu + " <li><a href='Add_Modify_PageContent.aspx?PID=4'>الإتصال بنا</a></li>";

                strMenu = strMenu + "</ul>";

                strMenu = strMenu + "</div>";
                strMenu = strMenu + "</div>";

                strMenu = strMenu + " </li>";

                //  strMenu = strMenu + "<li class=''><a href='Add_Mod_Settings.aspx'><div class='icon-w'><i class='fa fa-cog' aria-hidden='true'></i></div> <span>Settings </span></a></li>";
            }
        }




        if (Session["MaleabnaCMSBannerMenu"].ToString() == "True")
        {
            // strMenu = strMenu + "<li class='sub-header'> <span>الملعب</span></li>";

            if (Request.Url.ToString().IndexOf("Manage_Banner.aspx") != -1 | Request.Url.ToString().IndexOf("Create_Banner.aspx") != -1)
            {
                strMenu = strMenu + " <li class='selected'><a href='Manage_Banner.aspx'><div class='icon-w'><div class='os-icon os-icon-documents-07'></div> </div><span>Banner</span></a> </li>";
            }
            else
            {
                strMenu = strMenu + " <li class=''><a href='Manage_Banner.aspx'><div class='icon-w'><div class='os-icon os-icon-documents-07'></div> </div><span>Banner</span></a> </li>";
            }
        }

        if (Session["MaleabnaCMSBlockStadiumMenu"].ToString() == "True")
        {

            if (Request.Url.ToString().IndexOf("View_BlockStadium.aspx") != -1 | Request.Url.ToString().IndexOf("View_BlockStadiumDetails.aspx") != -1)
            {
                strMenu = strMenu + " <li class='selected'><a href='View_BlockStadium.aspx'><div class='icon-w'><div class='fa fa-ban'></div> </div><span>Block Stadium</span></a> </li>";
            }
            else
            {
                strMenu = strMenu + " <li class=''><a href='View_BlockStadium.aspx'><div class='icon-w'><div class='fa fa-ban'></div> </div><span>Block Stadium</span></a> </li>";
            }
        }

        if (Session["MaleabnaCMSContactMenu"].ToString() == "True")
        {

            if (Request.Url.ToString().IndexOf("View_ContactUs.aspx") != -1)
            {
                strMenu = strMenu + " <li class='selected'><a href='View_ContactUs.aspx'><div class='icon-w'><div class='fa fa-pencil'></div> </div><span> ContactUs </span></a> </li>";
            }
            else
            {
                strMenu = strMenu + " <li class=''><a href='View_ContactUs.aspx'><div class='icon-w'><div class='fa fa-pencil'></div> </div><span> ContactUs </span></a> </li>";
            }
        }


        //if (Request.Url.ToString().IndexOf("View_BookingReport.aspx") != -1)
        //{
        //    strMenu = strMenu + " <li class='selected'><a href='View_BookingReport.aspx'><div class='icon-w'><div class='fa fa-object-group'></div> </div><span> Report </span></a> </li>";
        //}
        //else
        //{
        //    strMenu = strMenu + " <li class=''><a href='View_BookingReport.aspx'><div class='icon-w'><div class='fa fa-object-group'></div> </div><span> Report </span></a> </li>";
        //}

        //strMenu = strMenu + "<li class='sub-header'> <span>الاعدادات</span></li>";
        //if (Request.Url.ToString().IndexOf("Manage_Governorate.aspx") != -1 )
        //{
        //    strMenu = strMenu + " <li class='selected'><a href='Manage_Governorate.aspx'><div class='icon-w'><div class='fa fa-filter'></div> </div><span>المحافظة</span></a> </li>";
        //}
        //else
        //{
        //    strMenu = strMenu + " <li class=''><a href='Manage_Governorate.aspx'><div class='icon-w'><div class='fa fa-filter'></div> </div><span>المحافظة</span></a> </li>";
        //}

        //if (Request.Url.ToString().IndexOf("Manage_Area.aspx") != -1)
        //{
        //    strMenu = strMenu + " <li class='selected'><a href='Manage_Area.aspx'><div class='icon-w'><div class='fa fa-filter'></div> </div><span>المنطقة</span></a> </li>";
        //}
        //else
        //{
        //    strMenu = strMenu + " <li class=''><a href='Manage_Area.aspx'><div class='icon-w'><div class='fa fa-filter'></div> </div><span>المنطقة</span></a> </li>";
        //}

        //if (Request.Url.ToString().IndexOf("Manage_School.aspx") != -1 | Request.Url.ToString().IndexOf("Create_School.aspx") != -1)
        //{
        //    strMenu = strMenu + " <li class='selected'><a href='Manage_School.aspx'><div class='icon-w'><div class='fa fa-building-o'></div> </div><span>School</span></a> </li>";
        //}
        //else
        //{
        //    strMenu = strMenu + " <li class=''><a href='Manage_School.aspx'><div class='icon-w'><div class='fa fa-building-o'></div> </div><span>School</span></a> </li>";
        //}



        //if (Request.Url.ToString().IndexOf("Manage_Guard.aspx") != -1 | Request.Url.ToString().IndexOf("Create_Guard.aspx") != -1)
        //{
        //    strMenu = strMenu + " <li class='selected'><a href='Manage_Guard.aspx'><div class='icon-w'><div class='fa fa-user'></div> </div><span>Guard</span></a> </li>";
        //}
        //else
        //{
        //    strMenu = strMenu + " <li class=''><a href='Manage_Guard.aspx'><div class='icon-w'><div class='fa fa-user'></div> </div><span>Guard</span></a> </li>";
        //}

    }
}
