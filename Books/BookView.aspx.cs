using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Books
{
    public partial class BookView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtGenre.Text = Session["Genre"].ToString();
                txtAuthor.Text = Session["Author"].ToString();
                string bookID = Session["BookID"].ToString();

                string[] titleOnly = bookID.Split(',');
                List<string> titlesList = new List<string>(titleOnly.Length);
                titlesList.AddRange(titleOnly);
                titlesList.Reverse();
                txtBookID.Text = titleOnly[0].ToString();

                string dateCreated = Session["BookID"].ToString();

                string[] dateOnly = dateCreated.Split(',');
                List<string> datesList = new List<string>(dateOnly.Length);
                datesList.AddRange(dateOnly);
                datesList.Reverse();
                txtDateCreated.Text = dateOnly[1].ToString();
            }

        }


        protected void btnOk_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("~/BookSelect.aspx");
        }
    }
}