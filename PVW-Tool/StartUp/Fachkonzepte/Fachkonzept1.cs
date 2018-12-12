using System.Collections.Generic;
using System.Linq;
using StartUp.Datenhaltung;
using StartUp.Infrastructure.Extensions;
using StartUp.Model;

namespace StartUp.Fachkonzepte
{
    public  class Fachkonzept1 : IFachkonzept
    {
        //XmlParser data;
        readonly SqliteDataAccess _data;

        public Fachkonzept1()
        {
            //data = new XmlParser();
            _data = new SqliteDataAccess();
        }

        public void ChangeEmployee(string id, string name, string department)
        {
            _data.ChangeExistingEntry(new Employee()
            {
                Id = id,
                Name = name,
                Abteilung = department
            });
        }

        public void CreateEmployee(string name, string department)
        {
            _data.WriteNewEntry(new Employee()
            {
                Name = name,
                Abteilung = department
            });
        }

        public void DeleteEmployee(string id)
        {
            _data.DeleteEntry(id);
        }

        public List<Employee> GetEmployees()
        {
            return _data.GetEmployees();
        }
        
        public List<Employee> SearchFor(string department, string name, string id)
        {
            var resultList = _data.GetEmployees();

            if (!string.IsNullOrEmpty(department))
                resultList = resultList.Where(x => x.Abteilung.Contains(department.Trim())).ToList();

            if (!string.IsNullOrEmpty(name))
                resultList = resultList.Where(x => x.Name.Contains(name)).ToList();

            if (!string.IsNullOrEmpty(id))
                resultList = resultList.Where(x => x.Id.Equals(id)).ToList();

            return resultList;
        }
    }
}
