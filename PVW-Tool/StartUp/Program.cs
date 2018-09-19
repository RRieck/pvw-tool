using System;
using System.Threading;
using StartUp.Datenhaltung;
using StartUp.Model;

namespace StartUp
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //-------------------------------------------------------------------------------------------------------------------------------------

            //Open TUI here 
            //var tui = new TUI();

            //Open GUI Here
            //new Application().Run(new GUI());

            

            var employee1 = new Employee()
            {
                Name = "Ron Rieck",
                Abteilung = "Datenhaltung"
            };
            var employee2 = new Employee()
            {
                //nname vname trennung test
                Name = "Johannes-Carl Kunz",
                Abteilung = "Front-End"
            };
            var employee3 = new Employee()
            {
                //Umlaut test
                Name = "Mäx",
                Abteilung = "Business-Logik"
            };

            new Datenhaltung.SqlDataAccess().WriteNewEntry(employee1);
            new Datenhaltung.SqlDataAccess().WriteNewEntry(employee2);
            new Datenhaltung.SqlDataAccess().WriteNewEntry(employee3);

            Thread.Sleep(1000);

            foreach (var item in new SqlDataAccess().GetEmployees())
            {
                var output = $"{item.Name} aus der Abteilung {item.Abteilung} mit der Id {item.Id}";
                Console.WriteLine(output);
                Console.WriteLine(new string('-', output.Length));
            }

            Console.ReadLine();

        }
    }
}
