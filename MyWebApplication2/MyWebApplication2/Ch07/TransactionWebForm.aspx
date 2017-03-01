<%@ Page Title="" Language="C#" MasterPageFile="~/Ch07/Ch07MasterPage.master" AutoEventWireup="true" CodeBehind="TransactionWebForm.aspx.cs" Inherits="MyWebApplication2.Ch07.TransactionWebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <h3>使用Linq and TransactionScope</h3>
    <asp:Label ID="Label1" runat="server" Text="請輸入真實姓名:"></asp:Label>
    <asp:TextBox ID="txtRealName" runat="server" Text="player1"></asp:TextBox><br/>
    <asp:Label ID="Label2" runat="server" Text="請輸入綽號:"></asp:Label>
    <asp:TextBox ID="txtName" runat="server" Text="p1"></asp:TextBox><br/>
    <asp:Label ID="Label3" runat="server" Text="請輸入密碼:"></asp:Label>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br/>
    <asp:Label ID="Label4" runat="server" Text="請選擇性別"></asp:Label>
    <asp:DropDownList ID="ddlSex" runat="server">
        <asp:ListItem Selected="True">男</asp:ListItem>
        <asp:ListItem>女</asp:ListItem>
    </asp:DropDownList><br/>
    <asp:Label ID="Label5" runat="server" Text="請輸入email"></asp:Label>
    <asp:TextBox ID="txtMail" runat="server" Text="player1@gmail.com"></asp:TextBox><br/>
    <asp:Label ID="Label6" runat="server" Text="請輸入Rank(數字)"></asp:Label>
    <asp:TextBox ID="txtRank" runat="server" Text="1"></asp:TextBox>
    <hr/>

    <asp:Label ID="Label7" runat="server" Text="請輸入真實姓名:"></asp:Label>
    <asp:TextBox ID="txtRealName2" runat="server"  Text="player2"></asp:TextBox><br/>
    <asp:Label ID="Label8" runat="server" Text="請輸入綽號:"></asp:Label>
    <asp:TextBox ID="txtName2" runat="server"  Text="p2"></asp:TextBox><br/>
    <asp:Label ID="Label9" runat="server" Text="請輸入密碼:"></asp:Label>
    <asp:TextBox ID="txtPassword2" runat="server" TextMode="Password"></asp:TextBox><br/>
    <asp:Label ID="Label10" runat="server" Text="請選擇性別"></asp:Label>
    <asp:DropDownList ID="ddlSex2" runat="server">
        <asp:ListItem Selected="True">男</asp:ListItem>
        <asp:ListItem>女</asp:ListItem>
    </asp:DropDownList><br/>
    <asp:Label ID="Label11" runat="server" Text="請輸入email"></asp:Label>
    <asp:TextBox ID="txtMail2" runat="server" Text="player2@gmail.com"></asp:TextBox><br/>
    <asp:Label ID="Label12" runat="server" Text="請輸入Rank(數字)"></asp:Label>
    <asp:TextBox ID="txtRank2" runat="server" Text="2"></asp:TextBox>
    <hr/>

    <asp:Label ID="Label13" runat="server" Text="請輸入真實姓名:"></asp:Label>
    <asp:TextBox ID="txtRealName3" runat="server" Text="player3"></asp:TextBox><br/>
    <asp:Label ID="Label14" runat="server" Text="請輸入綽號:"></asp:Label>
    <asp:TextBox ID="txtName3" runat="server" Text="p3"></asp:TextBox><br/>
    <asp:Label ID="Label15" runat="server" Text="請輸入密碼:"></asp:Label>
    <asp:TextBox ID="txtPassword3" runat="server" TextMode="Password"></asp:TextBox><br/>
    <asp:Label ID="Label16" runat="server" Text="請選擇性別"></asp:Label>
    <asp:DropDownList ID="ddlSex3" runat="server">
        <asp:ListItem Selected="True">男</asp:ListItem>
        <asp:ListItem>女</asp:ListItem>
    </asp:DropDownList><br/>
    <asp:Label ID="Label17" runat="server" Text="請輸入email"></asp:Label>
    <asp:TextBox ID="txtMail3" runat="server" Text="player3@gmail.com"></asp:TextBox><br/>
    <asp:Label ID="Label18" runat="server" Text="請輸入Rank(數字)"></asp:Label>
    <asp:TextBox ID="txtRank3" runat="server"></asp:TextBox>
    <hr />

    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
</asp:Content>
