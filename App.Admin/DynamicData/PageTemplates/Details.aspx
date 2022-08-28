<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeBehind="Details.aspx.cs" Inherits="DynamicData.Admin.Details" %>


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
                    <li><%= table.DisplayName%></li>
                </ul>
                <h4>Entry from table <%= table.DisplayName%></h4>
            </div>
        </div>
        <!-- media -->
    </div>
    <!-- pageheader -->
    <div class="contentpanel">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="true"
            HeaderText="List of validation errors" CssClass="DDValidator" />
        <asp:DynamicValidator runat="server" ID="DetailsViewValidator" ControlToValidate="FormView1" Display="None" CssClass="DDValidator" />


        <div class="row">
            <div class="table-responsive">
                <asp:FormView runat="server" ID="FormView1"
                    DataSourceID="DetailsDataSource" OnItemDeleted="FormView1_ItemDeleted" RenderOuterTable="false">
                    <ItemTemplate>
                        <table id="detailsTable" class="table table-primary mb30">
                            <asp:DynamicEntity runat="server" />
                            <tr class="td">
                                <td colspan="2">
                                    <asp:DynamicHyperLink runat="server" CssClass="btn btn-primary" Action="Edit" Text="Edit" />
                                    <asp:LinkButton runat="server" CommandName="Delete" Text="Delete" CssClass="btn btn-danger"
                                        OnClientClick='return confirm("Are you sure you want to delete this item?");' />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <div class="DDNoItem">No such item.</div>
                    </EmptyDataTemplate>
                </asp:FormView>
            </div>
            <ef:EntityDataSource ID="DetailsDataSource" runat="server" EnableDelete="true" />

            <asp:QueryExtender TargetControlID="DetailsDataSource" ID="DetailsQueryExtender" runat="server">
                <asp:DynamicRouteExpression />
            </asp:QueryExtender>

            <br />
            <div class="col-md-6">
                <asp:DynamicHyperLink ID="ListHyperLink" CssClass="btn btn-primary-alt" runat="server" Action="List">Show all items</asp:DynamicHyperLink>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="js" runat="Server">
</asp:Content>
