<%@ Page Title="" Language="C#" MasterPageFile="~/Ch04/Ch04MasterPage.master" AutoEventWireup="true" CodeBehind="ObjectDataSource2_1.aspx.cs" Inherits="MyWebApplication2.Ch04.ObjectDataSource2_1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="透過事件抓取選取的值，再配對"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="OrderID" DataSourceID="ObjectDataSource1" ForeColor="Black" GridLines="Vertical" PageSize="5" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
            <asp:BoundField DataField="OrderID" HeaderText="OrderID" InsertVisible="False" ReadOnly="True" SortExpression="OrderID" />
            <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" SortExpression="CustomerID" />
            <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" SortExpression="EmployeeID" />
            <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" SortExpression="OrderDate" />
            <asp:BoundField DataField="RequiredDate" HeaderText="RequiredDate" SortExpression="RequiredDate" />
            <asp:BoundField DataField="ShippedDate" HeaderText="ShippedDate" SortExpression="ShippedDate" />
            <asp:BoundField DataField="ShipVia" HeaderText="ShipVia" SortExpression="ShipVia" />
            <asp:BoundField DataField="Freight" HeaderText="Freight" SortExpression="Freight" />
            <asp:BoundField DataField="ShipName" HeaderText="ShipName" SortExpression="ShipName" />
            <asp:BoundField DataField="ShipAddress" HeaderText="ShipAddress" SortExpression="ShipAddress" />
            <asp:BoundField DataField="ShipCity" HeaderText="ShipCity" SortExpression="ShipCity" />
            <asp:BoundField DataField="ShipRegion" HeaderText="ShipRegion" SortExpression="ShipRegion" />
            <asp:BoundField DataField="ShipPostalCode" HeaderText="ShipPostalCode" SortExpression="ShipPostalCode" />
            <asp:BoundField DataField="ShipCountry" HeaderText="ShipCountry" SortExpression="ShipCountry" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="MyWebApplication2.Ch04.DataSet_NorthWindTableAdapters.OrdersTableAdapter" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_OrderID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CustomerID" Type="String" />
            <asp:Parameter Name="EmployeeID" Type="Int32" />
            <asp:Parameter Name="OrderDate" Type="DateTime" />
            <asp:Parameter Name="RequiredDate" Type="DateTime" />
            <asp:Parameter Name="ShippedDate" Type="DateTime" />
            <asp:Parameter Name="ShipVia" Type="Int32" />
            <asp:Parameter Name="Freight" Type="Decimal" />
            <asp:Parameter Name="ShipName" Type="String" />
            <asp:Parameter Name="ShipAddress" Type="String" />
            <asp:Parameter Name="ShipCity" Type="String" />
            <asp:Parameter Name="ShipRegion" Type="String" />
            <asp:Parameter Name="ShipPostalCode" Type="String" />
            <asp:Parameter Name="ShipCountry" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="CustomerID" Type="String" />
            <asp:Parameter Name="EmployeeID" Type="Int32" />
            <asp:Parameter Name="OrderDate" Type="DateTime" />
            <asp:Parameter Name="RequiredDate" Type="DateTime" />
            <asp:Parameter Name="ShippedDate" Type="DateTime" />
            <asp:Parameter Name="ShipVia" Type="Int32" />
            <asp:Parameter Name="Freight" Type="Decimal" />
            <asp:Parameter Name="ShipName" Type="String" />
            <asp:Parameter Name="ShipAddress" Type="String" />
            <asp:Parameter Name="ShipCity" Type="String" />
            <asp:Parameter Name="ShipRegion" Type="String" />
            <asp:Parameter Name="ShipPostalCode" Type="String" />
            <asp:Parameter Name="ShipCountry" Type="String" />
            <asp:Parameter Name="Original_OrderID" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <br />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderID,ProductID" DataSourceID="">
        <Columns>
            <asp:BoundField DataField="OrderID" HeaderText="OrderID" ReadOnly="True" SortExpression="OrderID" />
            <asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="True" SortExpression="ProductID" />
            <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            <asp:BoundField DataField="Discount" HeaderText="Discount" SortExpression="Discount" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="MyWebApplication2.Ch04.DataSet_NorthWindTableAdapters.Order_DetailsTableAdapter" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_OrderID" Type="Int32" />
            <asp:Parameter Name="Original_ProductID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="OrderID" Type="Int32" />
            <asp:Parameter Name="ProductID" Type="Int32" />
            <asp:Parameter Name="UnitPrice" Type="Decimal" />
            <asp:Parameter Name="Quantity" Type="Int16" />
            <asp:Parameter Name="Discount" Type="Single" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="UnitPrice" Type="Decimal" />
            <asp:Parameter Name="Quantity" Type="Int16" />
            <asp:Parameter Name="Discount" Type="Single" />
            <asp:Parameter Name="Original_OrderID" Type="Int32" />
            <asp:Parameter Name="Original_ProductID" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <br />
</asp:Content>
