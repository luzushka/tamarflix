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
    /// Summary description for Member
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Member : System.Web.Services.WebService
    {


        [WebMethod]
        public string[] Login(string username, string password)
        {
            System.Diagnostics.Debug.WriteLine("[creds]" + username + password);
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["TamarlixDBConnectionString"].ToString();
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = String.Format(SQLQueries.RegisteredUsersQuery, username, password);
            cmd.Connection = con;
            OleDbDataReader a = cmd.ExecuteReader();
            string[] member = new string[3];
            while (a.Read())
            {
                System.Diagnostics.Debug.WriteLine(a[0].ToString() + " " + a[1].ToString() + " " + a[2].ToString());
                member[0] = a[0].ToString();
                member[1] = a[1].ToString();
                member[2] = a[2].ToString();
                System.Diagnostics.Debug.WriteLine("[member]" + member[0] + member[1] + member[2]);

                return member;
            }
            System.Diagnostics.Debug.WriteLine("[nomember]");
            return new string[0];
        }
    }
}
