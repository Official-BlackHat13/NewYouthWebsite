<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteMasterPage.master" CodeFile="thankyou.aspx.cs" Inherits="thankyou" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">

     <section>
        <div class="container-fluid">
            <div class="container py-5">
                <div class="container bg-white">
                    <div class="container new-services">
                        <div class="row" dir="rtl">
                            <div class="col-xs-12 col-sm-12 text-right">
                               

                                <div class="heading-bg">
                                    <h1 class="form-style">شكراً لك</h1>
                                </div>


                                <div class="col-lg-12 col-xs-12 form-bg1">

                                    <div style="color: #2E5E04; padding: 15px; margin-top: 15px; margin-bottom: 15px; text-align: center; font-size: 1.3em; background: #CAF1CA; border-radius: 5px;">
                             شكرا لكم .. تمت اضافة المبادر المحترف بنجاح
                        <br />
                                سيتم الاتصال بكم لاحقا 
                             
                            </div>


                            <div style="text-align:center;">
                               
                                <asp:Button runat="server" class="btn btn-info" ID="btback" Text="عودة" OnClick="btback_Click" />
                                <br />
                                  <br />
                                <!--Form END-->
                            </div>


                                 </div>

                                 <div class="heading-f-bg""></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>






    <div class="breadcrumb breadcrumb__t">
        <div class="cap">شكراً لك</div>
    </div>
    <div class="cont col-lg-12">
        <div class="features_sec29">
            <div class="row">
                <div class="col-md-3"></div>
                <div class="col-md-6">
                    <div class="ContainerAR">
                        <div class="cont col-xs-12">
                            

                        </div>
                    </div>
                </div>
                <div class="col-md-3"></div>
            </div>
        </div>
    </div>
</asp:Content>

