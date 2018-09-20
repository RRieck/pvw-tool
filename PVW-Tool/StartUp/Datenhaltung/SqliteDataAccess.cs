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
using StartUp.Model;

namespace StartUp.Datenhaltung
{
    class SqliteDataAccess : IDatenhaltung
    {
        public List<Employee> GetEmployees()
        {
            using (IDbConnection con = new SqliteConnection(ReceiveConnectionString()))
            {
                return con.Query<Employee>("select",new DynamicParameters()).ToList();
            }
        }

        public void WriteNewEntry(Employee employee)
        {
            throw new NotImplementedException();
        }

        private string ReceiveConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["SqLiteConn"].ConnectionString;
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
