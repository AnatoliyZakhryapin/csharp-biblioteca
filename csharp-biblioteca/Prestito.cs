using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Prestito
    {
        private Utente utente;
        private Documento documento;
        private DateTime dal;
        private DateTime all;

        // -----------
        // Costruttore
        // -----------

        public Prestito(Utente utente, Documento documento, DateTime dal, DateTime all)
        {
            this.utente = utente;
            this.documento = documento;
            this.dal = dal;
            this.all = all;
        }

        // ---------
        // Get e Set
        // ----------

        public Utente Utente
        {
            get { return utente; }
            set { utente = value; }
        }

        public Documento Documento
        {
            get { return documento; }
            set { documento = value; }
        }

        public DateTime Dal
        {
            get { return dal; }
            set { dal = value; }
        }

        public DateTime All
        {
            get { return all; }
            set { all = value; }
        }


        // ---------
        // Metodi
        // ----------

        public void StampaInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Stampa informazione del prestito.");
            Console.WriteLine();
            Console.WriteLine("Prestato da:");
            Utente.StampaInfo();
            Console.WriteLine();
            Console.WriteLine("Documento prestato:");
            Documento.StampaInfo();

        }
    }
}
