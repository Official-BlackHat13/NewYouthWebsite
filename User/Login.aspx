<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style>
        @media (max-width:768px) {
            .user-forgot-pass {
                display: block !important;
                text-align: right !important;
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



    <div class="container">

        <div class="text-center mt-50">
            <h3>تسجيل الدخول </h3>

        </div>

        <hr />


        <div class="bg-white text-right">


            <div class="form-group">
                <div class="row" style="direction: rtl;">
                    <div class="col-xs-12 col-sm-2">
                        <label class="control-label">اسم المستخدم / البريد الالكتروني</label>
                    </div>

                    <div class="col-xs-12 col-sm-6 col-xs-12">
                        <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="personalInfo " ReadOnly="False" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqdEmail" runat="server"
                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtEmail"
                            CssClass="red"
                            ValidationGroup="personalInfo" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="clear"></div>


            </div>

            <div class="form-group">
                <div class="row" style="direction: rtl;">
                    <div class="col-xs-12 col-sm-2">
                        <label class="control-label">كلمة المرور</label>
                    </div>

                    <div class="col-xs-12 col-sm-6">
                        <asp:TextBox ID="txtPassowrd" runat="server" alidationGroup="personalInfo" AutoCompleteType="Disabled" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtPasswordValidator1" runat="server" Display="Dynamic"
                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtPassowrd" CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                    </div>
                </div>



                <div class="row" style="direction: rtl; margin-top: 18px;">

                    <div class="col-xs-12 col-sm-3 col-12">

                        <span class="user-forgot-pass mt-2" style="position: absolute; left: 0;">
                            <a href="Register_AR.aspx" class="modal-opener ">تسجيل جديد </a>
                        </span>

                    </div>

                    <div class="col-xs-12 col-sm-8 text-center">

                        <span class="user-forgot-pass mt-2">
                            <a href="Forgot.aspx" class="tab-title">هل نسيت كلمة المرور او اسم المستخدم ؟ </a>

                        </span>
                    </div>

                </div>
            </div>

            <hr />

            <div class="form-group">

                <div class="text-center">
                    <asp:Button ID="btnUserLogin" runat="server" class="btn btn-info" Text="الدخول" ValidationGroup="personalInfo" OnClick="btnUserLogin_Clicked" />

                    <asp:Button ID="btnnewlogin" runat="server" class="btn btn-info" Text="Test" ValidationGroup="personalInfo" OnClick="btnnewlogin_Click" />
                </div>
            </div>


        </div>
    </div>




</asp:Content>


