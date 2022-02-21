<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ForegetPassword.aspx.cs" Inherits="ForegetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="page_banner"></div>

    <div class="breadcrumbs1_wrapper">
        <div class="container">
            <div class="breadcrumbs1"><a href="index.html">الرئيسية</a><span>/</span>نسيت كلمة المرور</div>
        </div>
    </div>

    <div id="main">
        <div id="content">
            <div class="container">

                <div class="row" style="direction:rtl;">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-6">
                        <h3> نسيت كلمة المرور </h3>
                        <div id="fields">
                            <form id="ajax-contact-form" class="form-horizontal" >
                                <div class="login-box">
                                    <div class="form-group" style="margin: 10px; text-align: right" id="divmodalmsg" runat="server" visible="false"></div>
                                    <div style="display: none" class="spinner" id="divmodalspin"></div>
                                    <div class="form-group">
                                        <label for="inputName">إدخال بريدك الالكتروني</label>
                                        <%-- <input type="text" class="form-control" ng-model="emailID" id="txtemail" placeholder="البريد الإلكتروني " required=""
                                       onBlur="if(this.value=='') this.value='البريد الإلكتروني '"
                                       onFocus="if(this.value =='البريد الإلكتروني ' ) this.value=''">--%>

                                        <asp:TextBox ID="txtEmail" runat="server" placeholder="البريد الإلكتروني " autocomplete="off" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="forget" runat="server" ControlToValidate="txtEmail" CssClass="text-danger" SetFocusOnError="true" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                                ErrorMessage="يرجى كتابة عنوان الإيميل"
                                                ControlToValidate="txtEmail" CssClass="text-danger" Display="dynamic"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                ValidationGroup="forget"></asp:RegularExpressionValidator>
                                    </div>

                                    <%-- <button type="submit" class="btn-default btn-cf-submit" ng-click="OnClickForgetPWD(UserName,Password);">تسجيل الدخول</button>--%>
                                    <asp:LinkButton ID="lnkSubmit" runat="server" CssClass="btn-default btn-cf-submit" Text="تسجيل الدخول" OnClick="lnkSubmit_Click" ValidationGroup="forget"></asp:LinkButton>
                                   <%-- <span class="text-danger" style="color: red">{{ erroMessage }}</span>--%>
                            </form>
                        </div>
                    </div>
                    <div class="col-sm-3"></div>
                </div>
            </div>
        </div>

    </div>




    <script type="text/javascript">
        function OnBlur() {
            document.getElementById("lnkHidden").click();
        };
    </script>


</asp:Content>

