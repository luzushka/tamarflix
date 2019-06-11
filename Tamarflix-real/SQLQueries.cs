using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tamarflix_real
{
    public static class SQLQueries
    {
        public const string RegisteredUsersQuery = "select * from Registered_Users where UserName='{0}' and Password='{1}'";
        public const string AllMoviesQuery = "select * from MovList";
        public const string AllMoviesExcludingCart = "select * from MovList where MovID not in ({0})";
        public const string UserCartMovies = "select * from MovList where MovID in ({0})";
        public const string UserCartSum = "select sum(Price) from MovList where MovID in ({0})";
        public const string UserMoviesQuery = @"select *
                                                from UserMovies um
                                                left join MovList mv
                                                on um.MovieID = mv.MovID
                                                where um.UserID = '{0}'";
        public const string RemovePersonalMovie = "delete from UserMovies where RecordID = {0}";
        public const string BuyMovie = @"insert into UserMovies (UserID, MovieID)
VALUES ('{0}', {1});";
    }
}