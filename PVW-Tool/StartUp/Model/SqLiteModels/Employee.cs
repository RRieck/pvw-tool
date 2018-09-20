using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp.Model.SqLiteModels
{
    class Employee
    {
        public string employee_nr { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string department_id { get; set; }
    }
}
