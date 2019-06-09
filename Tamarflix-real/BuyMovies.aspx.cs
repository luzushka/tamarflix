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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FirstName"] != null)
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["TamarlixDBConnectionString"].ToString();
                con.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = String.Format(SQLQueries.AllMoviesQuery);
                cmd.Connection = con;
                OleDbDataReader a = cmd.ExecuteReader();
                OleDbDataAdapter da = new OleDbDataAdapter(SQLQueries.AllMoviesQuery, con);
                DataSet ds = new DataSet();
                da.Fill(ds);


                while (a.Read())
                {
                    System.Diagnostics.Debug.WriteLine(a[0] + " " + a[1] + " " + a[2]);

                }

                
                MovieRepeater.DataSource = ds;
                MovieRepeater.DataBind();

            }

        }
    }
}