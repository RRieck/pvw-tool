using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using StartUp.Datenhaltung.DoNotTouchThis.ISaidDoNot;
using StartUp.Infrastructure.Extensions;
using StartUp.Model.SqLiteModels;
using Employee = StartUp.Model.Employee;

namespace StartUp.Datenhaltung
{
    class SqliteDataAccess : IDatenhaltung
    {
        public SqliteDataAccess()
        {
            SQLitePCL.Batteries.Init();
            Init();
        }

        void Init()
        {
            using (IDbConnection con = new SqliteConnection(ReceiveConnectionString()))
            {
                con.Execute("delete FROM Department");

                var departments = new List<string>() { "Personalabteilung", "Entwickler", "Netzwerk", "Managment" };
                for (int i = 1; i < 5; i++)
                {
                    con.Execute("Insert into Department (department_id, name) values (@department_id, @name)", new Model.SqLiteModels.Department()
                    {
                        department_id = i.ToString(),
                        name = departments[i - 1]
                    });
                }
            }
        }

        List<Department> GetDepartments()
        {
            using (IDbConnection con = new SqliteConnection(ReceiveConnectionString()))
            {
                return con.Query<Model.SqLiteModels.Department>("select department_id, name from Department", new DynamicParameters()).ToList();
            }
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employeeAccordingToDepartureList = new List<Employee>();
            using (IDbConnection con = new SqliteConnection(ReceiveConnectionString()))
            {
                var employees = con.Query<Model.SqLiteModels.Employee>("select employee_nr, firstname,lastname, department_id from Employee", new DynamicParameters()).ToList();
                var departments = con.Query<Model.SqLiteModels.Department>("select department_id, name from Department", new DynamicParameters()).ToList();

                for (int i = 0; i < employees.Count; i++)
                {
                    employeeAccordingToDepartureList.Add(new Employee()
                    {
                        Id = employees[i].employee_nr,
                        Name = employees[i].firstname + " " + employees[i].lastname,
                        Abteilung = departments.Where(entry => entry.department_id == employees[i].department_id).Select(entry => entry.name).First()
                    });
                }
            }
            return employeeAccordingToDepartureList;
        }

        public void WriteNewEntry(Employee employee)
        {
            var departments = GetDepartments();

            using (IDbConnection con = new SqliteConnection(ReceiveConnectionString()))
            {
                con.Execute("Insert into Employee (employee_nr, firstname, lastname, department_id) values (@employee_nr, @firstname, @lastname, @department_id)", new Model.SqLiteModels.Employee()
                {
                    employee_nr = IdCreator.Generate().ToString(),
                    firstname = NameParser.ReceivePreAndLastname(employee.Name).First(),
                    lastname = NameParser.ReceivePreAndLastname(employee.Name).Last(),
                    department_id = departments.Where(x => x.name.Equals(employee.Abteilung)).Select(x => x.department_id).First()
                });
            }
        }

        public void DeleteEntry(string id)
        {
            using (IDbConnection con = new SqliteConnection(ReceiveConnectionString()))
            {
                var employeeObj = con.Query<Model.SqLiteModels.Employee>($"select employee_nr, firstname,lastname, department_id from Employee where employee_nr = '{id}'", new DynamicParameters()).ToList().First();
                con.Execute($"delete from Employee where employee_nr = '{id}'");
                con.Execute($"delete from Department where department_id = '{employeeObj.department_id}'");
            }
        }

        public void ChangeExistingEntry(Employee employee)
        {
            using (IDbConnection con = new SqliteConnection(ReceiveConnectionString()))
            {
                var employeeObj = con.Query<Model.SqLiteModels.Employee>($"select employee_nr, firstname,lastname, department_id from Employee where employee_nr = '{employee.Id}'", new DynamicParameters()).ToList().First();
                con.Execute($"update Employee set firstname = '{NameParser.ReceivePreAndLastname(employee.Name).First()}', lastname = '{NameParser.ReceivePreAndLastname(employee.Name).Last()}' where employee_nr = '{employee.Id}'");
                con.Execute($"update Department set name = '{employee.Abteilung}' where department_id = '{employeeObj.department_id}'");
            }
        }

        string ReceiveConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["SqLiteConn"].ConnectionString;
        }
    }
}
