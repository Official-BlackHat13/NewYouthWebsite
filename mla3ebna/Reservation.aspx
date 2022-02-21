<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Reservation.aspx.cs" Inherits="Reservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
         ol li {
            line-height:180% !important;
            padding: 5px 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="page_banner"></div>

    <div class="breadcrumbs1_wrapper">
        <div class="container">
            <div class="breadcrumbs1"><a href="index.aspx">الرئيسية</a><span>/</span>سياسة الحجز</div>
        </div>
    </div>

<div id="content">
  <div class="container">

    <div class="row">
      <div class="col-sm-12">
        <div class="blog_content">


          <div class="post post-full">
           
            <div class="post-story" style="direction:rtl;">
                <div runat="server" id="pAbout" visible="false"></div>
                 <ol>
                            <li class="">الإلتزام بالاخلاق الرياضية والهدوء أثناء اللعب</li>
                            <li class="">الإلتزام بمواعيد الحجز</li>
                            <li class="">الالتزام بإرتداء الملابس الرياضية</li>
                            <li class="">الالتزام بالمحافظة على نظافة الملعب .</li>
                             <li class=""> يمنع منعا باتا التدخين في مرافق المركز</li>
                            <li class=""> الإلتزام باستخدام المواقف المخصصة للسيارات</li>
                            <li class=""> عدم ترك السيارة داخل المواقف المخصصة للسيارات بعد موعد الحجز</li>
                            <li class=""> لا نتحمل الاصابات والحوادث الناتجة عن استخدام الملعب</li>
                            <li class=""> ليس علينا اي إالتزامات ناتجة عن تغيير الأحوال الجوية والعوامل الطبيعة </li>
                            <li class=""> في حالة الرغبة في إلغاء الحجز يمكن الغاء عبر الموقع الالكتروني قبل موعد الحجز بـ 24 ساعة ؛ ننوه بتحول المبلغ للمحفظة اذا تم الإلغاء قبل 24 ساعة ، وبالإمكان استخدام رصيد المحفظة في حجز مواعيد أخرى ، مبلغ الحجز لا يرد ولا يستبدل بموعد آخر في حالة عدم الالتزام بموعد الحجز.  </li>
                            <li class=""> لدينا الحق في تغيير موعد الحجز في حالات خاصة، وتعويض العميل بوقت آخر حسب الاتفاق. </li>
                            <li class=""> نحن  غير مسئولين عن فقدان اي أغراض وأمتعة شخصية </li>
                            <li class=""> رقم الهاتف المسجل بالحساب هو حلقة الوصل و يجب الرد عليه في حال تواصلنا معكم في حال اضطرار تغيير الحجز</li>
                            <li class=""> لا يجوز الغاء الحجز اذا كان الموعد بعد اقل من 24 ساعة. </li>
                         <%--   <li class=""> </li>--%>
                        </ol>

               
              
            </div>
          </div>

       
        </div>
      </div>
       
    </div>


  </div>
</div>


</asp:Content>

