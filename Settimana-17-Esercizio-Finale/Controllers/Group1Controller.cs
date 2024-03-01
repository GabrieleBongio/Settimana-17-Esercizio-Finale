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
    public class Group1Controller : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // GET: Group1
        public ActionResult Ricerca1()
        {
            List<Group1> Esercizio1 = new List<Group1>();

            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query = "SELECT COUNT(*), IdAnagrafica FROM Verbale GROUP BY IdAnagrafica";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Esercizio1.Add(new Group1(reader.GetInt32(0), reader.GetInt32(1)));
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

            return View(Esercizio1);
        }

        public ActionResult Ricerca2()
        {
            List<Group2> Esercizio2 = new List<Group2>();

            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query =
                    "SELECT SUM(DecurtamentoPunti), IdAnagrafica FROM Verbale GROUP BY IdAnagrafica";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        Esercizio2.Add(new Group2(reader.GetInt32(0), reader.GetInt32(1)));
                    }
                    catch
                    {
                        Esercizio2.Add(new Group2(0, reader.GetInt32(1)));
                    }
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

            return View(Esercizio2);
        }

        public ActionResult Ricerca3()
        {
            List<Group3> Esercizio3 = new List<Group3>();

            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query =
                    "SELECT Importo, Cognome, Nome, dataViolazione, DecurtamentoPunti FROM Verbale INNER JOIN Anagrafica ON Verbale.IdAnagrafica = Anagrafica.IdAnagrafica WHERE DecurtamentoPunti > 10";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Esercizio3.Add(
                        new Group3(
                            reader.GetSqlMoney(0).ToDouble(),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetDateTime(3),
                            reader.GetInt32(4)
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

            return View(Esercizio3);
        }

        public ActionResult Ricerca4()
        {
            List<Verbale> Esercizio4 = new List<Verbale>();

            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Verbale WHERE Importo > 400";
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

                    Esercizio4.Add(nuovoVerbale);
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

            return View(Esercizio4);
        }
    }
}
