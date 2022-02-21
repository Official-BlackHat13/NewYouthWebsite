<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="Block_Stadium1.aspx.cs" Inherits="Block_Stadium" %>

<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        input[type="radio"], input[type="checkbox"] {
    -webkit-box-sizing: border-box;
    box-sizing: border-box;
    padding: 0px;
    margin: 15px 15px 5px 5px !Important;
}
    </style>
    <link rel="stylesheet" href="Design/Scripts/Calendar/css/jquery-ui.css">
    <script src="Design/Scripts/Calendar/jquery-1.12.4.js"></script>
    <script src="Design/Scripts/Calendar/1.12.1/jquery-ui.js"></script>
    <script>
        $.noConflict();
        jQuery(document).ready(function ($) {
            $('#<%=TxtFromDate.ClientID %>').datepicker({
                changeMonth: true,
                changeYear: true,
                minDate: '+1D',
                onSelect: function (dateStr) {
                    $('#<%=TxtToDate.ClientID %>').datepicker("option", { minDate: new Date(dateStr) })
                }
            });
            $('#<%=TxtToDate.ClientID %>').datepicker({
                changeMonth: true,
                changeYear: true
            });
        });
    </script>
    <script type="text/javascript">
        function CheckBoxValueSelect(source, args) {
            var chkList = document.getElementById('<%= ChkTimeSlot.ClientID %>');
            var chkLista = chkList.getElementsByTagName("input");
            for (var i = 0; i < chkLista.length; i++) {
                if (chkLista[i].checked) {
                    args.IsValid = true;
                    return;
                }
            }
            args.IsValid = false;
        }
    </script>



    
    <script src="js/jquery-1.12.4.js"></script>
    
    <script type="text/javascript">
        $(document).ready(function () {
            
            $("#<%=ChkTimeSlot.ClientID%> input:checkbox:last").change(function () {    
                
                if (this.checked) {                    
                    // $("input[id*='ChkTimeSlot']:checkbox").attr('checked', true);
                    select();
                } else {
                    // $("input[id*='ChkTimeSlot']:checkbox").attr('checked', false);
                    deselect();
                }

            });
        });

        function select() {
            var chkList = document.getElementById('<%= ChkTimeSlot.ClientID %>');
            var chkLista = chkList.getElementsByTagName("input");
            for (var i = 0; i < chkLista.length; i++) {
                chkLista[i].checked = true;                   
                }
            
        }
        function deselect() {
            var chkList = document.getElementById('<%= ChkTimeSlot.ClientID %>');
             var chkLista = chkList.getElementsByTagName("input");
             for (var i = 0; i < chkLista.length; i++) {
                 chkLista[i].checked = false;

             }

         }
    </script>


   
    <script type="text/javascript">
        function CallConfirmBox() {
            var result = "Are you Sure To book ";

            var Governorate = document.getElementById(('<%= DDLGovernorate.ClientID %>'));
            var GovernorateValue = Governorate.options[Governorate.selectedIndex].value;

            if (GovernorateValue != 0) {

                var Area = document.getElementById(('<%= DDLArea.ClientID %>'));
                var AreaValue = Area.options[Area.selectedIndex].value;

                if (AreaValue == "0" && GovernorateValue != "0") {

                    result = result + "all The Stadiums Under Governorate" + Governorate.options[Governorate.selectedIndex].text;
                }
                else {

                    var School = document.getElementById(('<%= DDLSchool.ClientID %>'));
                    var SchoolValue = School.options[School.selectedIndex].value;

                    if (AreaValue != "0" && SchoolValue == "0") {

                        result = result + "all The Stadiums Under Governorate" + Governorate.options[Governorate.selectedIndex].text + ", Area" + Area.options[Area.selectedIndex].text;
                    }
                    else {

                        var Stadium = document.getElementById(('<%= DDLStadium.ClientID %>'));
                        var StadiumValue = Stadium.options[Stadium.selectedIndex].value;

                        if (StadiumValue == "0" && SchoolValue != "0") {
                            result = result + "all The Stadiums Under Governorate" + Governorate.options[Governorate.selectedIndex].text + ", Area" + Area.options[Area.selectedIndex].text + ", School" + School.options[School.selectedIndex].text;
                        }
                        else {

                            var StadiumCourt = document.getElementById(('<%= DDLStadiumCourt.ClientID %>'));
                            var StadiumCourtValue = StadiumCourt.options[StadiumCourt.selectedIndex].value;

                            if (StadiumCourtValue == "0" && StadiumValue != "0") {
                                result = result + "all the Stadiums Under Governorate-" + Governorate.options[Governorate.selectedIndex].text + ", Area-" + Area.options[Area.selectedIndex].text + ", School-" + School.options[School.selectedIndex].text + ",Stadium -" + Stadium.options[Stadium.selectedIndex].text;
                            }
                            else if (StadiumCourtValue != "0" && StadiumValue != "0") {
                                result = result + "Stadiums Under Governorate-" + Governorate.options[Governorate.selectedIndex].text + ", Area-" + Area.options[Area.selectedIndex].text + ", School-" + School.options[School.selectedIndex].text + ",Stadium -" + Stadium.options[Stadium.selectedIndex].text + ",Of Members-" + StadiumCourt.options[StadiumCourt.selectedIndex].text;

                            }
                        }
                    }
                }
            }
            else {
                result = result + "All the Stadiums Under all Governorates!"
            }

            //swal(result);
            if (confirm(result) == true) {
                return true;
            }
            else
                return false;
            
        }
