using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Settimana_17_Esercizio_Finale.Models
{
    public class Group1
    {
        public int TotVerb { get; set; }

        public int Anagrafica { get; set; }

        public Group1(int totVerb, int anagrafica)
        {
            TotVerb = totVerb;
            Anagrafica = anagrafica;
        }
    }
}
