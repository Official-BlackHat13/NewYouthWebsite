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
    </section>

</asp:Content>


