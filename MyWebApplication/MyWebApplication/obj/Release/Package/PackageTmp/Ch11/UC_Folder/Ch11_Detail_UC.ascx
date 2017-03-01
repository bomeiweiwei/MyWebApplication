<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ch11_Detail_UC.ascx.cs" Inherits="MyWebApplication.Ch11.UC_Folder.Ch11_Detail_UC" %>
<asp:GridView ID="GridViewDetail" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="id" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical">
    <AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
        <asp:TemplateField HeaderText="article" SortExpression="article">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("article") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server" Height="115px" Text='<%# Bind("article") %>' TextMode="MultiLine" Width="800px"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="author" HeaderText="author" SortExpression="author" />
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
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT [id], [article], [author] FROM [test] WHERE ([id] = @id)">
    <SelectParameters>
        <asp:ControlParameter ControlID="GridViewMaster" Name="id" PropertyName="SelectedValue" Type="Int32" />
    </SelectParameters>
</asp:SqlDataSource>

