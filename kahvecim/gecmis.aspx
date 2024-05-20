<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gecmis.aspx.cs" Inherits="kahvecim.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 900px;
        }
        .auto-style2 {
            width: 335px;
            height: 50px;
        }
        .auto-style3 {
            height: 50px;
        }
    </style>
   <link href="tasarım.css" rel="stylesheet"/>
</head>
<body bgcolor="#F2C5A3">
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <div class="auto-style2">
                        <div class="auto-style2">
                    <td colspan="2" align="right" height="60px">
                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Names="Franklin Gothic Medium" Font-Size="Large" Font-Underline="False" ForeColor="White" OnClick="LinkButton1_Click">❌ Çıkış Yap</asp:LinkButton> </td>
                </tr>
                <tr>
                    <td colspan="2"><img alt="" class="banner" src="resimler/logo.jpg" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Label" BorderColor="Black" Font-Bold="True" Font-Names="Franklin Gothic Medium" Font-Size="X-Large" ForeColor="White"></asp:Label>
                    </td>
                    <td colspan="2" align="right" class="auto-style3">
                        <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Franklin Gothic Medium" Font-Overline="False" Font-Size="XX-Large" Font-Strikeout="False" Font-Underline="False" ForeColor="White" OnClick="LinkButton2_Click">🛒 Kahve Sepetim</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <br /><br />
                        <asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Franklin Gothic Medium" Font-Size="X-Large" Font-Underline="False" ForeColor="White" OnClick="LinkButton3_Click">Ana Sayfaya Dön</asp:LinkButton>
                    </td>
                    <td align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server" Text="Sipariş Geçmişi" Font-Bold="True" Font-Italic="True" Font-Names="Franklin Gothic Medium" Font-Size="XX-Large" ForeColor="White"></asp:Label>
                        <br /><br /><br /><br /><br /><br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Repeater ID="rpturun" runat="server">
                            <ItemTemplate>
                                 <div class="urun">
                                            <div class="urunbaslik">
                                                <%#Eval("urun_adi") %>
                                            </div>
                                            <div>
                                                
                                                <img src="resimler/<%#Eval("urun_id") %>.PNG" class="urunresim" border="0" /></a>
                                                <div class="urunfiyat">
                                                    Fiyat: <%#Eval("urun_fiyat") %> ₺ 
                                                    Adet: <%#Eval("urun_miktar") %>
                                                </div>
                                            </div>
                                        </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td height="40px" bgcolor="#F2C5A3" colspan="2" align="center">
                                <asp:Repeater ID="rptiletisim" runat="server">
                                    <ItemTemplate>
                        <div class="iletisim">Telefon : <%#Eval("tel")%>  •  E-posta : <%#Eval("e_posta")%>  •  Adres : <%#Eval("adres")%></div>
                                </ItemTemplate>  
                                </asp:Repeater>

                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
