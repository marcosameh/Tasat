<%@ Control Language="C#" CodeBehind="IconSelect_Edit.ascx.cs" Inherits="DynamicData.Admin.DynamicData.FieldTemplates.IconSelect_EditField" %>

<%--add your cutom icons--%>
<input type="hidden" value="<%# FieldValue %>" runat="server" id="hdnValue" />
<select class="selectpicker" id="ddlIcons" runat="server">
    <%--<optgroup label="Web Application Icons">--%>
    <option value="fa fa-wifi" data-icon="fa fa-wifi">Wifi</option>
    <option value="fa fa-cutlery" data-icon="fa fa-cutlery">Kitchen</option>
    <option value="fa fa-bath" data-icon="fa fa-bath">Bath</option>
    <%--</optgroup>--%>
</select>

<%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="TextBox1" Display="Dynamic" Enabled="false" />
<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ControlToValidate="TextBox1" Display="Dynamic" Enabled="false" />
<asp:DynamicValidator runat="server" ID="DynamicValidator1" ControlToValidate="TextBox1" Display="Dynamic" />--%>
