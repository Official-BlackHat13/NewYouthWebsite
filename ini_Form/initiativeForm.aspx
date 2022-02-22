<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteMasterPage.master" Culture="en-GB" ValidateRequest="false"
    CodeFile="initiativeForm.aspx.cs" ClientIDMode="AutoID" Inherits="initiativeForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">

  
<%--   <link href="../Content/CSS/ini-form/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="../Content/CSS/ini-form/style1.css" type="text/css" />
    <link href="../Content/CSS/ini-form/default.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Content/CSS/ini-form/font-awesome.min.css" rel="stylesheet" />
    <script src="../Content/JS/ini-form/jquery-ui.js"></script>--%>
    
    

    <script type="text/javascript">
        $(function () {
            function datepicked() {
                var fromDate = $('#datepicker').datepicker('getDate');
                var toDate = $('#txtend').datepicker('getDate');
                if (fromDate && toDate) {
                    var difference_msec = toDate.getTime() - fromDate.getTime();
                    var difference_days = difference_msec / 86400000;
                    $("#nights").val(Math.ceil(difference_days));

                }
            }
            $("#<%=datepicker.ClientID %>").datepicker({
                numberOfMonths: 1,
                firstDay: 1,
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd-mm-yy',
                useCurrent: false,
                minDate: '+45D',
                maxDate: '+2Y',

                onSelect: function (dateStr) {
                    var d1 = $(this).datepicker("getDate");
                    d1.setDate(d1.getDate() + 0); // change to + 1 if necessary
                    var d2 = $(this).datepicker("getDate");
                    d2.setDate(d2.getDate() + 365); // change to + 29 if necessary                   
                    $("#txtend").datepicker("setDate", null);
                    $("#txtend").datepicker("option", "minDate", d1);
                    $("#txtend").datepicker("option", "maxDate", d2);
                    $("input[id$=txtActivityDate]").datepicker("option", "minDate", d1);
                    $("input[id$=txtDate]").datepicker("option", "minDate", d1);

                    datepicked();
                }
            });

            $("input[id$=txtActivityDate]").datepicker({
                numberOfMonths: 1,
                firstDay: 1,
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd-mm-yy',
                minDate: new Date($("#datepicker").datepicker("getDate")),
                maxDate: new Date($("#txtend").datepicker("getDate")),
                onSelect: function (dateStr) {
                    var d1 = $("#datepicker").datepicker("getDate");
                    d1.setDate(d1.getDate() + 0);
                    var d2 = $("#txtend").datepicker("getDate");
                    d2.setDate(d2.getDate() + 0);
                    $("input[id$=txtActivityDate]").datepicker("option", "minDate", d1);
                    $("input[id$=txtActivityDate]").datepicker("option", "maxDate", d2);

                    datepicked();
                }
            });
            $("input[id$=txtDate]").datepicker({
                numberOfMonths: 1,
                firstDay: 1,
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd-mm-yy',
                minDate: new Date($("input[id$=datepicker]").datepicker("getDate")),
                maxDate: $("#txtend").datepicker("getDate"),
                onSelect: function (dateStr) {

                    var d1 = $("#datepicker").datepicker("getDate");
                    d1.setDate(d1.getDate() + 0);
                    var d2 = $("#txtend").datepicker("getDate");
                    d2.setDate(d2.getDate() + 0);
                    $("input[id$=txtDate]").datepicker("option", "minDate", d1);
                    $("input[id$=txtDate]").datepicker("option", "maxDate", d2);

                    datepicked();
                }
            });
            $("#<%=txtend.ClientID %>").datepicker({
                numberOfMonths: 1,
                firstDay: 1,
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd-mm-yy',
                minDate: '+45D',
                maxDate: '+2Y',
                onSelect: function (dateStr) {
                    var d1 = $(this).datepicker("getDate");
                    d1.setDate(d1.getDate() + 0);
                    $("input[id$=txtActivityDate]").datepicker("option", "maxDate", d1);
                    $("input[id$=txtDate]").datepicker("option", "maxDate", d1);
                    datepicked();
                }
            });
        });
    </script>


  <%--  <style>
        .col {
            padding: 3px 0 0 3px;
        }

        .radio {
            padding: 10px;
            margin: 0px;
        }

        hr {
            background: linear-gradient(to left, transparent, #DBDBDB, transparent);
            height: 1px;
            border: 0px;
            margin: 16px;
        }
    </style>--%>


    <script type="text/javascript">
        $(function () {
            $('[data-toggle="tooltip"]').tooltip()
        })
    </script>



    <script type="text/javascript">
        $('#txtStartTime').timepicker();
    </script>


    <script type="text/javascript">
        function showpreview(input, val) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                if (val == 1) {

                    if (input.files[0].size > 1048576) {
                        alert("Should not exceed 1MB")
                        $(input).val('');
                    }
                }
                else if (val == 2) {

                    if (input.files[0].size > 2 * 1048576) {
                        alert("Should not exceed 2MB")
                        $(input).val('');
                    }
                }
                reader.readAsDataURL(input.files[0]);
            }
        }

    </script>
    <script>

        function pageLoad(sender, args) {

            $(document).ready(function () {
                $("[id*=txtObjective]").bind('paste', function (e) {
                    e.preventDefault();
                    alert("You cannot paste text into this textbox!");
                });
            });
        };

    </script>


   <%-- <style>
          body {
            font-family: 'Neo Sans Arabic';
        }

        .mt-3 {
            margin-top: 30px;
        }
        .text-right {
            text-align:right;
        }
    </style>--%>




</asp:Content>
<asp:Content ID="Content" runat="server" ContentPlaceHolderID="PageContent">
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_pageL
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function datepicked() {
            var fromDate = $('#datepicker').datepicker('getDate');
            var toDate = $('#txtend').datepicker('getDate');
            if (fromDate && toDate) {
                var difference_msec = toDate.getTime() - fromDate.getTime();
                var difference_days = difference_msec / 86400000;
                $("#nights").val(Math.ceil(difference_days));
            }
        }
        function EndRequestHandler() {
            $("#<%=datepicker.ClientID %>").datepicker({
                numberOfMonths: 1,
                firstDay: 1,
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd-mm-yy',
                useCurrent: false,
                minDate: '+45D',
                maxDate: '+2Y',

                onSelect: function (dateStr) {
                    var d1 = $(this).datepicker("getDate");
                    d1.setDate(d1.getDate() + 0); // change to + 1 if necessary
                    var d2 = $(this).datepicker("getDate");
                    d2.setDate(d2.getDate() + 365); // change to + 29 if necessary
                    var d3 = $("#txtend").datepicker("getDate");
                    d3.setDate(d3.getDate() + 0);
                    $("#txtend").datepicker("setDate", null);
                    $("#txtend").datepicker("option", "minDate", d1);
                    $("#txtend").datepicker("option", "maxDate", d2);
                    $("input[id$=txtActivityDate]").datepicker("option", "minDate", d1);
                    $("input[id$=txtActivityDate]").datepicker("option", "maxDate", d3);
                    $("input[id$=txtDate]").datepicker("option", "minDate", d1);
                    $("input[id$=txtDate]").datepicker("option", "maxDate", d3);
                    datepicked();
                }
            });

            $("input[id$=txtActivityDate]").datepicker({
                numberOfMonths: 1,
                firstDay: 1,
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd-mm-yy',
                minDate: $("#datepicker").datepicker("getDate"),
                maxDate: $("#txtend").datepicker("getDate"),
                onSelect: function (dateStr) {
                    var d1 = $("#datepicker").datepicker("getDate");
                    d1.setDate(d1.getDate() + 0); // change to + 1 if necessary
                    var d2 = $("#txtend").datepicker("getDate");
                    d2.setDate(d2.getDate() + 0); // change to + 29 if necessary                   
                    $("input[id$=txtActivityDate]").datepicker("option", "minDate", d1);
                    $("input[id$=txtActivityDate]").datepicker("option", "maxDate", d2);
                    datepicked();
                }
            });
            $("input[id$=txtDate]").datepicker({
                numberOfMonths: 1,
                firstDay: 1,
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd-mm-yy',
                minDate: new Date($("input[id$=datepicker]").datepicker("getDate")),
                maxDate: $("#txtend").datepicker("getDate"),
                onSelect: function (dateStr) {

                    var d1 = $("#datepicker").datepicker("getDate");
                    d1.setDate(d1.getDate() + 0); // change to + 1 if necessary
                    var d2 = $("#txtend").datepicker("getDate");
                    d2.setDate(d2.getDate() + 0); // change to + 29 if necessary                   
                    $("input[id$=txtDate]").datepicker("option", "minDate", d1);
                    $("input[id$=txtDate]").datepicker("option", "maxDate", d2);
                    datepicked();
                }
            });
            $("#<%=txtend.ClientID %>").datepicker({
                numberOfMonths: 1,
                firstDay: 1,
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd-mm-yy',
                minDate: '+45D',
                maxDate: '+2Y',
                onSelect: function (dateStr) {
                    var d1 = $(this).datepicker("getDate");
                    d1.setDate(d1.getDate() + 0);
                    $("input[id$=txtActivityDate]").datepicker("option", "maxDate", d1);
                    $("input[id$=txtDate]").datepicker("option", "maxDate", d1);
                    datepicked();
                }
            });
        }


    </script>

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

    <section>
        <div class="container-fluid">
            <div class="container">

                  <div class="text-center mt-50">
                    <h3> نموذج المشاريع أو الفعاليات الشبابية </h3>

                </div>

                <hr />
                <div class="bg-white ">
                   
                        <div class="row text-right">

                            <div class="col-xs-12 col-lg-12">


                                 <div class="form-horizontal">
                                    <div id="alertEmail" class="alert alert-danger" runat="server" visible="false">
                                        <p>Submitted Aleardy</p>
                                    </div>
                                </div>


                                <div class="col-12 form-group row mb-3">

                                    <label class="col-sm-3  pt-2" for="inputRounded">
                                        مقدم الطلب
                                    </label>
                                    <div class="col-sm-9 col-xs-12 pull-right ">
                                        <asp:RadioButtonList runat="server" ID="RBIntiativeCatagory" RepeatDirection="Horizontal"
                                            RepeatLayout="Flow" AutoPostBack="true" OnSelectedIndexChanged="RBIntiativeCatagory_SelectedIndexChanged">
                                            <asp:ListItem Text="أفراد" Value="أفراد"></asp:ListItem>
                                            <asp:ListItem Text="مجموعات شبابية" Value="مجموعات شبابية"></asp:ListItem>
                                            <asp:ListItem Text="جهات" Value="جهات"></asp:ListItem>
                                            <asp:ListItem Text="جمعيات نفع عام" Value="جمعيات نفع عام"></asp:ListItem>
                                            <asp:ListItem Text="ذوي الخبرة" Value="ذوي الخبرة"></asp:ListItem>

                                        </asp:RadioButtonList>
                                    </div>

                                    <div class="clearfix col-sm-5 col-xs-12 pull-leftradio radio-info">

                                        <asp:Label runat="server" Visible="false" ID="lblExperience" CssClass="red" Text="يشترط دراسة علمية وخبرة لا تقل عن (10) سنوات في المجال المقدم"></asp:Label>
                                    </div>
                                    <div class="clearfix">
                                        <asp:Label runat="server" Visible="false" ID="lblAgeMessage" CssClass="red" Text="لايمكنك التقديم على(أفراد،مجموعات شبابية) في حال تجاوز العمر 35"></asp:Label>


                                    </div>
                                    <hr />
                                </div>

                                <asp:Panel runat="server" ID="pnlType" Visible="false">
                                    <div class="col-12 form-group row mb-3">
                                        <label class="col-sm-3 col-xs-12 pull-right  pt-2" for="inputRounded">
                                            نوع الطلب

                                        </label>
                                        <div class="col-sm-2 col-xs-8 pull-right radio radio-info">
                                            <asp:RadioButton runat="server" ID="RBindivitual" GroupName="type" Text="مشروع" RepeatDirection="Horizontal"
                                                RepeatLayout="Flow" AutoPostBack="true" OnCheckedChanged="RBindivitual_CheckedChanged"></asp:RadioButton>
                                            <asp:Label runat="server" ID="toolindi" ToolTip="نشاط منظم غير هادف للربح، لتحقيق غاية محددة أو أكثر، يخدم الشباب بشكل خاص والمجتمع بشكل عام وفق أطر وفترة زمنية محددة قابلة للتطبيق.
