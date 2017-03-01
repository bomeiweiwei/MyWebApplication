<%@ Page Title="" Language="C#" MasterPageFile="~/Ch05/Ch05MasterPage.master" AutoEventWireup="true" CodeBehind="LindDataSource3.aspx.cs" Inherits="MyWebApplication2.Ch05.LindDataSource3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click"/><br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True"></asp:GridView>
</asp:Content>
