<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="unauthorized.aspx.cs" 
    Inherits="DynamicData.Admin.unauthorized"
    MasterPageFile="~/Site.master" %>


<asp:Content ContentPlaceHolderID="head" ID="Content1" runat="server">

    <!-- Google font -->
	<link href="https://fonts.googleapis.com/css?family=Montserrat:500" rel="stylesheet" />
	<link href="https://fonts.googleapis.com/css?family=Titillium+Web:700,900" rel="stylesheet" />


    <style>
        #notfound {
            position: relative;
            height: 100vh;
        }

            #notfound .notfound {
                position: absolute;
                left: 50%;
                top: 35%;
                -webkit-transform: translate(-50%, -50%);
                -ms-transform: translate(-50%, -50%);
                transform: translate(-50%, -50%);
            }

        .notfound {
            max-width: 767px;
            width: 100%;
            line-height: 1.4;
            padding: 0px 15px;
        }

            .notfound .notfound-404 {
                position: relative;
                height: 150px;
                line-height: 150px;
                margin-bottom: 25px;
            }

                .notfound .notfound-404 h1 {
                    font-family: 'Titillium Web', sans-serif;
                    font-size: 70px;
                    font-weight: 900;
                    margin: 0px;
                    text-transform: uppercase;
                    background: url('/images/text.png');
                    -webkit-background-clip: text;
                    -webkit-text-fill-color: transparent;
                    background-size: cover;
                    background-position: center;
                }

            .notfound h2 {
                font-family: 'Titillium Web', sans-serif;
                font-size: 26px;
                font-weight: 700;
                margin: 0;
            }

            .notfound p {
                font-family: 'Montserrat', sans-serif;
                font-size: 14px;
                font-weight: 500;
                margin-bottom: 0px;
                text-transform: uppercase;
                color:black;
            }

            .notfound a {
                font-family: 'Titillium Web', sans-serif;
                display: inline-block;
                text-transform: uppercase;
                color: #fff;
                text-decoration: none;
                border: none;
                background: #5c91fe;
                padding: 10px 40px;
                font-size: 14px;
                font-weight: 700;
                border-radius: 1px;
                margin-top: 15px;
                -webkit-transition: 0.2s all;
                transition: 0.2s all;
            }

                .notfound a:hover {
                    opacity: 0.8;
                }

        @media only screen and (max-width: 767px) {
            .notfound .notfound-404 {
                height: 110px;
                line-height: 110px;
            }

                .notfound .notfound-404 h1 {
                    font-size: 120px;
                }
        }
    </style>


</asp:Content>

<asp:Content ContentPlaceHolderID="main" ID="Content2" runat="server">

    <div id="notfound">
        <div class="notfound">
            <div class="notfound-404">
                <h1>Unauthorized Access</h1>
            </div>
<%--            <h2>Unauthorized Access</h2>--%>
            <p>You have attempted to access a page that you are not authorized to view.</p>
            <p>
                If you have any questions, please contact the site administrator.
            </p>
        </div>
    </div>
</asp:Content>

<asp:Content ContentPlaceHolderID="js" ID="Content3" runat="server"></asp:Content>

