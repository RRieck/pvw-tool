using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using StartUp.Frontend;
using StartUp.Model;

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

            //Testing
            new Datenhaltung.XmlParser().ReadFile();
            new Datenhaltung.XmlParser().WriteNewEntry(new Employee()
            {
                //Danke @J lo das du einen zweiten Vornamen hast ;) sollten das im Frontend validieren, sodass zweitnamen (Vor oder Nachname) mit Bindestrich geschrieben werden müssen 
                Name = "Johannes-Carl Kunz",
                Abteilung = "Front-End"
            });
            new Datenhaltung.XmlParser().WriteNewEntry(new Employee()
            {
                Name = "Maximilian Mahlke",
                Abteilung = "Business-Logik"
            });
            new Datenhaltung.XmlParser().WriteNewEntry(new Employee()
            {
                //Codierung worked auch :thumb:
                Name = "Ron Rieck",
                Abteilung = "Datenhaltung"
            });
        }
    }
}
