using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace inven
{
    public partial class Home : System.Web.UI.Page
    {
        public String message = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Convert.ToString(Session["id"]);
            //String message = null;
            if (Session["id"] == null) { Response.Redirect("Login.aspx"); }
            else
            {
                try
                {
                    Koneksi loadData = new Koneksi();
                    TableUser.DataSource = loadData.daftar_barang();
                    TableUser.DataBind();
                    loadData.kon.Close();
                    Riwayat.DataSource = loadData.riwayat_barang();
                    Riwayat.DataBind();
                    loadData.kon.Close();
                }catch(Exception msg)
                {
                    this.message = "terjadi masalah";
                }
                
            }
            
        }
        
    }
}