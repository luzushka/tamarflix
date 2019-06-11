using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;

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
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["TamarlixDBConnectionString"].ToString();
                con.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(String.Format(SQLQueries.UserCartMovies, comaSeperatedMovies), con);
                System.Diagnostics.Debug.WriteLine("[comaseperated] " + String.Format(SQLQueries.UserCartMovies, comaSeperatedMovies));
                DataSet ds = new DataSet();
                da.Fill(ds);

                MovieRepeater.DataSource = ds;
                MovieRepeater.DataBind();

                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = String.Format(SQLQueries.UserCartSum, comaSeperatedMovies);
                cmd.Connection = con;
                OleDbDataReader a = cmd.ExecuteReader();
                sumNumberLabel.Text = "0";
                while (a.Read())
                {
                    sumNumberLabel.Text = a[0].ToString();

                }
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
            var parameter = e.CommandArgument;
            System.Diagnostics.Debug.WriteLine("Param:" + parameter.ToString());
            List<string> buyCart = (List<string>)Session["BuyCart"];

            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["TamarlixDBConnectionString"].ToString();
            con.Open();
            foreach (string MovieID in buyCart)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = String.Format(SQLQueries.BuyMovie, Session["UserID"], MovieID);
                cmd.Connection = con;
                int a = cmd.ExecuteNonQuery();
            }

            Session["BuyCart"] = new List<string>();
            
            System.Diagnostics.Debug.WriteLine("buycart:" + buyCart.ToString());
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}