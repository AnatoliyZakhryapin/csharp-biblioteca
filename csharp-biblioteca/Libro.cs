using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Libro : Documento
    {
        private int pagine;

        // -----------
        // Costruttore
        // -----------

        public Libro(int pagine, string codice, string titolo, int anno, string settore, string scaffale, Autore autore) : base(codice, titolo, anno, settore, scaffale, autore)
        { 
           this.pagine = pagine; 
        }

        // ---------
        // Get e Set
        // ----------

        public int Pagine
        {
            get { return pagine; }
            set { pagine = value; }
        }

        // ---------
        // Metodi
        // ----------

        public override void StampaInfo()
        {
            base.StampaInfo();
            Console.WriteLine($"Pagine: {pagine}");
            Console.WriteLine("Tipo: LIBRO");
        }
    }
}
