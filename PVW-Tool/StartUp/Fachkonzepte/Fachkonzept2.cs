using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartUp.Model;

namespace StartUp.Fachkonzepte
{
    class Fachkonzept2 : IFachkonzept
    {
        public void ChangeEmployee(string id, string name, string abteilung)
        {
            throw new NotImplementedException();
        }

        public void CreateEmployee(string name, string Abteilung)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(string id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public List<Employee> SearchFor(string category, string name, string id)
        {
            throw new NotImplementedException();
        }
    }
}
