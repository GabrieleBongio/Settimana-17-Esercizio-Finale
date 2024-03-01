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
    public class AnagraficaController : Controller
    {
        // GET: Trasgressori
        public ActionResult Index()
        {
            List<Anagrafica> listaAnagrafica = new List<Anagrafica>();

            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Anagrafica";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    listaAnagrafica.Add(
                        new Anagrafica(
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5),
                            reader.GetString(6)
                        )
                    );
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

            return View(listaAnagrafica);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Anagrafica a)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query =
                    "INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Città, CAP, Cod_Fisc) VALUES (@Cognome, @Nome, @Indirizzo, @Città, @CAP ,@Cod_Fisc)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Cognome", a.Cognome);
                cmd.Parameters.AddWithValue("@Nome", a.Nome);
                cmd.Parameters.AddWithValue("@Indirizzo", a.Indirizzo);
                cmd.Parameters.AddWithValue("@Città", a.Città);
                cmd.Parameters.AddWithValue("@CAP", a.CAP);
                cmd.Parameters.AddWithValue("@Cod_Fisc", a.Cod_Fisc);
                SqlDataReader reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return RedirectToAction("Index");
        }
    }
}
