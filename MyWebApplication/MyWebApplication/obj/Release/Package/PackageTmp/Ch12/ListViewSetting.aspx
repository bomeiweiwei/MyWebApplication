<%@ Page Title="" Language="C#" MasterPageFile="~/Ch12/Ch12MasterPage.master" AutoEventWireup="true" CodeBehind="ListViewSetting.aspx.cs" Inherits="MyWebApplication.Ch12.ListViewSetting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="id" DataSourceID="SqlDataSource1" InsertItemPosition="LastItem" OnItemCanceling="ListView1_ItemCanceling" OnItemCommand="ListView1_ItemCommand" OnItemEditing="ListView1_ItemEditing">
        <AlternatingItemTemplate>
            <span style="background-color: #FFF8DC;">id:
            <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
            <br />
            test_time:
            <asp:Label ID="test_timeLabel" runat="server" Text='<%# Eval("test_time","{0:yyyy-mm-dd}") %>' />
            <br />
            title:
            <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' Font-Bold="True" Font-Size="Medium" />
            <br />
            summary:
            <asp:Label ID="summaryLabel" runat="server" Text='<%# Eval("summary") %>' />
            <br />
            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
            <asp:Button ID="Button1" runat="server" Text="Button(Select)" CommandName="Select" />
            <br />
            <br />
            </span>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <span style="background-color: #008A8C;color: #FFFFFF;">id:
            <asp:Label ID="idLabel1" runat="server" Text='<%# Eval("id") %>' />
            <br />
            test_time:
            <asp:TextBox ID="test_timeTextBox" runat="server" Text='<%# Bind("test_time") %>' />
            <br />
            title:
            <asp:TextBox ID="titleTextBox" runat="server" Text='<%# Bind("title") %>' />
            <br />
            summary:
            <asp:TextBox ID="summaryTextBox" runat="server" Text='<%# Bind("summary") %>' />
            <br />
            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
            <br />
            <br />
            </span>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <span>未傳回資料。</span>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <span style="">test_time:
            <asp:TextBox ID="test_timeTextBox" runat="server" Text='<%# Bind("test_time") %>' />
            <br />title:
            <asp:TextBox ID="titleTextBox" runat="server" Text='<%# Bind("title") %>' />
            <br />summary:
            <asp:TextBox ID="summaryTextBox" runat="server" Text='<%# Bind("summary") %>' />
            <br />
            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
            <br />
            <br /></span>
        </InsertItemTemplate>
        <ItemTemplate>
            <span style="background-color: #DCDCDC;color: #000000;">id:
            <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
            <br />
            test_time:
            <asp:Label ID="test_timeLabel" runat="server" Text='<%# Eval("test_time","{0:yyyy-mm-dd}") %>' />
            <br />
            title:
            <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' Font-Size="Medium" Font-Bold="True" />
            <br />
            summary:
            <asp:Label ID="summaryLabel" runat="server" Text='<%# Eval("summary") %>' />
            <br />
            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
            <asp:Button ID="Button1" runat="server" Text="Button(Select)" CommandName="Select" />
            <br />
            <br />
            </span>
        </ItemTemplate>
        <LayoutTemplate>
            <div id="itemPlaceholderContainer" runat="server" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                <span runat="server" id="itemPlaceholder" />
            </div>
            <div style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                <asp:DataPager ID="DataPager1" runat="server">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                    </Fields>
                </asp:DataPager>
            </div>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <span style="background-color: #008A8C;font-weight: bold;color: #FFFFFF;">id:
            <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
            <br />
            test_time:
            <asp:Label ID="test_timeLabel" runat="server" Text='<%# Eval("test_time") %>' />
            <br />
            title:
            <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
            <br />
            summary:
            <asp:Label ID="summaryLabel" runat="server" Text='<%# Eval("summary") %>' />
            <br />
            article:
            <asp:Label ID="articleLabel" runat="server" Text='<%# Eval("article") %>' />
            <br />
            author:
            <asp:Label ID="authorLabel" runat="server" Text='<%# Eval("author") %>' />
            <br />
            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="編輯" />
            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="刪除" />
            <asp:Button ID="Button2" runat="server" Text="Button(Back)" CommandName="MyDetail" />
            <br />
            <br />
            </span>
        </SelectedItemTemplate>
</asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" DeleteCommand="DELETE FROM [test] WHERE [id] = @id" InsertCommand="INSERT INTO [test] ([test_time], [title], [summary], [class], [article], [author]) VALUES (@test_time, @title, @summary, @class, @article, @author)" SelectCommand="SELECT [id], [test_time], [title], [summary], [class], [article], [author] FROM [test]" UpdateCommand="UPDATE [test] SET [test_time] = @test_time, [title] = @title, [summary] = @summary, [class] = @class, [article] = @article, [author] = @author WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="test_time" Type="DateTime" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="summary" Type="String" />
            <asp:Parameter Name="class" Type="String" />
            <asp:Parameter Name="article" Type="String" />
            <asp:Parameter Name="author" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="test_time" Type="DateTime" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="summary" Type="String" />
            <asp:Parameter Name="class" Type="String" />
            <asp:Parameter Name="article" Type="String" />
            <asp:Parameter Name="author" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
</asp:SqlDataSource>
</asp:Content>
