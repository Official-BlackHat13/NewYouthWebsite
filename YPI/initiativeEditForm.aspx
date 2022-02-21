<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteMasterPage.master" Culture="en-GB" ValidateRequest="false"
    CodeFile="initiativeEditForm.aspx.cs" ClientIDMode="AutoID" Inherits="initiativeForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">


    <link href="../Content/CSS/ini-form/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="../Content/CSS/ini-form/style1.css" type="text/css" />
    <link href="../Content/CSS/ini-form/default.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Content/CSS/ini-form/font-awesome.min.css" rel="stylesheet" />
    <script src="../Content/JS/ini-form/jquery-ui.js"></script>



    <script type="text/javascript">
        $(function () {
            $('[data-toggle="tooltip"]').tooltip()
        })
    </script>



    <script type="text/javascript">
        $('#txtStartTime').timepicker();
    </script>


    <script type="text/javascript">
        function showpreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                if (input.files[0].size > 5242880) {
                    alert("Should not exceed 5MB")
                    $(input).val('');
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
    <style>
         .initiate-form .checkbox input[type=checkbox], .checkbox-inline input[type=checkbox], .radio input[type=radio], .radio-inline input[type=radio] {
          position:absolute;
          margin-right:4px;
      }
    </style>




</asp:Content>
<asp:Content ID="Content" runat="server" ContentPlaceHolderID="PageContent">


    <section>
        <div class="container-fluid">
            <div class="container py-5 mt-110 inside-page">
                <div class="container bg-white">
                    <div class="container new-services initiate-form">
                        <div class="row" dir="rtl">
                            <div class="col-xs-12 text-right">
                                <div class="form-horizontal">
                                   
                                    <div id="alert" class="notification msgalert" runat="server" visible="false">
                                        <p>Submitted Aleardy</p>
                                    </div>
                                    <div id="alertAge" class="notification msgalert" runat="server" visible="false">
                                        <p>You are Not Eligible to apply .Kindly check Term and conditions</p>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-xs-12 form-bg1">

                                <div class="heading-bg">
                                    <h1 class="form-style"><strong>نموذج المبادر المحترف  </strong></h1><div class="line"></div>
                                </div>


                                

                                     <asp:Panel runat="server" ID="divFormPanel" Visible="true">
                                    <div class="form-horizontal">
                                        <div class="cont col-xs-12">
                                            <div class="col-sm-12">
                                                <div class="form-row ">

                                                    <asp:HiddenField ID="hiddenID" runat="server" />
                                                    <asp:HiddenField ID="hdinitiativeId" runat="server" />

                                                    <asp:UpdatePanel ID="experienceupdatepanel" runat="server">
                                                        <ContentTemplate>
                                                            <div class="col-12 form-group row mb-3">

                                                                <label class="col-sm-3 control-label text-lg-left pt-2" for="inputRounded">
                                                                    مقدم الطلب
                                                                </label>
                                                                <div class="col-sm-9 col-xs-12  radio radio-info">
                                                                    <asp:RadioButtonList runat="server" ID="RBIntiativeType" RepeatDirection="Horizontal"
                                                                        RepeatLayout="Flow" AutoPostBack="true" OnSelectedIndexChanged="RBIntiativeType_SelectedIndexChanged">
                                                                    </asp:RadioButtonList>
                                                                    <asp:RequiredFieldValidator ID="ReqIntiativeCatagory" runat="server" ErrorMessage="مطلوب هذه الخانة"
                                                                        ControlToValidate="RBIntiativeType" CssClass="red" Display="Dynamic"
                                                                        ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                                                </div>



                                                                <div class="clearfix">
                                                                    <asp:Label runat="server" Visible="false" ID="lblAgeMessage" CssClass="red" Text="لايمكنك التقديم على(أفراد،مجموعات شبابية) في حال تجاوز العمر 35"></asp:Label>
                                                                </div>

                                                            </div>

                                                            <asp:Panel ID="ExperiencePanel" runat="server" Visible="true">

                                                                <div class="col-12 form-group row mb-3">

                                                                    <label class="col-sm-3 control-label text-lg-left pt-2" for="inputRounded">
                                                                        هل سبق لك أن قدمت مشروع مشابه 
                                                                    </label>
                                                                    <div class="col-sm-9 col-xs-12  radio radio-info">
                                                                        <asp:RadioButtonList runat="server" ID="ExperienceRadioList" RepeatDirection="Horizontal"
                                                                            RepeatLayout="Flow" AutoPostBack="true" OnSelectedIndexChanged="ExperienceRadioList_SelectedIndexChanged">
                                                                            <asp:ListItem Text="نعم" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="لا" Value="0"></asp:ListItem>

                                                                        </asp:RadioButtonList>
                                                                        <asp:RequiredFieldValidator ID="rqdExperienceRadioList" runat="server" ErrorMessage="مطلوب هذه الخانة"
                                                                            ControlToValidate="ExperienceRadioList" CssClass="red" Display="Dynamic"
                                                                            ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                                                    </div>


                                                                </div>
                                                                <asp:Panel runat="server" ID="TypeofExperienceDivision" Visible="false">

                                                                    <div class="col-12 form-group row mb-3">
                                                                        <label class="col-sm-3 control-label text-lg-left pt-2" for="inputRounded">
                                                                            طبيعة المشروع
                                                                        </label>
                                                                        <div class="col-sm-9 col-xs-12  radio radio-info">
                                                                            <asp:RadioButtonList runat="server" ID="RBTypeofExperience" RepeatDirection="Horizontal" OnSelectedIndexChanged="RBTypeofExperience_SelectedIndexChanged"
                                                                                RepeatLayout="Flow" AutoPostBack="true">
                                                                                <asp:ListItem Text="مشروع عائلي " Value="1"></asp:ListItem>
                                                                                <asp:ListItem Text="مشروع سابق " Value="0"></asp:ListItem>
                                                                                 <asp:ListItem Text="مشروع جديد " Value="2"></asp:ListItem>

                                                                            </asp:RadioButtonList>
                                                                            <asp:RequiredFieldValidator ID="RqdTypeofExperience" runat="server" ErrorMessage="مطلوب هذه الخانة"
                                                                                ControlToValidate="RBTypeofExperience" CssClass="red" Display="Dynamic"
                                                                                ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                </asp:Panel>
                                                            </asp:Panel>

                                                            <asp:Panel runat="server" ID="ExperienceInformationDivision" Visible="false">
                                                                <div class="col-12 form-group row mb-3">
                                                                    <label class="col-sm-3 control-label text-lg-left pt-2" for="inputRounded">
                                                                        نبذة عن المشروع
                                                                    </label>
                                                                    <div class="col-sm-8 col-xs-12 pull-right">
                                                                        <asp:TextBox ID="TxTExperienceProjectDescription" TextMode="MultiLine" Columns="5" runat="server" CssClass="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxTExperienceProjectDescription"
                                                                            CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                            ValidationGroup="submitionform">
                                                                        </asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="col-12 form-group row mb-3">

                                                                    <label class="col-sm-3 control-label text-lg-left pt-2" for="inputRounded">
                                                                        هل كانت تجربتك بالمشروع ناجحة أم واجهتك معوقات؟
                                                                    </label>
                                                                    <div class="col-sm-9 col-xs-12 radio radio-info">
                                                                        <asp:RadioButtonList runat="server" ID="RBExperienceProjectStatus" RepeatDirection="Horizontal" ClientIDMode="AutoID" OnSelectedIndexChanged="RBExperienceProjectStatus_CheckedChanged"
                                                                            RepeatLayout="Flow" AutoPostBack="true">
                                                                            <asp:ListItem Text="ناجح" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="واجهتك معوقات" Value="0"></asp:ListItem>

                                                                        </asp:RadioButtonList>
                                                                        <asp:RequiredFieldValidator ID="reqxperienceProjectStatus" runat="server" ErrorMessage="مطلوب هذه الخانة"
                                                                            ControlToValidate="RBExperienceProjectStatus" CssClass="red" Display="Dynamic"
                                                                            ValidationGroup="submitionform"></asp:RequiredFieldValidator>
                                                                    </div>


                                                                </div>


                                                            </asp:Panel>


                                                            <div class="col-12 form-group row mb-3" runat="server" id="SucessDivision" visible="false">

                                                                <label class="col-sm-3 control-label text-lg-left pt-2" for="inputRounded">
                                                                    اذكر مقومات النجاح
                                                                </label>
                                                                <div class="col-sm-8 col-xs-12 pull-right">
                                                                    <asp:TextBox ID="TxtSucess" runat="server" CssClass="form-control input-rounded"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtSucess"
                                                                        CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                        ValidationGroup="submitionform">
                                                                    </asp:RequiredFieldValidator>
                                                                </div>




                                                            </div>

                                                            <div class="col-12 form-group row mb-3" runat="server" id="FailureDivision" visible="false">

                                                                <label class="col-sm-3 control-label text-lg-left pt-2" for="inputRounded">
                                                                    اذكر معوقات المشروع  
                                                                </label>
                                                                <div class="col-sm-8 col-xs-12 pull-right">
                                                                    <asp:TextBox ID="txtfailure" runat="server" CssClass="form-control input-rounded"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfailure"
                                                                        CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                        ValidationGroup="submitionform">
                                                                    </asp:RequiredFieldValidator>
                                                                </div>

                                                            </div>

                                                            <h2 class="ipages_title1 text-right"><strong>بيانات المشروع</strong> </h2>


                                                            <div class="col-12 form-group row mb-3" runat="server" id="divProjectname">
                                                                <label class="col-sm-3 control-label text-lg-left pt-2" for="inputRounded">
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



                                                            </div>

                                                            <div class="col-12 form-group row mb-3" style="float:right;">
                                                                <%-- <label class="col-sm-3 control-label text-lg-left pt-2">
                                                                    المجال  &nbsp; &nbsp;( <a href="Document/suspendedActivity.pdf" target="_blank"><span class="red">قبل ادخال اسم المشروع يجب التأكد ان المشروع يندرج ضمن هذه المجالات الأربعة </span></a>)
                                                                </label>--%>
                                                                <label class="col-sm-3 control-label text-lg-left pt-2">
                                                                    المجال  &nbsp; &nbsp;( <a href="Document/suspendedActivity.pdf" target="_blank"><span class="red">قبل ادخال اسم المشروع يجب التأكد ان المشروع يندرج ضمن هذه القطاعات الستة  </span></a>)
                                                                </label>
                                                                <div class="col-sm-9 col-xs-12  radio radio-info">

                                                                    <asp:RadioButtonList runat="server" ID="RBProjectCategory" RepeatDirection="Horizontal" OnSelectedIndexChanged="RBProjectCategory_SelectedIndexChanged"
                                                                        RepeatLayout="Flow" AutoPostBack="true">
                                                                    </asp:RadioButtonList>


                                                                    <asp:RequiredFieldValidator ID="rqcRBProjectCategory" runat="server" ErrorMessage="مطلوب هذه الخانة"
                                                                        ControlToValidate="RBProjectCategory" CssClass="red" Display="Dynamic"
                                                                        ValidationGroup="submitionform"></asp:RequiredFieldValidator><br />


                                                                </div>
                                                                <div class="clearfix">
                                                                </div>


                                                            </div>
                                                            <div class="col-12 form-group row mb-3">

                                                                <label class="col-sm-3 control-label">اسم مقدم الطلب(حسب البطاقة المدنية)  </label>
                                                                <div class="col-sm-2 col-xs-12 pull-right">
                                                                    <asp:TextBox ID="txtFname" Style="margin-bottom: 5px;" placeholder="الأول" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server"
                                                                        ControlToValidate="txtFname" CssClass="red"
                                                                        ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                        ValidationGroup="submitionform"> </asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator24" ControlToValidate="txtFname" CssClass="red"
                                                                        ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                                        ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                                                </div>
                                                                <div class="col-sm-2 col-xs-12 pull-right">
                                                                    <asp:TextBox ID="txtMname" Style="margin-bottom: 5px;" placeholder="الثاني" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server"
                                                                        ControlToValidate="txtMname" CssClass="red"
                                                                        ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                        ValidationGroup="submitionform"> </asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator25" ControlToValidate="txtMname" CssClass="red"
                                                                        ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                                        ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                                                </div>
                                                                <div class="col-sm-2 col-xs-12 pull-right">
                                                                    <asp:TextBox ID="txtThirdName" Style="margin-bottom: 5px;" placeholder="الثالث" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server"
                                                                        ControlToValidate="txtThirdName" CssClass="red"
                                                                        ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                        ValidationGroup="submitionform"> </asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator26" ControlToValidate="txtThirdName" CssClass="red"
                                                                        ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                                        ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                                                </div>
                                                                <div class="col-sm-2 col-xs-12 pull-right">
                                                                    <asp:TextBox ID="txtsurname" Style="margin-bottom: 5px;" placeholder="الأخير" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server"
                                                                        ControlToValidate="txtsurname" CssClass="red"
                                                                        ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                        ValidationGroup="submitionform"> </asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator27" ControlToValidate="txtsurname" CssClass="red"
                                                                        ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                                        ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                                                </div>
                                                            </div>




                                                            <div class="col-12 form-group row mb-3">
                                                                <label class="col-sm-3 control-label text-lg-left pt-2">
                                                                    المؤهل الدراسي
                                                                </label>
                                                                <div class="col-sm-8 col-xs-12 pull-right">
                                                                    <asp:DropDownList runat="server" ID="drpEduQulification" AppendDataBoundItems="true" AutoPostBack="true" CssClass="form-control form-control mb-3" OnSelectedIndexChanged="drpEduQulification_SelectedIndexChanged">
                                                                    </asp:DropDownList>

                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="drpEduQulification"
                                                                        ErrorMessage="حقول مطلوبة" SetFocusOnError="true" Display="Dynamic"
                                                                        CssClass="red" InitialValue="0" ValidationGroup="submitionform">
                                                                    </asp:RequiredFieldValidator>
                                                                </div>
                                                                <div class="clearfix">
                                                                </div>


                                                            </div>



                                                            <div class="col-12 form-group row mb-3" runat="server" id="divEduQuliOther" visible="false">
                                                                <label class="col-sm-3 control-label text-lg-left pt-2">
                                                                </label>
                                                                <div class="col-sm-8 col-xs-12 pull-right">
                                                                    <asp:TextBox runat="server" ID="TxtEduQuliOther" CssClass="form-control"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TxtEduQuliOther"
                                                                        ErrorMessage="حقول مطلوبة" SetFocusOnError="true" Display="Dynamic"
                                                                        CssClass="red" ValidationGroup="submitionform">
                                                                    </asp:RequiredFieldValidator>
                                                                    <asp:Label runat="server" ID="LblError" CssClass="red"></asp:Label>
                                                                </div>
                                                                <div class="clearfix">
                                                                </div>


                                                            </div>


                                                            <div class="col-12 form-group row mb-3">
                                                                <label class="col-sm-3 control-label text-lg-left pt-2" for="inputRounded">
                                                                    شرح تفصيلي للمشروع
                                                                </label>
                                                                <div class="col-sm-8 col-xs-12  pull-right">
                                                                    <asp:TextBox runat="server" ID="TxTProjectDescription" CssClass="form-control" CausesValidation="true" TextMode="MultiLine" Rows="3" Columns="5"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="TxTProjectDescription"
                                                                        CssClass="red" ErrorMessage="حقول مطلوبة " Display="Dynamic" SetFocusOnError="true"
                                                                        ValidationGroup="submitionform">
                                                                    </asp:RequiredFieldValidator>

                                                                    <%--      <asp:RegularExpressionValidator ID="RegularExpressionValidator30" runat="server" ControlToValidate="TxTProjectDescription" SetFocusOnError="true"
                                                                Display="Dynamic" ErrorMessage="لا يقل عن 1 كلمة ولا يزيد عن 700 كلمة" CssClass="red"
                                                                ValidationGroup="submitionform"
                                                                ValidationExpression="[\s\S]{1,5000}"></asp:RegularExpressionValidator>--%>
                                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator16"
                                                                        ControlToValidate="TxTProjectDescription" CssClass="red"
                                                                        ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic"
                                                                        SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                                                        ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                                                </div>
                                                            </div>
                                                            <div class="clearfix">
                                                            </div>

                                                            <div class="col-12 form-group row mb-3">
                                                                <label class="col-sm-3 control-label text-lg-left pt-2 nf" for="inputRounded">
                                                                    الأهداف(على أن تكون على هيئة نقاط)
                                                                </label>
                                                                <div class="col-sm-8 col-xs-12 mb-3 pull-right">

                                                                    <asp:TextBox runat="server" TextMode="MultiLine" ID="TxtProjectGoal" CausesValidation="true" CssClass="form-control" Rows="3" Columns="5" AutoPostBack="true"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RFVRoleofAppicant" runat="server"
                                                                        ControlToValidate="TxtProjectGoal" CssClass="red" ErrorMessage="حقول مطلوبة "
                                                                        Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RequiredFieldValidator>

                                                                    <asp:RegularExpressionValidator runat="server" ID="REVRoleofapplicant" ControlToValidate="TxtProjectGoal" CssClass="red"
                                                                        ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true"
                                                                        ValidationExpression="[^a-zA-Z]+"
                                                                        ValidationGroup="submitionform"> </asp:RegularExpressionValidator>
                                                                    <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator32" runat="server" ControlToValidate="TxtProjectGoal" SetFocusOnError="true"
                                                                Display="Dynamic" ErrorMessage="لا يقل عن 1 كلمة ولا يزيد عن 700 كلمة"
                                                                CssClass="red" ValidationGroup="submitionform"
                                                                ValidationExpression="[\s\S]{1,5000}"></asp:RegularExpressionValidator>--%>
                                                                    <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server" ControlToValidate="TxtProjectGoal"
                                                                Display="Dynamic" ErrorMessage="لا يقل عن 20 كلمة ولا يزيد عن 300 كلمة" CssClass="red" SetFocusOnError="true"
                                                                ValidationExpression="[\s\S]{111,2500}" ValidationGroup="submitionform"></asp:RegularExpressionValidator>--%>
                                                                </div>
                                                            </div>

                                                            <div class="clearfix">
                                                            </div>
                                                            <asp:UpdatePanel runat="server" ID="updWhere">
                                                                <ContentTemplate>

                                                                    <div class="col-12 form-group row mb-3">
                                                                        <label class="col-sm-3 control-label text-lg-left pt-2">
                                                                            كيف علمت بنا  
                                                                        </label>
                                                                        <div class="col-sm-8 col-xs-12 pull-right">

                                                                            <asp:DropDownList runat="server" ID="DrpFromWhere" AutoPostBack="true" CssClass="form-control form-control mb-3" OnSelectedIndexChanged="DrpFromWhere_SelectedIndexChanged">
                                                                                <asp:ListItem Value="0">--select--</asp:ListItem>
                                                                                <asp:ListItem Value="1">التواصل الاجتماعي</asp:ListItem>
                                                                                <asp:ListItem Value="2">الاعلانات</asp:ListItem>
                                                                                <asp:ListItem Value="3">اصدقاء</asp:ListItem>
                                                                                <asp:ListItem Value="4">الحاضنات</asp:ListItem>
                                                                                <asp:ListItem Value="5">اخرى</asp:ListItem>
                                                                                 <asp:ListItem Value="6">الجامعات</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="clearfix">
                                                                        </div>

                                                                    </div>
                                                                    <asp:Panel runat="server" ID="OtherPanel" Visible="false">

                                                                        <div class="col-12 form-group row mb-3">
                                                                            <label class="col-sm-3 control-label text-lg-left pt-2">
                                                                                كيف علمت بنا  (اخرى)
                                                                            </label>
                                                                            <div class="col-sm-8 col-xs-12 pull-right">

                                                                                <asp:TextBox runat="server" ID="txtOtherWhere" CssClass="form-control"></asp:TextBox>
                                                                            </div>
                                                                            <div class="clearfix">
                                                                            </div>

                                                                        </div>
                                                                    </asp:Panel>

                                                                    <asp:Panel runat="server" ID="pnlBusinessNursy" Visible="false">

                                                                        <div class="col-12 form-group row mb-3">
                                                                            <label class="col-sm-3 control-label text-lg-left pt-2">
                                                                                &nbsp;
                                                                            </label>
                                                                            <div class="col-sm-8 col-xs-12 pull-right">

                                                                                <asp:DropDownList runat="server" ID="DrpBusinessNursy" AppendDataBoundItems="true" AutoPostBack="true" CssClass="form-control form-control mb-3" OnSelectedIndexChanged="DrpBusinessNursy_SelectedIndexChanged">
                                                                                </asp:DropDownList>

                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="DrpBusinessNursy"
                                                                                    ErrorMessage="حقول مطلوبة" SetFocusOnError="true" Display="Dynamic"
                                                                                    CssClass="red" InitialValue="0" ValidationGroup="submitionform">
                                                                                </asp:RequiredFieldValidator>
                                                                            </div>
                                                                            <div class="clearfix">
                                                                            </div>

                                                                        </div>
                                                                    </asp:Panel>


                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>




                                                            <div class="col-12 form-group row mb-3" style="display:none;">
                                                                <label class="col-sm-3 control-label text-lg-left pt-2">
                                                                    أختار أحد حاضنات الأعمال 
                                                                </label>
                                                                <div class="col-sm-8 col-xs-12 pull-right">

                                                                    <asp:DropDownList runat="server" ID="DropChooseIncubator" AppendDataBoundItems="true" CssClass="form-control form-control mb-3">
                                                                    </asp:DropDownList>

                                                                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                                        ControlToValidate="DropChooseIncubator" CssClass="red" ErrorMessage="حقول مطلوبة " InitialValue="0"
                                                                        Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RequiredFieldValidator>--%>
                                                                </div>
                                                                <div class="clearfix">
                                                                </div>

                                                            </div>



                                                            <div class="col-12 form-group row mb-3" style="display: none;">
                                                                <label class="col-sm-3 control-label text-lg-left pt-2">
                                                                    ارفق الصحيفة الجنائية (حديثة )  
                                                                </label>
                                                                <div class="col-sm-8 col-xs-12 pull-right">
                                                                    <asp:FileUpload ID="FileCriminalAutorization" runat="server" CssClass="form-control input-rounded" ClientIDMode="Static" onchange="showpreview(FileCriminalAutorization);" />
                                                                    <a id="FileCriminalAutorization_a" runat="server" target="_blank" href="" visible="false">View Document</a>
                                                                    <asp:HiddenField ID="hdcriminal" runat="server" />
                                                                    <%--                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="FileCriminalAutorization"
                                                                    ErrorMessage="حقول مطلوبة" SetFocusOnError="true" Display="Dynamic"
                                                                    CssClass="red" ValidationGroup="submitionform">
                                                                </asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                                    ErrorMessage="Only .pdf files are allowed." CssClass="red"
                                                                    ValidationExpression="^.*\.(pdf|PDF)$"
                                                                    ControlToValidate="FileCriminalAutorization" Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RegularExpressionValidator--%>>
                                                                </div>
                                                                <div class="clearfix">
                                                                </div>

                                                            </div>


                                                            <div class="col-12 form-group row mb-3">
                                                                <label class="col-sm-3 control-label text-lg-left pt-2">
                                                                    ارفق صورة من شهادة آخر مؤهل دراسي  
                                                                </label>
                                                                <div class="col-sm-8 col-xs-12 pull-right">
                                                                    <asp:FileUpload ID="FileAcademicQualification" runat="server" CssClass="form-control input-rounded" ClientIDMode="Static" onchange="showpreview(FileAcademicQualification);" />
                                                                    <a id="FileAcademicQualification_a" runat="server" target="_blank" href="" visible="false">View Document</a>
                                                                    <asp:HiddenField ID="hdacademic" runat="server" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="FileAcademicQualification"
                                                                        ErrorMessage="حقول مطلوبة" SetFocusOnError="true" Display="Dynamic"
                                                                        CssClass="red" ValidationGroup="submitionform">
                                                                    </asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                                        ErrorMessage="Only .pdf files are allowed." CssClass="red"
                                                                        ValidationExpression="^.*\.(pdf|PDF)$"
                                                                        ControlToValidate="FileAcademicQualification" Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RegularExpressionValidator>
                                                                </div>
                                                                <div class="clearfix">
                                                                </div>

                                                            </div>


                                                            <div class="col-12 form-group row mb-3" runat="server" id="div_fp_agriculture" visible="false">
                                                                <label class="col-sm-3 control-label text-lg-left pt-2">
                                                                    ارفق صورة من الرخصة الزراعية
                                                                </label>
                                                                <div class="col-sm-8 col-xs-12 pull-right">
                                                                    <asp:FileUpload ID="FileAgriculture" runat="server" CssClass="form-control input-rounded" ClientIDMode="Static" onchange="showpreview(FileAgriculture);" />
                                                                    <a id="FileAgriculture_a" runat="server" target="_blank" href="" visible="false">View Document</a>
                                                                    <asp:HiddenField ID="hdagriculture" runat="server" />

                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="FileAgriculture"
                                                                        ErrorMessage="حقول مطلوبة" SetFocusOnError="true" Display="Dynamic"
                                                                        CssClass="red" ValidationGroup="submitionform">
                                                                    </asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                                                        ErrorMessage="Only .pdf files are allowed." CssClass="red"
                                                                        ValidationExpression="^.*\.(pdf|PDF)$"
                                                                        ControlToValidate="FileAgriculture" Display="Dynamic" SetFocusOnError="true" ValidationGroup="submitionform"></asp:RegularExpressionValidator>
                                                                </div>
                                                                <div class="clearfix">
                                                                </div>

                                                            </div>


                                                            <div class="col-12 form-group row mb-3 text-center">
                                                                <div class="text-center">
                                                                    <asp:LinkButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" ValidationGroup="submitionform" CssClass="btn btn-lg btn-info m-auto" Text="ارسل" />
                                                                </div>
                                                            </div>
                                                            <%-- </asp:Panel>--%>
                                                        </ContentTemplate>
                                                        <Triggers>

                                                            <asp:PostBackTrigger ControlID="btnSubmit" />



                                                        </Triggers>
                                                    </asp:UpdatePanel>


                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                                </div>

                                <div class="heading-f-bg""></div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>




</asp:Content>
