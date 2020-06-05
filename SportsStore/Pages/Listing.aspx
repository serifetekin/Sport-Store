<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" 
    MasterPageFile="~/Store.Master" Inherits="SportsStore.Pages.Listing" %>

<%@ Import Namespace="SportsStore.Models" %>


<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <asp:Repeater ItemType="SportsStore.Models.Product" SelectMethod="GetProducts" runat="server" >
            <ItemTemplate>
                <div class="item">
                    <h3> <%# Item.Name %> </h3>
                    <p>  <%# Item.Description %> </p>
                    <h4> <%# Item.Price %></h4>
                    <button name="ekle" type="submit" value="<%# Item.ProductID %>">Sepete Ekle</button>
                </div>
            </ItemTemplate>
        </asp:Repeater>


    </div>

    <div class="pager">
        <%
            for(int i=1; i<=MaxPage; i++)
            {
                Response.Write(string.Format("<a href='/Pages/Listing.aspx?page={0}&category={3}'{1}>{2}</a>"
                    , i, i == CurrentPage ? "class='selected'": "", i, CurrentCategory));
            }
        %>
    </div>

</asp:Content>

