using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

namespace kahvecim
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection vtbag = new SqlConnection(@"Data Source=DESKTOP-SQP4A4P\SQLEXPRESS;Initial Catalog=kahveci;Integrated Security=True");
            vtbag.Open();

            /*İletişim Bilgileri*/
            SqlCommand sorgui = new SqlCommand("select * from iletisim", vtbag);
            SqlDataReader okui = sorgui.ExecuteReader();
            rptiletisim.DataSource = okui;
            rptiletisim.DataBind();
            sorgui.Dispose();
            rptiletisim.Dispose();
            okui.Dispose();
            okui.Close();
            vtbag.Dispose();
            vtbag.Close();

            /*İletişim Bilgileri*/

            Label1.Text = "Kullanıcı Adı ve Şifre Giriniz.";

            if (Session["UyeID"] == null)
            {
                LinkButton2.Visible = false;
            }
            else
            {
                LinkButton2.Visible = true;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection vtbag = new SqlConnection(@"Data Source=DESKTOP-SQP4A4P\SQLEXPRESS;Initial Catalog=kahveci;Integrated Security=True");
            vtbag.Open();

            /*Kullanıcı Girişi*/
            SqlCommand sorgu = new SqlCommand("SELECT * FROM musterii WHERE kullanici_adi='" + TextBox1.Text + "' AND sifre='" + TextBox2.Text + "'", vtbag);
            SqlDataReader oku = sorgu.ExecuteReader();
            //Eğer bir kayıt okunuyorsa
            if (oku.Read())
            {
                //Okunan verileri Session'larda sakla
                Session["UyeID"] = oku["musteri_id"].ToString();
                Session["AdiSoyadi"] = oku["musteri_ad"].ToString() + " " + oku["musteri_soyad"].ToString();
                // Giriş sayfasına yönlendir
                Response.Redirect("anasayfa.aspx");
            }
            else // Böyle bir kayıt okunamadıysa
            {
                Label1.Text = "Geçersiz Kullanıcı Adı Veya Şifre 😞";
            }
            oku.Close(); // Reader nesnesini kapat
            /*Kullanıcı Girişi*/

            vtbag.Close();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("uyeol.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
        
            //Bütün Session değerlerini sıfırlayarak kullanıcının sistemden çıkış yapması sağlanır.
            Session.Abandon();

        }
    }
}