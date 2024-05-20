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
using System.EnterpriseServices.Internal;

namespace kahvecim
{
    public partial class WebForm4 : System.Web.UI.Page
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

            
            

            RequiredFieldValidator1.ControlToValidate = "ad";
            RequiredFieldValidator2.ControlToValidate = "soyad";
            RequiredFieldValidator3.ControlToValidate = "telefon";
            RequiredFieldValidator4.ControlToValidate = "eposta";
            RequiredFieldValidator5.ControlToValidate = "adres";
            RequiredFieldValidator6.ControlToValidate = "ilce";
            RequiredFieldValidator7.ControlToValidate = "il";
            RequiredFieldValidator8.ControlToValidate = "kad";
            RequiredFieldValidator9.ControlToValidate = "sifre";

            RequiredFieldValidator1.Text = "Bu alan boş bırakılamaz";
            RequiredFieldValidator2.Text = "Bu alan boş bırakılamaz";
            RequiredFieldValidator3.Text = "Bu alan boş bırakılamaz";
            RequiredFieldValidator4.Text = "Bu alan boş bırakılamaz";
            RequiredFieldValidator5.Text = "Bu alan boş bırakılamaz";
            RequiredFieldValidator6.Text = "Bu alan boş bırakılamaz";
            RequiredFieldValidator7.Text = "Bu alan boş bırakılamaz";
            RequiredFieldValidator8.Text = "Bu alan boş bırakılamaz";
            RequiredFieldValidator9.Text = "Bu alan boş bırakılamaz";

            RequiredFieldValidator1.InitialValue = "";
            RequiredFieldValidator2.InitialValue = "";
            RequiredFieldValidator3.InitialValue = "";
            RequiredFieldValidator4.InitialValue = "";
            RequiredFieldValidator5.InitialValue = "";
            RequiredFieldValidator6.InitialValue = "";
            RequiredFieldValidator7.InitialValue = "";
            RequiredFieldValidator8.InitialValue = "";
            RequiredFieldValidator9.InitialValue = "";

            Label1.Visible = false;

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm2.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            

            
            if (Page.IsValid)
            {
                
            
            SqlConnection vtbag = new SqlConnection(@"Data Source=DESKTOP-SQP4A4P\SQLEXPRESS;Initial Catalog=kahveci;Integrated Security=True");
            vtbag.Open();
            try
            {
                
                SqlCommand sorgu = new SqlCommand("insert into musterii values('" + ad.Text + "','" + soyad.Text + "','" + telefon.Text + "','" + eposta.Text + "','" + adres.Text + "','" + ilce.Text + "','" + il.Text + "','" + kad.Text + "','" + sifre.Text + "')", vtbag);
                sorgu.ExecuteNonQuery();
                Label1.Visible = true;
                Label1.Text = "Kayıt Başarılı 🥰";
                foreach (Control c in this.Page.Form.Controls)
                {
                    if (c is TextBox)
                    {
                        ((TextBox)c).Text = string.Empty;
                    }
                }
            }
            catch
            {
                    Label1.Visible = true;
                Label1.Text = "Bu kullanıcı adı daha önceden alınmış 😞";
            }
            finally
            {
                vtbag.Close();
            }
            }
        }
    }
}