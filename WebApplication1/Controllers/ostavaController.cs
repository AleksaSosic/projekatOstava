using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Konekcija;
using System.Security.Principal;
using System.Net.Http;
using System.Web.UI;

namespace WebApplication1.Controllers
{
    public class ostavaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Unesi()
        {
            return View();
        }
        public ActionResult SacuvajPodatke(ostava ost)
        {
            using (SqlConnection konekt = new SqlConnection(Konekcija.Konekcija.KonektujSe()))
            {
                using (SqlCommand komand = new SqlCommand("INSERT INTO ostava VALUES ('" + ost.naziv + "', '" + ost.kolicina + "', " + ost.rok_trajanja + ")", konekt))
                {
                    if (konekt.State != ConnectionState.Open) konekt.Open();
                    komand.ExecuteNonQuery();
                }
            }

            return RedirectToAction("table_ostava");
        }
        public ActionResult table_ostava()
        {
            List<ostava> ostava = new List<ostava>();
            using (SqlConnection konekt = new SqlConnection(Konekcija.Konekcija.KonektujSe()))
            {
                using (SqlCommand komand = new SqlCommand("SELECT * FROM ostava", konekt))
                {
                    if (konekt.State != ConnectionState.Open) konekt.Open();

                    SqlDataReader dr_ostava = komand.ExecuteReader();
                    DataTable dt_ostava = new DataTable();
                    dt_ostava.Load(dr_ostava);

                    foreach (DataRow ostavaSlog in dt_ostava.Rows) ostava.Add(new ostava(ostavaSlog));
                }
            }

            return View(ostava);
        }
    }
}