using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Settimana_17_Esercizio_Finale.Models
{
    public class Verbale
    {
        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        public int IdAnagrafica { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        public int IdViolazione { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        public DateTime DataViolazione { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [MaxLength(100, ErrorMessage = "Massimo 100 caratteri")]
        public string IndirizzoViolazione { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [MaxLength(100, ErrorMessage = "Massimo 100 caratteri")]
        public string NominativoAgente { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        public DateTime DataTrascrizioneVerbale { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        public double Importo { get; set; }

        public int? DecurtamentoPunti { get; set; }

        public Verbale() { }

        public Verbale(
            int idAnagrafica,
            int idViolazione,
            DateTime dataViolazione,
            string indirizzoViolazione,
            string nominativoAgente,
            DateTime dataTrascrizioneVerbale,
            double importo
        )
        {
            IdAnagrafica = idAnagrafica;
            IdViolazione = idViolazione;
            DataViolazione = dataViolazione;
            IndirizzoViolazione = indirizzoViolazione;
            NominativoAgente = nominativoAgente;
            DataTrascrizioneVerbale = dataTrascrizioneVerbale;
            Importo = importo;
        }
    }
}
