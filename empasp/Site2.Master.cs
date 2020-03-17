using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace empasp
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["username"] == null)
                Response.Redirect("webForm1.aspx");
            else
                Label1.Text ="welcome "+ Request.Cookies["username"].Value;
        }
    }
}