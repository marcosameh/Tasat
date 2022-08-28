<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserRoleSelect.ascx.cs" Inherits="DynamicData.Admin.Controls.UserRoleSelect" %>

<asp:DropDownList  ID="DropDownList1" runat="server" CssClass="DDDropDown form-control"
    SelectMethod="LoadRoles" DataTextField="Text" DataValueField="Value"></asp:DropDownList>

<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" EnableClientScript="true"
    ControlToValidate="DropDownList1" Display="None" Enabled="true"  />