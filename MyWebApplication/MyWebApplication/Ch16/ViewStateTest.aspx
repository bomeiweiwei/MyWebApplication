<%@ Page Title="" Language="C#" MasterPageFile="~/Ch16/Ch16NestedMasterPage.master" AutoEventWireup="true" CodeBehind="ViewStateTest.aspx.cs" Inherits="MyWebApplication.Ch16.ViewStateTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:Button ID="btn_SetArrayList" runat="server" Text="設定ArrayList" OnClick="btn_SetArrayList_Click" /><br />
    <asp:DropDownList ID="ddl_GetArrayList" runat="server">
        <asp:ListItem>沒有東西</asp:ListItem>
    </asp:DropDownList>
</asp:Content>
