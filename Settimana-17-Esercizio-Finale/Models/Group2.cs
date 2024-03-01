using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Settimana_17_Esercizio_Finale.Models
{
    public class Group2
    {
        public int TotPunti { get; set; }

        public int Anagrafica { get; set; }

        public Group2(int totPunti, int anagrafica)
        {
            TotPunti = totPunti;
            Anagrafica = anagrafica;
        }
    }
}
