<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.ascx.cs" 
    Inherits="SportsStore.Controls.CategoryList" %>

<a href='/Pages/Listing.aspx'>Home</a>

<%
    foreach (string cat in GetCategories())
    {
        Response.Write(CreateLinkHtml(cat));
    }
%>

