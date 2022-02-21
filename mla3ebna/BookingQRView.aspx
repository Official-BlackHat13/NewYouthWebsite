<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BookingQRView.aspx.cs" Inherits="BookingQRView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ملاعبنا</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <script src="js/jquery.js"></script>
    <script src="js/jquery-ui.js"></script>
    <script src="js/jquery-migrate-1.2.1.min.js"></script>
    <script src="js/jquery.easing.1.3.js"></script>
    <script src="js/superfish.js"></script>

    <script src="js/select2.js"></script>
    <script src="js/jquery.superslides.js"></script>
    <script src="js/jquery.parallax-1.1.3.resize.js"></script>


    <script src="js/jquery.appear.js"></script>
    <script src="js/jquery.caroufredsel.js"></script>
    <script src="js/jquery.touchSwipe.min.js"></script>
    <script src="js/jquery.ui.totop.js"></script>

    <script src="js/touchTouch.jquery.js"></script>
    <%-- <script src="js/isotope.pkgd.min.js"></script>--%>
    <script src="js/imagesloaded.pkgd.js"></script>




    <script src="js/script.js"></script>


    <link href="images/favicon.png" rel="icon" />


    <link href="css/bootstrap.css" rel="stylesheet" />

    <link href="css/jquery-ui.css" rel="stylesheet" />
    <link href="css/font-awesome.css" rel="stylesheet" />
    <link href="css/superslides.css" rel="stylesheet" />
    <%-- <link href="css/superslides.css" rel="stylesheet" />--%>
    <%--  <link href="css/isotope.css" rel="stylesheet"/>--%>
    <link href="css/animate.css" rel="stylesheet" />
    <link href="css/select2.css" rel="stylesheet" />
    <link href="css/smoothness/jquery-ui-1.10.0.custom.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="main">
            <div class="top2_wrapper">
                <div class="container">
                    <div class="top2 clearfix">
                        <div class="row">
                            <div class="col-lg-2"></div>
                            <div class="col-lg-8 sucess-container">
                                <div class="row">
                                    <div class="col-md-6 col-lg-6 col-xs-6 text-left">
                                        <img src="images/Malebna_logo.png" />
                                    </div>
                                    <div class="col-md-6 col-lg-6 col-xs-6 text-right">
                                        <img src="images/MaleabnaLogo.png" alt="" height="85" class="text-right" />
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <br />
                                <br />
                                <%--  <div class="payment-status"></div>--%>
                                <div class="booking-row">
                                    <div class="input2_wrapper row">
                                        <label class="col-md-6 ">اللإسم</label>

                                        <div class="col-md-6">
                                            <span class="red">
                                                <asp:Label ID="lblcName" runat="server"></asp:Label>
                                            </span>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="input2_wrapper row">
                                        <label class="col-md-6">المكان</label>

                                        <div class="col-md-6">
                                            <span class="red">
                                                <asp:Label ID="lblStadiumName" runat="server"></asp:Label>
                                            </span>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="input2_wrapper row">
                                        <label class="col-md-6">الملعب</label>

                                        <div class="col-md-6">
                                            <span class="red">
                                                <asp:Label ID="lbladdress" runat="server"></asp:Label>
                                            </span>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="input2_wrapper row">
                                        <label class="col-md-6">الفترة</label>

                                        <div class="col-md-6">
                                            <span class="red">
                                                <asp:Label ID="lblselTime" runat="server"></asp:Label>
                                            </span>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="input2_wrapper row">
                                        <label class="col-md-6">التاريخ</label>

                                        <div class="col-md-6">
                                            <span class="red">
                                                <asp:Label ID="lblSelDate" runat="server"></asp:Label>
                                                <%--{{dtBooking[0].SelDate}}--%></span>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
