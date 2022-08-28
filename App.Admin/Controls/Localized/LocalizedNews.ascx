<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LocalizedNews.ascx.cs" Inherits="DynamicData.Admin.Controls.Localized.LocalizedNewsItem" %>
<%@ Register Src="LocalizedField.ascx" TagName="LocalizedField" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Localized/LocalizedHtmlField.ascx" TagPrefix="uc1" TagName="LocalizedHtmlField" %>

<uc1:LocalizedField ID="lfTitle" FieldName="Title" 
    runat="server" RequiredLanguage="English" />
<uc1:LocalizedField ID="lfShortDescription" FieldName="ShortDescription" 
    runat="server" RequiredLanguage="English" />

<uc1:LocalizedHtmlField ID="lfBody" FieldName="Body" 
    runat="server" RequiredLanguage="English" />


<uc1:LocalizedField ID="lfMetaTitle" FieldName="Meta Title" 
    runat="server" RequiredLanguage="English" />

<uc1:LocalizedField ID="lfMetaDescription" FieldName="Meta Description" 
    runat="server" RequiredLanguage="English" />


