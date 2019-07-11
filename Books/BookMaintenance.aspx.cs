using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Books
{
    public partial class BookMaintenance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";
                LoadDropDowns();
                pnMain.Visible = false;
                if (ddlBook.SelectedIndex > 0)
                {
                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    btnView.Visible = false;
                }
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

            dt = ds.Tables[2];
            ddlBook.DataSource = dt;
            ddlBook.DataValueField = "TitleID";
            ddlBook.DataTextField = "Title";
            ddlBook.DataBind();
            ddlBook.Items.Insert(0, "Please Select Title");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string action = lblAction.Text;
            int genreID = Convert.ToInt32(ddlGenre.SelectedValue);
            int authorID = Convert.ToInt32(ddlAuthor.SelectedValue);
            int titleID = Convert.ToInt32(ddlTitle.SelectedValue);
            string dateCreated = txtDateCreated.Text;
            

            int bookID = 0;
            string msg = "";
            lblMessage.Text = "";
            var db = new DBAccess();
            bookID = db.SetBook(action, ref msg, genreID, authorID, titleID, dateCreated, bookID);
            if (bookID > 0)
            {
                lblMessage.Text = "Book was inserted succesfully with Book ID = " + bookID;
            }
            else
            {
                if (bookID == 0)
                {
                    lblMessage.Text = "There was an error, " + msg;
                }
            }
            
                      
            

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            btnSave.Text = "OK";
            string dateCreated = txtDateCreated.Text;
            LoadBook();
            
                  
        }

        private void LoadBook()
        {
            if (ddlBook.SelectedIndex > 0)
            {
                pnMain.Visible = true;
                
                ddlAuthor.Enabled = false;
                ddlGenre.Enabled = false;
                ddlTitle.Enabled = false;
                txtDateCreated.Enabled = false;


                int bookId = Convert.ToInt32(ddlBook.SelectedValue);
                var db = new DBAccess();
                DataSet ds = db.GetBook(bookId);
                
                
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    ddlAuthor.SelectedValue = dr["AuthorID"].ToString();
                    ddlGenre.SelectedValue = dr["GenreID"].ToString();
                    ddlTitle.SelectedValue = dr["TitleID"].ToString();
                    txtDateCreated.Text = dr["DateCreated"].ToString();
                   

                }
          
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            
            if (ddlBook.SelectedIndex > 0)
            {
                LoadBook();
                pnMain.Visible = true;
                lblAction.Text = "Update";
                btnSave.Text = "Update";
                
                ddlAuthor.Enabled = true;
                ddlGenre.Enabled = true;
                ddlTitle.Enabled = true;
                txtDateCreated.Enabled = true;


            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (ddlBook.SelectedIndex > 0)
            {
                LoadBook();
                pnMain.Visible = true;
                lblAction.Text = "Delete";
                btnSave.Text = "Delete";
                LoadBook();
                int bookId = Convert.ToInt32(ddlBook.SelectedValue);
                string bookName = ddlBook.SelectedItem.ToString();
              //  Response.Redirect("~/Delete.aspx?BookID=" + bookId + "&BookName=" + bookName);
                
            }
            
        }

        protected void btnNewBook_Click(object sender, EventArgs e)
        {
            lblAction.Text = "Insert";
            btnSave.Text = "Insert";
            LoadBook();
            pnMain.Visible = true;

        }

        protected void ddlBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBook.SelectedIndex > 0)
            {
                pnMain.Visible = false;
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnView.Visible = true;
            }
        }
    }
}