<%@ Control Language="C#" CodeBehind="Default.ascx.cs" Inherits="DynamicData.Admin.DefaultEntityTemplate" %>

<asp:EntityTemplate runat="server" ID="EntityTemplate1">
    <ItemTemplate>
        <tr class="row">
            <td class="col-md-4">
                <asp:Label runat="server" CssClass="control-label" OnInit="Label_Init" />
            </td>
            <td class="col-md-8">
                <asp:DynamicControl runat="server" OnInit="DynamicControl_Init" />
            </td>
        </tr>
    </ItemTemplate>
</asp:EntityTemplate>

