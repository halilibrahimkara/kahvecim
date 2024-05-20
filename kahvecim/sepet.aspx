<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sepet.aspx.cs" Inherits="kahvecim.WebForm3" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 1173px;
            height: 258px;
        }
        .iletisim {
            display: inline-block;
            background-color: #3C3741;
            color: #ffffff;
            text-decoration: none;
            list-style-type: none;
            font-size: 15px;
        }
        .auto-style3 {
            width: 947px;
            height: 120px;
        }
        .auto-style4 {
            width: 254px;
        }
    </style>
    <link href="tasarım.css" rel="stylesheet"/>
</head>
<body bgcolor="#F2C5A3">
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1" align="center">
                <tr>
                    <td colspan="3" align="right" height="60px">
                        <asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="True" Font-Names="Franklin Gothic Medium" Font-Size="X-Large" Font-Underline="False" ForeColor="White" OnClick="LinkButton3_Click">❌ Çıkış Yap</asp:LinkButton>
                </tr>
                <tr>
                    <div class="auto-style2">
                    <td colspan="3">
                        <img alt="" class="banner" src="https://localhost:44376/resimler/logo.jpg" height="400px" width="1500px"/>
                    </td>
                </tr>
                <tr>
                    <td width="300px" colspan="3" height="60px">
                        <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True" Font-Names="Franklin Gothic Medium" Font-Size="X-Large" ForeColor="White"></asp:Label>
                        
                    </td>
                </tr>
                <tr>
                    <td height="60px" class="auto-style4" valign="top" width="400"><br /><br />
                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Italic="False" Font-Names="Franklin Gothic Medium" Font-Size="Larger" Font-Underline="False" ForeColor="White" OnClick="LinkButton1_Click">← Alışverişe Dön</asp:LinkButton><br /><br /><br /> 
                        <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" Font-Names="Franklin Gothic Medium" Font-Size="X-Large" Font-Underline="False" ForeColor="White" OnClick="LinkButton2_Click" Width="276px">Önceki Siparişlerim</asp:LinkButton>
                    </td>
                    <td height="60px" class="auto-style3" align="center" valign="top">
                        <br /><asp:Label ID="Label2" runat="server" ForeColor="White" Font-Bold="True" Font-Names="Franklin Gothic Medium" Font-Size="XX-Large" Font-Underline="False"></asp:Label><br /><br />
                        <asp:Repeater ID="rptsepet" runat="server" >
                            <ItemTemplate>
                                 <div class="urunbaslik">
                                                <%#Eval("urun_adi") %>
                                            </div>
                                            <div class="urunbaslik">
                                                <img src="resimler/<%#Eval("urun_resim") %>" class="urunresim" border="0" />
                                                
                                                <div class="urunfiyat">
                                                    Fiyat: <%#Eval("urun_fiyat") %> ₺ <br>
                                                    Adet: <%#Eval("urun_miktar") %> <br>
                                                    
                                                </div>
                                                <a href="sepett.aspx?urunid=<%#Eval("urun_id") %>" style="text-decoration:none;color:white">Sil</a>
                                            </div><br>
                                        </div>
                               
                            </ItemTemplate>
                        </asp:Repeater>
                        
                    </td>
                    <td align="center" valign="top">
                        <br /><br /><br /><asp:Label ID="Label3" runat="server" Text="Toplam Tutar" Font-Bold="True" Font-Italic="True" Font-Names="Franklin Gothic Medium" Font-Size="X-Large" ForeColor="White"></asp:Label><br /><br />
                        <asp:Label ID="Label4" runat="server" Text="Label" Font-Bold="True" Font-Italic="False" Font-Names="Franklin Gothic Medium" Font-Size="X-Large" ForeColor="White"></asp:Label>&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Text="₺" Font-Bold="True" Font-Italic="True" Font-Names="Franklin Gothic Medium" Font-Size="X-Large" ForeColor="White"></asp:Label><br /><br /><br />
                        <asp:Button ID="Button1" runat="server" Text="Sepeti Onayla" BackColor="Black" Font-Bold="True" Font-Names="Franklin Gothic Medium" Font-Size="X-Large" ForeColor="White" OnClick="Button1_Click" />
                    </td>
                </tr>
                <tr>
                    <td height="40px" bgcolor="#3C3741" colspan="3" align="center">
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
