using System;
using System.Collections.Generic;
using StartUp.Infrastructure.Validator;
using StartUp.Infrastructure.Converter;
using StartUp.Model;

namespace StartUp.Frontend
{
    class TUI
    {
        public TUI()
        {
            Fachkonzepte.Fachkonzept1 fach = new Fachkonzepte.Fachkonzept1();
            Menu(fach);
        }

        private void Menu(Fachkonzepte.Fachkonzept1 fach)
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
                        Tuple<string, string> employee = AddEmployeeMenu();
                        Console.WriteLine(employee.Item1 + " : " + employee.Item2);
                        fach.CreateEmployee(employee.Item1, employee.Item2);
                        break;
                    case 2:
                        Console.WriteLine("Welchen Mitarbeiter wollen Sie bearbeiten?");
                        List<string> search_employee_for_change = SearchEmployeeMenu();
                        List<Employee> employee_list_for_change = fach.SearchFor(search_employee_for_change[0], search_employee_for_change[1], "id");
                        ShowSearchResult(employee_list_for_change);
                        Console.WriteLine("Geben sie die Zahl des Mitarbeiters ein den sie bearbeiten moechten");
                        Tuple<bool,int> to_be_changed_employee_nr = Validate.IntegerValidator(Console.ReadLine());
                        Employee to_be_changed_employee = employee_list_for_change[to_be_changed_employee_nr.Item2];
                        Employee changed_employee = EditEmployeeMenu(to_be_changed_employee);
                        fach.ChangeEmployee(changed_employee.Id, changed_employee.Name, changed_employee.Abteilung);
                        break;
                    case 3:
                        List<string> search_employee = SearchEmployeeMenu();
                        List<Employee> employee_list = fach.SearchFor(search_employee[0], search_employee[1], "id");
                        ShowSearchResult(employee_list);
                        break;
                    case 4:
                        string customer_id = DeleteEmployeeMenu();
                        fach.DeleteEmployee(customer_id);
                        break;
                    case 5:
                        break;
                    case 6:
                        turnOff = true;
                        break;
                }
            } while (!turnOff);
        }
        private void InitializeMenu()
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

        private List<string> SearchEmployeeMenu()
        {
            List<string> search_parameters = new List<string>();

            Console.WriteLine("Bitte geben sie zunächst den Namen des Mitarbeiters ein.");
            Console.WriteLine("Für Suche mittels Abteilungsname drücken sie Enter ohne Eingabe.");

            string name = Console.ReadLine();
            if (name.Length > 0)
            {
                search_parameters.Add(name);
            }

            Console.WriteLine("Für Suche mittels Abteilungsname drücken sie Enter ohne Eingabe.");

            string department = Console.ReadLine();
            if (department.Length > 0)
            {
                search_parameters.Add(department);
            }

            return search_parameters;
        }

        private Employee EditEmployeeMenu(Employee to_be_changed)
        {
            Console.WriteLine("Diese Eingabe dient zur Namensaenderung. Enter um zur Abteilungsaenderung zu kommen");
            string name = Console.ReadLine();
            if (Validate.CheckValidString(name))
            {
                to_be_changed.Name = name;
            }
            Console.WriteLine("Bitte wählen sie nun die Abteilung.");
            Console.WriteLine("(1) - Personalabteilung");
            Console.WriteLine("(2) - Entwickler");
            Console.WriteLine("(3) - Netzwerk");
            Console.WriteLine("(4) - Managment");
            Tuple<bool, int> validatedInput = Validate.IntegerValidator(Console.ReadLine());
            if (validatedInput.Item1)
            {
                to_be_changed.Abteilung = IDConverter.DepartmentIdConverter(validatedInput.Item2);
            }
            return to_be_changed;
        }

        private string DeleteEmployeeMenu()
        {
            Console.WriteLine("Bitte geben Sie die ID des Mitarbeiters der gelöscht werden soll ein.");
            string customer_id = Console.ReadLine();
            return customer_id;
        }


        private Tuple<string, string> AddEmployeeMenu()
        {
            Console.Clear();

            string name;
            do
            {
                Console.WriteLine("Bitte geben sie zunächst den Vor- und Zunamen des Mitarbeiters ein.");
                Console.WriteLine("Mitarbeiter mit Zweitnamen werden so eingegeben: Hans-Christian Müller");
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

        private void ShowSearchResult(List<Employee> employee_list)
        {
            int count = 1;
            Console.WriteLine("\n");
            foreach ( Employee employee in employee_list)
            {
                Console.WriteLine(count + ". ID: " + employee.Id + " | Name: " + employee.Name + " | Abteilung: " + employee.Abteilung);
                count++;
            }
        }
    }
}
