<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add_EvalUser.aspx.cs" Inherits="Evaluator_Add_UserInformation" MasterPageFile="StadiumEvalMasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


    <%--<script>
        function RecorerTablaPos(idtabla) {
            var vacio = true;
            var posGuardada = '';
            $('#' + idtabla + ' input[type=checkbox]').each(function () {
                if ($(this).is(':checked')) {
                    vacio = false;
                    var id = $(this).attr('id').split('_');
                    var posActual = id[id.length - 1];
                    if (posGuardada == '' || parseInt(posGuardada) > parseInt(posActual)) posGuardada = posActual;
                }
            });
            if (vacio) posGuardada = '';

            $('#' + idtabla).attr('data-indexpos', posGuardada);
        }

        function AtacharEvento() {
            $('.divChkLst input[type=checkbox]').click(function () {
                var idTabla = $($(this).parent().parent().parent().parent().parent()).attr('id');
                RecorerTablaPos(idTabla)
            });

            $('.divChkLst').mouseenter(function () {
                Agrandar(this, $(this).attr('data-height-max'), $(this).attr('data-indexpos'));
            })
                .mouseleave(function () {
                    Achicar(this, $(this).attr('data-height-min'), $(this).attr('data-indexpos'));
                });
        }

        $(function () {
            AtacharEvento();
        });
    </script>--%>

    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Eval_Stadium.aspx">Home</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">User</a>
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
                            <a class="btn btn-success btn-sm" href="Manage_EvalUsers.aspx"><i class="os-icon os-icon-ui-49"></i><span>&nbsp; View Users </span></a>
                        </div>
                        <h6 class="element-header">الملعب</h6>

                        <div class="element-box">







                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="">
                                            UserName  
                                         <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TextName" ID="RequiredFieldValidator10" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </label>
                                        <asp:TextBox ID="TextUserName" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="">
                                            Name  
                                         <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TextName" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </label>
                                        <asp:TextBox ID="TextName" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="">
                                            CivilID  
                                         <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TextCivilID" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </label>
                                        <asp:TextBox ID="TextCivilID" runat="server" CssClass="form-control" MaxLength="12" AutoComplete="off"></asp:TextBox>
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="">
                                            Mobile  
                                         <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TextPhone" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </label>
                                        <asp:TextBox ID="TextPhone" runat="server" CssClass="form-control" MaxLength="8" AutoComplete="off"></asp:TextBox>
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="">
                                            Email  
                                         <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="TextEmail" ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </label>
                                        <asp:TextBox ID="TextEmail" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="">
                                            Password  
                                         <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="Textpwd" ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </label>
                                        <asp:TextBox ID="Textpwd" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="">
                                            UserType  
                                         <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="DDLUserType" InitialValue="0" ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </label>
                                        <asp:DropDownList ID="DDLUserType" runat="server" CssClass="form-control chzn-select chzn-rtl">
                                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Admin"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="User"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <asp:UpdatePanel ID="updatepannel" runat="server">
                                <ContentTemplate>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="">
                                                    Governorate  
                                         <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="DDLgovernorate" InitialValue="0" ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </label>
                                                <asp:DropDownList ID="DDLGovernorate" runat="server" CssClass=" form-control chzn-select chzn-rtl" AutoPostBack="true" OnSelectedIndexChanged="DDLGovernorate_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="">
                                                    Area  
                                         <asp:RequiredFieldValidator ValidationGroup="MainValidate" CssClass="require" ControlToValidate="DDLArea" InitialValue="0" ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </label>
                                                <asp:DropDownList ID="DDLArea" runat="server" CssClass="form-control chzn-select chzn-rtl" AutoPostBack="true" OnSelectedIndexChanged="DDLArea_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="">
                                                    Stadium  
                                        <asp:CustomValidator ID="customHome" runat="server" ErrorMessage="Required" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationGroup="privilege" ClientValidationFunction="HomecheckBoxValidate"></asp:CustomValidator>
                                                </label>

                                                 <asp:CheckBoxList ID="chkStadium" RepeatDirection="Horizontal"  runat="server">
                                                </asp:CheckBoxList> 
                                               <%-- <asp:ListBox ID="lstEmployee" runat="server" SelectionMode="Multiple">
                                                    <asp:ListItem Text="Nikunj Satasiya" Value="1" />
                                                    <asp:ListItem Text="Dev Karathiya" Value="2" />
                                                    <asp:ListItem Text="Hiren Dobariya" Value="3" />
                                                    <asp:ListItem Text="Vivek Ghadiya" Value="4" />
                                                    <asp:ListItem Text="Pratik Pansuriya" Value="5" />
                                                </asp:ListBox>
                                              --%>


                                                <%--<div id="divEjecutivo" data-height-min="20px" data-indexpos="" class="divChkLst checkBox" data-width-max="400px" > 
                                               
                                                    
                                                <asp:CheckBoxList ID="chkStadium" runat="server">
                                                </asp:CheckBoxList>   </div>--%>

                                                <%--<asp:DropDownList Visible="false" ID="DDLStadium" runat="server" CssClass="form-control chzn-select chzn-rtl"></asp:DropDownList>--%>
                                            </div>
                                        </div>
                                    </div>


                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div class="row" runat="server" id="DivStatus" visible="false">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="">
                                            &nbsp;&nbsp;  
                                        </label>
                                        <asp:CheckBox ID="chkstatus" runat="server" Text="&nbsp;&nbsp;User Status is Active" />
                                    </div>
                                </div>
                            </div>

                            <div class="form-buttons-w">


                                <asp:LinkButton ID="lnkAdd" OnClick="lnkAdd_Click" ValidationGroup="MainValidate" runat="server" CssClass="btn btn-primary"> <i class="os-icon os-icon-ui-22"></i>&nbsp;Add</asp:LinkButton>


                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript">
        function HomecheckBoxValidate(sender, args) {


            var checkBoxList = document.getElementById("<%=chkStadium.ClientID %>");
            var checkboxes = checkBoxList.getElementsByTagName("input");
            alert(checkboxes.length);
            var isValid = false;
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    isValid = true;
                    break;
                    alert("inside");
                }
            }
            args.IsValid = isValid;
        }
    </script>





    <%--<style>
        .checkBox {
            /*margin-top: -53px;  */
            width: 351px; 
            height:auto; 
            overflow: auto; 
            position: absolute; 
            border: 1px solid rgb(205, 210 ,212); 
            background-color: White;
        }
    </style>--%>
</asp:Content>
