<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebFormsOktaExample.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"
        integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4="
        crossorigin="anonymous"></script>
    <script src="https://global.oktacdn.com/okta-signin-widget/5.16.1/js/okta-sign-in.min.js" type="text/javascript"></script>
    <link href="https://global.oktacdn.com/okta-signin-widget/5.16.1/css/okta-sign-in.min.css" type="text/css" rel="stylesheet" />

    <div id="widget"></div>

    <form runat="server" method="POST" action="Signin.ashx" id="oktaSignInForm">
        <input type="hidden" name="sessionToken" id="oktaSessionToken" />
    </form>

    <script type="text/javascript">
        const oktaSignIn = new OktaSignIn({
            baseUrl: '<%= ConfigurationManager.AppSettings["okta:OktaDomain"] %>',
            features: {
                idpDiscovery: true
            },
            idpDiscovery: {
                requestContext: 'https://localhost:44304/signin.ashx'
            }
        });

        oktaSignIn.renderEl({ el: '#widget' }, (res) => {
            $("#oktaSessionToken").val(res.session.token);
            $("#oktaSignInForm").submit();
        }, (err) => {
            console.error(err);
        });
    </script>
</asp:Content>
