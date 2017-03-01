<%@ Page Title="" Language="C#"  validateRequest="False"  MasterPageFile="~/Ch09/Ch09MasterPage.master" AutoEventWireup="true" CodeBehind="Ch09_SearchEngine.aspx.cs" Inherits="MyWebApplication.Ch09.Ch09_SearchEngine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>&nbsp;&nbsp;<asp:Button ID="btn_Search" runat="server" Text="Search" Width="101px" OnClick="btn_Search_Click" />
    <h1>GridView1(Master)</h1>
    <hr />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="id" GridLines="Horizontal" PageSize="5" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
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
    <hr />
    <h1>GridView2(Detail)</h1>
    <hr />
    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="" ForeColor="Black" GridLines="Horizontal" Width="100%">
        <Columns>
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" >
            <HeaderStyle Width="15%" />
            </asp:BoundField>
            <asp:BoundField DataField="summary" HeaderText="summary" SortExpression="summary" >
            <HeaderStyle Width="20%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="article" SortExpression="article">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("article") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True" Text='<%# Bind("article") %>' TextMode="MultiLine"></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle Width="40%" />
            </asp:TemplateField>
            <asp:BoundField DataField="author" HeaderText="author" SortExpression="author" >
            <HeaderStyle Width="20%" />
            </asp:BoundField>
            <asp:BoundField DataField="hit_no" HeaderText="hit_no" SortExpression="hit_no" >
            <HeaderStyle Width="5%" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT [id], [test_time], [title], [summary] FROM [test] WHERE ([title] LIKE '%' + @title + '%')">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtSearch" Name="title" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT [title], [summary], [hit_no], [article], [author] FROM [test] WHERE ([id] = @id)">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="id" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
