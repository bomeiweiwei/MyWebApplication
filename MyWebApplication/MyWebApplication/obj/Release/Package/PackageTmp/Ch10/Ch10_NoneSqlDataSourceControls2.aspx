<%@ Page Title="" Language="C#" MasterPageFile="~/Ch10/Ch10MasterPage.master" AutoEventWireup="true" CodeBehind="Ch10_NoneSqlDataSourceControls2.aspx.cs" Inherits="MyWebApplication.Ch10.Ch10_NoneSqlDataSourceControls2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing" OnDataBound="GridView1_DataBound" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting">
        <Columns>
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" ShowEditButton="True" ShowDeleteButton="True" />
            <asp:ButtonField ButtonType="Button" CommandName="Cancel_Select" Text="不選取"></asp:ButtonField>
            <asp:TemplateField HeaderText="id" InsertVisible="False" SortExpression="id">
                <EditItemTemplate>
                    <asp:Label ID="lblUpID" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                    <asp:CheckBox ID="chkID" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="test_time" SortExpression="test_time">
                <EditItemTemplate>
                    <asp:Calendar ID="calTestTime" runat="server" SelectedDate='<%# Bind("test_time") %>' OnSelectionChanged="calTestTime_SelectionChanged"></asp:Calendar>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblTestTime" runat="server" Text='<%# Bind("test_time") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="title" SortExpression="title">
                <EditItemTemplate>
                    <asp:TextBox ID="txtUpTitle" runat="server" Text='<%# Bind("title") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("title") %>'></asp:Label>
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
        <PagerSettings Position="Top" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <PagerTemplate>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </PagerTemplate>
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>
    <asp:Label ID="lblPager" runat="server" Text=""></asp:Label><br/>
    <asp:Button ID="Button1" runat="server" Text="顯示選取的CheckBox id" Height="35px" Width="250px" OnClick="Button1_Click" /><br />
    <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblErr" runat="server" Text=""></asp:Label>
</asp:Content>
