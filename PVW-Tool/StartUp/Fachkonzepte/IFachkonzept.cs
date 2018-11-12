using StartUp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp.Fachkonzepte
{
    interface IFachkonzept
    {
        void CreateEmployee(string name, string Abteilung);
        void ChangeEmployee(string id);
        void DeleteEmployee();
        List<Employee> SearchFor(string category);
        List<Employee> GetEmployees();
    }
}
