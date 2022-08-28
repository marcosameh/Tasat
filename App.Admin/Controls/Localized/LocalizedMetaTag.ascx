<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LocalizedMetaTag.ascx.cs" 
    Inherits="DynamicData.Admin.Controls.Localized.LocalizedMetaTag" %>
<%@ Register Src="~/Controls/Localized/LocalizedField.ascx" TagPrefix="uc1" TagName="LocalizedField" %>

<uc1:LocalizedField ID="lfMetaTitle" FieldName="MetaTitle" DisplayName="Meta Title" 
    runat="server" />
<uc1:LocalizedField ID="lfMetaDescription" FieldName="MetaDescription" DisplayName="Meta Description" 
    runat="server" />
<uc1:LocalizedField ID="lfMetaKeywords" FieldName="MetaKeywords" DisplayName="Meta Keywords"  
    runat="server" />   