"><i class="fa fa-question-circle"></i></asp:Label>

                                        </div>
                                        <div class="col-sm-4 col-xs-8 pull-right radio radio-info" runat="server" visible="false">
                                            <asp:RadioButton runat="server" ID="RBForum" RepeatDirection="Horizontal" GroupName="type"
                                                Text="فعالية (معرض،ملتقى،مؤتمر) " AutoPostBack="true" RepeatLayout="Flow" OnCheckedChanged="RBForum_CheckedChanged"></asp:RadioButton>
                                            <asp:Label ID="Label1" runat="server" ToolTip="نشاط يقام لفترة محددة كمعرض أو مؤتمر أو ملتقى، يتم من خلاله تقديم خدمات للشباب أو تبادل الخبرات في إحدى المجالات التي يستهدفها المكتب
"><i class="fa fa-question-circle"></i></asp:Label>
                                        </div>

                                        <div class="clearfix">
                                        </div>
                                        <hr />
                                    </div>
                                </asp:Panel>

                                <asp:UpdatePanel runat="server" ID="UPType">
                                    <ContentTemplate>
                                        <asp:Panel runat="server" ID="pnlOthr" Visible="false">
                                           
                                            <div class="col-12 form-group row mb-3" runat="server" id="divProjectname">
                                                <label class="col-sm-3 pull-right  pt-2" for="inputRounded">
                                                    اسم المشروع
                                                </label>
                                                <div class="col-sm-8 col-xs-12 pull-right">
                                                    <asp:TextBox runat="server" ID="txtProjectName" CssClass="form-control input-rounded"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtProjectName"
                                                        CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                        ValidationGroup="submitionform">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                <div class="clearfix">
                                                </div>


                                                <hr />
                                            </div>
                                            
                                            <div class="col-12 form-group row mb-3" runat="server" id="divEvent">
                                                <label class="col-sm-3 pull-right  pt-2" for="inputRounded">
                                                    اسم الفعالية
                                                </label>
                                                <div class="col-sm-8 col-xs-12 pull-right">
                                                    <asp:TextBox runat="server" ID="txtEventName" CssClass="form-control input-rounded"></asp:TextBox>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEventName"
                                                        CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                        ValidationGroup="submitionform">
                                                    </asp:RequiredFieldValidator>

                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator11" ControlToValidate="txtEventName" CssClass="red"
                                                        ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                        ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                                </div>
                                                <div class="clearfix">
                                                </div>
                                                <hr />
                                            </div>
                                            <div class="col-12 form-group row mb-3">

                                                <label class="col-sm-3 pull-right ">اسم مقدم الطلب(حسب البطاقة المدنية)  </label>
                                                <div class="col-sm-2 col-xs-12 pull-right">
                                                    <asp:TextBox ID="txtFname" Style="margin-bottom: 5px;" placeholder="الأول" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server"
                                                        ControlToValidate="txtFname" CssClass="red"
                                                        ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                        ValidationGroup="submitionform"> </asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator24" ControlToValidate="txtFname" CssClass="red"
                                                        ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                        ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                                </div>
                                                <div class="col-sm-2 col-xs-12 pull-right">
                                                    <asp:TextBox ID="txtMname" Style="margin-bottom: 5px;" placeholder="الثاني" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server"
                                                        ControlToValidate="txtMname" CssClass="red"
                                                        ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                        ValidationGroup="submitionform"> </asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator25" ControlToValidate="txtMname" CssClass="red"
                                                        ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                        ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                                </div>
                                                <div class="col-sm-2 col-xs-12 pull-right">
                                                    <asp:TextBox ID="txtThirdName" Style="margin-bottom: 5px;" placeholder="الثالث" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server"
                                                        ControlToValidate="txtThirdName" CssClass="red"
                                                        ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                        ValidationGroup="submitionform"> </asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator26" ControlToValidate="txtThirdName" CssClass="red"
                                                        ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                        ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                                </div>
                                                <div class="col-sm-2 col-xs-12 pull-right">
                                                    <asp:TextBox ID="txtsurname" Style="margin-bottom: 5px;" placeholder="الأخير" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server"
                                                        ControlToValidate="txtsurname" CssClass="red"
                                                        ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                        ValidationGroup="submitionform"> </asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator27" ControlToValidate="txtsurname" CssClass="red"
                                                        ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                        ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                                </div>
                                            </div>



                                            <%-- <div class="text-2 text-danger" style="font-family: Tahoma;">1st, 2nd, 3rd, 4th, 5th radio to 1st, 2nd radio  </div>--%>
                                            <div class="col-12 form-group row mb-3">
                                                <label class="col-sm-3 pull-right  pt-2">
                                                    المؤهل الدراسي
                                                </label>
                                                <div class="col-sm-8 col-xs-12 pull-right">
                                                    <asp:DropDownList runat="server" ID="drpEduQulification" CssClass="form-control form-control mb-3">
                                                        <asp:ListItem Value="0">--اختر--</asp:ListItem>
                                                        <asp:ListItem Value="1">متوسط</asp:ListItem>
                                                        <asp:ListItem Value="2">ثانوي</asp:ListItem>
                                                        <asp:ListItem Value="3">دبلوم</asp:ListItem>
                                                        <asp:ListItem Value="4">جامعي</asp:ListItem>
                                                        <asp:ListItem Value="5">دراسات عليا</asp:ListItem>
                                                        <asp:ListItem Value="6">أخرى</asp:ListItem>
                                                    </asp:DropDownList>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="drpEduQulification"
                                                        ErrorMessage="حقول مطلوبة" SetFocusOnError="true" Display="Dynamic"
                                                        CssClass="red" InitialValue="0" ValidationGroup="submitionform">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                <div class="clearfix">
                                                </div>

                                                <hr />
                                            </div>
                                            <%-- <div class="text-2 text-danger" style="font-family: Tahoma;">
                                        2nd radio to 1st, 2nd radio
                                    </div>--%>
                                            <div class="col-12 form-group row mb-3" runat="server" id="divCivilID">
                                                <label class="col-sm-3 pull-right  pt-2">
                                                    البطاقة المدنية لأعضاء المجموعة الشبابية
                                                </label>
                                                <div class="col-sm-8 col-xs-12 pull-right">
                                                    <div class="fileupload fileupload-new" data-provides="fileupload">
                                                        <div class="input-append">
                                                            <asp:FileUpload ID="fpCivilID" runat="server" CssClass="form-control input-rounded" ClientIDMode="Static" onchange="showpreview(fpCivilID,1);" />
                                                            <asp:RequiredFieldValidator ID="rfvCivilId" runat="server" ControlToValidate="fpCivilID"
                                                                ErrorMessage="حقول مطلوبة" SetFocusOnError="true" Display="Dynamic"
                                                                CssClass="red" ValidationGroup="submitionform">
                                                            </asp:RequiredFieldValidator>

                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator34" runat="server"
                                                                ErrorMessage="Only .pdf files are allowed." CssClass="red"
                                                                ValidationExpression="^.*\.(pdf|PDF)$"
                                                                ControlToValidate="fpCivilID" Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RegularExpressionValidator>
                                                            <span class="text-2 text-danger">يرجى إرفاق جميع البطاقات المدنية للأعضاء في ملف واحد</span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="clearfix">
                                                </div>
                                                <hr />
                                            </div>
                                            <%--  <div class="text-2 text-danger" style="font-family: Tahoma;">
                                        3rd, 4th radio to 1st, 2nd radio
                                    </div>--%>
                                            <div class="col-12 form-group row mb-3" id="divname_of_institution" runat="server">
                                                <label class="col-sm-3 pull-right  pt-2">
                                                    اسم الجهة
                                                </label>
                                                <div class="col-sm-8 col-xs-12 pull-right">
                                                    <asp:TextBox runat="server" ID="txtNameofInstitution" CssClass="form-control input-rounded"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNameofInstitution"
                                                        CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                        ValidationGroup="submitionform">
                                                    </asp:RequiredFieldValidator>

                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator12" ControlToValidate="txtNameofInstitution" CssClass="red"
                                                        ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                        ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                                </div>
                                                <div class="clearfix">
                                                </div>
                                                <hr />
                                            </div>
                                            <%--  <div class="text-2 text-danger" style="font-family: Tahoma;">
                                        3rd radio to 1st, 2nd radio
                                    </div>--%>
                                            <div class="col-12 form-group row mb-3" id="div_authorization" runat="server">
                                                <label class="col-sm-3 pull-right  pt-2">
                                                    تفويض من قبل الجهة باسم مقدم الطلب</label>
                                                <div class="col-sm-8 col-xs-12 pull-right">
                                                    <asp:FileUpload ID="fpAutorization" runat="server" CssClass="form-control input-rounded" ClientIDMode="Static" onchange="showpreview(fpAutorization,1);" />

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="fpAutorization"
                                                        ErrorMessage="حقول مطلوبة" SetFocusOnError="true" Display="Dynamic"
                                                        CssClass="red" ValidationGroup="submitionform">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                        ErrorMessage="Only .pdf files are allowed." CssClass="red"
                                                        ValidationExpression="^.*\.(pdf|PDF)$"
                                                        ControlToValidate="fpAutorization" Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RegularExpressionValidator>
                                                </div>
                                                <div class="clearfix">
                                                </div>
                                                <hr />
                                            </div>
                                            <%--  <div class="text-2 text-danger" style="font-family: Tahoma;">
                                        3rd, 4th radio to 1st, 2nd radio
                                    </div>--%>
                                            <div class="col-12 form-group row mb-3" id="div_civilid_publi_authority" runat="server">
                                                <label class="col-sm-3 pull-right  pt-2">
                                                    الرقم المدني للجهة من الهيئة العامة للمعلومات المدنية</label>
                                                <div class="col-sm-8 col-xs-12 pull-right">
                                                    <asp:FileUpload ID="fpcivilpubicauthority" runat="server" CssClass="form-control input-rounded" ClientIDMode="Static" onchange="showpreview(fpcivilpubicauthority,1);" />

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="fpcivilpubicauthority"
                                                        ErrorMessage="حقول مطلوبة" SetFocusOnError="true" Display="Dynamic"
                                                        CssClass="red" ValidationGroup="submitionform">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                        ErrorMessage="Only .pdf files are allowed." CssClass="red"
                                                        ValidationExpression="^.*\.(pdf|PDF)$"
                                                        ControlToValidate="fpcivilpubicauthority" Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RegularExpressionValidator>
                                                </div>
                                                <div class="clearfix">
                                                </div>
                                                <hr />
                                            </div>
                                            <%--  <div class="text-2 text-danger" style="font-family: Tahoma;">
                                        4th radio to 1st, 2nd radio
                                    </div>--%>
                                            <div class="col-12 form-group row mb-3" id="div_civilid_public_papper" runat="server">
                                                <label class="col-sm-3 pull-right  pt-2">
                                                    ورقة إشهار من وزارة الشئون الإجتماعية والعمل</label>
                                                <div class="col-sm-8 col-xs-12 pull-right">
                                                    <asp:FileUpload ID="fpcivilidpublicpapper" runat="server" CssClass="form-control input-rounded" ClientIDMode="Static" onchange="showpreview(fpcivilidpublicpapper,1);" />

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="fpcivilidpublicpapper"
                                                        ErrorMessage="حقول مطلوبة" SetFocusOnError="true" Display="Dynamic"
                                                        CssClass="red" ValidationGroup="submitionform">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                                        ErrorMessage="Only .pdf files are allowed." CssClass="red"
                                                        ValidationExpression="^.*\.(pdf|PDF)$"
                                                        ControlToValidate="fpcivilidpublicpapper" Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RegularExpressionValidator>
                                                </div>
                                                <div class="clearfix">
                                                </div>
                                                <hr />
                                            </div>
                                            <%--  <div class="text-2 text-danger" style="font-family: Tahoma;">
                                        1st, 2nd, 3rd, 4th, 5th radio to 1st, 2nd radio
                                    </div>--%>
                                            <div class="col-12 form-group row mb-3">
                                                <label class="col-sm-3 pull-right  pt-2">
                                                    المحافظة
                                                </label>
                                                <div class="col-sm-8 col-xs-12 pull-right">
                                                    <asp:DropDownList runat="server" ID="dpGovernarate" CssClass="form-control form-control mb-3">
                                                        <asp:ListItem Value="0">--اختر--</asp:ListItem>
                                                        <asp:ListItem Value="1">العاصمة</asp:ListItem>
                                                        <asp:ListItem Value="2">حولي</asp:ListItem>
                                                        <asp:ListItem Value="3">الفروانية</asp:ListItem>
                                                        <asp:ListItem Value="4">مبارك الكبير</asp:ListItem>
                                                        <asp:ListItem Value="5">الاحمدي</asp:ListItem>
                                                        <asp:ListItem Value="6">الجهراء</asp:ListItem>
                                                    </asp:DropDownList>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="dpGovernarate"
                                                        ErrorMessage="حقول مطلوبة" SetFocusOnError="true" InitialValue="0"
                                                        Display="Dynamic" CssClass="red" ValidationGroup="submitionform">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                <div class="clearfix">
                                                </div>

                                                <hr />
                                            </div>
                                            <%--  <div class="text-2 text-danger" style="font-family: Tahoma;">
                                        1st, 2nd, 3rd, 4th, 5th radio to 1st, 2nd radio
                                    </div>--%>
                                            <div class="col-12 form-group row mb-3">
                                                <label class="col-sm-3 pull-right  pt-2">
                                                    المجال
                                                </label>
                                                <div class="col-sm-8 col-xs-12 pull-right">
                                                    <asp:DropDownList runat="server" ID="dpArea" CssClass="form-control form-control mb-3">
                                                        <asp:ListItem Value="0">--اختر--</asp:ListItem>
                                                        <asp:ListItem Value="1">الثقافة</asp:ListItem>
                                                        <asp:ListItem Value="2">الفنون</asp:ListItem>
                                                        <asp:ListItem Value="3">الآداب</asp:ListItem>
                                                        <asp:ListItem Value="4">التخطيط العمراني وتنمية المدن</asp:ListItem>
                                                        <asp:ListItem Value="5">التعليم</asp:ListItem>
                                                        <asp:ListItem Value="6">البحوث</asp:ListItem>
                                                        <asp:ListItem Value="7">الصحة</asp:ListItem>
                                                        <asp:ListItem Value="8">الرياضة</asp:ListItem>
                                                        <asp:ListItem Value="9">العلوم والتكنولوجيا</asp:ListItem>
                                                        <asp:ListItem Value="10">الإعلام</asp:ListItem>
                                                        <asp:ListItem Value="11">الحملات التوعوية</asp:ListItem>
                                                        <asp:ListItem Value="12">ريادة الأعمال</asp:ListItem>
                                                        <asp:ListItem Value="13">البيئة</asp:ListItem>
                                                        <asp:ListItem Value="14">الطاقة</asp:ListItem>
                                                        <asp:ListItem Value="15">علوم الشريعة الإسلامية</asp:ListItem>
                                                    </asp:DropDownList>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="dpArea"
                                                        ErrorMessage="حقول مطلوبة" SetFocusOnError="true" InitialValue="0"
                                                        Display="Dynamic" CssClass="red" ValidationGroup="submitionform">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                <div class="clearfix">
                                                </div>

                                                <hr />
                                            </div>



                                            <h2 class="ipages_title1"><strong>وصف المشروع</strong> </h2>
                                            <div class="col-12 form-group row mb-3" id="dpprojcetcatagory" runat="server" visible="false">
                                                <label class="col-sm-3 pull-right  pt-2">
                                                    تصنيف المشروع
                                                </label>
                                                <div class="col-sm-8 col-xs-12 pull-right">
                                                    <!--if select 1st option with attchemnt will come only. if other option select, no attachemnt and last option select, there are nothing will come-->
                                                    <asp:DropDownList runat="server" ID="dpProjectCategory" AutoPostBack="true" CssClass="form-control form-control mb-3">

                                                        <asp:ListItem Value="0">--اختر---</asp:ListItem>
                                                        <asp:ListItem Value="1">المشاريع الطلابية</asp:ListItem>
                                                        <asp:ListItem Value="2">الإنتاج الفني</asp:ListItem>
                                                        <asp:ListItem Value="3">المشاريع الإبتكارية والتطويرية</asp:ListItem>
                                                        <asp:ListItem Value="4">البحوث والدراسات المتعلقة بالشباب والمجتمع</asp:ListItem>
                                                        <asp:ListItem Value="5">المواقع الإلكترونية وتطبيقات الهواتف الذكية</asp:ListItem>
                                                        <asp:ListItem Value="6">ورش العمل والبرامج التدريبية</asp:ListItem>
                                                        <asp:ListItem Value="7">انتاج البرامج المرئية والمسموعة</asp:ListItem>
                                                        <asp:ListItem Value="8">الحملات التوعوية</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" InitialValue="0"
                                                        ControlToValidate="dpProjectCategory" CssClass="red" ErrorMessage="حقول مطلوبة "
                                                        Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="clearfix">
                                                </div>

                                                <hr />
                                            </div>

                                            <label class="col-sm-3 pull-right  pt-2 nf" for="inputRounded">
                                                شرح تفصيلي للمشروع (لا يقل عن 100 كلمة ولا يزيد عن 700 كلمة)
                                            </label>
                                            <div class="col-sm-8 col-xs-12 pull-right">
                                                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtProjectDetail" CssClass="form-control" Rows="3" Columns="5" AutoPostBack="true" OnTextChanged="txtProjectDetail_TextChanged"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txtProjectDetail"
                                                    CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                    ValidationGroup="submitionform"> 
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator15" ControlToValidate="txtProjectDetail"
                                                    CssClass="red"
                                                    ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic"
                                                    SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                    ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressio15" runat="server" ControlToValidate="txtProjectDetail" SetFocusOnError="true"
                                                    Display="Dynamic" ErrorMessage="لا يقل عن 100 كلمة ولا يزيد عن 700 كلمة" CssClass="red" ValidationGroup="submitionform"
                                                    ValidationExpression="[\s\S]{600,5000}"></asp:RegularExpressionValidator>
                                            </div>

                                            <div class="clearfix"></div>

                                            <hr />

                                            <label class="col-sm-3 pull-right  pt-2" for="inputRounded">
                                                الأهداف(على أن تكون على هيئة نقاط)</label>
                                            <div class="col-sm-8 col-xs-12 pull-right">
                                                <asp:TextBox runat="server" ID="txtObjective" CssClass="form-control" CausesValidation="true" TextMode="MultiLine" Rows="3" Columns="5"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="txtObjective"
                                                    CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                    ValidationGroup="submitionform">
                                                </asp:RequiredFieldValidator>

                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator30" runat="server" ControlToValidate="txtObjective" SetFocusOnError="true"
                                                    Display="Dynamic" ErrorMessage="لا يقل عن 1 كلمة ولا يزيد عن 700 كلمة" CssClass="red"
                                                    ValidationGroup="submitionform"
                                                    ValidationExpression="[\s\S]{1,5000}"></asp:RegularExpressionValidator>
                                                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator16"
                                                    ControlToValidate="txtObjective" CssClass="red"
                                                    ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic"
                                                    SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                    ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                            </div>
                                            <div class="clearfix">
                                            </div>
                                            <hr />

                                            <%--  <div class="text-2 text-danger" style="font-family: Tahoma;">
                                        1st, 2nd, 3rd, 4th, 5th radio to 1st, 2nd radio
                                    </div>--%>

                                            <label class="col-sm-3 pull-right  pt-2" for="inputRounded">
                                                <asp:Label runat="server" ID="lblproject" Text="بيان الأثر الإيجابي"></asp:Label>
                                            </label>
                                            <div class="col-sm-8 col-xs-12 pull-right">
                                                <asp:TextBox ID="txtImpctofproject" runat="server" CssClass="form-control" CausesValidation="true" TextMode="MultiLine" Rows="3" Columns="5" AutoPostBack="true" OnTextChanged="txtImpctofproject_TextChanged"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="txtImpctofproject"
                                                    CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                    ValidationGroup="submitionform">
                                            
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator31" runat="server" ControlToValidate="txtImpctofproject" SetFocusOnError="true"
                                                    Display="Dynamic" ErrorMessage="لا يقل عن 1 كلمة ولا يزيد عن 700 كلمة" CssClass="red"
                                                    ValidationGroup="submitionform"
                                                    ValidationExpression="[\s\S]{1,5000}"></asp:RegularExpressionValidator>
                                                <asp:RegularExpressionValidator runat="server" ID="RVImpactofproject17"
                                                    ControlToValidate="txtImpctofproject" CssClass="red"
                                                    ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic"
                                                    SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                    ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                            </div>
                                            <div class="clearfix">
                                            </div>
                                            <hr />


                                            <label class="col-sm-3 pull-right  pt-2 nf" for="inputRounded">
                                                دور مقدم الطلب بصورة تفصيلية (لا يزيد عن 300 كلمة)
                                            </label>
                                            <div class="col-sm-8 col-xs-12 pull-right">

                                                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtRoleofApplicant" CausesValidation="true" CssClass="form-control" Rows="3" Columns="5" AutoPostBack="true" OnTextChanged="txtRoleofApplicant_TextChanged"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFVRoleofAppicant" runat="server"
                                                    ControlToValidate="txtRoleofApplicant" CssClass="red" ErrorMessage="حقول مطلوبة "
                                                    Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RequiredFieldValidator>

                                                <asp:RegularExpressionValidator runat="server" ID="REVRoleofapplicant" ControlToValidate="txtRoleofApplicant" CssClass="red"
                                                    ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true"
                                                    ValidationExpression="[^a-zA-Z]+"
                                                    ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator32" runat="server" ControlToValidate="txtImpctofproject" SetFocusOnError="true"
                                                    Display="Dynamic" ErrorMessage="لا يقل عن 1 كلمة ولا يزيد عن 700 كلمة"
                                                    CssClass="red" ValidationGroup="submitionform"
                                                    ValidationExpression="[\s\S]{1,5000}"></asp:RegularExpressionValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server" ControlToValidate="txtRoleofApplicant"
                                                    Display="Dynamic" ErrorMessage="لا يقل عن 20 كلمة ولا يزيد عن 300 كلمة" CssClass="red" SetFocusOnError="true"
                                                    ValidationExpression="[\s\S]{111,2500}" ValidationGroup="submitionform"></asp:RegularExpressionValidator>
                                            </div>


                                            <div class="clearfix">
                                            </div>
                                            <hr />
                                            <div class="col-12 form-group row mb-3" id="div_eventVenue" runat="server">
                                                <label class="col-sm-3 pull-right  pt-2" for="inputRounded">
                                                    مكان إقامة الفعالية
                                                </label>
                                                <div class="col-sm-8 col-xs-12 pull-right">
                                                    <asp:TextBox runat="server" ID="txtEventVenue" CssClass="form-control input-rounded"></asp:TextBox>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtEventVenue"
                                                        CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                        ValidationGroup="submitionform">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator14" ControlToValidate="txtEventVenue" CssClass="red"
                                                        ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                        ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                                </div>
                                                <div class="clearfix">
                                                </div>
                                                <hr />
                                            </div>
                                            <%-- <div class="text-2 text-danger" style="font-family: Tahoma;">
                                        1st, 2nd, 3rd, 4th, 5th radio to 1st, 2nd radio
                                    </div>--%>

                                            <div class="col-12 form-group row mb-3" id="div_projectVenue" runat="server">
                                                <label class="col-sm-3 pull-right  pt-2" for="inputRounded">
                                                    مكان إقامة المشروع
                                            <!--أو الفعالية-->
                                                </label>
                                                <div class="col-sm-8 col-xs-12 pull-right">
                                                    <asp:TextBox runat="server" ID="txtPlaceofResidence" CssClass="form-control input-rounded"></asp:TextBox>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtPlaceofResidence"
                                                        CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                        ValidationGroup="submitionform">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator13" ControlToValidate="txtPlaceofResidence" CssClass="red"
                                                        ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                        ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                                </div>
                                                <div class="clearfix">
                                                </div>
                                                <hr />
                                            </div>

                                            <div class="col-12 form-group row mb-3">
                                                <label class="col-sm-3 pull-right  pt-2" for="inputRounded">
                                                    كتاب الموافقة على المكان
                                            <!--أو الفعالية-->
                                                </label>
                                                <div class="col-sm-8 col-xs-12 pull-right">


                                                    <asp:FileUpload ID="txtBookApproval" runat="server" CssClass="form-control input-rounded" ClientIDMode="Static" onchange="showpreview(txtBookApproval,1);" />


                                                    <asp:RequiredFieldValidator ID="rvBookApproval" runat="server" ControlToValidate="txtBookApproval"
                                                        CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                        ValidationGroup="submitionform">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                                                        ErrorMessage="Only .pdf files are allowed." CssClass="red"
                                                        ValidationExpression="^.*\.(pdf|PDF)$"
                                                        ControlToValidate="txtBookApproval" Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RegularExpressionValidator>
                                                </div>
                                                <div class="clearfix">
                                                </div>
                                                <hr />
                                            </div>
                                            <div class="col-12 form-group row mb-3">
                                                <label class="col-sm-3 pull-right  pt-2">
                                                    الشريحة المستهدفة
                                                </label>
                                                <div class="col-sm-8 col-xs-12 pull-right">
                                                    <asp:DropDownList runat="server" ID="dpTargetSegment" CssClass="form-control form-control mb-3" AutoPostBack="true" OnSelectedIndexChanged="dpTargetSegment_SelectedIndexChanged">
                                                        <asp:ListItem Value="0">--اختر--</asp:ListItem>
                                                        <asp:ListItem Value="1">الشباب</asp:ListItem>
                                                        <%--  <asp:ListItem Value="2">حولي</asp:ListItem>--%>
                                                        <asp:ListItem Value="3">الشباب والمجتمع</asp:ListItem>
                                                    </asp:DropDownList>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" InitialValue="0"
                                                        ControlToValidate="dpTargetSegment" CssClass="red" ErrorMessage="حقول مطلوبة "
                                                        Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                <div class="clearfix">
                                                </div>

                                                <hr />
                                            </div>
                                            <%--  <div class="text-2 text-danger" style="font-family: Tahoma;">
                                        1st, 2nd, 3rd, 4th, 5th radio to 1st, 2nd radio
                                    </div>--%>

                                            <%-- <div class="text-2 text-danger" style="font-family: Tahoma;">
                                        1st, 2nd, 3rd, 4th, 5th radio to 1st, 2nd radio
                                    </div>--%>
                                            <div class="col-12 form-group row mb-3">
                                                <label class="col-sm-3 pull-right  pt-2" for="inputRounded">
                                                    <asp:Label runat="server" ID="lblCatagory" Text="الفئة العمرية للمستفيدين"></asp:Label>
                                                </label>

                                                <div class="col-sm-4 col-xs-12 pull-right">
                                                    <asp:TextBox runat="server" ID="txtAgeFrom" placeholder="من " CssClass="form-control input-rounded"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtAgeFrom"
                                                        CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                        ValidationGroup="submitionform"></asp:RequiredFieldValidator>

                                                    <asp:RegularExpressionValidator
                                                        EnableClientScript="true"
                                                        ID="RegularExpressionValidator22" runat="server"
                                                        ErrorMessage="فضلا أدخل أرقام فقط "
                                                        ValidationGroup="submitionform"
                                                        ControlToValidate="txtAgeFrom" Display="dynamic"
                                                        ValidationExpression="^\d+?$"
                                                        CssClass="red" SetFocusOnError="true" />
                                                </div>
                                                <div class="col-sm-4 col-xs-12 pull-right">
                                                    <asp:TextBox runat="server" ID="txtAgeTo" placeholder="إلى" CssClass="form-control input-rounded"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ControlToValidate="txtAgeTo"
                                                        CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                        ValidationGroup="submitionform"></asp:RequiredFieldValidator>

                                                    <asp:RegularExpressionValidator
                                                        EnableClientScript="true"
                                                        ID="RegularExpressionValidator29" runat="server"
                                                        ErrorMessage="فضلا أدخل أرقام فقط "
                                                        ValidationGroup="submitionform"
                                                        ControlToValidate="txtAgeTo" Display="dynamic"
                                                        ValidationExpression="^\d+?$"
                                                        CssClass="red" SetFocusOnError="true" />
                                                </div>

                                                <%-- only text--%>
                                                <div class="clearfix">
                                                </div>
                                                <hr />
                                            </div>
                                            <div class="col-12 form-group row mb-3">
                                                <%-- <h2>المستفيدين</h2>--%>
                                                <label class="col-sm-3 pull-right  pt-2" for="inputRounded">
                                                    <asp:Label runat="server" ID="lblNumberofBenficiries"></asp:Label>
                                                </label>
                                                <div class="col-sm-8 col-xs-12 pull-right">
                                                    <asp:TextBox runat="server" ID="txtNumberofBenficiries" CssClass="form-control input-rounded" MaxLength="5"></asp:TextBox><%--//only number--%>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtNumberofBenficiries"
                                                        CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                        ValidationGroup="submitionform">
                                                    </asp:RequiredFieldValidator>

                                                    <asp:RegularExpressionValidator
                                                        EnableClientScript="true"
                                                        ID="RegularExpressionValidator7" runat="server"
                                                        ErrorMessage="فضلا أدخل أرقام فقط "
                                                        ValidationGroup="submitionform"
                                                        ControlToValidate="txtNumberofBenficiries" Display="dynamic"
                                                        ValidationExpression="^\d+?$"
                                                        CssClass="red" SetFocusOnError="true" />
                                                </div>
                                                <div class="clearfix">
                                                </div>

                                                <hr />
                                            </div>

                                            <div class="clearfix">
                                            </div>
                                            <div class="col-12 form-group row mb-3">


                                                <h2 class="ipages_title1"><strong>الخطة التنفيذية </strong></h2>
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div class="col-12 form-group row mb-3">
                                                            <label class="col-sm-3 pull-right  pt-2">
                                                                مدة المشروع

                                                            </label>

                                                            <div class="col-sm-6 col-xs-12 pull-right">
                                                                <div class="col-sm-6 sp">

                                                                    <div class="input-group">
                                                                        <div class="input-group date">
                                                                            <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                                                            <asp:TextBox runat="server" ID="txtend" ClientIDMode="Static" ValidationGroup="submitionform" onkeypress="return false;" onpaste="return false;" CssClass="form-control input-rounded"></asp:TextBox>

                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="txtend"
                                                                                CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                                ValidationGroup="submitionform">
                                                                            </asp:RequiredFieldValidator>
                                                                        </div>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" Display="Dynamic" SetFocusOnError="true"
                                                                            ErrorMessage="يرجى ادخال التاريخ" ValidationGroup="submitionform" CssClass="red"
                                                                            ControlToValidate="txtend"
                                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$" />
                                                                        <asp:CompareValidator ID="CompareValidator1" CssClass="red" ValidationGroup="submitionform"
                                                                            runat="server" ControlToValidate="datepicker" ControlToCompare="txtend"
                                                                            Operator="LessThanEqual" Type="Date" ErrorMessage="تاريخ نهاية المشروع يجب ان يكون بعد تاريخ بداية المشروع" SetFocusOnError="true"></asp:CompareValidator>

                                                                    </div>

                                                                </div>

                                                                <div class="col-sm-6 sp">

                                                                    <div class="input-group date">
                                                                        <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                                                        <asp:TextBox runat="server" ID="datepicker" ClientIDMode="Static" ValidationGroup="submitionform" onkeypress="return false;" onpaste="return false;" CssClass="form-control input-rounded"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="datepicker"
                                                                            CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                            ValidationGroup="submitionform">
                                                      
                                                                        </asp:RequiredFieldValidator>
                                                                        <asp:Label runat="server" ID="lblage" Text="يشترط على المبادر تقديم مشروعه قبل إنعقاد المشروع ب 45 يوم" Visible="false" CssClass="red"> </asp:Label>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" Display="Dynamic" SetFocusOnError="true"
                                                                            ErrorMessage="يرجى ادخال التاريخ" ValidationGroup="submitionform" CssClass="red"
                                                                            ControlToValidate="datepicker"
                                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$" />


                                                                    </div>

                                                                </div>



                                                            </div>

                                                            <div class="clearfix">
                                                            </div>
                                                            <hr />
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </div>
                                            <div class="col-12 form-group row mb-3">
                                                <label class="col-sm-3 pull-right  pt-2">
                                                    الجدول الزمني للخطة التنفيذية
                                                </label>
                                                <div class="col-sm-9">
                                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                        <tr>

                                                            <td align="center">التاريخ
                                                        <br>
                                                            </td>
                                                            <td align="center">النشاط
                                                        <br>
                                                            </td>

                                                        </tr>
                                                        <asp:Repeater ID="RpExctuiveplan" runat="server" OnItemCommand="RpExctuiveplan_ItemCommand">
                                                            <ItemTemplate>
                                                                <tr>


                                                                    <td>
                                                                        <div class="col">
                                                                            <div class="input-group date">
                                                                                <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                                                                <asp:TextBox runat="server" ID="txtActivityDate" Text='<%# Eval("txtActivityDate").ToString() %>' onkeypress="return false;" onpaste="return false;" CssClass="form-control input-rounded"></asp:TextBox>

                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtActivityDate"
                                                                                    CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                                    ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                                                            </div>

                                                                            <asp:Label runat="server" ID="lblMessage" Visible="false" CssClass="red" Text="يجب أن لا يكون التاريخ قبل بداية المشروع"></asp:Label>

                                                                            <%--    <asp:CompareValidator ID="CompareVa" CssClass="red" ValidationGroup="submitionform"
                                                                        runat="server" ControlToValidate="datepicker" ControlToCompare="txtActivityDate"
                                                                        Operator="GreaterThanEqual" Type="Date" ErrorMessage="يجب أن لا يكون التاريخ قبل بداية المشروع" SetFocusOnError="true"></asp:CompareValidator>--%>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div class="col">

                                                                            <asp:TextBox runat="server" ID="txtActivity" Text='<%# Eval("txtActivity").ToString() %>' CssClass="form-control input-rounded"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtActivity"
                                                                                CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                                ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator17" ControlToValidate="txtActivity" CssClass="red"
                                                                                ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                                                ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                                                        </div>
                                                                    </td>


                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                        <tr>
                                                            <td style="font-size: 27px; color: #F00; font-weight: 600;" align="right">
                                                                <asp:LinkButton ID="lnk_Excutive" runat="server" Text="+"
                                                                    OnClick="lnk_Excutive_Click" Style="font-size: 27px; color: #F00; font-weight: 600; text-decoration: none" Font-Size="13px" Font-Underline="true"
                                                                    ValidationGroup="persExecutive" />
                                                            </td>
                                                            <td>
                                                                <p align="center" class="text-2 text-danger" dir="RTL">
                                                                    يرجى تفصيل كل يوم على حده
                                                                </p>
                                                            </td>
                                                            <td>
                                                                <p align="center" dir="RTL">
                                                                    &nbsp;
                                                                </p>
                                                            </td>
                                                            <td>
                                                                <p align="center" dir="RTL">
                                                                    <asp:LinkButton ID="lnkExcutiveCanecl" runat="server" Text="-" OnClick="lnkExcutiveCanecl_Click" Visible="false"
                                                                        Style="font-size: 27px; color: #F00; font-weight: 600; text-decoration: none" Font-Size="13px" Font-Underline="true"
                                                                        ValidationGroup="persExecutive" />
                                                                </p>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <div class="clearfix">
                                                </div>
                                                <hr />
                                            </div>




                                            <div class="col-12 form-group row mb-3">
                                                <label class="col-sm-3 pull-right  pt-2">
                                                    نوع النشاط
                                                </label>
                                                <div class="col-sm-9 col-xs-12 pull-right">
                                                    <!--if select 1st option with attchemnt will come only. if other option select, no attachemnt and last option select, there are nothing will come-->
                                                    <asp:DropDownList runat="server" ID="drpType" AutoPostBack="true" CausesValidation="true" CssClass="form-control form-control mb-3" OnSelectedIndexChanged="drpType_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" InitialValue="0"
                                                        ControlToValidate="drpType" CssClass="red" ErrorMessage="حقول مطلوبة "
                                                        Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="clearfix">
                                                </div>

                                                <hr />
                                            </div>
                                            <div class="col-12 form-group row mb-3">
                                                <div class="col-sm-12">
                                                    <asp:Panel runat="server" ID="pnlDetails" Visible="false">
                                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="mobile-fix">
                                                            <tr>
                                                                <td align="center">التاريخ
                                                            <br>
                                                                </td>
                                                                <td align="center">الوقت
                                                            <br>
                                                                </td>
                                                                <td align="center">السيرة الذاتية للمحاضر<br>
                                                                </td>
                                                                <td align="center">اسم المحاضر
                                                            <br>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Label runat="server" ID="lblAddress" Text="العنوان"></asp:Label><br>
                                                                </td>
                                                                <td align="center">المحاور<br>
                                                                </td>
                                                                <td align="center">عدد الحضور
                                                            <br>
                                                                </td>
                                                            </tr>
                                                            <asp:Repeater ID="rpDetails" runat="server" OnItemCommand="rpDetails_ItemCommand">
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td>
                                                                         
                                                                                    <div class="input-group">
                                                                                        <asp:UpdatePanel runat="server" ID="txtdetails">
                                                                                            <ContentTemplate>
                                                                                                <div class="input-group date">
                                                                                                    <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                                                                                    <asp:TextBox ID="txtDate" runat="server" Text='<%# Eval("txtDate").ToString() %>' onkeypress="return false;" onpaste="return false;" CssClass="form-control"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFiedetails1" runat="server"
                                                                                                        ControlToValidate="txtDate" CssClass="red" ErrorMessage="حقول مطلوبة "
                                                                                                        Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                                                                                    <asp:Label runat="server" ID="lblDetailsMessage" Visible="false" CssClass="red" Text="يجب أن لا يكون التاريخ قبل بداية المشروع"></asp:Label>
                                                                                                </div>
                                                                                            </ContentTemplate>
                                                                                            <Triggers>
                                                                                                <asp:AsyncPostBackTrigger ControlID="txtDate" />
                                                                                            </Triggers>
                                                                                        </asp:UpdatePanel>
                                                                                    </div>
                                                                                
                                                                        </td>
                                                                        <td>
                                                                            
                                                                                    <div class="input-group">
                                                                                        <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
                                                                                        <asp:TextBox ID="txtStartTime" runat="server" Text='<%# Eval("txtStartTime").ToString() %>' CssClass="form-control"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server"
                                                                                            ControlToValidate="txtStartTime" CssClass="red" ErrorMessage="حقول مطلوبة "
                                                                                            Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                </div>
                                                                           
                                                                                    <div class="input-group">
                                                                                        <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>

                                                                                        <asp:TextBox ID="txtEndTime" runat="server" Text='<%# Eval("txtEndTime").ToString() %>' CssClass="form-control"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server"
                                                                                            ControlToValidate="txtEndTime" CssClass="red" ErrorMessage="حقول مطلوبة "
                                                                                            Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                                                                    
                                                                              
                                                                        </td>
                                                                        <td>
                                                                           
                                                                                    <asp:FileUpload runat="server" ID="fbCv" CssClass="form-control" ClientIDMode="Static" onchange="showpreview(fbCv,1);" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                                                        ControlToValidate="fbCv" CssClass="red" ErrorMessage="حقول مطلوبة "
                                                                                        Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                                                                                        ErrorMessage="Only .pdf files are allowed." CssClass="red"
                                                                                        ValidationExpression="^.*\.(pdf|PDF)$"
                                                                                        ControlToValidate="fbCv" Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RegularExpressionValidator>
                                                                                    <asp:TextBox ID="txtCv" Visible="false" runat="server" Text='<%# Eval("txtCv").ToString() %>' CssClass="form-control"></asp:TextBox>
                                                                             
                                                                        </td>
                                                                        <td>
                                                                            
                                                                                    <asp:TextBox ID="txtNameofSpeaker" runat="server" Text='<%# Eval("txtNameofSpeaker").ToString() %>' CssClass="form-control"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator21" ControlToValidate="txtNameofSpeaker" CssClass="red"
                                                                                        ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                                                        ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                                                        ControlToValidate="txtNameofSpeaker" CssClass="red" ErrorMessage="حقول مطلوبة "
                                                                                        Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                                                             
                                                                        </td>
                                                                        <td>
                                                                           
                                                                                    <asp:TextBox ID="txtAddress" runat="server" Text='<%# Eval("txtAddress").ToString() %>' CssClass="form-control"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator17" ControlToValidate="txtAddress" CssClass="red"
                                                                                        ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                                                        ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server"
                                                                                        ControlToValidate="txtAddress" CssClass="red" ErrorMessage="حقول مطلوبة "
                                                                                        Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RequiredFieldValidator>

                                                                               
                                                                        </td>
                                                                        <td>
                                                                            
                                                                                    <asp:TextBox ID="txtAxces" runat="server" Text='<%# Eval("txtAxces").ToString() %>' CssClass="form-control"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server"
                                                                                        ControlToValidate="txtAxces" CssClass="red" ErrorMessage="حقول مطلوبة "
                                                                                        Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator18" ControlToValidate="txtAxces" CssClass="red"
                                                                                        ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                                                        ValidationGroup="submitionform"> </asp:RegularExpressionValidator>

                                                                              
                                                                        </td>
                                                                        <td>
                                                                           
                                                                                    <asp:TextBox ID="txtNumberofattendence" runat="server" Text='<%# Eval("txtNumberofattendence").ToString() %>' CssClass="form-control"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server"
                                                                                        ControlToValidate="txtNumberofattendence" CssClass="red" ErrorMessage="حقول مطلوبة "
                                                                                        Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RequiredFieldValidator>

                                                                             
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                            <tr>
                                                                <td style="font-size: 27px; color: #F00; font-weight: 600;" align="center">
                                                                    <asp:LinkButton ID="btnAdd" runat="server" Text="+"
                                                                        OnClick="btnAdd_Click" Style="font-size: 27px; color: #F00; font-weight: 600; text-decoration: none" Font-Size="13px" Font-Underline="true"
                                                                        ValidationGroup="persDetails" />
                                                                </td>
                                                                <td>
                                                                    <p align="center" dir="RTL">
                                                                        &nbsp;
                                                                    </p>
                                                                </td>
                                                                <td>
                                                                    <p align="center" dir="RTL">
                                                                        &nbsp;
                                                                    </p>
                                                                </td>
                                                                <td>
                                                                    <p align="center" dir="RTL">
                                                                    &nbsp;</td>
                                                                <td>
                                                                    <p align="center" dir="RTL">
                                                                    &nbsp;</td>
                                                                <td>
                                                                    <p style="float: left;" dir="RTL">
                                                                        <asp:LinkButton ID="lnkDetailCancel" runat="server" Text="-" OnClick="lnkDetailCancel_Click" Visible="false"
                                                                            Style="font-size: 27px; color: #F00; font-weight: 600; text-decoration: none" Font-Size="13px" Font-Underline="true"
                                                                            ValidationGroup="persDetails" />
                                                                    </p>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel runat="server" ID="pnlFile" Visible="false">
                                                        <div class="col-sm-6 pull-right">
                                                            <h5 class="col-sm-12 text-right">ورقة عمل للمؤتمر</h5>
                                                            <div class="col-sm-9 col-xs-12 pull-right">
                                                                <div class="fileupload fileupload-new" data-provides="fileupload">
                                                                    <div class="input-append">
                                                                        <asp:FileUpload ID="fpconferencewrkingpapper" runat="server" CssClass="form-control input-rounded" ClientIDMode="Static" onchange="showpreview(fpconferencewrkingpapper,1);" />

                                                                    </div>
                                                                </div>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server"
                                                                    ControlToValidate="fpconferencewrkingpapper" CssClass="red" ErrorMessage="حقول مطلوبة "
                                                                    Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RequiredFieldValidator>

                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                                                                    ErrorMessage="Only .pdf files are allowed." CssClass="red"
                                                                    ValidationExpression="^.*\.(pdf|PDF)$"
                                                                    ControlToValidate="fpconferencewrkingpapper" Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RegularExpressionValidator>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                </div>
                                                <div class="clearfix">
                                                </div>

                                            </div>

                                            <%--  <div class="text-2 text-danger" style="font-family: Tahoma;">
                                        1st, 2nd, 3rd, 4th, 5th radio to 1st, 2nd radio
                                    </div>--%>

                                            <%--   <div class="text-2 text-danger" style="font-family: Tahoma;">
                                        1st, 2nd, 3rd, 4th, 5th radio to 1st, 2nd radio
                                    </div>--%>
                                            <div class="row" style="margin-right:30px;">
                                            <div class="col-12  form-group row mb-3">
                                                <h2 class="ipages_title1"><strong>الخطة الإعلامية</strong>
                                                    <asp:Label ID="Label2" runat="server" title="إعلانات الطرق، الصحف أو بوست الإنستقرام،تويتر أو أي طريقة يراها مقدم الطلب مناسبة مع ذكر أسماء الحسابات والصحف التي سيتم الاعلان فيها مع ذكر التكلفة 
