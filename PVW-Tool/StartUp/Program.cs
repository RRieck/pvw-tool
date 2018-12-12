using StartUp.Frontend.GUI;
using StartUp.Model;
using System;
using System.Linq;
using System.Security.AccessControl;
using System.Windows;

namespace StartUp
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            new Frontend.TUI();
            new Application().Run(new GUI());


            

            //si könnte es aussehen :)
            //var objOfFk = new Fachkonzepte.Fachkonzept1();

            //objOfFk.CreateEmployee("hans uwe","frw");
            //objOfFk.CreateEmployee("hans-thorsten-ernestus damn","entwicklung");
            //objOfFk.CreateEmployee("hme-morlig-ernestus Son","entwicklung");

            //Console.WriteLine("Welchen Mitarbeiter suchen sie? Eingabe lautet wie folgt: [Abteilung;Name]. (Es muss nicht jedes Feld angegeben werden) Bspw. ;maxmustermann");
            //var input = "frw;hans"; //zum Testen -- ansonsten ein console.readline()                 
            //var parameters = input.Split(new char []{ ';'},StringSplitOptions.None);


            //should return 1
            //var matchedEmployees = objOfFk.SearchFor("entwicklung", null, null);
            //Console.WriteLine(matchedEmployees.First().Name);
            //Console.ReadLine();
        }
    }
}
