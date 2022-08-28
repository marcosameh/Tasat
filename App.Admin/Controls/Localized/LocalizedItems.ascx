<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LocalizedItems.ascx.cs" Inherits="DynamicData.Admin.Controls.Localized.LocalizedItems" %>



<%@ Register Src="LocalizedItem.ascx" TagName="LocalizedItem" TagPrefix="uc1" %>

<div class="row" id="divLocItemsContainer">
    <div class="col-md-12">
        <ul class="nav nav-tabs nav-primary">
            <asp:Repeater ID="rptrLanguages" runat="server" DataSourceID="edsLanguages">
                <ItemTemplate>
                    <li <%# Container.ItemIndex == 0 ? "class='active'" : string.Empty %>>
                        <a href="#language<%# Eval("Id") %>" data-toggle="tab">
                            <strong><%# Eval("FriendlyName")%></strong></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>

        <asp:ListView ID="lvControls" runat="server" DataSourceID="edsLanguages">
            <LayoutTemplate>
                <div class="tab-content tab-content-primary mb30">
                    <asp:PlaceHolder runat="server" ID="ItemPlaceHolder"></asp:PlaceHolder>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="tab-pane <%# Container.DataItemIndex == 0 ? "active" : string.Empty %>" id="language<%# Eval("Id") %>">
                    <uc1:LocalizedItem ID="ucLocalizedItem" ItemId="<%# ItemId %>" LanguageId='<%# Eval("Id") %>'
                        LanguageFriendlyName='<%# Eval("FriendlyName")%>' runat="server" />
                </div>
                <div class="clearfix"></div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</div>

<ef:EntityDataSource ID="edsLanguages" Where="it.Active=true" OrderBy="it.FriendlyName" runat="server" Select="it.Id, it.FriendlyName" ConnectionString="name=AdminEntities" DefaultContainerName="AdminEntities" EntitySetName="Languages">
</ef:EntityDataSource>
<script>
    $(document).ready(function () {
        if ($("#language2057").children().length == 0)
            $("#divLocItemsContainer").hide();
    });
</script>
