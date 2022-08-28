<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeBehind="List.aspx.cs" Inherits="DynamicData.Admin.CustomPages.Settings.List" %>

<%@ Register Src="~/DynamicData/Content/GridViewPager.ascx" TagName="GridViewPager" TagPrefix="asp" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="Server">
    <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true">
        <DataControls>
            <asp:DataControlReference ControlID="GridView1" />
        </DataControls>
    </asp:DynamicDataManager>

    <div class="pageheader">
        <div class="media">
            <div class="pageicon pull-left">
                <i class="fa fa-table"></i>
            </div>
            <div class="media-body">
                <ul class="breadcrumb">
                    <li><a href="/"><i class="glyphicon glyphicon-home"></i></a></li>
                    <li><%= table.DisplayName.Humanize2() %></li>
                </ul>
                <h4 class="pull-left"><%= table.DisplayName.Humanize2() %></h4>

            </div>
        </div>
        <!-- media -->
    </div>
    <!-- pageheader -->

    <div class="contentpanel">
        <div runat="server" id="rptFilters" class="row">

            <div class="panel panel-default">
                <div class="panel-body">
                    <asp:QueryableFilterRepeater runat="server" ID="FilterRepeater">
                        <ItemTemplate>
                            <div class="inline-block form-group">
                                <asp:Label CssClass="control-label col-md-4" runat="server" Text='<%# Eval("DisplayName").ToString().Humanize2() %>'
                                    OnPreRender="Label_PreRender" />
                                <span class="col-md-7">
                                    <asp:DynamicFilter runat="server" ID="DynamicFilter" OnFilterChanged="DynamicFilter_FilterChanged" />
                                </span>
                            </div>
                        </ItemTemplate>
                    </asp:QueryableFilterRepeater>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:GridView ID="GridView1" runat="server" DataSourceID="GridDataSource" data-page-length='50'
                        EnablePersistedSelection="true" AllowPaging="false" AllowSorting="false"
                        CssClass="table table-primary mb30 responsive dataTable no-footer" OnRowCreated="GridView1_RowCreated">
                        <Columns>
                            <asp:TemplateField HeaderStyle-CssClass="table-actions" ItemStyle-CssClass="table-action">
                                <ItemTemplate>
                                    <asp:DynamicHyperLink runat="server" Action="Edit">
                                        <i class="fa fa-pencil tooltips" data-toggle="tooltip"
                                        title="Edit"></i> Edit
                                    </asp:DynamicHyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                        <PagerStyle CssClass="DDFooter" />
                        <PagerTemplate>
                            <asp:GridViewPager runat="server" />
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            There are currently no items in this table.
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
                <!-- table-responsive -->
            </div>
        </div>


        <ef:EntityDataSource ID="GridDataSource" runat="server" EnableDelete="true" />

        <asp:QueryExtender TargetControlID="GridDataSource" ID="GridQueryExtender" runat="server">
            <asp:DynamicFilterExpression ControlID="FilterRepeater" />
            <asp:PropertyExpression >
                <asp:Parameter Type="Int32" Name="CategoryId" DefaultValue="2" />
            </asp:PropertyExpression>
        </asp:QueryExtender>

    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="js" runat="Server">
</asp:Content>
