<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="thankEdit.aspx.cs" Inherits="YPI_thankEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>

        .heading-bg {
            margin-top:120px;
        }
        .form-style {
            background:none;
            margin-bottom:20px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PageContent" Runat="Server">
    
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
                    <h3> شكراً لك </h3>

                </div>

                <hr />



                <div class="container bg-white">
                    <div class="container new-services">
                        <div class="row">
                            <div class="col-xs-12 col-sm-12 text-right">
                              

                                  <div class="col-lg-12 col-xs-12 form-bg1">
                                      <div style="color: #2E5E04; padding: 15px; margin-top: 15px; margin-bottom: 15px; text-align: center; font-size: 1.3em; background: #CAF1CA; border-radius: 5px;">
                              <%--Thank you.--%>
                                          شكرا لك للمشاركة في الاستبيان
                            </div>


                            <div class="clear"></div>
                                  </div>

                                  <div>

                                        <asp:Button runat="server" class="btn btn-info" ID="btback" Text="عودة" OnClick="btback_Click" />


                                    </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
  

</asp:Content>


