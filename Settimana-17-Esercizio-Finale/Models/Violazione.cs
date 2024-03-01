using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Settimana_17_Esercizio_Finale.Models
{
    public class Violazione
    {
        public string Descrizione { get; set; }

        public bool Contestabile { get; set; }

        public Violazione() { }

        public Violazione(string descrizione, bool contestabile)
        {
            Descrizione = descrizione;
            Contestabile = contestabile;
        }
    }
}
