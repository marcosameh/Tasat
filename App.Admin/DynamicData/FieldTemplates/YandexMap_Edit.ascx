<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YandexMap_Edit.ascx.cs" ClientIDMode="Static" Inherits="DynamicData.Admin.YandexMap_EditField" %>
Address:
<input type="text" id="txtAddress" placeholder="Address" />
<input id="btnFind" type="button" value="Find" />
<br />
Latitude:
<input type="hidden" id="hidLatitude" runat="server" value="<%# GetLat(FieldValue) %>" />
<input type="hidden" id="hidLongitude" runat="server" value="<%# GetLng(FieldValue) %>" />
<asp:TextBox Style="border: none;" runat="server" ID="txtLatitude"
    Text="<%# GetLat(FieldValue) %>" />
Longitude:
<asp:TextBox Style="border: none;" runat="server" ID="txtLongitude"
    Text="<%# GetLng(FieldValue) %>" />
Zoom Level:
<asp:TextBox Style="width: 20px; disabled: disabled; border: none;" runat="server"
    ID="txtZoomLevel" Text="8" />
<br />
<a href="javascript:clear();">Reset</a>
<asp:Label runat="server" ID="lblHint" Visible="false"></asp:Label>
<asp:Label ID="Label1" runat="server" Text='<%# GetCoordinates(FieldValue) %>'
    Width="100%" Visible="false"></asp:Label>
<br />
<div runat="server" id="map" style="width: 600px; height: 420px;"></div>


<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" EnableClientScript="true"
    ControlToValidate="txtLatitude" Display="None" Enabled="false"  />

<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" EnableClientScript="true"
    ControlToValidate="txtLatitude" Display="None" Enabled="false"  />

<asp:DynamicValidator runat="server" ID="DynamicValidator1" EnableClientScript="true" ControlToValidate="txtLatitude"
    Display="None"  />

<script src="http://api-maps.yandex.ru/2.0-stable/?load=package.standard&lang=ru-RU" type="text/javascript"></script>
<script src="/Scripts/yandex-map.js"></script>
<script>

    var txtLat = $("#<%=txtLatitude.ClientID %>");
    var txtLng = $("#<%=txtLongitude.ClientID %>");
    var txtZoom = $("#<%= txtZoomLevel.ClientID %>");
    var hidLatitude = $("#<%= hidLatitude.ClientID %>");
    var hidLongitude = $("#<%= hidLongitude.ClientID %>");

    $(function () {
        var map = new YandexMap();
        map.renderMap('map', parseFloat('<%# GetLat(FieldValue) %>'), parseFloat('<%# GetLng(FieldValue) %>'), 12, true, true, true, true);
        map.createMarker(parseFloat('<%# GetLat(FieldValue) %>'), parseFloat('<%# GetLng(FieldValue) %>'), null, true, null, markerDragged);

        $("#btnFind").bind("click", function () {
            map.geocode($("#txtAddress").val(), false, false, function (coordinates) {
                map.clear();
                markerDragged(coordinates);
                map.createMarker(coordinates[0], coordinates[1], null, true, null, markerDragged);
            });
        })
    })

    function markerDragged(coordinates) {
        //map.map.panTo(coordinates);
        txtLat.val(coordinates[0]);
        txtLng.val(coordinates[1]);
        hidLatitude.val(coordinates[0]);
        hidLongitude.val(coordinates[1]);
    }
</script>
