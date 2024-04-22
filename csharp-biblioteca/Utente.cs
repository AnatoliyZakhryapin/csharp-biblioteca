using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Utente : Person
    {
        private string email;
        private string password;
        private string recapito;

        // -----------
        // Costruttore
        // -----------
        public Utente (string nome, string cognome, string email, string password, string recapito) : base (nome, cognome)
        {
            this.email = email;
            this.password = password;
            this.recapito = recapito;
        }

        // ---------
        // Get e Set
        // ----------

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


        // ---------
        // Metodi
        // ----------

        public override void StampaInfo()
        {
            base.StampaInfo();
            Console.WriteLine();
            Console.WriteLine("Stampa informazione dell'utente:");
            Console.WriteLine($"Email: {email}");
            //Console.WriteLine($"Password: {password}");
            Console.WriteLine($"Recapito: {recapito}");
        }
    }
}
