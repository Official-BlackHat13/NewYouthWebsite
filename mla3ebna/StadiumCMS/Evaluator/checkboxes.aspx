<%@ Page Title="" Language="C#"  AutoEventWireup="true" MasterPageFile="StadiumEvalMasterPage.master" CodeFile="checkboxes.aspx.cs" Inherits="Evaluator_checkboxes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script src="http://code.jquery.com/jquery-1.12.4.min.js"></script>  
<link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"  
rel="stylesheet" type="text/css" />  
<script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"></script>  
<link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css"  
rel="stylesheet" type="text/css" />  
<script src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>  


    <script type="text/javascript">
        $(function () {
            $('[id*=lstEmployee]').multiselect({
                includeSelectAllOption: true
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


      
     
   Employee : <asp:ListBox ID="lstEmployee" runat="server" SelectionMode="Multiple">  
        <asp:ListItem Text="Nikunj Satasiya" Value="1" />  
        <asp:ListItem Text="Dev Karathiya" Value="2" />  
        <asp:ListItem Text="Hiren Dobariya" Value="3" />  
        <asp:ListItem Text="Vivek Ghadiya" Value="4" />  
        <asp:ListItem Text="Pratik Pansuriya" Value="5" />  
    </asp:ListBox>  
    <asp:Button ID="Button1" Text="Submit" runat="server" />  
</asp:Content>

