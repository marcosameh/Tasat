<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Youtube.ascx.cs" Inherits="DynamicData.Admin.YoutubeField" %>
<asp:HyperLink ID="HyperLink1" Target="_blank" runat="server" CssClass="youtubeImage">
    <asp:Image ID="Image1" runat="server" />
</asp:HyperLink>
<a class="youtubeImage" style="background-image: url('<%# Utility.GetYoutubeThumbnail("http://www.youtube.com/watch?v="+FieldValueString) %>')" href='<%#"http://www.youtube.com/watch?v="+ FieldValueString %>' rel="prettyPhoto[youtube]">
    <span class="stopped"></span>
</a>