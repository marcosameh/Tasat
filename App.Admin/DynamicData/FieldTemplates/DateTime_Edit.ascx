<%@ Control Language="C#" CodeBehind="DateTime_Edit.ascx.cs" Inherits="DynamicData.Admin.DateTime_EditField" %>


<div class="input-group">
    <asp:TextBox ID="TextBox1" CssClass="form-control hasDatepicker" runat="server" Columns="20"></asp:TextBox>
    <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
</div>
<span runat="server" visible="false" id="lblHintIcon" class="glyphicon glyphicon-info-sign"></span>
<asp:Label ID="lblHint" runat="server" Visible="false"></asp:Label>


<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="TextBox1"
    Display="None" Enabled="false"  EnableClientScript="true" />

<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" EnableClientScript="true"
    ControlToValidate="TextBox1" Display="None" Enabled="false"  />

<asp:DynamicValidator runat="server" ID="DynamicValidator1" ControlToValidate="TextBox1"
    Display="None"  EnableClientScript="true" />

<asp:CustomValidator runat="server" ID="DateValidator" ControlToValidate="TextBox1"
    Display="None" EnableClientScript="true" Enabled="false"
    OnServerValidate="DateValidator_ServerValidate"  />

