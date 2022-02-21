<%@ Page Title="" Language="C#" MasterPageFile="~/Arabic_SiteMaster.master" AutoEventWireup="true" CodeFile="RegisterForm.aspx.cs" Inherits="RegisterForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .black_overlay
        {
            display: none;
            position: absolute;
            top: 0%;
            left: 0%;
            width: 100%;
            height: 100%;
            background-color: black;
            z-index: 1001;
            -moz-opacity: 0.8;
            opacity: .80;
            filter: alpha(opacity=80);
        }
        .txtnotered {color:red !important;font-weight:600; font-size:15px !important;    font-size: 22px !important;
    line-height: 35px;
        }

        .white_content
        {
            display: none;
            position: absolute;
            top: -10%;
            left: 25%;
            width: 50%;
            height: 20%;
            padding: 16px;
            border: 10px solid #67a4bb;
            background-color: white;
            z-index: 1002;
            overflow: auto;
        }

        @media only screen and (max-width: 479px)
        {

            h2.ipages_title1 strong
            {
                font-weight: 500;
            }

            .form-horizontal .control-label, .form-horizontal .radio, .form-horizontal .checkbox, .form-horizontal .radio-inline, .form-horizontal .checkbox-inline
            {
                padding-top: 7px;
                margin-top: 0;
                margin-bottom: 11px;
                font-size: 26px;
            }




            .form-control
            {
                display: block;
                width: 100%;
                height: 50px !important;
                padding: 6px 12px;
                font-size: 14px;
                line-height: 1.42857143;
                color: #555;
                background-color: #fff;
                background-image: none;
                border: 1px solid #ccc;
                border-radius: 4px;
                -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,0.075);
                box-shadow: inset 0 1px 1px rgba(0,0,0,0.075);
                -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
                -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
                transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
                direction: rtl;
            }


            .black_overlay
            {
                display: none;
                position: absolute;
                top: 0%;
                left: -70%;
                width: 750px;
                background-color: black;
                z-index: 1001;
                -moz-opacity: 0.8;
                opacity: .80;
                filter: alpha(opacity=80);
            }
        }
    </style>
    <script type="text/javascript">
        function showpreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                if (input.files[0].size > 1048576) {
                    alert("Should not exceed 1MB")
                    $(input).val('');
                }
                reader.readAsDataURL(input.files[0]);
            }
        }

    </script>


    <script>
        function validateTerms(source, arguments) {
            var $c = $('#<%= ChckTerm.ClientID %>');
            if ($c.prop("checked")) {
                arguments.IsValid = true;
            } else {
                arguments.IsValid = false;
            }
        }
        function validatePhone(source, arguments) {
            var userPhone = $('#txtContactNo').val();
            var ParentPhone = $('#TxtParentMobileNo').val();


            if (userPhone.length > 0 || ParentPhone.length > 0) {

                arguments.IsValid = true;
            }

            else {

                arguments.IsValid = false;
            }

        }

    </script>
    <script>
        function validateEmail(source, arguments) {
            var userEmail = $('#txtEmail').val();
            var ParentEmail = $('#TxtParentEmail').val();


            if (userEmail.length > 0 || ParentEmail.length > 0) {

                arguments.IsValid = true;
            }

            else {

                arguments.IsValid = false;
            }

        }
    </script>




    <link href="../js/form/bootstrap.css" rel="stylesheet" type="text/css" media="screen" />
    <link rel="stylesheet" type="text/css" href="../js/lightbox/jquery.fancybox.css" media="screen" />

    <!-- carousel -->
    <link rel="stylesheet" href="../js/carousel/flexslider.css" type="text/css" media="screen" />
    <link rel="stylesheet" type="text/css" href="../js/carousel/skin.css" />

    <!-- accordion -->
    <link rel="stylesheet" href="../js/accordion/accordion.css" type="text/css" media="all">

    <!-- forms -->
    <link rel="stylesheet" href="../js/form/sky-forms.css" type="text/css" media="all">

    <!-- lightbox -->
    <link rel="stylesheet" type="text/css" href="../js/lightbox/jquery.fancybox.css" media="screen" />



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContainerAR" runat="Server">


    <div class="features_sec8">
        <div class="container">
            <div class="one_full">
                <h2 class="ipages_title1"><strong>نموذج التسجيل </strong></h2>
                <div class="ContainerAR">
                    <div class="cont col-lg-12">
                        <div class="onlineTraining_inner">
                            <div class="col-lg-11 col-xs-12">


                                <div class="form-horizontal">
                                    <asp:Panel ID="panelform" runat="server">

                                        <div id="alertEmail" class="notification msgalert" runat="server" visible="false">
                                            <p>الايميل مسجل لدينا مسبقاً</p>
                                        </div>
                                        <div id="alertCivil" class="notification msgalert" runat="server" visible="false">
                                            <p>الرقم المدني مسجل لدينا مسبقاً</p>
                                        </div>
                                        <div class="form-group">

                                            <div class="row">
                                                 <div class="form-group"> <div class="col-sm-12 txtnotered"><%--ملاحظة : سوف يتم استخدام Microsoft teams  للتدريب او الدراسة  عن بعد وبمجرد تسجيلك سوف يتم تزويدك بالبيانات (اسم المستخدم وكلمة المرور عبر بريدك الإلكتروني الخاص )خلال 24 ساعة--%>ملاحظة : سوف يتم استخدام Microsoft teams للتدريب او الدراسة عن بعد</div></div><br />
                                                <label class="control-label col-sm-2" style="margin-right: 15px;">اسم المشارك </label>
                                                <div class="col-sm-9">
                                                    <div class="col-sm-4"></div>
                                                    <div class="col-sm-2 col-xs-12 pull-right">
                                                        <asp:TextBox ID="txtName" Style="margin-bottom: 5px;" runat="server" CssClass="form-control" placeholder="الأول"></asp:TextBox>

                                                        <asp:RequiredFieldValidator ID="txtNameValidator" runat="server" Display="Dynamic"
                                                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtName"
                                                            CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator27" ControlToValidate="txtName" CssClass="red"
                                                            ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                            ValidationGroup="personalInfo"> </asp:RegularExpressionValidator>

                                                    </div>
                                                    <div class="col-sm-2 col-xs-12 pull-right">
                                                        <asp:TextBox ID="txtMname" Style="margin-bottom: 5px;" runat="server" CssClass="form-control" placeholder="الثاني"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtMname"
                                                            CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator3" ControlToValidate="txtMname" CssClass="red"
                                                            ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                            ValidationGroup="personalInfo"> </asp:RegularExpressionValidator>
                                                    </div>
                                                    <div class="col-sm-2 col-xs-12 pull-right">
                                                        <asp:TextBox ID="txtTname" Style="margin-bottom: 5px;" runat="server" CssClass="form-control" placeholder="الثالث"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtTname"
                                                            CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator5" ControlToValidate="txtTname" CssClass="red"
                                                            ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                            ValidationGroup="personalInfo"> </asp:RegularExpressionValidator>


                                                    </div>
                                                    <div class="col-sm-2 col-xs-12 pull-right">
                                                        <asp:TextBox ID="txtLname" Style="margin-bottom: 5px;" runat="server" CssClass="form-control" placeholder="الأخير"></asp:TextBox>

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtLname"
                                                            CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator7" ControlToValidate="txtLname" CssClass="red"
                                                            ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                            ValidationGroup="personalInfo"> </asp:RegularExpressionValidator>
                                                    </div>

                                                    <div class="clearfix"></div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="form-group">
                                            <label class="control-label col-sm-3">Name in English</label>
                                            <div class="col-sm-3"></div>
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:TextBox ID="txtEnglishName"  ClientIDMode="Static" runat="server" ValidationGroup="personalInfo" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="clear"></div>
                                            <div class="req">
                                                <div class="col-sm-3"></div>
                                                <div class="col-sm-6"> 
                                                      <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator16" ControlToValidate="txtEnglishName"
                                                    ErrorMessage="Fill the Text in English" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[a-zA-Z @#$%\^&\*\\\-+=\\\|\}\]\{\['&quot;:?.>,</]+"
                                                    ValidationGroup="personalInfo" ForeColor="red"> </asp:RegularExpressionValidator>
                                                 <asp:RequiredFieldValidator ID="rqd1Contactnumber" runat="server" Display="Dynamic"
                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtEnglishName"
                                        CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                                   
                                                </div>
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
                                        <div class="form-group">
                                            <label class="control-label col-sm-3">الجنس</label>


                                            <%--<div class="col-sm-4 radio radio-info">--%>
                                            <div class="col-sm-3"></div>
                                            <div class="col-sm-6 radio radio-info">
                                                <asp:RadioButtonList runat="server" ID="gender" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                    <asp:ListItem Text="ذكر " Value="ذكر"></asp:ListItem>
                                                    <asp:ListItem Text=" أنثى " Value="أنثى"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>

                                            <div class="req">
                                                <div class="col-sm-3"></div>
                                                <div class="col-sm-6">
                                                    <asp:RequiredFieldValidator ID="rqdGender" runat="server" ErrorMessage="مطلوب هذه الخانة"
                                                        ControlToValidate="gender" CssClass="red" Display="Dynamic" SetFocusOnError="true"
                                                        ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-sm-3">الهاتف</label>
                                            <div class="col-sm-3"></div>
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:TextBox ID="txtContactNo" MaxLength="8" ClientIDMode="Static" runat="server" ValidationGroup="personalInfo" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="clear"></div>
                                            <div class="req">
                                                <div class="col-sm-3"></div>
                                                <div class="col-sm-6">
                                                    <asp:CustomValidator ID="CustomValidator3"
                                                        ClientValidationFunction="validatePhone"
                                                        ErrorMessage="Atlest one Mobile Number"
                                                        ForeColor="Red" SetFocusOnError="true"
                                                        Display="Dynamic"
                                                        EnableClientScript="true"
                                                        ValidationGroup="personalInfo"
                                                        runat="server" />



                                                    <%--    <asp:RequiredFieldValidator ID="rqdContactnumber" runat="server" Display="Dynamic"
                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtContactNo"
                                        CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>--%>
                                                    <asp:RegularExpressionValidator
                                                        EnableClientScript="true"
                                                        ID="RegularExpressionValidator2" runat="server"
                                                        ErrorMessage="رقم الهاتف يجب ان يكون 8 ارقام!"
                                                        ValidationGroup="personalInfo" SetFocusOnError="true"
                                                        ControlToValidate="txtContactNo" Display="dynamic"
                                                        ValidationExpression="^[0-9,٠-٩]{8}$"
                                                        CssClass="red" />
                                                </div>
                                            </div>
                                        </div>
                                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                            <ContentTemplate>
                                                <div class="form-group">
                                                    <label class="control-label col-sm-3">الرقم المدني: </label>

                                                    <div class="col-sm-3"></div>
                                                    <div class="col-sm-6">
                                                        <asp:TextBox ID="txtCivil" runat="server" MaxLength="12" ValidationGroup="personalInfo" OnTextChanged="txtCivil_TextChanged" AutoPostBack="true" CssClass="form-control"> </asp:TextBox>
                                                    </div>
                                                    <div class="clear"></div>
                                                    <div class="req">
                                                        <div class="col-sm-3"></div>
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
                                                <div class="form-group" runat="server" visible="false">
                                                    <label class="control-label col-sm-3">تاريخ الميلاد:</label>
                                                    <div class="col-sm-7">
                                                        <asp:TextBox ID="datepicker" runat="server" ValidationGroup="personalInfo" AutoCompleteType="Disabled" Enabled="false" CssClass="form-control"></asp:TextBox>

                                                    </div>
                                                    <div class="clear"></div>

                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>

                                                <div class="form-group">
                                                    <asp:HiddenField runat="server" ID="HdAge" />
                                                    <label class="control-label col-sm-3">تم تسجيلك في المستوى</label>
                                                    <div class="col-sm-3"></div>
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:DropDownList ID="DDLlevl" Enabled="false" runat="server" CssClass="form-control" Visible="true">
                                                            <asp:ListItem Text="--اختر---" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="المبتدئ" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="المتوسط" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="المتقدم" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:Label runat="server" ID="lblLevelIssue" Visible="false" CssClass="red" Text="نعتذر عن عدم تسجليكم لعدم توافق العمر مع الشروط العامة لدوري الابداع الشبابي"></asp:Label>
                                                    </div>
                                                    <div class="clear"></div>
                                                    <div class="req">
                                                        <div class="col-sm-3"></div>
                                                        <div class="col-sm-6">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                                ErrorMessage="مطلوب هذه الخانة" ControlToValidate="DDLlevl"
                                                                CssClass="red"
                                                                ValidationGroup="personalInfo" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic" InitialValue="0"
                                                                ErrorMessage="مطلوب هذه الخانة" ControlToValidate="DDLlevl"
                                                                CssClass="red" ValidationGroup="personalInfo" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>

                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="txtCivil" />
                                            </Triggers>
                                        </asp:UpdatePanel>

                                        <div class="form-group">
                                            <label class="control-label col-sm-3">صورة البطاقة المدنية</label>
                                            <div class="col-sm-3"></div>
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:FileUpload ID="fbCiviID" runat="server" CssClass="form-control input-rounded" ClientIDMode="Static" onchange="showpreview(fbCiviID);" />
                                                <span class="red">(.jpg,.png,.jpeg, or .pdf 1 MB)
                                                </span>
                                            </div>
                                            <div class="clear"></div>
                                            <div class="req">
                                                <div class="col-sm-3"></div>
                                                <div class="col-sm-6">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="fbCiviID"
                                                        CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                        ValidationGroup="personalInfo">
                                                    </asp:RequiredFieldValidator>

                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                                                        ErrorMessage="Only .pdf/.png/.jpg/.jepg/.gif files are allowed." CssClass="red"
                                                        ValidationExpression="^.*\.(pdf|PDF|png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF)$"
                                                        ControlToValidate="fbCiviID" Display="Dynamic" SetFocusOnError="true" ValidationGroup="personalInfo"></asp:RegularExpressionValidator>

                                                    <asp:Label ID="lblfileerror" runat="server" CssClass="red" Text="File should not be empty" Visible="false"></asp:Label>

                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-sm-3">البريد الالكتروني</label>
                                            <div class="col-sm-3"></div>
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="personalInfo" ClientIDMode="Static" ReadOnly="False" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="clear"></div>
                                            <div class="req">
                                                <div class="col-sm-3"></div>
                                                <div class="col-sm-6">

                                                    <asp:CustomValidator ID="CustomValidator2"
                                                        ClientValidationFunction="validateEmail"
                                                        ErrorMessage="Atlest one Email ID"
                                                        ForeColor="Red" SetFocusOnError="true"
                                                        Display="Dynamic"
                                                        EnableClientScript="true"
                                                        ValidationGroup="personalInfo"
                                                        runat="server" />

                                                    <%--    <asp:RequiredFieldValidator ID="rqdEmail" runat="server"
                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtEmail"
                                        CssClass="red"
                                        ValidationGroup="personalInfo" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                                        ErrorMessage="يرجى كتابة عنوان الإيميل" SetFocusOnError="true"
                                                        ControlToValidate="txtEmail" CssClass="red" Display="dynamic"
                                                        ValidationExpression="\s*\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*"
                                                        ValidationGroup="personalInfo"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-sm-3">أعد كتابة البريد الالكتروني</label>
                                            <div class="col-sm-3"></div>
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:TextBox ID="TxtEmailCompare" runat="server" ValidationGroup="personalInfo " ReadOnly="False" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="clear"></div>
                                            <div class="req">
                                                <div class="col-sm-3"></div>
                                                <div class="col-sm-6">
                                                    <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                    ErrorMessage="مطلوب هذه الخانة" ControlToValidate="TxtEmailCompare"
                                                    CssClass="red"
                                                    ValidationGroup="personalInfo" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server"
                                                        ErrorMessage="يرجى كتابة عنوان الإيميل" SetFocusOnError="true"
                                                        ControlToValidate="TxtEmailCompare" CssClass="red" Display="dynamic"
                                                        ValidationExpression="\s*\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*"
                                                        ValidationGroup="personalInfo"></asp:RegularExpressionValidator>


                                                <%--    <asp:CompareValidator ID="CompareValidator2" runat="server" Display="Dynamic"
                                                        ControlToCompare="txtEmail" SetFocusOnError="true"
                                                        ControlToValidate="TxtEmailCompare"
                                                        ErrorMessage="البريد الإلكتروني غير مطابق " CssClass="red" ValidationGroup="personalInfo"></asp:CompareValidator>--%>
                                                </div>
                                            </div>
                                        </div>



                                        <%-- New field --%>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <div class="form-group">
                                                    <label class="control-label col-sm-3">المحافظة</label>
                                                    <div class="col-sm-3"></div>
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:DropDownList ID="DDlGovernarate" runat="server" Enabled="false" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DDlGovernarate_SelectedIndexChanged">
                                                        </asp:DropDownList>

                                                    </div>
                                                    <div class="clear"></div>
                                                    <div class="req">
                                                        <div class="col-sm-3"></div>
                                                        <div class="col-sm-6">
                                                            <asp:RequiredFieldValidator ID="rqdGovernarate" runat="server"
                                                                ErrorMessage="مطلوب هذه الخانة" ControlToValidate="DDlGovernarate"
                                                                CssClass="red"
                                                                ValidationGroup="personalInfo" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic" InitialValue="0"
                                                                ErrorMessage="مطلوب هذه الخانة" ControlToValidate="DDlGovernarate"
                                                                CssClass="red" ValidationGroup="personalInfo" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>



                                                <div class="form-group">
                                                    <label class="control-label col-sm-3">منطقة السكن</label>
                                                    <div class="col-sm-3"></div>
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:DropDownList ID="DDLArea" runat="server" CssClass="form-control" Enabled="false" AutoPostBack="true">
                                                        </asp:DropDownList>

                                                    </div>
                                                    <div class="clear"></div>
                                                    <div class="req">
                                                        <div class="col-sm-3"></div>
                                                        <div class="col-sm-6">
                                                            <asp:RequiredFieldValidator ID="rqdArea" runat="server"
                                                                ErrorMessage="مطلوب هذه الخانة" ControlToValidate="DDLArea"
                                                                CssClass="red"
                                                                ValidationGroup="personalInfo" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" InitialValue="0"
                                                                ErrorMessage="مطلوب هذه الخانة" ControlToValidate="DDLArea"
                                                                CssClass="red" ValidationGroup="personalInfo" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>


                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <div class="form-group">
                                                    <label class="control-label col-sm-3">اختر مسابقة واحدة فقط</label>
                                                    <div class="col-sm-3"></div>
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:DropDownList ID="DDLCatagory" runat="server" CssClass="form-control" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="DDLCatagory_SelectedIndexChanged">
                                                        </asp:DropDownList>

                                                    </div>
                                                    <div class="clear"></div>
                                                    <div class="req">
                                                        <div class="col-sm-3"></div>

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic" InitialValue="0"
                                                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="DDLCatagory"
                                                            CssClass="red" ValidationGroup="personalInfo" SetFocusOnError="true"></asp:RequiredFieldValidator>

                                                    </div>
                                                </div>
                                                <asp:Panel runat="server" ID="pnlSub" Visible="false">
                                                    <div class="form-group">
                                                        <label class="control-label col-sm-3">المسابقة المتاحة</label>
                                                        <div class="col-sm-3"></div>
                                                        <div class="col-sm-6 col-xs-12">
                                                            <asp:DropDownList ID="DDlSubGroup" runat="server" CssClass="form-control" Enabled="false">
                                                            </asp:DropDownList>

                                                        </div>
                                                        <div class="clear"></div>
                                                        <div class="req">
                                                            <div class="col-sm-3"></div>
                                                            <div class="col-sm-6">

                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" Display="Dynamic" InitialValue="0"
                                                                    ErrorMessage="مطلوب هذه الخانة" ControlToValidate="DDlSubGroup"
                                                                    CssClass="red" ValidationGroup="personalInfo" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </asp:Panel>

                                                <asp:Panel runat="server" ID="pnlMessage" CssClass="notification msgalert" Visible="false">
                                                    <p>
                                                        عذراَ
لقد اكتمل عدد المسجلين في هذا المجال 
يمكنك اختيار أي مجال آخر متاح لك
                                                    </p>
                                                </asp:Panel>
                                                <%-- Parent Details --%>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="form-group">

                                            <div class="row">
                                                <label class="control-label col-sm-2" style="margin-right: 15px;">اسم ولي الأمر </label>
                                                <div class="col-sm-9">
                                                    <div class="col-sm-4"></div>
                                                    <div class="col-sm-2 col-xs-12 pull-right">
                                                        <asp:TextBox ID="TxtParentFirstname" Style="margin-bottom: 5px;" runat="server" CssClass="form-control" placeholder="الأول"></asp:TextBox>

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" Display="Dynamic" SetFocusOnError="true"
                                                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="TxtParentFirstname"
                                                            CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator9" ControlToValidate="TxtParentFirstname" CssClass="red"
                                                            ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                            ValidationGroup="personalInfo"> </asp:RegularExpressionValidator>

                                                    </div>
                                                    <div class="col-sm-2 col-xs-12 pull-right">
                                                        <asp:TextBox ID="TxtParentSecondname" Style="margin-bottom: 5px;" runat="server" CssClass="form-control" placeholder="الثاني"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" Display="Dynamic" SetFocusOnError="true"
                                                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="TxtParentSecondname"
                                                            CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator10" ControlToValidate="TxtParentSecondname" CssClass="red"
                                                            ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                            ValidationGroup="personalInfo"> </asp:RegularExpressionValidator>
                                                    </div>
                                                    <div class="col-sm-2 col-xs-12 pull-right">
                                                        <asp:TextBox ID="TxtParentThirdname" Style="margin-bottom: 5px;" runat="server" CssClass="form-control" placeholder="الثالث"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" Display="Dynamic" SetFocusOnError="true"
                                                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="TxtParentThirdname"
                                                            CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator11" ControlToValidate="TxtParentThirdname" CssClass="red"
                                                            ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                            ValidationGroup="personalInfo"> </asp:RegularExpressionValidator>


                                                    </div>
                                                    <div class="col-sm-2 col-xs-12 pull-right">
                                                        <asp:TextBox ID="TxtParentLastname" Style="margin-bottom: 5px;" runat="server" CssClass="form-control" placeholder="الأخير"></asp:TextBox>

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" Display="Dynamic" SetFocusOnError="true"
                                                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="TxtParentLastname"
                                                            CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator12" ControlToValidate="TxtParentLastname" CssClass="red"
                                                            ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                            ValidationGroup="personalInfo"> </asp:RegularExpressionValidator>
                                                    </div>

                                                    <div class="clearfix"></div>
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
                                        <asp:UpdatePanel runat="server" ID="updCivil" UpdateMode="Always">
                                            <ContentTemplate>
                                                <div class="form-group">
                                                    <label class="control-label col-sm-3">هاتف ولي الأمر</label>
                                                    <div class="col-sm-3"></div>
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:TextBox ID="TxtParentMobileNo" MaxLength="8" runat="server" ClientIDMode="Static" ValidationGroup="personalInfo" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                    <div class="clear"></div>
                                                    <div class="req">
                                                        <div class="col-sm-3"></div>
                                                        <div class="col-sm-6">

                                                            <asp:CustomValidator ID="CustomValidator1"
                                                                ClientValidationFunction="validatePhone"
                                                                ErrorMessage="Atleast One Phone Number"
                                                                ForeColor="Red"
                                                                Display="Dynamic"
                                                                EnableClientScript="true"
                                                                ValidationGroup="personalInfo" SetFocusOnError="true"
                                                                runat="server" />

                                                            <asp:RequiredFieldValidator ID="rqdContactnumber" runat="server" Display="Dynamic" Enabled="false"
                                                                ErrorMessage="مطلوب هذه الخانة" ControlToValidate="TxtParentMobileNo" SetFocusOnError="true"
                                                                CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator
                                                                EnableClientScript="true"
                                                                ID="RegularExpressionValidator13" runat="server" SetFocusOnError="true"
                                                                ErrorMessage="رقم الهاتف يجب ان يكون 8 ارقام!"
                                                                ValidationGroup="personalInfo"
                                                                ControlToValidate="TxtParentMobileNo" Display="dynamic"
                                                                ValidationExpression="^[0-9,٠-٩]{8}$"
                                                                CssClass="red" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="form-group">
                                                    <label class="control-label col-sm-3">البريد الالكتروني لولي الأمر</label>
                                                    <div class="col-sm-3"></div>
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:TextBox ID="TxtParentEmail" runat="server" ValidationGroup="personalInfo" ClientIDMode="Static" ReadOnly="False" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                    <div class="clear"></div>
                                                    <div class="req">
                                                        <div class="col-sm-3"></div>
                                                        <div class="col-sm-6">
                                                            <asp:RequiredFieldValidator ID="rqdEmail" runat="server" Enabled="false" SetFocusOnError="true"
                                                                ErrorMessage="مطلوب هذه الخانة" ControlToValidate="TxtParentEmail"
                                                                CssClass="red"
                                                                ValidationGroup="personalInfo" Display="Dynamic"></asp:RequiredFieldValidator>

                                                            <asp:CustomValidator ID="CustomValidator4"
                                                                ClientValidationFunction="validateEmail"
                                                                ErrorMessage="Atlest one Email ID"
                                                                ForeColor="Red"
                                                                Display="Dynamic"
                                                                EnableClientScript="true"
                                                                ValidationGroup="personalInfo" SetFocusOnError="true"
                                                                runat="server" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" SetFocusOnError="true"
                                                                ErrorMessage="يرجى كتابة عنوان الإيميل"
                                                                ControlToValidate="TxtParentEmail" CssClass="red" Display="dynamic"
                                                                ValidationExpression="\s*\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*"
                                                                ValidationGroup="personalInfo"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="control-label col-sm-3">أعد كتابة البريد الالكتروني</label>
                                                    <div class="col-sm-3"></div>
                                                    <div class="col-sm-6 col-xs-12">
                                                        <asp:TextBox ID="TxtReParentEmail" runat="server" ValidationGroup="personalInfo " ReadOnly="False" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                    <div class="clear"></div>
                                                    <div class="req">
                                                        <div class="col-sm-3"></div>
                                                        <div class="col-sm-6">
                                                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server"
                                                    ErrorMessage="مطلوب هذه الخانة" ControlToValidate="TxtReParentEmail"
                                                    CssClass="red"
                                                    ValidationGroup="personalInfo" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                                                                ErrorMessage="يرجى كتابة عنوان الإيميل" SetFocusOnError="true"
                                                                ControlToValidate="TxtReParentEmail" CssClass="red" Display="dynamic"
                                                                ValidationExpression="\s*\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*"
                                                                ValidationGroup="personalInfo"></asp:RegularExpressionValidator>


                                                           <%-- <asp:CompareValidator ID="CompareValidator3" runat="server" Display="Dynamic" SetFocusOnError="true"
                                                                ControlToCompare="TxtParentEmail"
                                                                ControlToValidate="TxtReParentEmail"
                                                                ErrorMessage="البريد الإلكتروني غير مطابق " CssClass="red" ValidationGroup="personalInfo"></asp:CompareValidator>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="form-group">
                                            <label class="control-label col-sm-3">كلمة المرور:</label>
                                            <div class="col-sm-3"></div>
                                            <div class="col-sm-6">
                                                <asp:TextBox ID="txtPassword" runat="server" ValidationGroup="personalInfo" AutoCompleteType="Disabled" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="clear"></div>
                                            <div class="req">
                                                <div class="col-sm-3"></div>
                                                <div class="col-sm-6 col-xs-12">
                                                    <asp:RequiredFieldValidator ID="txtPasswordValidator1" runat="server" Display="Dynamic"
                                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtPassword" CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="regular" runat="server"
                                                        ControlToValidate="txtPassword" ErrorMessage="Password must be atleast 6 characters long and only English alphanumeric allowed " Display="Dynamic"
                                                        ValidationExpression="^[a-zA-Z0-9@#$%&*+\-_(),+':;?.,!\[\]\s\\/]{6,}$" CssClass="red nf" SetFocusOnError="true" ValidationGroup="personalInfo"></asp:RegularExpressionValidator>
                                                </div>
                                                <%--{6,}$--%>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-sm-3">تأكيد كلمة المرور:</label>
                                            <div class="col-sm-3"></div>
                                            <div class="col-sm-6">
                                                <asp:TextBox ID="txtConfirmPwd" runat="server" CssClass="form-control" ValidationGroup="personalInfo" TextMode="Password"></asp:TextBox>
                                            </div>
                                            <div class="clear"></div>
                                            <div class="req">
                                                <div class="col-sm-3"></div>
                                                <div class="col-sm-6 col-xs-12">
                                                    <asp:RequiredFieldValidator ID="reqConfirmPassword" runat="server" Display="Dynamic" SetFocusOnError="true"
                                                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtConfirmPwd" CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>


                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" SetFocusOnError="true"
                                                        ControlToCompare="txtPassword"
                                                        ControlToValidate="txtConfirmPwd"
                                                        ErrorMessage=" كلمة المرور لم تطابق" CssClass="red" ValidationGroup="personalInfo"></asp:CompareValidator>
                                                </div>
                                            </div>
                                        </div>




                                        <div class="form-group" style="margin-bottom: 15px; display: none;">

                                            <div class="form-group" style="direction: rtl; margin: 0px 0px 20px 0px; text-align: justify;">السياسات والشروط العامة: </div>
                                            <div class="col-xs-12">
                                                <ul style="direction: rtl; margin: 0px 0px 20px 0px; text-align: justify;">
                                                    <li>1) أن يكون المشارك كويتي الجنسية</li>
                                                    <li>2)أن تكون المشاركة فردية وليست جماعية</li>
                                                    <li>3)	أن تتراوح الأعمار مابين 7-18 عاماً وقت التسجيل </li>
                                                    <li>4)	أن يلتزم المشاركين بالتسجيل من خلال موقع دوري الشباب الابداعي وملء استمارة التسجيل  التسجيل Link To Registration Form </li>
                                                    <li>5)	أن يلتزم المشاركين بالتواجد في جميع مراحل المسابقات</li>
                                                    <li>6)	لا يمكن المشاركة بأكثر من مسابقة في الدوري </li>
                                                    <li>7)	أن يجتاز المشارك مرحلة التصفيات ليتأهل إلى الدخول في التصفيات النهائية</li>
                                                    <li>8)	سيتم إقصاء المشاركين التي لا تتبع أعمارهم شروط التقديم أو الشروط الفنية أو العامة </li>
                                                    <li>9) يتم اقصاء المشارك المسجل بأكثر من مسابقة </li>
                                                </ul>
                                            </div>

                                        </div>
                                        <div class="form-group">

                                            <div class="col-sm-11">
                                                <label>أقر وأتعهد بأن المعلومات صحيحة</label>

                                            </div>
                                            <div class="col-sm-1">

                                                <asp:CheckBox runat="server" ID="ChckTerm" />

                                            </div>
                                            <div class="req">
                                                <div class="col-sm-3 pull-right">
                                                    <asp:CustomValidator ID="vTerms"
                                                        ClientValidationFunction="validateTerms"
                                                        ErrorMessage="مطلوب هذه الخانة"
                                                        ForeColor="Red"
                                                        Display="Dynamic"
                                                        EnableClientScript="true" SetFocusOnError="true"
                                                        ValidationGroup="personalInfo"
                                                        runat="server" />
                                                </div>
                                                <div class="col-sm-6">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-sm-3"></div>
                                            <div class="col-sm-6">
                                                <asp:Button ID="btnSubmit" runat="server" class="btn btn-info" Text="تسجيل" ValidationGroup="personalInfo" OnClick="btnSubmit_Click" />
                                            </div>
                                        </div>
                                        <asp:HiddenField ID="hdfile" runat="server" />
                                        <asp:HiddenField ID="hdpwd" runat="server" />

                                    </asp:Panel>


                                    <%--  <asp:UpdatePanel runat="server" ID="uppanel"><ContentTemplate>--%>
                                    <div id="QuestionModel" class="white_content" runat="server">
                                        <div id="div1" runat="server">
                                            <label class="control-label col-sm-12" style="font-size: 16px; margin-bottom: 32px;">
                                                مركز صباح الأحمد للموهبة والابداع يقدم دورات تدريبية مجانية للتدريب على مسابقات دوري الابداع الشبابي
