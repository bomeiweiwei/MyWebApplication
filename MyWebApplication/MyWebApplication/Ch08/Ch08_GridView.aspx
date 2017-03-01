<%@ Page Title="" Language="C#" MasterPageFile="~/Ch08/Ch08MasterPage.master" AutoEventWireup="true" CodeBehind="Ch08_GridView.aspx.cs" Inherits="MyWebApplication.Ch08.Ch08_GridView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <h1>GridView1</h1>
    <hr />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource1" PageSize="5">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True">
            <HeaderStyle Width="180px" />
            </asp:CommandField>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:TemplateField HeaderText="test_time" SortExpression="test_time">
                <EditItemTemplate>
                    <asp:Calendar ID="Calendar1" runat="server" 
                            SelectedDate='<%# Bind("test_time") %>' BackColor="White" 
                            BorderColor="Black" 
                            Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" Width="330px" BorderStyle="Solid" CellSpacing="1" NextPrevFormat="ShortMonth">
                            <DayHeaderStyle Font-Bold="True" Height="8pt" Font-Size="8pt" ForeColor="#333333" />
                            <DayStyle BackColor="#CCCCCC" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="White" Font-Bold="True" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                            <TitleStyle BackColor="#333399" Font-Bold="True" Font-Size="12pt" 
                                ForeColor="White" BorderStyle="Solid" Height="12pt" />
                            <TodayDayStyle BackColor="#999999" ForeColor="White" />
                        </asp:Calendar>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("test_time") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
            <asp:TemplateField HeaderText="summary" SortExpression="summary">
                <EditItemTemplate>
                    內容修改--<br />
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("summary") %>' TextMode="MultiLine"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    摘要內容--<br />
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("summary") %>'></asp:Label>
                    <br />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
    </asp:GridView>
    <hr />
    <h1>GridView2</h1>
    <hr />
    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource2" PageSize="3">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="test_time" HeaderText="test_time" SortExpression="test_time" />
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
            <asp:BoundField DataField="summary" HeaderText="summary" SortExpression="summary" />
        </Columns>
        <EmptyDataTemplate>
            <asp:Label ID="Label2" runat="server" Text="RRR!!!搜尋不到任何資料。" ForeColor="Red"></asp:Label>
        </EmptyDataTemplate>
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
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT [id], [test_time], [title], [summary] FROM [test] where id=1234567"></asp:SqlDataSource>
</asp:Content>
