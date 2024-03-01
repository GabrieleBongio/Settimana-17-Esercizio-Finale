using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Settimana_17_Esercizio_Finale.Models
{
    public class Anagrafica
    {
        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [MaxLength(50, ErrorMessage = "Massimo 50 caratteri")]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [MaxLength(50, ErrorMessage = "Massimo 50 caratteri")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [MaxLength(50, ErrorMessage = "Massimo 50 caratteri")]
        public string Indirizzo { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [MaxLength(50, ErrorMessage = "Massimo 50 caratteri")]
        public string Città { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [MaxLength(5, ErrorMessage = "Lunghezza obbligaatoria di 5 caratteri")]
        [MinLength(5, ErrorMessage = "Lunghezza obbligaatoria di 5 caratteri")]
        public string CAP { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [MaxLength(16, ErrorMessage = "Lunghezza obbligaatoria di 16 caratteri")]
        [MinLength(16, ErrorMessage = "Lunghezza obbligaatoria di 16 caratteri")]
        [Display(Name = "Codice Fiscale")]
        public string Cod_Fisc { get; set; }

        public Anagrafica() { }

        public Anagrafica(
            string cognome,
            string nome,
            string indirizzo,
            string cIttà,
            string cAP,
            string cod_Fisc
        )
        {
            Cognome = cognome;
            Nome = nome;
            Indirizzo = indirizzo;
            Città = cIttà;
            CAP = cAP;
            Cod_Fisc = cod_Fisc;
        }
    }
}
