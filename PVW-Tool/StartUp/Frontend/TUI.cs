using System;
using System.Text.RegularExpressions;
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
            Tuple<bool, int> validatedInput = IntegerValidator(input);
            if (!validatedInput.Item1 & validatedInput.Item2 <= 6)
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

            string name;
            do
            {
                Console.WriteLine("Bitte geben sie zunächst den Vor- und Zunamen des Mitarbeiters ein.");
                name = Console.ReadLine();
            } while (!CheckValidString(name));

            Tuple<bool, int> validatedInput;
            do
            {
                Console.WriteLine("Bitte wählen sie nun die Abteilung.");
                Console.WriteLine("(1) - Personalabteilung");
                Console.WriteLine("(2) - Entwickler");
                Console.WriteLine("(3) - Netzwerk");
                Console.WriteLine("(4) - Managment");

                validatedInput = IntegerValidator(Console.ReadLine());
            } while (!validatedInput.Item1 & validatedInput.Item2 <= 4 );
            Console.WriteLine(name + " : " + validatedInput.Item2);
            Console.ReadLine();
        }

        Tuple<bool, int> IntegerValidator(string input)
        {
            int option;
            bool isInteger = int.TryParse(input, out option);

            return Tuple.Create(isInteger, option);
        }

        bool CheckValidString(string inputString)
        {
            var regex = new Regex("^[a-zA-Z0-9 äüöÄÜÖß]*$");
            if (!regex.IsMatch(inputString))
            {
                return false;
            }
            return true;
        }
    }
}
