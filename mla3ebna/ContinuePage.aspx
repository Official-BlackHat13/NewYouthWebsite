<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ContinuePage.aspx.cs" Inherits="Mubaratna2021_ContinuePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
      <div class="page_banner"></div>

    <div class="breadcrumbs1_wrapper">
        <div class="container">
            <div class="breadcrumbs1"><a href="index.html">الرئيسية</a></div>
        </div>
    </div>


    <div id="main">     


        <div id="content">
            <div class="container">

                <div class="row" style="direction:rtl;">

                  <div class="col-sm-2"></div>
                    <div class="col-sm-8">


                         <div id="Div1">
                            <div id="ajax-contact-form3" class="form-horizontal" >
                      
                        <div id="fields">
                            <div id="ajax-contact-form" class="form-horizontal">
                              
                                <div class="row">

                                    <div class="col-md-12">
                                        <div class="alert alert-success ">
                                   <h4 class="text-right"> مرحبا بك في ملاعبنا</h4>
                                    <h5 class="text-right"> شكرا جزيلا لقد تم تسجيلك بنجاح</h5>

                                            </div>

                                                <div class="controls">
                                    <div class="row">
                                        <div class="col-md-4 col-12">
                                            <div class="form-group">
                                                <asp:LinkButton ID="lnkContinue" runat="server" CssClass="btn-default btn-cf-submit" Text="الصفحة الرئيسية" ValidationGroup="contact" OnClick="lnkContinue_Click"></asp:LinkButton>
                                            </div>
                                        </div>
                                        <div class="col-md-4 col-12">
                                            <div class="form-group">
                                                <asp:LinkButton ID="lnkLogin" runat="server" CssClass="btn-default btn-cf-submit" Text="تسجيل الدخول" ValidationGroup="contact" OnClick="lnkLogin_Click"></asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>



                                    </div>





                                </div>
                        



                            </div>
                        </div>
                                </div>
                             </div>


                    </div>
                </div>


            </div>
        </div>

    </div>




</asp:Content>

