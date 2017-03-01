<%@ Page Title="" Language="C#" MasterPageFile="~/Ch14/Ch14MasterPage.master" AutoEventWireup="true" CodeBehind="SqlParameters.aspx.cs" Inherits="MyWebApplication.Ch14.SqlParameters" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    <br />===================================<br />
    <asp:GridView ID="GridView1" runat="server" EmptyDataText="RRR，沒有資料耶"></asp:GridView>
</asp:Content>
