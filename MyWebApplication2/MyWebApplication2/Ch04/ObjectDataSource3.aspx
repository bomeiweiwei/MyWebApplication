<%@ Page Title="" Language="C#" MasterPageFile="~/Ch04/Ch04MasterPage.master" AutoEventWireup="true" CodeBehind="ObjectDataSource3.aspx.cs" Inherits="MyWebApplication2.Ch04.ObjectDataSource3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="自行呼叫類別方法getAll()"></asp:Label><br />
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="EmployeeID" DataSourceID="ObjectDataSource1" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
         <Columns>
           <asp:CommandField  ShowSelectButton="True"/>
            <asp:BoundField DataField="EmployeeID" HeaderText="ID" ReadOnly="True"></asp:BoundField>
            <asp:BoundField DataField="FirstName" HeaderText="名" ReadOnly="True"></asp:BoundField>
            <asp:BoundField DataField="LastName" HeaderText="姓"></asp:BoundField>
            <asp:BoundField DataField="Title" HeaderText="標題"></asp:BoundField>
            <asp:BoundField DataField="Courtesy" HeaderText="XXX"></asp:BoundField>
            <asp:BoundField DataField="Supervisor" HeaderText="OOO"></asp:BoundField>
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
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getAll" TypeName="MyWebApplication2.Ch04.EmployeeLogic"></asp:ObjectDataSource>
</asp:Content>
