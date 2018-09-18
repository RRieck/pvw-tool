using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp.Infrastructure.Extensions
{
    public static class IdCreator
    {
        public static Guid Generate()
        {
            return Guid.NewGuid();
        }
    }
}
