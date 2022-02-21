<%@ Page Title="" Language="C#" MasterPageFile="StadiumCMSMasterPage.master" AutoEventWireup="true" CodeFile="Create_CMSUsers.aspx.cs" Inherits="StadiumCMS_Create_CMSUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        @media (min-width: 767px)
{
.select2-container{min-width:230px !important;}
}
    </style>
 <%--   <script type="text/javascript">
        var config = {
            '.chosen-select': {},
            '.chosen-select-deselect': { allow_single_deselect: true },
            '.chosen-select-no-single': { disable_search_threshold: 10 },
            '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
            '.chosen-select-width': { width: "95%" }
        }


    </script>--%>



   <%-- <script>

        function getMultipleSelectedValue() {
            
            var x = document.getElementById("DDLGovernorate");

            var GovernorateID;
            for (var i = 0; i < x.options.length; i++) {
                if (x.options[i].selected == true) {
                    //alert(x.options[i].value);
                    GovernorateID = GovernorateID + ',' + x.options[i].value;
                }
            }


            GovernorateID = GovernorateID.replace('undefined,', '');

            var DDLArea = $("#DDLArea");

            $("#DDLArea").css({ display: "block" });
            DDLArea.empty();
            //DDLArea.setAttribute("multiple", "multiple");
            //  DDLArea.multiple = true;

            $.ajax({
                type: "POST",
                url: 'Create_CMSUsers.aspx/GetstadiumData',
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                data: JSON.stringify({ "id": GovernorateID, "type": "area" }),

                success: function (r) {
                      alert(r.d.length);

                    $.each(r.d, function () {
                        var newOption = new Option(this['Text'], this['Value'], false, false);
                        $('#DDLArea').append(newOption).trigger('change');

                        //addOption(DDLArea, this['Text'], this['Value']);
                      //  DDLArea.append($("<option><input type='checkbox' id=" + this['Value'] + " value=" + this['Text'] + "></option>").val(this['Value']).html(this['Text']));
                    });


                },
                error: function (error) {
                    console.log(error.d);
                }

            });

        }


    </script>


    <script>
        function getMultipleSelectedAreaValue() {

            var x = document.getElementById("DDLArea");

            var AreaID;
            for (var i = 0; i < x.options.length; i++) {
                if (x.options[i].selected == true) {
                    AreaID = AreaID + ',' + x.options[i].value;
                }
            }


            AreaID = AreaID.replace('undefined,', '');

            var DDLSchool = $("#DDLSchool");
            $("#DDLSchool").css({ display: "block" });
            DDLSchool.empty();
            // DDLSchool.multiple = true;


            $.ajax({
                type: "POST",
                url: 'Create_CMSUsers.aspx/GetstadiumData',
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                data: JSON.stringify({ "id": AreaID, "type": "school" }),

                success: function (r) {
                    //  alert(r.d);

                    $.each(r.d, function () {
                        DDLSchool.append($("<option></option>").val(this['Value']).html(this['Text']));
                    });
                },
                error: function (error) {
                    console.log(error.d);
                }

            });

        }


    </script>


    <script>
        function getMultipleSelectedSchoolValue() {

            var x = document.getElementById("DDLSchool");


            var SchoolID;
            for (var i = 0; i < x.options.length; i++) {
                if (x.options[i].selected == true) {
                    //alert(x.options[i].value);
                    SchoolID = SchoolID + ',' + x.options[i].value;
                }
            }


            SchoolID = SchoolID.replace('undefined,', '');

            var DDLStadium = $("#DDLStadium");
            $("#DDLStadium").css({ display: "block" });

            DDLStadium.empty();
            //  DDLStadium.multiple = true;

            $.ajax({
                type: "POST",
                url: 'Create_CMSUsers.aspx/GetstadiumData',
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                data: JSON.stringify({ "id": SchoolID, "type": "stadium" }),

                success: function (r) {
                    //alert(r.d);

                    $.each(r.d, function () {
                        DDLStadium.append($("<option></option>").val(this['Value']).html(this['Text']));
                    });
                },
                error: function (error) {
                    console.log(error.d);
                }

            });

        }


    </script>--%>


    <style>
        body {
            /*font-family: 'Ubuntu', sans-serif;*/
            font-weight: bold;
        }

        .select2-container {
            min-width: 357px;
        }

        .select2-results__option {
            padding-right: 20px;
            vertical-align: middle;
        }

            .select2-results__option:before {
                content: "";
                display: inline-block;
                position: relative;
                height: 20px;
                width: 20px;
                border: 2px solid #e9e9e9;
                border-radius: 4px;
                background-color: #fff;
                margin-right: 20px;
                vertical-align: middle;
            }

            .select2-results__option[aria-selected=true]:before {
                font-family: fontAwesome;
                content: "\f00c";
                color: #fff;
                background-color: #3d8d27;
                border: 0;
                display: inline-block;
                padding-left: 3px;
            }

        .select2-container--default .select2-results__option[aria-selected=true] {
            background-color: #fff;
        }

        .select2-container--default .select2-results__option--highlighted[aria-selected] {
            background-color: #eaeaeb;
            color: #272727;
        }

        .select2-container--default .select2-selection--multiple {
            margin-bottom: 10px;
        }

        .select2-container--default.select2-container--open.select2-container--below .select2-selection--multiple {
            border-radius: 4px;
        }

        .select2-container--default.select2-container--focus .select2-selection--multiple {
            border-color: #3d8d27;
            border-width: 2px;
        }

        .select2-container--default .select2-selection--multiple {
            border-width: 2px;
        }

        .select2-container--open .select2-dropdown--below {
            border-radius: 6px;
            box-shadow: 0 0 10px rgba(0,0,0,0.5);
        }

        .select2-selection .select2-selection--multiple:after {
            content: 'hhghgh';
        }
        /* select with icons badges single*/
        .select-icon .select2-selection__placeholder .badge {
            display: none;
        }

        .select-icon .placeholder {
            display: none;
        }

        .select-icon .select2-results__option:before,
        .select-icon .select2-results__option[aria-selected=true]:before {
            display: none !important;
            /* content: "" !important; */
        }

        .select-icon .select2-search--dropdown {
            display: none;
        }

        .select2-dropdown {

            border-color:#fff !important;
        }

        .select2-container--default .select2-selection--multiple .select2-selection__clear {
            font-size: 16px;
        }

        .select2-container--default .select2-results__option[aria-selected=true] {
            color:#3E4B5B !important;
        }


    </style>





    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>

    <script src="MultiselectScripts/select.js"></script>

    <script>
        function GovernorateSelect(Id) {
            var arr = Id.split(',');           
            $('#DDLGovernorate').val(arr).trigger('change.select2');           
         
        }
        function AreaSelect(Id) {
           
            var arr = Id.split(',');
            //$('#DDLGovernorate').change();
            $('#DDLArea').val(arr).trigger('change.select2');;
           
        }
        function SchoolSelect(Id) {
            var arr = Id.split(',');           
             $('#DDLSchool').val(arr).trigger('change.select2');         
        }
        function StadiumSelect(Id) {
            var arr = Id.split(',');
            $('#DDLStadium').val(arr).trigger('change.select2');;
           
        }


      
    </script>

  


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">




    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Default.aspx">Home</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">فريق العمل</a>
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
                            <a class="btn btn-success btn-sm" href="Manage_CMSUsers.aspx"><i class="os-icon os-icon-ui-49"></i><span>تعديل فريق العمل</span></a>
                        </div>
                        <h6 class="element-header">فريق العمل</h6>
                        <div class="element-box">


                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="">
                                            الاسم
                                            <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtName" ID="RequiredFieldValidator2" runat="server" ErrorMessage="(يرجى إدخال الاسم)"></asp:RequiredFieldValidator></label><asp:TextBox ID="TxtName" runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="">
                                            اسم المستخدم
                                            <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtUserName" ID="RequiredFieldValidator1" runat="server" ErrorMessage="(يرجى إدخال اسم المستخدم)"></asp:RequiredFieldValidator></label><asp:TextBox ID="TxtUserName" runat="server" CssClass="form-control" placeholder="User Name"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-lg-6 ">
                                    <div class="form-group">
                                        <label for="">
                                            الرقم السري
                                            <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtPassword" ID="RequiredFieldValidator3" runat="server" ErrorMessage="(يرجى إدخال الرقم السري)"></asp:RequiredFieldValidator></label><asp:TextBox ID="TxtPassword" runat="server" CssClass="form-control" placeholder="Password"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput2">
                                            الهاتف  
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="txtreq" ControlToValidate="TxtMobile"
                                                ValidationExpression="\d+" Display="Static" EnableClientScript="true" ErrorMessage="Please enter numbers only"
                                                runat="server" />
                                        </label>
                                        <asp:TextBox ID="TxtMobile" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            البريد الالكتروني  
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Email"
                                                ControlToValidate="TxtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                        </label>
                                        <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput1">
                                            الرقــم المـدني
                                          <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TxtCivilID" ID="RequiredFieldValidator4" runat="server" ErrorMessage="(يرجى إدخال الرقــم المـدني)"></asp:RequiredFieldValidator>
                                        </label>
                                        <asp:TextBox ID="TxtCivilID" runat="server" CssClass="form-control" MaxLength="12"></asp:TextBox>

                                    </div>
                                </div>

                            </div>



                            <div class="row">



                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="projectinput2">
                                            نوع المستخدم 
                                        </label>

                                        <asp:DropDownList CssClass="form-control" ID="DDLUserType" OnSelectedIndexChanged="DDLUserType_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                            <asp:ListItem Value="1">Admin</asp:ListItem>
                                            <asp:ListItem Value="2">Normal User</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <asp:Panel runat="server" ID="pnlLocation" Visible="false">
                                <br />
                                <legend><span>User View&nbsp;</span></legend>

                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="">
                                                المحافظة  
                                          
                                            </label>

                                            <select class="chzn-select chzn-rtl" clientidmode="Static" multiple id="DDLGovernorate"  runat="server">
                                            </select>                                          
                                             <script>


                                                 $("#DDLGovernorate").select2({
                                                     closeOnSelect: false,
                                                     placeholder: "select options",
                                                     allowHtml: true,
                                                     allowClear: true,
                                                     tags: true // создает новые опции на лету
                                                 });


                                                 $('#DDLGovernorate').change(function () {
                                                    // $("[id$=hGov]").val("");
                                                     // alert($('#testddl').find(':selected').val());  //working


                                                     //var optionsText = $("#testddl").find("option[value='5']").val(); //working
                                                     //alert(optionsText);

                                                     //  var selectedID = $("#testddl").select2("val"); // get all the selected values of select2 dropdown,...working
                                                     

                                                     var GovernorateID = $("#DDLGovernorate").select2("val");
                                                     

                                                     $('#DDLArea').empty();
                                                     $('#DDLArea').change();

                                                     $.ajax({
                                                         type: "POST",
                                                         url: 'Create_CMSUsers.aspx/GetstadiumData',
                                                         contentType: "application/json; charset=utf-8",
                                                         dataType: "json",

                                                         data: JSON.stringify({ "id": "" + GovernorateID + "", "type": "area" }),

                                                         success: function (r) {
                                                            
                                                             $.each(r.d, function () {
                                                                
                                                                 var text = this['Text'];
                                                                 var value = this['Value'];
                                                                 
                                                                 var newOption = new Option(text, value, false, false);                                                         
                                                          
                                                                 $('#DDLArea').append(newOption);
                                                             });


                                                         },
                                                         error: function (error) {
                                                             alert("error  " + error.d);
                                                         }

                                                     });


                                                 });

                                                </script>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="">
                                                المنطقة  
                                          
                                            </label>

                                                                                            

                                            <select class="chzn-select chzn-rtl" multiple id="DDLArea"  runat="server" clientidmode="Static">

                                            </select>
                                            <script>


                                                $("#DDLArea").select2({
                                                    closeOnSelect: false,
                                                    placeholder: "select options",
                                                    allowHtml: true,
                                                    allowClear: true,
                                                    tags: true // создает новые опции на лету
                                                });

                                                $('#DDLArea').change(function () {

                                                   
                                                    var AreaID = $("#DDLArea").select2("val");

                                                    $('#DDLSchool').empty();
                                                    $('#DDLSchool').change();

                                                    $.ajax({
                                                        type: "POST",
                                                        url: 'Create_CMSUsers.aspx/GetstadiumData',
                                                        contentType: "application/json; charset=utf-8",
                                                        dataType: "json",

                                                        data: JSON.stringify({ "id": "" + AreaID + "", "type": "school" }),

                                                        success: function (r) {

                                                            $.each(r.d, function () {

                                                                var text = this['Text'];
                                                                var value = this['Value'];

                                                                var newOption = new Option(text, value, false, false);

                                                                $('#DDLSchool').append(newOption);
                                                            });


                                                        },
                                                        error: function (error) {
                                                            alert("error  " + error.d);
                                                        }

                                                    });


                                                });

                                            </script>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="">
                                                School  
                                          
                                            </label>
                                            <br />
                                            <select class="chzn-select chzn-rtl" multiple id="DDLSchool"  runat="server" clientidmode="Static" style="max-width:357px !important;">
                                            </select>

                                             <script>


                                                 $("#DDLSchool").select2({
                                                     closeOnSelect: false,
                                                     placeholder: "select options",
                                                     allowHtml: true,
                                                     allowClear: true,
                                                     tags: true // создает новые опции на лету
                                                 });

                                                 $('#DDLSchool').change(function () {

                                                   
                                                     var SchoolID = $("#DDLSchool").select2("val");

                                                     $('#DDLStadium').empty();

                                                     $.ajax({
                                                         type: "POST",
                                                         url: 'Create_CMSUsers.aspx/GetstadiumData',
                                                         contentType: "application/json; charset=utf-8",
                                                         dataType: "json",

                                                         data: JSON.stringify({ "id": "" + SchoolID + "", "type": "stadium" }),

                                                         success: function (r) {

                                                             $.each(r.d, function () {

                                                                 var text = this['Text'];
                                                                 var value = this['Value'];

                                                                 var newOption = new Option(text, value, false, false);

                                                                 $('#DDLStadium').append(newOption);
                                                             });


                                                         },
                                                         error: function (error) {
                                                             alert("error  " + error.d);
                                                         }

                                                     });


                                                 });

                                            </script>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="">
                                                Stadium  
                                          
                                            </label>
                                            
                                            <select class="chzn-select chzn-rtl" multiple id="DDLStadium"  runat="server" clientidmode="Static" style="max-width:357px !important;">
                                            </select>

                                             <script>


                                                 $("#DDLStadium").select2({
                                                     closeOnSelect: false,
                                                     placeholder: "select options",
                                                     allowHtml: true,
                                                     allowClear: true,
                                                     tags: true // создает новые опции на лету
                                                 });

                                                 
                                            </script>
                                        </div>
                                    </div>


                                </div>
                            </asp:Panel>


                            <br />
                            <legend><span>Menu Access&nbsp;</span></legend>
                            <div class="row">
                                <div class="form-group col-md-2">
                                    <div class="form-group">
                                        <label for="projectinput2">&nbsp;</label>
                                        <asp:CheckBox ID="CH_Users" Text="&nbsp; فريق العمل" CssClass="form-control" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group col-md-2">
                                    <div class="form-group">
                                        <label for="projectinput2">&nbsp;</label>
                                        <asp:CheckBox ID="CH_Settings" Text="&nbsp; الاعدادات" CssClass="form-control" runat="server" />
                                    </div>
                                </div>



                                <div class="form-group col-md-2">
                                    <div class="form-group">
                                        <label for="projectinput2">&nbsp;</label>
                                        <asp:CheckBox ID="CH_Stadium" Text="&nbsp; الملعب" CssClass="form-control" runat="server" />
                                    </div>
                                </div>

                                <div class="form-group col-md-2">
                                    <div class="form-group">
                                        <label for="projectinput2">&nbsp;</label>
                                        <asp:CheckBox ID="CH_Members" Text="&nbsp; Members" CssClass="form-control" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group col-md-2">
                                    <div class="form-group">
                                        <label for="projectinput2">&nbsp;</label>
                                        <asp:CheckBox ID="CH_Pages" Text="&nbsp; Pages" CssClass="form-control" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group col-md-2">
                                    <div class="form-group">
                                        <label for="projectinput2">&nbsp;</label>
                                        <asp:CheckBox ID="CH_Report" Text="&nbsp; Report" CssClass="form-control" runat="server" />
                                    </div>
                                </div>

                                <div class="form-group col-md-2">
                                    <div class="form-group">
                                        <label for="projectinput2">&nbsp;</label>
                                        <asp:CheckBox ID="CH_Banner" Text="&nbsp; Banner" CssClass="form-control" runat="server" />
                                    </div>
                                </div>

                                <div class="form-group col-md-2">
                                    <div class="form-group">
                                        <label for="projectinput2">&nbsp;</label>
                                        <asp:CheckBox ID="CH_DropDowns" Text="&nbsp; DropDowns" CssClass="form-control" runat="server" />
                                    </div>
                                </div>

                                <div class="form-group col-md-2">
                                    <div class="form-group">
                                        <label for="projectinput2">&nbsp;</label>
                                        <asp:CheckBox ID="CH_Booking" Text="&nbsp; Booking" CssClass="form-control" runat="server" />
                                    </div>
                                </div>

                                <div class="form-group col-md-2">
                                    <div class="form-group">
                                        <label for="projectinput2">&nbsp;</label>
                                        <asp:CheckBox ID="CH_Block" Text="&nbsp; StadiumBlocking" CssClass="form-control" runat="server" />
                                    </div>
                                </div>

                                <div class="form-group col-md-2">
                                    <div class="form-group">
                                        <label for="projectinput2">&nbsp;</label>
                                        <asp:CheckBox ID="CH_Contact" Text="&nbsp; Contact" CssClass="form-control" runat="server" />
                                    </div>
                                </div>
                                 <div class="form-group col-md-2">
                                    <div class="form-group">
                                        <label for="CH_Delete">&nbsp;</label>
                                        <asp:CheckBox ID="CH_Delete" Text="&nbsp; Delete" CssClass="form-control" runat="server" />
                                    </div>
                                </div>

                            </div>

                            <legend><span>Button Access&nbsp;</span></legend>
                            <div class="row">

                                <div class="form-group col-md-3">
                                    <div class="form-group">
                                        <label for="projectinput2">&nbsp;</label>
                                        <asp:CheckBox ID="CH_RewiewApprove" Text="&nbsp; Rewiew & Approve" CssClass="form-control" runat="server" />
                                    </div>
                                </div>

                            </div>

                            <div class="form-buttons-w">
                              <asp:HiddenField ID="hGov" runat="server" ClientIDMode="Static"/>
                                 <asp:HiddenField ID="hArea" runat="server" ClientIDMode="Static"/>
                                 <asp:HiddenField ID="hSchool" runat="server" ClientIDMode="Static"/>
                                 <asp:HiddenField ID="hStadium" runat="server" ClientIDMode="Static"/>

                                

                               
                                <asp:LinkButton ID="lnkAdd" OnClick="lnkAdd_Click" ValidationGroup="MainValidate" runat="server" CssClass="btn btn-primary"> <i class="os-icon os-icon-ui-22"></i>&nbsp;Add</asp:LinkButton>

                                <asp:LinkButton ID="lnkCancel" OnClick="lnkCancel_Click" runat="server" CssClass="btn btn-danger mr-1"><i class="fa fa-refresh" aria-hidden="true"></i>&nbsp;Cancel</asp:LinkButton>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        $("[id$=lnkAdd]").click(function () {
            var Gov = $("#DDLGovernorate").select2("val");
            var Area = $("#DDLArea").select2("val");
            var School = $("#DDLSchool").select2("val");
            var Stadium = $("#DDLStadium").select2("val");

            document.getElementById('hGov').value = Gov;
            document.getElementById('hArea').value = Area;
            document.getElementById('hSchool').value = School;
            document.getElementById('hStadium').value = Stadium;

        });
    </script>
</asp:Content>

