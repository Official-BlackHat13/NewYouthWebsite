<%@ Page Title="" Language="C#" MasterPageFile="cpanl.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="YCA_Admin_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="url" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pagetitle" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="mainContent" runat="Server">
    <asp:HiddenField runat="server" ID="HiddenField3" />

    <div id="success" class="alert alert-success" runat="server" visible="false">
        <p>Edited Successfully</p>
    </div>
    <div class="controls">
                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-info"  Text="Update Profile"
                        OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-info marginleft15"  Text="Reset Password"
                        OnClick="btnCancel_Click" />
                </div>
    <div id="pnlProfile" runat="server" visible="true">
        <div class="widgetcontent bordered shadowed stdform">
            <h4 class="widgettitle">Profile</h4>

            <div class="control-group"></div>
            <div class=" control-group">
                <label class="control-label">الاسم</label>
                <div class="controls">
                    <asp:RequiredFieldValidator ID="txtNameValidator" runat="server" Display="Dynamic"
                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtname"
                        CssClass="red" ValidationGroup="personalInfo"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtname" runat="server" ClientIDMode="Static" CssClass="span5 nf" Enabled="false"></asp:TextBox>

                </div>
            </div>
            <!-- // Group END -->

            <div class=" control-group">
                <label class="control-label">الهاتف النقال</label>
                <div class="controls">
                    <asp:TextBox ID="txtmob" runat="server" ClientIDMode="Static" class="span5 nf" Enabled="false"></asp:TextBox>

                </div>
            </div>
            <!-- // Group END -->
            <div class=" control-group">
                <label class="control-label">البريد الالكتروني</label>
                <div class="controls">
                    <asp:TextBox ID="txtemail" runat="server" ClientIDMode="Static" CssClass="span5 nf" Enabled="false"></asp:TextBox>

                </div>
            </div>
            <!-- // Group END -->

      





            <hr />
            <div class="par control-group">
                   <div class="controls">
                    <asp:Button ID="btUpdate" runat="server" CssClass="btn btn-info"  Text="Save"  ValidationGroup="personalInfo" Visible="false"
                       OnClick="btUpdate_Click" />
                   
                </div>
                
            </div>

        </div>

    </div>
    <!-- notification msgsuccess -->

    <div id="pnlResetPassword" runat="server" visible="false">

        <div class="widgetcontent bordered shadowed stdform">
            <h4 class="widgettitle">Reset Password</h4>

                  <div class=" control-group">
                <label class="control-label">الرقم السري الجديد</label>
                <div class="controls">
                    <asp:RequiredFieldValidator ID="txtPasswordValidator1" runat="server" ForeColor="Red" Display="Dynamic"
                        ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtPassword" CssClass="red" class="span5" ValidationGroup="personalInfo1"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtPassword" runat="server"
                        ValidationGroup="personalInfo"
                        AutoCompleteType="Disabled" TextMode="Password" class="span5 nf"></asp:TextBox>



                </div>

            </div>
            <!-- // Group END -->
            <div class=" control-group">
                <label class="control-label">تأكيد الرقم السري</label>
                <div class="controls">
                    <asp:CompareValidator ID="CompareValidator1" runat="server"
                        ControlToCompare="txtPassword" Display="Dynamic"
                        ControlToValidate="txtPassword2"
                        ErrorMessage=" كلمة المرور لم تطابق" CssClass="red" ForeColor="Red" ValidationGroup="personalInfo1"></asp:CompareValidator>
                    <asp:TextBox ID="txtPassword2" runat="server"
                        ValidationGroup="personalInfo" TextMode="Password" class="span5"></asp:TextBox>





                </div>
            </div>
            <!-- // Group END -->
               <hr />
            <div class="par control-group">
                   <div class="controls">
                    <asp:Button ID="btReset" runat="server" CssClass="btn btn-info"  Text="Save"  ValidationGroup="personalInfo1" 
                      OnClick="btReset_Click" />
                   
                </div>
                
            </div>
        </div>
    </div>
</asp:Content>

