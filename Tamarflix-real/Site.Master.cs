using System;
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
            if (Session["FirstName"] != null)
            {
                loginLink.Visible = false;
                logoutLink.Visible = true;
                greetLabel.Text = "Hello, " + Session["FirstName"].ToString();
                System.Diagnostics.Debug.WriteLine("session:" + Session["FirstName"].ToString());
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
