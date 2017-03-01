<%@ Page Title="" Language="C#" MasterPageFile="~/Ch10/Ch10MasterPage.master" AutoEventWireup="true" CodeBehind="Ch10_GridViewEvent.aspx.cs" Inherits="MyWebApplication.Ch10.Ch10_GridViewEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:Label ID="lblMember" runat="server" Text="Label"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="id" DataSourceID="SqlDataSource1" GridLines="Vertical" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" PageSize="3">
        <AlternatingRowStyle BackColor="Gainsboro" />
        <Columns>
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="test_time" HeaderText="test_time" SortExpression="test_time" />
            <asp:BoundField DataField="class" HeaderText="class" SortExpression="class" />
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
            <asp:BoundField DataField="summary" HeaderText="summary" SortExpression="summary" />
            <asp:TemplateField HeaderText="article" SortExpression="article">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("article") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Height="100px" Text='<%# Bind("article") %>' TextMode="MultiLine" Width="300px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="author" HeaderText="author" SortExpression="author" />
            <asp:BoundField DataField="hit_no" HeaderText="hit_no" SortExpression="hit_no" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>
    <hr />
    <asp:Label ID="lblIndex" runat="server" Text="Label"></asp:Label><br/>
    <asp:Label ID="lblRowIndex" runat="server" Text="Label"></asp:Label><br/>
    <asp:Label ID="lblSelectValue" runat="server" Text="Label"></asp:Label><br/>
    <asp:Label ID="lblSelectDKey" runat="server" Text="Label"></asp:Label><br/>
    <asp:Label ID="lblRowCommand" runat="server" Text="Label"></asp:Label>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT [id], [test_time], [class], [title], [summary], [article], [author], [hit_no] FROM [test]"></asp:SqlDataSource>
</asp:Content>
