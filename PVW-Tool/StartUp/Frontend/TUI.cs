using System;
using StartUp.Infrastructure.Validator;
using StartUp.Infrastructure.Converter;

namespace StartUp.Frontend
{
    class TUI
    {
        public TUI()
        {
            Fachkonzepte.Fachkonzept1 fach = new Fachkonzepte.Fachkonzept1();
            Menu(fach);
        }

        void Menu(Fachkonzepte.Fachkonzept1 fach)
        {
            bool turnOff;
            do
            {
                InitializeMenu();
                turnOff = false;
                string input = Console.ReadLine();
                Tuple<bool, int> validatedInput = Validate.IntegerValidator(input);
                if (!validatedInput.Item1 & validatedInput.Item2 <= 6)
                {
                    Console.WriteLine("\n Ihre Eingabe entspricht keiner Option.\n");
                    Console.ReadLine();
                    Menu(fach);
                }

                int option = Int32.Parse(input);

                switch (option)
                {
                    case 1:
                        Tuple<string, string> employee = AddEmployee();
                        Console.WriteLine(employee.Item1 + " : " + employee.Item2);
                        fach.CreateEmployee(employee.Item1, employee.Item2);
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
                        turnOff = true;
                        break;
                }
            } while (!turnOff);
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

        Tuple<string, string> AddEmployee()
        {
            Console.Clear();

            string name;
            do
            {
                //vlt noch dazuschreiben, dass Zweitnamen mit einem "-" getrennt werden müssen => ansonsten läufts ganz gut :thumb:
                Console.WriteLine("Bitte geben sie zunächst den Vor- und Zunamen des Mitarbeiters ein.");
                name = Console.ReadLine();
            } while (!Validate.CheckValidString(name));

            Tuple<bool, int> validatedInput;
            do
            {
                Console.WriteLine("Bitte wählen sie nun die Abteilung.");
                Console.WriteLine("(1) - Personalabteilung");
                Console.WriteLine("(2) - Entwickler");
                Console.WriteLine("(3) - Netzwerk");
                Console.WriteLine("(4) - Managment");

                validatedInput = Validate.IntegerValidator(Console.ReadLine());
            } while (!validatedInput.Item1 & validatedInput.Item2 <= 4);
            return new Tuple<string, string>(name, IDConverter.DepartmentIdConverter(validatedInput.Item2));
        }
    }
}
