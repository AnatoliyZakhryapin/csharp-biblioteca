using System;

namespace csharp_biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
     
            Biblioteca biblioteca = new Biblioteca();

            biblioteca.AddUtente(new Utente("Anatoliy", "Zakhryapin", "anatoliy@gmail.com", "password", "+33333333333"));

            biblioteca.CreareFakeDatiUtenti(10);
            biblioteca.CreareFakeDatiLibri(10);
            biblioteca.CreareFakeDatiDvd(10);
            biblioteca.CreareFakeDatiPrestiti(5);

            biblioteca.AddDocumento(new Libro(100, "123", "Monte Cristo", 1888, "bla bla", "A1", new Autore("nome", "cognome")));
            biblioteca.AddDocumento(new Libro(200, "345", "Cuori di Atlantide", 2000, "aaaaaa bla bla", "A2", new Autore("nome2", "cognome2")));
            biblioteca.AddDocumento(new Dvd(TimeSpan.FromHours(2), "678", "Il padrino", 1972, "Film", "B456", new Autore("Francis Ford", "Coppola")));

            biblioteca.AddPrestito(new Prestito(biblioteca.Utenti[0], biblioteca.Documenti[2], DateTime.Now, DateTime.Now.AddDays(14)));
            biblioteca.AddPrestito(new Prestito(biblioteca.Utenti[0], biblioteca.Documenti[1], DateTime.Now, DateTime.Now.AddDays(14)));

            //biblioteca.CercaDocumento("123");
            //biblioteca.StampaListaPrestiti();
            //biblioteca.CercaPrestitoConNomeCognome("Anatoliy", "Zakhryapin");

            //biblioteca.StampaListaUtenti();
            //biblioteca.StampaListaDocumenti();
            //biblioteca.StampaListaPrestiti();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Seleziona opzione:");
                Console.WriteLine();
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Registrati");
                Console.WriteLine();
                Console.WriteLine("0. Esci");

                // Prendiamo l'input dell'utente
                string input = Console.ReadLine();

                // Converte l'input in un numero intero
                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 0:
                            // Uscita dal programma
                            return;
                        case 1:
                            EnterByLogin(biblioteca);
                            break;
                        case 2:
                            EnterByRegistratione(biblioteca);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Input non valido. Riprova.");
                }
            }
        }
        public static Utente? Auth(Biblioteca biblioteca)
        {
            Console.WriteLine();
            Console.WriteLine("Benvenuto nella biblioteca!");

            Console.WriteLine();
            Console.WriteLine("Inserisci credenziali:");

            Utente utenteLogato = null;
            
            while (true)
            {
                Console.Write("Email:");
                string email = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Password:");
                string password = Console.ReadLine();
                Console.WriteLine();

                foreach (Utente utente in biblioteca.Utenti)
                {
                    if (utente.Email == email && utente.Password == password)
                    {
                        utenteLogato = utente;
                        break;
                    }
                }

                if (utenteLogato != null)
                {
                    Console.WriteLine($"Benvenuto, {utenteLogato.Nome} {utenteLogato.Cognome}!");
                    // Esegui altre operazioni o menu per l'utente loggato...

                    return utenteLogato;
                }
                else
                {
                    Console.WriteLine("Email o password non validi. Riprova.");
                    // Gestisci il caso in cui le credenziali non siano valide...

                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Vuoi tornare al menu precedente? (S/N)");
                        Console.WriteLine();
                        string input = Console.ReadLine();

                        if (input.ToUpper() == "S")
                        {
                            return utenteLogato; 
                        }
                        else if (input.ToUpper() == "N")
                        {
                            break; 
                        }
                        else
                        {
                            Console.WriteLine("Input non valido. Riprova.");
                        }
                    }
                }

            }
        }
        public static void EnterByLogin(Biblioteca biblioteca)
        {
            Utente utenteLogato = Auth(biblioteca);

            Navigatione(utenteLogato, biblioteca);
        }
        public static void EnterByRegistratione(Biblioteca biblioteca)
        {

            AggiungiNuovoUtente(biblioteca);

            Utente utenteLogato = Auth(biblioteca);

            Navigatione(utenteLogato, biblioteca);
        }
        public static void Navigatione(Utente utenteLogato, Biblioteca biblioteca)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Seleziona opzione:");
                Console.WriteLine();
                Console.WriteLine("1. Guarda la lista dei utenti");
                Console.WriteLine("2. Guarda la lista dei documenti");
                Console.WriteLine("3. Guarda la lista dei prestiti");
                Console.WriteLine("4. Aggiungi nuovo utente");
                Console.WriteLine("5. Aggiungi nuovo documento");
                Console.WriteLine("6. Aggiungi nuovo prestito");
                Console.WriteLine("7. Cerca documento");
                Console.WriteLine("8. Cerca prestito");
                Console.WriteLine();
                Console.WriteLine("0. Esci");

                // Prendiamo l'input dell'utente
                string input = Console.ReadLine();

                // Converte l'input in un numero intero
                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 0:
                            // Uscita dal programma
                            return;
                        case 1:
                            biblioteca.StampaListaUtenti();
                            break;
                        case 2:
                            biblioteca.StampaListaDocumenti();
                            break;
                        case 3:
                            biblioteca.StampaListaPrestiti();
                            break;
                        case 4:
                            AggiungiNuovoUtente(biblioteca);
                            break;
                        case 5:
                            AggiungiNuovoDocumento(biblioteca);
                            break;
                        case 6:
                            AggiungiNuovoPrestito(biblioteca, utenteLogato);
                            break;
                        case 7:
                            CercaDocumento(biblioteca, utenteLogato);
                            break;
                        case 8:
                            CercaPrestito(biblioteca);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Input non valido. Riprova.");
                }
            }
        }
        public static void CercaPrestito(Biblioteca biblioteca)
        {
            Console.WriteLine();
            Console.WriteLine("Inserisci il nome dell'utente:");
            string nome = Console.ReadLine();

            Console.WriteLine("Inserisci il cognome dell'utente:");
            string cognome = Console.ReadLine();

            List<Prestito> prestitiTrovati = biblioteca.CercaPrestitoConNomeCognome(nome, cognome);

            if (prestitiTrovati.Count > 0)
            {
                foreach (Prestito prestito in prestitiTrovati)
                {
                    prestito.StampaInfo();
                }
            }
        }
        public static void CercaDocumento(Biblioteca biblioteca, Utente utenteLogato)
        {
            Console.WriteLine("Vuoi cercare un documento per codice o per titolo? (C/T)");
            string scelta = Console.ReadLine().ToUpper();

            string codiceOtitolo;
            if (scelta == "C")
            {
                Console.WriteLine("Inserisci il codice del documento:");
                codiceOtitolo = Console.ReadLine();
            }
            else if (scelta == "T")
            {
                Console.WriteLine("Inserisci il titolo del documento:");
                codiceOtitolo = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Scelta non valida.");
                return;
            }

            Documento documento = biblioteca.CercaDocumento(codiceOtitolo);
            if (documento == null)
            {
                Console.WriteLine("Documento non trovato.");
            }
            else
            {
                Console.WriteLine("Documento trovato:");
                documento.StampaInfo();

                Console.WriteLine("Vuoi proseguire con prestito questo documento? (S/N)");
                string risposta = Console.ReadLine().ToUpper();
                if (risposta == "S")
                {
                    AggiungiNuovoPrestito(biblioteca, utenteLogato, documento);
                }
            }
        }
        public static Prestito AggiungiNuovoPrestito(Biblioteca biblioteca, Utente utenteLogato, Documento risultatoRicerca = null)
        {
            if ( risultatoRicerca == null)
            {
                Console.WriteLine("Vuoi prestare l'ultimo documento aggiunto? (S/N)");
                string scelta = Console.ReadLine();

                Documento documento;

                if (scelta.ToUpper() == "S")
                {
                    documento = biblioteca.Documenti.LastOrDefault();
                    if (documento == null)
                    {
                        Console.WriteLine("Nessun documento disponibile per il prestito.");
                        return null;
                    }
                }
                else if (scelta.ToUpper() == "N")
                {
                    Console.WriteLine("Inserisci il codice o il titolo del documento che vuoi prestare:");
                    string codiceOtitolo = Console.ReadLine();

                    documento = biblioteca.CercaDocumento(codiceOtitolo);
                    if (documento == null)
                    {
                        Console.WriteLine("Documento non trovato.");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Scelta non valida. Operazione annullata.");
                    return null;
                }

                DateTime dataInizio = DateTime.Now;
                DateTime dataFine = DateTime.Now.AddDays(new Random().Next(7, 22));

                Prestito nuovoPrestito = new Prestito(utenteLogato, documento, dataInizio, dataFine);

                biblioteca.AddPrestito(nuovoPrestito);

                Console.WriteLine("Nuovo prestito aggiunto:");
                nuovoPrestito.StampaInfo();

                return nuovoPrestito;
            }
            else
            {
                DateTime dataInizio = DateTime.Now;
                DateTime dataFine = DateTime.Now.AddDays(new Random().Next(7, 22));

                Prestito nuovoPrestito = new Prestito(utenteLogato, risultatoRicerca, dataInizio, dataFine);

                biblioteca.AddPrestito(nuovoPrestito);

                Console.WriteLine("Nuovo prestito aggiunto:");
                nuovoPrestito.StampaInfo();

                return nuovoPrestito;
            }

        }
        public static Documento AggiungiNuovoDocumento(Biblioteca biblioteca)
        {
            //biblioteca.AddDocumento(new Libro(200, "345", "Cuori di Atlantide", 2000, "aaaaaa bla bla", "A2", new Person("nome2", "cognome2")));
            //biblioteca.AddDocumento(new Dvd(TimeSpan.FromHours(2), "678", "Il padrino", 1972, "Film", "B456", new Person("Francis Ford", "Coppola")));
            Console.WriteLine();
            Console.WriteLine("Aggiungi codice:");
            string codice = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Aggiungi titolo:");
            string titolo = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Aggiungi anno:");
            int anno = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Aggiungi settore:");
            string settore = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Aggiungi scaffale:");
            string scaffale = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Aggiungi autore (nome):");
            string autoreNome = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Aggiungi autore (cognome):");
            string autoreCognome = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Se il documento è un libro, aggiungi il numero di pagine. Se è un DVD, aggiungi la durata in ore:");
            int durataPagine = Convert.ToInt32(Console.ReadLine());

            // Scelta del tipo di documento
            Console.WriteLine("Scegli il tipo di documento (L per libro, D per DVD):");
            char tipoDocumento = Console.ReadKey().KeyChar;
            Console.WriteLine();

            Documento nuovoDocumento;

            if (tipoDocumento == 'L' || tipoDocumento == 'l')
            {
                nuovoDocumento = new Libro(durataPagine, codice, titolo, anno, settore, scaffale, new Autore(autoreNome, autoreCognome));
            }
            else if (tipoDocumento == 'D' || tipoDocumento == 'd')
            {
                TimeSpan durata = TimeSpan.FromHours(durataPagine);
                nuovoDocumento = new Dvd(durata, codice, titolo, anno, settore, scaffale, new Autore(autoreNome, autoreCognome));
            }
            else
            {
                Console.WriteLine("Tipo di documento non valido. Creazione documento annullata.");
                return null;
            }

            biblioteca.AddDocumento(nuovoDocumento);

            Console.WriteLine("Nuovo documento aggiunto:");
            nuovoDocumento.StampaInfo();

            return nuovoDocumento;
        }
        public static Utente AggiungiNuovoUtente(Biblioteca biblioteca)
        {
            Console.WriteLine();
            Console.WriteLine("Aggiungi nome");
            string nome = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Aggiungi Cognome");
            string cognome = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Aggiungi Email");
            string email = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Aggiungi password");
            string password = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Aggiungi recapito");
            string recapito = Console.ReadLine();

            biblioteca.AddUtente(new Utente(nome, cognome, email, password, recapito));

            Utente ultimoUtenteAggiunto = biblioteca.Utenti.Last();

            Console.WriteLine("Ultimo utente aggiunto:");
            
            ultimoUtenteAggiunto.StampaInfo();

            return ultimoUtenteAggiunto;
        }
    }
}
