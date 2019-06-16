using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tamarflix_real.moviesref;

namespace Tamarflix_real
{
    public partial class ManageMovies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FirstName"] != null && (bool)Session["IsAdmin"]) // if user is connected
            {

                string queryString = SQLQueries.AllMoviesQuery;
                

                moviesref.Movies proxy = new moviesref.Movies();

                Tamarflix_real.moviesref.DataSet ds = proxy.GetAllMovies(queryString);



                MovieRepeater.DataSource = ds;
                MovieRepeater.DataBind();

            }

        }

        protected void RemoveMovie_Click(object sender, CommandEventArgs e)
        {
            var parameter = e.CommandArgument;
            moviesref.Movies proxy = new moviesref.Movies();
            proxy.RemoveGeneralMovie(parameter.ToString());
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}