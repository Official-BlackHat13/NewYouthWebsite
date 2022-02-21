<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
    <div class="page_banner"></div>

    <div class="breadcrumbs1_wrapper">
        <div class="container">
            <div class="breadcrumbs1"><a href="index.html">الرئيسية</a><span>/</span> تسجيل مستخدم جديد </div>
        </div>
    </div>

<div id="main">
    
    <div id="content">
        <div class="container">
            <div class="col-lg-12">
                <div class="row" style="direction:rtl;">
                
                    <div class="col-sm-12">
                        <h3 style="margin-right:20px;">تسجيل مستخدم جديد </h3>
                        <div id="fields">
                            <div id="ajax-contact-form3" class="form-horizontal" >
                                <div class="bg-gray1">
                                    
                                       <asp:UpdatePanel ID="update1" runat="server">
                                        <ContentTemplate>
                                    <h4 style="font-weight:bold;">شروط تسجيل حساب جديد</h4>
                                    <ul>
                                        <li>يرجى إدخال بيانات حقيقية مرتبطة بك، حيث سيتحقق مسؤول الملعب من تطابق بياناتك المسجلة بالنظام مع بطاقتك المدنية.</li>

                                      
                                        <li>يرجى إدخال رقم هاتفك النقال حيث سيتم إرسال رسالة قصيرة تحتوي على رمز التفعيل والذي من خلاله يمكنك تفعيل حسابك.</li>

                                    </ul>
                                    <div style="display: none" class="spinner" id="divmodalspin"></div>
                                    <div class="form-group" style=" margin: 10px" id="divmodalmsg" runat="server" visible="false"></div>
                                    <div class="form-group row">
                                        <label for="colFormLabelLg" class="col-sm-3">اسم المستخدم</label>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" autocomplete="off" placeholder="اسم المستخدم"></asp:TextBox>                                             
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="register" runat="server" ControlToValidate="txtUserName" CssClass="text-danger" SetFocusOnError="true" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                        </div>
                                         
                                    </div>

                                    <div class="form-group row">
                                        <label for="colFormLabelLg" class="col-sm-3">الاسم الكامل </label>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="الاسم الأول" ></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="register" runat="server" ControlToValidate="txtName" CssClass="text-danger" SetFocusOnError="true" ErrorMessage="Required"></asp:RequiredFieldValidator>

                                        </div>
                                        <div class="col-sm-2">
                                            <asp:TextBox ID="txtMname" runat="server" CssClass="form-control" placeholder="الثاني"></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="register" runat="server" ControlToValidate="txtMname" CssClass="text-danger" SetFocusOnError="true" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                                        </div>
                                         <div class="col-sm-2">
                                            <asp:TextBox ID="txtTname" runat="server" CssClass="form-control" placeholder="الثالث"></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" ValidationGroup="register" runat="server" ControlToValidate="txtTname" CssClass="text-danger" SetFocusOnError="true" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                                        </div>
                                         <div class="col-sm-2">
                                            <asp:TextBox ID="txtLname" runat="server" CssClass="form-control" placeholder="الأخير"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ValidationGroup="register" runat="server" ControlToValidate="txtLname" CssClass="text-danger" SetFocusOnError="true" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <label for="colFormLabelLg" class="col-sm-3">الرقم المدني</label>
                                        <div class="col-sm-9">
                                              <asp:TextBox ID="txtCivilID" runat="server" CssClass="form-control" MaxLength="12"  placeholder="الأول" ClientIDMode="Static"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="register" runat="server" ControlToValidate="txtCivilID" CssClass="text-danger" SetFocusOnError="true" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                             <asp:RegularExpressionValidator
                                                                            EnableClientScript="true"
                                                                            ID="RegularExpressionValidator1" runat="server"
                                                                            ErrorMessage="البطاقة المدنية يجب ان تكون 12 رقم فقط!"
                                                                            ValidationGroup="register"
                                                                            ControlToValidate="txtCivilID" Display="dynamic"
                                                                            ValidationExpression="^[0-9]{12}$"
                                                                            CssClass="text-danger" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                        </div>
                                        
                                    </div>

                                 
                                             <div class="form-group row">
                                        <label for="colFormLabelLg" class="col-sm-3">المحافظة</label>
                                        <div class="col-sm-9">                                           

                                            <asp:DropDownList ID="DDLGov" runat="server" CssClass="form-control" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="DDLGov_SelectedIndexChanged"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="register" runat="server" ControlToValidate="DDLGov" InitialValue="0" CssClass="text-danger" SetFocusOnError="true" ErrorMessage="Required"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>

                                     <div class="form-group row">
                                        <label for="colFormLabelLg" class="col-sm-3">منطقة</label>
                                        <div class="col-sm-9">                                           

                                            <asp:DropDownList ID="DDLArea" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ValidationGroup="register" runat="server" ControlToValidate="DDLArea" InitialValue="0" CssClass="text-danger" SetFocusOnError="true" ErrorMessage="Required"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                        
                                     <div class="form-group row">
                                        <label for="colFormLabelLg" class="col-sm-3">الجنس</label>
                                        <div class="col-sm-9">
                                            <select class="form-control" style="width: 100%;direction: rtl;" id="cmbGender" data-placeholder="الجنس.." runat="server">
                                                <option style="text-align:right;" value="0"> اختيار </option>
                                                <option style="text-align:right;" value="ذكر">ذكر </option>
                                                <option style="text-align:right;" value="أنثى">أنثى </option>
                                            </select>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="register" runat="server" ControlToValidate="cmbGender" InitialValue="0" CssClass="text-danger" SetFocusOnError="true" ErrorMessage="Required"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <label for="colFormLabelLg" class="col-sm-3">البريد الإلكتروني</label>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="البريد الإلكتروني"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="register" runat="server" ControlToValidate="txtEmail" CssClass="text-danger" SetFocusOnError="true" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                                ErrorMessage="يرجى كتابة عنوان الإيميل"
                                                ControlToValidate="txtEmail" CssClass="text-danger" Display="dynamic"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                ValidationGroup="register"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <label for="colFormLabelLg" class="col-sm-3">رقم الهاتف النقال</label>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtmobile" runat="server" placeholder="رقم الهاتف النقال" CssClass="form-control" MaxLength="8"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="register" runat="server" ControlToValidate="txtmobile" CssClass="text-danger" SetFocusOnError="true" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                             <asp:RegularExpressionValidator
                                                                            EnableClientScript="true"
                                                                            ID="RegularExpressionValidator5" runat="server"
                                                                            ErrorMessage="البطاقة المدنية يجب ان تكون 12 رقم فقط!"
                                                                            ValidationGroup="register"
                                                                            ControlToValidate="txtmobile" Display="dynamic"
                                                                            ValidationExpression="^[0-9]{8}$"
                                                                            CssClass="text-danger" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <label for="colFormLabelLg" class="col-sm-3">كلمة السر</label>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" CssClass="form-control" placeholder="كلمة السر"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="register" runat="server" ControlToValidate="txtPwd" CssClass="text-danger" SetFocusOnError="true" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <label for="colFormLabelLg" class="col-sm-3">تأكيد كلمة السر</label>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtConfirmpwd" runat="server" CssClass="form-control" placeholder="تأكيد كلمة السر" TextMode="Password"></asp:TextBox>
                                            <asp:CompareValidator ID="comp1" runat="server" ValidationGroup="register" ControlToValidate="txtConfirmpwd" ControlToCompare="txtPwd"
                                                                SetFocusOnError="true" CssClass="text-danger" ErrorMessage="Password Should match"></asp:CompareValidator>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="register" runat="server" ControlToValidate="txtConfirmpwd" CssClass="text-danger" SetFocusOnError="true" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                            
                                        </div>
                                    </div>
                                  

                                     <div class="form-group row">
                                        <label for="colFormLabelLg" class="col-sm-12"> <a data-toggle="modal" data-target="#BookPoicyModal" style="color:#464646;cursor: pointer;""> اوافق على سياسة الخصوصية </a> 
                                           <asp:CheckBox ID="chkterms" runat="server" ClientIDMode="Static" />
                                        </label>
                                    
                                    </div>
                                    
                                    <div class="form-group" style="margin: 10px" id="divmodalmsg1"></div>
                                   

                                    <asp:LinkButton ID="lnkSubmit" runat="server" CssClass="btn-default btn-cf-submit" ValidationGroup="register" OnClientClick="return chkterms();" OnClick="lnkSubmit_Click" Text="تسجيل حساب جديد"></asp:LinkButton>

                                            </ContentTemplate>
                                    </asp:UpdatePanel>                                   

                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="col-sm-2"></div>
                </div>
            </div>
        </div>
    </div>

         <!-- Modal -->
