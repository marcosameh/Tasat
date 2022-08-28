<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Notifier.ascx.cs" Inherits="DynamicData.Admin.Controls.Notifier" %>

<%--<div runat="server" id="mainNotifier" style="display: none;" class="alertContainer">
    <div class="alert alert-<%= Type.ToString().ToLower() %>">
        <button aria-hidden="true" data-dismiss="alert" class="close" type="button">×</button>
        <strong><%= Title %></strong>&nbsp<%= Message %>
    </div>
</div>--%>
<div runat="server" id="mainNotifier" style="display: none;" class="alertContainer">
    <div class="alertContainerTopBrdr">
        <div class="alertContainerBtmBrdr" style="padding:5px;">
            <img id="imgType" alt="alert" runat="server" src="~/images/alerts/success.png" />
            <p runat="server" id="mainNotifierTitle" class="alertTitle">
                Your notifications <span>(5 new) </span>
            </p>
            <a href="javascript:hideNotifier();" class="closeAlert"></a>
            <div runat="server" id="mainNotifierMessage" class="mainNotifierMessage">
                <%--Notification message goes here, can be list items as well <LI></LI>--%>
                Message
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
</div>

<script type="text/javascript">
    function hideNotifier() {
        $("#<%= mainNotifier.ClientID %>").fadeOut("slow");
    }

    function showNotifier(type, title, message) {
        var container = $("#<%= mainNotifier.ClientID %>");
        container.removeClass("error warning");
        switch (type) {
            case "error":
                container.addClass("errorAlert");
                break;

            case "warning":
                container.addClass("warningAlert");
                break;
        }

        $("#<%= mainNotifierTitle.ClientID %>").html(title);
        $("#<%= mainNotifierMessage.ClientID %>").html(message);
        $("#<%= mainNotifier.ClientID %>").fadeIn("slow");
    }
</script>




