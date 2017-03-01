<%@ Page Title="" Language="C#" MasterPageFile="~/Ch11/Ch11MasterPage.master" AutoEventWireup="true" CodeBehind="Ch11_MTableJoin.aspx.cs" Inherits="MyWebApplication.Ch11.Ch11_MTableJoin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
     <div>
         <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="id,t_id" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Horizontal">
             <Columns>
                 <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                 <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                 <asp:BoundField DataField="test_time" HeaderText="test_time" SortExpression="test_time" />
                 <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                 <asp:BoundField DataField="summary" HeaderText="summary" SortExpression="summary" />
                 <asp:BoundField DataField="t_id" HeaderText="t_id" InsertVisible="False" ReadOnly="True" SortExpression="t_id" />
                 <asp:BoundField DataField="test_id" HeaderText="test_id" SortExpression="test_id" />
                 <asp:BoundField DataField="t_test_time" HeaderText="t_test_time" SortExpression="t_test_time" />
                 <asp:BoundField DataField="t_article" HeaderText="t_article" SortExpression="t_article" />
                 <asp:BoundField DataField="t_author" HeaderText="t_author" SortExpression="t_author" />
                 <asp:BoundField DataField="t_email" HeaderText="t_email" SortExpression="t_email" />
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
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT test.id, test.test_time, test.title, test.summary, test_talk.id AS t_id, test_talk.test_id, test_talk.test_time AS t_test_time, test_talk.article AS t_article, test_talk.author AS t_author, test_talk.email AS t_email FROM test INNER JOIN test_talk ON test.id = test_talk.test_id order by test.id"></asp:SqlDataSource>
    </div>
</asp:Content>
