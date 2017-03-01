<%@ Page Title="" Language="C#" MasterPageFile="~/Ch11/Ch11MasterPage.master" AutoEventWireup="true" CodeBehind="Ch11_TableColSpan.aspx.cs" Inherits="MyWebApplication.Ch11.Ch11_TableColSpan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="id,t_id" DataSourceID="SqlDataSource1" OnRowCreated="GridView1_RowCreated">
        <Columns>
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="test_time" HeaderText="test_time" SortExpression="test_time" />
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
            <asp:BoundField DataField="summary" HeaderText="summary" SortExpression="summary" />
            <asp:BoundField DataField="t_id" HeaderText="t_id" InsertVisible="False" ReadOnly="True" SortExpression="t_id" />
            <asp:BoundField DataField="test_id" HeaderText="test_id" SortExpression="test_id" />
            <asp:BoundField DataField="t_test_time" HeaderText="t_test_time" SortExpression="t_test_time" />
            <asp:BoundField DataField="t_article" HeaderText="t_article" SortExpression="t_article" />
            <asp:BoundField DataField="t_author" HeaderText="t_author" SortExpression="t_author" />
            <asp:BoundField DataField="t_email" HeaderText="t_email" SortExpression="t_email" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT test.id, test.test_time, test.title, test.summary, test_talk.id AS t_id, test_talk.test_id, test_talk.test_time AS t_test_time, test_talk.article AS t_article, test_talk.author AS t_author, test_talk.email AS t_email FROM test INNER JOIN test_talk ON test.id = test_talk.test_id order by test.id"></asp:SqlDataSource>
</asp:Content>
