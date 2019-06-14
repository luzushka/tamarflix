using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;
using Tamarflix_real.moviesref;

namespace Tamarflix_real
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FirstName"] == null)
            {
                loginToProceed.Text = "Please log-in to proceed...";
                movieTablePanel.Visible = false;

            }
            else
            {
                loginToProceed.Text = "";
                movieTablePanel.Visible = true;
                moviesref.Movies proxy = new moviesref.Movies();
                MovieRepeater.DataSource = proxy.GetMyMovies(Session["UserID"].ToString());
                MovieRepeater.DataBind();

            }
        }

        protected void DeleteButton_Click(object sender, CommandEventArgs e)
        {            
            var parameter = e.CommandArgument;
            moviesref.Movies proxy = new moviesref.Movies();

            proxy.RemoveMyMovie(parameter.ToString());
            
            Response.Redirect(Request.Url.AbsoluteUri);


        }
    }
}
