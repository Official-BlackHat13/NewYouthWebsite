<%@ Page Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="ActivityDetails.aspx.cs" Inherits="ActivityDetails" %>


<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
   



    <!-- News Section -->
    <section class="news-section bg-grey margin-top-50">


        <%-- <div class="container content-lg padding-bottom-0">
            <div class="row" style="padding-bottom:100px;">
                <div class="col-sm-5 sm-margin-bottom-20">
                    <img class="img-responsive" id="newsImage" runat="server" src="assets/img/news/01.jpg" alt="">
                </div>
                <div class="col-sm-7 news-v3" style="min-height:307px">
                    <div class="news-v3-in-sm no-padding">
                        <h1 class="margin-top-20" id="title" runat="server">عنوان الخبر</h1>
                        <ul class="list-inline posted-info">
                            <li><i class="fa fa-clock-o"></i>&nbsp;<span id="date" runat="server"></span></li>
                        </ul>
                        <p id="newsText" runat="server">لوريم إيبسوم(Lorem Ipsum) هو ببساطة نص شكلي (بمعنى أن الغاية هي الشكل وليس المحتوى) ويُستخدم في صناعات المطابع ودور النشر. كان لوريم إيبسوم ولايزال المعيار للنص الشكلي منذ القرن الخامس عشر عندما قامت مطبعة مجهولة برص مجموعة من الأحرف بشكل عشوائي أخذتها من نص، لتكوّن كتيّب بمثابة دليل أو مرجع شكلي لهذه الأحرف. خمسة قرون من الزمن لم تقضي على هذا النص، بل انه حتى صار مستخدماً وبشكله الأصلي في الطباعة والتنضيد الإلكتروني. انتشر بشكل كبير في ستينيّات هذا القرن مع إصدار رقائق "ليتراسيت" (Letraset) البلاستيكية تحوي مقاطع من هذا النص، وعاد لينتشر مرة أخرى مؤخراَ مع ظهور برامج النشر الإلكتروني مثل "ألدوس بايج مايكر" (Aldus PageMaker) والتي حوت أيضاً على نسخ من نص لوريم إيبسوم. لوريم إيبسوم(Lorem Ipsum) هو ببساطة نص شكلي (بمعنى أن الغاية هي الشكل وليس المحتوى) ويُستخدم في صناعات المطابع ودور النشر. كان لوريم إيبسوم ولايزال المعيار للنص الشكلي منذ القرن الخامس عشر عندما قامت مطبعة مجهولة برص مجموعة من الأحرف بشكل عشوائي أخذتها من نص، لتكوّن كتيّب بمثابة دليل أو مرجع شكلي لهذه الأحرف. خمسة قرون من الزمن لم تقضي على هذا النص، بل انه حتى صار مستخدماً وبشكله الأصلي في الطباعة والتنضيد الإلكتروني. انتشر بشكل كبير في ستينيّات هذا القرن مع إصدار رقائق "ليتراسيت" (Letraset) البلاستيكية تحوي مقاطع من هذا النص، وعاد لينتشر مرة أخرى مؤخراَ مع ظهور برامج النشر الإلكتروني مثل "ألدوس بايج مايكر" (Aldus PageMaker) والتي حوت أيضاً على نسخ من نص لوريم إيبسوم.</p>
                    </div>
                </div>
            </div>
        </div>--%>

       






        <div class="container content-lg padding-bottom-0">
            <div class="row" style="padding-bottom: 100px;">
                <div class="col-sm-12 news-v3">
                    <div class="news-v3-in-sm no-padding">
                       <%-- <h1 class="margin-top-20" id="title" runat="server">عنوان الخبر</h1>--%>
                        <%--<ul class="list-inline posted-info">
                            <li><i class="fa fa-clock-o"></i>&nbsp;<span id="date" runat="server"></span></li>
                        </ul>--%>
                        
                         <%--<div class="center">--%>
                           <%-- <img class="img-responsive news-image"  id="newsImage" runat="server" src="../assets/img/news/01.jpg" alt="" ></div>--%>
                           <img class="img-responsive  imgcenter"  id="newsImage" runat="server" src="../assets/img/news/01.jpg" alt=""  />
                            <br />
                              <h1  id="title" runat="server" class="imgcenter">عنوان الخبر</h1>
                          
                           <%-- <asp:Label ID="lblnew" runat="server" ></asp:Label>--%>
                           
                           <%-- <span id="newsText" runat="server">لوريم إيبسوم(Lorem Ipsum) هو ببساطة نص شكلي (بمعنى أن الغاية هي الشكل وليس المحتوى) ويُستخدم في صناعات المطابع ودور النشر. كان لوريم إيبسوم ولايزال المعيار للنص الشكلي منذ القرن الخامس عشر عندما قامت مطبعة مجهولة برص مجموعة من الأحرف بشكل عشوائي أخذتها من نص، لتكوّن كتيّب بمثابة دليل أو مرجع شكلي لهذه الأحرف. خمسة قرون من الزمن لم تقضي على هذا النص، بل انه حتى صار مستخدماً وبشكله الأصلي في الطباعة والتنضيد الإلكتروني. انتشر بشكل كبير في ستينيّات هذا القرن مع إصدار رقائق "ليتراسيت" (Letraset) البلاستيكية تحوي مقاطع من هذا النص، وعاد لينتشر مرة أخرى مؤخراَ مع ظهور برامج النشر الإلكتروني مثل "ألدوس بايج مايكر" (Aldus PageMaker) والتي حوت أيضاً على نسخ من نص لوريم إيبسوم. لوريم إيبسوم(Lorem Ipsum) هو ببساطة نص شكلي (بمعنى أن الغاية هي الشكل وليس المحتوى) ويُستخدم في صناعات المطابع ودور النشر. كان لوريم إيبسوم ولايزال المعيار للنص الشكلي منذ القرن الخامس عشر عندما قامت مطبعة مجهولة برص مجموعة من الأحرف بشكل عشوائي أخذتها من نص، لتكوّن كتيّب بمثابة دليل أو مرجع شكلي لهذه الأحرف. خمسة قرون من الزمن لم تقضي على هذا النص، بل انه حتى صار مستخدماً وبشكله الأصلي في الطباعة والتنضيد الإلكتروني. انتشر بشكل كبير في ستينيّات هذا القرن مع إصدار رقائق "ليتراسيت" (Letraset) البلاستيكية تحوي مقاطع من هذا النص، وعاد لينتشر مرة أخرى مؤخراَ مع ظهور برامج النشر الإلكتروني مثل "ألدوس بايج مايكر" (Aldus PageMaker) والتي حوت أيضاً على نسخ من نص لوريم إيبسوم.</span>--%>
                            
                              <span id="Span2" runat="server" class="imgcenter"  style="font-weight: bold;margin-left: 5px; margin-right: auto;" />
                             <br /><br />
                           
                        <%--   <asp:TextBox ID="txtnews" MaxLength="8000" Rows="12" TextMode="MultiLine" runat="server" CssClass="form-control" ReadOnly="true" />
                         <br /><br />--%>

                                <%--<span id="Span1" runat="server" class="imgcenter"  />--%>

                        <asp:Label ID="lbl" runat="server" class="imgcenter"  />


                       <asp:Panel ID="winnerpnl" runat="server" >
                        <asp:Label ID="A" runat="server" class="imgcenter"  style="color:brown; Font-Size:16px"/>
                         <div class="row">
                         <div class="col-md-12"> 
                              <div class="col-md-6"> 
                             <asp:Label ID ="A1" runat="server" style='color: black;font-size: 14px' ></asp:Label></div>
                                <div class="col-md-6"> <asp:LinkButton ID="lnkA1" runat="server" style='color:mediumblue;font-size: 14px;'  OnClick="lnkA1_Click" ><i class="fa fa-file-pdf-o">للتحميل والمشاهدة</i></asp:LinkButton>
                              </div>
                         </div>  

                       <div class="col-md-12">  
                              <div class="col-md-6">                     
                             <asp:Label ID ="A2" runat="server" style='color: black;font-size: 14px' ></asp:Label> </div>
                               <div class="col-md-6"><asp:LinkButton ID="lnkA2" runat="server" style='color:mediumblue;font-size: 14px;'  OnClick="lnkA2_Click" ><i class="fa fa-file-pdf-o">للتحميل والمشاهدة</i></asp:LinkButton>
                               </div>
                         </div>
                         <div class="col-md-12">  
                              <div class="col-md-6">                      
                             <asp:Label ID ="A3" runat="server" style='color: black;font-size: 14px' ></asp:Label></div>
                                 <div class="col-md-6"><asp:LinkButton ID="lnkA3" runat="server" style='color:mediumblue;font-size: 14px;'  OnClick="lnkA3_Click" ><i class="fa fa-file-pdf-o">للتحميل والمشاهدة</i></asp:LinkButton>
                            </div>  
                         </div>  </div>  <br />
                    <%--   <FTB:FreeTextBox ID="FreeTextBox1" runat="server"  Width="100%"   Height="400px" FormatHtmlTagsToXhtml="False" EnableToolbars="false" AllowHtmlMode="true" AutoHideToolbar="true" DesignModeBodyTagCssClass="ftb1" ClientSideTextChanged="false" HtmlModeCssClass="ftb1" ReadOnly="true" EditorBorderColorDark="White" EditorBorderColorLight="White" GutterBorderColorDark="White" GutterBorderColorLight="White" ToolbarLayout="none" ButtonDownImage="false" RemoveScriptNameFromBookmarks  ="true"></FTB:FreeTextBox>--%>
                          <%--   </div>--%>
                         
                        <asp:Label ID="B" runat="server" class="imgcenter"  style="color:brown; Font-Size:16px"/>
                    <div class="row"> 
                        <div class="col-md-12">  
                              <div class="col-md-6">                     
                             <asp:Label ID ="B1" runat="server" style='color: black;font-size: 14px' ></asp:Label></div>
                               
                              <div class="col-md-6"><asp:LinkButton ID="lnkB1" runat="server" style='color:mediumblue;font-size: 14px;'  OnClick="lnkB1_Click" ><i class="fa fa-file-pdf-o">للتحميل والمشاهدة</i></asp:LinkButton>                              
                         </div></div>

                        <div class="col-md-12">  
                              <div class="col-md-6">                     
                             <asp:Label ID ="B2" runat="server" style='color: black;font-size: 14px' ></asp:Label> </div>
                              
                              <div class="col-md-6"><asp:LinkButton ID="lnkB2" runat="server" style='color:mediumblue;font-size: 14px;'  OnClick="lnkB2_Click" ><i class="fa fa-file-pdf-o">للتحميل والمشاهدة</i></asp:LinkButton>                              
                         </div></div>

                         <div class="col-md-12">  
                              <div class="col-md-6">                      
                             <asp:Label ID ="B3" runat="server" style='color: black;font-size: 14px' ></asp:Label> </div>
                                
                              <div class="col-md-6"> <asp:LinkButton ID="lnkB3" runat="server" style='color:mediumblue;font-size: 14px;'  OnClick="lnkB3_Click" ><i class="fa fa-file-pdf-o">للتحميل والمشاهدة</i></asp:LinkButton>                              
                         </div></div></div>
                        <br />
                       
                        <asp:Label ID="C" runat="server" class="imgcenter"  style="color:brown; Font-Size:16px"/>
                     <div class="row">
                         <div class="col-md-12">  
                              <div class="col-md-6">                     
                             <asp:Label ID ="C1" runat="server" style='color: black;font-size: 14px' ></asp:Label></div>
                               
                              <div class="col-md-6"><asp:LinkButton ID="lnkC1" runat="server" style='color:mediumblue;font-size: 14px;'  OnClick="lnkC1_Click" ><i class="fa fa-file-pdf-o">للتحميل والمشاهدة</i></asp:LinkButton>                              
                         </div></div>

                        <div class="col-md-12">  
                              <div class="col-md-6">                    
                             <asp:Label ID ="C2" runat="server" style='color: black;font-size: 14px' ></asp:Label> </div>
                               
                              <div class="col-md-6"> <asp:LinkButton ID="lnkC2" runat="server" style='color:mediumblue;font-size: 14px;'  OnClick="lnkC2_Click" ><i class="fa fa-file-pdf-o">للتحميل والمشاهدة</i></asp:LinkButton>                              
                         </div></div>
                        <div class="col-md-12">  
                              <div class="col-md-6">                      
                             <asp:Label ID ="C3" runat="server" style='color: black;font-size: 14px' ></asp:Label></div>
                                 
                              <div class="col-md-6">  <asp:LinkButton ID="lnkC3" runat="server" style='color:mediumblue;font-size: 14px;'  OnClick="lnkC3_Click" ><i class="fa fa-file-pdf-o">للتحميل والمشاهدة</i></asp:LinkButton>                              
                        </div></div> </div>
                    </asp:Panel>

               
                    <div class="text-right margin-bottom-20">
                          <asp:LinkButton ID="lnkDownloadDetailas" runat="server" class="btn btn-primaryL" OnClick="lnkDownloadDetailas_Click" visible="false" > تفاصيل الدورات</asp:LinkButton> 
                         <a id="regLink" runat="server" class="btn btn-primary" role="button">التسجيل </a>
                        <a id="regSurvey" runat="server" class="btn btn-primary" role="button" visible="false" >انقر للاستبيان </a>

                         <a id="LoginLink" runat="server" class="btn btn-primaryL"  role="button" visible="false" > الدخول</a>
                    </div>
                </div>

            </div>

        </div>
       
        <asp:Panel ID="pnlPhotoGallery" runat="server" CssClass="container content padding-bottom-100">
            <div class="text-center margin-bottom-50">
                <h2 class="title-v2 title-center">صور النشاط</h2>
                <p class="space-lg-hor">صور خاصة بتفاصيل النشاط</p>
            </div>

            <div class="row  margin-bottom-30">
                <asp:Repeater ID="rptNewsPhotoGallery" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-2 sm-margin-bottom-30">
                            <a href='Handlers/PhotoHandler.ashx?phptoType=5&id=<%# Eval("ActivityPhotoID") %>' rel="gallery3" class="fancybox img-hover-v1">
                                <span>
                                    <img class="img-responsive" src='Handlers/PhotoHandler.ashx?phptoType=5&id=<%# Eval("ActivityPhotoID") %>&ChangeSize=1' alt="">
                                </span>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </asp:Panel>
