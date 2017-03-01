<%@ Page Title="" Language="C#" MasterPageFile="~/Ch14/Ch14MasterPage.master" AutoEventWireup="true" CodeBehind="DataToGridview2.aspx.cs" Inherits="MyWebApplication.Ch14.DataToGridview2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <h1>不使用SqlDataSource工具，Gridview也不做任何設定(空)，DataSet</h1>
    <br />
    <br />
    <asp:Label ID="msg" runat="server" Text="Label"></asp:Label>
    <h3>GridView1：using</h3>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    <br />
    <br />
    <br />
    <h3>GridView2：no using</h3>
    <asp:GridView ID="GridView2" runat="server"></asp:GridView>
    <br />
    <br />
    <br />
    <h3>Table：no using</h3>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</asp:Content>
