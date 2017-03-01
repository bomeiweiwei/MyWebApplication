<%@ Page Title="" Language="C#" MasterPageFile="~/Ch16/Ch16NestedMasterPage.master" AutoEventWireup="true" CodeBehind="RequestTest.aspx.cs" Inherits="MyWebApplication.Ch16.RequestTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <h3>對網頁傳參數?xxx=111&bbb=222</h3>
    <asp:TextBox ID="txtNum1" runat="server" >0</asp:TextBox>&nbsp;
    +<asp:TextBox ID="txtNum2" runat="server" >0</asp:TextBox>&nbsp;
    =&nbsp;
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label><br />
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    <br /><br /><br />
    <hr />
    <h3>對網頁傳物件</h3>
    <asp:Button ID="Button2" runat="server" Text="Server.Transfer" OnClick="Button2_Click" />
</asp:Content>
