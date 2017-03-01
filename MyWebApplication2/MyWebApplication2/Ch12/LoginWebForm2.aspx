<%@ Page Title="" Language="C#" MasterPageFile="~/Ch12/Ch12MasterPage.master" AutoEventWireup="true" CodeBehind="LoginWebForm2.aspx.cs" Inherits="MyWebApplication2.Ch12.LoginWebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    透過Server.HtmlEncode更改惡意參數<br/>
    帳號:<asp:TextBox ID="txtAcc" runat="server"></asp:TextBox><br/>
    密碼:<asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox><br/>
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click"/><br/>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
