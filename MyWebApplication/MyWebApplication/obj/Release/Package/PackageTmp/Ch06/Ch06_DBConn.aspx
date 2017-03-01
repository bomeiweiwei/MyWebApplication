<%@ Page Title="" Language="C#" MasterPageFile="~/Ch06/Ch06MasterPage.master" AutoEventWireup="true" CodeBehind="Ch06_DBConn.aspx.cs" Inherits="MyWebApplication.Ch06.Ch06_DBConn" %>
<%@ Import Namespace = "System.Data" %>
<%@ Import Namespace = "System.Data.SqlClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <% 
        SqlConnection conn = new SqlConnection("server=.\\SQLEXPRESS;Initial Catalog=test;User ID=dbtest;Password=dbtest0000"); 
        conn.Open();
        SqlCommand cmd=new SqlCommand("select top 10 id,test_time,title from test",conn);
        SqlDataReader dr=cmd.ExecuteReader();
        while(dr.Read()){
            Response.Write("id="+Convert.ToString(dr["id"])+"<br>");
            Response.Write("test_time="+Convert.ToString(dr["test_time"])+"<br>");
            Response.Write("title="+Convert.ToString(dr["title"])+"<br>");
            Response.Write("<hr>");
        }
        cmd.Cancel();
        dr.Close();        
        conn.Close();
       %>
</asp:Content>
