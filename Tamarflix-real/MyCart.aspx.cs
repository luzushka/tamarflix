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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            List<string> buyCart = (List<string>)Session["BuyCart"];
            if (buyCart != null && buyCart.Count > 0)
            {
                string comaSeperatedMovies = CartUtils.ListToComaSeperatedMovieString(buyCart);

                moviesref.Movies proxy = new moviesref.Movies();

                MovieRepeater.DataSource = proxy.GetAllCartMovies(comaSeperatedMovies);
                MovieRepeater.DataBind();

                sumNumberLabel.Text = "0";
                sumNumberLabel.Text = proxy.GetAllCartMoviesSum(comaSeperatedMovies);


                noMovieLabel.Visible = false;

            }
            else
            {
                movieTablePanel.Visible = false;
                noMovieLabel.Visible = true;
            }
        }

        protected void DeleteButton_Click(object sender, CommandEventArgs e)
        {
            var parameter = e.CommandArgument;
            System.Diagnostics.Debug.WriteLine("Param:" + parameter.ToString());
            List<string> buyCart = (List<string>)Session["BuyCart"];
            buyCart.Remove(parameter.ToString());
            System.Diagnostics.Debug.WriteLine("buycart:" + buyCart.ToString());
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void BuyNow_Click(object sender, CommandEventArgs e)
        {
            object parameter = e.CommandArgument;
            System.Diagnostics.Debug.WriteLine("Param:" + parameter.ToString());
            List<string> buyCartList = (List<string>)Session["BuyCart"];

            moviesref.Movies proxy = new moviesref.Movies();
            int answer = proxy.BuyCart(Session["UserID"].ToString(), buyCartList.ToArray());

            Session["BuyCart"] = new List<string>();
            
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}