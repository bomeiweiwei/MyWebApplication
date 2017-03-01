<%@ Page Title="" Language="C#" MasterPageFile="~/Ch11/Ch11MasterPage.master" AutoEventWireup="true" CodeBehind="Ch11_ExcelByGridView.aspx.cs" Inherits="MyWebApplication.Ch11.Ch11_Excel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:Button ID="Button1" runat="server" Text="Excel" Height="45px" OnClick="Button1_Click" Width="225px" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="test_time" HeaderText="test_time" SortExpression="test_time" />
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
            <asp:BoundField DataField="summary" HeaderText="summary" SortExpression="summary" />
        </Columns>
    </asp:GridView>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT [id], [test_time], [title], [summary] FROM [test]"></asp:SqlDataSource>
</asp:Content>
