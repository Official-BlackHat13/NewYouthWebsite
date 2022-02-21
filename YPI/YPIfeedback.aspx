<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="YPIfeedback.aspx.cs" Inherits="YPI_YPIfeedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


    <script type="text/javascript" language="javascript">
        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
    </script>

    <%--<link rel="stylesheet" href="css/star-demo.css" />--%>
    <link rel="stylesheet" href="css/star-style.css" />


    <style type="text/css">
        .rating-star-block .star.outline {
            background: url("images/star-empty-lg.png") no-repeat scroll 0 0 rgba(0, 0, 0, 0);
            background-size: 50% 50%;
        }

        .rating-star-block .star.filled {
            background: url("images/star-fill-lg.png") no-repeat scroll 0 0 rgba(0, 0, 0, 0);
            background-size: 50% 50%;
        }

        .rating-star-block .star {
            color: rgba(0,0,0,0);
            display: inline-block;
            height: 54px;
            overflow: hidden;
            text-indent: -999em;
            width: 50px;
        }

        a {
            color: #005782;
            text-decoration: none;
        }

        /*.container-fixed {
            max-height: 800px;
            overflow-y: scroll;
        }*/

        .feedback h5 {
            padding-bottom: 50px;
            border-bottom: 1px solid #ccc;
        }


        ::-webkit-scrollbar-track {
            box-shadow: inset 0 0 5px grey;
            border-radius: 10px;
        }
    </style>


    <style>
        /*tr {
  border-bottom: 1px solid #ddd;
}*/
        .mt {
            margin-top: 75px !important;
        }

        .radio input[type=radio] {
            margin-right: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">


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


    <section>
        <div class="container-fluid">
            <div class="container bg-white text-right">

                <div class="text-center mt-50">
                    <h3>تقييم المبادرين لأداء حاضنات الأعمال لبرنامج المبادر المحترف </h3>

                </div>

                <hr />


                <div class="row" dir="rtl">
                    <div class="col-xs-12 col-md-12">
                        <div class="form-horizontal">

                            <div id="alert" class="alert alert-danger" role="alert" runat="server" visible="false">
                                <p>
                                    <asp:Label ID="lbl1" runat="server"></asp:Label>
                                </p>
                            </div>

                        </div>

                        <div runat="server" id="DivFeedback" visible="true">



                            <div class="feedback py-5">

                                <div class="clear"></div>

                                <h5>الرجاء اختيار التقييم المناسب حيث 5 نجوم يمثل الأفضل و 1 نجمة يمثل الأضعف. </h5>



                                <div class="container-fixed">


                                    <asp:Repeater ID="rpCategory" runat="server" OnItemDataBound="rpCategory_ItemDataBound" OnItemCommand="rpCategory_ItemCommand">
                                        <ItemTemplate>

                                            <asp:Table runat="server" ID="pnl" ClientIDMode="Static">


                                                <asp:TableRow runat="server" ID="tr1">
                                                    <asp:TableCell runat="server" ID="ds">
                                                        <h3><%#Eval("ID") %>.  <%#Eval("CategoryName") %> </h3>
                                                        <asp:HiddenField ID="hiddenID" runat="server" Value='<%#Eval("ID") %>' />

                                                    </asp:TableCell>
                                                </asp:TableRow>

                                                <asp:TableRow runat="server" ID="TableRow2">
                                                    <asp:TableCell runat="server" ID="TableCell2">
                                                        <asp:Repeater ID="rpQuestions" runat="server">
                                                            <ItemTemplate>
                                                                <asp:TableRow runat="server" ID="TableRow1">
                                                                    <asp:TableCell runat="server" ID="TableCell1" class="radio">
                                                                        <p><%#Container.ItemIndex+1 %>. <%#Eval("Question") %>  </p>

                                                                        <asp:HiddenField ID="hiddenQuestionID" runat="server" Value='<%#Eval("QuestionID") %>' />
                                                                        <asp:HiddenField ID="hiddenCategoryID" runat="server" Value='<%#Eval("CategoryID") %>' />


                                                                        <div class="rating-star-block" id='div_<%#Eval("QuestionID") %>'>


                                                                            <a class="star outline" href="#" rating="1" title="vote 1">vote 1</a>
                                                                            <a class="star outline" href="#" rating="2" title="vote 2">vote 2</a>
                                                                            <a class="star outline" href="#" rating="3" title="vote 3">vote 3</a>
                                                                            <a class="star outline" href="#" rating="4" title="vote 4">vote 4</a>
                                                                            <a class="star outline" href="#" rating="5" title="vote 5">vote 5</a>

                                                                            <asp:TextBox ID="txtMark" runat="server" Style="display: none;"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="reqMark" runat="server" ValidationGroup="feedback" CssClass="text-danger" ErrorMessage="required" ControlToValidate="txtMark" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                        </div>


                                                                    </asp:TableCell>
                                                                </asp:TableRow>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </asp:TableCell>
                                                </asp:TableRow>




                                                <asp:TableRow runat="server" ID="TableRow3">
                                                    <asp:TableCell runat="server" ID="TableCell3">
                                                        <p>الملاحظات:</p>

                                                        <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Rows="5" Columns="20" CssClass="form-control"></asp:TextBox>

                                                        <br />
                                                    </asp:TableCell>
                                                </asp:TableRow>

                                                <asp:TableRow runat="server" ID="TableRow4">
                                                    <asp:TableCell runat="server" ID="TableCell4">
                                                        <asp:UpdatePanel ID="update" runat="server">
                                                            <ContentTemplate>

                                                                <asp:LinkButton ID="lnkSubmit" runat="server" CssClass="btn btn-info btn-lg" ValidationGroup='feedback' Text="التالي" CommandName="submit"></asp:LinkButton>

                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </asp:TableCell>
                                                </asp:TableRow>


                                            </asp:Table>








                                        </ItemTemplate>
                                    </asp:Repeater>






                                </div>



                            </div>


                        </div>


                    </div>
                </div>


            </div>
        </div>
    </section>

    <!-- modal-->

    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>

                </div>
                <div class="modal-body">
                    <p class="text-success text-center">Thank you for submitting....</p>
                </div>

            </div>
        </div>
    </div>



    <script type="text/javascript">
        $(document).ready(function () {

            $(".rating-star-block .star").click(function (e) {
                var hoverVal = $(this).attr('rating');

                $("#" + $(this).parent().attr('id') + " .star").each(function () {
                    $(this).addClass("outline");
                    $(this).removeClass("filled");
                });
                $(this).prevUntil().addClass("filled");
                $(this).addClass("filled");

                // $(this).parents('td').eq(0).find('#lblMark').text(hoverVal);
                $(this).parents('td').eq(0).find('input[type=text]').val(hoverVal);
                e.preventDefault();
            });


        });
    </script>

    <script>
        function validate() {
            //var validation = "feedback_" + val;

            if (Page_ClientValidate("feedback") == true) {

                return true;
            }
            return false;
        }


        function modeOpen() {
            $("#myModal").modal('toggle');
            window.location.href = "index.aspx";
        }
    </script>


</asp:Content>

