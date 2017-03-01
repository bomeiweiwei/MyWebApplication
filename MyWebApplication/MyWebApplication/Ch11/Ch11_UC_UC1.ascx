<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ch11_UC_UC1.ascx.cs" Inherits="MyWebApplication.Ch11.Ch11_UC_UC1" %>

<p>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyNames="id" DataSourceID="SqlDataSource1" ForeColor="Black" PageSize="3">
        <Columns>
            <asp:CommandField ShowSelectButton="True">
                <HeaderStyle Width="100px" />
            </asp:CommandField>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id">
                <HeaderStyle Width="5%" />
            </asp:BoundField>
            <asp:BoundField DataField="test_time" HeaderText="test_time" SortExpression="test_time">
                <HeaderStyle Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title">
                <HeaderStyle Width="20%" />
            </asp:BoundField>
            <asp:BoundField DataField="summary" HeaderText="summary" SortExpression="summary"></asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT [id], [test_time], [title], [summary] FROM [test]"></asp:SqlDataSource>
    <p>
