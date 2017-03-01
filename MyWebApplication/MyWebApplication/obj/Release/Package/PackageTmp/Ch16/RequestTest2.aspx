<%@ Page Title="" Language="C#" MasterPageFile="~/Ch16/Ch16NestedMasterPage.master" AutoEventWireup="true" CodeBehind="RequestTest2.aspx.cs" Inherits="MyWebApplication.Ch16.RequestTest2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <h3>透過FindControl(要逐層才能找到)<h3>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label><br />
</asp:Content>
