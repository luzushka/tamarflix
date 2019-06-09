using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tamarflix_real
{
    public static class SQLQueries
    {
        public const string RegisteredUsersQuery = "select * from Registered_Users where UserName='{0}' and Password='{1}'";
    }
}