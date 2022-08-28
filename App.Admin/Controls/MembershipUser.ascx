<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MembershipUser.ascx.cs" Inherits="DynamicData.Admin.Controls.MembershipUser" %>
<%@ Register Src="~/Controls/UserRoleSelect.ascx" TagPrefix="uc1" TagName="UserRoleSelect" %>
<div class="panel panel-default">
    <div class="panel-heading">User Membership</div>
    <div class="panel-body">
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblEmail" runat="server">Email</asp:Label>:
            </div>
            <div class="col-md-10">
                <asp:TextBox ID="txtEmail" CssClass="form-control input-sm" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="Label1" runat="server">Password</asp:Label>:
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtPassword" CssClass="password form-control input-sm" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <button type="button" id="btnGeneratePassword" runat="server" class="btn btn-info" onclick="generatePassword();">Generate Password</button>
            </div>
            <div class="col-md-2">
                <div class="checkbox">
                    <label runat="server" ID="lblSendPasswordByEmail">
                        <asp:CheckBox runat="server" ID="chkSendPasswordByEmail" /> Send By Email</label>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="Label2" runat="server">Active</asp:Label>:
            </div>
            <div class="col-md-10">
                <asp:CheckBox CssClass="" runat="server" ID="chkActive" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="Label3" runat="server">Role</asp:Label>:
            </div>
            <div class="col-md-10">
                <uc1:UserRoleSelect runat="server" ID="ucUserRoleSelect" />
            </div>
        </div>
    </div>
</div>
<script>
    function generatePassword() {
        var url = "https://www.dinopass.com/password/strong";
        var password = '';
        $.ajax({
            url: url,
            type: 'GET',
            dataType: 'text',
            success: function (res) {
                console.log('succes' + res);
                password = res;
                $('.password').val(res);
            },
            error: function (error) {
                console.log('error' + error.responseText);
            }
        });
    };
</script>
