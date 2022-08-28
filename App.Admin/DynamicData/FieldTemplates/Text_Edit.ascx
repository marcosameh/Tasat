<%@ Control Language="C#" CodeBehind="Text_Edit.ascx.cs" Inherits="DynamicData.Admin.Text_EditField" %>

<asp:TextBox ID="TextBox1" runat="server" Text='<%# BrToCRLF(FieldValueEditString) %>' CssClass="form-control input-sm"></asp:TextBox>
<br />

<span runat="server" id="lblHintIcon" class="glyphicon glyphicon-info-sign"></span>
<asp:Label runat="server" ID="lblHint" Visible="false"></asp:Label>

<asp:Label ID="Label1" runat="server" Text='<%# Server.HtmlDecode(FieldValueString) %>'
    Width="100%" Visible="false"></asp:Label>

<asp:RequiredFieldValidator runat="server" ID="rfv1" Text="Required"
    ControlToValidate="TextBox1" Display="None" Enabled="false" EnableClientScript="true"
     ErrorMessage="Required"></asp:RequiredFieldValidator>

<asp:RegularExpressionValidator runat="server" ID="rev1"
    ControlToValidate="TextBox1" Display="None" Enabled="false" EnableClientScript="true"
    ></asp:RegularExpressionValidator>

<asp:DynamicValidator runat="server" ID="dv1" ControlToValidate="TextBox1"
    Display="None"  EnableClientScript="true" Enabled="false" />

<asp:RegularExpressionValidator runat="server" ID="revMax" ControlToValidate="TextBox1" Display="None" Enabled="false"
     EnableClientScript="true"></asp:RegularExpressionValidator>
