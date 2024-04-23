using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Autore : Person
    {
        // -----------
        // Costruttore
        // -----------
        public Autore(string nome, string cognome) : base(nome, cognome)
        {
        }

        // ---------
        // Metodi
        // ----------

        public override void StampaInfo()
        {
            base.StampaInfo();
        }
    }
}
