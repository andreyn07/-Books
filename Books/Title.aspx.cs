using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Books
{
    public partial class Title : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropDowns();
            }
        }

        private void LoadDropDowns()
        {
            int authorId = 0;
            var db = new DBAccess();
            DataSet ds = db.GetTitle(authorId);
            DataTable dt = ds.Tables[0];
            
            ddlTitle.DataSource = dt;
            ddlTitle.DataValueField = "TitleID";
            ddlTitle.DataTextField = "Title";
            ddlTitle.DataBind();
            ddlTitle.Items.Insert(0, "Please Select Title");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!txtTitle.Text.isEntered())
            {
                lblMessage.Text = "Please enter the Title";
                return;
            }
            string title = txtTitle.Text;
            var db = new DBAccess();
            string msg = "";
            int titleId = db.SetTitle( title, ref msg);
            if (!string.IsNullOrEmpty(msg))
            {
                lblMessage.Text = msg;
                return;
            }
            if (titleId == 0)
            {
                lblMessage.Text = "Already exists";
                return;
            }

            lblMessage.Text = "The new Title ID is" + " " + titleId.ToString();
            LoadDropDowns();
            txtTitle.Focus();
        }
    }
}