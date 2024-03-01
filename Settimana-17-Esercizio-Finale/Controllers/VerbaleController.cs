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
    public class VerbaleController : Controller
    {
        // GET: Verbale
        public ActionResult Index()
        {
            List<Verbale> listaVerbali = new List<Verbale>();

            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Verbale";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Verbale nuovoVerbale = new Verbale(
                        reader.GetInt32(1),
                        reader.GetInt32(2),
                        reader.GetDateTime(3),
                        reader.GetString(4),
                        reader.GetString(5),
                        reader.GetDateTime(6),
                        reader.GetSqlMoney(7).ToDouble()
                    );
                    try
                    {
                        nuovoVerbale.DecurtamentoPunti = reader.GetInt32(8);
                    }
                    catch
                    {
                        nuovoVerbale.DecurtamentoPunti = 0;
                    }

                    listaVerbali.Add(nuovoVerbale);
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

            Dictionary<int, string> dictionaryAnagrafica = new Dictionary<int, string>();

            try
            {
                conn.Open();
                string query = "SELECT * FROM Anagrafica";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dictionaryAnagrafica.Add(
                        reader.GetInt32(0),
                        reader.GetString(1) + " " + reader.GetString(2)
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

            ViewBag.ListaAnagrafica = dictionaryAnagrafica;

            Dictionary<int, string> dictionaryViolazioni = new Dictionary<int, string>();

            try
            {
                conn.Open();
                string query = "SELECT * FROM Violazione";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dictionaryViolazioni.Add(reader.GetInt32(0), reader.GetString(1));
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

            ViewBag.ListaViolazioni = dictionaryViolazioni;

            return View(listaVerbali);
        }

        public ActionResult Create()
        {
            List<SelectListItem> listaSelectViolazioni = new List<SelectListItem>();

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
                    listaSelectViolazioni.Add(
                        new SelectListItem
                        {
                            Text = reader.GetString(1),
                            Value = reader.GetInt32(0).ToString()
                        }
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

            ViewBag.IdViolazione = listaSelectViolazioni;

            List<SelectListItem> listaSelectAnagrafica = new List<SelectListItem>();

            try
            {
                conn.Open();
                string query = "SELECT * FROM Anagrafica";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    listaSelectAnagrafica.Add(
                        new SelectListItem
                        {
                            Text = reader.GetString(1) + " " + reader.GetString(2),
                            Value = reader.GetInt32(0).ToString()
                        }
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

            ViewBag.IdAnagrafica = listaSelectAnagrafica;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Verbale v)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query =
                    "INSERT INTO Verbale (IdAnagrafica, IdViolazione, DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti) VALUES (@IdAnagrafica, @IdViolazione, @DataViolazione, @IndirizzoViolazione, @NominativoAgente, @DataTrascrizioneVerbale, @Importo, @DecurtamentoPunti)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdAnagrafica", v.IdAnagrafica);
                cmd.Parameters.AddWithValue("@IdViolazione", v.IdViolazione);
                cmd.Parameters.AddWithValue("@DataViolazione", v.DataViolazione);
                cmd.Parameters.AddWithValue("@IndirizzoViolazione", v.IndirizzoViolazione);
                cmd.Parameters.AddWithValue("@NominativoAgente", v.NominativoAgente);
                cmd.Parameters.AddWithValue("@DataTrascrizioneVerbale", v.DataTrascrizioneVerbale);
                cmd.Parameters.AddWithValue("@Importo", v.Importo);
                if (v.DecurtamentoPunti != null)
                {
                    cmd.Parameters.AddWithValue("@DecurtamentoPunti", v.DecurtamentoPunti);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DecurtamentoPunti", 0);
                }
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
