<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LocalizedHomeBanner.ascx.cs" Inherits="DynamicData.Admin.Controls.Localized.BannerItem" %>
<%@ Register Src="LocalizedField.ascx" TagName="LocalizedField" TagPrefix="uc1" %>

<uc1:LocalizedField ID="lfTitle" FieldName="Title" 
                    runat="server" RequiredLanguage="English" />



<uc1:LocalizedField ID="lfSubTitle" FieldName="SubTitle" 
                    runat="server" RequiredLanguage="English" />

<%--<uc1:LocalizedField ID="lfLink" FieldName="Link Text" FieldIsRequired="false" 
                    runat="server" RequiredLanguage="English" />--%>