using System.Collections.Generic;
using System.Linq;
using StartUp.Datenhaltung;
using StartUp.Infrastructure.Extensions;
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
        // -------------Ist es jetzt klar warum es ein string ist (wenn ja einfach comment entfernen :) )?!?-------------------
        public void DeleteEmployee(string id)
        {
            data.DeleteEntry(id);
        }

        public List<Employee> GetEmployees()
        {
            return data.GetEmployees();
        }
        
        public List<Employee> SearchFor(string department, string name, string id)
        {
            var resultList = new List<Employee>();
            var CachedList = new List<Employee>();

            var emplyees = data.GetEmployees();

            if (!string.IsNullOrEmpty(department))
                CachedList.AddRange(emplyees.Where(x => x.Abteilung.Equals(department.Trim())).ToList());

            if (!string.IsNullOrEmpty(name))
                CachedList.AddRange(emplyees.Where(x => x.Name.Equals(name)).ToList());

            if (!string.IsNullOrEmpty(id))
                CachedList.AddRange(emplyees.Where(x => x.Id.Equals(id)).ToList());

            resultList = ListParser.DeleteContainedEntries(CachedList);

            return resultList;
        }
    }
}
