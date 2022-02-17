<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="ActivityDetails.aspx.cs" Inherits="ActivityDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style>
    .imgcenter {
   
    margin-left: auto;
    margin-right: auto;
    height:auto;
    max-width :100%;
    
}
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <div class="main-content">
        <div class="rs-breadcrumbs bg-6">
            <div class="container">
                <div class="content-part text-center">
                    <h1 class="breadcrumbs-title white-color mb-0">مجلس الشباب</h1>
                </div>
            </div>
        </div>

              <div class="container ">
            <div class="row">
                <div class="col-sm-12 ">
                    <div class="">
                      
                           <img class=""  id="newsImage" runat="server" src="../assets/img/news/01.jpg" alt=""  />
                            <br />
                              <h1  id="title" runat="server" class="">عنوان الخبر</h1>
                       
                              <span id="Span2" runat="server" class="imgcenter"  style="font-weight: bold;margin-left: 5px; margin-right: auto;" />
                             <br /><br />
                           
                      
                        <asp:Label ID="lbl" runat="server" class=""  />


                       <asp:Panel ID="winnerpnl" runat="server" >
                        <asp:Label ID="A" runat="server" class=""  style="color:brown; Font-Size:16px"/>
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
                   
                        <asp:Label ID="B" runat="server" class=""  style="color:brown; Font-Size:16px"/>
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
                        <div class="col-sm-2">
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

    </div>
</asp:Content>

