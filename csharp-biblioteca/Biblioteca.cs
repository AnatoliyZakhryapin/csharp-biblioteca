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

        public void AddUtente(Utente utente) => utenti.Add(utente);

        public void AddDocumento(Documento documento) => documenti.Add(documento);

        public void AddPrestito(Prestito prestito) => prestiti.Add(prestito);

        public Documento CercaDocumento(string codiceOtitolo)
        {
            foreach (Documento documento in documenti)
            {
                if(documento.Codice == codiceOtitolo || documento.Titolo == codiceOtitolo)
                {
                    Console.WriteLine($"Documento trovato con \"{(documento.Codice == codiceOtitolo ? "codice" : "titolo")}\" \"{codiceOtitolo}\": {documento.Titolo}");
                    documento.StampaInfo();
                    return documento;
                }
            }
            Console.WriteLine("Documento non e stato trovato");
            return null;
        }

        public List<Prestito> CercaPrestitoConNomeCognome(string nome, string cognome)
        {
            List<Prestito> prestitiTrovati = new List<Prestito>();

            foreach (Prestito prestito in prestiti)
            {
                if (prestito.Utente.Nome == nome && prestito.Utente.Cognome == cognome)
                {
                   prestitiTrovati.Add(prestito);
                }
            }

            if (prestitiTrovati.Count > 0)
            {
                Console.WriteLine($"Trovati {prestitiTrovati.Count()} prestiti per l'utente \"{nome} {cognome}\".");

                foreach (Prestito prestito in prestitiTrovati)
                {
                    prestito.StampaInfo();
                }
            }
            else
            {
                Console.WriteLine($"NON SONO STATI trovati i prestiti per l'utente \"{nome} {cognome}\".");
            }

            return prestitiTrovati;
        }
        public void StampaListaUtenti()
        {
            Console.WriteLine();
            Console.WriteLine("STAMPA DELLA LISTA DEI UTENTI DI BIBLIOTECA");
            Console.WriteLine($"Utenti totali: {utenti.Count()}");
            foreach (Utente utente in utenti)
            {
                utente.StampaInfo();
            }
        }
        public void StampaListaDocumenti()
        {
            Console.WriteLine();
            Console.WriteLine("STAMPA DELLA LISTA DEI DOCUMENTI DI BIBLIOTECA");
            Console.WriteLine($"Documenti totali: {documenti.Count()}");
            foreach (Documento documento in documenti)
            {
                documento.StampaInfo();
            }
        }
        public void StampaListaPrestiti()
        {
            Console.WriteLine();
            Console.WriteLine("STAMPA DELLA LISTA DEI PRESTITI DI BIBLIOTECA");
            Console.WriteLine($"Prestiti totali: {prestiti.Count()}");
            foreach (Prestito prestito in prestiti)
            {
                prestito.StampaInfo();
            }
        }
        public void CreareFakeDatiUtenti(int numeroUtenti)
        {
            for (int i = 0; i < numeroUtenti; i++)
            {
                string nome = "Nome" + i;
                string cognome = "Cognome" + i;
                string email = $"utente{i}@biblioteca.com";
                string password = "password" + i;
                string recapito = "+123456789" + i;

                AddUtente(new Utente(nome, cognome, email, password, recapito));
            }
        }
        public void CreareFakeDatiLibri(int numeroLibri)
        {
            for (int i = 0; i < numeroLibri; i++)
            {
                int numeroPagine = new Random().Next(100, 1000); 
                string codice = "L" + i;
                string titolo = "Libro" + i;
                int anno = new Random().Next(1800, 2022);
                string settore = "Settore" + i;
                string scaffale = "Scaffale" + i;
                string autoreNome = "AutoreNome" + i;
                string autoreCognome = "AutoreCognome" + i;

                AddDocumento(new Libro(numeroPagine, codice, titolo, anno, settore, scaffale, new Person(autoreNome, autoreCognome)));
            }
        }
        public void CreareFakeDatiDvd(int numeroDvd)
        {
            for (int i = 0; i < numeroDvd; i++)
            {
                TimeSpan durata = TimeSpan.FromHours(new Random().Next(1, 3)); 
                string codice = "D" + i;
                string titolo = "DVD" + i;
                int anno = new Random().Next(1970, 2022);
                string settore = "Settore" + i;
                string scaffale = "Scaffale" + i;
                string registaNome = "RegistaNome" + i;
                string registaCognome = "RegistaCognome" + i;

                AddDocumento(new Dvd(durata, codice, titolo, anno, settore, scaffale, new Person(registaNome, registaCognome)));
            }
        }
        public void CreareFakeDatiPrestiti(int maxNumeroPrestitiUtente)
        {
            foreach (Utente utente in utenti)
            {
                int numPrestitiUtente = new Random().Next(maxNumeroPrestitiUtente);

                for (int i = 0; i < numPrestitiUtente; i++)
                {
                    Documento documento = documenti[new Random().Next(documenti.Count)];

                    int giorniPrestito = new Random().Next(7, 22);

                    AddPrestito(new Prestito(utente, documento, DateTime.Now, DateTime.Now.AddDays(giorniPrestito)));
                }
            }
        }
    }
}