<div class="modal fade" id="BookPoicyModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" >
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel"> <asp:Label ID="lblng_modalheading" runat="server"> اوافق على سياسة الخصوصية </asp:Label> </h5>
         
      </div>
      <div class="modal-body"  >           
               
                    <div id="dividmodal" style="direction:rtl;">                    
                    
                        <div runat="server" id="DivPolicy"></div>

                        <div runat="server" id="DivBooking"></div>
                     


                        
                    </div>
           
      </div>

      <div class="modal-footer">
        <button type="button" class="btn btn-danger btn-secondary" data-dismiss="modal">إغلاق </button>
       
      </div>
    </div>
  </div>
</div>

</div>

     <script type="text/javascript">
         function chkterms() {

             $('#divmodalmsg1').hide();




             if ($('input[name$=chkterms]:checked').length > 0) {
                 return true;
             }
             else {

                 $('#divmodalmsg1').html('<div class="alert alert-danger"><button type="button" class="close" data-dismiss="alert"><i class="ace-icon fa fa-times"></i></button><strong>الرجاء قبول الشروط والأحكام </strong> </div>');
                 $('#divmodalmsg1').show();

                 return false;
             }


         }
    </script>

  <script>

      function validate(evt) {
          var theEvent = evt || window.event;
          var key = theEvent.keyCode || theEvent.which;
          key = String.fromCharCode(key);
          var regex = /[0-9]|\./;
          if (!regex.test(key)) {
              theEvent.returnValue = false;
              if (theEvent.preventDefault) theEvent.preventDefault();
          }
      }
      function validatecivilno(evt) {
          var theEvent = evt || window.event;
          var key = theEvent.keyCode || theEvent.which;
          key = String.fromCharCode(key);
          var regex = /[0-9]|\./;
          if (!regex.test(key)) {
              theEvent.returnValue = false;
              if (theEvent.preventDefault) theEvent.preventDefault();
          }

      }
      $("#txtcivil").on('keypress', function () {
          if ($(this).val().length > 11) {
              alert("Civil Id No must be 12 letters long.");
              return false;
          }
      });

      function isValidEmail(emailAddress) {
          var userinput = $('#Email').val();
          var pattern = /^\b[A-Z0-9._%-]+@@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i

          if (!pattern.test(userinput))
              alert('not a valid e-mail address');
          return false;
      };
    </script>
</asp:Content>

