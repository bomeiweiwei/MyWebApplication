<%@ Page Title="" Language="C#" MasterPageFile="~/Ch12/Ch12MasterPage.master" AutoEventWireup="true" CodeBehind="LoginWebForm3.aspx.cs" Inherits="MyWebApplication2.Ch12.LoginWebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">    
    <script type="text/javascript" src="../Scripts/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.min.js"></script>

    <script type="text/javascript" src="../Scripts/jquery.keyboard.js"></script>
    <link rel="stylesheet" type="text/css" href="../CSS/keyboard.css">
    <link rel="stylesheet" type="text/css" href="../CSS/jquery-ui.css">
    <script type='text/javascript'>//<![CDATA[ 
        $(window).load(function () {
            $(document).ready(function () {
                $('#<%=TextBox1.ClientID%>').keyboard();
                $('#<%=TextBox2.ClientID%>').keyboard({
                    layout: 'num',
                    restrictInput: true,
                    preventPaste: true,
                    autoAccept: true
                }).addTyping();
            });
        });//]]>  

    </script>

    透過System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode更改惡意參數<br/>
    帳號:<asp:TextBox ID="txtAcc" runat="server"></asp:TextBox><br/>
    密碼:<asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox><br/>
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click"/><br/>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <hr/>
    測試小鍵盤<br/>
    <asp:TextBox ID="TextBox1" runat="server" TextMode="SingleLine"></asp:TextBox><br/>
    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
</asp:Content>
