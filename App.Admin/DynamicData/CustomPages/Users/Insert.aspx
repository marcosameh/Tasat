<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeBehind="Insert.aspx.cs" Inherits="DynamicData.Admin.CustomPages.Users.Insert" %>

<%@ Register Src="~/Controls/UserRoleSelect.ascx" TagPrefix="uc1" TagName="UserRoleSelect" %>
<%@ Register Src="~/Controls/MembershipUser.ascx" TagPrefix="uc1" TagName="MembershipUser" %>







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
                    <li><%= table.DisplayName.Humanize2() %></li>
                </ul>
                <h4>Add new <%= table.DisplayName.Singularize() %></h4>
            </div>
        </div>
        <!-- media -->
    </div>
    <!-- pageheader -->

    <div class="contentpanel">
        <div class="row">
            <div class="col-md-12">
                <asp:ValidationSummary CssClass="alert alert-danger" runat="server" EnableClientScript="true"
                    ShowValidationErrors="true" ShowSummary="true" Enabled="true"
                    DisplayMode="BulletList" />
                <asp:DynamicValidator runat="server" Enabled="true" ID="DetailsViewValidator" EnableClientScript="true"
                    ControlToValidate="FormView1" Display="None" />
                <!-- panel -->
            </div>
        </div>


        <asp:FormView runat="server" ID="FormView1" DataSourceID="DetailsDataSource" DefaultMode="Insert"
            OnItemCommand="FormView1_ItemCommand" OnItemInserted="FormView1_ItemInserted" RenderOuterTable="false"
            OnItemInserting="FormView1_ItemInserting">
            <InsertItemTemplate>
                <table id="detailsTable" class="table table-primary mb30">

                    <asp:DynamicEntity runat="server" Mode="Insert" />
                    <tr class="row">
                        <td colspan="3" class="col-md-12">
                            <uc1:MembershipUser runat="server" ID="MembershipUser" />
                        </td>
                    </tr>

                    <tr class="row">
                        <td colspan="2" class="col-md-12 text-right">
                            <asp:LinkButton runat="server" CommandName="Cancel" CssClass="btn btn-danger"
                                Text="Cancel" CausesValidation="false" />

                            <asp:LinkButton runat="server" CommandName="Insert" CssClass="btn btn-success"
                                Text="Add" />
                        </td>
                    </tr>
                </table>
            </InsertItemTemplate>
        </asp:FormView>

        <ef:EntityDataSource ID="DetailsDataSource" runat="server" EnableInsert="true" OnInserted="DetailsDataSource_Inserted" />
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="js" runat="Server">
    <script>

        function generatePassword() {
            var url = "https://www.dinopass.com/password/strong";
            var password = '';
            $.ajax({
                url: url,
                type: 'GET',
                dataType: 'text',
                success: function (res) {
                    console.log('succes' + res);
                    password = res;
                    $('.password').val(res);
                },
                error: function (error) {
                    console.log('error' + error.responseText);
                }
            });
        };
    </script>
</asp:Content>
