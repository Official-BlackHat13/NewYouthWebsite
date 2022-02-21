<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Evaluator_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">


    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="Design/scripts/validate.js"></script>
    <!------ Include the above in your HEAD tag ---------->

    <script src="https://cdn.jsdelivr.net/jquery.validation/1.15.1/jquery.validate.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Kaushan+Script" rel="stylesheet">
    <link href="Design/css/style.css" rel="stylesheet">

    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous">
    
    <style>       

        body {
            background: url(../Evaluator/Design/img/bg-img.jpg)  top left no-repeat !important;
            background-size: cover;
        }
    </style>



</head>



<body class="vertical-center">
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div id="first">
                    <div class="myform form ">
                        <div class="logo mb-3">
                            <div class="text-center">
                                <img  src="https://www.youth.gov.kw/mla3ebna/images/MaleabnaLogo.png" height="120"/>
                            </div>
                        </div>

                        <div class="login-or">
                            <hr class="hr-or py-2">
                        </div>

                        <form  name="login" runat="server" class="dir-change">
                            <div class="form-group">
                               
                                <label for="" >
                                    اسم المستخدم
                        <asp:RequiredFieldValidator CssClass="require" ControlToValidate="TxtUsername" ID="RequiredFieldValidator4" placeholder="Enter email" ValidationGroup="MainValidiateLogin" runat="server" ErrorMessage="(يرجى إدخال اسم المستخدم)"></asp:RequiredFieldValidator></label><asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>

                                <div class="pre-icon os-icon os-icon-user-male-circle"></div>

                            </div>
                            <div class="form-group">
                                
                                <label for="">
                                    كلمة السر
                        <asp:RequiredFieldValidator CssClass="require" ControlToValidate="TxtPassword" ID="RequiredFieldValidator1" ValidationGroup="MainValidiateLogin" runat="server" ErrorMessage="(يرجى إدخال كلمة السر)"></asp:RequiredFieldValidator></label><asp:TextBox ID="TxtPassword" TextMode="Password" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                                <div class="pre-icon os-icon os-icon-fingerprint"></div>

                            </div>

                            <div class="row mt-5">
                                <div class="col-md-6 text-center ">

                                    <asp:LinkButton ID="lnkLogin" OnClick="lnkLogin_Click" CssClass="btn btn-block mybtn btn-green tx-tfm" runat="server" ValidationGroup="MainValidiateLogin"><i class="ft-unlock"></i>  تسجيل الدخول</asp:LinkButton>

                                </div>
                                <div class="col-md-6 text-center ">
                                    <button type="reset" class=" btn btn-block mybtn btn-danger tx-tfm">Reset</button>
                                </div>
                            </div>

                        </form>

                    </div>
                </div>

            </div>
        </div>
    </div>

</body>





</html>
