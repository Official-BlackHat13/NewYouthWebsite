<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListPrintGeneral.aspx.cs" Inherits="MYA2_YPAindividualPrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script type="text/javascript">
      function hidePrint()
      {
      document.getElementById("dvContents").style.display = 'none';
      window.print();
      window.close();
      document.getElementById("dvContents").style.display = "block"; 
      }
     
    </script>
  
</head>

<body">
    <form id="form1" runat="server">
      <div id="dvContents">
           <center>
             <input type="button" id="btn_print" runat="server" value="Print" style="background-color: #4CAF50;font-size: 16px;font-family:'Times New Roman'; border-radius: 12px;padding: 7px 24px;cursor:pointer;" onclick="javascript:hidePrint();"/>
             <asp:Button ID="btn_cancel" runat="server" Text="Cancel"  OnClick="btn_cancel_Click" style="background-color: #f44336;font-size: 16px;font-family:'Times New Roman';border-radius: 12px;padding: 7px 24px;cursor:pointer;"></asp:Button>
              <br />
                </center>
             </div>
        <center>
        <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
              </center>
    </form>
</body>
</html>
