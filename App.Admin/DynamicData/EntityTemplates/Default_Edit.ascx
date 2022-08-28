<%@ Control Language="C#" CodeBehind="Default_Edit.ascx.cs" Inherits="DynamicData.Admin.Default_EditEntityTemplate" %>

<%@ Reference Control="~/DynamicData/EntityTemplates/Default.ascx" %>
<asp:EntityTemplate runat="server" ID="EntityTemplate1">
    <ItemTemplate>
        <tr class="row">
            <td class="col-md-2">
                <asp:Label runat="server" OnInit="Label_Init" CssClass="control-label" OnPreRender="Label_PreRender" />
                    </strong>
            </td>
            <td class="col-md-10">
                <asp:DynamicControl runat="server" ID="DynamicControl" Mode="Edit" OnInit="DynamicControl_Init" />
            </td>
        </tr>
    </ItemTemplate>
</asp:EntityTemplate>

