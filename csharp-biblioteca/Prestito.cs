using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Prestito
    {
        private Person person;
        private Documento documento;
        private DateTime dal;
        private DateTime all;

        // -----------
        // Costruttore
        // -----------

        public Prestito(Person person, Documento documento, DateTime dal, DateTime all)
        {
            this.person = person;
            this.documento = documento;
            this.dal = dal;
            this.all = all;
        }
    }
}
