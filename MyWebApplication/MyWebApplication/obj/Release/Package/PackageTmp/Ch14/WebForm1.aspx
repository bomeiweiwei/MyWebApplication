<%@ Page Title="" Language="C#" MasterPageFile="~/Ch14/Ch14MasterPage.master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="MyWebApplication.Ch14.WebForm1" %>
<%@ PreviousPageType VirtualPath="~/Ch14/WebForm2.aspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <script type="text/javascript" language="javascript" src="../js/date-picker.js"></script>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="txtTestDate" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="選擇日期" />
    <br />
    <br />==============================================
    <br />
    <br />
    <h2>此為日期設定的接收網頁，須檢查PreviousPage</h2>
    <asp:TextBox ID="txtTestDate2" runat="server"></asp:TextBox>
    <asp:Button ID="Button2" runat="server" Text="選擇日期" PostBackUrl="~/Ch14/WebForm2.aspx" />
</asp:Content>
