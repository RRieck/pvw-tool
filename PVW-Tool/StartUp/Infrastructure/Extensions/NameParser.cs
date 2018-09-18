using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp.Infrastructure.Extensions
{
     public static class NameParser
    {
        public static List<string> ReceivePreAndLastname(string name)
        {
           return new List<string>(){
                name.Split(new[] { ' ' }, StringSplitOptions.None).First(),
                name.Split(new[] { ' ' }, StringSplitOptions.None).Last()
            };
        }
    }
}
