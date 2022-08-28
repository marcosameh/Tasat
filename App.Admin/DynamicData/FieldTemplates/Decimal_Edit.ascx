<%@ Control Language="C#" CodeBehind="Decimal_Edit.ascx.cs" Inherits="DynamicData.Admin.Decimal_EditField" %>

<asp:TextBox ID="TextBox1" runat="server" type="number" CssClass="input-sm form-control" Text='<%# FieldValueEditString %>' Columns="10"></asp:TextBox>

<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" EnableClientScript="true"
    ControlToValidate="TextBox1" Display="None" Enabled="false"  />

<asp:CompareValidator runat="server" ID="CompareValidator1" ControlToValidate="TextBox1"
    Display="None" Operator="DataTypeCheck" Type="Double" 
    EnableClientScript="true" />

<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1"
    ControlToValidate="TextBox1" Display="None" Enabled="false" EnableClientScript="true" />

<asp:RangeValidator runat="server" ID="RangeValidator1" ControlToValidate="TextBox1"
    Type="Double" Enabled="false" EnableClientScript="true" MinimumValue="0" MaximumValue="100" Display="None"
     />

<asp:DynamicValidator runat="server" ID="DynamicValidator1" ControlToValidate="TextBox1"
    Display="None"  EnableClientScript="true" />

