<%@ Page Title="" Language="C#" MasterPageFile="~/Ch02/Ch02MasterPage.master" AutoEventWireup="true" CodeBehind="Ch02_Login.aspx.cs" Inherits="MyWebApplication2.Ch02.Ch02_Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>
    <hr />
    <asp:LoginView ID="LoginView1" runat="server"> 
    <AnonymousTemplate> 
      <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate"></asp:Login>
      <asp:Label ID="lblErrMsg" runat="server" ForeColor="Red" /> 
    </AnonymousTemplate> 
    <LoggedInTemplate> 
        Hello,
        <asp:LoginName ID="LoginName1" runat="server" /> 
        <br /> 
        <asp:LoginStatus ID="LoginStatus1" runat="server" LoginText="" LogoutText="登出" /> 
    </LoggedInTemplate> 
    </asp:LoginView>

    <br />
    <asp:Label ID="Label1" runat="server" Text="http://www.dotblogs.com.tw/topcat/archive/2008/03/05/1237.aspx"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="http://www.dotblogs.com.tw/a93701011/archive/2015/01/30/148319.aspx"></asp:Label>
    <hr />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
</asp:Content>
