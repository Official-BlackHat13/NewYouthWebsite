<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectDate.aspx.cs" Inherits="mla3ebna_SelectDate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    

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
      <script src="https://unpkg.com/leaflet@1.5.1/dist/leaflet.js"
    integrity="sha512-GffPMF3RvMeYyc1LWMHtK8EbPv0iNZ8/oTtHPx9/cc2ILxQ+u905qIwdpULaqDkyBKgOaB57QTMg7ztg8Jm2Og=="
    crossorigin=""></script>
    


    <script src="js/script.js"></script>    


       <link href="images/favicon.png" rel="icon"/>
    

    <link href="css/bootstrap.css" rel="stylesheet"/>   
    
    <link href="css/jquery-ui.css" rel="stylesheet"/>
    <link href="css/font-awesome.css" rel="stylesheet"/>
    <link href="css/superslides.css" rel="stylesheet"/>
   <%-- <link href="css/superslides.css" rel="stylesheet" />--%>
  <%--  <link href="css/isotope.css" rel="stylesheet"/>--%>
    <link href="css/animate.css" rel="stylesheet"/>
    <link href="css/select2.css" rel="stylesheet"/>
    <link href="css/smoothness/jquery-ui-1.10.0.custom.css" rel="stylesheet"/>
    <link href="css/style.css" rel="stylesheet" />     
    
    <link rel="stylesheet" href="https://unpkg.com/leaflet@1.5.1/dist/leaflet.css"
    integrity="sha512-xwE/Az9zrjBIphAcBb3F6JVqxf46+CDLwfLMHloNu6KEQCAWi6HcDUbeOfBIptF7tcCzusKFjFw2yuvEpDL9wQ=="
    crossorigin="" />
    <script src="assets/js/bootstrap-datepicker.min.js"></script>
    <script src="assets/js/bootstrap-colorpicker.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>


    <style>
        .map { width: 640px; height: 480px; }
        
        .heart {
          width: 100px;
          height: 100px;
          background: url("heart.png") no-repeat;
          background-position: 0 0;
          cursor: pointer;
          transition: background-position 1s steps(28);
          transition-duration: 0s;
        }
        .heart.is-active {
          transition-duration: 1s;
          background-position: -2800px 0;
        }



        .stage {
          position: fixed;
          top: 50%;
          left: 50%;
          -webkit-transform: translate(-50%, -50%);
                  transform: translate(-50%, -50%);
        }
 
  
        
        @media screen and (min-width: 479px) {
          .title_message {
            visibility: hidden;
            clear: both;
            float: left;
            margin: 10px auto 5px 20px;
            width: 28%;
            display: none;
            background:#6cacc5;
          }
        }

        .spinner {
           position: absolute;
           left: 50%;
           top: 50%;
           height:60px;
           width:60px;
           margin:0px auto;
           -webkit-animation: rotation .6s infinite linear;
           -moz-animation: rotation .6s infinite linear;
           -o-animation: rotation .6s infinite linear;
           animation: rotation .6s infinite linear;
           border-left:6px solid rgba(0,174,239,.15);
           border-right:6px solid rgba(0,174,239,.15);
           border-bottom:6px solid rgba(0,174,239,.15);
           border-top:6px solid rgba(0,174,239,.8); 
           border-radius:100%;
        }
        
           @-webkit-keyframes rotation {
           from {-webkit-transform: rotate(0deg);}
           to {-webkit-transform: rotate(359deg);}
        }
        @-moz-keyframes rotation {
           from {-moz-transform: rotate(0deg);}
           to {-moz-transform: rotate(359deg);}
        }
        @-o-keyframes rotation {
           from {-o-transform: rotate(0deg);}
           to {-o-transform: rotate(359deg);}
        }
        @keyframes rotation {
           from {transform: rotate(0deg);}
           to {transform: rotate(359deg);}
        }
        
        [ng\:cloak], [ng-cloak], [data-ng-cloak], [x-ng-cloak], .ng-cloak, .x-ng-cloak {
          display: none !important;
        }


    fieldset, label {  direction:ltr;}
    /*body{ margin: 20px; }*/
    h1 { font-size: 1.5em; margin: 10px; }

    /****** Style Star Rating Widget *****/

    .ratingonly { 
      border: none;
      float: none;
    }

    .ratingonly > input { display: none; } 
    .ratingonly > label:before { 
      margin: 5px;
      font-size: 1.25em;
      font-family: FontAwesome;
      display: inline-block;
      content: "\f005";
    }

    .ratingonly > .half:before { 
      content: "\f089";
      position: absolute;
    }

    .ratingonly > label { 
      color: #ddd; 
     float: right; 
    }

    .ratingonly > input:checked ~ label, /* show gold star when clicked */
     /*.ratingonly:not(:checked) > label:hover, hover current star */
    /*.ratingonly:not(:checked) > label:hover ~ label { color: #FFD700;  } /* hover previous stars in list */

    /*.ratingonly > input:checked + label:hover, /* hover current star when changing rating */
    /*.ratingonly > input:checked ~ label:hover,
    .ratingonly > label:hover ~ input:checked ~ label, /* lighten current selection */
    .ratingonly > input:checked ~ label:hover ~ label { color: #FFD700;  } 




     .ratingonlytwo { 
      border: none;
      float: none;
    }

    .ratingonlytwo > input { display: none; } 
    .ratingonlytwo > label:before { 
      margin: 5px;
      font-size: 1.25em;
      font-family: FontAwesome;
      display: inline-block;
      content: "\f005";
    }

    .ratingonlytwo > .half:before { 
      content: "\f089";
      position: absolute;
    }

    .ratingonlytwo > label { 
      color: #ddd; 
     float: right; 
    }

    .ratingonlytwo > input:checked ~ label, /* show gold star when clicked */
     /*.ratingonly:not(:checked) > label:hover, hover current star */
    /*.ratingonly:not(:checked) > label:hover ~ label { color: #FFD700;  } /* hover previous stars in list */

    /*.ratingonly > input:checked + label:hover, /* hover current star when changing rating */
    /*.ratingonly > input:checked ~ label:hover,
    .ratingonly > label:hover ~ input:checked ~ label, /* lighten current selection */
    .ratingonlytwo > input:checked ~ label:hover ~ label { color: #FFD700;  } 


    .ratingonlythree { 
      border: none;
      float: none;
    }

    .ratingonlythree > input { display: none; } 
    .ratingonlythree > label:before { 
      margin: 5px;
      font-size: 1.25em;
      font-family: FontAwesome;
      display: inline-block;
      content: "\f005";
    }

    .ratingonlythree > .half:before { 
      content: "\f089";
      position: absolute;
    }

    .ratingonlythree > label { 
      color: #ddd; 
     float: right; 
    }

    .ratingonlythree > input:checked ~ label, /* show gold star when clicked */
     /*.ratingonly:not(:checked) > label:hover, hover current star */
    /*.ratingonly:not(:checked) > label:hover ~ label { color: #FFD700;  } /* hover previous stars in list */

    /*.ratingonly > input:checked + label:hover, /* hover current star when changing rating */
    /*.ratingonly > input:checked ~ label:hover,
    .ratingonly > label:hover ~ input:checked ~ label, /* lighten current selection */
    .ratingonlythree > input:checked ~ label:hover ~ label { color: #FFD700;  } 





    .ratingonlydet { 
      border: none;
      float: none;
    }

    .ratingonlydet > input { display: none; } 
    .ratingonlydet > label:before { 
      margin: 5px;
      font-size: 2.00em;
      font-family: FontAwesome;
      display: inline-block;
      content: "\f005";
    }

    .ratingonlydet > .half:before { 
      content: "\f089";
      position: absolute;
    }

    .ratingonlydet > label { 
      color: #ddd; 
     float: right; 
    }

    .ratingonlydet > input:checked ~ label, /* show gold star when clicked */
   
    .ratingonlydet > input:checked ~ label:hover ~ label { color: #FFD700;  } 
    



    .rating { 
      border: none;
      float: none;
    }

    .rating > input { display: none; } 
    .rating > label:before { 
      margin: 5px;
      font-size: 2.00em;
      font-family: FontAwesome;
      display: inline-block;
      content: "\f005";
    }

    .rating > .half:before { 
      content: "\f089";
      position: absolute;
    }

    .rating > label { 
      color: #ddd; 
     float: right; 
    }

    /***** CSS Magic to Highlight Stars on Hover *****/

    .rating > input:checked ~ label, /* show gold star when clicked */
    .rating:not(:checked) > label:hover, /* hover current star */
    .rating:not(:checked) > label:hover ~ label { color: #FFD700;  } /* hover previous stars in list */

    .rating > input:checked + label:hover, /* hover current star when changing rating */
    .rating > input:checked ~ label:hover,
    .rating > label:hover ~ input:checked ~ label, /* lighten current selection */
    .rating > input:checked ~ label:hover ~ label { color: #FFED85;  } 
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
         <div class="row">
                <div class="col-md-3"></div>
                    <div class="col-md-6" id="dividmodal">      
                                     
        <div id="datepickermodalPop" value="Dd/Mm/Yy" autocomplete="off" ></div>


                         <asp:LinkButton ID="lnkGetStadiumData" runat="server" CssClass="hidden" OnClick="lnkGetStadiumData_Click" ClientIDMode="Static" Text="GetStadiumData"></asp:LinkButton>
                            <asp:HiddenField ID="hiddenDate1" runat="server" ClientIDMode="Static" />
                </div>
            </div>

        <br />

        <div class="row">

            <button type="button" class="btn btn-danger" data-dismiss="modal">إغلاق </button>
          <button type="button" class="btn btn-success" id="btnsearch1">بحث </button>
        </div>

    
    </div>
    </form>
</body>

   

      <script type="text/javascript">
          $(function () {
              $("#btnsearch1").click(function () {
                  alert("1");
                  var selected = $("#hiddenDate1").val();
                  alert($("#hiddenDate1").val());
                  if (selected === '') {
                      alert("Choose date!!!");
                      e.preventDefault();
                  }
              });
          });
        </script>
       
     <%--<script src="js/jquery-ui.js"></script>--%>
    
  <%--  <script src="js/jquery-ui.js"></script>
    <script src="js/jquery-migrate-1.2.1.min.js"></script>--%>

</html>
