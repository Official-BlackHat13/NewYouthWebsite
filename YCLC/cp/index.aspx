<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="youth_NEW_ADMIN_index" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Ministry of State for Youth Affairs</title>
    <link rel="stylesheet" href="css/style.default.css" type="text/css" />   
</head>

<body class="loginbody">

    <div class="loginwrapper">
        <div class="loginwrap zindex100 animate2 bounceInDown">
            <div class="logintitle">
                <img src="img/logo.png" style="float: left;"><br>
               
            </div>
            <div class="loginwrapperinner">
                <form id="loginform" runat="server">
                    <asp:Panel ID="pnlLogin" runat="server">
                        <p class="animate4 bounceIn">
                            <asp:TextBox ID="txtusername" runat="server" placeholder="Username" CssClass="username"></asp:TextBox>
                        </p>
                        <p class="animate5 bounceIn">
                            <asp:TextBox ID="txtpassword" runat="server" placeholder="Password" CssClass="password" TextMode="Password"></asp:TextBox>
                        </p>

                        <asp:Label runat="server" ID="error" Visible="false"></asp:Label>
                        <p class="animate6 bounceIn">
                            <asp:Button runat="server" CssClass="loginbutton btn btn-default btn-block" Text="Login" ID="btlogin" OnClick="btlogin_Click" ValidationGroup="Login" />
                        </p>
                        <p class="animate7 fadeIn">
                            <asp:LinkButton runat="server" id="lbforgot" onclick="lbforgot_Click"><span class="icon-question-sign icon-white"></span>Forgot Password?</asp:LinkButton>

                        </p>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="Pnl_Password" Visible="false">
                       <%-- <label>اسم المستخدم - البريد الالكتروني</label>--%>
                       <p class="animate4 bounceIn"> <asp:TextBox runat="server"  placeholder="Email ID" CssClass="username" ID="txtEmail"></asp:TextBox> </p>
                        <p class="animate6 bounceIn"><asp:Button runat="server" ID="bt" CssClass="loginbutton btn btn-default btn-block"
                            Text="Submit"  OnClick="bt_Click"></asp:Button> </p>
                        <p class="animate7 fadeIn">
                            <asp:LinkButton runat="server" id="lloginpnl" onclick="lloginpnl_Click"><span class="icon-question-sign icon-white"></span></asp:LinkButton>

                        </p>
                    </asp:Panel>
                </form>
            </div>
            <!--loginwrapperinner-->
        </div>
        <div class="loginshadow animate3 fadeInUp"></div>
    </div>
    <!--loginwrapper-->

  
</body>
</html>
