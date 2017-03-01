<%@ Page Title="" Language="C#" MasterPageFile="~/Ch11/Ch11MasterPage.master" AutoEventWireup="true" CodeBehind="Ch11_RowDataBound.aspx.cs" Inherits="MyWebApplication.Ch11.Ch11_RowDataBound" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource1" GridLines="Horizontal" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            <asp:BoundField DataField="student_id" HeaderText="student_id" SortExpression="student_id" />
            <asp:BoundField DataField="chinese" HeaderText="chinese" SortExpression="chinese" />
            <asp:BoundField DataField="math" HeaderText="math" SortExpression="math" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#487575" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#275353" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT [id], [name], [student_id], [chinese], [math] FROM [student_test]"></asp:SqlDataSource>
</asp:Content>
