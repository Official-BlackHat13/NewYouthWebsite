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
        .box h2
        {
            font-size:1.6rem !important;
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
              .content ul li {
                list-style-type:none;
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
                margin:0 auto;
             background: #f3f3f3;
            position: relative;
            z-index: 103;
            padding: 10px;
            border-radius: 5px;
            box-shadow: 0 2px 5px #000;
            margin-top: -250px;
        }

        .iframe-container {
            position: relative;
            width: 100%;
            padding-bottom: 56.25%;
            height: 0;
        }

            .iframe-container iframe {
                position: absolute;
                top: 0;
                left: 0;
                width: 100%;
                height: 100%;
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


      <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                  
                </div>
                <div class="modal-body">
                    <p>
                        <video class="embed-responsive-item" width="100%" controls autoplay muted>
                            <source src="Video/YPI_Intro.mp4" type="video/mp4" />
                        </video>
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">اغلاق</button>
                </div>
            </div>

        </div>
    </div>


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


            <div class="container text-right" style="direction:rtl;">

                 <div class="text-center mt-50">
                <h3> المبادر المحترف </h3>

            </div>

            <hr />
                <div class="bg-white">
                 
                      <div class="row" >
                            <div class="col-xs-12 col-md-12 ">




                                <div class='popup container'>
                                    <div class='content'>
                                        <span class='fancybox-item fancybox-close x'></span>


                                        <h2 class="ipages_title1" ><strong>شروط التقديم</strong></h2>
                                        <ul>
                                            <li>1.	أن يكون المتقدم كويتي الجنسية.
                                            </li>
                                            <li>2. ان لا يقل عمره عن واحد وعشرون عاما ولايزيد عن خمسة وثلاثين عاما.

                                            </li>

                                            <li>3.	أن تندرج فكرة المشروع تحت القطاعات الستة:
                                                <br />
                    
                     التكنولوجيا ونظم المعلومات والإتصالات
                    <br />
                                                الفنون والآداب والمجال الإبداعي والإعلامي
                    <br />
                                                القطاع الزراعي والثروة الحيوانية والأمن الغدائي
                    <br />
                                                الحرفي والصناعي
                    <br />
                                                الصحة والبيئة والطاقة المتجددة
                    <br />
                                                نشاط تأجير المركبات الترفيهية
                                            </li>

                                        </ul>

                                        <a href='' class="btn btn-info cls">اغلاق</a>

                                    </div>
                                </div>


                                <div class='popupActivity container'>
                                    <div class='content1'>

                                        <span class='fancybox-item fancybox-close x'></span>

                                        <iframe type="application/pdf"
                                            width="780"
                                            height="780"
                                            src="Document/suspendedActivity.pdf" class="pdf-mobile"></iframe>


                                        <a href='' class="btn btn-info cls">اغلاق</a>

                                    </div>
                                </div>


                             <div class="col-lg-12 col-xs-12">

                             
                                    <h3 >المبادر المحترف</h3>
                               
                                

                                        <p>يهدف البرنامج الى تاهيل وتدريب الشباب الكويتي بما يجعل لديهم القدره على اقامة مشاريعهم الخاصه وفق متطلبات السوق المحلي وحسب متطلبات الجهات التمويليه ومن اهمها الصندوق الوطني لرعاية وتنمية المشروعات الصغيرة والمتوسطه ، وذلك وفق برنامج تدريبي خلال ثلاثة شهور بالتعاون مع حاضنات الاعمال المعتمده وبالشراكه مع كل من مركز صباح الاحمد للموهبه والابداع وكلية الهندسة والبترول بجامعة الكويت .</p>


                                        <div class="row py-5">
                                  
                                        <div class="col-md-4 text-xs-center text-center">
                                            <a href="YPIfeedback.aspx">
                                                <div class="box">

                                                    <div class="icon">
                                                        <img src="../assets/images/YPI_Survey.png" alt="" />
                                                    </div>

                                                    <h4>استبيان برنامج المبادر المحترف</h4>



                                                </div>
                                            </a>
                                        </div>

                                        <div class="col-md-4 text-xs-center text-center">
                                            <a href="#" class="click">
                                                <div class="box">

                                                    <div class="icon">
                                                        <img src="../assets/images/forms1.png" alt="" />
                                                    </div>

                                                    <h4>شروط التقديم</h4>

                                                </div>
                                            </a>
                                        </div>



                                        <div class="col-md-4 text-xs-center text-center">
                                            <a href="initiativeForm.aspx">
                                                <div class="box">

                                                    <div class="icon">
                                                        <img src="../assets/images/forms.png" alt="" />
                                                    </div>

                                                    <h4>نماذج التقديم</h4>

                                                </div>
                                            </a>
                                        </div>


                                        </div>



                                        <div class="clearfix"></div>
                                        <div class="clearfix"></div>



                                        <div class="row py-5">
                                            <div class="col-md-3 text-center"></div>
                                            <div class="col-md-6 text-center">
                                                <div class="iframe-container">
                                                    <%--<iframe width="100%" height="315" src="https://www.youtube.com/embed/pfh1DZJVkpU" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>--%>
                                                    <iframe width="100%" height="315" src="https://www.youtube.com/embed/R8hzhxkMC_w" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                                                  
                                                </div>
                                            </div>
                                            <div class="col-md-3 text-center"></div>
                                        </div>

                                   
                                    <br />


                                    <div class="container">

                                 

                                        </div>

                                       <div class="row">
                                     
                                            <div class="col-md-12 text-center py-md-5 " >

                                                   <%--  <h3 style="color: black;">للاستفسار عن المبادر المحترف:  134</h3>--%>

                                                        <%-- <h4 style="color: black;">Extn : 6124/6123/6099</h4>--%>
                                                      <h6 style="color: black;"><i class="fa fa-envelope"></i>: enquiries@youth.gov.kw</h6>
                                            </div>
                                      </div>

                                    
                                    </div>



                                  <div class="heading-f-bg""></div>

                                </div>


                            
                                

                            </div>
                      
                    </div>
                </div>          
      
    
    <script>

        $(window).on('load', function () {
            $('#myModal').modal('show');
        });


                                </script>
  


</asp:Content>
