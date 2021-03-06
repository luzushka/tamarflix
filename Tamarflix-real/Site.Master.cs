﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tamarflix_real
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FirstName"] != null && !(bool)Session["IsAdmin"])
            {
                loginLink.Visible = false;
                logoutLink.Visible = true;
                greetLabel.Text = "Hello, " + Session["FirstName"].ToString();
                System.Diagnostics.Debug.WriteLine("session:" + Session["FirstName"].ToString());
                NavigationMenu.Items.Add(new MenuItem
                {
                    Text = "Buy Movies",
                    NavigateUrl = "~/BuyMovies.aspx"
                });
                NavigationMenu.Items.Add(new MenuItem
                {
                    Text = String.Format("Your cart({0})", ((List<string>)Session["BuyCart"]).Count),
                    NavigateUrl = "~/MyCart.aspx"
                });
            }
            else if (Session["FirstName"] != null && (bool)Session["IsAdmin"])
            {
                loginLink.Visible = false;
                logoutLink.Visible = true;
                greetLabel.Text = "Hello, administrator " + Session["FirstName"].ToString();
                System.Diagnostics.Debug.WriteLine("session:" + Session["FirstName"].ToString());
                NavigationMenu.Items.Add(new MenuItem
                {
                    Text = "Manage Movies",
                    NavigateUrl = "~/ManageMovies.aspx"
                });
            }

            else
            {
                loginLink.Visible = true;
                logoutLink.Visible = false;
                greetLabel.Visible = false;
                System.Diagnostics.Debug.WriteLine("false");
            }

        }

        protected void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
        {

        }
    }
}
