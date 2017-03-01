﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Ch12/Ch12MasterPage.master" AutoEventWireup="true" CodeBehind="ListViewSetting3.aspx.cs" Inherits="MyWebApplication.Ch12.ListViewSetting3" MaintainScrollPositionOnPostback="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    自己動手撰寫「刪除」的程式碼，但刪除按鈕必須<span class="style1">設定在 ListView的「外面」！</span>
        <p>流程如下：
        <br />
        &nbsp;
        1. 先選定 ListView某一筆資料（按下「選取（Select）」按鈕）
        <br />
        &nbsp;
        2. 選定之後，按下最上面的「刪除」按鈕即可進行刪除。
        </p>
        <asp:Button ID="Button1_Delete" runat="server" Text="Delete (刪除)" 
            OnClick="Button1_Delete_Click" /> &nbsp;&nbsp;
        <asp:Button ID="Button2_Edit" runat="server" Text="Edit (編輯)" 
            OnClick="Button2_Edit_Click" /> &nbsp;&nbsp;
        <asp:Button ID="Button3_Update" runat="server" Text="Update (更新)" 
            visible="False" OnClick="Button3_Update_Click" /> &nbsp;&nbsp;
        <asp:Button ID="Button4_Insert" runat="server" Text="Insert (新增)" 
            OnClick="Button4_Insert_Click" /> 
        <br />
        <hr />
        <br />
        Message --
        <asp:Label ID="Label1" runat="server" style="font-weight: 700; color: #FF0000;"></asp:Label>
        <br />
        <br />
        <hr />
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="id" 
            DataSourceID="SqlDataSource1" 
            InsertItemPosition="LastItem"
            onitemdeleted="ListView1_ItemDeleted" oniteminserted="ListView1_ItemInserted" 
            onitemupdating="ListView1_ItemUpdating" 
            onpagepropertieschanging="ListView1_PagePropertiesChanging">
           <ItemTemplate>
                <span style="background-color: #DCDCDC;color: #000000;">
                    id:
                    <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                    <br />
                    test_time:
                    <asp:Label ID="test_timeLabel" runat="server" Text='<%# Eval("test_time") %>' />
                    <br />
                    class:
                    <asp:Label ID="classLabel" runat="server" Text='<%# Eval("class") %>' />
                    <br />
                    title:
                    <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
                    <br />
                    summary:
                    <asp:Label ID="summaryLabel" runat="server" Text='<%# Eval("summary") %>' />
                    <br />
                    <br />
                    <asp:Button ID="Button2" runat="server" Text="選取（Select）" CommandName="Select"  />
                </span>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <span style="background-color: #FFF8DC;">
                    id:
                    <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                    <br />
                    test_time:
                    <asp:Label ID="test_timeLabel" runat="server" Text='<%# Eval("test_time") %>' />
                    <br />
                    class:
                    <asp:Label ID="classLabel" runat="server" Text='<%# Eval("class") %>' />
                    <br />
                    title:
                    <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
                    <br />
                    summary:
                    <asp:Label ID="summaryLabel" runat="server" Text='<%# Eval("summary") %>' />
                    <br />
                    <br />
                    <asp:Button ID="Button2" runat="server" Text="選取（Select）" CommandName="Select"  />
                </span>
            </AlternatingItemTemplate>

            <EmptyDataTemplate>
                未傳回資料。
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <td id="Td4" runat="server" style="">
                    日期:
                    <asp:TextBox ID="test_timeTextBox" runat="server" 
                        Text='<%# Bind("test_time") %>' />
                    <br />
                    分類:
                    <asp:TextBox ID="classTextBox" runat="server" Text='<%# Bind("class") %>' />
                    <br />
                    標題:
                    <asp:TextBox ID="titleTextBox" runat="server" Text='<%# Bind("title") %>' />
                    <br />
                    摘要:
                    <asp:TextBox ID="summaryTextBox" runat="server" Text='<%# Bind("summary") %>' TextMode="MultiLine" Height="100"/>
                    <br />
                    內容（全文）:
                    <asp:TextBox ID="articleTextBox" runat="server" Text='<%# Bind("article") %>' TextMode="MultiLine" Height="250" />
                    <br />
                    作者:
                    <asp:TextBox ID="authorTextBox" runat="server" Text='<%# Bind("author") %>' />
                    <br />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                    Text="Clear（取消）" />
                    <br />
                </td>
            </InsertItemTemplate>
            <ItemSeparatorTemplate>
                <br />
            </ItemSeparatorTemplate>

            <LayoutTemplate>
                <ul ID="itemPlaceholderContainer" runat="server" 
                    style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                    <li runat="server" id="itemPlaceholder" />
                </ul>
                <div style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                    <asp:DataPager ID="DataPager1" runat="server">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" 
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                </div>
            </LayoutTemplate>
          <EditItemTemplate>
                <span style="background-color: #FFB366;font-weight: bold;color: #FFFFFF;">
                    id:
                    <asp:Label ID="idLabel1" runat="server" Text='<%# Eval("id") %>' />
                    <br />
                    test_time:
                    <asp:TextBox ID="test_timeTextBox" runat="server" 
                        Text='<%# Bind("test_time") %>' />
                    <br />
                    class:
                    <asp:TextBox ID="classTextBox" runat="server" Text='<%# Bind("class") %>' />
                    <br />
                    title:
                    <asp:TextBox ID="titleTextBox" runat="server" Text='<%# Bind("title") %>' />
                    <br />
                    summary:
                    <asp:TextBox ID="summaryTextBox" runat="server" Text='<%# Bind("summary") %>' />
                    <br />
                    article:
                    <asp:TextBox ID="articleTextBox" runat="server" Text='<%# Bind("article") %>' />
                    <br />
                    author:
                    <asp:TextBox ID="authorTextBox" runat="server" Text='<%# Bind("author") %>' />
                    <br />
                    hit_no:
                    <asp:TextBox ID="hit_noTextBox" runat="server" Text='<%# Bind("hit_no") %>' />
                    <br />
                    get_no:
                    <asp:TextBox ID="get_noTextBox" runat="server" Text='<%# Bind("get_no") %>' />
                    <br />
                    email_no:
                    <asp:TextBox ID="email_noTextBox" runat="server" 
                        Text='<%# Bind("email_no") %>' />
                    <br />
                    approved:
                    <asp:TextBox ID="approvedTextBox" runat="server" 
                        Text='<%# Bind("approved") %>' />
                    <br />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                Text="Cancel（取消）" />
                </span>
            </EditItemTemplate>

            <SelectedItemTemplate>
                <span style="background-color: #008A8C;font-weight: bold;color: #FFFFFF;">
                    id:
                    <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                    <br />
                    test_time:
                    <asp:Label ID="test_timeLabel" runat="server" Text='<%# Eval("test_time") %>' />
                    <br />
                    class:
                    <asp:Label ID="classLabel" runat="server" Text='<%# Eval("class") %>' />
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
                </span>
            </SelectedItemTemplate>
        </asp:ListView>
        <br />
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:testConnectionString %>" 
            DeleteCommand="DELETE FROM [test] WHERE [id] = @id" 
            InsertCommand="INSERT INTO [test] ([test_time], [class], [title], [summary], [article], [author], [hit_no], [get_no], [email_no], [approved]) VALUES (@test_time, @class, @title, @summary, @article, @author, @hit_no, @get_no, @email_no, @approved)" 
            SelectCommand="SELECT * FROM [test]" 
            
            UpdateCommand="UPDATE [test] SET [test_time] = @test_time, [class] = @class, [title] = @title, [summary] = @summary, [article] = @article, [author] = @author, [hit_no] = @hit_no, [get_no] = @get_no, [email_no] = @email_no, [approved] = @approved WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
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
        </asp:SqlDataSource>
</asp:Content>
