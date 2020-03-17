using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace empasp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = null;
        SqlDataAdapter adp = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            adp = new SqlDataAdapter("select * from emptable where ename=@u and password=@p", con);
            adp.SelectCommand.Parameters.AddWithValue("@u",TextBox1.Text);
            adp.SelectCommand.Parameters.AddWithValue("@p",TextBox2.Text);
            DataSet D = new DataSet();
            adp.Fill(D, "t");
            if ((int)D.Tables["t"].Rows.Count != 0)
            {
                DataRow r = D.Tables["t"].Rows[0];
                if (r[3].ToString() == "admin")
                {
                    Response.Cookies["username"].Value = TextBox1.Text;
                    Response.Redirect("WebForm2.aspx");

                }
                else if (r[3].ToString() == "user")
                {
                    Response.Cookies["username"].Value = TextBox1.Text;
                    Response.Redirect("WebForm3.aspx");

                }
            }
            else
            TextBox1.Focus();

        }
    }
}