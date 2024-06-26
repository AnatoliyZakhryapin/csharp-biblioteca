﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Dvd : Documento
    {
        private TimeSpan durata;

        // -----------
        // Costruttore
        // -----------

        public Dvd(TimeSpan durata, string codice, string titolo, int anno, string settore, string scaffale, Autore autore) : base(codice, titolo, anno, settore, scaffale, autore)
        {
            this.durata = durata;
        }

        // ---------
        // Get e Set
        // ----------

        public TimeSpan Durata
        {
            get { return durata; }
            set { durata = value; }
        }


        // ---------
        // Metodi
        // ----------

        public override void StampaInfo()
        {
            base.StampaInfo();
            Console.WriteLine($"durata: {durata}");
            Console.WriteLine("Tipo: DVD");
        }
    }
}
