using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Books
{
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblBookID.Text = Request.QueryString["BookID"] != null ? Request.QueryString["BookID"].ToString() : "0";
            lblBookName.Text = Request.QueryString["BookName"] != null ? Request.QueryString["BookName"].ToString() : "0";
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookMaintenance.aspx");
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            lblAnswer.Text = "Delete";
            string yes = lblAnswer.Text;
            Response.Redirect("~/BookMaintenance.aspx?BookID=" + yes);
        }
    }
}