<%@ Page Title="Login" Language="C#" AutoEventWireup="true" CodeBehind="reset-password.aspx.cs" Inherits="DynamicData.Admin.reset_password" %>

<%@ Register Src="~/Controls/Notifier.ascx" TagPrefix="uc1" TagName="Notifier" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Area: Login Page</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <meta name="author" content="Innovix Solutions" />
    <link href="/content/style.default.css" rel="stylesheet" />
    <script src="/scripts/vendors/jquery-2.1.3.min.js"></script>
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
        <script src="/scripts/vendors/html5shiv.js"></script>
        <script src="/scripts/vendors//respond.min.js"></script>
        <![endif]-->
</head>
<body class="signin">
    <form id="form1" runat="server">

        <section>

            <div class="panel panel-signin">
                <div class="panel-body">
                    <div class="logo text-center">
                        <img src="/images/logo-primary.png" />
                    </div>
                    <br />
                    <h4 class="text-center mb5">Welcome</h4>
                    <p class="text-center">Reset Your Password</p>

                    <asp:ValidationSummary CssClass="alert alert-danger" runat="server" EnableClientScript="true" ShowValidationErrors="true"
                        ShowSummary="true" Enabled="true" DisplayMode="BulletList" />

                    <div class="mb30">
                    </div>

                    <div runat="server" id="divResetForm">
                        <div class="input-group mb15">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                            <input type="text" name="user" class="form-control" placeholder="Email" runat="server" id="txtEmail" />
                            <asp:RequiredFieldValidator EnableClientScript="true" ID="rfvUserName"
                                ForeColor="red" runat="server" ErrorMessage="User name is required!"
                                ControlToValidate="txtEmail" Display="None" CssClass="input-group-addon"></asp:RequiredFieldValidator>
                        </div>

                        <div class="clearfix">
                            <div class="pull-right">
                                <asp:Button runat="server" class="btn btn-fullcolor" Text="Reset Password"
                                    ID="btnRequestResetLink" OnClick="btnRequestResetLink_OnClick" />
                            </div>
                        </div>
                    </div>


                    <div runat="server" id="divNewPassword">
                        <div class="input-group mb15">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                            <input type="password" class="form-control" placeholder="Password" runat="server" id="password" />
                            <asp:RequiredFieldValidator EnableClientScript="true" ID="RequiredFieldValidator1"
                                ForeColor="red" runat="server" ErrorMessage="Password is required!"
                                ControlToValidate="password" Display="None" CssClass="input-group-addon"></asp:RequiredFieldValidator>
                        </div>
                        <!-- input-group -->
                        <div class="input-group mb15">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                            <input type="password" class="form-control" placeholder="Confirm Password" runat="server" id="confirm_password" />
                            <asp:RequiredFieldValidator CssClass="input-group-addon"
                                ID="rfvPassword" ForeColor="red" runat="server"
                                ErrorMessage="Password is required!" Display="None" ControlToValidate="confirm_password"></asp:RequiredFieldValidator>

                        </div>


                        <div class="clearfix">
                            <div class="pull-right">
                                <asp:Button runat="server" class="btn btn-fullcolor" Text="Reset Password"
                                    OnClientClick="javascript: return  $('#divNewPassword').validateForm();"
                                    ID="btnReset" OnClick="btnReset_OnClick" />
                            </div>
                        </div>
                    </div>
                    
                    <asp:CustomValidator ID="cvLoginFailed" runat="server" Visible="false"
                        ForeColor="Red" ></asp:CustomValidator>
                    <uc1:Notifier runat="server" ID="ucNotifier" />
                </div>
                <!-- panel-body -->

                <div class="panel-footer text-center">
                    Powered by <a href="http://innovixsolutions.com" target="_blank">Innovix Solutions</a>
                </div>
                <!-- panel-footer -->
            </div>
            <!-- panel -->

        </section>
        <asp:PlaceHolder runat="server">
            <%: Scripts.Render("~/bundles/masterJs/") %>
        </asp:PlaceHolder>
    </form>
</body>
</html>
<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Website Admin Area</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <meta name="author" content="Innovix Solutions" />
    <asp:PlaceHolder runat="server">
        <%: Styles.Render("~/bundles/masterCss/") %>
    </asp:PlaceHolder>
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
        <header>
            <div class="headerwrapper">
                <div class="header-left">
                    <a href="/" class="logo">
                        <img src="/images/logo.png" alt="" />
                    </a>
                    <div class="pull-right">
                        <a href="" class="menu-collapse">
                            <i class="fa fa-bars"></i>
                        </a>
                    </div>
                </div>
                <!-- header-left -->


            </div>
            <!-- headerwrapper -->
        </header>
        <section>
            <div class="mainwrapper">
                <div class="mainpanel">
                    <!-- BEGIN CONTENT WRAPPER -->
                    <div class="content">
                        <div class="container">
                            <div class="row">
                                <!-- Request Password reset -->
                                <div class="main col-sm-12">

                                    <div runat="server" class="login col-sm-5 col-sm-offset-1 validationEngineContainer" id="divResetForm">
                                        <h1 class="center">
                                            <asp:Localize Text="Reset Password" runat="server" ID="locResetPasswordHeader"></asp:Localize></h1>
                                        <div class="col-sm-12">
                                            <div class="form-style">
                                                <div class="validationEngineContainer" id="divRequestResetForm">
                                                    <input id="txtEmail" runat="server" type="text" name="Email" placeholder="Email Address" class="form-control validate[required,custom[email]]" />
                                                    <asp:Button runat="server" class="btn btn-fullcolor" Text="Reset Password"
                                                        OnClientClick="javascript: return  $('#divResetForm').validateForm();"
                                                        ID="btnRequestResetLink" OnClick="btnRequestResetLink_OnClick" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <!-- Actual Password Reset -->
                                <div runat="server" class="main col-sm-12 validationEngineContainer" id="divNewPassword">

                                    <div class="login col-sm-5 col-sm-offset-1">
                                        <h1 class="center">
                                            <asp:Localize Text="Reset Password" runat="server" ID="Localize1"></asp:Localize></h1>
                                        <div class="col-sm-12">
                                            <div class="form-style">
                                                <div>
                                                    <input type="password" runat="server" id="password" name="Password" placeholder="Password*" class="form-control validate[required,minSize[6]]" />
                                                    <input type="password" id="confirm_password" name="confirm_password" placeholder="Confirm Password*" class="form-control validate[required,equals[password]]" />

                                                    <asp:Button runat="server" class="btn btn-fullcolor" Text="Reset Password"
                                                        OnClientClick="javascript: return  $('#divNewPassword').validateForm();"
                                                        ID="btnReset" OnClick="btnReset_OnClick" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- END MAIN CONTENT -->

                            </div>
                        </div>
                    </div>
                    <!-- END CONTENT WRAPPER -->
                </div>
                <!-- contentpanel -->

            </div>
            <!-- mainwrapper -->
        </section>
    </form>
</body>
</html>--%>


