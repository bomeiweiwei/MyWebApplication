<%@ Page Title="" Language="C#" MasterPageFile="~/Ch09/Ch09MasterPage.master" AutoEventWireup="true" CodeBehind="Ch09_MD_URL2.aspx.cs" Inherits="MyWebApplication.Ch09.Ch09_MD_URL2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id">
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
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" DeleteCommand="DELETE FROM [test] WHERE [id] = @id" InsertCommand="INSERT INTO [test] ([test_time], [class], [title], [summary], [author], [article], [hit_no], [get_no], [email_no], [approved]) VALUES (@test_time, @class, @title, @summary, @author, @article, @hit_no, @get_no, @email_no, @approved)" SelectCommand="SELECT [id], [test_time], [class], [title], [summary], [author], [article], [hit_no], [get_no], [email_no], [approved] FROM [test] WHERE ([id] = @id)" UpdateCommand="UPDATE [test] SET [test_time] = @test_time, [class] = @class, [title] = @title, [summary] = @summary, [author] = @author, [article] = @article, [hit_no] = @hit_no, [get_no] = @get_no, [email_no] = @email_no, [approved] = @approved WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="test_time" Type="DateTime" />
            <asp:Parameter Name="class" Type="String" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="summary" Type="String" />
            <asp:Parameter Name="author" Type="String" />
            <asp:Parameter Name="article" Type="String" />
            <asp:Parameter Name="hit_no" Type="Int32" />
            <asp:Parameter Name="get_no" Type="Int32" />
            <asp:Parameter Name="email_no" Type="Int32" />
            <asp:Parameter Name="approved" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="id" QueryStringField="id" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="test_time" Type="DateTime" />
            <asp:Parameter Name="class" Type="String" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="summary" Type="String" />
            <asp:Parameter Name="author" Type="String" />
            <asp:Parameter Name="article" Type="String" />
            <asp:Parameter Name="hit_no" Type="Int32" />
            <asp:Parameter Name="get_no" Type="Int32" />
            <asp:Parameter Name="email_no" Type="Int32" />
            <asp:Parameter Name="approved" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
