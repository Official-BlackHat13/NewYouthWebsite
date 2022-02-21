<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="Thankyou.aspx.cs" Inherits="YCLC_Thankyou" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        @media (max-width:762px) {
            .container-fluid, .container {
                padding: 2px !important;
            }

            .row {
                margin: 0px !important;
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PageContent" runat="Server">

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

        <div class="container-fluid">
            <div class="container">

                 <div class="text-center mt-50">
            <h2>Thank You</h2>
            
        </div>
                  <hr />

                <div class=" bg-white">
            
                        <div class="row" dir="rtl">
                            <div class="col-xs-12 col-sm-12 text-right">                               
                                

                                   <div style="color: #2E5E04; padding: 15px; margin-top: 15px; margin-bottom: 15px; text-align: center; font-size: 1.3em; background: #CAF1CA; border-radius: 5px;" runat="server" id="DivWaiting">
                                        شكرا جزيلا ، لقد تم تسجيلك بنجاح ،انت في قائمة الإنتظار لدوري الإبداع الشبابي حاليا .
                        <br />
                                        سيتم التواصل معك في أقرب وقت<br />
                                       

                                    </div>                                   

                                        
                                    <div style="color: #2E5E04; padding: 15px; margin-top: 15px; margin-bottom: 15px; text-align: center; font-size: 1.3em; background: #CAF1CA; border-radius: 5px;" runat="server" id="DivNormal">
                                        تم الانتهاء من أجراءات تسجيل التدريب لمسابقات دوري الابداع الشبابي
                        <br />
                                        سيتم التواصل معك في أقرب وقت<br />
                                       

                                    </div>                                  


                                    <div class="form-group">
                                        <div class="col-sm-3"></div>
                                        <div class="col-sm-3">



                                            <asp:Button ID="btPrint" runat="server" class="btn btn-success" Visible="false" Text="Print Your Badge" OnClick="btPrint_Click" />
                                        </div>
                                    </div>



                                    <div class="form-group">
                                        <div class="col-sm-3"></div>
                                        <div class="col-sm-3">

                                            <asp:Button ID="btnBack" runat="server" class="btn btn-info" Text="اغلاق" OnClick="btnBack_Click" />
                                        </div>
                                    </div>

                                    <br />

                            </div>
                        </div>                  
                </div>
            </div>
        </div>
  


   
</asp:Content>


