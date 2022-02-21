<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteMasterPage.master" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        #overlay {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: #000;
            filter: alpha(opacity=70);
            -moz-opacity: 0.7;
            -khtml-opacity: 0.7;
            opacity: 0.7;
            z-index: 100;
            display: none;
        }

        .content a {
            text-decoration: none;
        }

        .popup {
            width: 100%;
            display: none;
            position: fixed;
            z-index: 101;
        }

        .popupActivity {
            width: 100%;
            display: none;
            position: fixed;
            z-index: 101;
        }

        .content {
            min-width: 600px;
            width: 600px;
            min-height: 400px;
            margin: -200px auto;
            background: #f3f3f3;
            position: relative;
            z-index: 103;
            padding: 10px;
            border-radius: 5px;
            box-shadow: 0 2px 5px #000;
        }

            .content p {
                clear: both;
                color: #555555;
                text-align: justify;
            }

            .content ul {
                padding: 20px;
            }

            .content p a {
                color: #d91900;
                font-weight: bold;
            }

            .content .x {
                float: right;
                height: 35px;
                left: 22px;
                position: relative;
                top: -25px;
                width: 34px;
            }

                .content .x:hover {
                    cursor: pointer;
                }

        .content1 {
            min-width: 800px;
            width: 800px;
            min-height: 800px;
            margin: 0px auto;
            background: #f3f3f3;
            position: relative;
            z-index: 103;
            padding: 10px;
            border-radius: 5px;
            box-shadow: 0 2px 5px #000;
            margin-top: -250px;
        }
        .text-center {
            text-align:right;
        }
    </style>

    <script type='text/javascript'>
        $(function () {
            var overlay = $('<div id="overlay"></div>');
            $('.cls').click(function () {
                $('.popup').hide();
                overlay.appendTo(document.body).remove();
                return false;
            });



            $('.x').click(function () {
                $('.popup').hide();
                overlay.appendTo(document.body).remove();
                return false;
            });

            $('.click').click(function () {
                overlay.show();
                overlay.appendTo(document.body);
                $('.popup').show();
                return false;
            });
        });
    </script>

    <script type='text/javascript'>
        $(function () {
            var overlay = $('<div id="overlay"></div>');
            $('.cls').click(function () {
                $('.popupActivity').hide();
                overlay.appendTo(document.body).remove();
                return false;
            });



            $('.x').click(function () {
                $('.popupActivity').hide();
                overlay.appendTo(document.body).remove();
                return false;
            });

            $('.clickA').click(function () {
                overlay.show();
                overlay.appendTo(document.body);
                $('.popupActivity').show();
                return false;
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="PageContent">


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



 
        <div class="container text-right">

             <div class="text-center mt-50">
            <h3>البرنامج التأهيلي لإدارة المرافق والأمن والسلامة والبيئة - الموسم الثالث</h3>

        </div>

        <hr />
             <%--   <div class="bg-white">--%>
                   
                        <div class="row" style="direction: rtl;">

                          

                                <div class="col-lg-12 col-xs-12">
                                    <p >
                                 تعلن الهيئة العامة للشباب عن فتح باب التقديم للبرنامج التأهيلي لإدارة المرافق والأمن والسلامة والبيئة - الموسم الثالث 
                                    </p>

                                     <p >
                                يهدف البرنامج الى إعداد الكوادر الوطنية للعمل في القطاع الخاص بعد تأهيلهم بشكل احترافي ضمن مناهج علمية يشرف عليها خبراء متخصصون في إدارة المرافق والأمن والسلامة والبيئة. 
                                    </p>


                                     <p>
                                 يسعى البرنامج التأهيلي لإدارة المرافق والأمن والسلامة والبيئة لتوفير مسار مهني مطلوب في سوق العمل المحلي والعالمي، وهو عبارة عن برنامج نظري وميداني يتخلله دورات في إدارة المرافق والأمن والسلامة والبيئة، وينتهي البرنامج بتأهيل المتدربين للعمل في القطاع الخاص وتوفير فرص وظيفية لهم في هذا المجال. 
                                    </p>

                                    
                                    <h3 style="margin-top: 20px;"><strong>الشروط الواجب توافرها في المتقدمين: </strong></h3>
                                    <ul style="font: 16px 'Neo Sans Arabic', sans-serif; font-weight: normal; line-height: 30px; list-style:none;">
                                        <li>1.  كويتي الجنسية.
                                        </li>
                                        <li>2.	يجيد اللغة الإنجليزية.               
                                        </li>

                                        <li>3.  ان يكون حاصلاً على بكالوريوس هندسة في أحد التخصصات التالية: 
                        
                                        </li>
                                        <li>

                                           <table class="table table-bordered">
                                               <tr>
                                                   <td> هندسة ميكانيكية </td>
                                                    <td> هندسة كهربائية </td>
                                                    <td> هندسة بيئية</td>
                                               </tr>
                                               <tr>
                                                    <td> هندسة مدنية </td>
                                                    <td> هندسة صناعية </td>
                                                    <td> هندسة كيميائية</td>
                                               </tr>
                                           </table>


                                        </li>
                                       
                                        <li >4.	ألا يكون قد مضى على سنة التخرج أكثر من ثلاث سنوات ونصف من تاريخ نشر الإعلان.  </li>
                                        <li>5.  ألا يكون مسجلا لدى المؤسسة العامة للتأمينات الاجتماعية خلال فترة التسجيل على البرنامج.</li>

                                    </ul>



                                    <p class="col-md-12 text-center" style="padding-top: 30px">
                                        <%--<span style="font-size:28px; color:red;"> عذرا ، لقد تم إغلاق التسجيل .</span>--%>
                                        <asp:LinkButton Font-Bold="true" Width="150px" ID="Linkfinalsubmit" runat="server" ValidationGroup="ContactUs" CssClass="btn btn-lg btn-info m-auto" Text="تسجيل" OnClick="Linkfinalsubmit_Click" ></asp:LinkButton>
                                    </p>

                                </div>

                              
                        </div>
                   
               <%-- </div>--%>
            </div>
   









</asp:Content>
