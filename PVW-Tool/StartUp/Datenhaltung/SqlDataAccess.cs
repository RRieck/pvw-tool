using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using StartUp.Datenhaltung.DoNotTouchThis.ISaidDoNot;
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
                    var abteilungsname = context.Abteilung
                        .Where(x => x.abteilung_id.Equals(entry.abteilung_id))
                        .Select(x => x.name)
                        .First();

                    employees.Add(new Employee()
                    {
                        Id = IdCreator.Generate().ToString(),
                        Name = entry.vname + " " + entry.nname,
                        Abteilung = abteilungsname
                    });
                }
            }
            return employees;
        }

        public void WriteNewEntry(Employee employee)
        {
            using (var context = new SQLDataDataContext())
            {
                var abteilungID = "A_" + IdCreator.Generate();

                context.Personal.InsertOnSubmit(new Personal()
                {
                    personal_nr = IdCreator.Generate().ToString(),
                    abteilung_id = abteilungID,
                    vname = NameParser.ReceivePreAndLastname(employee.Name).First(),
                    nname = NameParser.ReceivePreAndLastname(employee.Name).Last()
                });

                context.Abteilung.InsertOnSubmit(new Abteilung()
                {
                    name = employee.Abteilung,
                    abteilung_id = abteilungID
                });

                context.SubmitChanges(ConflictMode.ContinueOnConflict);
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
                return context.Personal.Any(x => x.personal_nr.Equals(id));
        }
    }
}
