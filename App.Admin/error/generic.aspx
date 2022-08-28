<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="generic.aspx.cs" Inherits="DynamicData.Admin.error.generic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">


    <br />
    <br />
    <div class="row">
        <div runat="server" id="mainNotifier" class="alertContainer col-sm-10 col-sm-offset-1">
            <div class="alert alert-danger">
                <button aria-hidden="true" data-dismiss="alert" class="close" type="button">×</button>
                <strong>An Error Occurred: </strong>&nbsp
            <br />
                <asp:Literal runat="server" ID="litErrorMessage"></asp:Literal>

                </di
            </div>

        </div>
    </div>
</asp:Content>
