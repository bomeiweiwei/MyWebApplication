<%@ Page Title="" Language="C#" MasterPageFile="~/Ch19/Ch19MasterPage.master" AutoEventWireup="true" CodeBehind="MasterDetail.aspx.cs" Inherits="MyWebApplication.Ch19.MasterDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <h3>ScriptManager已經在Site.Master惹</h3>
    <br />
    <br />
    <br />
    外層現在時間：<%=DateTime.Now.ToLongTimeString() %><br /><br /><br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="title" DataValueField="id"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT [id], [title] FROM [test]"></asp:SqlDataSource>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource2" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:TemplateField HeaderText="summary" SortExpression="summary">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("summary") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Height="80px" Text='<%# Bind("summary") %>' TextMode="MultiLine" Width="340px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="article" SortExpression="article">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("article") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Height="80px" Text='<%# Bind("article") %>' TextMode="MultiLine" Width="340px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="author" HeaderText="author" SortExpression="author" />
                    <asp:BoundField DataField="hit_no" HeaderText="hit_no" SortExpression="hit_no" />
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
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT [summary], [article], [author], [hit_no] FROM [test] WHERE ([id] = @id)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="id" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            內層現在時間：<%=DateTime.Now.ToLongTimeString() %><br />
        </ContentTemplate>
    </asp:UpdatePanel>

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js">
    </script>

    <script>
        function HelloWorld() {
            try {
                var options = {
                    type: "POST",
                    url: "<%=ResolveUrl("~/WebService1.asmx/HelloWorld")%>",
                    data: null,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        if (msg.d != "") {
                            alert(msg.d);
                        }
                        else {
                            return false;
                        }
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert(xhr.status + "  " + thrownError + "  " + ajaxOptions);
                    }
                };

                $.ajax(options);
            }
            catch (ex) {
                alert("Error");
            }
            return false;
        }
</script>
    <asp:Button runat="server" ID="btnCall" Text="Click to Call" OnClientClick="HelloWorld(); return false;" />
</asp:Content>
