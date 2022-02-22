<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="RAcademy_Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <%-- <style>
        .term-container
        {
            direction: rtl;
            text-align: right;
        }

        .conditions-sec
        {
            padding: 10px 30px 30px 30px;
            background-color: #ececec;
        }

            .conditions-sec h3
            {
                margin: 20px 0;
            }

            .conditions-sec ol li, .conditions-sec ul li
            {
                padding: 7px 0;
            }

        .title-bg
        {
            background-color: #c00000;
            color: #fff;
            text-align: center;
            padding: 20px 0;
            margin: 20px 0 0 0;
            border-radius: 20px 20px 0 0;
        }
        .mt-30
        {
            margin-top: 30px !important;
        }
        .mb-30
        {
            margin-bottom:30px;
        }

        @media (max-width:370px)
        {
            .sm-center1
            {
                text-align: center !important;
                display:block !important;
                margin:0 auto !important;
            }
        }
        hr {
         border-top:1px solid #c2c2c2 !important;
        }
        p {
            font-size: 16px;
        }
       .mt-30 {
            margin-top:30px;
        }
        .mt-60 {
            margin-top:60px !important;
        }
        ul.academy-list li {
            font-size:16px;

        }
       
    </style>--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">


    <div class="main-content">
        <!-- Breadcrumbs Section Start -->
        <div class="rs-breadcrumbs bg-6">
            <div class="container">
                <div class="content-part text-center">
                    <h1 class="breadcrumbs-title white-color mb-0">مجلس الشباب</h1>
                </div>
            </div>
        </div>

    </div>



    <div class="container term-container mt-50 mb-30">
       

        <div class="row text-right">
          

            <div class="col-md-12">

                <div class="row">
                    <div class="col-lg-4 sm-center1 co1-12 ">  <img src="Content/images/logo-new.png" /> </div>
                    <div class="col-lg-4 col-12 sm-center1">  <h3 class="mt-60" style="font-size: 32px;"> مركز الإرشاد الأكاديمي </h3></div>
                     <div class="col-lg-4 co1-12 sm-center1" style="text-align: center;" > <img src="Content/images/ypa-main-logo.png"/>  </div>
                    
                </div>
               <hr />

               
                    <h3 class="mt-30">نبدة عن مركز إلارشاد الاكاديمي :</h3>

                    <p style="line-height:250%;">
                   
                    
                        مركز لتحفيز وارشاد طلبة المرحلة الثانوية للالتحاق بأفضل الجامعات العالمية                    
                        والحصول على بعثات التميز من وزارة التعليم العالي في  الجامعات المتميزة المعتمده .
                        <br />

                        سيوفر المركز دعم ارشادي للطلبة لبناء ملف تقديم متكامل يتخلله:
                    </p>
                   
                       
                      <ul>
                          <li> كتابة السيرة الذاتية والبيان الشخصي </li>
                          <li>الارشاد لتقديم اختبار المستوى الأكاديمي والمقابلة الشخصية</li>
                          <li>توفير فرص تطوعية</li>
                          <li>تحفيز جانب الموهبة والإبداع للتقديم على  الجامعات والمتميزة</li>
                      </ul>
                        
                 
                        
                  
                   

                    
                    <div class="row">
                        <div class="col-md-12">

                            <a href="AcademicRegistration.aspx" class="btn btn-info"> التسجيل   </a>

                        </div>

                    </div>

                </div>



            </div>



     


    </div>
</asp:Content>

