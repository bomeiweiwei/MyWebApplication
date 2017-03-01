<%@ Page Title="" Language="C#" MasterPageFile="~/Ch09/Ch09MasterPage.master" AutoEventWireup="true" CodeBehind="Ch09_MasterDetail_URL.aspx.cs" Inherits="MyWebApplication.Ch09.Ch09_MasterDetail_URL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="test_time" HeaderText="test_time" SortExpression="test_time" />
            <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/Ch09/Ch09_MD_URL.aspx?id={0}" DataTextField="title" HeaderText="HLF標題超連結" />
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" Visible="False" />
            <asp:BoundField DataField="summary" HeaderText="summary" SortExpression="summary" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT [id], [test_time], [title], [summary] FROM [test]"></asp:SqlDataSource>
</asp:Content>
