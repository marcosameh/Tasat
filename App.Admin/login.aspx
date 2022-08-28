<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DynamicData.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Area: Login Page</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <meta name="author" content="Innovix Solutions" />
    <link href="Content/bundle.min.css" rel="stylesheet" />
    
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
                    <p class="text-center">Sign in to your account</p>

                    <asp:ValidationSummary CssClass="alert alert-danger" runat="server" EnableClientScript="true" ShowValidationErrors="true"
                        ShowSummary="true" Enabled="true" DisplayMode="BulletList" />

                    <div class="mb30">
                    </div>

                    <div>
                        <div class="input-group mb15">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                            <input type="text" name="user" class="form-control" placeholder="Email" runat="server" id="UserName" />
                            <asp:RequiredFieldValidator EnableClientScript="true" ID="rfvUserName"
                                ForeColor="red" runat="server" ErrorMessage="User name is required!"
                                ControlToValidate="UserName" Display="None" CssClass="input-group-addon"></asp:RequiredFieldValidator>
                        </div>
                        <!-- input-group -->
                        <div class="input-group mb15">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                            <input type="password" class="form-control" placeholder="Password" runat="server" id="Password" />

                            <asp:RequiredFieldValidator CssClass="input-group-addon"
                                ID="rfvPassword" ForeColor="red" runat="server"
                                ErrorMessage="Password is required!" Display="None" ControlToValidate="Password"></asp:RequiredFieldValidator>

                        </div>

                        <a href="/reset-password.aspx">
                            <asp:Localize Text="Forgot your password?" runat="server" ID="locForgetPasswordLink"></asp:Localize></a>
                        <!-- input-group -->

                        <div class="clearfix">
                            <div class="pull-left">
                                <div class="ckbox ckbox-primary mt10">
                                    <input type="checkbox" id="rememberMe" value="1" runat="server" />
                                    <label for="rememberMe">Remember Me</label>
                                </div>

                            </div>
                            <div class="pull-right">
                                <asp:Button Text="login" CssClass="btn btn-info btn-lg"
                                    runat="server" ID="btnAuthenticate" OnClick="btnAuthenticate_Click" />
                            </div>
                        </div>
                    </div>
                    <asp:CustomValidator ID="cvLoginFailed" runat="server" Visible="false"
                        ForeColor="Red" ErrorMessage="Incorrect Username or Password"></asp:CustomValidator>
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
        
            <script src="/scripts/vendors/jquery-2.1.3.min.js"></script>
            <script src="Content/bundle.min.js"></script>
        </asp:PlaceHolder>
    </form>
</body>
</html>
