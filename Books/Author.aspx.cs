using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Books
{
    public partial class Author : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropDown();
            }
        }

        private void LoadDropDown()
        {
            var db = new DBAccess();
            DataSet ds = db.GetAuthor();
            DataTable dt = ds.Tables[0];
            ddlAuthor.DataSource = dt;
            ddlAuthor.DataValueField = "AuthorID";
            ddlAuthor.DataTextField = "FullName";
            ddlAuthor.DataBind();
            ddlAuthor.Items.Insert(0, "Please Select Author");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!txtFName.Text.isEntered())
            {
                lblMessage.Text = "Please enter First Name";
                return;
            }
            if (!txtLName.Text.isEntered())
            {
                lblMessage.Text = "Please enter Last Name";
                return;
            }
            lblMessage.Text = "";
            string fName = txtFName.Text;
            string lName = txtLName.Text;
            var db = new DBAccess();
            string msg = "";
            int authorId = db.SetAuthor(fName, lName, ref msg);
            if (!string.IsNullOrEmpty(msg))
            {
                lblMessage.Text = msg;
                return;
            }
            if (authorId == 0)
            {
                lblMessage.Text = "Alredy exists";
                return;
            }

            lblMessage.Text = "The new author ID is" + " " + authorId.ToString();
            LoadDropDown();
        }
    }
}