</script>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">Home</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">الملعب</a>
        </li>
        <li class="breadcrumb-item">
            <span>
                <asp:Label ID="labtitle1" runat="server" Text="Manage"></asp:Label></span>
        </li>
    </ul>

    <div class="content-i">
        <div class="content-box">
            <div class="row">
                <div class="col-lg-12">
                    <div class="element-wrapper">
                        <div class="element-actions">
                            <a class="btn btn-success btn-sm" href="Manage_Stadium.aspx"><i class="os-icon os-icon-ui-49"></i><span>&nbsp; تعديل الملعب </span></a>
                        </div>
                        <h6 class="element-header">الملعب</h6>
                        <div class="element-box">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="">
                                            Date From  
                                           <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtFromDate" ID="RequiredFieldValidator1" runat="server" ErrorMessage="(Enter date)"></asp:RequiredFieldValidator>

                                        </label>
                                        <asp:TextBox ID="TxtFromDate" runat="server" AutoComplete="off" CssClass="form-control "></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="">
                                            Date To  
                                          <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtToDate" ID="RequiredFieldValidator2" runat="server" ErrorMessage="(Enter date)"></asp:RequiredFieldValidator>
                                        </label>
                                        <asp:TextBox ID="TxtToDate" runat="server" AutoComplete="off" CssClass="form-control "></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                             <div class="row">
                                  <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="">
                                           BlocK By  
                                          <asp:CustomValidator runat="server" ID="custPermitType" CssClass="require" ControlToValidate="DDLBlockType"
                                                SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                                ErrorMessage="(يرجى إدخال  المحافظة )" />

                                        </label>
                                        <asp:DropDownList CssClass="chzn-select chzn-rtl" OnSelectedIndexChanged="DDLBlockType_SelectedIndexChanged" ID="DDLBlockType" AutoPostBack="true" runat="server">
                                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Block By Governorate"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Block By Area"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Block By School"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="Block By Stadium"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="Block By Court"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="Block By TimeSlot"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="Block By "></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                             </div>


                            <asp:UpdatePanel ID="updatearea" runat="server">
                                <ContentTemplate>


                                    <div class="row">
                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <label for="">
                                                    المحافظة  
                                            <%--<asp:CustomValidator runat="server" ID="custPermitType" CssClass="require" ControlToValidate="DDLGovernorate"
                                                SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckDropDownValueZero"
                                                ErrorMessage="(يرجى إدخال  المحافظة )" />--%>
                                                </label>
                                                <asp:DropDownList CssClass="chzn-select chzn-rtl" OnSelectedIndexChanged="DDLGovernorate_SelectedIndexChanged" ID="DDLGovernorate" AutoPostBack="true" runat="server">
                                                </asp:DropDownList>
                                                <%--<asp:CheckBoxList ID="chkGovernorate" runat="server" RepeatDirection="Horizontal" RepeatColumns="2"></asp:CheckBoxList>--%>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6" runat="server" id="DivArea" visible="false">
                                            <div class="form-group">
                                                <label for="">
                                                    المنطقة  
                                          
                                                </label>
                                                <asp:DropDownList CssClass="chzn-select chzn-rtl" OnSelectedIndexChanged="DDLArea_SelectedIndexChanged" ID="DDLArea" AutoPostBack="true" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6" runat="server" id="DivSchool" visible="false">
                                            <div class="form-group">
                                                <label for="">
                                                    مدرسة  
                                          
                                                </label>
                                                <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLSchool" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DDLSchool_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-md-6" runat="server" visible="false" id="DivStadium">
                                            <div class="form-group">
                                                <label for="">
                                                    Stadium
                                        
                                                </label>
                                                <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLStadium" AutoPostBack="true" runat="server" ClientValidationFunction="CheckDropDownValueZero" OnSelectedIndexChanged="DDLStadium_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6" runat="server" visible="false" id="DivCourt">
                                            <div class="form-group">
                                                <label for="">
                                                    Court Type
                                          
                                                </label>
                                                <asp:DropDownList CssClass="chzn-select chzn-rtl" ID="DDLStadiumCourt" AutoPostBack="false" runat="server" >
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6" runat="server"  id="Div1">
                                            <div class="form-group">
                                                <label for="">
                                                    &nbsp;
                                          
                                                </label>
                                                <asp:Label ID="lblerror" runat="server" ForeColor="Red" ></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                     <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label for="">
                                                    Select TimeSlot  
                                           <asp:CustomValidator runat="server" ID="CustomValidator6" CssClass="require"
                                               SetFocusOnError="true" ValidationGroup="MainValidate" ClientValidationFunction="CheckBoxValueSelect"
                                               ErrorMessage="(Select Time Slot)" />
                                                </label>
                                                <asp:CheckBoxList ID="ChkTimeSlot" CssClass="form-control" runat="server" RepeatDirection="Horizontal" RepeatColumns="5" ValidationGroup="MainValidate"></asp:CheckBoxList>
                                                <asp:HiddenField ID="hdtimeslot" runat="server" />
                                            </div>
                                        </div>
                                    </div>

                                    
                                </ContentTemplate>
                            </asp:UpdatePanel>


                            <%--<asp:UpdatePanel ID="updatetime" runat="server">
                                <ContentTemplate>--%>
                                   
                                <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>


                            <div class="form-buttons-w">


                                <asp:LinkButton ID="lnkAdd" OnClick="lnkAdd_Click" OnClientClick="return CallConfirmBox();" ValidationGroup="MainValidate" runat="server" CssClass="btn btn-primary"> <i class="os-icon os-icon-ui-22"></i>&nbsp;Add</asp:LinkButton>

                                <asp:LinkButton ID="lnkCancel" OnClick="lnkCancel_Click" runat="server" CssClass="btn btn-danger mr-1"><i class="fa fa-refresh" aria-hidden="true"></i>&nbsp;Cancel</asp:LinkButton>

                            </div>



                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

