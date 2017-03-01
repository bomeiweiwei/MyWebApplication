<%@ Page Title="" Language="C#" MasterPageFile="~/Ch09/Ch09MasterPage.master" AutoEventWireup="true" CodeBehind="Ch09_DataBind.aspx.cs" Inherits="MyWebApplication.Ch09.Ch09_DataBind" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="test_time" HeaderText="test_time" SortExpression="test_time" />
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
            <asp:BoundField DataField="summary" HeaderText="summary" SortExpression="summary" />
        </Columns>
    </asp:GridView>
    <hr />
    <asp:FormView ID="FormView1" runat="server" Height="300px" Width="600px">
        <EditItemTemplate>
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
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="更新" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" />
        </EditItemTemplate>
        <InsertItemTemplate>
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
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="插入" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" />
        </InsertItemTemplate>
        <ItemTemplate>
            title:
            <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
            <br />
            summary:
            <asp:Label ID="summaryLabel" runat="server" Text='<%# Eval("summary") %>' />
            <br />
            article:
            <asp:TextBox ID="TextBox1" runat="server" Height="200px" Text='<%# Eval("article") %>' TextMode="MultiLine" Width="500px" ReadOnly="True"></asp:TextBox>
            <br />
            author:
            <asp:Label ID="authorLabel" runat="server" Text='<%# Eval("author") %>' />
            <br />
            hit_no:
            <asp:Label ID="hit_noLabel" runat="server" Text='<%# Eval("hit_no") %>' />
            <br />
        </ItemTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT [id], [test_time], [title], [summary] FROM [test]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT [title], [summary], [article], [author], [hit_no] FROM [test] WHERE ([id] = @id)">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="id" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
