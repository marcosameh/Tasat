<%@ Control Language="C#" CodeBehind="Enumeration_Edit.ascx.cs" Inherits="DynamicData.Admin.Enumeration_EditField" %>

<asp:DropDownList ID="DropDownList1" runat="server" CssClass="DDDropDown form-control" />

<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" EnableClientScript="true"
    ControlToValidate="DropDownList1" Display="None" Enabled="false"  />

<asp:DynamicValidator runat="server" ID="DynamicValidator1" EnableClientScript="true"
    ControlToValidate="DropDownList1" Display="None"  />

