<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebFormsOktaExample.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"
        integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4="
        crossorigin="anonymous"></script>
    <script src="https://global.oktacdn.com/okta-signin-widget/5.16.1/js/okta-sign-in.min.js" type="text/javascript"></script>
    <link href="https://global.oktacdn.com/okta-signin-widget/5.16.1/css/okta-sign-in.min.css" type="text/css" rel="stylesheet" />

    <div id="widget"></div>

    <script type="text/javascript">
        const signIn = new OktaSignIn({
            baseUrl: '<%= ConfigurationManager.AppSettings["okta:OktaDomain"] %>',
            features: {
                idpDiscovery: true
            },
            idpDiscovery: {
                requestContext: 'https://localhost:44303/signin.ashx'
            }
        });
        signIn.renderEl({ el: '#widget' }, (res) => {
        }, (err) => {
            console.error(err);
        });
    </script>
</asp:Content>
