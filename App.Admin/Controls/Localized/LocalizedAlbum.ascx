<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LocalizedAlbum.ascx.cs" Inherits="DynamicData.Admin.Controls.Localized.AlbumItem" %>
<%@ Register Src="LocalizedField.ascx" TagName="LocalizedField" TagPrefix="uc1" %>


<uc1:LocalizedField ID="lfName" FieldName="Name"  
                    runat="server" RequiredLanguage="English" />

<uc1:LocalizedField ID="lfDescription" FieldName="Description" 
                        runat="server"  />

<uc1:LocalizedField ID="lfMetaTitle" FieldName="MetaTitle" 
                    runat="server" RequiredLanguage="English" />

<uc1:LocalizedField ID="lfMetaDescription" FieldName="MetaDescription" 
                    runat="server" RequiredLanguage="English" />
