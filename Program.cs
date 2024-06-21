namespace PROGETTO_SETTIMINALE_BE_S1_L5__Vescio_Pia_Francesca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Contribuente c = new Contribuente("Valentina", "Rossi", new DateTime(1980, 12, 10), "RSSVNT90L10H501W", 'F', "Milano", 45350);

            Console.WriteLine(c.Description());
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Contribuente c2 = new Contribuente();
            c2.InserimentoDati();
        }
    }
}
