<%@ Page Title="" Language="C#" MasterPageFile="~/Ch10/Ch10MasterPage.master" AutoEventWireup="true" CodeBehind="Ch10_FindControls.aspx.cs" Inherits="MyWebApplication.Ch10.Ch10_FindControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" DataSourceID="SqlDataSource1" PageSize="5">
        <Columns>
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" ShowEditButton="True" />
            <asp:TemplateField HeaderText="id" InsertVisible="False" SortExpression="id">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                    <asp:CheckBox ID="chkID" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="test_time" SortExpression="test_time">
                <EditItemTemplate>
                    <asp:Calendar ID="calTestTime" runat="server" SelectedDate='<%# Bind("test_time") %>'></asp:Calendar>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblTestTime" runat="server" Text='<%# Bind("test_time") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="title" SortExpression="title">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("title") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("title") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="summary" SortExpression="summary">
                <EditItemTemplate>
                    <asp:TextBox ID="txtUpSummary" runat="server" Height="85px" Text='<%# Bind("summary") %>' TextMode="MultiLine" Width="285px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtSummary" runat="server" Height="85px" ReadOnly="True" Text='<%# Bind("summary") %>' TextMode="MultiLine" Width="285px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>
    <asp:Button ID="Button1" runat="server" Text="顯示多筆選取選項" Height="35px" Width="250px" OnClick="Button1_Click" /><br/>
    
    <asp:Label ID="lblErr" runat="server" Text=""></asp:Label>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT [id], [test_time], [title], [summary] FROM [test]" DeleteCommand="DELETE FROM [test] WHERE [id] = @id" InsertCommand="INSERT INTO [test] ([test_time], [title], [summary]) VALUES (@test_time, @title, @summary)" UpdateCommand="UPDATE [test] SET [test_time] = @test_time, [title] = @title, [summary] = @summary WHERE [id] = @id">
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
