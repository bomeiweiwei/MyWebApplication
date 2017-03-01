<%@ Page Title="" Language="C#" MasterPageFile="~/Ch10/Ch10MasterPage.master" AutoEventWireup="true" CodeBehind="Ch10_GridView_Mul_PK.aspx.cs" Inherits="MyWebApplication.Ch10.Ch10_GridView_Mul_PK" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:Label ID="lblMember" runat="server" Text="Label"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
        DataKeyNames="id,title" 
        DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="test_time" HeaderText="test_time" SortExpression="test_time" />
            <asp:HyperLinkField DataNavigateUrlFields="id,title" DataNavigateUrlFormatString="~/Ch10/Ch10_MD_URL.aspx?id={0}&title={1}" DataTextField="title" HeaderText="HLF標題超連結" />
            <asp:BoundField DataField="summary" HeaderText="summary" SortExpression="summary" />
        </Columns>
    </asp:GridView>
    <hr/>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
        <Columns>
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
            <asp:BoundField DataField="summary" HeaderText="summary" SortExpression="summary" />
            <asp:TemplateField HeaderText="article" SortExpression="article">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("article") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Height="100px" ReadOnly="True" Text='<%# Bind("article") %>' TextMode="MultiLine" Width="300px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="author" HeaderText="author" SortExpression="author" />
            <asp:BoundField DataField="hit_no" HeaderText="hit_no" SortExpression="hit_no" />
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
    <asp:Label ID="lblIndex" runat="server" Text="Label"></asp:Label><br/>
    <asp:Label ID="lblRowIndex" runat="server" Text="Label"></asp:Label><br/>
    <asp:Label ID="lblSelectValue" runat="server" Text="Label"></asp:Label><br/>
    <asp:Label ID="lblSelectDKey" runat="server" Text="Label"></asp:Label><br/>
    <asp:Label ID="lbllblSelectDKeyPK1" runat="server" Text="Label"></asp:Label><br/>
    <asp:Label ID="lbllblSelectDKeyPK2" runat="server" Text="Label"></asp:Label><br/>
    <asp:Label ID="lblRowCommand" runat="server" Text="Label"></asp:Label>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT [id], [test_time], [title], [summary] FROM [test]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT [title], [summary], [article], [author], [hit_no] FROM [test] WHERE ([id] = @id)">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="id" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
