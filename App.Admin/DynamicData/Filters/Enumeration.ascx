<%@ Control Language="C#" CodeBehind="Enumeration.ascx.cs" Inherits="DynamicData.Admin.EnumerationFilter" %>

<asp:DropDownList runat="server" ID="ddlEnum" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
  <asp:ListItem Text="All" Value="" />
</asp:DropDownList>

