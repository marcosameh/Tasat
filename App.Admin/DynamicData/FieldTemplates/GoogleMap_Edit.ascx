<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoogleMap_Edit.ascx.cs" Inherits="DynamicData.Admin.GoogleMap_EditField" %>
<div class="mapContainer">
    <div class="row">
        <span class="col-md-6">
            <label class="control-label col-md-2">Address: </label>
            <span class="col-md-8">
                <input id="txtAddress" type="text" class="form-control input-sm txtAddress" placeholder="type address to search for" /></span>
        </span>

        <span class="col-md-6">
            <label class="control-label col-md-2">Zoom Level: </label>
            <span class="col-md-8">
                <asp:TextBox runat="server" ID="txtZoomLevel" disabled Text="8" CssClass="form-control input-sm txtZoomLevel" /></span>
        </span>

    </div>
    <br />
    <div class="row">
        <input type="hidden" id="hidLatitude" runat="server" value="<%# GetLat(FieldValue) %>" class="hidLatitude" />
        <input type="hidden" id="hidLongitude" runat="server" value="<%# GetLng(FieldValue) %>" class="hidLongitude" />
        <span class="col-md-6">
            <label class="control-label col-md-2">Latitude: </label>
            <span class="col-md-8">
                <asp:TextBox runat="server" ID="txtLatitude" CssClass="form-control input-sm txtLatitude"
                    Text="<%# GetLat(FieldValue) %>" /></span>
        </span>
        <span class="col-md-6">
            <label class="control-label col-md-2">Longitude: </label>
            <span class="col-md-8">
                <asp:TextBox runat="server" ID="txtLongitude" CssClass="form-control input-sm txtLongitude"
                    Text="<%# GetLng(FieldValue) %>" /></span>
        </span>
    </div>
    <br />
    <div class="row">
        <span class="col-md-6">
            <input type="button" class="btn btn-sm btn-info col-md-offset-2 btnClear" id="updateMap" value="Update" />
        </span>
    </div>
    <asp:Label runat="server" ID="lblHint" Visible="false"></asp:Label>
    <asp:Label ID="lblCoordinats" runat="server" Text='<%# GetCoordinates(FieldValue) %>'
        Width="100%" Visible="false"></asp:Label>
    <br />
    <div runat="server" class="googleMap" id="map_canvas" style="height: 420px;">
    </div>

    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" EnableClientScript="true"
        ControlToValidate="txtLatitude" Display="None" Enabled="false" />

    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" EnableClientScript="true"
        ControlToValidate="txtLatitude" Display="None" Enabled="false" />

    <asp:DynamicValidator runat="server" ID="DynamicValidator1" CssClass="droplist" ControlToValidate="txtLatitude"
        Display="None" EnableClientScript="true" />

    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&signed_in=true&libraries=places&key=AIzaSyAZtt5BfJwGwPQMKBNxfqnO-R8vMZ4b0Y4"></script>
</div>
