<%@ Page Title="" Language="C#" MasterPageFile="~/Ch12/Ch12MasterPage.master" AutoEventWireup="true" CodeBehind="ListViewSetting2.aspx.cs" Inherits="MyWebApplication.Ch12.ListViewSetting2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="id" DataSourceID="SqlDataSource1" GroupItemCount="3">
        <AlternatingItemTemplate>
            <td runat="server" style="background-color:#FFF8DC;">id:
                <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                <br />test_time:
                <asp:Label ID="test_timeLabel" runat="server" Text='<%# Eval("test_time") %>' />
                <br />title:
                <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
                <br />author:
                <asp:Label ID="authorLabel" runat="server" Text='<%# Eval("author") %>' />
                <br /></td>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <td runat="server" style="background-color:#008A8C;color: #FFFFFF;">id:
                <asp:Label ID="idLabel1" runat="server" Text='<%# Eval("id") %>' />
                <br />test_time:
                <asp:TextBox ID="test_timeTextBox" runat="server" Text='<%# Bind("test_time") %>' />
                <br />title:
                <asp:TextBox ID="titleTextBox" runat="server" Text='<%# Bind("title") %>' />
                <br />author:
                <asp:TextBox ID="authorTextBox" runat="server" Text='<%# Bind("author") %>' />
                <br />
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                <br />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                <br /></td>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                <tr>
                    <td>未傳回資料。</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <EmptyItemTemplate>
<td runat="server" />
        </EmptyItemTemplate>
        <GroupTemplate>
            <tr id="itemPlaceholderContainer" runat="server">
                <td id="itemPlaceholder" runat="server"></td>
            </tr>
        </GroupTemplate>
        <InsertItemTemplate>
            <td runat="server" style="">test_time:
                <asp:TextBox ID="test_timeTextBox" runat="server" Text='<%# Bind("test_time") %>' />
                <br />title:
                <asp:TextBox ID="titleTextBox" runat="server" Text='<%# Bind("title") %>' />
                <br />author:
                <asp:TextBox ID="authorTextBox" runat="server" Text='<%# Bind("author") %>' />
                <br />
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                <br />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                <br /></td>
        </InsertItemTemplate>
        <ItemTemplate>
            <td runat="server" style="background-color:#DCDCDC;color: #000000;">id:
                <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                <br />test_time:
                <asp:Label ID="test_timeLabel" runat="server" Text='<%# Eval("test_time") %>' />
                <br />title:
                <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
                <br />author:
                <asp:Label ID="authorLabel" runat="server" Text='<%# Eval("author") %>' />
                <br /></td>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr id="groupPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                         <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                                <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button"
                                     ShowFirstPageButton="true"
                                     ShowNextPageButton="True"
                                     ShowPreviousPageButton="True"
                                     ShowLastPageButton="True" />
                                </Fields>
                        </asp:DataPager>

                    </td>
                </tr>

               
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <td runat="server" style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">id:
                <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                <br />test_time:
                <asp:Label ID="test_timeLabel" runat="server" Text='<%# Eval("test_time") %>' />
                <br />title:
                <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
                <br />author:
                <asp:Label ID="authorLabel" runat="server" Text='<%# Eval("author") %>' />
                <br /></td>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" DeleteCommand="DELETE FROM [test] WHERE [id] = @id" InsertCommand="INSERT INTO [test] ([test_time], [title], [author]) VALUES (@test_time, @title, @author)" SelectCommand="SELECT [id], [test_time], [title], [author] FROM [test]" UpdateCommand="UPDATE [test] SET [test_time] = @test_time, [title] = @title, [author] = @author WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="test_time" Type="DateTime" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="author" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="test_time" Type="DateTime" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="author" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
