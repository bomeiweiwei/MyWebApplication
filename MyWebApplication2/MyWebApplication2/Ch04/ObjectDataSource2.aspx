<%@ Page Title="" Language="C#" MasterPageFile="~/Ch04/Ch04MasterPage.master" AutoEventWireup="true" CodeBehind="ObjectDataSource2.aspx.cs" Inherits="MyWebApplication2.Ch04.ObjectDataSource2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Count : "></asp:Label>
    <asp:Label ID="lblCount" runat="server" Text="0"></asp:Label><br />
    <asp:Label ID="Label2" runat="server" Text="透過工具自動配對"></asp:Label><br />
    <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" AutoGenerateRows="False" DataKeyNames="OrderID" DataSourceID="ObjectDataSource1" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>

        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True"></CommandRowStyle>

        <EditRowStyle BackColor="#999999"></EditRowStyle>

        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True"></FieldHeaderStyle>
        <Fields>
            <asp:BoundField DataField="OrderID" HeaderText="OrderID" ReadOnly="True" InsertVisible="False" SortExpression="OrderID"></asp:BoundField>
            <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" SortExpression="CustomerID"></asp:BoundField>
            <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" SortExpression="EmployeeID"></asp:BoundField>
            <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" SortExpression="OrderDate"></asp:BoundField>
            <asp:BoundField DataField="RequiredDate" HeaderText="RequiredDate" SortExpression="RequiredDate"></asp:BoundField>
            <asp:BoundField DataField="ShippedDate" HeaderText="ShippedDate" SortExpression="ShippedDate"></asp:BoundField>
            <asp:BoundField DataField="ShipVia" HeaderText="ShipVia" SortExpression="ShipVia"></asp:BoundField>
            <asp:BoundField DataField="Freight" HeaderText="Freight" SortExpression="Freight"></asp:BoundField>
            <asp:BoundField DataField="ShipName" HeaderText="ShipName" SortExpression="ShipName"></asp:BoundField>
            <asp:BoundField DataField="ShipAddress" HeaderText="ShipAddress" SortExpression="ShipAddress"></asp:BoundField>
            <asp:BoundField DataField="ShipCity" HeaderText="ShipCity" SortExpression="ShipCity"></asp:BoundField>
            <asp:BoundField DataField="ShipRegion" HeaderText="ShipRegion" SortExpression="ShipRegion"></asp:BoundField>
            <asp:BoundField DataField="ShipPostalCode" HeaderText="ShipPostalCode" SortExpression="ShipPostalCode"></asp:BoundField>
            <asp:BoundField DataField="ShipCountry" HeaderText="ShipCountry" SortExpression="ShipCountry"></asp:BoundField>
        </Fields>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

        <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

        <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
    </asp:DetailsView>
    <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="MyWebApplication2.Ch04.DataSet_NorthWindTableAdapters.OrdersTableAdapter" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_OrderID" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CustomerID" Type="String"></asp:Parameter>
            <asp:Parameter Name="EmployeeID" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="OrderDate" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="RequiredDate" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="ShippedDate" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="ShipVia" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="Freight" Type="Decimal"></asp:Parameter>
            <asp:Parameter Name="ShipName" Type="String"></asp:Parameter>
            <asp:Parameter Name="ShipAddress" Type="String"></asp:Parameter>
            <asp:Parameter Name="ShipCity" Type="String"></asp:Parameter>
            <asp:Parameter Name="ShipRegion" Type="String"></asp:Parameter>
            <asp:Parameter Name="ShipPostalCode" Type="String"></asp:Parameter>
            <asp:Parameter Name="ShipCountry" Type="String"></asp:Parameter>
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="CustomerID" Type="String"></asp:Parameter>
            <asp:Parameter Name="EmployeeID" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="OrderDate" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="RequiredDate" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="ShippedDate" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="ShipVia" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="Freight" Type="Decimal"></asp:Parameter>
            <asp:Parameter Name="ShipName" Type="String"></asp:Parameter>
            <asp:Parameter Name="ShipAddress" Type="String"></asp:Parameter>
            <asp:Parameter Name="ShipCity" Type="String"></asp:Parameter>
            <asp:Parameter Name="ShipRegion" Type="String"></asp:Parameter>
            <asp:Parameter Name="ShipPostalCode" Type="String"></asp:Parameter>
            <asp:Parameter Name="ShipCountry" Type="String"></asp:Parameter>
            <asp:Parameter Name="Original_OrderID" Type="Int32"></asp:Parameter>
        </UpdateParameters>
    </asp:ObjectDataSource>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderID,ProductID" DataSourceID="ObjectDataSource3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
        <Columns>
            <asp:BoundField DataField="OrderID" HeaderText="OrderID" ReadOnly="True" SortExpression="OrderID"></asp:BoundField>
            <asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="True" SortExpression="ProductID"></asp:BoundField>
            <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice"></asp:BoundField>
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"></asp:BoundField>
            <asp:BoundField DataField="Discount" HeaderText="Discount" SortExpression="Discount"></asp:BoundField>
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
    <asp:ObjectDataSource runat="server" ID="ObjectDataSource3" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByOrderID" TypeName="MyWebApplication2.Ch04.DataSet_NorthWindTableAdapters.Order_DetailsTableAdapter" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_OrderID" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="Original_ProductID" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="OrderID" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="ProductID" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="UnitPrice" Type="Decimal"></asp:Parameter>
            <asp:Parameter Name="Quantity" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="Discount" Type="Single"></asp:Parameter>
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="DetailsView1" PropertyName="SelectedValue" Name="OrderID" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="UnitPrice" Type="Decimal"></asp:Parameter>
            <asp:Parameter Name="Quantity" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="Discount" Type="Single"></asp:Parameter>
            <asp:Parameter Name="Original_OrderID" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="Original_ProductID" Type="Int32"></asp:Parameter>
        </UpdateParameters>
    </asp:ObjectDataSource>
</asp:Content>
