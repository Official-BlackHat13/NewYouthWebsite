<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterPage.master" AutoEventWireup="true" CodeFile="Activities-old.aspx.cs" Inherits="Activities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">


    <!-- News Section -->
    <%--<section class="news-section bg-grey margin-top-50">--%>
        <div class="container">
            <div class="title-v1">
                <h2>الأنشطة</h2>
                <p>آخر أنشطة الهيئة العامة للشباب</p>
            </div>
            <div class="row">
                <div class="col-md-12">

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row mt-20">
                        <asp:ListView ID="lstNews" runat="server" ItemPlaceholderID="newsItem" OnPagePropertiesChanging="lstNews_PagePropertiesChanging" >
                            <ItemTemplate>
                                <div class="col-md-4 md-margin-bottom-40">
                                    <div class="news-v1-in">
                                        <a href='ActivityDetails.aspx?id=<%# Eval("ActivityID") %>'>
                                           
                                            <img class="img-responsive" src='Handlers/PhotoHandler.ashx?phptoType=6&id=<%# Eval("ActivityID") %>' alt="" ></a>
                                            <div style="height: 135px">
                                            <h3><a href='ActivityDetails.aspx?id=<%# Eval("ActivityID") %>'><%# Eval("ActivityTitle") %></a></h3>
                                            <p><%# Eval("ActivitySummary") %></p>
                                           </div>
                                        <ul class="list-inline news-v1-info">
                                            <li class="pull-right"><i class="fa fa-clock-o"></i>&nbsp;<%#  Eval("DateFrom","{0:dd/MM/yyyy}") %></li>
                                        </ul>
                                    </div>
                                </div>
                            </ItemTemplate>
                            <LayoutTemplate>
                                <asp:PlaceHolder runat="server" ID="newsItem"></asp:PlaceHolder>
                            </LayoutTemplate>
                        </asp:ListView>
                    </div>
                    <div class="cbp-l-loadMore-button">

                        <asp:DataPager ID="newsPager" runat="server" PagedControlID="lstNews"
                            PageSize="20">
                            <Fields>
                                <asp:TemplatePagerField Visible="true" OnPagerCommand="pager_OnPagerCommand">
                                    <PagerTemplate>
                                        <ul class="pagination" id="pagerItems" runat="server">
                                        </ul>
                                    </PagerTemplate>
                                </asp:TemplatePagerField>

                            </Fields>

                        </asp:DataPager>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
                </div> 
                </div>
        </div>


  <%--  </section>--%>
    <!-- End News Section -->

    <script>
        $(document).ready(function () {
            $('.ActivityI').addClass('active');
        });
    </script>
</asp:Content>

