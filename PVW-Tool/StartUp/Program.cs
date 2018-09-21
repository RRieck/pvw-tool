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

            var jhannes = new Employee()
            {
                Id = "6efd47cf-6b7a-4aca-b4be-ee55256519c5",
                Name ="Johannes kunz",
                Abteilung = "FrontENDE"
            };

            //new Datenhaltung.SqliteDataAccess().WriteNewEntry(jhannes);
            //new Datenhaltung.SqliteDataAccess().ChangeExistingEntry(jhannes);
            //new Datenhaltung.SqliteDataAccess().DeleteEntry("6efd47cf-6b7a-4aca-b4be-ee55256519c5");
            foreach (var item in new Datenhaltung.SqliteDataAccess().GetEmployees())
            {
                Console.WriteLine(item.Name + " arbeitet in der Abteilung "+ item.Abteilung);
            }    

            Console.WriteLine("feetich!");
            Console.ReadLine();
        }
    }
}
