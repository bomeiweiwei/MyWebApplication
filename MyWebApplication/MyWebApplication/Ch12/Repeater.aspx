<%@ Page Title="" Language="C#" MasterPageFile="~/Ch12/Ch12MasterPage.master" AutoEventWireup="true" CodeBehind="Repeater.aspx.cs" Inherits="MyWebApplication.Ch12.Repeater" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        <HeaderTemplate>
            <table>
                <tr>
                <td>id</td>
                <td>Date&Time</td>
                <td>Title</td>
                <td>Summary</td>
                </tr>   
        </HeaderTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%#DataBinder.Eval(Container.DataItem,"id") %></td>
                        <td><%#DataBinder.Eval(Container.DataItem,"test_time","{0:d}") %></td>
                        <td><%#DataBinder.Eval(Container.DataItem,"title") %></td>
                        <td><%#DataBinder.Eval(Container.DataItem,"summary") %></td>
                    </tr>
                </ItemTemplate>

        <FooterTemplate>
            </table>
        </FooterTemplate>


        
    </asp:Repeater>
    <table border="1" style="width: 90%;">
            <tr>
                <td>id</td>
                <td>Date&Time</td>
                <td>Title</td>
                <td>Summary</td>
            </tr>           
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT [id], [test_time], [title], [summary] FROM [test]"></asp:SqlDataSource>
</asp:Content>
