using System.Collections.Generic;
using System.Linq;
using lemberg.Models;

namespace lemberg.Helpers
{
    public static class SortHelper
    {
        public static IEnumerable<People> Order(this IEnumerable<People> peoples, string orderBy)
        {
            switch (orderBy)
            {
                case "FirstName":
                    peoples = peoples.OrderBy(p => p.FirstName);
                    break;
                case "LastName":
                    peoples = peoples.OrderBy(p => p.LastName);
                    break;
                case "MarkValue":
                    peoples = peoples.OrderBy(p => p.Mark.Value);
                    break;
            }

            return peoples;
        }
    }
}