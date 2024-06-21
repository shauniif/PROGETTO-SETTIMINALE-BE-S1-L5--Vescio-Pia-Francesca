using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PROGETTO_SETTIMINALE_BE_S1_L5__Vescio_Pia_Francesca
{
    internal class Contribuente
    {
        private string Nome { get; set; }
        private string Cognome { get; set; }

        private DateTime DataNascita { get; set; }

        private char Sesso { get; set; }

        private string CodiceFiscale { get; set; }
        private string ComuneResidenza { get; set; }

        private decimal RedditoAnnuale { get; set; }

        private decimal impostadaversare;

        public void InserimentoDati()
        {
            Console.WriteLine("inserisci nome");
            string nome = Console.ReadLine();
            Console.WriteLine("inserisci cognome");
            string cognome = Console.ReadLine();
            Console.WriteLine("inserisci il tuo genere: M, F, A (Altro)");
            string genere = Console.ReadLine();
            Console.WriteLine("Inserisci la tua data di Nascita");
            string dataNascita = Console.ReadLine();
            Console.WriteLine("Inserisci il tuo codice fiscale");
            string codiceFiscale = Console.ReadLine();
            Console.WriteLine("Inserisci il tuo comune di residenza");
            string comuneResidenza = Console.ReadLine();
            Console.WriteLine("Inserisci il tuo reddito)");
            string redditoAnnuale = Console.ReadLine();

            Nome = nome;
            Cognome = cognome;
            Sesso = genere[0];
            DataNascita = DateTime.Parse(dataNascita);
            CodiceFiscale = codiceFiscale;
            ComuneResidenza = comuneResidenza;
            RedditoAnnuale = int.Parse(redditoAnnuale);
            CalcoloScaglioniReddito();
            Console.WriteLine(Description());

        }
        public Contribuente() { }

        public Contribuente(string nome, string cognome, DateTime dataNascita, string codiceFiscale, char sesso, string comuneResidenza, decimal redditoAnnuale)
        {
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            CodiceFiscale = codiceFiscale;
            Sesso = sesso;
            ComuneResidenza = comuneResidenza;
            RedditoAnnuale = redditoAnnuale;
        }

        private decimal CalcoloScaglioniReddito()
        {
            decimal aliquota1 = 0.23m;
            decimal aliquota2 = 0.27m;
            decimal aliquota3 = 0.38m;
            decimal aliquota4 = 0.41m;
            decimal aliquota5 = 0.43m;
            impostadaversare = 0;

            decimal primoscaglione = 15000 * aliquota1;
            decimal secondoscaglione = 13000 * aliquota2;
            decimal terzoscaglione = 27000 * aliquota3;
            decimal quartoscaglione = 20000 * aliquota4;

            if (RedditoAnnuale >= 0 && RedditoAnnuale <= 15000)
            {
                impostadaversare = RedditoAnnuale * aliquota1;
            }
            else if (RedditoAnnuale >= 15001 && RedditoAnnuale <= 28000)
            {
                impostadaversare = primoscaglione + (RedditoAnnuale - 15000) * aliquota2;
            }
            else if (RedditoAnnuale >= 28001 && RedditoAnnuale <= 55000)
            {
                impostadaversare = primoscaglione + secondoscaglione + (RedditoAnnuale - 28000) * aliquota3;
            }
            else if (RedditoAnnuale >= 55001 && RedditoAnnuale <= 75000)
            {
                impostadaversare = primoscaglione + secondoscaglione + terzoscaglione + (RedditoAnnuale - 55000) * aliquota4;
            }
            else if (RedditoAnnuale > 75000)
            {
                impostadaversare = primoscaglione + secondoscaglione + terzoscaglione + quartoscaglione + (RedditoAnnuale - 75000) * aliquota5;
            }
            return impostadaversare;
        }


        public string Description()
        {
            CalcoloScaglioniReddito();
            return $"Contribuente:{Nome}  {Cognome}; \nNato il {DataNascita.ToShortDateString()} ({Sesso}); \nResidente in {ComuneResidenza}; \nCodiceFiscale: {CodiceFiscale}; \nReddito dichiarato {RedditoAnnuale}€,\nImposta da versare: {impostadaversare}€"; 
        }


    }
}
