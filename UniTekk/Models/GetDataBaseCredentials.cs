using System;
using System.Data;
using System.Data.SqlClient;

namespace UniTekk.Models
{  
    public static class databaseCredentials
    {
        public static string Get_PuBConnectionString()
        {
            try
            {
                return @"Data Source=.;Initial Catalog=UniTekk;Integrated Security=True";
            }
            catch { return null; }
        }
    }
}