using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1.Models
{
    public class ostava
    {
        public int id { get; set; }
        public string naziv { get; set; }
        public int kolicina { get; set; }
        public string rok_trajanja { get; set; }

        public ostava() { }

        public ostava(DataRow ostava)
        {
            id = (int)ostava["id"];
            naziv = ostava["naziv"].ToString();
            kolicina = (int)ostava["kolicina"];
            rok_trajanja = ostava["rok_trajanja"].ToString();
        }
    }
}