<%@ Page Title="" Language="C#" MasterPageFile="~/Ch14/Ch14MasterPage.master" AutoEventWireup="true" CodeBehind="DDL.aspx.cs" Inherits="MyWebApplication.Ch14.DDL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:Label ID="msg" runat="server" Text="Label"></asp:Label>
    <br /><br /><br />
    請挑選：<br />
    <asp:DropDownList ID="DropDownList1" runat="server">

    </asp:DropDownList>
    <br /><br /><br />
    份量：<asp:TextBox ID="TextBox1" runat="server" Width="64px">0</asp:TextBox>&nbsp;
    <asp:Button ID="Button1" runat="server" Text="計算卡路里" OnClick="Button1_Click" />
    <br /><br /><br />
    卡路里：<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br /><br />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>

</asp:Content>
