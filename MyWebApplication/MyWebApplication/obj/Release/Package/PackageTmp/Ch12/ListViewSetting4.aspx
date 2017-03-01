<%@ Page Title="" Language="C#" MasterPageFile="~/Ch12/Ch12MasterPage.master" AutoEventWireup="true" CodeBehind="ListViewSetting4.aspx.cs" Inherits="MyWebApplication.Ch12.ListViewSetting4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    &nbsp;&nbsp;
        &nbsp;&nbsp;
        &nbsp;&nbsp;
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="id" 
        style="font-size: small" onitemcommand="ListView1_ItemCommand" 
        onselectedindexchanging="ListView1_SelectedIndexChanging">
           <ItemTemplate>
                <span>
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
                <span>
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
                    <br />
                    <asp:Button ID="Button2" runat="server" Text="Button(Back)" CommandName="MyDetail" />
                </span>
            </SelectedItemTemplate>
        </asp:ListView>
</asp:Content>
