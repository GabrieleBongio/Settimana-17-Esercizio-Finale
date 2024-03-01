using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Settimana_17_Esercizio_Finale.Models;

namespace Settimana_17_Esercizio_Finale.Controllers
{
    public class ViolazioneController : Controller
    {
        // GET: Violazione
        public ActionResult Index()
        {
            List<Violazione> listaViolazioni = new List<Violazione>();

            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Violazione";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    listaViolazioni.Add(new Violazione(reader.GetString(1), reader.GetBoolean(2)));
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return View(listaViolazioni);
        }
    }
}