</div>

    </section>
    <!-- End News Section -->
    <script>
        $(document).ready(function () {
            $('.ActivityI').addClass('active');
        });
    </script>
     <style>
         .btn-primaryL {
             color: #fff;
             background-color:seagreen;
             border-color: #2e6da4;
         }
  </style>

    <style>
   .center {
    display: block;
    margin-left: auto;
    margin-right: auto;
    width: 50%;
}
 </style>
 <style>
   span { 
   white-space: pre-wrap;
} </style>
 <style>
    .imgcenter {
   
    margin-left: auto;
    margin-right: auto;
    height:auto;
    max-width :100%;
    
}
 </style>
    <style>

.ftb1

body {
       font-size: 8pt;
    font-family: Verdana;
    
    border-color:#cccccc;
    border-style:solid;
    border-width:1px;
    margin-top:-20px;
    
 width:100%;
}
</style>
</asp:Content>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">

   <section class="news-section bg-grey margin-top-50">
      <div class="container content-lg padding-bottom-0">
          <div class="row" style="padding-bottom: 100px;">
             <div class="col-sm-12 news-v3">
                <div class="news-v3-in-sm no-padding">
                        <asp:Image ID="Image1" runat="server" />
                       <br />
                       <h1 id="ctl00_ContentPlaceHolder1_title" class="imgcenter"> <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label></h1>
                        <span id="ctl00_ContentPlaceHolder1_Span2" class="imgcenter" style="font-weight: bold;margin-left: 5px; margin-right: auto;">
                            <asp:Label ID="lblSummery" runat="server" Text="Label"></asp:Label>
                        </span>
                    <br /><br />
                      <span id="ctl00_ContentPlaceHolder1_lbl" class="imgcenter"> <asp:Label ID="lblText" runat="server" Text="Label"></asp:Label></span>
                      <div class="text-right margin-bottom-20">
                       <a href="https://docs.google.com/forms/d/e/1FAIpQLScmzV0uaj_HxXzuCnoJ6yhMmneTTSDtW2dGOAR1heyhaL74hA/viewform?usp=sf_link" id="ctl00_ContentPlaceHolder1_regSurvey" class="btn btn-primary" role="button">انقر للاستبيان </a>
                     </div>
              </div>
          </div>
    </div>
 </div>
</section>

</asp:Content>--%>