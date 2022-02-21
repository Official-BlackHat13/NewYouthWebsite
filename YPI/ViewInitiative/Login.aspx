<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="ViewInitiative_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=System.Configuration.ConfigurationSettings.AppSettings["TitleViewInitiative"]%></title>
     <meta charset="utf-8">
    <meta content="ie=edge" http-equiv="x-ua-compatible">
    <meta content="iMaxtel IT" name="keywords">
    <meta content="iMaxtel IT" name="author">
    <meta content="iMaxtel IT" name="description">
    <meta content="width=device-width, initial-scale=1" name="viewport">
    <link href="img/favicon.ico" rel="shortcut icon">
    <link href="apple-touch-icon.png" rel="apple-touch-icon">
    <link href="https://fonts.googleapis.com/css?family=Rubik:300,400,500" rel="stylesheet" type="text/css">
    <link href="bower_components/select2/dist/css/select2.min.css" rel="stylesheet">
    <link href="bower_components/bootstrap-daterangepicker/daterangepicker.css" rel="stylesheet">
    <link href="bower_components/dropzone/dist/dropzone.css" rel="stylesheet">
    <link href="bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet">
    <link href="bower_components/fullcalendar/dist/fullcalendar.min.css" rel="stylesheet">
    <link href="bower_components/perfect-scrollbar/css/perfect-scrollbar.min.css" rel="stylesheet">
    <link href="bower_components/slick-carousel/slick/slick.css" rel="stylesheet">
    <link href="css/main.css?version=4.4.0" rel="stylesheet">
    <style>
        .require {
            color: red;
        }
        .loginTittle {    display: inline-block;
    vertical-align: middle;
    color: #047bf8;
    letter-spacing: 1px;
    text-transform: uppercase;
    font-weight: 500;
    font-size: 1.6rem;
    position: relative;
    margin-left: 10px;
        }
        .auth-box-w .logo-w {
    text-align: center;
    padding: 20%;
    padding-top: 10% !important;
    padding-right: 20%;
    padding-bottom: 10% !important;
    padding-left: 20%;
}
        </style>
</head>
<body class="auth-wrapper">
    <div class="all-wrapper menu-side with-pattern">
      <div class="auth-box-w">
        <div class="logo-w"><%--<span class="loginTittle">Dr.Esraa Clinic</span>--%>
          <a href="Default.aspx"><img alt="" src="img/MYALogo.png"></a>
        </div>
        <h4 class="auth-header">
          تسجيل الدخول
        </h4>
       <form id="form1" runat="server">
          <div class="form-group"><%--مطلوب هذه الخانة--%>
            <label for="">اسم المستخدم <asp:RequiredFieldValidator CssClass="require" ControlToValidate="TxtUsername" ID="RequiredFieldValidator4" ValidationGroup="MainValidiateLogin" runat="server" ErrorMessage="(يرجى إدخال اسم المستخدم)"></asp:RequiredFieldValidator></label><asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
             
            <div class="pre-icon os-icon os-icon-user-male-circle"></div>
              
          </div>
          <div class="form-group">
              
            <label for="">كلمة السر <asp:RequiredFieldValidator CssClass="require" ControlToValidate="TxtPassword" ID="RequiredFieldValidator1" ValidationGroup="MainValidiateLogin" runat="server" ErrorMessage="(يرجى إدخال كلمة السر)"></asp:RequiredFieldValidator></label><asp:TextBox ID="TxtPassword" TextMode="Password" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
            <div class="pre-icon os-icon os-icon-fingerprint"></div>
          </div>
          <div class="buttons-w">
              <asp:LinkButton ID="lnkLogin" OnClick="lnkLogin_Click" CssClass="btn btn-primary" runat="server" ValidationGroup="MainValidiateLogin"><i class="ft-unlock"></i>  تسجيل الدخول</asp:LinkButton>
         
          </div>
       </form>
      </div>
    </div>
</body>
</html>
