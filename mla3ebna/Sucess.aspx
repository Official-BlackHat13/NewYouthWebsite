<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Sucess.aspx.cs" Inherits="Sucess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

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

        .payment-status {
              padding: 10px 0 !important;
          }

          .payment-status-wallet {
              padding: 20px !important;
          }


    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div id="main">
        <div class="page_banner"></div>
        <div class="breadcrumbs1_wrapper">
            <div class="container">
                <div class="breadcrumbs1"><a href="index.aspx">الرئيسية</a><span>/</span>تفاصيل الدفع</div>
            </div>
        </div>


        <div id="content">
            <div class="container">
                <div class="row">
                    <div class="col-lg-2"></div>
                    <div class="col-lg-8 sucess-container">

                       

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



                            <div style="color: Green; text-align: center; font-size: large;"><asp:Label ID="lblHead" runat="server"></asp:Label> </div>
                            <br />
                            <div class="o-heading" style="text-align: center"> <img id="ImgBookingQRCode" width="200" runat="server" />
                               </div>
                            <br />
                            <div class="o-heading" style="text-align: center">حالة الدفع  :
                                <asp:Label ID="lblPaymentStatus" runat="server"></asp:Label>
                               </div>
                            <br />
                            <div class="o-heading" style="text-align: center">تاريخ وتوقيت الدفع :
                                <asp:Label ID="lblPaymentDate" runat="server"></asp:Label>
                            </div>
                            <br />
                            <div class="o-heading" style="text-align: center">الرمز التعريفي لعملية الدفع  :
                                <asp:Label ID="lblngPayId" runat="server"></asp:Label>
                                </div>
                            <br />
                             <div class="o-heading" style="text-align: center">TrackID  :
                                <asp:Label ID="lbltrackID" runat="server"></asp:Label>
                                </div>
                            <br />
                            <div class="o-heading" style="text-align: center">ReferenceNumber  :
                                <asp:Label ID="lblrefNum" runat="server"></asp:Label>
                                </div>
                            <br />

                        </div>



                        <div class="booking-row">
                            <h3 class="line">تفاصيل الحجز</h3>

                             <div class="input2_wrapper row">
                                 <div class="col-md-2"></div>
                                 <label class="col-md-10" >
                            <span style="font-weight:bold;font-size:20px;color:red;" runat="server" id="SpanNotSuccess" visible="true">
                                                                                            فشل في عملية الحجز ، الرجاء المحاولة مرة أخرى
                                                                                        </span>
                                     </label>
                                 </div>

                            <div class="input2_wrapper row">
                                <label class="col-md-6 " >اللإسم</label>

                                <div class="col-md-6" >
                                    <span class="red">
                                        <asp:Label ID="lblcName" runat="server"></asp:Label>
                                    </span>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="input2_wrapper row">
                                <label class="col-md-6" >المكان</label>

                                <div class="col-md-6" >
                                    <span class="red">
                                        <asp:Label ID="lblStadiumName" runat="server"></asp:Label>
                                       </span>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="input2_wrapper row">
                                <label class="col-md-6" >الملعب</label>

                                <div class="col-md-6" >
                                    <span class="red">
                                        <asp:Label ID="lbladdress" runat="server"></asp:Label>
                                         </span>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="input2_wrapper row">
                                <label class="col-md-6" >الفترة</label>

                                <div class="col-md-6" >
                                    <span class="red">
                                        <asp:Label ID="lblselTime" runat="server"></asp:Label>
                                       </span>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="input2_wrapper row">
                                <label class="col-md-6" >التاريخ</label>

                                <div class="col-md-6" >
                                    <span class="red">
                                        <asp:Label ID="lblSelDate" runat="server"></asp:Label>
                                        <%--{{dtBooking[0].SelDate}}--%></span>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="margin-top"></div>
                            <h3 class="line">قيمة الحجز</h3>

                            <div class="input2_wrapper row">
                                <label class="col-md-6" >مبلغ الدفع </label>

                                <div class="col-md-6" >
                                    <span class="red">
                                        <asp:Label ID="lblRate" runat="server"></asp:Label>
                                         د.ك</span>
                                </div>
                            </div>

                       <%--       <div class="input2_wrapper">
                            <label class="col-md-6" style="padding-left:0;padding-top:12px;"> kNet TestPayment </label>

                            <div class="col-md-6" style="padding-right:0;padding-left:0;">
                                <asp:Label ID="lbltransdata" runat="server"></asp:Label> 
                                 <asp:Label ID="lblerror" runat="server"></asp:Label> 
                            </div>
                        </div>--%>


                            <div class="clearfix"></div>
                            <div class="margin-top"></div>

                            <div class="col-md-2"></div>

                        </div>

                        <div class="row noprint">
                            <div class="col-sm-12 col-xs-12">
                                <div class="no-padding margin-top col-md-2 col-xs-5 text-right" style="margin-top: 5px;">
                                    <button class="btn btn-success btn-cf-submit" style="width: 100%;" onclick="window.print();">طباعة</button>
                                </div>
                                <div class="col-md-8 col-xs-2"></div>
                                <div class="no-padding btn-success margin-top col-md-2 col-xs-5 text-right" style="margin-top: 5px;">
                                    <%--<button class="btn btn-success btn-cf-submit" style="width: 100%;" onclick="OnClickHome();">الرئيسية</button>--%>
                                    <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-success btn-cf-submit" OnClick="btnCancel_Click" Text="الرئيسية"></asp:LinkButton>
                                </div>
                            </div>
                        </div>


                    </div>
                </div>
            </div>
        </div>

    </div>

    <script type="text/javascript">
        function OnClickHome() {
            window.location = "index.aspx";
        }
    </script>
</asp:Content>

