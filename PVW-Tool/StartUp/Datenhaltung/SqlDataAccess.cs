using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Serialization;
using System.Windows.Controls;
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
                        Abteilung  = abteilungsname
                    };    
                    employees.Add(newEmployee);
                }
            }
            return employees;
        }
        
        public void WriteNewEntry(Employee employee)
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

                context.SubmitChanges();
            }
        }

        public void ChangeExistingEntry(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntry(string id)
        {
            throw new NotImplementedException();
        }
    }
}
