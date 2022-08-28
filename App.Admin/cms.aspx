<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="cms.aspx.cs" Inherits="DynamicData.Admin.cms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/content/bootstrap-2.css" rel="stylesheet" />
    <link rel="stylesheet" href="/content/plugins/editable/bootstrap-editable.css" type="text/css" />
    <link rel="stylesheet" href="/content/plugins/bootstrap-wysihtml5-0.0.2.css" type="text/css" />
    <link rel="stylesheet" href="/content/plugins/wysiwyg-color.css" type="text/css" />
    <style>
        .icon-list {
            margin-bottom: 0 !important;
        }

        ul.wysihtml5-toolbar li:last-of-type {
            display: none; /* hide insert image*/
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="pageheader">
        <div class="media">
            <div class="pageicon pull-left">
                <i class="fa fa-table"></i>
            </div>
            <div class="media-body">
                <ul class="breadcrumb">
                    <li><a href="/"><i class="glyphicon glyphicon-home"></i></a></li>
                    <li>Content Managment</li>
                </ul>
                <h4>Content Managment</h4>
            </div>
        </div>
        <!-- media -->
    </div>
    <!-- pageheader -->

    <div class="contentpanel">
        <div class="row">
            <div class="col-md-3">
                <div id="tree" class="tree-view">
                    <ul>
                        <asp:ListView runat="server" ItemType="DynamicData.Admin.TreeNode" ID="lvTree" SelectMethod="lvTree_GetData">
                            <ItemTemplate>
                                <li data-jstree='{ "type" : "<%# Item.Type.ToString().ToLower() %>","opened" : true }'><a href="<%# Item.Link %>"><%# Item.Name %></a>
                                    <asp:ListView runat="server" ItemType="DynamicData.Admin.TreeNode" DataSource="<%# Item.Children %>">
                                        <LayoutTemplate>
                                            <ul>
                                                <asp:PlaceHolder runat="server" ID="ItemPlaceHolder" />
                                            </ul>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <li data-jstree='{ "type" : "<%# Item.Type.ToString().ToLower() %>" }'><a href="<%# Item.Link %>"><%# Item.Name %></a>
                                                <asp:ListView runat="server" ItemType="DynamicData.Admin.TreeNode" DataSource="<%# Item.Children %>">
                                                    <LayoutTemplate>
                                                        <ul>
                                                            <asp:PlaceHolder runat="server" ID="ItemPlaceHolder" />
                                                        </ul>
                                                    </LayoutTemplate>
                                                    <ItemTemplate>
                                                        <li data-jstree='{ "type" : "<%# Item.Type.ToString().ToLower() %>" }'><a href="<%# Item.Link %>"><%# Item.Name %></a>
                                                            <asp:ListView runat="server" ItemType="DynamicData.Admin.TreeNode" DataSource="<%# Item.Children %>">
                                                                <LayoutTemplate>
                                                                    <ul>
                                                                        <asp:PlaceHolder runat="server" ID="ItemPlaceHolder" />
                                                                    </ul>
                                                                </LayoutTemplate>
                                                                <ItemTemplate>
                                                                    <li data-jstree='{ "type" : "<%# Item.Type.ToString().ToLower() %>" }'><a href="<%# Item.Link %>"><%# Item.Name %></a></li>
                                                                </ItemTemplate>
                                                            </asp:ListView>
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                            </li>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </li>
                            </ItemTemplate>
                        </asp:ListView>
                    </ul>

                </div>
            </div>
            <div class="col-md-9">
                <h4 runat="server" class="pageName" id="hCurrentFileName"></h4>
                <!-- Nav tabs -->
                <ul class="nav nav-tabs nav-justified nav-metro">
                    <asp:ListView ID="lvLanguageTabs" runat="server"
                        SelectMethod="GetLanguages">
                        <ItemTemplate>
                            <li class="<%# Container.DataItemIndex == 0 ? "active":"" %>">
                                <a href="#lng<%# Eval("Key.Id")  %>" data-toggle="tab"><strong><%# Eval("Key.FriendlyName") %></strong></a>
                            </li>
                        </ItemTemplate>
                    </asp:ListView>


                </ul>

                <!-- Tab panes -->
                <div class="tab-content tab-content-metro mb30">
                    <asp:ListView runat="server" SelectMethod="GetLanguages">
                        <ItemTemplate>
                            <!-- tab-pane -->
                            <div class="tab-pane <%# Container.DataItemIndex ==0 ? "active" :"" %>"
                                id="lng<%# Eval("Key.Id") %>">
                                <table class="table table-primary mb30 table-hover table-striped">
                                    <thead>
                                        <tr>
                                            <th>Key
                                            </th>
                                            <th>Value
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:ListView runat="server" DataSource='<%# Eval("Value") %>'>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Eval("Key") %></td>
                                                    <td>
                                                        <a class="editable" data-type="<%# GetXEditMode((string)Eval("Value.Value"), (string)Eval("Value.Hint")) %>"
                                                            data-file-path=" <%# Eval("Value.FilePath") %>" data-key=" <%# Eval("Value.Key") %>"><%# GetValue((string)Eval("Value.Value"), (string)Eval("Value.Hint"))%></a></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:ListView>
                                    </tbody>
                                </table>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                    <div runat="server" id="divNoData" class="text-center">
                        <span class="glyphicon glyphicon-info-sign"></span>
                        Please Select a Page from Left Tree to Update It's Content
                    </div>
                </div>
                <!-- tab-content -->

            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="js" runat="server">
    <script src="/scripts/plugins/bootstrap-editable.min.js"></script>
    <script src="/scripts/plugins/wysihtml5-0.3.0.min.js"></script>
    <script src="/scripts/plugins/bootstrap-wysihtml5-0.0.2.min.js"></script>
    <script src="/scripts/plugins/wysihtml5.js"></script>
    <script src="/Scripts/plugins/jstree.min.js"></script>

    <script>
        $(function () {
            app.initTreeView();
            app.initXEditable("/api/cms/update", function (e, params) {
                if (params.response.length > 0) {
                    var oldValue = $(e.target).text();
                    alert(params.response);
                    $(e.target).editabel().setValue(oldValue);
                }
            });

            //Collapse side menu
            $(".mainwrapper").add(".headerwrapper").addClass("collapsed");
        })
    </script>
</asp:Content>
