<%@ Page Title="" Language="C#" MasterPageFile="~/Ch14/Ch14MasterPage.master" AutoEventWireup="true" CodeBehind="SDS_SetDR.aspx.cs" Inherits="MyWebApplication.Ch14.SDS_SetDR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <h1>程式裡宣告SqlDataSource並設定SqlDataSourceMode為DataReader，Gridview也不做任何設定(空)</h1>
    <br />
    <br />
    <asp:Label ID="msg" runat="server" Text="Label"></asp:Label>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>
