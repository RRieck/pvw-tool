using System;
using System.Collections.Generic;
using StartUp.Model;

namespace StartUp.Fachkonzepte
{
    class Fachkonzept1 : IFachkonzept
    {
        Object context;
        public Fachkonzept1()
        {
            context = Activator.CreateInstance<Datenhaltung.XmlParser>();
        }
        
        public void ChangeEmployee(string id)
        {
            throw new NotImplementedException();
        }

        public void CreateEmployee(string name, string Abteilung)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee()
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployees()
        {
            var test = context;
            return null;
        }

        public List<Employee> SearchFor(string category)
        {
            return null;
        }
    }
}
