<%@ Page Title="" Language="C#" MasterPageFile="~/Ch11/Ch11MasterPage.master" AutoEventWireup="true" CodeBehind="Ch11_DSetRowDataBound.aspx.cs" Inherits="MyWebApplication.Ch11.Ch11_DSetRowDataBound" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" 
        OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="id" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="real_name" HeaderText="real_name" SortExpression="real_name" />
            <asp:TemplateField HeaderText="sex" SortExpression="sex">
                <EditItemTemplate>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:RadioButtonList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:RadioButtonList>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" DeleteCommand="DELETE FROM [db_user] WHERE [id] = @id" InsertCommand="INSERT INTO [db_user] ([real_name], [sex]) VALUES (@real_name, @sex)" SelectCommand="SELECT [id], [real_name], [sex] FROM [db_user]" UpdateCommand="UPDATE [db_user] SET [real_name] = @real_name, [sex] = @sex WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="real_name" Type="String" />
            <asp:Parameter Name="sex" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="real_name" Type="String" />
            <asp:Parameter Name="sex" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
