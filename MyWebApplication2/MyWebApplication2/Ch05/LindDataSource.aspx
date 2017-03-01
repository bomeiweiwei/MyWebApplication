<%@ Page Title="" Language="C#" MasterPageFile="~/Ch05/Ch05MasterPage.master" AutoEventWireup="true" CodeBehind="LindDataSource.aspx.cs" Inherits="MyWebApplication2.Ch05.LindDataSource" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id"  AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" DataSourceID="LinqDataSource1">
        <Columns>
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" ShowSelectButton="True">
                <HeaderStyle Width="180px"></HeaderStyle>
            </asp:CommandField>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" InsertVisible="False" SortExpression="id"></asp:BoundField>
            <asp:BoundField DataField="test_time" HeaderText="test_time" SortExpression="test_time"></asp:BoundField>
            <asp:BoundField DataField="class" HeaderText="class" SortExpression="class"></asp:BoundField>
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title"></asp:BoundField>
            <asp:BoundField DataField="summary" HeaderText="summary" SortExpression="summary"></asp:BoundField>
            <asp:TemplateField HeaderText="article" SortExpression="article">
                <EditItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("article") %>' ID="TextBox1"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Height="70px" TextMode="MultiLine" Width="300px" Text='<%# Bind("article") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="author" HeaderText="author" SortExpression="author"></asp:BoundField>
            <asp:BoundField DataField="hit_no" HeaderText="hit_no" SortExpression="hit_no"></asp:BoundField>
            <asp:BoundField DataField="get_no" HeaderText="get_no" SortExpression="get_no"></asp:BoundField>
            <asp:BoundField DataField="email_no" HeaderText="email_no" SortExpression="email_no"></asp:BoundField>
            <asp:BoundField DataField="approved" HeaderText="approved" SortExpression="approved"></asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black"></FooterStyle>

        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White"></HeaderStyle>

        <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>

        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

        <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#4B4B4B"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#E5E5E5"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#242121"></SortedDescendingHeaderStyle>
    </asp:GridView>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" EntityTypeName="" ContextTypeName="MyWebApplication2.testDataClassesDataContext" EnableDelete="True" EnableInsert="True" EnableUpdate="True" TableName="test">
    </asp:LinqDataSource>
</asp:Content>
