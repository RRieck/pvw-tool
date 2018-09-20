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


            //new Datenhaltung.SqliteDataAccess().WriteNewEntry(new Employee()
            //{
            //    Name = "Test Testing",
            //    Abteilung = "Test"
            //});


            foreach (var el in new Datenhaltung.SqliteDataAccess().GetEmployees())
            {
                Console.WriteLine(el.Name);
            }

            //new Datenhaltung.SqliteDataAccess().GetEmployees();

            Console.ReadLine();
        }
    }
}
