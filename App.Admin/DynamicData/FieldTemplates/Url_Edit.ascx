<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="Url_Edit.ascx.cs" Inherits="DynamicData.Admin.Url_EditField" %>


<asp:TextBox ID="TextBox1" runat="server" CssClass="form-control input-sm" Text='<%# FieldValueEditString %>' Columns="10" TextMode="Url"></asp:TextBox>


<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" EnableClientScript="true"
    ControlToValidate="TextBox1" Display="None" Enabled="false" />

<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" EnableClientScript="true" 
    ControlToValidate="TextBox1" Display="None" Enabled="false" />

<asp:DynamicValidator runat="server" ID="DynamicValidator1" EnableClientScript="true"
     ControlToValidate="TextBox1" Display="None"  />

