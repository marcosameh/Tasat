<%@ Control Language="C#" CodeBehind="ManyToMany.ascx.cs" Inherits="DynamicData.Admin.ManyToManyField" %>

<asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
      <asp:DynamicHyperLink runat="server"></asp:DynamicHyperLink>
    </ItemTemplate>
    <SeparatorTemplate>,&nbsp;</SeparatorTemplate>
</asp:Repeater>

