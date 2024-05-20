using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace kahvecim
{
    public partial class sepett : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string srg = Request.QueryString["urunid"];
            

            SqlConnection vtbag = new SqlConnection(@"Data Source=DESKTOP-SQP4A4P\SQLEXPRESS;Initial Catalog=kahveci;Integrated Security=True");
            vtbag.Open();

            SqlCommand sepetsil = new SqlCommand("delete from sepet where urun_id=" +srg, vtbag);
            sepetsil.ExecuteNonQuery();
            vtbag.Close();
            Response.Redirect("sepet.aspx");
        }
    }
}