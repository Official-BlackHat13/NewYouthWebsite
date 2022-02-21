<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Booking.aspx.cs" Inherits="Booking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style>

        .red span {
            font-size: 14px;
        }
        .booking-row {
            background-color: #ececec !important;
            padding: 10px 20px !important;
        }

        .booking-row h3.line {
    font-weight: 600;
    font-size: 18px;
    color: #fff;
    border-bottom: 2px solid #01726a;
    padding-bottom: 9px;
    background-color: #267128;
    padding-right: 10px;
}
        .rate {
            float: left !important;
            text-align:left !important;
            font-size:18px;
        }
        .rate-kd {
            font-size:18px;
            color:#4caf50 !important;
        }
            .rate span {
                font-size:18px !important;
            }
        .modal-header  {
            text-align: right;
            background-color: #267128;
            color: #fff;
            padding:0 10px 0 10px!important;
        }

            .modal-header h5 {
                color:#fff;
                text-align:right;
            }
            @media (max-width: 767px){

.input2_wrapper span:first-child{
    float:right;

}
.input2_wrapper .knet label  {
  
margin-left:-73px !important;

}

}
        .wallet-button {
            padding-top: 12px;
            text-align: left;
            padding-left: 10px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <asp:ScriptManager runat="server" ID="script"></asp:ScriptManager>
<div id="main"  >
    <div class="page_banner"></div>
   <div class="breadcrumbs1_wrapper"  >
        <div class="container">            

            <div class="breadcrumbs1"><a href="index.aspx">الرئيسية</a><span>/</span><asp:Label ID="lblng_bread" runat="server"></asp:Label></div>
        </div>
    </div>

    
    <div id="content"  >
        <div class="container"> 
            <div class="row" runat="server" id="form">
                <div class="col-sm-12">
                    <asp:HiddenField ID="hiddenSession" runat="server" ClientIDMode="Static" />
                    <div class="clearfix"></div>
                   <div class="col-md-2"></div>
                   
                     <asp:UpdatePanel ID="updatesubmit" runat="server">
                                <ContentTemplate>
 <asp:Label ID="lbl" runat="server" test="test" CssClass="text-red" Visible="false"></asp:Label>
                    <div class="col-md-8 booking-row">
                        <h3 class="line">تفاصيل الحجز</h3>

                        <div class="input2_wrapper">
                            <label class="col-md-6" style="padding-left:0;padding-top:12px;">اللإسم</label>

                            <div class="col-md-6" style="padding-right:0;padding-left:0;">
                                <span class="red"> <asp:Label ID="lblCName" runat="server"></asp:Label>
                                </span>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="input2_wrapper">
                            <label class="col-md-6" style="padding-left:0;padding-top:12px;">المكان</label>

                            <div class="col-md-6" style="padding-right:0;padding-left:0;">
                                <span class="red"> <asp:Label ID="lblStdName" runat="server"></asp:Label> </span>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="input2_wrapper">
                            <label class="col-md-6" style="padding-left:0;padding-top:12px;">الملعب</label>

                            <div class="col-md-6" style="padding-right:0;padding-left:0;">
                                <span class="red"> <asp:Label ID="lblAddress" runat="server"></asp:Label>  </span>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="input2_wrapper">
                            <label class="col-md-6" style="padding-left:0;padding-top:12px;">الفترة</label>

                            <div class="col-md-6" style="padding-right:0;padding-left:0;">
                                <span class="red"><asp:Label ID="lblSelTime" runat="server"></asp:Label> </span>
                            </div>
                        </div>
						<div class="clearfix"></div>
                        <div class="input2_wrapper">
                            <label class="col-md-6" style="padding-left:0;padding-top:12px;">التاريخ</label>

                            <div class="col-md-6" style="padding-right:0;padding-left:0;">
                                <span class="red"> <asp:Label ID="lblSelDate" runat="server"></asp:Label> </span>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="margin-top"></div>
                        <h3 class="line">قيمة الحجز</h3>

                        <div class="input2_wrapper">
                            <label class="col-md-6" style="padding-left:0;padding-top:12px;">مبلغ الدفع </label>

                            <div class="col-md-6" style="float:left; text-align:left; font-size:16px;">
                                <span class="red rate">  <label class="rate-kd">   د.ك </label> <asp:Label ID="lblRate" runat="server"></asp:Label></span>
                            </div>
                        </div>

                        <div id="divspin1" runat="server" visible="false" class="spinner"></div>

                        <div class="clearfix"></div>
                        <div class="margin-top"></div>
                        <div id="divpayment" runat="server">
                            <h3 class="line">طريقة الدفع </h3>

                            <div class="input2_wrapper row" >
                                <div class="knet col-md-2 col-xs-6">
                                     <label style="" for="male-radio"><img src="images/knet.png" style="height:42px;"></label>
                                <asp:RadioButton  ID="radioKnet" runat="server" GroupName="paymethod"  /> &nbsp;&nbsp;
                               
                                </div>
                                <div id="divWallet" class="col-md-2 col-xs-6" runat="server" visible="false">
                                                               <label  style="" for="female-radio"><img src="images/wallet.png" style="height:42px;" /></label>
                                    <asp:RadioButton ID="radioWallet" CssClass="wallet-button" runat="server" GroupName="paymethod" />
         
                                </div>
                            </div>

                            <div class="clearfix"></div>
                            <div class="margin-top" style="margin-top:20px;"></div>
                        </div>
                        <div class="border-3px"></div>
                        <div class="clearfix"></div>
                        <div class="margin-top"></div>
                       <%-- <h3>أقر و تأكيد</h3>--%>
                         <a data-toggle="modal" data-target="#BookPoicyModal" style="color:#464646;cursor: pointer;"">  
                            
                           <%-- أوافق على الأحكام والشروط --%>
                            اوافق على سياسة الحجز
                                            
                                </a>
         
                        <asp:CheckBox ID="chkterms" runat="server" ClientIDMode="Static" />
                        <div class="margin-top"></div>
                        <div class="clearfix"></div>
                        <div class="input2_wrapper">
                            <label class="col-md-6" style="padding-left:0;padding-top:18px;font-size:16px;">المبلغ الإجمالي</label>

                            <div class="col-md-6" style="padding-right:0;padding-left:0;">
                                <span class="red rate"> <label class="rate-kd">   د.ك </label>   <asp:Label ID="lblRate1" runat="server" ></asp:Label></span>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                         <div class="form-group" style="margin: 10px" id="divmodalmsg" runat="server" visible="false"></div>
                         <div class="form-group" style="margin: 10px" id="divmodalmsg1"></div>

                        <div class="margin-top">
                           
                                    <asp:LinkButton ID="lnkSubmit" runat="server" ValidationGroup="booking" OnClientClick="return chkterms();" CssClass="col-md-12 btn btn-default btn-cf-submit3" style="text-align:center;" Text="إرسال" OnClick="lnkSubmit_Click"></asp:LinkButton>                          
                               
                              
                        </div>

                        <div class="margin-top" style="margin-top:1.8cm;">
                            <asp:LinkButton ID="lnkCancel" runat="server" Text="عودة" CssClass="col-md-12 btn btn-default btn-cf-submit3" style="text-align:center;" OnClick="lnkCancel_Click"></asp:LinkButton>
                            
                        </div>

                    </div>

                     </ContentTemplate>
                     </asp:UpdatePanel>

					<div class="col-md-2"></div>
                </div>
            </div>
        </div>
    </div>

</div>
 

     <!-- Modal -->
<div class="modal fade" id="BookPoicyModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" >
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel"> <asp:Label ID="lblng_modalheading" runat="server"></asp:Label> </h5>
         
      </div>
      <div class="modal-body"  >
            <div class="col-md-12">
                <div class="col-md-3"></div>
                    <div class="col-md-6" id="dividmodal">                    
                    <h5>
                        <asp:Label ID="lblng_modaltext" runat="server"></asp:Label>
                       </h5>
                </div>
            </div>
      </div>

      <div class="modal-footer">
        <button type="button" class="btn btn-danger btn-secondary" data-dismiss="modal">إغلاق </button>
       
      </div>
    </div>
  </div>
</div>


    <script type="text/javascript">
        function chkterms() {

            $('#divmodalmsg1').hide();
            var session = $("#hiddenSession").val();

            if (session === 'Booking') {

                if ($('input[name$=chkterms]:checked').length > 0 && $('input[name$=paymethod]:checked').length > 0) {
                    $('#divspin1').show();
                    return true;
                }
                else {
                    if ($('input[name$=chkterms]:checked').length > 0) {
                        alert("Please choose payment method");
                    }
                    else {
                        $('#divmodalmsg1').html('<div class="alert alert-danger"><button type="button" class="close" data-dismiss="alert"><i class="ace-icon fa fa-times"></i></button><strong>الرجاء قبول الشروط والأحكام </strong> </div>');
                        $('#divmodalmsg1').show();
                    }

                    return false;
                }
            }
            else if (session === 'Cancel') {

                if ($('input[name$=chkterms]:checked').length > 0) {

                    return true;
                }
                else {

                    $('#divmodalmsg1').html('<div class="alert alert-danger"><button type="button" class="close" data-dismiss="alert"><i class="ace-icon fa fa-times"></i></button><strong>الرجاء قبول الشروط والأحكام </strong> </div>');
                    $('#divmodalmsg1').show();
                }
                return false;
            }
            else {

                return false;
            }
        }
    </script>
</asp:Content>

