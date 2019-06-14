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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FirstName"] != null) // if user is connected
            {
                List<string> buyCart = (List<string>)Session["BuyCart"];
                string queryString = "";
                if (buyCart != null && buyCart.Count > 0) // hide movies already in the cart
                {
                    string comaSeparatedMovies = CartUtils.ListToComaSeperatedMovieString(buyCart);
                    queryString = String.Format(SQLQueries.AllMoviesExcludingCart, comaSeparatedMovies);
                }
                else
                {
                    queryString = SQLQueries.AllMoviesQuery;
                }

                moviesref.Movies proxy = new moviesref.Movies();

                Tamarflix_real.moviesref.DataSet ds = proxy.GetAllMovies(queryString);


                
                MovieRepeater.DataSource = ds;
                MovieRepeater.DataBind();

            }

        }

        protected void AddToCart_Click(object sender, CommandEventArgs e)
        {            
            var parameter = e.CommandArgument;
            List<string> buyCart = (List<string>)Session["BuyCart"];
            buyCart.Add(parameter.ToString());
            System.Diagnostics.Debug.WriteLine("buycart:" + buyCart.ToString());
            Response.Redirect("~/MyCart.aspx");
        }
    }
}