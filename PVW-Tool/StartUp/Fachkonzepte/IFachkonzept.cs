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
        void ChangeEmployee(string id, string name, string abteilung);
        void DeleteEmployee(string id);
        List<Employee> SearchFor(string category, string name, string id);
        List<Employee> GetEmployees();
    }
}
