<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteMasterPage.master" CodeFile="thankyou.aspx.cs" Inherits="thankyou" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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


  
        <div class="container-fluid">
            <div class="container text-center">
                 <div class="text-center mt-50">
                    <h3> شكراً لك </h3>

                </div>

                <hr />

                <div class="bg-white">
                   
                        <div class="row" ">
                            <div class="col-xs-12 col-sm-12 text-right">
                               


                             

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
                        </div>
                    
                </div>
            </div>
        </div>
   

</asp:Content>

