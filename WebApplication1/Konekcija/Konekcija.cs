using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace WebApplication1.Konekcija
{
    public class Konekcija
    {
        public static string KonektujSe()
        { 
            return ConfigurationManager.ConnectionStrings["ostava"].ConnectionString;
        }
    }
}