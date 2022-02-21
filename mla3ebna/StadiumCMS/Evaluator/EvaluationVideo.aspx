<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EvaluationVideo.aspx.cs" Inherits="Evaluator_EvaluationVideo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


         
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />

    <title></title>


      <script type="text/javascript">

          function showpreview(input) {
              if (input.files && input.files[0]) {
                  var reader = new FileReader();
                 

                      if (input.files[0].size > 10*1048576) {
                          alert("Should not exceed 10MB")
                          $(input).val('');
                      }
                
                  reader.readAsDataURL(input.files[0]);
              }
          }

          


    </script>   
    <style>
        .center-align {

            text-align:center;
            padding:20px;
            border:1px solid #bbc4c1;

        }

        .btn {
            width:200px;
            margin-top:20px;
            padding:10px;
            background-color:#0a422f;
            border-radius:5px;
            color:#fff;
            font-weight:bold;


        }
        .center-align a {
            text-decoration: none;
        }





    </style>


</head>
<body>




    <form id="form1" runat="server">
    <div class="center-align">
<img src="Design/img/upload.png" />
        <br />
        <asp:FileUpload ID="fpuploadvideo" runat="server" onchange="showpreview(fpuploadvideo);" />
        <asp:RequiredFieldValidator ID="Required" runat="server" ControlToValidate="fpuploadvideo" ErrorMessage="Required" SetFocusOnError="true" ValidationGroup="video" ForeColor="Red"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator34" runat="server"
                                                                ErrorMessage="Only .MP4/.MP3 files are allowed." ForeColor="red"
                                                                ValidationExpression="^.*\.(mp4|MP4|mp3|MP3)$"
                                                                ControlToValidate="fpuploadvideo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="video"></asp:RegularExpressionValidator>
                                  <br />                        
        
        <br />
        <asp:LinkButton ID="videoSubmit" runat="server" Text="Submit" ValidationGroup="video" CssClass="btn" OnClick="videoSubmit_Click"></asp:LinkButton>

        <br />


      
      




    </div>
    </form>







</body>
</html>
