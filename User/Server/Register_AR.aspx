<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="Register_AR.aspx.cs" Inherits="User_Register_AR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .GenderRadio  input[type=radio]
        {
            margin-right:24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    
    <div class="container-fluid">
        <div class="container py-5 mt-110 inside-page">
            <div class="container bg-white">
                <div class="container new-services">
                    <div class="row">
                        <div class="col-xs-12 text-right">
                           
                            <div class="col-lg-12 col-xs-12 form-bg1">
                             <div class="heading-bg">
                                <h1 class="form-style">التسجيل</h1><div class="line"></div>
                                </div>
                            
                              <%--  <div class="col-sm-12" style="background: #fff; border: solid 1px #ededed; border-radius: 5px; margin-bottom: 15px; padding: 10px;">
                                    <h1 style="margin: 0px;">للدخول الى حسابك  </h1>
                                    <div class="btn-login" style="margin: 0 0 0 3px;"><a href="Login.aspx" class="btn-login"><span>دخول</span></a> </div>
                                    <div class="clear"></div>
                                </div>--%>
                                <div class="clearfix"></div>

                                <br />
                                <div class="form-horizontal">
                                    <div id="alertEmail" class="alert alert-danger" runat="server" visible="false">
                                        <p>البريد الالكتروني مسجل لدينا من قبل ، اذا نسيت اسم المستخدم او كلمة المرور الرجاء الذهاب إلى صفحة تسجيل الدخول و إضغط على نسيت كلمة المرور او إسم المستخدم</p>
                                    </div>
                                    <div id="alertCivil" class="alert alert-danger" runat="server" visible="false">
                                        <p>الرقم المدني مسجل لدينا من قبل ، اذا نسيت اسم المستخدم او كلمة المرور الرجاء الذهاب إلى صفحة تسجيل الدخول و إضغط على نسيت كلمة المرور او إسم المستخدم</p>
                                    </div>
                                    <div class="form-group">

                                        <div class="row" style="direction: rtl;">
                                            <div class="col-sm-2 col-xs-12">
                                                <label class="control-label">الاسم (حسب البطاقة المدنية)  <span class="mandatory">*</span> </label>
                                            </div>

                                            <div class="col-sm-2 col-xs-12 ">
                                                <asp:TextBox ID="txtName" Style="margin-bottom: 5px;" runat="server" CssClass="form-control" placeholder="الأول"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="txtNameValidator" runat="server" Display="Dynamic"
                                                    ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtName"
                                                    CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator27" ControlToValidate="txtName" CssClass="red"
                                                    ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                    ValidationGroup="personalInfo"> </asp:RegularExpressionValidator>

                                            </div>
                                            <div class="col-sm-2 col-xs-12">
                                                <asp:TextBox ID="txtMname" Style="margin-bottom: 5px;" runat="server" CssClass="form-control" placeholder="الثاني"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                    ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtMname"
                                                    CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator3" ControlToValidate="txtMname" CssClass="red"
                                                    ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                    ValidationGroup="personalInfo"> </asp:RegularExpressionValidator>
                                            </div>
                                            <div class="col-sm-2 col-xs-12 ">
                                                <asp:TextBox ID="txtTname" Style="margin-bottom: 5px;" runat="server" CssClass="form-control" placeholder="الثالث"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                                    ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtTname"
                                                    CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator5" ControlToValidate="txtTname" CssClass="red"
                                                    ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                    ValidationGroup="personalInfo"> </asp:RegularExpressionValidator>


                                            </div>
                                            <div class="col-sm-2 col-xs-12 ">
                                                <asp:TextBox ID="txtLname" Style="margin-bottom: 5px;" runat="server" CssClass="form-control" placeholder="الأخير"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                                    ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtLname"
                                                    CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator7" ControlToValidate="txtLname" CssClass="red"
                                                    ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                    ValidationGroup="personalInfo"> </asp:RegularExpressionValidator>
                                            </div>



                                        </div>
                                        <div class="clear"></div>
                                        <div class="req">
                                            <div class="col-sm-9">
                                                <div class="col-sm-4"></div>
                                                <div class="col-sm-2">
                                                </div>
                                                <div class="col-sm-2">
                                                </div>
                                                <div class="col-sm-2">
                                                </div>
                                                <div class="col-sm-2">
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                        <ContentTemplate>
                                            <div class="form-group">
                                                <div class="row" style="direction: rtl;">
                                                    <div class="col-sm-2">
                                                        <label class="control-label">الرقــم المـدني: <span class="mandatory">*</span> </label>
                                                    </div>

                                                    <div class="col-sm-8">
                                                        <asp:TextBox ID="txtCivil" runat="server" MaxLength="12" ValidationGroup="personalInfo" OnTextChanged="txtCivil_TextChanged" AutoPostBack="true" CssClass="form-control"> </asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="clear"></div>


                                                <div class="req">

                                                    <div class="col-sm-6">
                                                        <asp:RequiredFieldValidator ID="rqdCivil" runat="server"
                                                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtCivil"
                                                            CssClass="red" Display="Dynamic"
                                                            ValidationGroup="personalInfo" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator
                                                            EnableClientScript="true"
                                                            ID="RegularExpressionValidator1" runat="server"
                                                            ErrorMessage="البطاقة المدنية يجب ان تكون 12 رقم فقط!"
                                                            ValidationGroup="personalInfo"
                                                            ControlToValidate="txtCivil" Display="dynamic"
                                                            ValidationExpression="^[0-9,٠-٩]{12}$"
                                                            CssClass="red" SetFocusOnError="true" />
                                                        <asp:Label ID="lblCivil" runat="server" Visible="false" SetFocusOnError="true" Text="الرقم المدني غير صحيح" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="Div1" class="form-group" runat="server" visible="false">
                                                <label class="control-label col-sm-3">تاريخ الميلاد:</label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="datepicker" runat="server" ValidationGroup="personalInfo" AutoCompleteType="Disabled" Enabled="false" CssClass="form-control"></asp:TextBox>

                                                </div>
                                                <div class="clear"></div>

                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                    <div class="form-group">

                                        <div class="row" style="direction: rtl;">
                                            <div class="col-sm-2">
                                                <label class="control-label">صورةالبطاقة المدنية: </label>
                                            </div>
                                            <div class="col-sm-8 col-xs-12">
                                                <asp:FileUpload ID="fbCiviID" runat="server" CssClass="form-control input-rounded" ClientIDMode="Static" onchange="showpreview(fbCiviID);" />
                                            </div>
                                        </div>
                                        <div class="clear"></div>
                                        <div class="req">

                                            <div class="col-sm-6">
                                            <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="fbCiviID"
                                                    CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                    ValidationGroup="personalInfo">
                                                </asp:RequiredFieldValidator>--%>
                                                <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                                    ErrorMessage="Only .pdf files are allowed." CssClass="red"
                                    ValidationExpression="^.*\.(pdf|PDF)$"
                                    ControlToValidate="fbCiviID" Display="Dynamic" SetFocusOnError="true" ValidationGroup="personalInfo"></asp:RegularExpressionValidator>--%>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                                                    ErrorMessage="Only .pdf/.png/.jpg/.jepg/.gif files are allowed." CssClass="red"
                                                    ValidationExpression="^.*\.(pdf|PDF|png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF)$"
                                                    ControlToValidate="fbCiviID" Display="Dynamic" SetFocusOnError="true" ValidationGroup="personalInfo"></asp:RegularExpressionValidator>

                                            </div>

                                        </div>

                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="row" style="direction: rtl;">
                                        <div class="col-sm-2">
                                            <label class="control-label">البريد الإلكتروني: <span class="mandatory">*</span></label>
                                        </div>

                                        <div class="col-sm-8 col-xs-12">
                                            <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="personalInfo " ReadOnly="False" CssClass="form-control"></asp:TextBox>

                                              <asp:RequiredFieldValidator ID="rqdEmail" runat="server"
                                                ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtEmail"
                                                CssClass="red"
                                                ValidationGroup="personalInfo" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                                ErrorMessage="يرجى كتابة عنوان الإيميل"
                                                ControlToValidate="txtEmail" CssClass="red" Display="dynamic"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                ValidationGroup="personalInfo"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <div class="clear"></div>
                                    <div class="req">

                                        <div class="col-sm-6">
                                          
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="row" style="direction: rtl;">
                                        <div class="col-sm-2">
                                            <label class="control-label">أعد إدخال البريد الالكتروني : <span class="mandatory">*</span></label>
                                        </div>
                                        <div class="col-sm-8 col-xs-12">
                                            <asp:TextBox ID="TxtEmailCompare" runat="server" ValidationGroup="personalInfo " ReadOnly="False" CssClass="form-control"></asp:TextBox>

                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                ErrorMessage="مطلوب هذه الخانة" ControlToValidate="TxtEmailCompare"
                                                CssClass="red"
                                                ValidationGroup="personalInfo" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server"
                                                ErrorMessage="يرجى كتابة عنوان الإيميل"
                                                ControlToValidate="TxtEmailCompare" CssClass="red" Display="dynamic"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                ValidationGroup="personalInfo"></asp:RegularExpressionValidator>


                                            <asp:CompareValidator ID="CompareValidator2" runat="server" Display="Dynamic"
                                                ControlToCompare="txtEmail"
                                                ControlToValidate="TxtEmailCompare"
                                                ErrorMessage="البريد الإلكتروني غير مطابق " CssClass="red" ValidationGroup="personalInfo"></asp:CompareValidator>
                                        </div>
                                    </div>
                                    <div class="clear"></div>
                                    <div class="req">

                                        <div class="col-sm-6">
                                           
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="row" style="direction: rtl;">
                                        <div class="col-sm-2">
                                            <label class="control-label">رقم الهاتف : <span class="mandatory">*</span></label>
                                        </div>

                                        <div class="col-sm-8 col-xs-12">
                                            <asp:TextBox ID="txtContactNo" MaxLength="8" runat="server" ValidationGroup="personalInfo" CssClass="form-control"></asp:TextBox>

                                               <asp:RequiredFieldValidator ID="rqdContactnumber" runat="server" Display="Dynamic"
                                                ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtContactNo"
                                                CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator
                                                EnableClientScript="true"
                                                ID="RegularExpressionValidator2" runat="server"
                                                ErrorMessage="رقم الهاتف يجب ان يكون 8 ارقام!"
                                                ValidationGroup="personalInfo"
                                                ControlToValidate="txtContactNo" Display="dynamic"
                                                ValidationExpression="^[0-9,٠-٩]{8}$"
                                                CssClass="red" />
                                        </div>
                                    </div>
                                    <div class="clear"></div>
                                    <div class="req">
                                        <div class="col-sm-3"></div>
                                        <div class="col-sm-6">
                                         
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="row" style="direction: rtl;">
                                        <div class="col-sm-2">

                                            <label class="control-label">الجنس:<span class="mandatory">*</span></label>
                                        </div>

                                        <div class="col-sm-2  GenderRadio">
                                            <asp:RadioButtonList runat="server" ID="gender" RepeatDirection="Horizontal" RepeatLayout="Flow" style="display:inline-block;">
                                                <asp:ListItem Text="ذكر " Value="ذكر" ></asp:ListItem>
                                                <asp:ListItem Text=" أنثى " Value="أنثى"></asp:ListItem>
                                            </asp:RadioButtonList>
                                                <asp:RequiredFieldValidator ID="rqdGender" runat="server" ErrorMessage="مطلوب هذه الخانة"
                                                ControlToValidate="gender" CssClass="red" Display="Dynamic"
                                                ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="req">
                                        <div class="col-sm-3"></div>
                                        <div class="col-sm-6">
                                        
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="row" style="direction: rtl;">
                                        <div class="col-sm-2">
                                            <label class="control-label">كلمة المرور: <span class="mandatory">*</span></label>
                                        </div>

                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txtPassword" runat="server" ValidationGroup="personalInfo" AutoCompleteType="Disabled" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="txtPasswordValidator1" runat="server" Display="Dynamic"
                                                ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtPassword" CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="regular" runat="server"
                                                ControlToValidate="txtPassword" ErrorMessage="Password must be atleast 6 characters long and only English alphanumeric allowed " Display="Dynamic"
                                                ValidationExpression="^[a-zA-Z0-9@#$%&*+\-_(),+':;?.,!\[\]\s\\/]{6,}$" CssClass="red nf" SetFocusOnError="true" ValidationGroup="personalInfo"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <div class="clear"></div>
                                    <div class="req">
                                        <div class="col-sm-3"></div>
                                        <div class="col-sm-6 col-xs-12">
                                          
                                        </div>
                                        <%--{6,}$--%>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="row" style="direction: rtl;">
                                        <div class="col-sm-2">
                                            <label class="control-label">تأكيد كلمة المرور: <span class="mandatory">*</span></label>
                                        </div>



                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txtConfirmPwd" runat="server" CssClass="form-control" ValidationGroup="personalInfo" TextMode="Password"></asp:TextBox>
                                               <asp:RequiredFieldValidator ID="reqConfirmPassword" runat="server" Display="Dynamic"
                                                ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtConfirmPwd" CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>


                                            <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic"
                                                ControlToCompare="txtPassword"
                                                ControlToValidate="txtConfirmPwd"
                                                ErrorMessage=" كلمة المرور لم تطابق" CssClass="red" ValidationGroup="personalInfo"></asp:CompareValidator>
                                        </div>
                                    </div>
                                    <div class="clear"></div>
                                    <div class="req">
                                        <div class="col-sm-3"></div>
                                        <div class="col-sm-6 col-xs-12">
                                         
                                        </div>
                                    </div>
                                </div>
                                <hr />
                                <p style="color:red;font-size:17px;font-size:bold;text-align:center;">اذا كنت تستخدم المتصفح safari ، بعد الإنتهاء من التسجيل الرجاء إرسال كل الملفات المطلوبة عبر البريد الإلكتروني التالي : web@youth.gov.kw</p>
                                <div class="form-group">

                                    <div class="col-sm-6">
                                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-info" Text="تسجيل" ValidationGroup="personalInfo" OnClick="btnSubmit_Click" />
                                    </div>
                                </div>
                                <br /><hr />
                                <div class="form-group" style="text-align:right;">
                                    <label class="control-label col-xs-12">
                                        في حال واجهتك مشكلة في التسجيل يرجى الضغط هنا 
                
                                        &nbsp; <span class="red"><a href="../contact_webadmin.aspx" style="color: red;">الدعم الفني</a></span>
                                    </label>
                                </div>

                                
                            </div>
                            <div class="heading-f-bg""></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
  

</asp:Content>

