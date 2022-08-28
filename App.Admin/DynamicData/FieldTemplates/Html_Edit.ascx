<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Html_Edit.ascx.cs" Inherits="DynamicData.Admin.Html_EditField" %>
<asp:TextBox CssClass="summernoteEditor form-control" runat="server" ID="txtHtmlField" Width="800px" TextMode="MultiLine"
    Text='<%# FieldValue %>'></asp:TextBox>
<asp:HiddenField ID="hfImages" runat="server" />

<asp:RequiredFieldValidator runat="server" ID="rfvHtmlField"
    ControlToValidate="txtHtmlField" Display="None" Enabled="false" EnableClientScript="true" 
    />