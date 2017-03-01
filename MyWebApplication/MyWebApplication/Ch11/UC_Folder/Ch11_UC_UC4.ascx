<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ch11_UC_UC4.ascx.cs" Inherits="MyWebApplication.Ch11.Ch11_UC_UC4" %>
<asp:Label ID="Label1" runat="server" Text="你覺得今天心情如何?"></asp:Label><p>
<p>
    &nbsp;</p>
<asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
    <asp:ListItem Value="0">超好</asp:ListItem>
    <asp:ListItem Value="1">好</asp:ListItem>
    <asp:ListItem Selected="True" Value="2">普通</asp:ListItem>
    <asp:ListItem Value="3">不好</asp:ListItem>
    <asp:ListItem Value="4">超爛</asp:ListItem>
</asp:RadioButtonList>
<asp:Label ID="lblNote" runat="server" Text=""></asp:Label>
