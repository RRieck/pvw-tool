using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp.Infrastructure.Converter
{
    public static class IDConverter
    {
        public static string DepartmentIdConverter(int department_id)
        {
            switch (department_id)
            {
                case 1:
                    return "Personalabteilung";
                case 2:
                    return "Entwickler";
                case 3:
                    return "Netzwerk";
                case 4:
                    return "Managment";
                default:
                    return "";
            }
        }
    }
}
