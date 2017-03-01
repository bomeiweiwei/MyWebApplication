<%@ Page Title="" Language="C#" MasterPageFile="~/Ch08/Ch08MasterPage.master" AutoEventWireup="true" CodeBehind="Ch08_GridView2.aspx.cs" Inherits="MyWebApplication.Ch08.Ch08_GridView2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="id" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="real_name" HeaderText="real_name" SortExpression="real_name" />
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
            <asp:TemplateField HeaderText="sex" SortExpression="sex">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("sex") %>'>
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("sex") %>'></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="60px" />
            </asp:TemplateField>
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" DeleteCommand="DELETE FROM [db_user] WHERE [id] = @id" InsertCommand="INSERT INTO [db_user] ([real_name], [name], [sex], [email]) VALUES (@real_name, @name, @sex, @email)" SelectCommand="SELECT [id], [real_name], [name], [sex], [email] FROM [db_user]" UpdateCommand="UPDATE [db_user] SET [real_name] = @real_name, [name] = @name, [sex] = @sex, [email] = @email WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="real_name" Type="String" />
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="sex" Type="String" />
            <asp:Parameter Name="email" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="real_name" Type="String" />
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="sex" Type="String" />
            <asp:Parameter Name="email" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
