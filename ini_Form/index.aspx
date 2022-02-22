<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="ini_Form_index" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .tab-content {
            background-color: #1c89b8;
            border: 5px solid #69c0e5;
            padding: 0 0 0px 0;
            margin: -60px 20px 20px 20px;
            box-shadow: 5px 10px 2px #c7c7c7;
        }

            .tab-content a {
                width: 100% !important;
                text-align: center !important;
                background-color: #d2e7f1;
                color: #1c89b8;
            }

        .tab-pane p {
            color: #fff !important;
        }

        p {
            margin-top: 0 !important;
            margin-bottom: 1rem !important;
            text-align: justify !important;
            direction: rtl !important;
            padding: 5px;
        }

        .tab-content .enquiry-info {
            background-color: #6bb2d1;
            padding: 5px;
            color: #fff;
            text-align: center;
            margin-left: 10%;
        }

        .tab-pane {
            padding: 56px 20px 20px 20px;
            color: #fff;
        }

        body {
            font-family: 'Neo Sans Arabic';
        }

        .mt-3 {
            margin-top: 30px;
        }

        .domains-sec {
            background-color: #d64e44;
            border: 5px solid #df8f89;
            padding: 10px 20px;
        }

        .list-domains ul li {
            margin: 0 4.5px;
        }

        .list-domains {
            background-color:#f8dcdb;
        }
        .list-domains ul li a.culture {
            width: 68px;
            height: 141px;
            background: url(../images/culture.gif) top left no-repeat;
            display: block;
            text-indent: -99999px;
        }

        .list-domains ul li a {
            cursor: initial !important;
            margin
        }

            .list-domains ul li a:hover {
                opacity: 0.5 !important;
                background-color: white !important;
            }

        a {
            text-decoration: none !important;
        }

        .tab-pane ul li {
            list-style-type: none;
            display: inline-block;
            /*margin: 20px;*/
        }

        .list-domains ul li {
            list-style-type: none;
            width: 68px;
            height: 141px;
            display: inline-block;
        }

        .tab-pane ul li {
            list-style-type: none;
            display: inline-block;
            /*margin: 20px;*/
        }

        .list-domains ul li a.education {
            width: 68px;
            height: 141px;
            background: url(../assets/images/education.gif) top left no-repeat;
            display: block;
            text-indent: -99999px;
        }

        .list-domains ul li a.advertising {
            width: 68px;
            height: 141px;
            background: url(../assets/images/advertising.gif) top left no-repeat;
            display: block;
            text-indent: -99999px;
        }

        .list-domains ul li a.culture {
            width: 68px;
            height: 141px;
            background: url(../assets/images/culture.gif) top left no-repeat;
            display: block;
            text-indent: -99999px;
        }

        .list-domains ul li a.power {
            width: 68px;
            height: 141px;
            background: url(../assets/images/power.gif) top left no-repeat;
            display: block;
            text-indent: -99999px;
        }

        .list-domains ul li a.islamic-law {
            width: 68px;
            height: 141px;
            background: url(../assets/images/islamic-law.gif) top left no-repeat;
            display: block;
            text-indent: -99999px;
        }

        .list-domains ul li a.energy {
            width: 68px;
            height: 141px;
            background: url(../assets/images/energy.gif) top left no-repeat;
            display: block;
            text-indent: -99999px;
        }

        .list-domains ul li a.research {
            width: 68px;
            height: 141px;
            background: url(../assets/images/research.gif) top left no-repeat;
            display: block;
            text-indent: -99999px;
        }

        .list-domains ul li a.business {
            width: 68px;
            height: 141px;
            background: url(../assets/images/business.gif) top left no-repeat;
            display: block;
            text-indent: -99999px;
        }

        .list-domains ul li a.urban-development {
            width: 68px;
            height: 141px;
            background: url(../assets/images/urban-development.gif) top left no-repeat;
            display: block;
            text-indent: -99999px;
        }

        .list-domains ul li a.technology {
            width: 68px;
            height: 141px;
            background: url(../assets/images/technology.gif) top left no-repeat;
            display: block;
            text-indent: -99999px;
        }

        .list-domains ul li a.awareness {
            width: 68px;
            height: 141px;
            background: url(../assets/images/awareness.gif) top left no-repeat;
            display: block;
            text-indent: -99999px;
        }

        .list-domains ul li a.arts {
            width: 68px;
            height: 141px;
            background: url(../assets/images/arts.gif) top left no-repeat;
            display: block;
            text-indent: -99999px;
        }

        .list-domains ul li a.environment {
            width: 68px;
            height: 141px;
            background: url(../assets/images/environment.gif) top left no-repeat;
            display: block;
            text-indent: -99999px;
        }

        .list-domains ul li a.health {
            width: 68px;
            height: 141px;
            background: url(../assets/images/health.gif) top left no-repeat;
            display: block;
            text-indent: -99999px;
        }

        .list-domains ul li a.sports {
            width: 68px;
            height: 141px;
            background: url(../assets/images/sports.gif) top left no-repeat;
            display: block;
            text-indent: -99999px;
        }

        .domain-h3 {
            color: #fff;
            text-align: right;
        }

       
        .input-group-text {
            background-color: #1a88b8;
            color: #fff;
            border: 1px solid #1a88b8;
        }

        .input-group-text {
            margin-left: -4px;
        }

        .btn {
            border-radius: 5px 5px 5px 5px !important;
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




    
      
            <div class="container ">
                 <div class="text-center mt-50">
                    <h3> نظرة عامة </h3>

                </div>

                <hr />


              
                  
                        <div class="row">
                            <div class="col-xs-12 text-right">
                               
                                <div class="col-lg-12 col-xs-12 ">
                                    <div class="tab-content  px-3 px-sm-0 innerTab" id="nav-tabContent" style="margin: 3px -1px 7px -7px">
                                        <div class="tab-pane  show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">


                                            <div class="row">
                                                <div class="col-md-4 pr-5">
                                                    <div id="site-searchform">
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <p class="text-right">للاستعلام عن طلبك أدخل الرقم المرجعي</p>
                                                                <div class="md-form form-sm form-1 pl-0">
                                                                    

                                                                    <asp:LinkButton ID="searchsubmit" OnClick="btnsearch_Click" ValidationGroup="inquiryAR" CausesValidation="false" runat="server" CssClass="input-group-text search-clr" ClientIDMode="Static"></asp:LinkButton>

                                                                    
                                                                    <asp:TextBox runat="server" ID="s"   MaxLength="12" CssClass="form-control my-0 py-1" ClientIDMode="Static" placeholder="Search" aria-label="Search"></asp:TextBox>


                                                                    <div class="req" style="display: block; width: 100%; color: red;">
                                                                        <asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>

                                                                    </div>

                                                                </div>
                                                                <div class="panel" id="search_results" runat="server">
                                                                    <asp:Label runat="server" ID="lblsearch"></asp:Label>
                                                                </div>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                    <a href="list_of_initiative.aspx" class="btn mt-3">المشاريع والفعاليات التي تمت الموافقة عليها </a>

                                                    <asp:LinkButton ID="lnkedit" runat="server" CssClass="btn mt-3 " OnClick="lnkedit_Click"> مشاهدة الملف الشخصي  </asp:LinkButton>

                                                </div>

                                                <div class="col-md-4 mt-30">
                                                    <asp:LinkButton runat="server" ID="btRegister" OnClick="btRegister_Click" CssClass="btn"><strong> تقديم المبادرة </strong> </asp:LinkButton>


                                                   </div>
                                              

                                                <div class="col-md-4 mt-30">

                                                    <div class="enquiry-info">
                                                        <p>
                                                            للاستعلام عن المبادرات<br />
                                                          <%--  134--%>
                                                            <br />
                                                            mubadarat@youth.gov.kw
                                                        </p>
                                                    </div>

                                                </div>


                                            </div>
                                            <br />
                                        
                                            <div class="domains-sec mt-4">
                                                <!--Domains section-->

                                                <div class="row px-3 py-2">

                                                    <div class="col-md-12">
                                                        <h3 class="domain-h3">المجالات</h3>
                                                    </div>
                                                </div>

                                                <div class="row py-2">
                                                    <div class="list-domains">
                                                        <ul>
                                                            <li><a href="#" class="education" title="education"></a></li>
                                                            <li><a href="#" class="advertising" title="advertising"></a></li>
                                                            <li><a href="#" class="culture" title="culture"></a></li>
                                                            <li><a href="#" class="energy" title="Energy"></a></li>
                                                            <li><a href="#" class="islamic-law" title="islamic-law"></a></li>
                                                            <li><a href="#" class="research" title="Research"></a></li>
                                                            <li><a href="#" class="business" title="Business"></a></li>
                                                            <li><a href="#" class="urban-development" title="urban-development"></a></li>
                                                            <li><a href="#" class="technology" title="Technology"></a></li>
                                                            <li><a href="#" class="awareness" title="Awareness"></a></li>
                                                            <li><a href="#" class="arts" title="Arts"></a></li>
                                                            <li><a href="#" class="environment" title="Environment"></a></li>
                                                            <li><a href="#" class="health" title="Health"></a></li>
                                                            <li><a href="#" class="sports" title="Sports"></a></li>
                                                        </ul>


                                                    </div>

                                                </div>

                                            </div>
                                            <!--/ Domain sections ends-->

                                        </div>

                                    </div>


                                </div>
                                <div class="heading-f-bg"></div>
                            </div>
                        </div>
                    
                </div>
   
   
</asp:Content>

