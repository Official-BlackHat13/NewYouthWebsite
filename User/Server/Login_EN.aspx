<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<html>
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<!-- Glyphicons Font Icons -->
	<!-- Font Icons -->
   
    <link href="../EN/css/font_icon.css" rel="stylesheet" type="text/css" media="all" />
	
        <link rel="shortcut icon" type="image/x-icon" href="../AR/images/favicon.ico">

	<title>Ministry of State for Youth Affairs</title>
    
<!--LOGIN CSS-->
 <style type="text/css">
@font-face {
  
    font-family: "GEDinarOneMedium";
    src: url("../AR/common/theme/font/ge_dinar_one_medium.eot");
    src: url("../AR/common/theme/font/ge_dinar_one_medium.eot") format("embedded-opentype"),
         url("../AR/common/theme/font/ge_dinar_one_medium.woff") format("woff"),
         url("../AR/common/theme/font/ge_dinar_one_medium.ttf") format("truetype"),
         url("../AR/common/theme/font/ge_dinar_one_medium.svg#GEDinarOneMedium") format("svg");
    

}

.glyphicons {
  display: inline-block;
  position: relative;
  padding: 5px 0px 5px 0px;
  color: #fff;
  text-decoration: none;
  *display: inline;
  *zoom: 1;
  font-size:1.1em;
  font-weight:normal;
}
.glyphicons i:before {
  position: relative;
  right: 0;
  top: 0;
  font: 24px/1em 'Glyphicons';
  font-style: normal;
  color: #558094;
}
		 
