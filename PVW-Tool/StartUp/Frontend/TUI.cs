using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp.Frontend
{
    class TUI
    {
        public TUI()
        {

            menu();
        }

        void menu()
        {
            InitializeMenu();
            string input = Console.ReadLine();
            if (!InputValidator(input))
            {
                Console.WriteLine("\n Ihre Eingabe entspricht keiner Option.\n");
                Console.ReadLine();
                menu();
            }

            int option = Int32.Parse(input);

            switch (option)
            {
                case 1:
                    AddEmployee();
                    backend(name, abteilung)
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
            }   
        }

        Boolean InputValidator(string input)
        {
            int option;
            bool isInteger = int.TryParse(input, out option);

            return isInteger & option <= 6;
        }

        void InitializeMenu()
        {
            Console.Clear();
            Console.WriteLine("Personal-Verwaltungs-System");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Waehlen Sie eine der Optionen\n");
            Console.WriteLine("(1) - Mitarbeiter Hinzufuegen");
            Console.WriteLine("(2) - Mitarbeiter bearbeiten");
            Console.WriteLine("(3) - Mitarbeiter Suchen");
            Console.WriteLine("(4) - Mitarbeiter Loeschen");
            Console.WriteLine("(5) - Abteilung Suchen");
            Console.WriteLine("(6) - Programm beenden\n");
        }

        void AddEmployee()
        {
            Console.Clear();
            Console.WriteLine("Bitte geben sie zunächst den Namen des Mitarbeiters ein.");
            validator
            rückgabe
            
        }
    }
}
