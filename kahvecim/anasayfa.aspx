<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="anasayfa.aspx.cs" Inherits="kahvecim.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 900px;
            height: 1117px;
        }
        .auto-style3 {
            width: 335px;
            height: 590px;
        }
        .auto-style4 {
            height: 590px;
        }
        .auto-style5 {
            width: 335px;
            height: 50px;
        }
        .auto-style6 {
            height: 50px;
        }
        .auto-style7 {
            background-color: black;
            text-align: center;
            font-style: oblique;
            color: white;
            font-size: 25px;
            margin-top: 2px;
        }
        </style>
    <link href="tasarım.css" rel="stylesheet"/>
</head>
<body bgcolor="#F2C5A3">
    <form id="form1" runat="server">
        <div>
            <table align="center" cellpadding="0" cellspacing="0" class="auto-style1">
                <tr>
                    <td colspan="3" align="right" height="60px">
                        <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" Font-Names="Franklin Gothic Medium" Font-Size="Large" Font-Underline="False" ForeColor="White" OnClick="LinkButton2_Click">❌ Çıkış Yap</asp:LinkButton> </td>
                    </tr>
                    <tr>
                    <div class="auto-style5">
                        <div class="auto-style5">
                            <td colspan="3">
                                <img alt="" class="banner" src="resimler/logo.jpg" /> </td>
                            
                </tr>
                        <tr>
                            <td class="auto-style5">
                                <asp:Button ID="Button1" runat="server" Text="Kullanıcı Girişi" BackColor="Black" ForeColor="White" Height="50px" Font-
                                    Bold="True" Font-Italic="False" Font-Names="Franklin Gothic Medium" Font-Size="Large" OnClick="Button1_Click" />
                            <asp:Label ID="Label3" runat="server" Text="Label" BorderColor="Black" Font-Bold="True" Font-Names="Franklin Gothic Medium" Font-Size="X-Large" ForeColor="White"></asp:Label></td>
                            <td colspan="2" align="right" class="auto-style6">
                                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Franklin Gothic Medium" Font-Overline="False" Font-Size="XX-Large" Font-Strikeout="False" Font-Underline="False" ForeColor="Black" OnClick="LinkButton1_Click">🛒 Kahve Sepetim</asp:LinkButton> </td>
                        </tr>
                        <tr>
                            <td class="literal">
                                <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="White"></asp:Label>
                                <br>
                                <asp:Label ID="Label2" runat="server" Text="Label" ForeColor="White"></asp:Label>
                            </td>
                            <td bgcolor="#F2C5A3" colspan="2" align="right">
                                 </td>
                        </tr>
                        <tr>
                            <td class="auto-style3" valign="top" bgcolor="#F2C5A3">
                                <div class="auto-style7">
                                    Kategoriler</div>
                                <asp:Repeater ID="rptkategori" runat="server">
                                    <ItemTemplate>
                                        <a style="text-decoration:none" href="?ktgr_id=<%#Eval("kategori_id")%>&ktgr_adi=<%#Eval("kategori_ad") %>">
                                        <div class="bolumicerik">
                                            <%#Eval("kategori_ad") %>
                                        </div>
                                        </a>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <div class="bolumbaslik">
                                    Marka</div>
                                <asp:Repeater ID="rptmarka" runat="server">
                                    <ItemTemplate>
                                        <a style="text-decoration:none" href="?marka_id=<%#Eval("marka_id")%>&marka_adi=<%#Eval("marka_ad") %>">
                                        <div class="bolumicerik">
                                            <%#Eval("marka_ad") %>
                                        </div>
                                        </a>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                            <td border="2" valign="top" width="1200" class="auto-style4">
                                <asp:Repeater ID="rpturun" runat="server" OnItemCommand="rpturun_ItemCommand">
                                    <ItemTemplate>
                                        <div class="urun">
                                            <div class="urunbaslik">
                                                <%#Eval("urun_ad") %>
                                            </div>
                                            <div>
                                                <a href="urun.aspx?urunid=<%# Eval("id") %>">
                                                <img src="resimler/<%#Eval("urun_resim") %>" class="urunresim" border="0" /></a>
                                                <div class="urunfiyat">
                                                    Fiyat: <%#Eval("urun_fiyat") %> ₺ 
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                            </td>
                            
                        </tr>
                        <tr>
                            <td  height="40px" bgcolor="#3C3741" colspan="3" align="center">
                                <asp:Repeater ID="rptiletisim" runat="server">
                                    <ItemTemplate>
                        <div class="iletisim">Telefon : <%#Eval("tel")%>  •  E-posta : <%#Eval("e_posta")%>  •  Adres : <%#Eval("adres")%></div>
                                </ItemTemplate>  
                                </asp:Repeater>
                            </td>
                        </div>
                </tr>
            </table>
    </form>
</body>
</html>
