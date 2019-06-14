using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;
using Tamarflix_real.localhost;


namespace Tamarflix_real
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // create a proxy for the member web service
            localhost.Member proxy = new localhost.Member();

            string[] member = proxy.Login(userName.Text, pwd.Text);
            if (member.Length == 3)
            {
                    System.Diagnostics.Debug.WriteLine(member[0]+" "+member[1]+" "+member[2]);
                    Session["FirstName"] = member[2];
                    Session["UserID"] = member[0];
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