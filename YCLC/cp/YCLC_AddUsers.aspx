<%@ Page Title="" Language="C#" MasterPageFile="cpanl.master" AutoEventWireup="true" CodeFile="YCLC_AddUsers.aspx.cs" Inherits="YCA_Admin_Profile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        /*.GenderRadio input[type=radio] {
            margin-right: 24px;
        }*/


      

        .inut-four input {
        }

        .stdform input {
            width: 100%;
        }

        .stdform select {
            width: 102%;
        }

        .red {
            color: red;
        }

        .GenderRadio input[type=radio] {
            margin-right: 24px;
            width: auto !important;
            float: right;
            margin-left: 10px;
        }

         .radio-list input[type=radio] {
             margin-right: 10px;
            width: auto !important;
            float: right;
            margin-left: 5px;
        }

        #mainContent_ChckTerm {
            width: auto !important;
            float: right;
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

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="url" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pagetitle" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="mainContent" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <asp:HiddenField runat="server" ID="HiddenField3" />

   
    <div class="controls">
    </div>
    <div id="pnlProfile" runat="server" visible="true">
        <div class="widgetcontent bordered shadowed stdform">
            <h4 class="widgettitle"></h4>
            <div class="row">
                <div class="col-md-8 col-md-offset-2 text-center ">
                    <asp:Panel ID="pnlReg" runat="server">


                        <asp:Panel ID="panelform" runat="server" Style="margin-right: 15px;">
                            <div id="success" class="alert alert-success" runat="server" visible="false">
                                <p>Added Successfully</p>
                            </div>
                            <div id="alertEmail" class="alert alert-danger" runat="server" visible="false">
                                <p>الايميل مسجل لدينا مسبقاً</p>
                            </div>
                            <div id="alertCivil" class="alert alert-danger" runat="server" visible="false">
                                <p>الرقم المدني مسجل لدينا مسبقاً</p>
                            </div>
                            <div class="form-group">

                                <div class="row inut-four" style="direction: rtl; padding-top: 20px;">
                                    <div class="col-sm-3 col-xs-12 pull-right">
                                        <label class="control-label">اسم المشارك </label>
                                    </div>


                                    <div class="col-sm-2 col-xs-12">
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
                                    <div class="col-sm-1 col-xs-12">
                                        <asp:TextBox ID="txtTname" Style="margin-bottom: 5px;" runat="server" CssClass="form-control" placeholder="الثالث"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtTname"
                                            CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator5" ControlToValidate="txtTname" CssClass="red"
                                            ErrorMessage="يرجى تعبئه البيانات باللغه العربيه" Display="Dynamic" SetFocusOnError="true" ValidationExpression="[^a-zA-Z]+"
                                            ValidationGroup="personalInfo"> </asp:RegularExpressionValidator>


                                    </div>
                                    <div class="col-sm-2 col-xs-12">
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
                                            <div class="row" style="direction: rtl;">
                                                <div class="col-sm-3">
                                                    <label class="control-label">Name in English</label>

                                                </div>

                                                <div class="col-sm-8">

                                                    <asp:TextBox ID="txtEnglishName" ClientIDMode="Static" runat="server" ValidationGroup="personalInfo" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="clear"></div>
                                            </div>
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
                            <div class="form-group">
                                <div class="row" style="direction: rtl;">
                                    <div class="col-sm-3">
                                        <label class="control-label">الجنس</label>
                                    </div>


                                    <%--<div class="col-sm-4 radio radio-info">--%>

                                    <div class="col-sm-8  GenderRadio">
                                        <asp:RadioButtonList runat="server" ID="gender" RepeatDirection="Horizontal" RepeatLayout="Flow" Style="display: inline-block; width: 100%;">
                                            <asp:ListItem Text="ذكر " Value="ذكر"></asp:ListItem>
                                            <asp:ListItem Text=" أنثى " Value="أنثى"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
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
                                <div class="row" style="direction: rtl;">
                                    <div class="col-sm-3">
                                        <label class="control-label">الهاتف</label>
                                    </div>

                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtContactNo" MaxLength="8" ClientIDMode="Static" runat="server" ValidationGroup="personalInfo" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="clear"></div>
                                </div>
                                <div class="req">
                                    <div class="col-sm-3"></div>
                                    <div class="col-sm-6">

                                        <asp:RequiredFieldValidator ID="rqdContactnumber1" runat="server" Display="Dynamic"
                                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtContactNo"
                                            CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
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

                                        <div class="row" style="direction: rtl;">
                                            <div class="col-sm-3">
                                                <label class="control-label">الرقم المدني </label>
                                            </div>


                                            <div class="col-sm-8">
                                                <asp:TextBox ID="txtCivil" runat="server" MaxLength="12" ValidationGroup="personalInfo" OnTextChanged="txtCivil_TextChanged" AutoPostBack="true" CssClass="form-control"> </asp:TextBox>
                                            </div>
                                            <div class="clear"></div>
                                        </div>
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
                                                <asp:Label ID="lblCivil" runat="server" Visible="false" CssClass="red" SetFocusOnError="true" Text="الرقم المدني غير صحيح" />
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
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>

                                    <div class="form-group">
                                        <div class="row" style="direction: rtl;">
                                            <div class="col-sm-3">
                                                <asp:HiddenField runat="server" ID="HdAge" />
                                                <label class="control-label">تم تسجيلك في المستوى</label>
                                            </div>

                                            <div class="col-sm-8">
                                                <asp:DropDownList ID="DDLlevl" Enabled="false" runat="server" CssClass="form-control" Visible="true">
                                                    <asp:ListItem Text="--اختر---" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="المبتدئ" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="المتوسط" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="المتقدم" Value="3"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label runat="server" ID="lblLevelIssue" Visible="false" CssClass="red" Text="نعتذر عن عدم تسجليكم لعدم توافق العمر مع الشروط العامة لدوري الابداع الشبابي"></asp:Label>
                                            </div>
                                            <div class="clear"></div>
                                        </div>
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
                                <div class="row" style="direction: rtl;">
                                    <div class="col-sm-3">
                                        <label class="control-label">صورة البطاقة المدنية</label>
                                    </div>

                                    <div class="col-sm-8">
                                        <asp:FileUpload ID="fbCiviID" runat="server" CssClass="form-control input-rounded" ClientIDMode="Static" onchange="showpreview(fbCiviID);" />
                                        <span class="red">(.jpg,.png,.jpeg, or .pdf 1 MB)
                                        </span>
                                    </div>
                                    <div class="clear"></div>
                                </div>
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
                                <div class="row" style="direction: rtl;">
                                    <div class="col-sm-3">
                                        <label class="control-label">البريد الالكتروني</label>
                                    </div>

                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="personalInfo" ClientIDMode="Static" ReadOnly="False" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="clear"></div>
                                </div>
                                <div class="req">
                                    <div class="col-sm-3"></div>
                                    <div class="col-sm-6">                                        

                                        <asp:RequiredFieldValidator ID="rqdEmail1" runat="server"
                                            ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtEmail"
                                            CssClass="red"
                                            ValidationGroup="personalInfo" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                            ErrorMessage="يرجى كتابة عنوان الإيميل" SetFocusOnError="true"
                                            ControlToValidate="txtEmail" CssClass="red" Display="dynamic"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ValidationGroup="personalInfo"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row" style="direction: rtl;">
                                    <div class="col-sm-3">
                                        <label class="control-label">أعد كتابة البريد الالكتروني</label>
                                    </div>

                                    <div class="col-sm-8">
                                        <asp:TextBox ID="TxtEmailCompare" runat="server" ValidationGroup="personalInfo " ReadOnly="False" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="clear"></div>
                                </div>
                                <div class="req">
                                    <div class="col-sm-3"></div>
                                    <div class="col-sm-6">
                                       
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server"
                                            ErrorMessage="يرجى كتابة عنوان الإيميل" SetFocusOnError="true"
                                            ControlToValidate="TxtEmailCompare" CssClass="red" Display="dynamic"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ValidationGroup="personalInfo"></asp:RegularExpressionValidator>


                                        <asp:CompareValidator ID="CompareValidator2" runat="server" Display="Dynamic"
                                            ControlToCompare="txtEmail" SetFocusOnError="true"
                                            ControlToValidate="TxtEmailCompare"
                                            ErrorMessage="البريد الإلكتروني غير مطابق " CssClass="red" ValidationGroup="personalInfo"></asp:CompareValidator>
                                    </div>
                                </div>
                            </div>


                           
                          
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <div class="form-group">
                                        <div class="row" style="direction: rtl;">
                                            <div class="col-sm-3">
                                                <label class="control-label">اختر مسابقة واحدة فقط</label>
                                            </div>

                                            <div class="col-sm-8 radio-list">
                                                <asp:RadioButtonList ID="DDLCatagory" style="display: inline-block; width: 100%;" RepeatDirection="Horizontal" runat="server" Enabled="false" >  <%--AutoPostBack="true" OnSelectedIndexChanged="DDLCatagory_SelectedIndexChanged"--%>
                                                </asp:RadioButtonList>

                                            </div>
                                            <div class="clear"></div>
                                        </div>
                                        <div class="req">
                                            <div class="col-sm-3"></div>
                                            <div class="col-sm-6">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic"
                                                    ErrorMessage="مطلوب هذه الخانة" ControlToValidate="DDLCatagory"
                                                    CssClass="red" ValidationGroup="personalInfo" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            </div>

                                        </div>
                                    </div>

                                    <asp:Panel runat="server" ID="pnlSub" Visible="false">
                                        <div class="form-group">
                                            <div class="row" style="direction: rtl;">
                                                <div class="col-sm-3">
                                                    <label class="control-label">المسابقة المتاحة</label>
                                                </div>

                                                <div class="col-sm-8">
                                                    <asp:DropDownList ID="DDlSubGroup" runat="server" CssClass="form-control" Enabled="false">
                                                    </asp:DropDownList>

                                                </div>
                                                <div class="clear"></div>
                                            </div>
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

                                    <asp:Panel runat="server" ID="pnlMessage" CssClass="notification msgalert red col-md-9" Visible="false">
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
                                    <div class="col-sm-3">
                                        <label class="control-label"></label>
                                    </div>

                                    <div class="col-sm-6">

                                        <label>أقر وأتعهد بأن المعلومات صحيحة</label>
                                        &nbsp;
                                                      <asp:CheckBox runat="server" ID="ChckTerm" />

                                    </div>


                                </div>
                                <div class="req">
                                    <div class="col-sm-12 pull-right">
                                        <asp:CustomValidator ID="vTerms"
                                            ClientValidationFunction="validateTerms"
                                            ErrorMessage="مطلوب هذه الخانة"
                                            ForeColor="Red"
                                            Display="Dynamic"
                                            EnableClientScript="true" SetFocusOnError="true"
                                            ValidationGroup="personalInfo"
                                            runat="server" />
                                    </div>

                                </div>
                            </div>
                            <hr />
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-3"></div>
                                    <div class="col-sm-8">
                                        <div style="display: block; margin: 0 auto; text-align: center;">
                                            <asp:Button ID="btnSubmit" runat="server" class="btn btn-info" Text="تسجيل" ValidationGroup="personalInfo" OnClick="btnSubmit_Click" Style="width: 150px;" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:HiddenField ID="hdfile" runat="server" />
                            <asp:HiddenField ID="hdpwd" runat="server" />

                        </asp:Panel>




                    </asp:Panel>
                </div>
            </div>
        </div>

    </div>
    <!-- notification msgsuccess -->


</asp:Content>

