<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="AcademicRegistration.aspx.cs" Inherits="AcademicOrientation_AcademicRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Content/css/style.css" rel="stylesheet" />
    <style>
        .modal-title {
            color: #000;
        }

        .close {
            left: 10px !important;
            color: #000!important;
            right: auto;
        }

        #radioAchievements input[type=radio] {
            margin-right: 15px;
        }
        .form-bg1 {
            background-color:#2e99b0;
        }
        .mt-50 {
            margin-top:50px;
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





   <%-- <div style="direction: rtl; text-align: right;">--%>
        <div class="container mb-20 mt-50">
           
             <%--<div class="text-center mt-50">
                    <h3>التسجيل في مركز الإرشاد الأكاديمي </h3>

                </div>

                <hr />--%>

         
  
                 <div class="row">
                    <div class="col-md-3 col-12">

                        <img src="Content/images/logo-new.png" />
                    </div>
                    <div class="col-md-9 col-12">
                        <div class=" text-center mt-5 ">
                            <h3 class="mt-50">التسجيل في مركز الإرشاد الأكاديمي</h3>

                        </div>
                    </div>
                </div>
          
            <div class="bg-white">
              
                    <div class="row">
                   
                           
                            <div class="col-lg-12 col-xs-12 form-bg1">
                             <div class="heading-bg">
                              
                            </div>
                           
                                <div class="clearfix"></div>

                                 <div id="contact-form" role="form" style="direction:rtl;">
                                    <asp:UpdatePanel ID="update" runat="server">
                                        <ContentTemplate>
                                            <div id="DivCountalert" class="alert alert-danger" runat="server" visible="false">
                                                Registraton is closed for today!!!                                             
                                            </div>

                                            <div id="alertEmail" class="alert alert-danger" runat="server" visible="false">

                                                <asp:Label ID="lblalert" runat="server"></asp:Label>
                                            </div>

                                            <div class="controls">
                                                <div class="row">
                                                    <div class="col-md-4 col-12">
                                                        <div class="form-group">
                                                            <label for="form_name">الاسم الأول </label>
                                                            <asp:TextBox ID="txtfname" runat="server" CssClass="form-control" autocomplete="off"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true" ValidationGroup="academic" ControlToValidate="txtfname" Display="Dynamic" ErrorMessage="مطلوب هذه الخانة"
                                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4 col-12">
                                                        <div class="form-group">
                                                            <label for="form_lastname">اسم الأب </label>
                                                            <asp:TextBox ID="txtmname" runat="server" CssClass="form-control" autocomplete="off"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" SetFocusOnError="true" ValidationGroup="academic" ControlToValidate="txtmname" Display="Dynamic" ErrorMessage="مطلوب هذه الخانة"
                                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-4 col-12">
                                                        <div class="form-group">
                                                            <label for="form_lastname">اسم العائلة  </label>
                                                            <asp:TextBox ID="txtlname" runat="server" CssClass="form-control" autocomplete="off"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" SetFocusOnError="true" ValidationGroup="academic" ControlToValidate="txtlname" Display="Dynamic" ErrorMessage="مطلوب هذه الخانة"
                                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">

                                                    <div class="col-md-4 col-12">
                                                        <div class="form-group">
                                                            <label for="form_civil_id">الرقم المدني </label>

                                                            <asp:TextBox ID="txtcivil" runat="server" CssClass="form-control txtcivil" MaxLength="12" autocomplete="off" OnTextChanged="txtcivil_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true" ValidationGroup="academic" ControlToValidate="txtcivil" Display="Dynamic" ErrorMessage="مطلوب هذه الخانة"
                                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator
                                                                EnableClientScript="true"
                                                                ID="RegularExpressionValidator1" runat="server"
                                                                ErrorMessage="البطاقة المدنية يجب ان تكون 12 رقم فقط!"
                                                                ValidationGroup="academic"
                                                                ControlToValidate="txtcivil" Display="dynamic"
                                                                ValidationExpression="^[0-9]{12}$"
                                                                CssClass="red" SetFocusOnError="true"></asp:RegularExpressionValidator>

                                                        </div>
                                                    </div>

                                                    <div class="col-md-4 col-12">
                                                        <div class="form-group">
                                                            <label for="form_civil_id">تاريخ الميلاد </label>
                                                            <asp:TextBox ID="txtdob" runat="server" CssClass="form-control txtdob" Enabled="false"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" SetFocusOnError="true" ValidationGroup="academic" ControlToValidate="txtdob" Display="Dynamic" ErrorMessage="مطلوب هذه الخانة"
                                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-4 col-12">
                                                        <div class="form-group">
                                                            <label for="form_need">الجنس </label>

                                                            <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                                                                <asp:ListItem Value="0">--اختر--</asp:ListItem>
                                                                <asp:ListItem Value="1">الذكر</asp:ListItem>
                                                                <asp:ListItem Value="2">أنثى</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" SetFocusOnError="true" InitialValue="0" ValidationGroup="academic" ControlToValidate="ddlGender" Display="Dynamic" ErrorMessage="مطلوب هذه الخانة"
                                                                ForeColor="Red"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">

                                                    <div class="col-md-4 col-12">
                                                        <div class="form-group">
                                                            <label for="form_Governate">المحافظة </label>
                                                            <asp:DropDownList ID="ddlGov" AppendDataBoundItems="true" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlGov_SelectedIndexChanged"></asp:DropDownList>

                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" SetFocusOnError="true" InitialValue="0" ValidationGroup="academic" ControlToValidate="ddlGov" Display="Dynamic" ErrorMessage="مطلوب هذه الخانة"
                                                                ForeColor="Red"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>

                                                    <div class="col-md-4 col-12">
                                                        <div class="form-group">
                                                            <label for="form_area">منطقة</label>
                                                            <asp:DropDownList ID="ddlArea" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" InitialValue="0" runat="server" SetFocusOnError="true" ValidationGroup="academic" ControlToValidate="ddlArea" Display="Dynamic" ErrorMessage="مطلوب هذه الخانة"
                                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-4 col-12">
                                                        <div class="form-group">
                                                            <label for="form_area">Date</label>
                                                            <asp:TextBox ID="txtDate" runat="server" type="date" CssClass="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" SetFocusOnError="true" ValidationGroup="academic" ControlToValidate="txtDate" Display="Dynamic" ErrorMessage="مطلوب هذه الخانة"
                                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>

                                                   <%-- <div class="col-md-3 col-12">
                                                        <div class="form-group">
                                                            <label for="form_Bookings">موعد الحجز </label>

                                                            <asp:DropDownList ID="ddlBookings" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" InitialValue="0" SetFocusOnError="true" ValidationGroup="academic" ControlToValidate="ddlBookings" Display="Dynamic" ErrorMessage="مطلوب هذه الخانة"
                                                                ForeColor="Red"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>--%>

                                                </div>

                                                <div class="row">
                                                    <div class="col-md-4 col-12">
                                                        <div class="form-group">
                                                            <label for="form_need">الجنسية </label>
                                                            <asp:DropDownList ID="drpNationality" runat="server" CssClass="form-control">
                                                                <asp:ListItem Value="0">--اختر--</asp:ListItem>
                                                                <asp:ListItem Value="كويتي">كويتي</asp:ListItem>
                                                                <asp:ListItem Value="غير كويتي">غير كويتي</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" SetFocusOnError="true" InitialValue="0" ValidationGroup="academic" ControlToValidate="drpNationality" Display="Dynamic" ErrorMessage="مطلوب هذه الخانة"
                                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-4 col-12">
                                                        <div class="form-group">
                                                            <label for="form_email">الهاتف </label>
                                                            <asp:TextBox ID="txttelephone" runat="server" CssClass="form-control" MaxLength="8" autocomplete="off"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" SetFocusOnError="true" ValidationGroup="academic" ControlToValidate="txttelephone" Display="Dynamic" ErrorMessage="مطلوب هذه الخانة"
                                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator
                                                                EnableClientScript="true"
                                                                ID="RegularExpressionValidator2" runat="server"
                                                                ErrorMessage="رقم الهاتف يجب ان يكون 8 ارقام!"
                                                                ValidationGroup="academic"
                                                                ControlToValidate="txttelephone" Display="dynamic"
                                                                ValidationExpression="^[0-9]{8}$"
                                                                CssClass="red" />
                                                        </div>
                                                    </div>

                                                    <div class="col-md-4 col-12">
                                                        <div class="form-group">
                                                            <label for="form_email">البريد الإلكتروني </label>
                                                            <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" autocomplete="off"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" SetFocusOnError="true" ValidationGroup="academic" ControlToValidate="txtemail" Display="Dynamic" ErrorMessage="مطلوب هذه الخانة"
                                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                                                ErrorMessage="يرجى كتابة عنوان الإيميل"
                                                                ControlToValidate="txtemail" CssClass="red" Display="dynamic"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                ValidationGroup="academic"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>

                                                </div>
                                                <asp:UpdatePanel ID="update1" runat="server">
                                                    <ContentTemplate>
                                                        <div class="row">




                                                            <div class="col-md-4 col-12">
                                                        <div class="form-group">
                                                            <label for="form_need">Year in high school</label>
                                                            <asp:DropDownList ID="ddlHighYear" runat="server" CssClass="form-control">
                                                                <asp:ListItem Value="0">--اختر--</asp:ListItem>
                                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                                <asp:ListItem Value="11">11</asp:ListItem>
                                                                 <asp:ListItem Value="12">12</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" SetFocusOnError="true" InitialValue="0" ValidationGroup="academic" ControlToValidate="ddlHighYear" Display="Dynamic" ErrorMessage="مطلوب هذه الخانة"
                                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-4 col-12">
                                                        <div class="form-group">
                                                            <label for="form_email">High School Name </label>
                                                            <asp:TextBox ID="txtschool" runat="server" CssClass="form-control" autocomplete="off"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidato" runat="server" SetFocusOnError="true" ValidationGroup="academic" ControlToValidate="txtschool" Display="Dynamic" ErrorMessage="مطلوب هذه الخانة"
                                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>

                                                            <div class="col-md-4 col-12" >
                                                                <div class="form-group">
                                                                    <label for="form_email"> GPA \100% <%--GPA <span class="text-danger">(Out of 100%)</span>--%></label>
                                                                    <asp:TextBox ID="txtGPA" runat="server" CssClass="form-control" ClientIDMode="Static" autocomplete="off"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" SetFocusOnError="true" ValidationGroup="academic" ControlToValidate="txtGPA" Display="Dynamic" ErrorMessage="مطلوب هذه الخانة"
                                                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                                                        ErrorMessage="Enter Valid GPA"
                                                                        ControlToValidate="txtGPA" CssClass="text-danger" Display="dynamic"
                                                                        ValidationExpression="^\d+(\.\d+)*$"
                                                                        ValidationGroup="academic"></asp:RegularExpressionValidator>

                                                                    <asp:CustomValidator ID="customvalidator" runat="server" ControlToValidate="txtGPA" ErrorMessage="Invalid Range" Display="Dynamic" ValidationGroup="academic"
                                                                        SetFocusOnError="true" CssClass="text-danger" ClientValidationFunction="GetRange"></asp:CustomValidator>
                                                                </div>
                                                            </div>
                                                            </div>

                                                             <div class="row">

                                                            <div class="col-md-4 col-12">
                                                                <div class="form-group">
                                                                    <label for="form_email">Any Achievements </label>
                                                                    <asp:RadioButtonList runat="server" ID="radioAchievements" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="radioAchievements_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" SetFocusOnError="true" ValidationGroup="academic" ControlToValidate="txtAchievements" Display="Dynamic" ErrorMessage="مطلوب هذه الخانة"
                                                                        ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                    <asp:Label id="lblAchievements" runat="server" CssClass="text-danger" ></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-4 col-12" runat="server" id="DivAchievements" visible="false">
                                                                <div class="form-group">
                                                                    <label for="txtAchievements">List any achievements you have accomplished </label>
                                                                    <asp:TextBox ID="txtAchievements" runat="server" CssClass="form-control" ClientIDMode="Static" autocomplete="off"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" SetFocusOnError="true" ValidationGroup="academic" ControlToValidate="txtAchievements" Display="Dynamic" ErrorMessage="مطلوب هذه الخانة"
                                                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                      </div>

                                                         <div class="row">
                                                             <div class="col-md-4 col-12" >
                                                                <div class="form-group">
                                                                    <label for="form_email">Do you have IELTS </label>
                                                                    <asp:RadioButtonList runat="server" ID="rblIELTS" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblIELTS_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="مطلوب هذه الخانة"
                                                                          ControlToValidate="rblIELTS" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                                                           ValidationGroup="academic"></asp:RequiredFieldValidator>
                                                                    <asp:Label id="Label1" runat="server" CssClass="text-danger" ></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-12" runat="server" id="DivScore" visible="false">
                                                                <div class="form-group">
                                                                    <label for="txtscore"> </label>
                                                                    <asp:TextBox ID="txtscore" runat="server" CssClass="form-control" ClientIDMode="Static" autocomplete="off"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" SetFocusOnError="true" ValidationGroup="academic" ControlToValidate="txtscore" Display="Dynamic" ErrorMessage="مطلوب هذه الخانة"
                                                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                                                                        ErrorMessage="Enter Valid Score"
                                                                        ControlToValidate="txtscore" CssClass="text-danger" Display="dynamic"
                                                                        ValidationExpression="^[1-9]\d*(\.\d+)?$"
                                                                        ValidationGroup="academic"></asp:RegularExpressionValidator>
                                                                     <asp:CustomValidator ID="customvalidato" runat="server" ControlToValidate="txtscore" ErrorMessage="Invalid Range" Display="Dynamic" ValidationGroup="academic"
                                                                        SetFocusOnError="true" CssClass="text-danger" ClientValidationFunction="GetScoreRange"></asp:CustomValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                 <div class="row">
                                                            <div class="col-md-12 col-12">
                                                                <div class="form-group">
                                                                    <label for="form_email">List any special skills or talents you have </label>
                                                                    <asp:TextBox ID="txtSkills" runat="server" CssClass="form-control" ClientIDMode="Static" autocomplete="off" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" SetFocusOnError="true" ValidationGroup="academic" ControlToValidate="txtSkills" Display="Dynamic" ErrorMessage="مطلوب هذه الخانة"
                                                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                                                  
                                                                </div>
                                                            </div>
                                                     </div>
                                                <div class="row">
                                                            <div class="col-md-12 col-12">
                                                                <div class="form-group">
                                                                    <label for="form_email">Briefly tell us a little more about you </label>
                                                                    <asp:TextBox ID="txtMore" runat="server" CssClass="form-control"  autocomplete="off" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" SetFocusOnError="true" ValidationGroup="academic" ControlToValidate="txtMore" Display="Dynamic" ErrorMessage="مطلوب هذه الخانة"
                                                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                                                     <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator16" ControlToValidate="txtMore"
                                                                        ErrorMessage="Fill the Text in English" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^[a-zA-Z0-9@#$%&*^ّ<>|=+\-_(),+':;?.,!\[\]\s\\/]{6,}$"
                                                                        ValidationGroup="academic" ForeColor="red"> </asp:RegularExpressionValidator>
                                                                </div>
                                                                <asp:Label ID="lblcount" runat="server" CssClass="text-danger" ClientIDMode="Static" Text=" maximum 250 Words"></asp:Label>
                                                            </div>
                                                     </div>
                                                <div class="row">

                                                    <div class="col-md-12">

                                                        <div class="tacbox">
                                                            <input type="checkbox" id="tremsCheck">
                                                            <asp:CustomValidator ID="custom" runat="server" ValidationGroup="academic" SetFocusOnError="true"
                                                                EnableClientScript="true" ErrorMessage="(*)" CssClass="text-danger" ClientValidationFunction="CheckTerms"></asp:CustomValidator>

                                                            <%-- <label for="checkbox"><a href="#" data-toggle="modal" data-target="#exampleModal">أوافق على الشروط   </a></label>--%>
                                                            <label for="checkbox"><a href="https://mohe.edu.kw/site/ar/services/enrollments/scholarships/excellence.aspx" target="_blank" style="color: #0a20bd; text-decoration: underline !important;">أوافق على شروط البعثات المتميزة من التعليم العالي </a></label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                   
                                                    <div class="col-md-4 mx-auto col-12">
                                                        <asp:LinkButton ID="btnSubmit" runat="server" ValidationGroup="academic" Visible="false" CssClass="btn btn-custom btn-send pt-2 btn-block" Text="تسجيل" OnClick="btnSubmit_Click" />
                                                    </div>
                                                </div>

                                                <%-- <div class="row">
                                                     <div class="col-md-12 col-sm-12 col-xs-12 text-center" >  <h2 class="text-danger"> <span  style="font-size:25px;" >  عذرا ، لقد تم إغلاق التسجيل . </span></h2></div>
                                    
                                                 </div>--%>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                 <div class="heading-f-bg"></div>
                </div>
      
    </div>
    
         </div>

            </div>



                <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLabel">الشروط</h5>
                                <button type="button" class="close term-close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body terms-body">
                                <p>
                                    مستوفي شروط البعثات المتميزة من التعليم العالي
                                </p>

                            </div>
                            <div class="modal-footer">
                                <%--<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>--%>
                            </div>
                        </div>
                    </div>
                </div>

           <%-- </div>
        </div>--%>
        <script>
            function CheckTerms(source, args) {
                //var x = document.getElementById("tremsCheck").checked;              
                return (args.IsValid = document.getElementById("tremsCheck").checked)
            }


            function GetRange(source, args) {

                var value = parseFloat($("#txtGPA").val());
                if (typeof value === 'number') {
                    if (value > 100)
                        return (args.IsValid = false);
                    else if (value < 75)
                        return (args.IsValid = false);
                    else
                        return (args.IsValid = true);
                }
                else
                    return (args.IsValid = false);

            }


            function GetScoreRange(source, args) {

                var value = parseFloat($("#txtscore").val());
                if (typeof value === 'number') {
                    if (value >= 10)
                        return (args.IsValid = false);
                    else if (value < 1)
                        return (args.IsValid = false);
                    else
                        return (args.IsValid = true);
                }
                else
                    return (args.IsValid = false);

            }
        </script>

        <script>
            $(document).ready(function () {

                $("[id*=txtMore]").on('keypress', function (e) {                   
                    var limit = 250;

                    var str = $(this).val();
                    var arr = str.split(" ");
                    var txtlength = arr.length;


                    var diff = limit - txtlength;

                    $("#lblcount").text(diff +" Words Remaining");

                    if (diff < 1)                       
                        e.preventDefault();
                   



                });

              
            });
        </script>

          

    </div>
</asp:Content>

