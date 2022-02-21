<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View_EvalStadium.aspx.cs" Inherits="Evaluator_View_EvalStadium" MasterPageFile="StadiumEvalMasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="Eval_Stadium.aspx">Home</a>
        </li>
        <li class="breadcrumb-item">
            <a href="#">الملعب</a>
        </li>
        <li class="breadcrumb-item">
            <span>
                <asp:Label ID="labtitle1" runat="server" Text="Details"></asp:Label></span>
        </li>
    </ul>

    <div class="content-i">
        <div class="content-box">
            <div class="row">
                <div class="col-lg-12">
                    <div class="element-wrapper">
                        <div class="element-actions">
                            <div class="element-actions">
                            </div>

                        </div>
                        <h6 class="element-header">Members</h6>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-8">
                    <div class="element-wrapper">
                        <div class="element-box" style="">


                            <h6 class="element-header">Stadium Evaluation Details
                                
                            </h6>

                            <asp:Repeater ID="repeater" runat="server">

                                <ItemTemplate>


                                    <div class="row">
                                        <div class="col-lg-12">
                                            <span class="labdetails">Stadium Name </span>
                                            <asp:Label ID="Labelstadium" runat="server" Text='<%#Eval("StadiumName") %>'></asp:Label>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">
                                        <div class="col-lg-12">
                                            <span class="labdetails">Evaluation By </span>
                                            <asp:Label ID="LabelEvaluationBy" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <span class="labdetails">مدخل الملعب : </span>
                                            <asp:Label ID="LabelEntrance" runat="server" Text='<%#Eval("StadiumEntrance") %>'></asp:Label>
                                        </div>
                                        <div class="col-lg-6">
                                            <span class="labdetails">أرضية الملعب : </span>
                                            <asp:Label ID="LabelField" runat="server" Text='<%#Eval("PlayingField") %>'></asp:Label>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">
                                        <div class="col-lg-6">
                                            <span class="labdetails">تحديد الملعب : </span>
                                            <asp:Label ID="LabelPitch" runat="server" Text='<%#Eval("Pitch") %>'></asp:Label>
                                        </div>
                                        <div class="col-lg-6">
                                            <span class="labdetails">المرمى : </span>
                                            <asp:Label ID="LabelGoal" runat="server" Text='<%#Eval("Goal") %>'></asp:Label>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">

                                        <div class="col-lg-6">
                                            <span class="labdetails">شبك المرمى. : </span>
                                            <asp:Label ID="LabelGoalKick" runat="server" Text='<%#Eval("GoalKick") %>'></asp:Label>
                                        </div>
                                        <div class="col-lg-6">
                                            <span class="labdetails">ماء(برادة): </span>
                                            <asp:Label ID="LabelWater" runat="server" Text='<%#Eval("Water") %>'></asp:Label>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">

                                        <div class="col-lg-6">
                                            <span class="labdetails">كشافات إضاءة : </span>
                                            <asp:Label ID="LabelHeadLight" runat="server" Text='<%#Eval("HeadlampLighting") %>'></asp:Label>
                                        </div>
                                        <div class="col-lg-6">
                                            <span class="labdetails">حمامات </span>
                                            <asp:Label ID="LabelRooms" runat="server" Text='<%#Eval("Rooms") %>'></asp:Label>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">

                                        <div class="col-lg-6">
                                            <span class="labdetails">Note : </span>
                                            <asp:Label ID="LabelNote" runat="server" Text='<%#Eval("Note") %>'></asp:Label>
                                        </div>

                                        <div class="col-lg-6">
                                            <span class="labdetails">Honour : </span>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Honour") %>'></asp:Label>
                                        </div>

                                    </div>

                                    <br />
                                    <div class="row">

                                        <div class="col-lg-6">
                                            <span class="labdetails">Administrator : </span>
                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("DistrictAdministrator") %>'></asp:Label>
                                        </div>
                                        <div class="col-lg-6">
                                            <span class="labdetails">TeamLeader : </span>
                                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("TeamLeader") %>'></asp:Label>
                                        </div>

                                    </div>
                                    <br />


                                </ItemTemplate>
                            </asp:Repeater>

                            <div class="row">

                                <div class="col-lg-6" runat="server" id="DivTRI">
                                    <span class="labdetails">TopRightImage : </span>
                                    <%=StrTopRightFile %>
                                </div>
                                <div class="col-lg-6" runat="server" id="DivTLI">
                                    <span class="labdetails">TopLeftImage </span>
                                    <%=StrTopLeftFile %>
                                </div>
                            </div>


                            <div class="row">

                                <div class="col-lg-6" runat="server" id="DivBRI">
                                    <span class="labdetails">BotomnRightImage : </span>
                                    <%=StrBotomnRightFile %>
                                </div>
                                <div class="col-lg-6" runat="server" id="DivBLI">
                                    <span class="labdetails">BotomnLeftImage </span>
                                    <%=StrBotomnLeftFile %>
                                </div>
                            </div>




                        </div>
                    </div>
                </div>

                <div class="col-lg-4">

                    <div class="property-single">
                        <div class="property-info-w">
                            <div class="property-info-side">

                                <div class="side-section">
                                    <script type="text/javascript">

                                        function openWinPrint(id) {

                                            window.open("Print_EvalStadium.aspx?StadiumEvalID=" + id + '', "_blank", "toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no,width=700,height=650");

                                        }




                                    </script>

                                    <div class="side-section-content">
                                        <div class="property-side-features">

                                            <div class="feature">
                                                <asp:LinkButton ID="lnkDelete" CssClass="" runat="server" OnClick="lnkDelete_Click"><i class="fa fa-trash"></i><span>&nbsp; حذف &nbsp;</span></asp:LinkButton>

                                            </div>


                                            <div class="feature"><%=StrPrintbtn %></div>
                                            <div class="feature">
                                                <a class="" href="Manage_EvalStadium.aspx"><i class="fa fa-arrow-circle-left"></i><span>&nbsp;رجوع &nbsp;</span></a>
                                            </div>
                                            <%-- <div class="feature">
                                                <i class="os-icon os-icon-home-10"></i><span>Washer and Dryer</span>
                                            </div>--%>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
            </div>




        </div>
    </div>
</asp:Content>
