using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace kahvecim
{ 
    public partial class WebForm5 : System.Web.UI.Page
    {
        string resim;
        protected void Page_Load(object sender, EventArgs e)
        {
            string srg = "";
            
            string srgy = "";

            if (Session["UyeID"] == null)
            {
                Response.Redirect("kullanicigirisi.aspx");
            }


            string srgm = Session["UyeID"].ToString();


            if (Request.QueryString["urunid"] != null)
            {
                Session["urunid"] = Request.QueryString["urunid"];
                Session["urun_id"] = Request.QueryString["urunid"];
            }

            if (Session["urunid"] != null)
            {
                srg = "id=" + Session["urunid"].ToString();
                srgy = "urun_id=" + Session["urun_id"].ToString();
            }
            else
            {
                srg = "id is not null";
                srgy = "urun_id is not null";
            }

            


            SqlConnection vtbag = new SqlConnection(@"Data Source=DESKTOP-SQP4A4P\SQLEXPRESS;Initial Catalog=kahveci;Integrated Security=True");
            vtbag.Open();

            //* Ürün bilgileri*/ /* 
            SqlCommand sorgu = new SqlCommand("select * from urun where " + srg, vtbag);
            SqlDataReader oku = sorgu.ExecuteReader();
            if (oku.Read())
            {
                lbaslik.Text = oku["urun_ad"].ToString().Trim();
                lfiyat.Text = oku["urun_fiyat"].ToString().Trim();
                lstok.Text = oku["urun_miktar"].ToString().Trim();
                Image1.ImageUrl = "resimler/" + oku["urun_resim"].ToString().Trim();
                resim = oku["urun_resim"].ToString();
            }
            sorgu.Dispose();

            oku.Dispose();
            oku.Close();
            //*Ürün bilgileri*/

            //* Müşteri bilgileri*/ /* 
            SqlCommand sorgum = new SqlCommand("select musteri_ad,musteri_soyad from musterii where musteri_id= "+ srgm, vtbag);
            SqlDataReader okum = sorgum.ExecuteReader();
            if (okum.Read())
            {
               Session["musteri_ad"] = okum["musteri_ad"].ToString().Trim();
                Session["musteri_soyad"] = okum["musteri_soyad"].ToString().Trim();
               
            }
            sorgum.Dispose();

            okum.Dispose();
            okum.Close();
            //*Müşteri bilgileri*/

            /*İletişim Bilgileri*/
            SqlCommand sorgui = new SqlCommand("select * from iletisim", vtbag);
            SqlDataReader okui = sorgui.ExecuteReader();
            rptiletisim.DataSource = okui;
            rptiletisim.DataBind();
            sorgui.Dispose();
            rptiletisim.Dispose();
            okui.Dispose();
            okui.Close();

            /*İletişim Bilgileri */

            /*Yorum Bilgileri*/
            
            SqlCommand sorguy = new SqlCommand("select * from yorum where "+ srgy, vtbag);
            SqlDataReader okuy = sorguy.ExecuteReader();
           
            rptyorum.DataSource = okuy;
            rptyorum.DataBind();
            sorguy.Dispose();
            rptyorum.Dispose();
            okuy.Dispose();
            okuy.Close();
            /*Yorum Bilgileri*/
            vtbag.Dispose();
            vtbag.Close();
            if (Session["UyeID"] == null)
            {
                Button1.Visible = true;
                Label3.Visible = false;
                LinkButton1.Visible = false;
                Label5.Visible = false;
                TextBox1.Visible = false;
                Button3.Visible = false;
                Label9.Visible = false;
                Label10.Visible = false;
                TextBox2.Visible = false;
            }
            else
            {
                // Varsa ekrana adını soyadını yaz
                Button2.Visible = false;
                Label3.Text = "👤 " + Session["AdiSoyadi"].ToString();
                LinkButton1.Visible = true;
                Label5.Visible = true;
                TextBox1.Visible = true;
                Button3.Visible = true;
                Label9.Visible = true;
                Label10.Visible = true;
                TextBox2.Visible = true;
            }

            Label11.Visible = false;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Bütün Session değerlerini sıfırlayarak kullanıcının sistemden çıkış yapması sağlanır.
            Session.Abandon();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("kullanicigirisi.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("sepet.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("anasayfa.aspx");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            SqlConnection vtbag = new SqlConnection(@"Data Source=DESKTOP-SQP4A4P\SQLEXPRESS;Initial Catalog=kahveci;Integrated Security=True");
            vtbag.Open();



            SqlCommand sorgu = new SqlCommand("insert into sepet(urun_id,musteri_id,urun_fiyat,urun_miktar,urun_adi,urun_resim) values('" + Session["urunid"] + "','"+Session["UyeID"] +"','" + lfiyat.Text + "','" + DropDownList1.SelectedValue + "','" + lbaslik.Text + "','"+resim+"')", vtbag);
            sorgu.ExecuteNonQuery();


            vtbag.Close();
            if(sorgu!=null)
            {
                Button1.Visible = false;
                Label4.Text = "Ürün başarıyla eklendi";
            }
            else
            {
                Label4.Text = "Ürün eklenemedi";
            }

            // Eğer herhangi bir kullanıcı yok ise
            if (Session["UyeID"] == null)
            {
                Response.Redirect("kullanicigirisi.aspx");
                
            }
            else
            {
                
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection vtbag = new SqlConnection(@"Data Source=DESKTOP-SQP4A4P\SQLEXPRESS;Initial Catalog=kahveci;Integrated Security=True");
            vtbag.Open();



            SqlCommand sorgu = new SqlCommand("insert into yorum(yorum_baslik,yorum_icerik,yorum_uye_id,urun_id,yorum_uye_adi,yorum_uye_soyadi,yorum_tarihi) values('"+TextBox1.Text+"','"+TextBox2.Text+"','" + Session["UyeID"] + "','" + Session["urunid"] + "','" + Session["musteri_ad"] + "','" +Session["musteri_soyad"] + "','" + DateTime.Now.Date.ToLongDateString()+ "')", vtbag);
            sorgu.ExecuteNonQuery();
            

            vtbag.Close();
            if (sorgu != null)
            {
                Button1.Visible = false;
                Label11.Visible = true;
                Label11.Text = "Yorum başarıyla eklendi";
                Button3.Visible = false;
            }
            else
            {
                Label11.Visible = true;
                Label11.Text = "Yorum eklenemedi";
            }

            if (Session["UyeID"] == null)
            {
                Response.Redirect("kullanicigirisi.aspx");
            }
        }
    }
}