<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="page_banner"></div>

    <div class="breadcrumbs1_wrapper">
        <div class="container">
            <div class="breadcrumbs1"><a href="index.aspx">الرئيسية</a><span>/</span> تسجيل الدخول </div>
        </div>
    </div>

    <div id="main" style="margin: 0px;">
        <div id="content">
            <div class="container">

                <div class="row">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-6">
                        <h3>تسجيل الدخول </h3>
                        <div id="fields">
                            <div id="ajax-contact-form" class="form-horizontal">
                                <div class="login-box">
                                    <div class="form-group" style="margin: 10px; text-align: right" id="divmodalmsg" runat="server" visible="false"></div>
                                    <div style="display: none" class="spinner" id="divmodalspin"></div>
                                    <div class="form-group">
                                        <label for="inputName">اسم المستخدم </label>
                                        <asp:TextBox ID="txtusername" runat="server" ValidationGroup="personalInfo " placeholder="اسم المستخدم " ReadOnly="False" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rqdEmail" runat="server"
                                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtusername"
                                            CssClass="text-danger"
                                            ValidationGroup="personalInfo" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail">Password</label>
                                        <asp:TextBox ID="txtpwd" runat="server" alidationGroup="personalInfo" AutoCompleteType="Disabled" TextMode="Password" placeholder="كلمة المرور " CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="txtPasswordValidator1" runat="server" Display="Dynamic"
                                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtpwd" CssClass="text-danger" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                    </div>
                                    <div>
                                        <asp:Button ID="btnUserLogin" runat="server" class="btn-default btn-cf-submit" Text="تسجيل الدخول" ValidationGroup="personalInfo" OnClick="btnUserLogin_Clicked" />

                                        <asp:Label class="text-danger" runat="server" Style="color: red" ID="lblError"></asp:Label>
                                    </div>
                                    <div style="margin-top: .5cm;">
                                       <a href="Register.aspx" class="btn-default btn-cf-submit"> تسجيل مستخدم جديد </a>
                                    </div>
                                    <div style="margin-top: .5cm;">
                                       <%-- <button type="submit" class="btn-default btn-cf-submit" >نسيت كلمة المرور </button>--%>
                                        <a href="ForegetPassword.aspx" class="">نسيت كلمة المرور?</a>
                                       <%-- <span class="text-danger" style="color: red"></span>--%>
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>
                    <div class="col-sm-3"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

