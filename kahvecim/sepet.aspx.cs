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
    public partial class WebForm3 : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Visible = true;

            string srg = "";
            if (Request.QueryString["musteri_id"] != null) 
            {
                Session["UyeID"] = Request.QueryString["musteri_id"];
            }

            if (Session["UyeID"] != null)
            {
                srg = "musteri_id=" + Session["UyeID"].ToString();
            }
            else
            {
                srg = "musteri_id is not null";
            }

            SqlConnection vtbag = new SqlConnection(@"Data Source=DESKTOP-SQP4A4P\SQLEXPRESS;Initial Catalog=kahveci;Integrated Security=True");
            vtbag.Open();

            /* SqlCommand sorgus = new SqlCommand("select * from sepet where "+srg, vtbag);
             SqlDataAdapter da = new SqlDataAdapter();
             da.SelectCommand = sorgus;
             DataTable dt = new DataTable();
             da.Fill(dt);
             GridView1.DataSource = dt;
             GridView1.DataBind();*/

            SqlCommand sorgus = new SqlCommand("select urun_adi,urun_resim,cast(urun_fiyat as decimal(10,2)) as urun_fiyat,urun_miktar,urun_id from sepet where " + srg, vtbag);
            SqlDataReader okus = sorgus.ExecuteReader();
            rptsepet.DataSource = okus;
            rptsepet.DataBind();
            sorgus.Dispose();
            rptsepet.Dispose();
            okus.Dispose();
            okus.Close();
            int x=0;
            SqlCommand deneme = new SqlCommand("select count(urun_id) as urun_id from sepet where musteri_id="+ Session["UyeID"], vtbag);
            if(Session["UyeID"]!=null)
            { 
             x = Convert.ToInt32(deneme.ExecuteScalar());
            
            if (x>0)
            {
                Label2.Visible = false;
            }
            else 
            {
               Label2.Visible = true;
                Label2.Text = "Sepetinizde Ürün Bulunmamaktadır";
                
            }
            }

            /*Toplam değeri alma*/
            SqlCommand toplam = new SqlCommand("select cast(SUM(urun_fiyat*urun_miktar) as decimal(10,2))as Toplam from sepet where musteri_id=" + Session["UyeID"], vtbag);
            if (Session["UyeID"] != null)
            {
                string sonuc = toplam.ExecuteScalar().ToString();
                Label4.Text = sonuc.ToString();
                if (Label2.Visible == true)
                {
                    Label4.Visible = true;
                    Label4.Text = "0";
                    Button1.Enabled = false;
                }
            }
            /*Toplam değeri alma*/


            /*İletişim Bilgileri*/
            SqlCommand sorgu = new SqlCommand("select * from iletisim", vtbag);
            SqlDataReader oku = sorgu.ExecuteReader();
            rptiletisim.DataSource = oku;
            rptiletisim.DataBind();
            sorgu.Dispose();
            rptiletisim.Dispose();
            oku.Dispose();
            oku.Close();
            vtbag.Dispose();
            vtbag.Close();
            /*İletişim Bilgileri*/

            // Eğer herhangi bir kullanıcı yok ise
            if (Session["UyeID"] == null)
            {
                Response.Redirect("kullanicigirisi.aspx");
            }
            else
            {
                // Varsa ekrana adını soyadını yaz
                Label1.Text = "👤 " + Session["AdiSoyadi"].ToString();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("anasayfa.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            //Bütün Session değerlerini sıfırlayarak kullanıcının sistemden çıkış yapması sağlanır ve tekrar giriş sayfasına yönlendirir.
            Session.Abandon();
            Response.Redirect("kullanicigirisi.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("satinal.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("gecmis.aspx");
        }
    }
}