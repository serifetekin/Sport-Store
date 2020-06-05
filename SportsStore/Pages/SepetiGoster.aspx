<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SepetiGoster.aspx.cs"
    MasterPageFile="~/Store.Master" Inherits="SportsStore.Pages.SepetiGoster" %>

<asp:Content name="sepetiGoster" ContentPlaceHolderID="bodyContent" runat="server">
    <h2>Sepetim</h2>

    <table id="sepetTablosu">
        <thead>
            <td>Miktar</td>
            <td>Ürün Adı</td>
            <td>Ürün Fiyat</td>
            <td>Ara Toplam</td>
        </thead>

        <tbody>
            <asp:Repeater ItemType="SportsStore.Models.SepetElemani" SelectMethod="SepetElemanlariniGetir" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <tr>
                        <td> <%# Item.adet %> </td>
                        <td> <%# Item.urun.Name %> </td>
                        <td> <%# Item.urun.Price %> </td>
                        <td> <%# Item.adet * Item.urun.Price %> </td>
                        <td>
                            <button type="submit" name="sil" value="<%# Item.urun.ProductID %>">Sil</button>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
        <tfoot>
           <td colspan="3"></td>
            <td><%= SepetToplami.ToString() %></td>
        </tfoot>

    </table>
</asp:Content>
