<%@ Page Title="" Language="C#" MasterPageFile="~/Ch01/Ch01MasterPage.master" AutoEventWireup="true" CodeBehind="MasterPageTest.aspx.cs" Inherits="MyWebApplication.Ch01_II.MasterPageTest" %>
<%@ MasterType VirtualPath="~/Ch01/Ch01MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>
    <hr />
    <h3>透過FindControl(要逐層才能找到)<h3>
    <asp:Button ID="btn_Show" runat="server" Text="將MasterPage的圖片顯示" OnClick="btn_Show_Click" />
    <asp:Button ID="btn_hidden" runat="server" Text="將MasterPage的圖片隱藏" OnClick="btn_hidden_Click" />
    <h3>透過主版頁面的公用屬性<h3>
    <asp:Button ID="btn_Show3" runat="server" Text="將MasterPage的圖片顯示" OnClick="btn_Show2_Click1"  />
    <asp:Button ID="btn_hidden3" runat="server" Text="將MasterPage的圖片隱藏" OnClick="btn_hidden2_Click"  />
    <br />
    <asp:Label ID="Label1" runat="server"></asp:Label><br />
    <asp:Button ID="btn_Show2" runat="server" Text="將MasterPage的文字顯示" OnClick="btn_Show2_Click" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT * FROM [test]"></asp:SqlDataSource>
</asp:Content>
