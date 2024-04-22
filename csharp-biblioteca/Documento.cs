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
        private Person autore;

        // -----------
        // Costruttore
        // -----------

        public Documento(string codice, string titolo, int anno, string settore, string scaffale, Person autore)
        {
            this.codice = codice;
            this.titolo = titolo;
            this.anno = anno;
            this.settore = settore;
            this.scaffale = scaffale;
            this.autore = autore;
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

        public Person Autore
        {
            get { return autore; }
            set { autore = value; }
        }
    }


}
