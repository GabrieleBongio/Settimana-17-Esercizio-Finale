using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Settimana_17_Esercizio_Finale.Models
{
    public class Group3
    {
        public double Importo { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public DateTime dataViolazione { get; set; }
        public int DecurtamentoPunti { get; set; }

        public Group3(
            double importo,
            string cognome,
            string nome,
            DateTime dataViolazione,
            int decurtamentoPunti
        )
        {
            Importo = importo;
            Cognome = cognome;
            Nome = nome;
            this.dataViolazione = dataViolazione;
            DecurtamentoPunti = decurtamentoPunti;
        }
    }
}
