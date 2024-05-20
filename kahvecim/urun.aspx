<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="urun.aspx.cs" Inherits="kahvecim.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 900px;
        }
        .auto-style6 {
            height: 58px;
        }
        .auto-style7 {
            width: 400px;
            background-color:#3C3741;
            border-radius:9px;
            box-shadow:5px 5px #000000;
            color:white;

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
                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Names="Franklin Gothic Medium" Font-Size="Large" Font-Underline="False" ForeColor="White" OnClick="LinkButton1_Click">❌ Çıkış Yap</asp:LinkButton>
                    </td>
                    <td align="right" height="60px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <div class="auto-style5">
                        <div class="auto-style5">
                    <td colspan="3">
                        <img alt="" class="banner" src="resimler/logo.jpg" /> </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td width="300px" class="auto-style6">
                                <asp:Button ID="Button2" runat="server" Text="Kullanıcı Girişi" BackColor="Black" ForeColor="White" Height="50px" Font-
                                    Bold="True" Font-Italic="False" Font-Names="Franklin Gothic Medium" Font-Size="Large" OnClick="Button1_Click" />
                            <asp:Label ID="Label3" runat="server" Text="Label" BorderColor="Black" Font-Bold="True" Font-Names="Franklin Gothic Medium" Font-Size="X-Large" ForeColor="White"></asp:Label> 
                    </td>
                    
                    <td align="left" class="auto-style6">
                        &nbsp;</td>
                    
                    <td align="right" class="auto-style6">
                                <asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Franklin Gothic Medium" Font-Overline="False" Font-Size="XX-Large" Font-Strikeout="False" Font-Underline="False" ForeColor="White" OnClick="LinkButton3_Click">🛒 Kahve Sepetim</asp:LinkButton> 
                        </td>
                </tr>
                <tr>
                    <td width="300px" class="auto-style6" valign="top"><br /><br />
                        <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Franklin Gothic Medium" Font-Size="X-Large" Font-Underline="False" ForeColor="White" OnClick="LinkButton2_Click">←Ana Sayfaya Dön </asp:LinkButton> 
                    </td>
                    
                    <td align="left" class="auto-style6"><br /><br />
                        <asp:Label ID="lbaslik" runat="server" Text="Label" Font-Bold="True" Font-Italic="True" Font-Names="Franklin Gothic Medium" Font-Size="XX-Large" ForeColor="White"></asp:Label><br /><br /><br />
                        
                        &nbsp;&nbsp;<asp:Image ID="Image1" runat="server" /><br><br />
                        <asp:Label ID="Label6" runat="server" Text="Ürün Fiyatı: " Font-Bold="True" Font-Names="Franklin Gothic Medium" Font-Size="Large" ForeColor="Black"></asp:Label>
                        <asp:Label ID="lfiyat" runat="server" Text="Label" Font-Bold="True" Font-Names="Franklin Gothic Medium" Font-Size="Large" ForeColor="Black"></asp:Label>&nbsp;
                        <asp:Label ID="Label8" runat="server" Text="₺" Font-Bold="True" Font-Names="Franklin Gothic Medium" Font-Size="Large" ForeColor="Black"></asp:Label>
                        <br />
                        <asp:Label ID="Label7" runat="server" Text="Ürün Stok Sayısı: " Font-Bold="True" Font-Names="Franklin Gothic Medium" Font-Size="Large"></asp:Label>
                        </asp:Literal><asp:Label ID="lstok" runat="server" Text="Label" Font-Bold="True" Font-Names="Franklin Gothic Medium" Font-Size="Large" ForeColor="Black"></asp:Label>
                        
                        
                    <br /><br /><br /> 
                    </td>
                    
                    <td align="left" valign="top" class="auto-style6">
                        <br /><br />
                        &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="False" Font-Names="Franklin Gothic Medium" Font-Size="Large" ForeColor="White" Text="Adet: "></asp:Label>
&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" DataTextField="urun_miktar" DataValueField="urun_miktar" BackColor="#666666" Font-Bold="True" Font-Italic="False" Font-Names="Franklin Gothic Medium" Font-Size="Medium" ForeColor="White" Height="24px" Width="57px">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                        </asp:DropDownList> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button1" runat="server" Text="Sepete Ekle" BackColor="Black" Font-Bold="True" Font-Names="Franklin Gothic Medium" Font-Size="X-Large" Font-Underline="False" ForeColor="White" OnClick="Button1_Click1" />
                        <asp:Label ID="Label4" runat="server" Font-Italic="True" Font-Names="Franklin Gothic Medium" Font-Size="Medium" ForeColor="Black"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td height="40px" bgcolor="#F2C5A3" align="center">
                               &nbsp;</td>
                    <td height="40px" bgcolor="#F2C5A3" align="left" >
                        _________________________________________________________________<br /><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="Yorumlar" Font-Bold="True" Font-Italic="True" Font-Names="Franklin Gothic Medium" Font-Size="XX-Large" ForeColor="White"></asp:Label>
                    <br /><br /><br />
                        
                        &nbsp;&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Text="Dilersen Yorumunu Ekleyebilirsin 😊" Font-Bold="True" Font-Italic="False" Font-Names="Franklin Gothic Medium" Font-Size="Large" ForeColor="White"></asp:Label><br /><br />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label9" runat="server" Text="Yorum Başlığı" Font-Bold="True" Font-Italic="True" Font-Names="Franklin Gothic Medium" Font-Size="Large" ForeColor="White"></asp:Label>
                                         <br />&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
                        &nbsp;&nbsp;
                         <asp:Label ID="Label10" runat="server" Text="Yorum İçeriği" Font-Bold="True" Font-Italic="True" Font-Names="Franklin Gothic Medium" Font-Size="Large" ForeColor="White"></asp:Label>
                        <br/>&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox2" runat="server" Height="86px" Width="574px" Columns="40" Rows="6" TextMode="MultiLine"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button3" runat="server" Text="Gönder" OnClick="Button3_Click" BackColor="Black" BorderColor="#333333" Font-Bold="True" Font-Names="Franklin Gothic Medium" Font-Size="Large" ForeColor="White" />
                        
                        
                        <asp:Label ID="Label11" runat="server" Text="Label" Font-Bold="True" Font-Italic="True" Font-Names="Franklin Gothic Medium" Font-Size="Large" ForeColor="Black"></asp:Label>
                        
                    </td>
                    
                    <td height="40px" bgcolor="#F2C5A3" align="center">
                               &nbsp;</td>
                    <td height="40px" bgcolor="#F2C5A3" align="center">
                               &nbsp;</td>
                </tr>
                <tr>
                    <td height="40px" bgcolor="#F2C5A3" align="center">
                               &nbsp;</td>
                    <td height="40px" bgcolor="#F2C5A3"  align="left" >
                        <asp:Repeater ID="rptyorum" runat="server">
                            <ItemTemplate>
                        <table cellspacing="1" class="auto-style7" width="700" border="1" bordercolor="black">
                            <tr>
                                <td><strong><%#Eval("yorum_uye_adi")%> <%#Eval("yorum_uye_soyadi") %></strong></td>
                                <td><strong><%#Eval("yorum_tarihi") %></strong></td>
                            </tr>
                            <tr>
                                <td colspan="2" align="left"><strong><%#Eval("yorum_baslik") %></strong><br />
                                    <%#Eval("yorum_icerik") %></td>
                            </tr>
                        </table>
                       
                            </ItemTemplate>
                        </asp:Repeater>
 
                    </td>
                     
                    <td height="40px" bgcolor="#F2C5A3" align="center">
                               &nbsp;</td>
                    <td height="40px" bgcolor="#F2C5A3" align="center">
                               &nbsp;</td>
                </tr>
                <tr>
                    <td height="40px" bgcolor="#F2C5A3" colspan="3" align="center">
                               &nbsp;&nbsp;&nbsp;&nbsp; <asp:Repeater ID="rptiletisim" runat="server">
                                    <ItemTemplate>
                        <div class="iletisim">Telefon : <%#Eval("tel")%>  •  E-posta : <%#Eval("e_posta")%>  •  Adres : <%#Eval("adres")%></div>
                                </ItemTemplate>  
                                </asp:Repeater>
                        </td>
                    <td height="40px" bgcolor="#F2C5A3" align="center">
                               &nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
