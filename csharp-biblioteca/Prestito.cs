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

        // ---------
        // Get e Set
        // ----------

        public Person Person
        {
            get { return person; }
            set { person = value; }
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
    }
}
