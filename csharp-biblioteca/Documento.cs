using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Documento
    {
        private string codice;
        private string titolo;
        private int anno;
        private string settore;
        private string scaffale;
        private Autore autore;

        // -----------
        // Costruttore
        // -----------

        public Documento(string codice, string titolo, int anno, string settore, string scaffale, Autore autore)
        {
            this.codice = codice;
            this.titolo = titolo;
            this.anno = anno;
            this.settore = settore;
            this.scaffale = scaffale;
            //this.autore = autore; //Qua punta sul riferimento 
            this.autore = new Autore(autore.Nome, autore.Cognome);// creare copia di autore 
        }

        // ---------
        // Get e Set
        // ----------

        public string Codice
        {
            get { return codice; }
            set { this.codice = value; }
        }

        public string Titolo
        {
            get { return titolo; }
            set { this.titolo = value;}
        }

        public int Anno
        {
            get { return anno; }
            set { anno = value; }
        }

        public string Settore
        {
            get { return settore; }
            set { settore = value; }
        }

        public string Scaffale
        {
            get { return scaffale; }
            set { scaffale = value; }
        }

        public Autore Autore
        {
            get { return autore; }
            set { autore = value; }
        }

        // ---------
        // Metodi
        // ----------

        public virtual void StampaInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Stampa informazione del documento:");
            Console.WriteLine($"Codice: {codice}");
            Console.WriteLine($"Titolo: {titolo}");
            Console.WriteLine($"Anno: {anno}");
            Console.WriteLine($"Settore: {settore}");
            Console.WriteLine($"Scaffale: {scaffale}");
            Console.WriteLine($"Autore: {Autore.Nome} {Autore.Cognome}");
        }
    }


}
