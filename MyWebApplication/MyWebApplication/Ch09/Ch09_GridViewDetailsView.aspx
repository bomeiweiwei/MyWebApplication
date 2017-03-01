<%@ Page Title="" Language="C#" MasterPageFile="~/Ch09/Ch09MasterPage.master" AutoEventWireup="true" CodeBehind="Ch09_GridViewDetailsView.aspx.cs" Inherits="MyWebApplication.Ch09.Ch09_GridViewDetailsView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="test_time" HeaderText="test_time" SortExpression="test_time" />
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
            <asp:BoundField DataField="summary" HeaderText="summary" SortExpression="summary" />
        </Columns>
    </asp:GridView>
    <hr />
    <asp:DetailsView ID="DetailsView1" runat="server" Height="400px" Width="300px" AllowPaging="True" AutoGenerateRows="False">
        <Fields>
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" >
            <HeaderStyle Height="20%" />
            </asp:BoundField>
            <asp:BoundField DataField="summary" HeaderText="summary" SortExpression="summary" >
            <HeaderStyle Height="20%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="article" SortExpression="article">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("article") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("article") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("article") %>' TextMode="MultiLine" Height="140px" Width="350px"></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle Height="40%" />
            </asp:TemplateField>
            <asp:BoundField DataField="author" HeaderText="author" SortExpression="author" >
            <HeaderStyle Height="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="hit_no" HeaderText="hit_no" SortExpression="hit_no" >
            <HeaderStyle Height="10%" />
            </asp:BoundField>
        </Fields>
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT [test_time], [title], [summary], [id] FROM [test]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT [title], [summary], [article], [author], [hit_no] FROM [test] WHERE ([id] = @id)">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="id" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
