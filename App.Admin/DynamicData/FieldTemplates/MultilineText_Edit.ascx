<%@ Control Language="C#" CodeBehind="MultilineText_Edit.ascx.cs" Inherits="DynamicData.Admin.MultilineText_EditField" %>

<asp:TextBox ID="TextBox1" runat="server" CssClass="DDControl form-control" TextMode="MultiLine" Text='<%# FieldValueEditString %>' Columns="80" Rows="5"></asp:TextBox>

<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" EnableClientScript="true"
    ControlToValidate="TextBox1" Display="None" Enabled="false"  />

<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" EnableClientScript="true"
    ControlToValidate="TextBox1" Display="None" Enabled="false"  />

<asp:DynamicValidator runat="server" ID="DynamicValidator1" ControlToValidate="TextBox1"
    Display="None"  EnableClientScript="true" />

