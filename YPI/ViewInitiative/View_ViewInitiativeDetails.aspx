<%@ Page Title="" Language="C#" MasterPageFile="ViewInitiativeMasterPage.master" AutoEventWireup="true" CodeFile="View_ViewInitiativeDetails.aspx.cs" Inherits="ViewInitiative_View_ViewInitiativeDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .badge {
            font-size: 0.71rem !important;
            padding: 0.45em 0.45em !important;
        }

        .txtWhite {
            color: white !important;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">الرئيسية</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">معلومات المبادر المحترف</a>
        </li>
        <li class="breadcrumb-item">
            <span>
                <asp:Label ID="labtitle1" runat="server" Text="عرض"></asp:Label>
            </span>
        </li>
    </ul>
    <script type="text/javascript">

        function openWinPrint(id) {
            window.open("Print_Initiative.aspx?InitiativeID=" + id + '', "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no,width=700,height=650");
        }



    </script>
    <div class="content-i">
        <div class="content-box">
            <div class="row">
                <div class="col-lg-12">
                    <div class="element-wrapper">
                        <div class="element-actions">
                            <div class="element-actions">
                                <%=StrPrintbtn %>

                                <asp:LinkButton ID="lnkEdit" CssClass="btn btn-primary btn-sm" runat="server" OnClick="lnkEdit_Click"><i class="fa fa-edit"></i><span>&nbsp; تعديل &nbsp;</span></asp:LinkButton>

                                <asp:LinkButton ID="lnkDelete" CssClass="btn btn-danger btn-sm" runat="server" OnClick="lnkDelete_Click"><i class="fa fa-trash"></i><span>&nbsp; حذف &nbsp;</span></asp:LinkButton>
                                <a class="btn btn-primary btn-sm" href="Search_Initiative.aspx"><i class="fa fa-arrow-circle-left"></i><span>&nbsp;رجوع &nbsp;</span></a>

                            </div>

                        </div>
                        <h6 class="element-header">معلومات المبادر المحترف</h6>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-8">
                    <div class="element-wrapper">

                        <div class="element-box" style="min-height: 250px;">
                            <h6 class="element-header">
                                <asp:Label ID="labInitiativeName1" runat="server" Text="مقدم الطلب معلومات "></asp:Label>
                            </h6>


                            <div class="row">
                                <div class="col-lg-6">
                                    <i class="fa fa-user-circle-o" aria-hidden="true"></i>&nbsp;
                                    <asp:Label ID="labName" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="col-lg-6">
                                    <i class="fa fa-mobile" aria-hidden="true"></i>&nbsp;
                                    <asp:Label ID="labMobile" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-6">
                                    <i class="fa fa-envelope-o" aria-hidden="true"></i>&nbsp;
                                    <asp:Label ID="labEmail" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="col-lg-6">
                                    <i class="fa fa-id-card-o" aria-hidden="true"></i>&nbsp;
                                    <asp:Label ID="labCivilID" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-6">
                                    <i class="fa fa-university" aria-hidden="true"></i>&nbsp;
                                    <asp:Label ID="labEducationQualification" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-6">
                                    <i class="fa fa-paperclip" aria-hidden="true"></i>&nbsp;
                                    <asp:Label ID="labCivilIDCopy" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12">
                                    <p>
                                        <asp:Label ID="labNote" runat="server" Text=""></asp:Label>
                                    </p>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="value-pair">
                                        <div class="label">
                                            Status:
                                        </div>
                                        <asp:Label ID="labStatus" runat="server" Text=""></asp:Label>
                                        <%--<div class="value badge badge-pill badge-success">
                                            Online
                                        </div>--%>
                                    </div>
                                </div>
                            </div>


                        </div>
                    </div>
                    <div class="element-wrapper">
                        <div class="element-box" style="">
                            <h6 class="element-header">
                                <asp:Label ID="Label4" runat="server" Text="معلومات برنامج المبادر المحترف"></asp:Label>
                            </h6>

                           
                              <div class="row">
                                <div class="col-lg-12">
                                    <span class="labdetails">مجالات المشروع  : </span>
                                    <asp:Label ID="labcategory" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12">
                                    <span class="labdetails">مقدم الطلب : </span>
                                    <asp:Label ID="LabType" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />

                            <div class="row" id="PanExperience" runat="server">
                                <div class="col-lg-12">

                                    <br />

                                    <div class="row">
                                        <div class="col-lg-12">
                                            <span class="labdetails">هل سبق لك أن قدمت مشروع مشابه : </span>
                                            <asp:Label ID="labSimilarProject" runat="server" Text=""></asp:Label>

                                        </div>
                                    </div>
                                    <br />

                                    <div class="row" id="PanSimilarProjectYes" runat="server">
                                        <div class="col-lg-12">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <span class="labdetails">طبيعة المشروع : </span>
                                                    <asp:Label ID="labExperienceType" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <span class="labdetails">نبذة عن المشروع : </span>
                                                    <asp:Label ID="labOldDesc" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <span class="labdetails">هل كانت تجربتك بالمشروع ناجحة أم واجهتك معوقات؟ : </span>
                                                    <asp:Label ID="labWastheproject" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <span class="labdetails" id="labdesc" runat="server">هل كان المشروع : </span>
                                                    <asp:Label ID="lablabWastheprojectdesc" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <br />
                                    <br />

                                </div>
                            </div>
                            <br />




                            <div class="row">
                                <div class="col-lg-12">
                                    <span class="labdetails">اسم المشروع : </span>
                                    <asp:Label ID="labInitiativeName" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12">
                                    <span class="labdetails">نبذة عن المشروع : </span>

                                    <asp:Label ID="labInitiativeDesc" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12">
                                    <span class="labdetails">الأهداف : </span>

                                    <asp:Label ID="labInitiativeObjectives" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                               <%-- <div class="col-lg-6">
                                    <span class="labdetails">الصحيفة الجنائية (حديثة ) : </span>

                                    <asp:Label ID="labFileCriminalAutorization" runat="server" Text=""></asp:Label>
                                </div>--%>
                                <div class="col-lg-6">
                                    <span class="labdetails">شهادة آخر مؤهل دراسي : </span>

                                    <asp:Label ID="labFileAcademicQualification" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row" runat="server" id="PanFileAgriculture">
                                <div class="col-lg-6">
                                    <span class="labdetails">ارفق صورة من الرخصة الزراعية : </span>

                                    <asp:Label ID="labFileAgriculture" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                             <br />
                            <div class="row" runat="server" id="HowtoKnow">
                                <div class="col-lg-6">
                                    <span class="labdetails">كيف علمت بنا </span>

                                    <asp:Label ID="lblHowtoKnow" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="element-wrapper  pt-2" id="PanFollowUpView" runat="server">
                        <div class="element-actions d-none d-sm-block">
                        </div>
                        <h6 class="element-header">View FollowUp
                        </h6>
                        <div class="element-box-tp">
                            <asp:GridView Width="100%" ID="GVFollowUpData" OnPageIndexChanging="GVFollowUpData_OnPageIndexChanging"
                                AutoGenerateColumns="false" CssClass=""
                                runat="server" BorderColor="Silver" BorderWidth="0px" CellPadding="3" CellSpacing="8"
                                PageSize="20" GridLines="None" AllowPaging="true" DataKeyNames="id" ShowHeader="false" ShowFooter="true">

                                <HeaderStyle CssClass="panel-blue"></HeaderStyle>
                                <Columns>
                                    <asp:TemplateField HeaderText="Phase">
                                        <ItemTemplate>
                                            <div class="post-box">
                                                <%--<div class="post-media" style="background-image: url(img/photo.jpg)"></div>--%>
                                                <div class="post-content">
                                                    <h6 class="post-title"><%#DataBinder.Eval(Container.DataItem, "Subject")%>
                                                    </h6>
                                                    <div class="post-text">
                                                        <%#DataBinder.Eval(Container.DataItem, "Note")%>
                                                    </div>
                                                    <div class="post-foot">
                                                        <div class="post-tags">
                                                            <div class="badge badge-primary">
                                                                <i class="fa fa-calendar" aria-hidden="true"></i>&nbsp;   <%#DataBinder.Eval(Container.DataItem, "CreatedAt")%>
                                                            </div>
                                                            <%# GetFollowAttachment(Eval("id"))%>
                                                            <%-- <div class="badge badge-primary">
                                                                <i class="fa fa-paperclip" aria-hidden="true"></i>&nbsp;   <%#DataBinder.Eval(Container.DataItem, "CreatedAt")%>
                                                            </div>--%>
                                                        </div>
                                                        <%-- <a class="post-link" href="#"><span>Read Full Story</span><i class="os-icon os-icon-arrow-right7"></i></a>--%>
                                                    </div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>



                        </div>
                    </div>
                    <div class="element-wrapper" id="PanFollowUpSubmit" runat="server">
                        <div class="element-box" style="">
                            <h6 class="element-header">
                                <asp:Label ID="Label1" runat="server" Text="Submit FollowUp"></asp:Label>
                            </h6>
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label for="">
                                            Subject
                                            <asp:RequiredFieldValidator ValidationGroup="MainValidateFollowUpSubmit" CssClass="require" ControlToValidate="TxtSubject" ID="RequiredFieldValidator2" runat="server" ErrorMessage="(يرجى إدخال الاسم)"></asp:RequiredFieldValidator></label>
                                        <asp:TextBox ID="TxtSubject" runat="server" CssClass="form-control" placeholder="Subject"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label for="">
                                            ملاحظات
                                        </label>
                                        <asp:TextBox ID="TxtNote" TextMode="MultiLine" Rows="5" runat="server" CssClass="form-control" placeholder="ملاحظات"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label for="">
                                            File
                                        </label>
                                        <input class="form-control" id="uFileFollowUp" style="width: 95%" type="file" name="uFileFollowUp"
                                            runat="server">
                                    </div>
                                </div>
                            </div>
                            <div class="form-buttons-w">


                                <asp:LinkButton ID="lnkFollowUpSubmit" OnClick="lnkFollowUpSubmit_Click" ValidationGroup="MainValidateFollowUpSubmit" runat="server" CssClass="btn btn-primary"> <i class="os-icon os-icon-ui-22"></i>&nbsp;إرسال</asp:LinkButton>



                            </div>
                        </div>
                    </div>
                    <%--  <div class="element-wrapper" >
                        <div class="element-box" style="">
                        </div>
                    </div>--%>
                </div>
                <div class="col-lg-4">
                    <div class="element-wrapper" id="panUpdateStatus" runat="server">
                        <div class="element-box" style="min-height: 250px;">
                            <h6 class="element-header">مبادراتنا الحالة</h6>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            الحالة
                                        <asp:CustomValidator runat="server" ID="custPermitType" CssClass="require" ControlToValidate="DDLStatus"
                                            SetFocusOnError="true" ValidationGroup="MainValidateStatus" ClientValidationFunction="CheckDropDownValueZero"
                                            ErrorMessage="( Choose Status )" />
                                        </label>
                                        <asp:DropDownList CssClass="form-control" ID="DDLStatus" AutoPostBack="false" runat="server">
                                            <asp:ListItem Value="0"><--Select--></asp:ListItem>
                                            <asp:ListItem Value="1">Active</asp:ListItem>
                                            <asp:ListItem Value="2">Pending</asp:ListItem>
                                            <asp:ListItem Value="3">Closed</asp:ListItem>
                                            <asp:ListItem Value="4">Lost</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label for="">
                                            ملاحظات
                                        </label>
                                        <asp:TextBox ID="TxtStageNote" TextMode="MultiLine" Rows="5" runat="server" CssClass="form-control" placeholder="ملاحظات"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-lg-12 text-center">
                                    <asp:LinkButton ID="lnkUpdateStatus" OnClick="lnkUpdateStatus_Click" ValidationGroup="MainValidateStatus" runat="server" CssClass="btn btn-primary"> <i class="os-icon os-icon-ui-49"></i>&nbsp;Update</asp:LinkButton>
                                </div>
                            </div>

                        </div>
                    </div>

                    <div class="element-wrapper" id="PANMYAReviewApprove" runat="server">
                        <div class="element-box " style="min-height: 250px;">
                            <h6 class="element-header">
                                <asp:Label ID="labStageText" runat="server" Text="Label"></asp:Label></h6>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            الحالة
                                        <asp:CustomValidator runat="server" ID="CustomValidator1" CssClass="require" ControlToValidate="DDLStageStatus"
                                            SetFocusOnError="true" ValidationGroup="MainValidateReviewApprove" ClientValidationFunction="CheckDropDownValueZero"
                                            ErrorMessage="(Choose Status )" />
                                        </label>
                                        <asp:DropDownList CssClass="form-control" ID="DDLStageStatus" AutoPostBack="false" runat="server">
                                            <%-- <asp:ListItem Value="0"><--Select--></asp:ListItem>
                                            <asp:ListItem Value="1">Approve</asp:ListItem>
                                            <asp:ListItem Value="2">Pending</asp:ListItem>
                                            <asp:ListItem Value="3">Reject</asp:ListItem>--%>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                            </div>
                            <div class="row" id="panIncubatorToChoose" runat="server">
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label for="">
                                            Incubator 
                                        </label>
                                        <asp:DropDownList CssClass="form-control" ID="DDLIncubator" AutoPostBack="false" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row" id="panIncubatorFileUploadWhenSelected" runat="server">
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label for="">
                                            File
                                        </label>
                                        <input class="form-control" id="uFileStage" style="width: 95%" type="file" name="uFileStage"
                                            runat="server">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="projectinput1">
                                        Comment</label>
                                    <asp:TextBox ID="TxtComment" TextMode="MultiLine" Rows="3" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12 text-center">
                                    <asp:Label ID="LabInstitutionID" Visible="false" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="LabStatus1" Visible="false" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="labStage" Visible="false" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="labStageStatus" Visible="false" runat="server" Text=""></asp:Label>
                                    <asp:LinkButton ID="lnkReviewApprove" OnClick="lnkReviewApprove_Click" ValidationGroup="MainValidateReviewApprove" runat="server" CssClass="btn btn-primary"> <i class="os-icon os-icon-ui-49"></i>&nbsp;Submit</asp:LinkButton>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="element-wrapper" id="PANInitiativeActivity" runat="server">
                        <h6 class="element-header">Initiative Activity
                        </h6>
                        <div class="element-box-tp">
                            <div class="activity-boxes-w">
                                <%=StrInitiativeActivityDiv %>
                                <%-- <div class="activity-box-w">
                                    <div class="activity-time">
                                       
                                    </div>
                                    <div class="activity-box">
                                        <div class="activity-avatar">
                                            <img alt="" src="img/photo.jpg">
                                        </div>
                                        <div class="activity-info">
                                            <div class="activity-role">
                                                John Mayers
                                            </div>
                                            <strong class="activity-title">Opened New Account</strong>
                                        </div>
                                    </div>
                                </div>
                                <div class="activity-box-w">
                                    <div class="activity-time">
                                       
                                    </div>
                                    <div class="activity-box">
                                        <div class="activity-avatar">
                                            <img alt="" src="img/photo.jpg">
                                        </div>
                                        <div class="activity-info">
                                            <div class="activity-role">
                                                Ben Gossman
                                            </div>
                                            <strong class="activity-title">Posted Comment</strong>
                                        </div>
                                    </div>
                                </div>
                                <div class="activity-box-w">
                                    <div class="activity-time">
                                       
                                    </div>
                                    <div class="activity-box">
                                        <div class="activity-avatar">
                                            <img alt="" src="img/photo.jpg">
                                        </div>
                                        <div class="activity-info">
                                            <div class="activity-role">
                                                Phil Nokorin
                                            </div>
                                            <strong class="activity-title">Opened New Account</strong>
                                        </div>
                                    </div>
                                </div>
                                <div class="activity-box-w">
                                    <div class="activity-time">
                                      
                                    </div>
                                    <div class="activity-box">
                                        <div class="activity-avatar">
                                            <img alt="" src="img/avatar4.jpg">
                                        </div>
                                        <div class="activity-info">
                                            <div class="activity-role">
                                                Jenny Miksa
                                            </div>
                                            <strong class="activity-title">Uploaded Image</strong>
                                        </div>
                                    </div>
                                </div>--%>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

