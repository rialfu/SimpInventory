using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace inven
{
    public partial class Quantity : System.Web.UI.Page
    {
        Koneksi k = new Koneksi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null) { Response.Redirect("Login.aspx"); }
            if (!IsPostBack)
            {
                
                barang.DataSource = k.daftar_barang();
                barang.DataTextField = "nama";
                barang.DataValueField = "id";
                barang.DataBind();
                k.kon.Close();
            }
            
        }
        protected void tambah(object sender, EventArgs e)
        {
            int value;
            if (barang.SelectedItem.Value != "" && (Tipe.SelectedItem.Value == "1"|| Tipe.SelectedItem.Value =="0") && jumlah.Text != ""&& int.TryParse(jumlah.Text, out value))
            {
                if(k.AddQuantity(Int32.Parse(jumlah.Text), Convert.ToString(Session["id"]), Int16.Parse(barang.SelectedItem.Value), Int16.Parse(Tipe.SelectedItem.Value)))
                {
                    Response.Write("<script>alert('berhasil')</script>");
                }
                else
                {
                    Response.Write("<script>alert('gagal,terjadi masalah')</script>");
                }
                
                
            }
            else
            {
                Response.Write("<script>alert('isi form dengan benar')</script>");
            }
            
            //barang.SelectedItem.Value

        }
        protected void changeValue(object sender, EventArgs e)
        {
            barang.SelectedValue = barang.SelectedItem.Value;
            //BindDropDownList(barang.SelectedItem.Value)
        }

        protected void changeValueTipe(object sender, EventArgs e)
        {
            Tipe.SelectedValue = Tipe.SelectedItem.Value;
        }
    }
}