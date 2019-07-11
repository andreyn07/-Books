using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Books
{
    public partial class Books : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropDowns();
                
               //txtDateCreated.Text = DateTime.Now.ToString("ddMMyyyy");
            }
        }

        private void LoadDropDowns()
        {

            var db = new DBAccess();
            DataSet ds = db.GetLookup();
            DataTable dt = ds.Tables[0];
            ddlGenre.DataSource = dt;
            ddlGenre.DataValueField = "GenreID";
            ddlGenre.DataTextField = "Genre";
            ddlGenre.DataBind();
            ddlGenre.Items.Insert(0, "Please Select Genre");

            dt = ds.Tables[1];
            ddlAuthor.DataSource = dt;
            ddlAuthor.DataValueField = "AuthorID";
            ddlAuthor.DataTextField = "FullName";
            ddlAuthor.DataBind();
            ddlAuthor.Items.Insert(0, "Please Select Author");

            dt = ds.Tables[2];
            ddlTitle.DataSource = dt;
            ddlTitle.DataValueField = "TitleID";
            ddlTitle.DataTextField = "Title";
            ddlTitle.DataBind();
            ddlTitle.Items.Insert(0, "Please Select Title");

            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!ddlGenre.SelectedIndex.isSelected())
            {
                lblMessage.Text = "Choose Genre";
                return;
            }
            if (!ddlAuthor.SelectedIndex.isSelected())
            {
                lblMessage.Text = "Choose Author";
                return;
            }
            if (!ddlTitle.SelectedIndex.isSelected())
            {
                lblMessage.Text = "Choose Title";
                return;
            }
            lblMessage.Text = "";
            int genreID = Convert.ToInt32(ddlGenre.SelectedValue);
            int authorID = Convert.ToInt32(ddlAuthor.SelectedValue);
            int titleID = Convert.ToInt32(ddlTitle.SelectedValue);
            string dateCreated = txtDateCreated.Text;
            string action = "View";
            
            //string action, ref string msg, int ? genreID = null,
            // int ? authorID = null, int ? titleID = null, string dateCreated = null, int ? ID = null
            int bookID = 0;
            string msg = "";
            var db = new DBAccess();
            bookID = db.SetBook(action,ref msg, genreID, authorID, titleID, dateCreated, bookID);
            if (bookID > 0)
            {
                lblMessage.Text = "Book was inserted succesfully with Book ID = " + bookID;
            }
           

            if (!string.IsNullOrEmpty(msg))
            {
                lblMessage.Text = msg;
                return;
            }
            else if (bookID == -1)
            { 
                lblMessage.Text = "Already exists";
                return;
            }
        }
    }
}