"><i class="fa fa-question-circle"></i></asp:Label>
                                                </h2>

                                                <div class="col-sm-3 col-md-3 hide-mobile"></div>
                                                <div class="col-sm-9 col-md-9">
                                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                        <tr>
                                                            <td align="center">م
                                                            </td>
                                                            <td align="center">مكان الإعلان
                                                        <br>
                                                            </td>
                                                            <td align="center">عدد الإعلانات
                                                        <br>
                                                            </td>
                                                            <td align="center">تفاصيل الإعلان
                                                        <br>
                                                            </td>
                                                            <td align="center">تكلفة الإعلان
                                                        <br>
                                                            </td>
                                                        </tr>
                                                        <asp:Repeater ID="RpMedia" runat="server" OnItemCommand="RpMedia_ItemCommand">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td align="center"><span class="nf"><%# Container.ItemIndex + 1 %></span>
                                                                    </td>
                                                                    <td>
                                                                     
                                                                            <asp:TextBox runat="server" ID="txtPlace" Text='<%# Eval("txtPlace").ToString() %>' CssClass="form-control input-rounded"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtPlace"
                                                                                CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                                ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                                                        
                                                                    </td>
                                                                    <td>
                                                                    
                                                                            <asp:TextBox runat="server" ID="txtNumberAdd" Text='<%# Eval("txtNumberAdd").ToString() %>' CssClass="form-control input-rounded"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtNumberAdd"
                                                                                CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                                ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                                                        
                                                                    </td>
                                                                    <td>
                                                                        
                                                                            <asp:TextBox runat="server" ID="txtAddDetails" Text='<%# Eval("txtAddDetails").ToString() %>' CssClass="form-control input-rounded"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtAddDetails"
                                                                                CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                                ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                                                        
                                                                    </td>
                                                                    <td>
                                                                        
                                                                            <asp:TextBox runat="server" ID="txtCostMedia" CausesValidation="true" ValidationGroup="persMedia" Text='<%# Eval("txtCostDetails").ToString() %>' MaxLength="5" OnTextChanged="txtCostMedia_TextChanged" AutoPostBack="true" CssClass="form-control input-rounded"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtCostMedia"
                                                                                CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                                ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator
                                                                                EnableClientScript="true"
                                                                                ID="RegularCostMedia" runat="server"
                                                                                ErrorMessage="فضلا أدخل أرقام فقط "
                                                                                ValidationGroup="persMedia"
                                                                                ControlToValidate="txtCostMedia" Display="dynamic"
                                                                                ValidationExpression="^\d+?$"
                                                                                CssClass="red" SetFocusOnError="true" />
                                                                       


                                                                    </td>

                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                        <tr>
                                                            <td></td>
                                                            <td>
                                                            
                                                            </td>
                                                            <td>
                                                              
                                                            </td>
                                                            <td>
                                                                
                                                            </td>
                                                            <td>
                                                                
                                                                    <h5>
                                                                        <asp:Label runat="server" ID="txtToalCostMedia" Text="" CssClass="nf"></asp:Label></h5>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-size: 27px; color: #F00; font-weight: 600;" align="center">
                                                                <asp:LinkButton ID="lnk_MediaPlan" runat="server" Text="+"
                                                                    OnClick="lnk_MediaPlan_Click" Style="font-size: 27px; color: #F00; font-weight: 600; text-decoration: none" Font-Size="13px" Font-Underline="true"
                                                                    ValidationGroup="persMedia" />
                                                            </td>
                                                            <td>
                                                                <p align="center" dir="RTL">
                                                                    &nbsp;
                                                                </p>
                                                            </td>
                                                            <td>
                                                                <p align="center" dir="RTL">
                                                                    &nbsp;
                                                                </p>
                                                            </td>
                                                            <td>
                                                                <p align="center" dir="RTL">
                                                                    &nbsp;
                                                                </p>
                                                            </td>
                                                            <td>
                                                                <p style="float: left;" dir="RTL">
                                                                    <asp:LinkButton ID="lnkMediaCancel" runat="server" Text="-" OnClick="lnkMediaCancel_Click" Visible="false"
                                                                        Style="font-size: 27px; color: #F00; font-weight: 600; text-decoration: none" Font-Size="13px" Font-Underline="true"
                                                                        ValidationGroup="persMedia" />
                                                                </p>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <div class="clearfix">
                                                </div>
                                                <hr />
                                            </div>
                                                </div>

                                            <div class="col-12 form-group row mb-3">

                                                <h2 class="ipages_title1"><strong>الخطة المالية</strong> </h2>

                                                <div class="col-sm-3 hide-mobile"></div>
                                                <div class="col-sm-9 col-xs-12">
                                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                        <tr>
                                                            <td align="center">م
                                                            </td>
                                                            <td align="center">الاحتياجات
                                                            </td>
                                                            <td align="center">العدد
                                                            </td>
                                                            <td align="center">التكلفة
                                                            </td>
                                                            <td align="center">الإجمالي (العدد*التكلفة)
                                                            </td>
                                                        </tr>
                                                        <asp:Repeater ID="RPBudget" runat="server" OnItemCommand="RPBudget_ItemCommand">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td align="center"><span class="nf"><%# Container.ItemIndex + 1 %></span>
                                                                    </td>
                                                                    <td>
                                                                        
                                                                            <asp:TextBox runat="server" ID="txtItem" Text='<%# Eval("txtItem").ToString() %>' CssClass="form-control input-rounded"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtItem"
                                                                                CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                                ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator runat="server" ID="RegularExpressiontxtItem" ControlToValidate="txtItem" CssClass="red"
                                                                                ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                                                ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                                                      
                                                                    </td>
                                                                    <td>
                                                                      
                                                                            <asp:TextBox runat="server" ID="txtNumber" ValidationGroup="Vbudget" CausesValidation="true" Text='<%# Eval("txtNumber").ToString() %>' AutoPostBack="true" MaxLength="5" OnTextChanged="txtCostBudget_TextChanged" CssClass="form-control input-rounded"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtNumber"
                                                                                CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                                ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator
                                                                                EnableClientScript="true"
                                                                                ID="RegularExpressionValidator7" runat="server"
                                                                                ErrorMessage="فضلا أدخل أرقام فقط "
                                                                                ValidationGroup="Vbudget"
                                                                                ControlToValidate="txtNumber" Display="dynamic"
                                                                                ValidationExpression="^\d+?$"
                                                                                CssClass="red" SetFocusOnError="true" />
                                                                        
                                                                    </td>
                                                                    <td>
                                                                        
                                                                            <asp:TextBox runat="server" ID="txtCostBudget" ValidationGroup="Vbudget" CausesValidation="true" Text='<%# Eval("txtCost").ToString() %>' AutoPostBack="true" MaxLength="5" OnTextChanged="txtCostBudget_TextChanged" CssClass="form-control input-rounded"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtCostBudget"
                                                                                CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                                ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator
                                                                                EnableClientScript="true"
                                                                                ID="RegularExpressionValidator8" runat="server"
                                                                                ErrorMessage="فضلا إدخل أرقام فقط "
                                                                                ValidationGroup="Vbudget"
                                                                                ControlToValidate="txtCostBudget" Display="dynamic"
                                                                                ValidationExpression="^\d+?$"
                                                                                CssClass="red" SetFocusOnError="true" />
                                                                        
                                                                    </td>
                                                                    <td>
                                                                        
                                                                            <asp:TextBox runat="server" ID="txtTotalcost" Enabled="false" Text='<%# Eval("txtTotalcost").ToString() %>' CssClass="form-control input-rounded"></asp:TextBox>
                                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtTotalcost"
                                                                        CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                        ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator
                                                                        EnableClientScript="true"
                                                                        ID="RegularExpressionValidator9" runat="server"
                                                                        ErrorMessage="فضلا أدخل أرقام فقط "
                                                                        ValidationGroup="submitionform"
                                                                        ControlToValidate="txtTotalcost" Display="dynamic"
                                                                        ValidationExpression="^\d+?$"
                                                                        CssClass="red" SetFocusOnError="true" />--%>
                                                                        
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                        <tr>
                                                            <td></td>
                                                            <td>
                                                             
                                                            </td>
                                                            <td>
                                                            
                                                            </td>
                                                            <td>
                                                           
                                                            </td>
                                                            <td>
                                                                <div class="col">
                                                                    <h5>
                                                                        <asp:Label runat="server" ID="txtTotalFinalcost" CssClass="nf" Text=""></asp:Label></h5>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-size: 27px; color: #F00; font-weight: 600;" align="center">
                                                                <asp:LinkButton ID="lnkBudget" runat="server" Text="+"
                                                                    OnClick="lnkBudget_Click" Style="font-size: 27px; color: #F00; font-weight: 600; text-decoration: none" Font-Size="13px" Font-Underline="true"
                                                                    ValidationGroup="Vbudget" />
                                                            </td>
                                                            <td>
                                                                <p align="center" dir="RTL">
                                                                    &nbsp;
                                                                </p>
                                                            </td>
                                                            <td>
                                                                <p align="center" dir="RTL">
                                                                    &nbsp;
                                                                </p>
                                                            </td>
                                                            <td>
                                                                <p align="center" dir="RTL">
                                                                    &nbsp;
                                                                </p>
                                                            </td>
                                                            <td>
                                                                <p style="float: left;" dir="RTL">
                                                                    <asp:LinkButton ID="lnkBugetCancel" runat="server" Text="-" OnClick="lnkBugetCancel_Click" Visible="false"
                                                                        Style="font-size: 27px; color: #F00; font-weight: 600; text-decoration: none" Font-Size="13px" Font-Underline="true"
                                                                        ValidationGroup="Vbudget" />
                                                                </p>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <div class="clearfix">
                                                </div>
                                                <hr />
                                            </div>

                                            <div class="col-12 form-group row mb-3">
                                                <label class="col-sm-3 pull-right">
                                                    الرعاة (إن وجد)
                                                </label>
                                                <div class="col-sm-9 col-xs-12">
                                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                        <tr>
                                                            <td align="center">م
                                                            </td>
                                                            <td align="center">اسم الراعي
                                                            </td>
                                                            <td align="center">نوع الرعاية
                                                            </td>
                                                            <td align="center">تفاصيل الرعاية
                                                            </td>
                                                        </tr>
                                                        <asp:Repeater ID="rpSponser" runat="server" OnItemCommand="rpSponser_ItemCommand">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td align="center"><span class="nf"><%# Container.ItemIndex + 1 %></span>
                                                                    </td>
                                                                    <td>
                                                                        
                                                                            <asp:TextBox runat="server" ID="txtSponserName" Text='<%# Eval("txtSponserName").ToString() %>' CssClass="form-control input-rounded"></asp:TextBox>
                                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtSponserName"
                                                                CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                ValidationGroup="submitionform"></asp:RequiredFieldValidator>--%>
                                                                            <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator18" ControlToValidate="txtSponserName" CssClass="red"
                                                                                ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                                                ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                                                  
                                                                    </td>
                                                                    <td>
                                                                        
                                                                            <asp:TextBox runat="server" ID="txtTypeCare" Text='<%# Eval("txtTypeCare").ToString() %>' CssClass="form-control input-rounded"></asp:TextBox>
                                                                            <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtTypeCare"
                                                                CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                ValidationGroup="submitionform"></asp:RequiredFieldValidator>--%>
                                                                            <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator19" ControlToValidate="txtTypeCare" CssClass="red"
                                                                                ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                                                ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                                                       
                                                                    </td>
                                                                    <td>
                                                                        
                                                                            <asp:TextBox runat="server" ID="txtCareDetails" Text='<%# Eval("txtCareDetails").ToString() %>' CssClass="form-control input-rounded"></asp:TextBox>
                                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtCareDetails"
                                                                CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                ValidationGroup="submitionform"></asp:RequiredFieldValidator>--%>
                                                                            <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator20" ControlToValidate="txtCareDetails" CssClass="red"
                                                                                ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                                                ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                                                       
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                        <tr>
                                                            <td style="font-size: 27px; color: #F00; font-weight: 600;" align="center">
                                                                <asp:LinkButton ID="lnksponser" runat="server" Text="+"
                                                                    OnClick="lnksponser_Click" Style="font-size: 27px; color: #F00; font-weight: 600; text-decoration: none" Font-Size="13px" Font-Underline="true"
                                                                    ValidationGroup="persSponser" />
                                                            </td>
                                                            <td>
                                                                <p align="center" dir="RTL">
                                                                    &nbsp;
                                                                </p>
                                                            </td>
                                                            <td>
                                                                <p align="center" dir="RTL">
                                                                    &nbsp;
                                                                </p>
                                                            </td>
                                                            <td>
                                                                <p style="float: left;" dir="RTL">
                                                                    <asp:LinkButton ID="lnkSponserCanel" runat="server" Text="-" OnClick="lnkSponserCanel_Click" Visible="false"
                                                                        Style="font-size: 27px; color: #F00; font-weight: 600; text-decoration: none" Font-Size="13px" Font-Underline="true"
                                                                        ValidationGroup="persSponser" />
                                                                </p>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <div class="clearfix">
                                                </div>
                                                <hr />
                                            </div>



                                            <div class="col-12 form-group row mb-3">
                                                <label class="col-sm-3 pull-right">
                                                    السيرة الذاتية لمقدم الطلب
                                                </label>
                                                <div class="col-sm-9 col-xs-12 pull-right">
                                                    <div class="fileupload fileupload-new" data-provides="fileupload">
                                                        <div class="input-append">
                                                            <asp:FileUpload ID="txtCvofapplicant" runat="server" CssClass="form-control input-rounded" ClientIDMode="Static" onchange="showpreview(txtCvofapplicant,1);" />

                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="txtCvofapplicant"
                                                                ErrorMessage="حقول مطلوبة" SetFocusOnError="true" Display="Dynamic"
                                                                CssClass="red" ValidationGroup="submitionform">
                                                            </asp:RequiredFieldValidator>

                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                                                ErrorMessage="Only .pdf files are allowed." CssClass="red"
                                                                ValidationExpression="^.*\.(pdf|PDF)$"
                                                                ControlToValidate="txtCvofapplicant" Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="clearfix">
                                                </div>
                                            </div>

                                            <div class="clearfix">
                                            </div>
                                            <div class="text-2 text-danger">
                                                ملاحظة: يجب ارفاق كافات الشهادات المذكورة في السير ة الذاتية
                                            </div>
                                            <div class="clearfix">
                                            </div>
                                            <hr />
                                            <div class="col-12 form-group row mb-3">
                                                <label class="col-sm-3 pull-right  pt-2">
                                                    ارفق الخطه الزمنيه اقل من      

