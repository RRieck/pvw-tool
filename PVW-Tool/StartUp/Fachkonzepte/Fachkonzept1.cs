using System.Collections.Generic;
using System.Linq;
using StartUp.Datenhaltung;
using StartUp.Model;

namespace StartUp.Fachkonzepte
{
    class Fachkonzept1 : IFachkonzept
    {
        XmlParser data;
        //SqliteDataAccess data;
        public Fachkonzept1()
        {
            data = new XmlParser();
          //  data = new SqliteDataAccess();
        }

        public void ChangeEmployee(string id, string name, string department)
        {
            data.ChangeExistingEntry(new Employee()
            {
                Id = id,
                Name = name,
                Abteilung = department
            });
        }

        public void CreateEmployee(string name, string department)
        {
            data.WriteNewEntry(new Employee()
            {
                Name = name,
                Abteilung = department
            });
        }
        // Hier würde ich es auch besser finden wenn wir da ein integer eigentlich überegeben?! weiß nur nicht ob dann wo anders was kaputt geht
        //  dewegen habe ich es nicht geändert
        public void DeleteEmployee(string id)
        {
            data.DeleteEntry(id);
        }

        public List<Employee> GetEmployees()
        {
            return data.GetEmployees();
        }
        // Hier würde ich mir noch gerne wünschen das wir eine mit allen drei paramtern einzeln los schicken können -> 
        // also zum beispiel nur mit name oder nur mit abteilung weil sonst brauch man die suche nicht
        // -- hoffe ron du liest das hier :P
        public List<Employee> SearchFor(string department, string name, string id)
        {
            return data.GetEmployees()
                .Where(x => x.Id.Equals(id) && x.Abteilung.Equals(department) && x.Name.Contains(name))
                .ToList();
        }
    }
}
