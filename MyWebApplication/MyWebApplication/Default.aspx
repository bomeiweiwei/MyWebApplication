<%@ Page Title="首頁" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyWebApplication._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>這是首頁</h2>
            </hgroup>
            
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h1>Hello World!!</h1>
    <h2>Hello World!!</h2>
    <h3>Hello World!!</h3>
    <h4>Hello World!!</h4>
    <h5>Hello World!!</h5>
    <%
        Response.Write("<h3>REMOTE_ADDR:  " + Request.ServerVariables["REMOTE_ADDR"] + "</h3>");
    %>
</asp:Content>
