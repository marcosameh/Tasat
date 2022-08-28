<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="admin-profile.aspx.cs" Inherits="DynamicData.Admin.admin_profile" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="Server">

    <div class="pageheader">
        <div class="media">
            <div class="media-body">
                <ul class="breadcrumb">
                    <li><a href="/"><i class="glyphicon glyphicon-home"></i></a></li>
                    <li>My Profile</li>
                </ul>
                <h4>Change Password</h4>
            </div>
        </div>
        <!-- media -->
    </div>
    <!-- pageheader -->


    <div class="contentpanel" id="formChangePassword">
        <div class="row">
            <div class="col-md-12">
              <div visible="False" class='custom-alerts alert alert-danger fade in' id="errorConatiner" runat="server">
                        <span runat="server" id="errorMessage">error</span>
                        <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                    </div>

                    <div visible="False" class='custom-alerts alert alert-success fade in' id="successContainer" runat="server">
                        <span runat="server" id="successMessage">Success</span>
                        <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                    </div>                <!-- panel -->
            </div>
        </div>

        <table id="detailsTable" class="table table-primary">
            <tbody>
                <tr class="row">
                    <td class="col-md-2">
                        <label for="txtCurrentPassowrd" class="control-label">Current Password *</label>

                    </td>
                    <td class="col-md-10">
                        <input name="txtCurrentPassword" type="password" maxlength="50" size="50" id="txtCurrentPassword" runat="server" class="form-control input-sm validate[required]" />
                    </td>
                </tr>
                <tr class="row">
                    <td class="col-md-2">
                        <label for="txtNewtPassowrd" class="control-label">New Password *</label>

                    </td>
                    <td class="col-md-10">
                        <input name="txtNewPassword" type="password" maxlength="50" size="50" id="txtNewPassword" runat="server" class="form-control input-sm validate[required]" />
                    </td>
                </tr>
                <tr class="row">
                    <td class="col-md-2">
                        <label for="txtRetypeNewPassowrd" class="control-label">Re-type New Password *</label>

                    </td>
                    <td class="col-md-10">
                        <input name="txtRetypeNewPassword" type="password" maxlength="50" size="50" id="txtRetypeNewPassword" runat="server" class="form-control input-sm validate[required,equals[txtNewPassword]]" />
                    </td>
                </tr>
                <tr class="row">
                    <td colspan="2" class="text-right">
                        <a class="btn btn-danger" href="/">Cancel</a>
                        <asp:Button CssClass="btn btn-success" runat="server" Text="Update" ID="btnUpdate" 
                            OnClientClick=" javascript: return $('#formChangePassword').validateForm(); " OnClick="btnUpdate_Click" />                        
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="js" runat="Server">
</asp:Content>


