<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="WebFormsOktaExample.Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="BodyContent" runat="server">
<p>The user  <%= Context.User.Identity.Name %> is logged in.</p>
</asp:Content>
