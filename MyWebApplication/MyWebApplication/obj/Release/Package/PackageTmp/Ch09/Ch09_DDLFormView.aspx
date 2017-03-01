<%@ Page Title="" Language="C#" MasterPageFile="~/Ch09/Ch09MasterPage.master" AutoEventWireup="true" CodeBehind="Ch09_DDLFormView.aspx.cs" Inherits="MyWebApplication.Ch09.Ch09_DDLFormView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    請選擇標題&nbsp;:&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="title" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
    <asp:FormView ID="FormView1" runat="server" CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource2" ForeColor="#333333" Width="600px">
        <EditItemTemplate>
            id:
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
            class:
            <asp:TextBox ID="classTextBox" runat="server" Text='<%# Bind("class") %>' />
            <br />
            article:
            <asp:TextBox ID="articleTextBox" runat="server" Text='<%# Bind("article") %>' />
            <br />
            author:
            <asp:TextBox ID="authorTextBox" runat="server" Text='<%# Bind("author") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="更新" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" />
        </EditItemTemplate>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <InsertItemTemplate>
            test_time:
            <asp:TextBox ID="test_timeTextBox" runat="server" Text='<%# Bind("test_time") %>' />
            <br />
            title:
            <asp:TextBox ID="titleTextBox" runat="server" Text='<%# Bind("title") %>' />
            <br />
            summary:
            <asp:TextBox ID="summaryTextBox" runat="server" Text='<%# Bind("summary") %>' />
            <br />
            class:
            <asp:TextBox ID="classTextBox" runat="server" Text='<%# Bind("class") %>' />
            <br />
            article:
            <asp:TextBox ID="articleTextBox" runat="server" Text='<%# Bind("article") %>' />
            <br />
            author:
            <asp:TextBox ID="authorTextBox" runat="server" Text='<%# Bind("author") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="插入" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" />
        </InsertItemTemplate>
        <ItemTemplate>
            id:
            <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
            <br />
            test_time:
            <asp:Label ID="test_timeLabel" runat="server" Text='<%# Bind("test_time") %>' />
            <br />
            title:
            <asp:Label ID="titleLabel" runat="server" Text='<%# Bind("title") %>' />
            <br />
            summary:
            <asp:Label ID="summaryLabel" runat="server" Text='<%# Bind("summary") %>' />
            <br />
            class:
            <asp:Label ID="classLabel" runat="server" Text='<%# Bind("class") %>' />
            <br />
            article:
            <asp:TextBox ID="TextBox1" runat="server" Height="300px" Text='<%# Bind("article") %>' TextMode="MultiLine" Width="500px"></asp:TextBox>
            <br />
            author:
            <asp:Label ID="authorLabel" runat="server" Text='<%# Bind("author") %>' />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="編輯" />
&nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除" />
            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="新增" />
        </ItemTemplate>
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
</asp:FormView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT [id], [title] FROM [test]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" DeleteCommand="DELETE FROM [test] WHERE [id] = @id" InsertCommand="INSERT INTO [test] ([test_time], [title], [summary], [class], [article], [author]) VALUES (@test_time, @title, @summary, @class, @article, @author)" SelectCommand="SELECT [id], [test_time], [title], [summary], [class], [article], [author] FROM [test] WHERE ([id] = @id)" UpdateCommand="UPDATE [test] SET [test_time] = @test_time, [title] = @title, [summary] = @summary, [class] = @class, [article] = @article, [author] = @author WHERE [id] = @id">
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
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="id" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
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
