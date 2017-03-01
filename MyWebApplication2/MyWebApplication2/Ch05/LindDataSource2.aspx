<%@ Page Title="" Language="C#" MasterPageFile="~/Ch05/Ch05MasterPage.master" AutoEventWireup="true" CodeBehind="LindDataSource2.aspx.cs" Inherits="MyWebApplication2.Ch05.LindDataSource2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" AutoGenerateRows="False" DataKeyNames="id" DataSourceID="LinqDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>

        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True"></CommandRowStyle>

        <EditRowStyle BackColor="#999999"></EditRowStyle>

        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True"></FieldHeaderStyle>
        <Fields>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" InsertVisible="False" SortExpression="id"></asp:BoundField>
            <asp:BoundField DataField="test_time" HeaderText="test_time" SortExpression="test_time"></asp:BoundField>
            <asp:BoundField DataField="class" HeaderText="class" SortExpression="class"></asp:BoundField>
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title"></asp:BoundField>
            <asp:BoundField DataField="summary" HeaderText="summary" SortExpression="summary"></asp:BoundField>
            <asp:BoundField DataField="article" HeaderText="article" SortExpression="article"></asp:BoundField>
            <asp:BoundField DataField="author" HeaderText="author" SortExpression="author"></asp:BoundField>
            <asp:BoundField DataField="hit_no" HeaderText="hit_no" SortExpression="hit_no"></asp:BoundField>
            <asp:BoundField DataField="get_no" HeaderText="get_no" SortExpression="get_no"></asp:BoundField>
            <asp:BoundField DataField="email_no" HeaderText="email_no" SortExpression="email_no"></asp:BoundField>
            <asp:BoundField DataField="approved" HeaderText="approved" SortExpression="approved"></asp:BoundField>
            <asp:CommandField ShowEditButton="True"></asp:CommandField>
        </Fields>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

        <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

        <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
    </asp:DetailsView>
    <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="MyWebApplication2.Ch05.MDDataClassesDataContext" EnableDelete="True" EnableInsert="True" EnableUpdate="True" TableName="test"></asp:LinqDataSource>
    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="LinqDataSource2">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" InsertVisible="False" SortExpression="id"></asp:BoundField>
            <asp:BoundField DataField="test_id" HeaderText="test_id" SortExpression="test_id"></asp:BoundField>
            <asp:BoundField DataField="test_time" HeaderText="test_time" SortExpression="test_time"></asp:BoundField>
            <asp:BoundField DataField="article" HeaderText="article" SortExpression="article"></asp:BoundField>
            <asp:BoundField DataField="author" HeaderText="author" SortExpression="author"></asp:BoundField>
            <asp:BoundField DataField="email" HeaderText="email" SortExpression="email"></asp:BoundField>
        </Columns>

        <FooterStyle BackColor="#CCCC99" ForeColor="Black"></FooterStyle>

        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White"></HeaderStyle>

        <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>

        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

        <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#4B4B4B"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#E5E5E5"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#242121"></SortedDescendingHeaderStyle>
    </asp:GridView>

    <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource2" ContextTypeName="MyWebApplication2.Ch05.MDDataClassesDataContext" EnableDelete="True" EnableInsert="True" EnableUpdate="True" TableName="test_talk" Where="test_id == @test_id">
        <WhereParameters>
            <asp:ControlParameter ControlID="DetailsView1" PropertyName="SelectedValue" Name="test_id" Type="Int32" DefaultValue="0"></asp:ControlParameter>
        </WhereParameters>
    </asp:LinqDataSource>
    <hr />
    <asp:Label ID="Label1" runat="server" Text="DataBind code-behind" Font-Size="XX-Large"></asp:Label><br />
    <asp:GridView ID="GridView2" runat="server" DataKeyNames="id" AllowPaging="True" OnPageIndexChanging="GridView2_PageIndexChanging"></asp:GridView>
    <hr />
    <asp:GridView ID="GridView3" runat="server" DataKeyNames="id"></asp:GridView>
</asp:Content>
