<%@ Page Title="" Language="C#" MasterPageFile="~/Ch11/Ch11MasterPage.master" AutoEventWireup="true" CodeBehind="Ch11_TableRowSpan.aspx.cs" Inherits="MyWebApplication.Ch11.Ch11_TableRowSpan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="id,t_id" DataSourceID="SqlDataSource1" OnPreRender="GridView1_PreRender">
        <Columns>
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
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT test.id, test.test_time, test.title, test.summary, test_talk.id AS t_id, test_talk.test_id, test_talk.test_time AS t_test_time, test_talk.article AS t_article, test_talk.author AS t_author, test_talk.email AS t_email FROM test INNER JOIN test_talk ON test.id = test_talk.test_id order by test.id"></asp:SqlDataSource>
</asp:Content>
