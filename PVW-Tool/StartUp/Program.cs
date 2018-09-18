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
            //-------------------------------------------------------------------------------------------------------------------------------------
            
            //Open TUI here 
            //var tui = new TUI();

            //Open GUI Here
            //new Application().Run(new GUI());

            foreach (var item in new Datenhaltung.XmlParser().GetEmployees())
            {
                var output = $"{item.Name} aus der Abteilung {item.Abteilung} mit der Id {item.Id}";
                Console.WriteLine(output);
                Console.WriteLine(new String('-', output.Length));
            }

            Console.ReadLine();
        }
    }
}
