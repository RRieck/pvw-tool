using StartUp.Model;
using System;

namespace StartUp
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Open TUI here 
            //var tui = new TUI();

            //Open GUI Here
            //new Application().Run(new GUI());
            
            
            //new StartUp.Frontend.TUI();

            //si könnte es aussehen :)
            var objOfFk = new Fachkonzepte.Fachkonzept1();

            Console.WriteLine("Welchen Mitarbeiter suchen sie? Eingabe lautet wie folgt: [Abteilung;Name]. (Es muss nicht jedes Feld angegeben werden) Bspw. ;maxmustermann");
            var input = ";hans"; //zum Testen -- ansonsten ein console.readline()                 
            var parameters = input.Split(new char []{ ';'},StringSplitOptions.None);


            var matchedEmployees = objOfFk.SearchFor(parameters[0],parameters[1],null);
        }
    }
}
