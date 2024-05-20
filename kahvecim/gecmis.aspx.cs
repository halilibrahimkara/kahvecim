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
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection vtbag = new SqlConnection(@"Data Source=DESKTOP-SQP4A4P\SQLEXPRESS;Initial Catalog=kahveci;Integrated Security=True");
            vtbag.Open();

          

            //* Ürün bilgileri*/
            SqlCommand sorgu = new SqlCommand("select * from gecmis where musteri_id=" + Session["UyeID"], vtbag);
            SqlDataReader oku = sorgu.ExecuteReader();
            rpturun.DataSource = oku;
            rpturun.DataBind();
            sorgu.Dispose();
            rpturun.Dispose();
            oku.Dispose();
            oku.Close();
            //*Ürün bilgileri*/


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
                Label1.Visible = false;
                LinkButton1.Visible = false;
            }
            else
            {
                // Varsa ekrana adını soyadını yaz
                Label1.Text = "👤 " + Session["AdiSoyadi"].ToString();
                LinkButton1.Visible = true;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Bütün Session değerlerini sıfırlayarak kullanıcının sistemden çıkış yapması sağlanır.
            Session.Abandon();
            Response.Redirect("anasayfa.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("sepet.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("anasayfa.aspx");
        }
        
    }
}