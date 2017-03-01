<%@ Page Title="" Language="C#" MasterPageFile="~/Ch11/Ch11MasterPage.master" AutoEventWireup="true" CodeBehind="Ch11_JavaScript.aspx.cs" Inherits="MyWebApplication.Ch11.Ch11_JavaScript" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update" Text="更新" />
                    &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Edit" Text="編輯" />
                    &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('真der要刪除嗎??')" Text="刪除" />
                </ItemTemplate>
                <HeaderStyle Width="150px" />
            </asp:TemplateField>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id">
            <HeaderStyle Width="5%" />
            </asp:BoundField>
            <asp:BoundField DataField="test_time" HeaderText="test_time" SortExpression="test_time">
            <HeaderStyle Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title">
            <HeaderStyle Width="20%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="summary" SortExpression="summary">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("summary") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("summary") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" DeleteCommand="DELETE FROM [test] WHERE [id] = @id" InsertCommand="INSERT INTO [test] ([test_time], [title], [summary]) VALUES (@test_time, @title, @summary)" SelectCommand="SELECT [id], [test_time], [title], [summary] FROM [test]" UpdateCommand="UPDATE [test] SET [test_time] = @test_time, [title] = @title, [summary] = @summary WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="test_time" Type="DateTime" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="summary" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="test_time" Type="DateTime" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="summary" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
