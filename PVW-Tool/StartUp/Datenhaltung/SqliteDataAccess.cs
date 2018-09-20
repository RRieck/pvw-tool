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
using StartUp.Model;

namespace StartUp.Datenhaltung
{
    class SqliteDataAccess : IDatenhaltung
    {
        public SqliteDataAccess()
        {
               SQLitePCL.Batteries.Init();
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employeeAccordingToDepartureList = new List<Employee>();
            using (IDbConnection con = new SqliteConnection(ReceiveConnectionString()))
            {
                var employees =  con.Query<Model.SqLiteModels.Employee>("select employee_nr, firstname,lastname, department_id from Employee",new DynamicParameters()).ToList();
                var departments =  con.Query<Model.SqLiteModels.Department>("select department_id, name from Department",new DynamicParameters()).ToList();

                for (int i = 0; i < employees.Count ; i++)
                {
                    employeeAccordingToDepartureList.Add(new Employee()
                    {
                        Id = employees[i].employee_nr,
                        Name = employees[i].firstname +  " " + employees[i].lastname,
                        Abteilung = departments.Where(entry => entry.department_id == employees[i].department_id).Select(entry => entry.name).First()
                    });
                }
            }
            return employeeAccordingToDepartureList;
        }

        public void WriteNewEntry(Employee employee)
        {
            using (IDbConnection con = new SqliteConnection(ReceiveConnectionString()))
            {
                var employeNR  = IdCreator.Generate();
                var departmentID  = "A_" + IdCreator.Generate();

                con.Execute("Insert into Employee (employee_nr, firstname, lastname, department_id) values (@employee_nr, @firstname, @lastname, @department_id)", new Model.SqLiteModels.Employee(){
                    employee_nr = employeNR.ToString(),
                    firstname = NameParser.ReceivePreAndLastname(employee.Name).First(),
                    lastname = NameParser.ReceivePreAndLastname(employee.Name).Last(),
                    department_id = departmentID
                });

                con.Execute("Insert into Department (department_id, name) values (@department_id, @name)", new Model.SqLiteModels.Department(){
                    department_id = departmentID,
                    name = employee.Abteilung
                });
            }
        }

        public void DeleteEntry(string id)
        {
            using(IDbConnection con = new SqliteConnection(ReceiveConnectionString()))
            {
                var employeeObj =  con.Query<Model.SqLiteModels.Employee>($"select employee_nr, firstname,lastname, department_id from Employee where employee_nr = '{id}'",new DynamicParameters()).ToList().First();
                con.Execute($"delete from Employee where employee_nr = '{id}'");
                con.Execute($"delete from Department where department_id = '{employeeObj.department_id}'");
            }
        }

        public void ChangeExistingEntry(Employee employee)
        {
           using(IDbConnection con = new SqliteConnection(ReceiveConnectionString()))
            {
                var employeeObj =  con.Query<Model.SqLiteModels.Employee>($"select employee_nr, firstname,lastname, department_id from Employee where employee_nr = '{employee.Id}'",new DynamicParameters()).ToList().First();
                con.Execute($"update Employee set firstname = '{NameParser.ReceivePreAndLastname(employee.Name).First()}', lastname = '{NameParser.ReceivePreAndLastname(employee.Name).Last()}' where employee_nr = '{employee.Id}'");
                con.Execute($"update Department set name = '{employee.Abteilung}' where department_id = '{employeeObj.department_id}'");
            }
        }

        

        private string ReceiveConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["SqLiteConn"].ConnectionString;
        }
    }
}