body { margin:0px; padding:0px; font-family:'tahoma, sans-serif' !important; border-top:solid 10px #6cacc5;}
 img {max-width:100%;
     }
* { margin: 0; padding: 0; }
a { text-decoration:none; font-size:0.9em; font-family:Tahoma,sans-serif!important;}
a:hover { text-shadow:0 0 10px #fff;}
p { margin:10px 0px;}
textarea:focus, input:focus{outline: 0;}
.clear{ clear:both;}
#bg { position: fixed; top: 10px; left: 0; }
header { width:100%; height:130px; position:absolute; z-index:1000; /*background:rgba(252, 252, 252, 0.7);*/
     }
     .logo {
         right: 0px;
         margin-top: 5px;
         height: auto;
         text-align: right;
         padding-right: 53px;
         position: absolute;
         z-index: 10;
         width: 253px;
     }
   
.logo img {
}
.bgwidth { width: 100%; }
.bgheight { height: 100%; }
#page-wrap {
	background: rgba(101, 177, 207, 0.7);
	position: relative;
	width: 640px;
	padding: 0px;
	border: solid 1px #cbcbcb;
	border-radius: 15px;
	text-align: left;
	box-shadow: 0 3px 35px 0 #fff;
	margin-right: auto;
	margin-bottom: 10px;
	margin-left: auto;
	padding: 10px;
	margin-top: 20px;
}
#page-wrap2 { background: rgba(108, 172, 197, 0.7); position:absolute; 
width: 400px; margin:450px 10px 0px 53px; padding:20px 20px;  right:0px; border:solid 2px #cbcbcb; border-radius:15px; text-align:right;
box-shadow:0 3px 35px 0 #fff;}
#page-wrap a { color:#fff; }
#page-wrap h1 { padding:5px 0px; border-bottom:solid 5px #6a98ae; width:100%; font-size:18px; line-height:21px; font-family:Tahoma; 
text-align:center; font-weight:normal; text-shadow:0 0 10px #fff; margin-bottom:5px; color:#fff;}
#page-wrap label {
	font-family:tahoma, sans-serif;
	font-size: 14px;
	display: block;
	margin-top: 5px;
	margin-bottom: 5px;
	color: #fff;
	float: left;
	width: 230px;
	margin-left: 20px;
}
#page-wrap input {
}
input[type="email"], input[type="text"], input[type="password"], input[type="submit"], button[type="submit"] { outline: #f7941e; font-size: 18px; 
font-weight: 300; font-family: tahoma, sans-serif; height:39px;  border-radius: 5px; 
background-color: rgba(255, 255, 255, 0.2); border: 1px solid rgba(255, 255, 255, 0.5); padding: 0; color: #5b5b5b; text-align:left; padding:5px; margin-top:5px; }

input[type="submit"], button[type="submit"] {
	background-color: #fff;
	border-bottom: 5px solid #6CACC5;
	border-right: 1px solid #6CACC5;
	border-top: 1px solid #6CACC5;
	border-left: 1px solid #6CACC5;
	height: 51px;
	width: 100px;
	color: #6cacc5;
	text-align: center;
	vertical-align: middle;
	padding: 0px;
	font-size: 1.3em;
	cursor: pointer;
	margin-top: 18px;
    font-family: 'GEDinarOneMedium', tahoma, sans-serif;
}

input[type="submit"]:hover, button[type="submit"]:hover {
	background-color: #5b5b5b; color:#fff; border-bottom:solid 5px #ccc;
}

::-webkit-input-placeholder { color: white; }

:-moz-placeholder { color: white; opacity: 1; }

::-moz-placeholder { color: white; opacity: 1; }

:-ms-input-placeholder { color: white; }

.btn, .btn-orange{ display: inline-block; height: 49px; line-height: 49px; color: #6cacc5; border: 1px solid white; padding: 0 30px; border-radius: 5px; }

.btn:hover, .btn-orange:hover{ background-color: rgba(255, 255, 255, 0.2); }

.btn-orange { background: #f7941e; border: 1px solid #f7941e; }

.btn-orange:hover { background-color: #e6830d; }

input[type=submit] { }
.links {}
.links ul {}
.links ul li { list-style:none; padding:5px; margin-left:20px;}
btn, .btn-blue{ display: inline-block; height: 27px; line-height: 27px; color: #fff; border: 1px solid white; padding: 0 10px; border-radius: 5px; }

.btn:hover, .btn-blue:hover{ background-color: rgba(255, 255, 255, 0.2); }

.btn-blue { background: #fff; border: 1px solid #3E9CC1; border-bottom:solid 5px #3E9CC1; color:#5aa8c7!important;}

.btn-blue:hover { background-color: #fff; }
.btn:hover {
	background: #82c7e4;
	text-shadow:0 0 10px #fff;
}
.btn:active {
	background: #8dc7cf;
	top: 2px;
}
p { font-family:'GEDinarOneMedium'; font-size:16px; margin: 10px 0 10px 0; text-indent: 40px; }
#content {
margin-top: 172px;
	}
.clear { clear:both;}	
.Slink { background:#6cacc5; padding:5px; float:right; margin-left:20px; border-bottom:solid 5px #5F9AB2; border-radius:5px; color:#fff; margin-right:53px;}
.Slink a { color:#fff; text-align:center; font-size:1.2em;}
.Slink:active { background:#ccc;}
.Slink #login {}
.Slink #login:active {background:#ccc;}
.title {
	font-size: 4em;
	line-height: 53px;
	text-align: center;
	position: absolute;
	z-index: 1000;
	padding: 5px;
	top:200px;
	left:272px;
	color:#fff;
    background:rgba(50, 154, 196, 0.7);
    border-radius:10px;
    padding:35px;
    display:block;
}


     .title_mob { display:none;
     }
 @media (max-width:1280px) {
     .title { top:153px; left:100px; font-size:3em; padding:25px;
     }
}
     @media (max-width:800px) { .title { top:153px; left:100px; font-size:2em; padding:15px;
     }
     }
 @media (max-width:640px) {
     #page-wrap { margin-left:auto; margin-right:auto; position:relative; 
	  margin-bottom:10px; float:none; width:253px; box-shadow:0 0px 15px #B3AEAE; border:solid 5px #fff;
     }
	 #page-wrap label {
	float: none;
	width:inherit;
	margin-left: 0px;
}

     input[type=text], input[type=password] { width:95%; margin-top:5px;
     }
     input[type=submit] { float:none;
     }
     .links { float:none;
     }
     .logo {padding-right:0px; position:relative; margin-left:auto; margin-right:auto; text-align:center; width:153px; 
     }
	 .Slink { margin-right:30px;}
     .title_mob {
	font-size: 1.5em;
	line-height: 21px;
	text-align: center;
	padding: 5px;
	color:#fff;
    background:rgba(50, 154, 196, 0.7);
    border-radius:5px;
    padding:10px;
    width:200px; margin-left:auto; margin-right:auto; position:relative; display:none; margin-top:10px;}
     .title { display:none;
     }
	  #content {margin-top:110px;}
     }
     

 @media (max-width:480px) {
         #page-wrap { width:221px; 
         }
		 #content {margin-top:110px;}

     }

@media (max-width:320px) {
         #page-wrap { width:250px;
         }

     }
 </style>
<!--LOGIN CSS END-->

<!--LOGIN Script-->
	<script src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>



	<script type="text/javascript">
	    var $ = jQuery.noConflict();
	    $(function () {

	        var theWindow = $(window),
			    $bg = $("#bg"),
			    aspectRatio = $bg.width() / $bg.height();

	        function resizeBg() {

	            if ((theWindow.width() / theWindow.height()) < aspectRatio) {
	                $bg
				    	.removeClass()
				    	.addClass('bgheight');
	            } else {
	                $bg
				    	.removeClass()
				    	.addClass('bgwidth');
	            }

	        }

	        theWindow.resize(function () {
	            resizeBg();
	        }).trigger("resize");

	    });
	</script>
    
<!--LOGIN Script END-->
</head>

<body>
<img src="../AR/images/LoginBG.jpg" id="bg" alt="" /> 

     <header>

         <div class="logo">
<!-- border-top:solid 5px #65b7d1; background:#fff;  opacity:0.5;-->
   
<a href="../index_EN.aspx"><img src="../AR/images/logo.png" alt="" / style="border:none;"> </a></div>
         <div class="title_mob">بوابة العمل التطوعي</div>

    </header>
<div id="content">
  <div class="login">
	  <div class="detail">
      
    <!--Volunteers Login-->
<div id="page-wrap">
<h1 class="glyphicons user"><i></i> Login </h1>

	<form runat="server">
    <label>User E-Mail
    
    <asp:TextBox ID="txtEmail" runat="server" Text="" class="radius2" ></asp:TextBox>
          <asp:RequiredFieldValidator ID="emailValidator3" runat="server" SetFocusOnError="true" ForeColor="#cc0000"
                                    ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtEmail" Display="Dynamic"
                                    CssClass="red"
                                    ValidationGroup="inquiryAR"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ForeColor="#cc0000"
                                    ErrorMessage="يرجى كتابة عنوان الإيميل" SetFocusOnError="true"
                                    ControlToValidate="txtEmail" CssClass="red" Display="dynamic"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ValidationGroup="inquiryAR"></asp:RegularExpressionValidator>
    </label>
    
    <label>Password
   
   <asp:TextBox ID="txtPassowrd" runat="server" class="radius2" 
                        TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true" ForeColor="#cc0000"
                                    ErrorMessage="مطلوب هذه الخانة" ControlToValidate="txtPassowrd" Display="Dynamic"
                                    CssClass="red"
                                    ValidationGroup="inquiryAR"></asp:RequiredFieldValidator>

    </label>
    
    <label style="width:100px; margin-left:0px; float:right; ">
     <asp:Button ID="btnUserLogin" runat="server" Text="Login" CssClass="btn" ValidationGroup="inquiryAR" 
                        onclick="btnUserLogin_Clicked"/>
   
   </label>
    </form>
    <div class="clear"></div>
   <div class="links">
   <ul>
       <li><a href="Register_EN.aspx" class="btn-blue" >New Registration </a></li>
    <li><a href="Forgot.aspx"> Forgot Password ?</a></li>
         <li> في حال واجهتك مشكلة في التسجيل يرجى الضغط هنا 

                                                   &nbsp; <a href="../contact_webadmin.aspx" style="color:red;">الدعم الفني</a></li>
   </ul>
	</div>
	
</div>

<div class="clear"></div>
</div></div>

</div>
<div class="clear"></div>

<!--<div class="title">بوابة العمل التطوعي</div>-->


</body>
</html>
