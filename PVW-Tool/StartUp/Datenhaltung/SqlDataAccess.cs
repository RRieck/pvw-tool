using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using StartUp.Infrastructure.Extensions;
using StartUp.Model;

namespace StartUp.Datenhaltung
{
    public class SqlDataAccess : IDatenhaltung
    {
        public List<Employee> GetEmployees()
        {
            var employees = new List<Employee>();
            using (var context = new SQLDataDataContext())
            {
                foreach (var entry in context.Personal)
                {
                    var guid = IdCreator.Generate();
                    var abteilungsname = context.Abteilung.Where(x => x.abteilung_id.Equals(entry.abteilung_id))
                        .Select(y => y.name).FirstOrDefault();

                    var newEmployee = new Employee()
                    {
                        Id = guid.ToString(),
                        Name = entry.vname + " " + entry.nname,
                        Abteilung = abteilungsname
                    };
                    employees.Add(newEmployee);
                }
            }
            return employees;
        }

        public void WriteNewEntry(Employee employee)
        {
            try
            {
                using (var context = new SQLDataDataContext())
                {
                    var personal_nr = IdCreator.Generate();
                    var abteilung_id = "A_" + IdCreator.Generate();

                    var dbEmployee = new Personal()
                    {
                        personal_nr = personal_nr.ToString(),
                        vname = NameParser.ReceivePreAndLastname(employee.Name).First(),
                        nname = NameParser.ReceivePreAndLastname(employee.Name).Last(),
                        abteilung_id = abteilung_id
                    };

                    context.Personal.InsertOnSubmit(dbEmployee);

                    var dbDepartment = new Abteilung()
                    {
                        name = employee.Abteilung,
                        abteilung_id = abteilung_id
                    };

                    context.Abteilung.InsertOnSubmit(dbDepartment);

                    context.SubmitChanges(ConflictMode.ContinueOnConflict);
                }
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                throw;
            }
            
        }

        public void DeleteEntry(string id)
        {
            if (!ContainsEntry(id)) return;

            using (var context = new SQLDataDataContext())
            {
                var employeeEntry = context.Personal.First(x => x.personal_nr.Equals(id));
                var departmentId = employeeEntry.abteilung_id;

                context.Personal.DeleteOnSubmit(employeeEntry);
                context.Abteilung.DeleteOnSubmit(context.Abteilung.First(x => x.abteilung_id.Equals(departmentId)));

                context.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
        }

        public void ChangeExistingEntry(Employee employee)
        {
            if (!ContainsEntry(employee.Id)) return;

            using (var context = new SQLDataDataContext())
            {
                var employeeEntry = context.Personal.First(x => x.personal_nr.Equals(employee.Id));
                var departmentEntry = context.Abteilung.First(x => x.abteilung_id.Equals(employeeEntry.abteilung_id));

                employeeEntry.vname = NameParser.ReceivePreAndLastname(employee.Name).First();
                employeeEntry.nname = NameParser.ReceivePreAndLastname(employee.Name).Last();
                departmentEntry.name = employee.Abteilung;

                context.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
        }

        bool ContainsEntry(string id)
        {
            using (var context = new SQLDataDataContext())
            {
                return context.Personal.Any(x => x.personal_nr.Equals(id));
            }
        }
    }
}
