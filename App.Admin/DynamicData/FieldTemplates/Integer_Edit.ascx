<%@ Control Language="C#" CodeBehind="Integer_Edit.ascx.cs" Inherits="DynamicData.Admin.Integer_EditField" %>

<asp:TextBox ID="TextBox1" runat="server" CssClass="form-control input-sm" Text='<%# FieldValueEditString %>' Columns="10" TextMode="Number"></asp:TextBox>

<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1"
    ControlToValidate="TextBox1" Display="None" Enabled="false" EnableClientScript="true" />

<asp:CompareValidator runat="server" ID="CompareValidator1" ControlToValidate="TextBox1"
    Display="None" Operator="DataTypeCheck" Type="Integer" EnableClientScript="true" />

<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1"
    ControlToValidate="TextBox1" Display="None" Enabled="false" EnableClientScript="true" />

<asp:RangeValidator runat="server" ID="RangeValidator1" ControlToValidate="TextBox1"
    Type="Integer" Enabled="false" EnableClientScript="true" MinimumValue="0" MaximumValue="100" Display="None" />

<asp:DynamicValidator runat="server" ID="DynamicValidator1" ControlToValidate="TextBox1"
    Display="None" EnableClientScript="true" />

