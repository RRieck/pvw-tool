using StartUp.Model;
using System;
using System.Security.AccessControl;

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

            objOfFk.CreateEmployee("hans uwe","frw");
            objOfFk.CreateEmployee("hans-thorsten-ernestus damn","entwicklung");
            objOfFk.CreateEmployee("hme-morlig-ernestus Son","entwicklung");

            Console.WriteLine("Welchen Mitarbeiter suchen sie? Eingabe lautet wie folgt: [Abteilung;Name]. (Es muss nicht jedes Feld angegeben werden) Bspw. ;maxmustermann");
            var input = "frw;hans"; //zum Testen -- ansonsten ein console.readline()                 
            var parameters = input.Split(new char []{ ';'},StringSplitOptions.None);


            //should return 1
            var matchedEmployees = objOfFk.SearchFor(parameters[0],parameters[1],null);
        }
    }
}
