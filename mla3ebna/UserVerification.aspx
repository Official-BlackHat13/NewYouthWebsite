<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserVerification.aspx.cs" Inherits="UserVerification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.0.1/css/font-awesome.css" />

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>



            <style>
                #wrapper {
                    font-family: Lato;
                    font-size: 1.5rem;
                    text-align: center;
                    box-sizing: border-box;
                    color: #333;
                    max-width: 90%;
                    margin: 0 auto;
                }

                #dialog h4 {
                    margin-top: 30px;
                }
                /*#wrapper #dialog {
	 border: solid 1px #ccc;
	 margin: 10px auto;
	 padding: 20px 30px;
	 display: inline-block;
	 box-shadow: 0 0 4px #ccc;
	 background-color: #faf8f8;
	 overflow: hidden;
	 position: relative;
	 max-width: 450px;
}*/
                #wrapper #dialog h3 {
                    margin: 0 0 10px;
                    padding: 0;
                    line-height: 1.25;
                }

                #wrapper #dialog span {
                    font-size: 90%;
                }
                /*#wrapper #dialog #form {
	 max-width: 240px;
	 margin: 25px auto 0;
}*/
                /*#wrapper #dialog #form input {
	 margin: 0 5px;
	 text-align: center;
	 line-height: 80px;
	 font-size: 50px;
	 border: solid 1px #ccc;
	 box-shadow: 0 0 5px #ccc inset;
	 outline: none;
	 width: 20%;
	 transition: all 0.2s ease-in-out;
	 border-radius: 3px;
}*/
                #wrapper #dialog #form input:focus {
                    border-color: purple;
                    box-shadow: 0 0 5px purple inset;
                }

                #wrapper #dialog #form input::selection {
                    background: transparent;
                }

                #wrapper #dialog #form button {
                    margin: 30px 0 50px;
                    width: 100%;
                    padding: 6px;
                    background-color: #b85fc6;
                    border: none;
                    text-transform: uppercase;
                }

                #wrapper #dialog button.close {
                    border: solid 2px;
                    border-radius: 30px;
                    line-height: 19px;
                    font-size: 120%;
                    width: 22px;
                    position: absolute;
                    right: 5px;
                    top: 5px;
                }

                #wrapper #dialog div {
                    position: relative;
                    z-index: 1;
                }

                #wrapper #dialog img {
                    position: absolute;
                    bottom: -70px;
                    right: -63px;
                }

                .alert-danger {
                    width: 60%;
                    margin: 0 auto;
                    text-align: center;
                }
            </style>

            <script>
                $(function () {
                    'use strict';

                    var body = $('body');

                    function goToNextInput(e) {
                        var key = e.which,
                          t = $(e.target),
                          sib = t.next('.passcoder');

                        if (key != 9 && (key < 48 || key > 57) && (key < 96 || key > 105)) {
                            e.preventDefault();
                            return false;
                        }

                        if (key === 9) {
                            return true;
                        }

                        if (!sib || !sib.length) {
                            sib = body.find('.passcoder').eq(0);
                        }
                        sib.select().focus();
                    }

                    function onKeyDown(e) {
                        var key = e.which;

                        if (key === 9 || (key >= 48 && key <= 57) || (key >= 96 && key <= 105)) {
                            return true;
                        }

                        e.preventDefault();
                        return false;
                    }

                    function onFocus(e) {
                        $(e.target).select();
                    }

                    body.on('keyup', '.passcoder', goToNextInput);
                    body.on('keydown', '.passcoder', onKeyDown);
                    body.on('click', '.passcoder', onFocus);

                })





            </script>

      <%--      <script>
                jQuery(document).ready(function () {


                    $("#lnkVerify").click(function (e) {

                        $('input[type=text]').each(function () {
                            if (typeof ($(this).val()) === 'undefined' || ($(this).val() === '')) {
                                alert("Fill the Values");
                                $(this).focus();
                                e.preventDefault();
                                return false;

                            }
                            else
                                return true;

                        });
                    });




                });
            </script>--%>



            <div id="wrapper">
                <div id="dialog">

                    <h2>الرجاء إدخال رمز التفعيل المكون من 6 أرقام الذي تم إرساله عن طريق رسالة نصية أو البريدالإلكتروني</h2>
                    <div class="form-group" style="margin: 10px" id="divmodalmsg" runat="server" visible="false"></div>
                    <div style="display: none" class="spinner" id="divmodalspin"></div>
                    <h4>(نريد التأكد قبل التواصل معك  )</h4>
                    <br />
                    <div id="form">



                        <asp:TextBox ID="txtopt1" runat="server" MaxLength="1" size="1" CssClass="passcoder"></asp:TextBox>

                        <asp:TextBox ID="txtopt2" runat="server" MaxLength="1" size="1" CssClass="passcoder"></asp:TextBox>

                        <asp:TextBox ID="txtopt3" runat="server" MaxLength="1" size="1" CssClass="passcoder"></asp:TextBox>

                        <asp:TextBox ID="txtopt4" runat="server" MaxLength="1" size="1" CssClass="passcoder"></asp:TextBox>

                        <asp:TextBox ID="txtopt5" runat="server" MaxLength="1" size="1" CssClass="passcoder"></asp:TextBox>

                        <asp:TextBox ID="txtopt6" runat="server" MaxLength="1" size="1" CssClass="passcoder"></asp:TextBox>
                       
                        <asp:LinkButton ID="lnkVerify" runat="server" CssClass="btn btn-success btn-embossed" Text="تأكد" OnClick="lnkVerify_Click"></asp:LinkButton>
                    </div>
                    <br />
                    <br />
                    <div>
                        <h4>لم يصلك الرمز ؟</h4>

                        <%--<a ng-href="" style="cursor: pointer;" ng-click="$event.preventDefault();OnClickREsendOTP();">اعادة ارسال الرمز </a>--%>

                        <asp:LinkButton ID="lnkresend" runat="server" CssClass="btn btn-primary" Text="عادة ارسال الرمز" ClientIDMode="Static" OnClick="lnkresend_Click"></asp:LinkButton>
                        <br />
                    </div>

                </div>
            </div>

        </div>
    </form>

</body>
</html>
