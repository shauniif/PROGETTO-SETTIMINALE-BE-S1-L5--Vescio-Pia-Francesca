using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PROGETTO_SETTIMINALE_BE_S1_L5__Vescio_Pia_Francesca
{
    public enum Genere
    {
        M,
        F,
        A
    }
    internal class Contribuente
    {
        private string nome;
        private string cognome;

        private DateTime dataNascita;
        private Genere genere;

        private string codiceFiscale;
        private string comuneResidenza;

        private decimal redditoAnnuale;

        private decimal impostadaversare;

        public void InserimentoDati()
        {
            Console.WriteLine("inserisci nome");
            string nomeinput = Console.ReadLine();
            Console.WriteLine("inserisci cognome");
            string cognomeinput = Console.ReadLine();

            Genere genereselezionato;
            bool genereValido = false;

            // Switch per gestire l'input del genere dell'utente  
            do
            {
                Console.WriteLine("Inserisci il tuo genere: M, F, A (Altro)");
                string genereIn = Console.ReadLine().ToUpper();

                switch (genereIn)
                {
                    case "M":
                        genereselezionato = Genere.M;
                        genereValido = true;
                        break;
                    case "F":
                        genereselezionato = Genere.F;
                        genereValido = true;
                        break;
                    case "A":
                        genereselezionato = Genere.A;
                        genereValido = true;
                        break;
                    default:
                        Console.WriteLine("Genere non valido. Inserire M, F o A.");
                        Console.WriteLine("");
                        break;
                }

            } while (!genereValido);

            
            string dataNascitainput;
            DateTime dataNascitaa;
            bool dataNascitaValida = false;
            do
            {
                Console.WriteLine("Inserisci la tua data di Nascita nel formato dd/mm/yyyy");
               dataNascitainput = Console.ReadLine();

                if (DateTime.TryParseExact(dataNascitainput, "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataNascita))
                {
                    dataNascitaValida = true;
                }
                else
                {
                    Console.WriteLine("Formato data non valido. Inserire nel formato dd/mm/yyyy.");
                    Console.WriteLine("");
                }   
            } while (!dataNascitaValida);

            Console.WriteLine("Inserisci il tuo codice fiscale");
            string codiceFiscaleinput = Console.ReadLine();
            Console.WriteLine("Inserisci il tuo comune di residenza");
            string comuneResidenzainput = Console.ReadLine();
            Console.WriteLine("Inserisci il tuo reddito");
            string redditoAnnualeinput = Console.ReadLine();

            nome = nomeinput;
            cognome = cognomeinput;
            dataNascita = DateTime.Parse(dataNascitainput);
            codiceFiscale = codiceFiscaleinput;
            comuneResidenza = comuneResidenzainput;
            redditoAnnuale = int.Parse(redditoAnnualeinput);
            CalcoloScaglioniReddito();
            Console.WriteLine(Description());
            

        }
        public Contribuente() { }

        public Contribuente(string nome, string cognome, DateTime dataNascita, string codiceFiscale, Genere sesso, string comuneResidenza, decimal redditoAnnuale)
        {
            this.nome = nome;
            this.cognome= cognome;
            this.dataNascita = dataNascita;
            this.codiceFiscale = codiceFiscale;
            this.genere = sesso;
            this.comuneResidenza= comuneResidenza;
            this.redditoAnnuale= redditoAnnuale;
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

            if (redditoAnnuale >= 0 && redditoAnnuale <= 15000)
            {
                impostadaversare = redditoAnnuale * aliquota1;
            }
            else if (redditoAnnuale >= 15001 && redditoAnnuale <= 28000)
            {
                impostadaversare = primoscaglione + (redditoAnnuale - 15000) * aliquota2;
            }
            else if (redditoAnnuale >= 28001 && redditoAnnuale <= 55000)
            {
                impostadaversare = primoscaglione + secondoscaglione + (redditoAnnuale - 28000) * aliquota3;
            }
            else if (redditoAnnuale >= 55001 && redditoAnnuale <= 75000)
            {
                impostadaversare = primoscaglione + secondoscaglione + terzoscaglione + (redditoAnnuale - 55000) * aliquota4;
            }
            else if (redditoAnnuale > 75000)
            {
                impostadaversare = primoscaglione + secondoscaglione + terzoscaglione + quartoscaglione + (redditoAnnuale - 75000) * aliquota5;
            }
            return impostadaversare;
        }


        public string Description()
        {
            CalcoloScaglioniReddito();
            Console.WriteLine("");
            return $"Contribuente:{nome} {cognome}; \nNato il {dataNascita.ToShortDateString()} ({genere}); \nResidente in {comuneResidenza}; \nCodiceFiscale: {codiceFiscale}; \nReddito dichiarato {redditoAnnuale}€,\nImposta da versare: {impostadaversare}€"; 
        }


    }
}
