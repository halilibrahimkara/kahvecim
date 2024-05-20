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
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection vtbag = new SqlConnection(@"Data Source=DESKTOP-SQP4A4P\SQLEXPRESS;Initial Catalog=kahveci;Integrated Security=True");
            vtbag.Open();

            /*Seçimleri Sil*/
            if (Request.QueryString["sil_ktgr"] != null)
            {
                Session["ktgr_id"] = null;
                Session["ktgr_adi"] = null;
            }
            if (Request.QueryString["sil_marka"] != null)
            {
                Session["marka_id"] = null;
                Session["marka_adi"] = null;
            }
            /*Session oluşturma*/
            if (Request.QueryString["ktgr_id"] != null)
            {
                Session["ktgr_id"] = Request.QueryString["ktgr_id"];
                Session["ktgr_adi"] = Request.QueryString["ktgr_adi"];
            }

            if (Request.QueryString["marka_id"] != null)
            {
                Session["marka_id"] = Request.QueryString["marka_id"];
                Session["marka_adi"] = Request.QueryString["marka_adi"];
            }

            

            string srg = "";
            /*Sorguların belirlendiği kısım*/
            if (Session["ktgr_id"] != null)
            {
                srg = "kategori_no=" + Session["ktgr_id"];
                Label1.Visible = true;
            }
            else
            { srg = "kategori_no is not null";
                Label1.Visible = false;
            }

            if (Session["marka_id"] != null)
            { 
                srg = srg + " and marka_no=" + Session["marka_id"];
                Label2.Visible = true;
            }
            else
            { 
                srg = srg + " and marka_no is not null";
            Label2.Visible = false;
            }

           
            /*Sorguların belirlendiği kısım*/

            Label1.Text = "Kategori: <a style=text-decoration:none;color:white; href=?sil_ktgr=" + Session["ktgr_id"] + "> " + Session["ktgr_adi"] + "</a>" + " ";
            Label2.Text= "Marka: <a style=text-decoration:none;color:white; href=?sil_marka=" + Session["marka_id"] + ">" + Session["marka_adi"] + "</a>"; 
            //* Ürün bilgileri*/
            SqlCommand sorgu = new SqlCommand("select * from urun where "+srg,vtbag);
            SqlCommand urun = new SqlCommand("select count(id) as urun_id from urun where  " + srg, vtbag);
            int y = Convert.ToInt32(urun.ExecuteScalar());
            if(y>0)
            {
                Label4.Visible = false;
            }
            else
            {
                Label4.Visible = true;
                Label4.Text = "Aradığınız kriterde ürün bulunmamaktadır.";
            }

            SqlDataReader oku = sorgu.ExecuteReader();
                rpturun.DataSource = oku;
                rpturun.DataBind();
                sorgu.Dispose();
                rpturun.Dispose();
                oku.Dispose();
                oku.Close();
            //*Ürün bilgileri*/

            //*Kategori Bilgileri*/
            SqlCommand sorguk = new SqlCommand("select * from kategori", vtbag);
            SqlDataReader okuk = sorguk.ExecuteReader();
            rptkategori.DataSource = okuk;
            rptkategori.DataBind();
            sorguk.Dispose();
            rptkategori.Dispose();
            okuk.Dispose();
            okuk.Close();
            //*Kategori Bilgileri*/

            //*Marka Bilgileri*/
            SqlCommand sorgum = new SqlCommand("select * from marka", vtbag);
            SqlDataReader okum = sorgum.ExecuteReader();
            rptmarka.DataSource = okum;
            rptmarka.DataBind();
            sorgum.Dispose();
            rptmarka.Dispose();
            okum.Dispose();
            okum.Close();
            //*Marka Bilgileri*/

            SqlCommand sorguy = new SqlCommand("select * from yorum", vtbag);
            SqlDataReader okuy = sorguy.ExecuteReader();
            if (okuy.Read())
            {
                Session["urun_id"] = okuy["urun_id"].ToString();
            }
            sorguy.Dispose();
            okuy.Dispose();
            okuy.Close();


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
            /*İletişim Bilgileri */

            // Eğer herhangi bir kullanıcı yok ise
            if (Session["UyeID"] == null)
            {
                Button1.Visible = true;
                Label3.Visible = false;
                LinkButton2.Visible = false;
            }
            else
            {
                // Varsa ekrana adını soyadını yaz
                Button1.Visible = false;
                Label3.Text = "👤 " + Session["AdiSoyadi"].ToString();
                LinkButton2.Visible = true;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("kullanicigirisi.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("sepet.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            //Bütün Session değerlerini sıfırlayarak kullanıcının sistemden çıkış yapması sağlanır.
            Session.Abandon();
        }

        protected void rpturun_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            SqlConnection vtbag = new SqlConnection(@"Data Source=DESKTOP-SQP4A4P\SQLEXPRESS;Initial Catalog=kahveci;Integrated Security=True");
            vtbag.Open();

            SqlCommand sorgu = new SqlCommand("SELECT * FROM urun", vtbag);
            SqlDataReader oku = sorgu.ExecuteReader();
            if (oku.Read())
            {
                //Okunan verileri Session'larda sakla
                Session["UrunID"] = oku["id"].ToString();
                
                // Ürün sayfasına yönlendir
                Response.Redirect("urun.aspx");
            }
            else // Böyle bir kayıt okunamadıysa
            {
                
            }
            oku.Close(); // Reader nesnesini kapat
            /*Kullanıcı Girişi*/
        }
    }
}