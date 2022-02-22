<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteMasterPage.master" CodeFile="thankyou.aspx.cs" Inherits="thankyou" %>

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



     <section>
        <div class="container-fluid">
            <div class="container">

                <div class="text-center mt-50">
                    <h3>شكراً لك </h3>

                </div>

                <hr />


                <div class="bg-white">
                   
                        <div class="row" ">

                            <div class="col-lg-12  col-xs-12 col-sm-12 text-right">
                             

                                
                                  
                                   
                              
                                     <div style="color: #2E5E04; padding: 15px; margin-top: 15px; margin-bottom: 15px; text-align: center; font-size: 1.3em; background: #CAF1CA; border-radius: 5px;">
                                تم استلام طلبك بنجاح 
                        <br />
                              <%--  رقم المرجع الخاص بك هو   --%> 
                        <asp:Label ID="r_id" runat="server" Style="font-family: Verdana; color: red; text-decoration: underline" Visible="false"></asp:Label>
                                سيتم التواصل معك قريباً
                            </div>


                         

                            <div style="text-align:center;">
                               
                                <asp:Button runat="server" class="btn btn-info" ID="btback" Text="عودة" PostBackUrl="~/Index_AR.aspx"  />      
                                <br />
                                  <br />
                                <!--Form END-->
                            </div>

                                
                            </div>

                        </div>
                    
                </div>
            </div>
            </div>
    </section>



</asp:Content>

