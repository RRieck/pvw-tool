using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StartUp.Infrastructure.Validator
{
    public static class Validate
    {

        public static Tuple<bool, int> IntegerValidator(string input)
        {
            int option;
            bool isInteger = int.TryParse(input, out option);

            return Tuple.Create(isInteger, option);
        }

        public static bool CheckValidString(string inputString)
        {
            var regex = new Regex("^[a-zA-Z0-9 äüöÄÜÖß]*$");
            if (!regex.IsMatch(inputString))
            {
                return false;
            }
            return true;
        }
    }
}
