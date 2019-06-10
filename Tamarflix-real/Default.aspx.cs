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
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["TamarlixDBConnectionString"].ToString();
                con.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = String.Format(SQLQueries.AllMoviesQuery);
                cmd.Connection = con;
                OleDbDataReader a = cmd.ExecuteReader();
                OleDbDataAdapter da = new OleDbDataAdapter(String.Format(SQLQueries.UserMoviesQuery, "123456789"), con);
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

        protected void DeleteButton_Click(object sender, CommandEventArgs e)
        {            
            var parameter = e.CommandArgument;
            System.Diagnostics.Debug.WriteLine("Param:" + parameter.ToString());
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["TamarlixDBConnectionString"].ToString();
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = String.Format(SQLQueries.RemovePersonalMovie, parameter.ToString());
            cmd.Connection = con;
            int a = cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect(Request.Url.AbsoluteUri);
            System.Diagnostics.Debug.WriteLine("Affected by delete:" + a.ToString());


        }
    }
}
