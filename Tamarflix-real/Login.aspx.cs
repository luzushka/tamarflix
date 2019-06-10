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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["TamarlixDBConnectionString"].ToString();
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = String.Format(SQLQueries.RegisteredUsersQuery, userName.Text, pwd.Text);
            cmd.Connection = con;
            OleDbDataReader a = cmd.ExecuteReader();
            while (a.Read())
            {
                System.Diagnostics.Debug.WriteLine(a[0]+" "+a[1]+" "+a[2]);
                Session["FirstName"] = a[2];
                Session["UserID"] = a[0];
                List<string> MovieCart = new List<string>();
                MovieCart.Add("1");
                MovieCart.Add("10");
                MovieCart.Add("13");
                Session["BuyCart"] = MovieCart;
                Response.Redirect("/");

            }

            Label1.Text = "Invalid credentials. Please try again!";
        }
    }
}