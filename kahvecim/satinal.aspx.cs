using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Web.Configuration;
using System.EnterpriseServices.Internal;

namespace kahvecim
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        string ödeme;
        public void ac()
        {
            TextBox9.Enabled = true;
            TextBox11.Enabled = true;
            TextBox12.Enabled = true;
            DropDownList1.Enabled = true;
        }

        public void kapat()
        {
            TextBox9.Enabled = false;
            TextBox11.Enabled = false;
            TextBox12.Enabled = false;
            DropDownList1.Enabled = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection vtbag = new SqlConnection(@"Data Source=DESKTOP-SQP4A4P\SQLEXPRESS;Initial Catalog=kahveci;Integrated Security=True");
            vtbag.Open();

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

            RadioButton1.AutoPostBack = true;
            RadioButton2.AutoPostBack = true;
            GridView1.Visible = false;

            /*İletişim Bilgileri*/
            SqlCommand sorgu = new SqlCommand("select * from iletisim", vtbag);
            SqlDataReader oku = sorgu.ExecuteReader();
            rptiletisim.DataSource = oku;
            rptiletisim.DataBind();
            sorgu.Dispose();
            rptiletisim.Dispose();
            oku.Dispose();
            oku.Close();

            /*İletişim Bilgileri*/

            SqlCommand sorgus = new SqlCommand("select urun_id as ÜrünID,musteri_id as MüsteriID,urun_fiyat as Fiyat,urun_miktar as Miktar,urun_adi as Ürün_Adı from sepet where " + srg, vtbag);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sorgus;
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            vtbag.Dispose();
            vtbag.Close();
            /*İletişim Bilgileri*/

            Label17.Visible = false;
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton1.Checked == true)
            {
                ac();
                RadioButton2.Checked = false;
                ödeme = RadioButton2.Text;
            }
            else if (RadioButton2.Checked == true)
            {
                
                RadioButton1.Checked = false;
                ödeme = RadioButton1.Text;
            }
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton2.Checked == true)
            {
                kapat();
                RadioButton1.Checked = false;
                ödeme = RadioButton1.Text;
            }
            else
            {
                ac();
                ödeme = RadioButton2.Text;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (TextBox1.Text == "")
            {
                Label17.Visible = true;
                Label17.Text = "Lütfen Ad Bilgisi Giriniz.";
            }
            if (TextBox2.Text == "")
            {
                Label17.Visible = true;
                Label17.Text = "Lütfen Soyad Bilgisi Giriniz.";
            }
            if (TextBox3.Text == "")
            {
                Label17.Visible = true;
                Label17.Text = "Lütfen Telefon Bilgisi Giriniz.";
            }
            if (TextBox4.Text == "")
            {
                Label17.Visible = true;
                Label17.Text = "Lütfen İl Bilgisi Giriniz.";
            }
            if (TextBox5.Text == "")
            {
                Label17.Visible = true;
                Label17.Text = "Lütfen İlçe Bilgisi Giriniz.";
            }
            if (TextBox6.Text == "")
            {
                Label17.Visible = true;
                Label17.Text = "Lütfen Mahalle Bilgisi Giriniz.";
            }
            if (TextBox7.Text == "")
            {
                Label17.Visible = true;
                Label17.Text = "Lütfen Adres Bilgisi Giriniz.";
            }
            if (TextBox8.Text == "")
            {
                Label17.Visible = true;
                Label17.Text = "Lütfen Adres Başlığı Bilgisi Giriniz.";
            }
            if (RadioButton1.Checked == true)
            {
                Label12.Visible = false;
                Label13.Visible = false;
                Label14.Visible = false;
                Label15.Visible = false;
                Label16.Visible = false;
                TextBox9.Visible = false;
                TextBox11.Visible = false;
                TextBox12.Visible = false;
                DropDownList1.Visible = false;

            }
                SqlConnection vtbag = new SqlConnection(@"Data Source=DESKTOP-SQP4A4P\SQLEXPRESS;Initial Catalog=kahveci;Integrated Security=True");
                vtbag.Open();

                for (int i = 0; i <= GridView1.Rows.Count - 1; i++)

                {
                    SqlCommand sorgug = new SqlCommand("insert into gecmis(urun_id,musteri_id,urun_fiyat,urun_miktar,urun_adi) values('" + GridView1.Rows[i].Cells[0].Text + "','" + GridView1.Rows[i].Cells[1].Text + "','" + GridView1.Rows[i].Cells[2].Text + "','" + GridView1.Rows[i].Cells[3].Text + "','" + GridView1.Rows[i].Cells[4].Text.ToString() + "')", vtbag);
                    sorgug.ExecuteNonQuery();



                    SqlCommand sorgusepetsil = new SqlCommand("delete from sepet where musteri_id=" + Session["UyeID"], vtbag);
                    sorgusepetsil.ExecuteNonQuery();
                    if (sorgug != null)
                    {
                        Label17.Visible = true;
                        Button1.Visible = false;
                        Label17.Text = "İşlem Başarıyla Gerçekleşti.";
                    }
                    else
                    {
                        Label17.Visible = true;
                        Label17.Text = "İşlem Gerçekleştirilemedi.";
                    }
                }

                SqlCommand sorgui = new SqlCommand("insert into islem values('" + Session["UyeID"] + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + ödeme + "','" + TextBox9.Text + "','" + DropDownList1.SelectedValue + "','" + TextBox11.Text + "','" + TextBox12.Text + "','" + DateTime.Now.Date.ToLongDateString() + "')", vtbag);
                sorgui.ExecuteNonQuery();
                if (sorgui != null)
                {
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    TextBox5.Text = "";
                    TextBox6.Text = "";
                    TextBox7.Text = "";
                    TextBox8.Text = "";
                    TextBox9.Text = "";
                    TextBox11.Text = "";
                    TextBox12.Text = "";
                    DropDownList1.SelectedIndex = 0;
                }
                vtbag.Close();
            
        }
    }
}