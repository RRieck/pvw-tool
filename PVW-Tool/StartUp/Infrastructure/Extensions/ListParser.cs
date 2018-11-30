using StartUp.Model;
using System.Collections.Generic;

namespace StartUp.Infrastructure.Extensions
{
    public static class ListParser
    {
        public static List<Employee> DeleteContainedEntries(List<Employee> list)
        {
            var resultList = new List<Employee>();

            foreach (var item in list)
            {
                if (!resultList.Contains(item))
                    resultList.Add(item);
            }

            return resultList;
        }
    }
}
