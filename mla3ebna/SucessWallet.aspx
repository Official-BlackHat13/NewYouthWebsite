<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="SucessWallet.aspx.cs" Inherits="SucessWallet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <style>
            body {
            -webkit-print-color-adjust: exact !important;
        }

        @page {
            size: auto;
            margin: 0mm;
        }
        @media print{
           .bot1_wrapper, .bot2_wrapper, .top2_wrapper, .top1_wrapper, .page_banner, .breadcrumbs1, .noprint, .navbar {
                display: none !important;
            }

            .only-print {
                display: block !important;
                padding: 10px;
                margin-bottom: 20px;
            }

            .payment-status-wallet {
                border: none !important;
            }

            body {
                -webkit-print-color-adjust: exact !important;
            }
             .col-md-6 {
                width: 50%;
            }

            .booking-row .red {
                padding-top: 0px !important;
            }
        }

           @media print and (color) {
            * {
                -webkit-print-color-adjust: exact !important;
                print-color-adjust: exact !important;
            }
        }
          .payment-status {
              padding: 10px 0 !important;
          }

          .payment-status-wallet {
              padding: 20px !important;
          }
           .input2_wrapper{margin-bottom:10px;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main">
    <div class="page_banner"></div>
   <div class="breadcrumbs1_wrapper">
        <div class="container">
            <div class="breadcrumbs1"><a href="index.html">الرئيسية</a><span>/</span> تفاصيل الدفع </div>
        </div>
    </div>


    <div id="content" >
        <div class="container"> 
            <div class="row">
                <div class="col-lg-2"></div>
                <div class="col-lg-8 payment-status-wallet" >
                    
                       <div class="row only-print" style="display: none;">
                            <div class="col-md-6 col-lg-6 col-xs-6 text-left">
                                <img src="images/Malebna_logo.png" />
                            </div>
                            <div class="col-md-6 col-lg-6 col-xs-6 text-right">
                                <img src="images/MaleabnaLogo.png" alt=""  height="85"  class="text-right"/>
                            </div>
                        </div>
                    <div class="clearfix"></div>
                    <div class="payment-status">
                        
                  

                     
                        <div style="color:Maroon;text-align:center;font-size:large;" id="Divngcancel" runat="server">لقد تم إلغاء حجزك بنجاح ...</div>        
                        <div style="color:Green;text-align:center;font-size:large;" id="Divngbook" runat="server" >عملية الدفع ناجحة ..</div>

                        <div class="o-heading" style="text-align:center">رصيد محفظتك : <asp:Label ID="lblngBAlWallet" runat="server"></asp:Label> <%--{{ngBAlWallet}}--%></div>      
                    

                        </div>
                    
                        <div class="booking-row">
                        <h3 class="line">تفاصيل الحجز</h3>

                        <div class="input2_wrapper">
                            <label class="col-md-6" >اللإسم</label>

                            <div class="col-md-6" >
                                <span class="red"> <asp:Label ID="lblcName" runat="server"></asp:Label>  <%--{{dtBooking[0].cName}}--%>
                                </span>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="input2_wrapper">
                            <label class="col-md-6" >المكان</label>

                            <div class="col-md-6" >
                                <span class="red" > <asp:Label ID="lblStadiumName" runat="server"></asp:Label>  <%--{{dtBooking[0].StadiumName}}--%></span>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="input2_wrapper">
                            <label class="col-md-6" >الملعب</label>

                            <div class="col-md-6" >
                                <span class="red"> <asp:Label ID="lbladdress" runat="server"></asp:Label>    <%--{{dtBooking[0].address}} --%></span>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="input2_wrapper">
                            <label class="col-md-6" >الفترة</label>

                            <div class="col-md-6" >
                                <span class="red">  <asp:Label ID="lblselTime" runat="server"></asp:Label>  <%--{{dtBooking[0].selTime}}--%> </span>
                            </div>
                        </div>
						<div class="clearfix"></div>
                        <div class="input2_wrapper">
                            <label class="col-md-6" >التاريخ</label>

                            <div class="col-md-6" >
                                <span class="red">  <asp:Label ID="lblSelDate" runat="server"></asp:Label> <%--{{dtBooking[0].SelDate}}--%> </span>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="margin-top"></div>
                        <h3 class="line">قيمة الحجز</h3>

                        <div class="input2_wrapper">
                            <label class="col-md-6" >مبلغ الدفع </label>

                            <div class="col-md-6" >
                                <span class="red">  <asp:Label ID="lblRate" runat="server"></asp:Label>  <%--{{dtBooking[0].Rate}}--%> د.ك</span>
                            </div>
                        </div>

                        <div class="clearfix"></div>
                        <div class="margin-top"></div>
                        
					<div class="col-md-2"></div>
                </div>

                     <div class="row noprint">
                    <div class="col-sm-12 col-xs-12">             				
                        <div class="no-padding margin-top col-md-2 col-xs-5 text-right" style="margin-top:5px;">
                            <button class="btn btn-default btn-cf-submit" style="width:100%;"  onclick="window.print();">طباعة</button>
                        </div>
                        <div class="col-md-8 col-xs-2"></div>
                        <div class="no-padding margin-top col-md-2 col-xs-5 text-right" style="margin-top:5px;">
                           <%-- <button class="btn btn-default btn-cf-submit" style="width:100%;"  onclick="OnClickHome();">الرئيسية</button>--%>
                            <a href="index.aspx" class="btn btn-default btn-cf-submit" style="width:100%;" >الرئيسية</a>
                        </div>
                    </div>
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

         <script type="text/javascript">
             function OnClickHome() {
                 window.location = "index.aspx";
             }
    </script>

</div>
 
</div>
</asp:Content>

