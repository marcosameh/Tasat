<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeBehind="Edit.aspx.cs" Inherits="DynamicData.Admin.Edit" %>

<%@ Register Src="~/Controls/Localized/LocalizedItems.ascx" TagPrefix="uc1" TagName="LocalizedItems" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="Server">
    <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true">
        <DataControls>
            <asp:DataControlReference ControlID="FormView1" />
        </DataControls>
    </asp:DynamicDataManager>

    <div class="pageheader">
        <div class="media">
            <div class="pageicon pull-left">
                <i class="fa fa-home"></i>
            </div>
            <div class="media-body">
                <ul class="breadcrumb">
                    <li><a href="/"><i class="glyphicon glyphicon-home"></i></a></li>
                    <li><%= table.DisplayName.Humanize2()%></li>
                </ul>
                <h4>Edit <%= table.DisplayName.Singularize()%></h4>
            </div>
        </div>
        <!-- media -->
    </div>
    <!-- pageheader -->

    <div class="contentpanel">
        <div class="row">
        <div class="col-md-12">
                <asp:ValidationSummary CssClass="alert alert-danger" runat="server" EnableClientScript="true"
                    ShowValidationErrors="true" ShowSummary="true"  Enabled="true" 
                    DisplayMode="BulletList" />
                <asp:DynamicValidator runat="server" Enabled="true"  ID="DetailsViewValidator" EnableClientScript="true" 
                     ControlToValidate="FormView1" Display="None" />
                <!-- panel -->
            </div>
        </div>

        <asp:FormView runat="server" ID="FormView1" DataSourceID="DetailsDataSource" DefaultMode="Edit"
            OnItemCommand="FormView1_ItemCommand" OnItemUpdated="FormView1_ItemUpdated" RenderOuterTable="false">
            <EditItemTemplate>
                <table id="detailsTable" class="table table-primary mb30">
                    <asp:DynamicEntity runat="server" Mode="Edit" />
                    <tr class="row">
                        <td colspan="3" class="col-md-12">
                            <uc1:LocalizedItems runat="server" ID="LocalizedItems" />
                        </td>
                    </tr>
                    <tr class="row">
                        <td colspan="2" class="text-right">
                            <asp:LinkButton runat="server" CommandName="Cancel" CssClass="btn btn-danger" Text="Cancel" CausesValidation="false" />

                            <asp:LinkButton runat="server" CommandName="Update" ValidationGroup="vgInsert" CssClass="btn btn-success" Text="Update" />
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <div class="DDNoItem">No such item.</div>
            </EmptyDataTemplate>
        </asp:FormView>

        <ef:EntityDataSource ID="DetailsDataSource" runat="server" EnableUpdate="true" OnUpdated="DetailsDataSource_Updated" />

        <asp:QueryExtender TargetControlID="DetailsDataSource" ID="DetailsQueryExtender" runat="server">
            <asp:DynamicRouteExpression />
        </asp:QueryExtender>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="js" runat="Server">
</asp:Content>
