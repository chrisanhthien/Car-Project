using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CarProject.DataAccess
{
    public static class Utility
    {
        public static string cn = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

    }
}