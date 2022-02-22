<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="user_Profile.aspx.cs" Inherits="User_user_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">

    <div class="container-fluid">
        <div class="container-bg">

            <div class="container profile-container py-5 mt-110 inside-page">


                <div class="row">
                    <div class="col-md-4">
                        <div class="tab-title">
                            <h2>حسابي</h2>
                        </div>



                        <!-- Tabs nav -->
                        <div class="left-tab-content">
                            <div class="profile-image">

                                <img runat="server" id="lblImage" />
                            </div>


                            <div class="user-info">


                                <div class="user-name user-box">
                                    <h6>الإسم</h6>
                                    <hr style="background-color: #fff; padding: 0; margin: 5px 10px;" />
                                    <h6>
                                        <asp:Label runat="server" ID="lblName"></asp:Label></h6>


                                </div>

                                <div class="user-name1 user-box">
                                    <h6>الجنس</h6>
                                    <hr style="background-color: #fff; padding: 0; margin: 5px 10px;" />
                                    <h6>
                                        <asp:Label runat="server" ID="lblGender"></asp:Label></h6>
                                </div>



                                <div class="user-civil user-box">
                                    <h6>الرقم المدني </h6>res
                                    <hr style="background-color: #fff; padding: 0; margin: 5px 10px;" />
                                    <h6>
                                        <asp:Label runat="server" ID="lblCivil"></asp:Label>
                                    </h6>
                                </div>



                                <div class="user-mail user-box">
                                    <h6>البريد الإلكتروني </h6>
                                    <hr style="background-color: #fff; padding: 0; margin: 5px 10px;" />
                                    <h6>
                                        <asp:Label runat="server" ID="lblEmail"></asp:Label>
                                    </h6>
                                </div>


                                <div class="user-phone user-box">
                                    <h6>رقم الهاتف </h6>
                                    <hr style="background-color: #fff; padding: 0; margin: 5px 10px;" />
                                    <h6>
                                        <asp:Label runat="server" ID="lblContactNo"></asp:Label>
                                    </h6>


                                </div>
                            </div>

                            <div class="nav flex-column nav-pills nav-pills-custom" id="v-pills-tab" role="tablist" aria-orientation="vertical">
                                <!-- <a class="nav-link mb-3 p-3 shadow active" id="v-pills-home-tab" data-toggle="pill" href="#v-pills-home" role="tab" aria-controls="v-pills-home" aria-selected="true">
                                                <i class="fa fa-user-circle-o mr-2"></i>
                                                <span class="font-weight-bold small text-uppercase">Personal information</span></a> -->

                                <a class="nav-link mb-3 p-3 shadow" id="v-pills-profile-tab" data-toggle="pill" href="#v-pills-profile" role="tab" aria-controls="v-pills-profile" aria-selected="false">
                                    <i class="fa fa-calendar-minus-o mr-2"></i>
                                    <span class="font-weight-bold">تعديل</span></a>


                            </div>

                        </div>
                    </div>


                    <div class="col-md-8">

                        <div class="tab-title">
                            <h2>المشاريع</h2>
                        </div>
                        <!-- Tabs content -->
                        <div class="tab-content" id="v-pills-tabContent">
                            <div class="tab-pane rounded show active px-0 md-p-5" id="v-pills-home" role="tabpanel" aria-labelledby="v-pills-home-tab">
                                <ul>

                               <%--     <li class="profile-items"><a href="../ELearning/Index.aspx">
                                        <img src="../Content/images/btns/one-btn-hover.png" /></a></li>--%>
                                    <li class="profile-items"><a href="../YPI/Index.aspx">
                                        <img src="https://www.youth.gov.kw/Content/images/btns/second-btn-hover.png" width="100" height="100" /></a></li>
                                    <li class="profile-items" ><a href="../YCLC/index.aspx">
                                        <img src="https://www.youth.gov.kw/Content/images/btns/fifth-btn-hover.png" width="100" height="100" /></a></li>
                                    <li class="profile-items" ><a href="https://mubaratna.com/#/">
                                        <img src="https://www.youth.gov.kw/Content/images/btns/third-btn-hover.png" width="100" height="100" /></a></li>
                                    <li class="profile-items"><a href="../YCA/index.aspx">
                                        <img src="https://www.youth.gov.kw/Content/images/btns/sixth-btn-hover.png" width="100" height="100" /></a></li>
                                     <li class="profile-items"><a href="../ini_Form/StudentOrganization.aspx">
                                        <img src="https://www.youth.gov.kw/Content/images/btns/tenth-btn-hover.png" width="100" height="100" /></a></li>
                                   <%-- <li class="profile-items"><a href="../ini_Form/Initiative_StudentOrganization.aspx">
                                        <img src="https://www.youth.gov.kw/Content/images/btns/tenth-btn-hover.png" width="100" height="100" /></a></li>--%>
                                    <li class="profile-items"><a href="../ini_Form/index.aspx">
                                        <img src="https://www.youth.gov.kw/Content/images/btns/fourth-btn-hover.png" width="100" height="100" /></a></li>
                                    <li class="profile-items"><a href="../FMC/index.aspx">
                                        <img src="https://www.youth.gov.kw/Content/images/btns/tenthnew-btn-hover.png" width="100" height="100" /></a></li>
                                    <li class="profile-items"><a href="../ini_Form/reward.aspx">
                                        <img src="https://www.youth.gov.kw/Content/images/btns/seventh-btn-hover.png" width="100" height="100" /></a></li>
                                    <li class="profile-items"><a href="javascript:void(0)">
                                        <img src="https://www.youth.gov.kw/Content/images/btns/eight-btn-hover.png" width="100" height="100" /></a></li>
                                     <li class="profile-items"><a href="javascript:void(0)">
                                        <img src="https://www.youth.gov.kw/Content/images/btns/ninth-btn-hover.png" width="100" height="100" /></a></li>
                                   <%-- <li class="profile-items"><a href="https://www.youth.gov.kw/ace/index.aspx">
                                        <img src="https://www.youth.gov.kw/Content/images/btns/ninth-btn-hover.png" width="100" height="100" /></a></li>--%>                                  

                                </ul>



                            </div>

                            <div class="tab-pane  md-p-5 p-4" id="v-pills-profile" role="tabpanel" aria-labelledby="v-pills-profile-tab">
                                <h4 class="font-italic mb-4">تعديل الملف الشخصي</h4>

                                <asp:Panel ID="Panel1" runat="server">


                                    <div class="clear"></div>
                                    <%--  <hr / style="margin-top:0px;">--%>
                                    <div class="form-group">
                                        <label class="col-sm-3 control-label ">الاسم:</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="TxtName" runat="server" Enabled="false" CssClass="form-control input_clean"></asp:TextBox>
                                        </div>
                                        <div class="clear"></div>
                                        <div class="req">
                                            <asp:RequiredFieldValidator ID="txtNameValidator" runat="server" Display="Dynamic"
                                                ErrorMessage="مطلوب هذه الخانة" ControlToValidate="TxtName"
                                                CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-3 control-label ">الجنس:</label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="ddlGender" runat="server" ValidationGroup="personalInfo" CssClass="form-control input_clean">
                                                <asp:ListItem>--select--</asp:ListItem>
                                                <asp:ListItem>ذكر</asp:ListItem>
                                                <asp:ListItem>أنثى</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="clear"></div>
                                        <div class="req">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="مطلوب هذه الخانة"
                                                ControlToValidate="ddlGender" CssClass="red" Display="Dynamic"
                                                ValidationGroup="personalInfo" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-3 control-label ">الرقــم المـدني:</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txtcivil" runat="server" Enabled="false" MaxLength="12" CssClass="form-control input_clean"></asp:TextBox>
                                        </div>
                                        <div class="clear"></div>
                                        <div class="req">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtcivil"
                                                CssClass="red" Display="Dynamic"
                                                ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator
                                                EnableClientScript="true"
                                                ID="RegularExpressionValidator1" runat="server"
                                                ErrorMessage="البطاقة المدنية يجب ان تكون 12 رقم فقط!"
                                                ValidationGroup="personalInfo"
                                                ControlToValidate="txtcivil" Display="dynamic"
                                                ValidationExpression="^[0-9]{12}$"
                                                CssClass="red" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-3 control-label ">البريد الإلكتروني:</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txTEmail" runat="server" Enabled="false" CssClass="form-control input_clean"></asp:TextBox>
                                        </div>
                                        <div class="clear"></div>
                                        <div class="req">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txTEmail"
                                                CssClass="red"
                                                ValidationGroup="personalInfo" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                                ErrorMessage="يرجى كتابة عنوان الإيميل"
                                                ControlToValidate="txTEmail" CssClass="red" Display="dynamic"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                ValidationGroup="personalInfo"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-3 control-label ">رقم الهاتف:</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txtmobile" runat="server" MaxLength="8" CssClass="form-control input_clean"></asp:TextBox>
                                        </div>
                                        <div class="clear"></div>
                                        <div class="req">
                                            <asp:RequiredFieldValidator ID="txtContactNoValidator1" runat="server" Display="Dynamic"
                                                ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtmobile"
                                                CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator
                                                EnableClientScript="true"
                                                ID="RegularExpressionValidator2" runat="server"
                                                ErrorMessage="رقم الهاتف يجب ان يكون 8 ارقام!"
                                                ValidationGroup="personalInfo"
                                                ControlToValidate="txtmobile" Display="dynamic"
                                                ValidationExpression="^[0-9,٠-٩]{8}$"
                                                CssClass="red" />
                                        </div>
                                    </div>

                                    <%--   <hr />--%>
                                    <div class="row">
                                        <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:Button ID="btnsave" runat="server" CssClass="btn btn-info" Text="حفظ" OnClick="btnsave_Click" ValidationGroup="personalInfo" />
                                        <asp:Button ID="btncancel" runat="server" CssClass="btn btn-danger" Text="الغاء " OnClick="btncancel_Click" ValidationGroup="personalInfo" />
                                    </div>
                                            </div>
                                    </div>
                                    <div class="clear"></div>
                                </asp:Panel>



                            </div>




                        </div>
                    </div>
                </div>
                

            </div>


        </div>
    </div>

</asp:Content>

