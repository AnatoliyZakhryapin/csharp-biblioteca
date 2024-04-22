namespace csharp_biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Biblioteca biblioteca = new Biblioteca();

            biblioteca.AddUtente(new Utente("555", new Person("Anatoliy", "Zakhryapin"), "anatoliy@gmail.com", "password", "+33333333333"));

            biblioteca.AddDocumento(new Libro(100, "123", "Monte Cristo", 1888, "bla bla", "A1", new Person("nome", "cognome")));
            biblioteca.AddDocumento(new Libro(200, "345", "Cuori di Atlantide", 2000, "aaaaaa bla bla", "A2", new Person("nome2", "cognome2")));
            biblioteca.AddDocumento(new Dvd(TimeSpan.FromHours(2), "678", "Il padrino", 1972, "Film", "B456", new Person("Francis Ford", "Coppola")));

            biblioteca.AddPrestito(new Prestito(biblioteca.Utenti[0], biblioteca.Documenti[2], DateTime.Now, DateTime.Now.AddDays(14)));

            biblioteca.CercaDocumento("12223");

            biblioteca.CercaPrestitoConNomeCognome("Anatoliy", "Zakhryapin");

            //foreach (var prestito in biblioteca.Prestiti)
            //{
            //    Console.WriteLine(prestito.Utente.Persona.Nome);
            //    Console.WriteLine(prestito.Utente.Persona.Cognome);
            //    Console.WriteLine(prestito.Documento);
            //    Console.WriteLine(prestito.Dal);
            //    Console.WriteLine(prestito.All);
            //}

            //foreach (var documento in biblioteca.Documenti)
            //{
            //    Console.WriteLine(documento.Codice);
            //}
        }
    }
}
