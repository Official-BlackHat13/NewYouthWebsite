<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
<div id="main">  
 <div id="content">
        <div class="container">

            <div class="row">
				<div class="col-sm-3"></div>
                <div class="col-sm-6">
                    <h3>تسجيل الدخول </h3>                   
                    <div id="fields">
                        <div id="ajax-contact-form" class="form-horizontal" >
							<div class="login-box">
                                <div class="form-group" style="margin: 10px" id="divmodalmsg" runat="server" visible="false"></div>                                
                                <div style="display: none" class="spinner" id="divmodalspin"></div>
                            <div class="form-group">
                                <label for="inputName">User Name</label>
                                <asp:TextBox ID="txtUserName" runat="server" placeholder="User Name" CssClass="form-control" Enabled="false"></asp:TextBox>
                               <%-- <input type="text" class="form-control" ng-model="UserName" ng-disabled="true" id="txtusername" placeholder="User Name" required=""
                                       onBlur="if(this.value=='') this.value='E-mail'"
                                       onFocus="if(this.value =='E-mail' ) this.value=''">--%>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail">New Password</label>
                                <%--<input type="password" class="form-control" ng-model="newPassword" id="txtnewpwd" placeholder="New Password"  required="" autocomplete="off"
                                       value="Password" onBlur="if(this.value=='') this.value='Password'"
                                       onFocus="if(this.value =='Password' ) this.value=''">--%>
                                <asp:TextBox ID="txtPwd" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="New Password" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="reset" runat="server" ControlToValidate="txtPwd" CssClass="text-danger" SetFocusOnError="true" ErrorMessage="Required"></asp:RequiredFieldValidator>
                            </div>   
                            <div class="form-group">
                                <label for="inputEmail">Confirm your Password</label>
                                <%--<input type="password" class="form-control" ng-model="rePassword" id="txtrepwd" placeholder="Confirm your Password"  required="" autocomplete="off"
                                       value="Password" onBlur="if(this.value=='') this.value='Password'"
                                       onFocus="if(this.value =='Password' ) this.value=''">--%>
                                <asp:TextBox ID="txtConfirmpwd" runat="server" CssClass="form-control" placeholder="Confirm your Password" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="reset" runat="server" ControlToValidate="txtConfirmpwd" CssClass="text-danger" SetFocusOnError="true" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                 <asp:CompareValidator ID="comp1" runat="server" ValidationGroup="reset" ControlToValidate="txtConfirmpwd" ControlToCompare="txtPwd"
                                                                SetFocusOnError="true" CssClass="text-danger" ErrorMessage="Password Should match"></asp:CompareValidator>
                            </div>                           
                            

                           <%-- <button type="submit" class="btn-default btn-cf-submit" ng-click="btnSubmit();">إرسال </button>--%>
								<asp:LinkButton ID="lnkSubmit" runat="server" ClientIDMode="Static" Text="إرسال" CssClass="btn-default btn-cf-submit" ValidationGroup="reset" OnClick="lnkSubmit_Click"></asp:LinkButton>
							</div>
                            
							 
                        </div>
                    </div>
                </div>
				<div class="col-sm-3"></div>
            </div>            
        </div>
    </div> 
  
	</div>



         <script>
             jQuery(document).ready(function () {


                 $("#lnkSubmit").click(function (e) {

                     $('input[type=text]').each(function () {

                         var pwd = $("#txtPwd").val();
                         if (pwd.length <= 3) {
                             alert("Password should contain atleast 4 letters");
                             $("#txtPwd").focus();
                             e.preventDefault();
                              return false;
                         }
                         else {
                             return true;
                         }

                         //if (typeof ($(this).val()) === 'undefined' || ($(this).val() === '')) {
                         //    alert("Fill the Values");
                         //    $(this).focus();
                         //    e.preventDefault();
                         //    return false;

                         //}
                         //else
                         //    return true;

                     });
                 });




             });
            </script>


</asp:Content>

