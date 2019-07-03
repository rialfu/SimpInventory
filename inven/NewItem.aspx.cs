using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace inven
{
    public partial class Tambah_Item : System.Web.UI.Page
    {
        public String message = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null) { Response.Redirect("Login.aspx"); }
        }
        protected void tambah(object sender, EventArgs e)
        {
            int value;
            if (nama.Text != "")
            {
                Koneksi insert = new Koneksi();
                if (jumlah.Text == "")
                {
                    if (insert.newItem(nama.Text))
                    {
                        Response.Write("<script>alert('Berhasil')</script>");
                        this.message = "berhasi";
                    }
                    else
                    {
                        Response.Write("<script>alert('Terjadi Masalah, silahkan hubungi Dev')</script>");
                        this.message = "gagal";
                    }
                }
                else if (int.TryParse(jumlah.Text, out value))
                {
                    if (insert.newItem(nama.Text ))
                    {
                        if(insert.AddQuantity(Int32.Parse(jumlah.Text), Convert.ToString(Session["id"])))
                        {
                            Response.Write("<script>alert('Berhasil')</script>");
                            this.message = "berhasil";
                        }
                        else
                        {
                            Response.Write("<script>alert('Terjadi Masalah, silahkan hubungi Dev')</script>");
                            this.message = "gagal";
                        }

                    }
                    else
                    {
                        Response.Write("<script>alert('Terjadi Masalah, silahkan hubungi Dev')</script>");
                        this.message = "gagal";
                    }

                }
                else
                {
                    Response.Write("<script>alert('Terjadi Masalah, silahkan hubungi Dev')</script>");
                    this.message = "gagal";
                }
            }
            else if(nama.Text=="")
            {
                Response.Write("<script>alert('isi dahulu form')</script>");
            }
            
            
        }
    }
}