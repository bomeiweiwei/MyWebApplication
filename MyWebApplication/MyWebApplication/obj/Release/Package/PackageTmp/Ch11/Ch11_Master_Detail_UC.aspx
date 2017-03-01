<%@ Page Title="" Language="C#" MasterPageFile="~/Ch11/Ch11MasterPage.master" AutoEventWireup="true" CodeBehind="Ch11_Master_Detail_UC.aspx.cs" Inherits="MyWebApplication.Ch11.Ch11_Master_Detail_UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div id="div1" runat="server">
        <asp:GridView ID="GridViewMaster" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Horizontal" OnPageIndexChanging="GridViewMaster_PageIndexChanging" OnRowCreated="GridViewMaster_RowCreated" OnSelectedIndexChanged="GridViewMaster_SelectedIndexChanged" OnSelectedIndexChanging="GridViewMaster_SelectedIndexChanging" OnSorting="GridViewMaster_Sorting">
            <Columns>
                <asp:CommandField ButtonType="Button" ShowSelectButton="True">
                <HeaderStyle Width="100px" />
                </asp:CommandField>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="test_time" HeaderText="test_time" SortExpression="test_time" />
                <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                <asp:BoundField DataField="summary" HeaderText="summary" SortExpression="summary" />
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
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT [id], [test_time], [title], [summary] FROM [test]"></asp:SqlDataSource>
    <asp:Label ID="lblErr" runat="server" Text=""></asp:Label>
    </asp:Content>
