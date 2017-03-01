<%@ Page Title="" Language="C#" MasterPageFile="~/Ch10/Ch10MasterPage.master" AutoEventWireup="true" CodeBehind="Ch10_MD_URL.aspx.cs" Inherits="MyWebApplication.Ch10.Ch10_MD_URL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
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
                    <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True" Text='<%# Bind("article") %>' TextMode="MultiLine" Height="161px" Width="400px"></asp:TextBox>
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT [title], [summary], [article], [author], [hit_no] FROM [test] WHERE (([id] = @id) AND ([title] = @title))">
        <SelectParameters>
            <asp:QueryStringParameter Name="id" QueryStringField="id" Type="Int32" />
            <asp:QueryStringParameter Name="title" QueryStringField="title" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