هل  ترغب  في التسجيل بالدورات ?
                                            </label>


                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" CssClass="radio radio-info" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                                <asp:ListItem Value="نعم" Text="نعم"></asp:ListItem>
                                                <asp:ListItem Value="لا" Text="لا"></asp:ListItem>
                                            </asp:RadioButtonList>

                                        </div>

                                        <div id="div2" runat="server" style="display: none;">
                                            <label class="control-label col-sm-12" style="font-size: 16px; margin-bottom: 32px;">تم تعبأة هذا النموذج بواسطة:?</label>


                                            <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" CssClass="radio radio-info" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged">
                                                <asp:ListItem Value="المشارك" Text="المشارك"></asp:ListItem>
                                                <asp:ListItem Value="ولي الأمر" Text="ولي الأمر"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <%--  </ContentTemplate>
                                        <Triggers><asp:PostBackTrigger ControlID="RadioButtonList1" />

                                            <asp:AsyncPostBackTrigger ControlID="RadioButtonList2" />
                                        </Triggers>
                                    </asp:UpdatePanel>--%>
                                </div>




                            </div>
                        </div>
                    </div>
                    <div class="clear"></div>
                </div>

            </div>
        </div>
    </div>
    <div id="FormFade" class="black_overlay" runat="server"></div>

</asp:Content>
