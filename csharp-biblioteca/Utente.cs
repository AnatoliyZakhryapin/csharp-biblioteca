using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Utente
    {
        private string codice;
        private string nome;
        private string cognome;
        private string email;
        private string password;
        private string recapito;

        // -----------
        // Costruttore
        // -----------
        public Utente (string codice, string nome, string cognome, string email, string password, string recapito)
        {
            this.codice = codice;
            this.nome = nome;
            this.cognome = cognome;
            this.email = email;
            this.password = password;
            this.recapito = recapito;
        }

        // ---------
        // Get e Set
        // ----------
        public string Codice
        {
            get { return codice; }
            set { this.codice = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { this.nome = value; }
        }

        public string Cognome
        {
            get { return cognome; }
            set { this.cognome = value; }
        }

        public string Email
        {
            get { return email; }
            set { this.email = value; }
        }

        public string Password
        {
            get { return password; }
            set { this.password = value; }
        }

        public string Recapito
        {
            get { return recapito; }
            set { this.recapito = value;}
        }
    }
}
