using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using StartUp.Model;

namespace StartUp.Fachkonzepte
{
    class Fachkonzept1 : IFachkonzept
    {
        Datenhaltung.XmlParser xml;
        Datenhaltung.SqliteDataAccess sql;
        string _dataStructure;

        public Fachkonzept1(string dataStructure)
        {
            if (dataStructure.ToLower().Trim().Equals("xml"))
            {
                xml = new Datenhaltung.XmlParser();
                _dataStructure = dataStructure.ToLower().Trim();
            }
            else if (dataStructure.ToLower().Trim().Equals("sql"))
            {
                sql = new Datenhaltung.SqliteDataAccess();
                _dataStructure = dataStructure;
            }
            else
                Debug.Write("Keine Datenanbinung => 'Yeeeee'");
        }

        public void ChangeEmployee(string id, string name, string abteilung)
        {
            if (_dataStructure.Equals("xml"))
            {
                xml.ChangeExistingEntry(new Employee()
                {
                    Id = id,
                    Name = name,
                    Abteilung = abteilung
                });
            }
        }

        public void CreateEmployee(string name, string abteilung)
        {
            if (_dataStructure.Equals("xml"))
            {
                xml.WriteNewEntry(new Employee()
                {
                    Name = name,
                    Abteilung = abteilung
                });
            }
            else if (_dataStructure.Equals("sql"))
            {
                sql.WriteNewEntry(new Employee()
                {
                    Name = name,
                    Abteilung = abteilung
                });
            }
        }

        public void DeleteEmployee(string id)
        {
            if (_dataStructure.Equals("xml"))
                xml.DeleteEntry(id);
            else if (_dataStructure.Equals("sql"))
                sql.DeleteEntry(id);

        }

        public List<Employee> GetEmployees()
        {
            return _dataStructure.Equals("xml") ? xml.GetEmployees() : sql.GetEmployees();
        }

        public List<Employee> SearchFor(string category, string name, string id)
        {
            if (_dataStructure.Equals("xml"))
                return xml.GetEmployees().Where(x => x.Id.Equals(id) && x.Abteilung.Equals(category) && x.Name.Contains(name)).ToList();
            else if (_dataStructure.Equals("sql"))
                return sql.GetEmployees().Where(x => x.Id.Equals(id) && x.Abteilung.Equals(category) && x.Name.Contains(name)).ToList();
            return null;
        }
    }
}
