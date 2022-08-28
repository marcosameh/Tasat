<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="File_Edit.ascx.cs" Inherits="TravelRedSea.Admin.File_EditField" %>


<asp:HyperLink ID="HyperLink1"  Visible="false" Target="_blank" runat="server"><%# FieldValueString %></asp:HyperLink>

<input type="button" Visible="False" runat="server" id="btnRemoveFile" onclick="RemoveFile();" value="Remove File" />
<asp:FileUpload ID="FileUpload1" runat="server" />
<br />
<asp:Label runat="server" ID="lblHint" Visible="false"></asp:Label>

<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1"
    ControlToValidate="FileUpload1" Display="None" Enabled="false"
    EnableClientScript="true" />

<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1"
    ControlToValidate="FileUpload1" Display="None" Enabled="false"
    EnableClientScript="true" />

<asp:DynamicValidator runat="server" ID="DynamicValidator1" ControlToValidate="FileUpload1"
    Display="None" EnableClientScript="true" />

<asp:HiddenField runat="server" ID="hdfFileName" Value=""  />

<script>
    function RemoveFile() {
        var filePath = '<%# HyperLink1.NavigateUrl %>';
        
        $("#<%= hdfFileName.ClientID %>").val(filePath);
        $("#<%= btnRemoveFile.ClientID %>").hide();
        $("#<%= HyperLink1.ClientID %>").hide();
    }
</script>
