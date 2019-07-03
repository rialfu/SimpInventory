using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace inven
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String id= Convert.ToString(Session["id"]);
            if (id != "") Response.Redirect("Home.aspx");

        }
        protected void login(object sender, EventArgs e)
        {
            Koneksi loadData = new Koneksi();
            String[] data = new String[2];
            data=loadData.login(username.Text, password.Text);
            if (data[0]!="")
            {
                Session["id"] = data[1];
                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Write("<script>alert('" + data[1] + "')</script>");
            }
        }
    }
}