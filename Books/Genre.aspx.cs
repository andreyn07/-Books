using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Books
{
    public partial class Genre : System.Web.UI.Page
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
            var db = new DBAccess();
          
            DataSet dt = db.GetLookup();
            ddlGenre.DataSource = dt;
            ddlGenre.DataValueField = "GenreID";
            ddlGenre.DataTextField = "Genre";
            ddlGenre.DataBind();
            ddlGenre.Items.Insert(0, "Please Select Genre");
           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!txtGenre.Text.isEntered())
            {
                lblMessage.Text = "Please enter the Genre";
                return;
            }
            string genre = txtGenre.Text;
            var db = new DBAccess();
            string msg = "";
            int genreId = db.SetGenre(genre, ref msg);
            if (!string.IsNullOrEmpty(msg))
            {
                lblMessage.Text = msg;
                return;
            }
            if(genreId == 0)
            {
                lblMessage.Text = "Alredy exists";
                return;
            }

            lblMessage.Text = "The new genre ID is" + " " + genreId.ToString();
            LoadDropDowns();
        }
    }
}