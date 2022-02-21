<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Fail.aspx.cs" Inherits="Fail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <style>
        body {
            -webkit-print-color-adjust: exact !important;
        }

        @page {
            size: auto;
            margin: 0mm;
        }

        @media print {
            .bot1_wrapper, .bot2_wrapper, .top2_wrapper, .top1_wrapper, .page_banner, .breadcrumbs1, .noprint, .navbar {
                display: none !important;
            }

             .col-md-6 {
                width: 50%;
            }

            .booking-row .red {
                padding-top: 0px;
            }


            .only-print {
                display: block !important;
                padding: 10px;
                margin-bottom: 20px;
            }

            .sucess-container {
                border: none !important;
            }

            body {
                -webkit-print-color-adjust: exact !important;
            }
        }

        @media print and (color) {
            * {
                -webkit-print-color-adjust: exact !important;
                print-color-adjust: exact !important;
            }
        }

        .input2_wrapper{margin-bottom:10px;}
         .btn-success {
            text-align:center;
           
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="main" >
    <div class="page_banner"></div>
   <div class="breadcrumbs1_wrapper">
        <div class="container">
            <div class="breadcrumbs1"><a href="index.aspx">الرئيسية</a><span>/</span>عن ملعبنا / تفاصيل الحجز</div>
        </div>
    </div>


    <div id="content" >
        <div class="container"> 
            <div class="row">
                 <div class="col-lg-2"></div>
                    <div class="col-lg-8 sucess-container">
                    
                    <div class="clearfix"></div>
                   
                     
                        <div class="row only-print" style="display: none;">
                            <div class="col-md-6 col-lg-6 col-xs-6 text-left">
                                <img src="images/Malebna_logo.png" />
                            </div>
                            <div class="col-md-6 col-lg-6 col-xs-6 text-right">
                                <img src="images/MaleabnaLogo_old.png" />
                            </div>
                        </div>

                         <div class="clearfix"></div>
                        <div class="payment-status">

                        <div style="color:Red;text-align:center;font-size:large;"> <asp:Label ID="lblngPayHead" runat="server"></asp:Label> </div>        

                        <br />
                        <div class="o-heading" style="text-align:center">حالة الدفع  : <asp:Label ID="lblPaymentStatus" runat="server"></asp:Label> </div> 
                        <br />
                        <div class="o-heading" style="text-align:center">تاريخ وتوقيت الدفع  : <asp:Label ID="lblPaymentDate" runat="server"></asp:Label> </div>      
                        <br />
                        <div class="o-heading" style="text-align:center">الرمز التعريفي لعملية الدفع : <asp:Label ID="lblngPayId" runat="server"></asp:Label>  </div>      
                        <br />

                             <div class="o-heading" style="text-align:center">TrackID : <asp:Label ID="lbltrackID" runat="server"></asp:Label>  </div>      
                        <br />


                             <div class="o-heading" style="text-align:center">ReferenceID :  <asp:Label ID="lblrefNum" runat="server"></asp:Label>  </div>      
                        <br />
                        <div class="col-md-2"></div>

                              </div>
                        <div class="booking-row">
                        <h3 class="line">تفاصيل الحجز</h3>

                        <div id="divspin1" style="display:none" class="spinner"></div>

                        <div class="input2_wrapper">
                            <label class="col-md-6" style="padding-left:0;padding-top:12px;">اللإسم</label>

                            <div class="col-md-6" style="padding-right:0;padding-left:0;">
                                <span class="red"> <asp:Label ID="lblcName" runat="server"></asp:Label>
                                </span>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="input2_wrapper">
                            <label class="col-md-6" style="padding-left:0;padding-top:12px;">المكان</label>

                            <div class="col-md-6" style="padding-right:0;padding-left:0;">
                                <span class="red"><asp:Label ID="lblStadiumName" runat="server"></asp:Label>  </span>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="input2_wrapper">
                            <label class="col-md-6" style="padding-left:0;padding-top:12px;">الملعب</label>

                            <div class="col-md-6" style="padding-right:0;padding-left:0;">
                                <span class="red"><asp:Label ID="lbladdress" runat="server"></asp:Label>  </span>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="input2_wrapper">
                            <label class="col-md-6" style="padding-left:0;padding-top:12px;">الفترة</label>

                            <div class="col-md-6" style="padding-right:0;padding-left:0;">
                                <span class="red"><asp:Label ID="lblselTime" runat="server"></asp:Label>  </span>
                            </div>
                        </div>
						<div class="clearfix"></div>
                        <div class="input2_wrapper">
                            <label class="col-md-6" style="padding-left:0;padding-top:12px;">التاريخ</label>

                            <div class="col-md-6" style="padding-right:0;padding-left:0;">
                                <span class="red"><asp:Label ID="lblSelDate" runat="server"></asp:Label></span>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="margin-top"></div>
                        <h3 class="line">قيمة الحجز</h3>

                        <div class="input2_wrapper">
                            <label class="col-md-6" style="padding-left:0;padding-top:12px;">مبلغ الدفع </label>

                            <div class="col-md-6" style="padding-right:0;padding-left:0;">
                                <span class="red"><asp:Label ID="lblRate" runat="server"></asp:Label>  د.ك</span>
                            </div>
                        </div>




                        <div class="clearfix"></div>
                        
                        
                         <div class="margin-top">
                            <%--<button class="col-md-12 btn btn-default btn-cf-submit3" style="text-align:center;" ng-click="OnClickRetry();">حاول مرة اخرى</button>--%>
                            <asp:LinkButton ID="lnktry" runat="server" Text="حاول مرة اخرى" CssClass="col-md-12 btn btn-danger btn-cf-submit3" style="text-align:center;" OnClick="lnktry_Click"></asp:LinkButton>
                              </div>

					<div class="col-md-2"></div>
                </div>
                          
            </div>
        </div>
    </div>

      <!--<script type="application/javascript">
          $(document).ready(function () {

              $.urlParam = function (name) {
                  var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
                  if (results == null) {
                      return null;
                  }
                  return decodeURI(results[1]) || 0;
              }

              var tech = $.urlParam('OrderID');
              console.log(tech);
              angular.element(document.getElementById('dividSucess')).scope().fn_GetSucessInfo();


          });

        
    </script>-->

</div>
 
</div>

</asp:Content>

