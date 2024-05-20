<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kullanicigirisi.aspx.cs" Inherits="kahvecim.WebForm2" %>

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
        }
        .icerik{
            font-family: Franklin Gothic Medium;
            font-size: large;
            color: white;
        }
        .iletisim {
            display: inline-block;
            background-color: #3C3741;
            color: #ffffff;
            text-decoration: none;
            list-style-type: none;
            font-size: 15px;
        }
        </style>
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
                <div class="auto-style2">
                    <td>
                        <img alt="" class="banner" src="resimler/logo.jpg" height="400px" width="1500px"/> 
                    </td>
                </tr>
                <tr>
                    <td align="center" class="icerik"><br /><br />Kullanıcı Adı  :  <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <br /><br />
                        Şifre&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;<asp:TextBox ID="TextBox2" runat="server" textmode="Password"></asp:TextBox>
                        <br /><br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="Giriş Yap" BackColor="Black" Font-Bold="True" Font-Italic="False" Font-Names="Franklin Gothic Medium" Font-Size="Large" Font-Strikeout="False" ForeColor="White" Height="43px" Width="136px" OnClick="Button1_Click" BorderColor="#333333"/>
                        <br /><br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True" Font-Names="Franklin Gothic Medium" Font-Size="Large" ForeColor="White"></asp:Label>
                        <br />
                        <br />
                        Üye Değil Misin ?<asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Franklin Gothic Medium" ForeColor="White" Font-Underline="False" Font-Size="X-Large" OnClick="LinkButton1_Click">&nbsp;&nbsp; Kayıt Ol</asp:LinkButton> 
                        <br />
                        <br />
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
