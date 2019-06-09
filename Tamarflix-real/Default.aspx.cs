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
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FirstName"] == null)
            {
                loginToProceed.Text = "Please log-in to proceed...";

            }
            else
            {
                loginToProceed.Text = "";
            }
        }
    }
}
