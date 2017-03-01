<%@ Page Title="" Language="C#" MasterPageFile="~/Ch07/Ch07MasterPage.master" AutoEventWireup="true" CodeBehind="Ch07_GridView.aspx.cs" Inherits="MyWebApplication.Ch07.Ch07_GridView" MaintainScrollPositionOnPostback="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <h1>GridView簡單設定</h1>
    <hr>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" PageSize="5" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True">
            <HeaderStyle Width="150px" />
            </asp:CommandField>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="test_time" HeaderText="test_time時間" SortExpression="test_time" />
            <asp:BoundField DataField="title" HeaderText="title標題" SortExpression="title" />
            <asp:BoundField DataField="summary" HeaderText="summary摘要" SortExpression="summary" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
    <hr>
    <h1>GridView命令欄位外觀設定</h1>
    <hr>
    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource2" GridLines="Horizontal" PageSize="5" AutoGenerateColumns="False" DataKeyNames="id">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True">
            <HeaderStyle Width="180px" />
            </asp:CommandField>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="test_time" HeaderText="test_time" SortExpression="test_time" />
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
            <asp:BoundField DataField="summary" HeaderText="summary" SortExpression="summary" />
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" DeleteCommand="DELETE FROM [test] WHERE [id] = @id" InsertCommand="INSERT INTO [test] ([test_time], [title], [summary]) VALUES (@test_time, @title, @summary)" SelectCommand="SELECT [test_time], [id], [title], [summary] FROM [test]" UpdateCommand="UPDATE [test] SET [test_time] = @test_time, [title] = @title, [summary] = @summary WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="test_time" Type="DateTime" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="summary" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="test_time" Type="DateTime" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="summary" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" DeleteCommand="DELETE FROM [test] WHERE [id] = @id" InsertCommand="INSERT INTO [test] ([test_time], [title], [summary]) VALUES (@test_time, @title, @summary)" SelectCommand="SELECT [id], [test_time], [title], [summary] FROM [test]" UpdateCommand="UPDATE [test] SET [test_time] = @test_time, [title] = @title, [summary] = @summary WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="test_time" Type="DateTime" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="summary" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="test_time" Type="DateTime" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="summary" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
