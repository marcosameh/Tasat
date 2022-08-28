<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LocalizedFaq.ascx.cs" Inherits="DynamicData.Admin.Controls.Localized.LocalizedFaqsItem" %>
<%@ Register Src="LocalizedField.ascx" TagName="LocalizedField" TagPrefix="uc1" %>
<uc1:LocalizedField ID="lfQuestion" FieldName="Question"  
    runat="server" RequiredLanguage="English" />
<uc1:LocalizedField ID="lfAnswer" FieldName="Answer"  
    runat="server" RequiredLanguage="English" />