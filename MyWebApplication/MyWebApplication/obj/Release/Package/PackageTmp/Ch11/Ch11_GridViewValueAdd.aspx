<%@ Page Title="" Language="C#" MasterPageFile="~/Ch11/Ch11MasterPage.master" AutoEventWireup="true" CodeBehind="Ch11_GridViewValueAdd.aspx.cs" Inherits="MyWebApplication.Ch11.Ch11_GridViewValueAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="id" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" >
            <HeaderStyle Width="180px" />
            </asp:CommandField>
            <asp:ButtonField ButtonType="Button" CommandName="myInsert" Text="自訂新增" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="test_time" HeaderText="test_time" SortExpression="test_time" />
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" >
            <HeaderStyle Width="20%" />
            </asp:BoundField>
            <asp:BoundField DataField="summary" HeaderText="summary" SortExpression="summary" >
            <HeaderStyle Width="30%" />
            </asp:BoundField>
            <asp:BoundField DataField="author" HeaderText="author" SortExpression="author" />
        </Columns>
        <EmptyDataTemplate>
            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="id" DataSourceID="SqlDataSource2" DefaultMode="Insert" Height="50px" Width="125px">
                <Fields>
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                    <asp:TemplateField HeaderText="test_time" SortExpression="test_time">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("test_time") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:Calendar ID="Calendar1" runat="server" SelectedDate='<%# Bind("test_time") %>'></asp:Calendar>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("test_time") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="class" HeaderText="class" SortExpression="class" />
                    <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                    <asp:BoundField DataField="summary" HeaderText="summary" SortExpression="summary" />
                    <asp:BoundField DataField="article" HeaderText="article" SortExpression="article" />
                    <asp:BoundField DataField="author" HeaderText="author" SortExpression="author" />
                    <asp:BoundField DataField="hit_no" HeaderText="hit_no" SortExpression="hit_no" />
                    <asp:BoundField DataField="get_no" HeaderText="get_no" SortExpression="get_no" />
                    <asp:BoundField DataField="email_no" HeaderText="email_no" SortExpression="email_no" />
                    <asp:BoundField DataField="approved" HeaderText="approved" SortExpression="approved" />
                    <asp:CommandField ShowInsertButton="True" />
                </Fields>
            </asp:DetailsView>
        </EmptyDataTemplate>
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" DeleteCommand="DELETE FROM [test] WHERE [id] = @id" InsertCommand="INSERT INTO [test] ([test_time], [title], [class], [summary], [author], [article], [hit_no], [get_no], [email_no], [approved]) VALUES (@test_time, @title, @class, @summary, @author, @article, @hit_no, @get_no, @email_no, @approved)" OnInserted="SqlDataSource1_Inserted" SelectCommand="SELECT [id], [test_time], [title], [class], [summary], [author], [article], [hit_no], [get_no], [email_no], [approved] FROM [test]" UpdateCommand="UPDATE [test] SET [test_time] = @test_time, [title] = @title, [class] = @class, [summary] = @summary, [author] = @author, [article] = @article, [hit_no] = @hit_no, [get_no] = @get_no, [email_no] = @email_no, [approved] = @approved WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="test_time" Type="DateTime" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="class" Type="String" />
            <asp:Parameter Name="summary" Type="String" />
            <asp:Parameter Name="author" Type="String" />
            <asp:Parameter Name="article" Type="String" />
            <asp:Parameter Name="hit_no" Type="Int32" />
            <asp:Parameter Name="get_no" Type="Int32" />
            <asp:Parameter Name="email_no" Type="Int32" />
            <asp:Parameter Name="approved" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="test_time" Type="DateTime" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="class" Type="String" />
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
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" DeleteCommand="DELETE FROM [test] WHERE [id] = @id" InsertCommand="INSERT INTO [test] ([test_time], [class], [title], [summary], [article], [author], [hit_no], [get_no], [email_no], [approved]) VALUES (@test_time, @class, @title, @summary, @article, @author, @hit_no, @get_no, @email_no, @approved)" OnInserted="SqlDataSource2_Inserted" OnInserting="SqlDataSource2_Inserting" SelectCommand="SELECT * FROM [test]" UpdateCommand="UPDATE [test] SET [test_time] = @test_time, [class] = @class, [title] = @title, [summary] = @summary, [article] = @article, [author] = @author, [hit_no] = @hit_no, [get_no] = @get_no, [email_no] = @email_no, [approved] = @approved WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="test_time" Type="DateTime" />
            <asp:Parameter Name="class" Type="String" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="summary" Type="String" />
            <asp:Parameter Name="article" Type="String" />
            <asp:Parameter Name="author" Type="String" />
            <asp:Parameter Name="hit_no" Type="Int32" />
            <asp:Parameter Name="get_no" Type="Int32" />
            <asp:Parameter Name="email_no" Type="Int32" />
            <asp:Parameter Name="approved" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="test_time" Type="DateTime" />
            <asp:Parameter Name="class" Type="String" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="summary" Type="String" />
            <asp:Parameter Name="article" Type="String" />
            <asp:Parameter Name="author" Type="String" />
            <asp:Parameter Name="hit_no" Type="Int32" />
            <asp:Parameter Name="get_no" Type="Int32" />
            <asp:Parameter Name="email_no" Type="Int32" />
            <asp:Parameter Name="approved" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
