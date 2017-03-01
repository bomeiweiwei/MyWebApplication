<%@ Page Title="" Language="C#" MasterPageFile="~/Ch05/Ch05MasterPage.master" AutoEventWireup="true" CodeBehind="LinqTransactionWebForm.aspx.cs" Inherits="MyWebApplication2.Ch05.LinqTransactionWebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="請輸入真實姓名:"></asp:Label>
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br/>
    <asp:Label ID="Label2" runat="server" Text="請輸入綽號:"></asp:Label>
    <asp:TextBox ID="txtName2" runat="server"></asp:TextBox><br/>
    <asp:Label ID="Label3" runat="server" Text="請輸入密碼:"></asp:Label>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br/>
    <asp:Label ID="Label4" runat="server" Text="請選擇性別"></asp:Label>
    <asp:DropDownList ID="ddlSex" runat="server">
        <asp:ListItem Selected="True">男</asp:ListItem>
        <asp:ListItem>女</asp:ListItem>
    </asp:DropDownList><br/>
    <asp:Label ID="Label5" runat="server" Text="請輸入email"></asp:Label>
    <asp:TextBox ID="txtMail" runat="server"></asp:TextBox><br/>
    <asp:Button ID="btn_Submit" runat="server" Text="一般SqlCommand新增法" OnClick="btn_Submit_Click" />
    <asp:Button ID="btn_Submit2" runat="server" Text="Linq新增法" OnClick="btn_Submit2_Click"/>
    <asp:Label ID="lblInsertMsg" runat="server" Text=""></asp:Label>
    <hr/>
    <asp:Label ID="Label6" runat="server" Text="真實姓名"></asp:Label>
    <asp:TextBox ID="txtDelete" runat="server"></asp:TextBox><asp:Button ID="btn_Delete" runat="server" Text="刪除" OnClick="btn_Delete_Click" />
    <asp:Label ID="lblDelete" runat="server" Text=""></asp:Label>
    <hr/>
    <asp:Label ID="Label7" runat="server" Text="真實姓名"></asp:Label>
    <asp:TextBox ID="TxtSearchName" runat="server"></asp:TextBox><br/>
    <asp:Label ID="Label8" runat="server" Text="E-mail"></asp:Label>
    <asp:TextBox ID="txtUpdate" runat="server"></asp:TextBox>
    <asp:Button ID="btn_Update" runat="server" Text="更新email" OnClick="btn_Update_Click" />
    <asp:Label ID="lblUpdate" runat="server" Text=""></asp:Label>
    <hr/>
    </asp:Content>
