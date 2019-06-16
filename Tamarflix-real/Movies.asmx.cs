using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.OleDb;
using System.Configuration;

namespace Tamarflix_real
{
    /// <summary>
    /// Summary description for Movies
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Movies : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet GetAllMovies(string queryString)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["TamarlixDBConnectionString"].ToString();
            con.Open();

            OleDbDataAdapter da = new OleDbDataAdapter(queryString, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet GetAllCartMovies(string values)
        {

            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["TamarlixDBConnectionString"].ToString();
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(String.Format(SQLQueries.UserCartMovies, values), con);
            System.Diagnostics.Debug.WriteLine("[comaseperated] " + String.Format(SQLQueries.UserCartMovies, values));
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public string GetAllCartMoviesSum(string values)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["TamarlixDBConnectionString"].ToString();
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = String.Format(SQLQueries.UserCartSum, values);
            cmd.Connection = con;
            OleDbDataReader a = cmd.ExecuteReader();
            while (a.Read())
            {
                return a[0].ToString();
            }
            return "0";
        }

        [WebMethod]
        public int BuyCart(string userID, List<string> buyCart) 
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["TamarlixDBConnectionString"].ToString();
            con.Open();
            foreach (string MovieID in buyCart)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = String.Format(SQLQueries.BuyMovie, userID, MovieID);
                cmd.Connection = con;
                int a = cmd.ExecuteNonQuery();
            }

            return 1;
        }

        [WebMethod]
        public DataSet GetMyMovies(string userID)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["TamarlixDBConnectionString"].ToString();
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = String.Format(SQLQueries.AllMoviesQuery);
            cmd.Connection = con;
            OleDbDataAdapter da = new OleDbDataAdapter(String.Format(SQLQueries.UserMoviesQuery, userID), con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public void RemoveMyMovie(string movieID)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["TamarlixDBConnectionString"].ToString();
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = String.Format(SQLQueries.RemovePersonalMovie, movieID);
            cmd.Connection = con;
            int a = cmd.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public void RemoveGeneralMovie(string movieID)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["TamarlixDBConnectionString"].ToString();
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = String.Format(SQLQueries.RemoveGeneralMovie, movieID);
            cmd.Connection = con;
            int a = cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
