using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tamarflix_real
{
    public static class CartUtils
    {
        public static string ListToComaSeperatedMovieString(List<string> list)
        {
            string comaSeperatedMovies = ""; // make string for SQL query
            int movieIndex = 0;
            foreach (string movieID in list)
            {
                if (movieIndex != list.Count - 1)
                {
                    comaSeperatedMovies += "'" + movieID + "',";
                }

                else
                {
                    comaSeperatedMovies += "'" + movieID + "'";
                }
            }

            return comaSeperatedMovies;
        }
    }
}