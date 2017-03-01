<%@ Page Title="" Language="C#" MasterPageFile="~/Ch16/Ch16NestedMasterPage.master" AutoEventWireup="true" CodeBehind="UserLoginSesson.aspx.cs" Inherits="MyWebApplication.Ch16.UserLoginSesson" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:Panel ID="PanelLogin" runat="server">
        姓名：<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox><br />
        密碼：<asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:Button ID="btn_Login" runat="server" Text="登 入" OnClick="btn_Login_Click" Width="230px" />
    </asp:Panel>
    <asp:Panel ID="PanelShow" runat="server">
        <asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="lblPassword" runat="server" Text="Label"></asp:Label><br />
        <asp:Button ID="btn_Logout" runat="server" Text="登 出" Width="230px" OnClick="btn_Logout_Click" />
    </asp:Panel>
    <asp:Label ID="lblMsg" runat="server" Text="gggggg"></asp:Label>
</asp:Content>
