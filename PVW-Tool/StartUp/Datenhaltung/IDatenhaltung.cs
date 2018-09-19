using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartUp.Model;

namespace StartUp.Datenhaltung
{
    public interface IDatenhaltung
    {
        List<Employee> GetEmployees();
        void WriteNewEntry(Employee employee);
        void ChangeExistingEntry(Employee employee);
        void DeleteEntry(string id);
    }
}
