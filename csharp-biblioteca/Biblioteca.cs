using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Biblioteca
    {

        private List<Utente> utenti = new List<Utente>();
        private List<Documento> documenti = new List<Documento>();
        private List<Prestito> prestiti = new List<Prestito>();

        // -----------
        // Costruttore
        // -----------

        public Biblioteca() { }

        // ---------
        // Get e Set
        // ----------

        public List<Utente> Utenti
        { 
            get {  return utenti; } 
        }

        public List<Documento> Documenti
        {
            get { return documenti; }
        }

        public List<Prestito> Prestiti
        {
            get { return prestiti; }
        }


        // ---------
        // Metodi
        // ----------

        public void AddUtente(Utente utente)
        {
            utenti.Add(utente);
        }

        public void AddDocumento(Documento documento)
        {
            documenti.Add(documento);
        }

        public void AddPrestito(Prestito prestito)
        {
            prestiti.Add(prestito);
        }

        public bool CercaDocumento(string codiceOtitolo)
        {

            foreach (var document in documenti)
            {
                if(document.Codice == codiceOtitolo || document.Titolo == codiceOtitolo)
                {
                    Console.WriteLine($"Documento trovato con \"{(document.Codice == codiceOtitolo ? "codice" : "titolo")}\" \"{codiceOtitolo}\": {document.Titolo}");

                    return true;
                }
            }
            Console.WriteLine("Documento non e stato trovato");
            return false;
        }

        public bool CercaPrestitoConNomeCognome(string nome, string cognome)
        {

            foreach (var prestito in prestiti)
            {
                if (prestito.Utente.Persona.Nome == nome && prestito.Utente.Persona.Cognome == cognome)
                {
                    Console.WriteLine($"Prestito trovato per l'utente \"{nome} {cognome}\".");
                    return true;
                }
            }
            Console.WriteLine("Prestito non e stato trovato");
            return false;
        }

    }
}