2MB 
                                                </label>
                                                <div class="col-sm-9 col-xs-12 pull-right">
                                                    <asp:FileUpload ID="fpexecutiveplan" runat="server" CssClass="form-control input-rounded" ClientIDMode="Static" onchange="showpreview(fpexecutiveplan,2);" />

                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="fpexecutiveplan"
                                                                                        CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                                        ValidationGroup="submitionform">
                                                                                    </asp:RequiredFieldValidator>--%>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator33" runat="server"
                                                        ErrorMessage="Only .pdf files are allowed." CssClass="red"
                                                        ValidationExpression="^.*\.(pdf|PDF)$"
                                                        ControlToValidate="fpexecutiveplan" Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RegularExpressionValidator>
                                                </div>
                                                <div class="clearfix">
                                                </div>

                                                <hr />
                                            </div>


                                            <asp:Panel runat="server" ID="Panelcivil" Visible="false">
                                                <div class="col-12 form-group row mb-3">
                                                    <label class="col-sm-3 pull-right  pt-2" for="inputRounded">
                                                        صورةالبطاقة المدنية
                                                    </label>
                                                    <div class="col-sm-9 col-xs-12 pull-right">
                                                        <asp:HiddenField runat="server" ID="hdUserCivilID" />
                                                        <asp:HiddenField runat="server" ID="hdUserCivilPath" />
                                                        <asp:FileUpload ID="filecivil" runat="server" CssClass="form-control input-rounded" ClientIDMode="Static" onchange="showpreview(filecivil,1);" />
                                                        <div class="input-append">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="filecivil"
                                                                CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                ValidationGroup="submitionform">
                                                            </asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator28" runat="server"
                                                                ErrorMessage="Only .pdf files are allowed." CssClass="red"
                                                                ValidationExpression="^.*\.(pdf|PDF)$"
                                                                ControlToValidate="filecivil" Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix">
                                                    </div>
                                                </div>

                                                <hr />


                                            </asp:Panel>
                                            <div class="col-12 form-group row mb-3">
                                                <label class="col-sm-3 pull-right  pt-2" for="inputRounded">
                                                    هل أنت مهتم بالعمل التطوعي؟
                                                </label>
                                                <div class="col-sm-6 col-xs-12 pull-right radio radio-info">

                                                    <asp:RadioButtonList runat="server" ID="RBVolounteer" RepeatDirection="Horizontal"
                                                        RepeatLayout="Flow">

                                                        <asp:ListItem Value="1" Text="نعم"></asp:ListItem>
                                                        <asp:ListItem Value="0" Text="لا"></asp:ListItem>
                                                    </asp:RadioButtonList>

                                                    <p>
                                                    </p>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="RBVolounteer" runat="server" ErrorMessage="حقول مطلوبة" SetFocusOnError="true" Display="Dynamic"
                                                        CssClass="red" ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="clearfix">
                                                </div>


                                            </div>


                                            <hr />
                                        </asp:Panel>

                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <asp:Panel runat="server" ID="pnlbutton" Visible="false">


                                    <div class="col-12 form-group row mb-3 text-center">
                                        <div class="text-center">
                                            <asp:LinkButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" ValidationGroup="submitionform" CssClass="btn btn-lg btn-info m-auto" Text="ارسل" />
                                        </div>
                                    </div>
                                </asp:Panel>
                                 
                                


                            </div>

                        
                            
                        </div>
                           
                  
                </div>
            </div>
        </div>
    </section>





</asp:Content>
