using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Books
{
    public partial class BookSelect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LoadDropDowns();


            }
        }

        void LoadDropDowns()
        {
            var db = new DBAccess();
            DataSet ds = db.GetLookup();
            DataTable dt = ds.Tables[0];
            ddlGenre.DataSource = dt;
            ddlGenre.DataValueField = "GenreID";
            ddlGenre.DataTextField = "Genre";
            ddlGenre.DataBind();
            ddlGenre.Items.Insert(0, "Please Select Genre");


        }


        protected void ddlGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGenre.SelectedIndex > 0)
            {
                var db = new DBAccess();
                int genreId = Convert.ToInt32(ddlGenre.SelectedValue);
                DataSet ds = db.GetAuthor(genreId);
                DataTable dt = ds.Tables[0];          
                ddlAuthor.DataSource = dt;
                ddlAuthor.DataValueField = "AuthorID";
                ddlAuthor.DataTextField = "FullName";
                ddlAuthor.DataBind();
                ddlAuthor.Items.Insert(0, "Please Select Author");
                
            }
        }

        protected void ddlAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAuthor.SelectedIndex > 0)
            {
                var db = new DBAccess();
                int authorId = Convert.ToInt32(ddlAuthor.SelectedValue);
                int genreId = Convert.ToInt32(ddlGenre.SelectedValue);

                DataSet ds = db.GetTitle(authorId, genreId);
                DataTable dt = ds.Tables[0];
                
                ddlBooks.DataSource = dt;
                ddlBooks.DataValueField = "BookID" ;
                ddlBooks.DataTextField =  "BookDesc" ;
                ddlBooks.DataBind();
                ddlBooks.Items.Insert(0, "Please Select");

            }
        }

        protected void ddlBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBooks.SelectedIndex > 0)
            {
                Session["Genre"] = ddlGenre.SelectedItem;
                Session["Author"] = ddlAuthor.SelectedItem;
                Session["BookID"] = ddlBooks.SelectedItem.Text;
                Response.Redirect("~/BookView.aspx");
            }
           
        }
    }
}