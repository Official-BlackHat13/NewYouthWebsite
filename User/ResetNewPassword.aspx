<%@ Page Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="ResetNewPassword.aspx.cs" Inherits="User_ResetNewPassword" %>

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
                                CssClass="text-danger"
                                ValidationGroup="personalInfo" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                ErrorMessage="يرجى كتابة عنوان الإيميل"
                                ControlToValidate="txtEmail" CssClass="text-danger" Display="dynamic"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ValidationGroup="personalInfo"></asp:RegularExpressionValidator>
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
                                ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtPassowrd" CssClass="text-danger" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="regular" runat="server"
                                ControlToValidate="txtPassowrd" ErrorMessage="Password must be atleast 6 characters long and only English alphanumeric allowed " Display="Dynamic"
                                ValidationExpression="^[a-zA-Z0-9@#$%&*+\-_(),+':;?.,!\[\]\s\\/]{6,}$" CssClass="text-danger " SetFocusOnError="true" ValidationGroup="personalInfo"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="clear"></div>


                </div>

                <div class="form-group">
                    <div class="row" style="direction: rtl;">
                        <div class="col-xs-12 col-sm-2">
                            <label class="control-label">Confirm Password</label>
                        </div>

                        <div class="col-xs-12 col-sm-6">
                            <asp:TextBox ID="txtconfirmpassword" runat="server" alidationGroup="personalInfo" AutoCompleteType="Disabled" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtconfirmpassword" CssClass="text-danger" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic"
                                ControlToCompare="txtPassowrd"
                                ControlToValidate="txtconfirmpassword"
                                ErrorMessage=" كلمة المرور لم تطابق" CssClass="text-danger" ValidationGroup="personalInfo"></asp:CompareValidator>
                        </div>
                    </div>

                  <%--  <div class="row" style="direction: rtl; margin-top: 18px;">

                        <div class="col-xs-12 col-sm-3 col-12">

                            <span class="user-forgot-pass mt-2" style="position: absolute; left: 0;">
                                <a href="Register_AR.aspx" class="modal-opener ">تسجيل جديد </a>
                            </span>

                        </div>



                    </div>--%>
                </div>
              
                <div class="form-group">
                     <div class="row" style="direction: rtl; margin-top: 18px;margin-bottom:50px;">

                        <div class="col-xs-12 col-sm-3 col-12">

                            <span class="user-forgot-pass mt-2" style="position: absolute; left: 0;">
                                <a href="Register_AR.aspx" class="modal-opener ">تسجيل جديد </a>
                            </span>

                        </div>



                    </div>
                </div>

                <hr />

                <div class="form-group">

                    <div class="text-center">
                        <asp:Button ID="btnUserLogin" runat="server" class="btn btn-info" Text="الدخول" ValidationGroup="personalInfo" OnClick="btnUserLogin_Clicked" />
                    </div>
                </div>



            </div>


    </div>
</asp:Content>


