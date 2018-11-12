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

        public void ChangeEmployee(string id, string name, string abteilung)
        {
            data.ChangeExistingEntry(new Employee()
            {
                Id = id,
                Name = name,
                Abteilung = abteilung
            });
        }

        public void CreateEmployee(string name, string abteilung)
        {
            data.WriteNewEntry(new Employee()
            {
                Name = name,
                Abteilung = abteilung
            });
        }

        public void DeleteEmployee(string id)
        {
            data.DeleteEntry(id);
        }

        public List<Employee> GetEmployees()
        {
            return data.GetEmployees();
        }

        public List<Employee> SearchFor(string category, string name, string id)
        {
            return data.GetEmployees()
                .Where(x => x.Id.Equals(id) && x.Abteilung.Equals(category) && x.Name.Contains(name))
                .ToList();
        }
    }
}
