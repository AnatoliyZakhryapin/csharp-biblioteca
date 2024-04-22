using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Person
    {
        private string nome;
        private string cognome;

        // -----------
        // Costruttore
        // -----------

        public Person(string nome, string cognome)
        {
            this.nome = nome;
            this.cognome = cognome;
        }

        // ---------
        // Get e Set
        // ----------

        public string Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }

        public string Cognome
        {
            get { return this.cognome; }
            set { this.cognome = value; }
        }
    }
}
