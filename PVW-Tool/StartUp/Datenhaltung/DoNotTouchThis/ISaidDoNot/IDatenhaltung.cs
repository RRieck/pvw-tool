using System.Collections.Generic;
using StartUp.Model;

namespace StartUp.Datenhaltung.DoNotTouchThis.ISaidDoNot
{
    public interface IDatenhaltung
    {
        List<Employee> GetEmployees();
        void WriteNewEntry(Employee employee);
        void ChangeExistingEntry(Employee employee);
        void DeleteEntry(string id);
    }
}
